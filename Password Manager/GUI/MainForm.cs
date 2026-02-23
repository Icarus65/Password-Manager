using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Data;

namespace Password_Manager.GUI
{
    public partial class MainForm : Form
    {
        private PasswordDbContext? _context;
        private VaultManager? _vaultManager;
        private TabControl? _tabControl;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _context = CreateDbContext();
            _context.Database.EnsureCreated();
            _vaultManager = new VaultManager(_context);

            if (!LoginCheck(_vaultManager))
            {
                Close();
                return;
            }

            InitializeTabs(_vaultManager);
        }

        private void InitializeTabs(VaultManager vaultManager)
        {
            _tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            var vaultTab = new TabPage("Vault");
            var generatorTab = new TabPage("Generator");
            var settingsTab = new TabPage("Settings");

            var addEditEntryForm = new AddEditEntryForm(vaultManager) { Dock = DockStyle.Fill };
            var generatorForm = new PasswordGeneratorForm { Dock = DockStyle.Fill };
            var settingsForm = new SettingsForm(vaultManager) { Dock = DockStyle.Fill };

            vaultTab.Controls.Add(addEditEntryForm);
            generatorTab.Controls.Add(generatorForm);
            settingsTab.Controls.Add(settingsForm);

            _tabControl.TabPages.Add(vaultTab);
            _tabControl.TabPages.Add(generatorTab);
            _tabControl.TabPages.Add(settingsTab);

            Controls.Add(_tabControl);
        }

        private bool LoginCheck(VaultManager vaultManager)
        {
            var exists = vaultManager.MasterPasswordExists();
            using var loginForm = new LoginForm(vaultManager, !exists);
            return loginForm.ShowDialog(this) == DialogResult.OK;
        }

        private static PasswordDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PasswordDbContext>();
            optionsBuilder.UseSqlite("Data Source=passwordvault.db");
            return new PasswordDbContext(optionsBuilder.Options);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _context?.Dispose();
        }
    }
}
