using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Navigation property - all entries in this category
        public List<PasswordEntry> Entries { get; set; } = new List<PasswordEntry>();
    }
}