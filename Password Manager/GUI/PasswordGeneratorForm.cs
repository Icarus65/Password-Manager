using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Security;

namespace Password_Manager.GUI
{
    public partial class PasswordGeneratorForm : UserControl
    {
        private readonly PasswordGenerator _generator = new PasswordGenerator();

        public PasswordGeneratorForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var length = (int)numLength.Value;
            var includeUpper = chkUpper.Checked;
            var includeLower = chkLower.Checked;
            var includeDigits = chkDigits.Checked;
            var includeSymbols = chkSymbols.Checked;

            if (!includeUpper && !includeLower && !includeDigits && !includeSymbols)
            {
                MessageBox.Show("Select at least one character type.", "Validation");
                return;
            }

            var password = _generator.GeneratePassword(length, includeUpper, includeLower, includeDigits, includeSymbols);
            txtGenerated.Text = password;

            var strength = _generator.CalculatePasswordStrength(password);
            var strengthText = _generator.GetPasswordStrengthText(strength);
            lblStrength.Text = $"Strength: {strength}/100 ({strengthText})";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGenerated.Text))
            {
                Clipboard.SetText(txtGenerated.Text);
            }
        }
    }
}
