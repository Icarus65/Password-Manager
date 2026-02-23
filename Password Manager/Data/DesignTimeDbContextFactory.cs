using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PasswordManager.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PasswordDbContext>
    {
        public PasswordDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PasswordDbContext>();
            optionsBuilder.UseSqlite("Data Source=passwordvault.db");

            return new PasswordDbContext(optionsBuilder.Options);
        }
    }
}