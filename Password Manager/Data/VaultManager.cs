using Microsoft.EntityFrameworkCore;
using PasswordManager.Models;
using PasswordManager.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManager.Data
{
    public class VaultManager
    {
        private readonly PasswordDbContext _context;
        private readonly EncryptionService _encryptionService;
        private string _currentMasterPassword;  // Keep in memory during session

        public VaultManager(PasswordDbContext context)
        {
            _context = context;
            _encryptionService = new EncryptionService();
        }

        // Set the master password for this session (after login)
        public void SetMasterPassword(string masterPassword)
        {
            _currentMasterPassword = masterPassword;
        }

        #region Master Password Methods

        // Check if master password exists
        public bool MasterPasswordExists()
        {
            return _context.MasterPasswords.Any();
        }

        // Create master password (first-time setup)
        public void CreateMasterPassword(string masterPassword)
        {
            if (MasterPasswordExists())
                throw new InvalidOperationException("Master password already exists");

            var hasher = new PasswordHasher();
            var (hash, salt) = hasher.HashPassword(masterPassword);

            var master = new MasterPassword
            {
                PasswordHash = hash,
                Salt = salt,
                CreatedAt = DateTime.Now
            };

            _context.MasterPasswords.Add(master);
            _context.SaveChanges();

            _currentMasterPassword = masterPassword;
        }

        // Verify master password
        public bool VerifyMasterPassword(string masterPassword)
        {
            var master = _context.MasterPasswords.FirstOrDefault();
            if (master == null)
                return false;

            var hasher = new PasswordHasher();
            bool isValid = hasher.VerifyPassword(masterPassword, master.PasswordHash, master.Salt);

            if (isValid)
                _currentMasterPassword = masterPassword;

            return isValid;
        }

        public void ChangeMasterPassword(string currentPassword, string newPassword)
        {
            if (!VerifyMasterPassword(currentPassword))
                throw new InvalidOperationException("Current master password is incorrect");

            var entries = _context.PasswordEntries.ToList();
            foreach (var entry in entries)
            {
                var decrypted = _encryptionService.Decrypt(entry.EncryptedPassword, currentPassword);
                entry.SetEncryptedPassword(_encryptionService.Encrypt(decrypted, newPassword));
                entry.UpdatedAt = DateTime.Now;
            }

            var hasher = new PasswordHasher();
            var (hash, salt) = hasher.HashPassword(newPassword);

            var master = _context.MasterPasswords.First();
            master.PasswordHash = hash;
            master.Salt = salt;
            master.LastChanged = DateTime.Now;

            _context.SaveChanges();

            _currentMasterPassword = newPassword;
        }

        public void ResetVault(string newMasterPassword)
        {
            _context.PasswordEntries.RemoveRange(_context.PasswordEntries);
            _context.MasterPasswords.RemoveRange(_context.MasterPasswords);
            _context.SaveChanges();

            CreateMasterPassword(newMasterPassword);
        }

        #endregion

        #region Category Methods

        public List<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        #endregion

        #region Password Entry Methods

        // Add a new password entry
        public void AddPasswordEntry(PasswordEntry entry, string plainPassword)
        {
            if (string.IsNullOrEmpty(_currentMasterPassword))
                throw new InvalidOperationException("Master password not set");

            // Encrypt the password
            entry.SetEncryptedPassword(_encryptionService.Encrypt(plainPassword, _currentMasterPassword));
            entry.CreatedAt = DateTime.Now;
            entry.LastUsed = DateTime.Now;

            _context.PasswordEntries.Add(entry);
            _context.SaveChanges();
        }

        // Update password entry
        public void UpdatePasswordEntry(PasswordEntry entry, string plainPassword = null)
        {
            if (string.IsNullOrEmpty(_currentMasterPassword))
                throw new InvalidOperationException("Master password not set");

            var existing = _context.PasswordEntries.Find(entry.Id);
            if (existing == null)
                throw new ArgumentException("Entry not found");

            existing.Website = entry.Website;
            existing.Username = entry.Username;
            existing.Notes = entry.Notes;
            existing.CategoryId = entry.CategoryId;
            existing.UpdatedAt = DateTime.Now;

            // Update password if provided
            if (!string.IsNullOrEmpty(plainPassword))
            {
                existing.SetEncryptedPassword(_encryptionService.Encrypt(plainPassword, _currentMasterPassword));
                existing.LastUsed = DateTime.Now;
            }

            _context.SaveChanges();
        }

        // Delete password entry
        public void DeletePasswordEntry(int id)
        {
            var entry = _context.PasswordEntries.Find(id);
            if (entry != null)
            {
                _context.PasswordEntries.Remove(entry);
                _context.SaveChanges();
            }
        }

        // Get all password entries (with decrypted passwords)
        public List<PasswordEntry> GetAllPasswordEntries()
        {
            if (string.IsNullOrEmpty(_currentMasterPassword))
                throw new InvalidOperationException("Master password not set");

            var entries = _context.PasswordEntries
                .Include(e => e.Category)
                .OrderBy(e => e.Website)
                .ToList();

            // Decrypt passwords for display
            foreach (var entry in entries)
            {
                try
                {
                    entry.DecryptedPassword = _encryptionService.Decrypt(
                        entry.EncryptedPassword,
                        _currentMasterPassword);
                }
                catch
                {
                    entry.DecryptedPassword = "[Decryption Error]";
                }
            }

            return entries;
        }

        // Get entry by ID (with decrypted password)
        public PasswordEntry GetPasswordEntryById(int id)
        {
            if (string.IsNullOrEmpty(_currentMasterPassword))
                throw new InvalidOperationException("Master password not set");

            var entry = _context.PasswordEntries
                .Include(e => e.Category)
                .FirstOrDefault(e => e.Id == id);

            if (entry != null)
            {
                try
                {
                    entry.DecryptedPassword = _encryptionService.Decrypt(
                        entry.EncryptedPassword,
                        _currentMasterPassword);
                }
                catch
                {
                    entry.DecryptedPassword = "[Decryption Error]";
                }
            }

            return entry;
        }

        // Search entries
        public List<PasswordEntry> SearchEntries(string searchTerm)
        {
            if (string.IsNullOrEmpty(_currentMasterPassword))
                throw new InvalidOperationException("Master password not set");

            var entries = _context.PasswordEntries
                .Include(e => e.Category)
                .Where(e => e.Website.Contains(searchTerm) ||
                           e.Username.Contains(searchTerm) ||
                           e.Notes.Contains(searchTerm))
                .ToList();

            // Decrypt passwords
            foreach (var entry in entries)
            {
                try
                {
                    entry.DecryptedPassword = _encryptionService.Decrypt(
                        entry.EncryptedPassword,
                        _currentMasterPassword);
                }
                catch
                {
                    entry.DecryptedPassword = "[Decryption Error]";
                }
            }

            return entries;
        }

        // Get entries by category
        public List<PasswordEntry> GetEntriesByCategory(int categoryId)
        {
            if (string.IsNullOrEmpty(_currentMasterPassword))
                throw new InvalidOperationException("Master password not set");

            var entries = _context.PasswordEntries
                .Include(e => e.Category)
                .Where(e => e.CategoryId == categoryId)
                .ToList();

            // Decrypt passwords
            foreach (var entry in entries)
            {
                try
                {
                    entry.DecryptedPassword = _encryptionService.Decrypt(
                        entry.EncryptedPassword,
                        _currentMasterPassword);
                }
                catch
                {
                    entry.DecryptedPassword = "[Decryption Error]";
                }
            }

            return entries;
        }

        // Update last used timestamp
        public void UpdateLastUsed(int entryId)
        {
            var entry = _context.PasswordEntries.Find(entryId);
            if (entry != null)
            {
                entry.LastUsed = DateTime.Now;
                _context.SaveChanges();
            }
        }

        #endregion

        #region Statistics

        public int GetTotalEntriesCount()
        {
            return _context.PasswordEntries.Count();
        }

        public Dictionary<string, int> GetEntriesCountByCategory()
        {
            return _context.PasswordEntries
                .Include(e => e.Category)
                .GroupBy(e => e.Category.Name)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        #endregion
    }
}