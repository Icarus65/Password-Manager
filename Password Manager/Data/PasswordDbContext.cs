using Microsoft.EntityFrameworkCore;
using PasswordManager.Models;

namespace PasswordManager.Data
{
    public class PasswordDbContext : DbContext
    {
        public PasswordDbContext(DbContextOptions<PasswordDbContext> options)
            : base(options)
        {
        }

        public DbSet<PasswordEntry> PasswordEntries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MasterPassword> MasterPasswords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PasswordEntry configuration
            modelBuilder.Entity<PasswordEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Website).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EncryptedPassword).IsRequired();
                entity.Property(e => e.Notes).HasMaxLength(500);

                // Relationship with Category
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Entries)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);  // Can't delete category with entries
            });

            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            // MasterPassword configuration
            modelBuilder.Entity<MasterPassword>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Salt).IsRequired();
            });

            // Seed default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Social Media" },
                new Category { Id = 2, Name = "Email" },
                new Category { Id = 3, Name = "Banking" },
                new Category { Id = 4, Name = "Shopping" },
                new Category { Id = 5, Name = "Work" },
                new Category { Id = 6, Name = "Gaming" },
                new Category { Id = 7, Name = "Other" }
            );
        }
    }
}