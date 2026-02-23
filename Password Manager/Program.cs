using Microsoft.EntityFrameworkCore;
using Password_Manager.GUI;
using PasswordManager.Data;

namespace Password_Manager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            InitializeDatabase();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        private static void InitializeDatabase()
        {
            using var context = CreateDbContext();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
                return;
            }

            context.Database.EnsureCreated();
        }

        private static PasswordDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PasswordDbContext>();
            optionsBuilder.UseSqlite("Data Source=passwordvault.db");

            return new PasswordDbContext(optionsBuilder.Options);
        }
    }
}