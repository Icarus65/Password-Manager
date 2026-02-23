using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Models
{
    public class PasswordEntry
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Website { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string EncryptedPassword { get; private set; } = string.Empty;

        public void SetEncryptedPassword(string encryptedPassword)
        {
            EncryptedPassword = encryptedPassword;
        }

        [MaxLength(500)]
        public string Notes { get; set; }

        // Foreign key to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastUsed { get; set; }  // When password was last copied

        // Not stored in database - for display only
        [NotMapped]
        public string DecryptedPassword { get; set; }
    }
}