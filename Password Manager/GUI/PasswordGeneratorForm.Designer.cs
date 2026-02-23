namespace Password_Manager.GUI
{
    partial class PasswordGeneratorForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblLength = new Label();
            numLength = new NumericUpDown();
            chkUpper = new CheckBox();
            chkLower = new CheckBox();
            chkDigits = new CheckBox();
            chkSymbols = new CheckBox();
            btnGenerate = new Button();
            txtGenerated = new TextBox();
            lblStrength = new Label();
            btnCopy = new Button();
            ((System.ComponentModel.ISupportInitialize)numLength).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Password Generator";
            // 
            // lblLength
            // 
            lblLength.AutoSize = true;
            lblLength.Location = new Point(20, 60);
            lblLength.Name = "lblLength";
            lblLength.Size = new Size(47, 15);
            lblLength.TabIndex = 1;
            lblLength.Text = "Length";
            // 
            // numLength
            // 
            numLength.Location = new Point(20, 78);
            numLength.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numLength.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            numLength.Name = "numLength";
            numLength.Size = new Size(120, 23);
            numLength.TabIndex = 2;
            numLength.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // chkUpper
            // 
            chkUpper.AutoSize = true;
            chkUpper.Checked = true;
            chkUpper.CheckState = CheckState.Checked;
            chkUpper.Location = new Point(20, 118);
            chkUpper.Name = "chkUpper";
            chkUpper.Size = new Size(85, 19);
            chkUpper.TabIndex = 3;
            chkUpper.Text = "Uppercase";
            chkUpper.UseVisualStyleBackColor = true;
            // 
            // chkLower
            // 
            chkLower.AutoSize = true;
            chkLower.Checked = true;
            chkLower.CheckState = CheckState.Checked;
            chkLower.Location = new Point(20, 143);
            chkLower.Name = "chkLower";
            chkLower.Size = new Size(83, 19);
            chkLower.TabIndex = 4;
            chkLower.Text = "Lowercase";
            chkLower.UseVisualStyleBackColor = true;
            // 
            // chkDigits
            // 
            chkDigits.AutoSize = true;
            chkDigits.Checked = true;
            chkDigits.CheckState = CheckState.Checked;
            chkDigits.Location = new Point(20, 168);
            chkDigits.Name = "chkDigits";
            chkDigits.Size = new Size(56, 19);
            chkDigits.TabIndex = 5;
            chkDigits.Text = "Digits";
            chkDigits.UseVisualStyleBackColor = true;
            // 
            // chkSymbols
            // 
            chkSymbols.AutoSize = true;
            chkSymbols.Checked = true;
            chkSymbols.CheckState = CheckState.Checked;
            chkSymbols.Location = new Point(20, 193);
            chkSymbols.Name = "chkSymbols";
            chkSymbols.Size = new Size(71, 19);
            chkSymbols.TabIndex = 6;
            chkSymbols.Text = "Symbols";
            chkSymbols.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(20, 226);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(120, 23);
            btnGenerate.TabIndex = 7;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // txtGenerated
            // 
            txtGenerated.Location = new Point(200, 78);
            txtGenerated.Multiline = true;
            txtGenerated.Name = "txtGenerated";
            txtGenerated.ReadOnly = true;
            txtGenerated.Size = new Size(260, 100);
            txtGenerated.TabIndex = 8;
            // 
            // lblStrength
            // 
            lblStrength.AutoSize = true;
            lblStrength.Location = new Point(200, 190);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new Size(56, 15);
            lblStrength.TabIndex = 9;
            lblStrength.Text = "Strength:";
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(200, 226);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(120, 23);
            btnCopy.TabIndex = 10;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // PasswordGeneratorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCopy);
            Controls.Add(lblStrength);
            Controls.Add(txtGenerated);
            Controls.Add(btnGenerate);
            Controls.Add(chkSymbols);
            Controls.Add(chkDigits);
            Controls.Add(chkLower);
            Controls.Add(chkUpper);
            Controls.Add(numLength);
            Controls.Add(lblLength);
            Controls.Add(lblTitle);
            Name = "PasswordGeneratorForm";
            Size = new Size(500, 300);
            ((System.ComponentModel.ISupportInitialize)numLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblLength;
        private NumericUpDown numLength;
        private CheckBox chkUpper;
        private CheckBox chkLower;
        private CheckBox chkDigits;
        private CheckBox chkSymbols;
        private Button btnGenerate;
        private TextBox txtGenerated;
        private Label lblStrength;
        private Button btnCopy;
    }
}
