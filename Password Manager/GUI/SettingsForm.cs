using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Data;

namespace Password_Manager.GUI
{
    public partial class SettingsForm : UserControl
    {
        private readonly VaultManager? _vaultManager;

        public SettingsForm() : this(null)
        {
        }

        public SettingsForm(VaultManager? vaultManager)
        {
            _vaultManager = vaultManager;
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (_vaultManager == null)
                return;

            if (string.IsNullOrWhiteSpace(txtCurrent.Text) ||
                string.IsNullOrWhiteSpace(txtNew.Text) ||
                string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation");
                return;
            }

            if (txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show("New passwords do not match.", "Validation");
                return;
            }

            try
            {
                _vaultManager.ChangeMasterPassword(txtCurrent.Text, txtNew.Text);
                MessageBox.Show("Master password updated.", "Success");
                txtCurrent.Clear();
                txtNew.Clear();
                txtConfirm.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
