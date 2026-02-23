using PasswordManager.Data;
using PasswordManager.Models;

namespace Password_Manager.GUI
{
    public partial class AddEditEntryForm : UserControl
    {
        private readonly VaultManager? _vaultManager;
        private List<PasswordEntry> _entries = new();
        private List<Category> _categories = new();
        private PasswordEntry? _selectedEntry;
        private bool _gridInitialized;

        public AddEditEntryForm() : this(null)
        {
        }

        public AddEditEntryForm(VaultManager? vaultManager)
        {
            _vaultManager = vaultManager;
            InitializeComponent();
        }

        private void AddEditEntryForm_Load(object sender, EventArgs e)
        {
            if (_vaultManager == null)
                return;

            InitializeGrid();
            LoadCategories();
            LoadEntries();
        }

        private void InitializeGrid()
        {
            if (_gridInitialized)
                return;

            entriesGrid.AutoGenerateColumns = false;
            entriesGrid.Columns.Clear();

            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            };

            entriesGrid.Columns.Add(idColumn);
            entriesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Website",
                HeaderText = "Website",
                DataPropertyName = "Website"
            });
            entriesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username"
            });
            entriesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category"
            });
            entriesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Notes",
                HeaderText = "Notes",
                DataPropertyName = "Notes"
            });
            entriesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastUsed",
                HeaderText = "Last Used",
                DataPropertyName = "LastUsed"
            });

            _gridInitialized = true;
        }

        private void LoadCategories()
        {
            _categories = _vaultManager!.GetAllCategories();
            cboCategory.DataSource = _categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }

        private void LoadEntries()
        {
            _entries = _vaultManager!.GetAllPasswordEntries();
            var view = _entries.Select(e => new PasswordEntryView
            {
                Id = e.Id,
                Website = e.Website,
                Username = e.Username,
                Category = e.Category?.Name ?? string.Empty,
                Notes = e.Notes ?? string.Empty,
                LastUsed = e.LastUsed
            }).ToList();

            entriesGrid.DataSource = view;
        }

        private void entriesGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (entriesGrid.SelectedRows.Count == 0)
                return;

            var id = Convert.ToInt32(entriesGrid.SelectedRows[0].Cells["Id"].Value);
            _selectedEntry = _entries.FirstOrDefault(e => e.Id == id);
            if (_selectedEntry == null)
                return;

            txtWebsite.Text = _selectedEntry.Website;
            txtUsername.Text = _selectedEntry.Username;
            txtPassword.Text = _selectedEntry.DecryptedPassword ?? string.Empty;
            txtNotes.Text = _selectedEntry.Notes ?? string.Empty;
            cboCategory.SelectedValue = _selectedEntry.CategoryId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_vaultManager == null)
                return;

            if (!TryGetEntryInput(out var entry, out var plainPassword))
                return;

            _vaultManager.AddPasswordEntry(entry, plainPassword);
            LoadEntries();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_vaultManager == null || _selectedEntry == null)
                return;

            if (!TryGetEntryInput(out var entry, out var plainPassword))
                return;

            entry.Id = _selectedEntry.Id;
            _vaultManager.UpdatePasswordEntry(entry, string.IsNullOrWhiteSpace(plainPassword) ? null : plainPassword);
            LoadEntries();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_vaultManager == null || _selectedEntry == null)
                return;

            var result = MessageBox.Show("Delete the selected entry?", "Confirm", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            _vaultManager.DeletePasswordEntry(_selectedEntry.Id);
            LoadEntries();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            if (_selectedEntry == null)
                return;

            if (!string.IsNullOrEmpty(_selectedEntry.DecryptedPassword))
            {
                Clipboard.SetText(_selectedEntry.DecryptedPassword);
                _vaultManager?.UpdateLastUsed(_selectedEntry.Id);
                LoadEntries();
            }
        }

        private bool TryGetEntryInput(out PasswordEntry entry, out string plainPassword)
        {
            entry = null!;
            plainPassword = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtWebsite.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(plainPassword) ||
                cboCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation");
                return false;
            }

            entry = new PasswordEntry
            {
                Website = txtWebsite.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? string.Empty : txtNotes.Text.Trim(),
                CategoryId = (int)cboCategory.SelectedValue
            };

            return true;
        }

        private void ClearFields()
        {
            _selectedEntry = null;
            txtWebsite.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtNotes.Clear();
            entriesGrid.ClearSelection();
        }

        private sealed class PasswordEntryView
        {
            public int Id { get; set; }
            public string Website { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public string Notes { get; set; } = string.Empty;
            public DateTime? LastUsed { get; set; }
        }
    }
}
