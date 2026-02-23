using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    public class MasterPassword
    {
        public int Id { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Salt { get; set; }  // Salt used for hashing

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastChanged { get; set; }
    }
}