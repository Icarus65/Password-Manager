namespace Password_Manager.GUI
{
    partial class SettingsForm
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
            lblCurrent = new Label();
            txtCurrent = new TextBox();
            lblNew = new Label();
            txtNew = new TextBox();
            lblConfirm = new Label();
            txtConfirm = new TextBox();
            btnChange = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Change Master Password";
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(20, 60);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(95, 15);
            lblCurrent.TabIndex = 1;
            lblCurrent.Text = "Current Password";
            // 
            // txtCurrent
            // 
            txtCurrent.Location = new Point(20, 78);
            txtCurrent.Name = "txtCurrent";
            txtCurrent.Size = new Size(260, 23);
            txtCurrent.TabIndex = 2;
            txtCurrent.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new Point(20, 112);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(78, 15);
            lblNew.TabIndex = 3;
            lblNew.Text = "New Password";
            // 
            // txtNew
            // 
            txtNew.Location = new Point(20, 130);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(260, 23);
            txtNew.TabIndex = 4;
            txtNew.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(20, 164);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(103, 15);
            lblConfirm.TabIndex = 5;
            lblConfirm.Text = "Confirm Password";
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(20, 182);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(260, 23);
            txtConfirm.TabIndex = 6;
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(205, 220);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 23);
            btnChange.TabIndex = 7;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnChange);
            Controls.Add(txtConfirm);
            Controls.Add(lblConfirm);
            Controls.Add(txtNew);
            Controls.Add(lblNew);
            Controls.Add(txtCurrent);
            Controls.Add(lblCurrent);
            Controls.Add(lblTitle);
            Name = "SettingsForm";
            Size = new Size(400, 280);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrent;
        private TextBox txtCurrent;
        private Label lblNew;
        private TextBox txtNew;
        private Label lblConfirm;
        private TextBox txtConfirm;
        private Button btnChange;
    }
}
