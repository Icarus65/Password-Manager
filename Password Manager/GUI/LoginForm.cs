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
    public partial class LoginForm : Form
    {
        private readonly VaultManager _vaultManager;
        private readonly bool _isFirstTime;

        public LoginForm(VaultManager vaultManager, bool isFirstTime)
        {
            _vaultManager = vaultManager;
            _isFirstTime = isFirstTime;
            InitializeComponent();

            if (_isFirstTime)
            {
                lblTitle.Text = "Create Master Password";
                lblConfirm.Visible = true;
                txtConfirm.Visible = true;
                chkCreateNew.Visible = false;
            }
            else
            {
                lblTitle.Text = "Enter Master Password";
                lblConfirm.Visible = false;
                txtConfirm.Visible = false;
                chkCreateNew.Visible = true;
            }
        }

        public string MasterPassword => txtPassword.Text;

        private void btnOk_Click(object sender, EventArgs e)
        {
            var password = txtPassword.Text;
            var creating = _isFirstTime || chkCreateNew.Checked;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a master password.", "Validation");
                return;
            }

            try
            {
                if (creating)
                {
                    if (password != txtConfirm.Text)
                    {
                        MessageBox.Show("Passwords do not match.", "Validation");
                        return;
                    }

                    if (_isFirstTime)
                    {
                        _vaultManager.CreateMasterPassword(password);
                    }
                    else
                    {
                        var result = MessageBox.Show("This will reset the vault and remove existing entries. Continue?", "Confirm", MessageBoxButtons.YesNo);
                        if (result != DialogResult.Yes)
                            return;

                        _vaultManager.ResetVault(password);
                    }
                }
                else
                {
                    if (!_vaultManager.VerifyMasterPassword(password))
                    {
                        MessageBox.Show("Invalid master password.", "Login Failed");
                        return;
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            var creating = chkCreateNew.Checked;
            lblTitle.Text = creating ? "Create Master Password" : "Enter Master Password";
            lblConfirm.Visible = creating;
            txtConfirm.Visible = creating;
            if (!creating)
            {
                txtConfirm.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
