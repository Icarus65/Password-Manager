using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Security
{
    public class PasswordHasher
    {
        // Hash a password with a random salt
        public (string hash, string salt) HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be empty");

            // Generate a random salt (16 bytes)
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Hash the password with the salt
            string hash = HashPasswordWithSalt(password, salt);

            return (hash, salt);
        }

        // Verify a password against a stored hash and salt
        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(storedSalt))
                return false;

            // Hash the provided password with the stored salt
            string hashToVerify = HashPasswordWithSalt(password, storedSalt);

            // Compare the hashes (constant-time comparison to prevent timing attacks)
            return SlowEquals(Convert.FromBase64String(hashToVerify),
                             Convert.FromBase64String(storedHash));
        }

        // Hash password with a given salt using PBKDF2
        private string HashPasswordWithSalt(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            // Use PBKDF2 with 100,000 iterations (very secure, slower to crack)
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);  // 32 bytes = 256 bits
                return Convert.ToBase64String(hash);
            }
        }

        // Constant-time comparison to prevent timing attacks
        private bool SlowEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }
    }
}