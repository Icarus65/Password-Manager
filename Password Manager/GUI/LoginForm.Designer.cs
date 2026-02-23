namespace Password_Manager.GUI
{
    partial class LoginForm
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
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirm = new Label();
            txtConfirm = new TextBox();
            chkCreateNew = new CheckBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(182, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Enter Master Password";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 60);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 78);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(260, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(20, 141);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(104, 15);
            lblConfirm.TabIndex = 3;
            lblConfirm.Text = "Confirm Password";
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(20, 159);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(260, 23);
            txtConfirm.TabIndex = 4;
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // chkCreateNew
            // 
            chkCreateNew.AutoSize = true;
            chkCreateNew.Location = new Point(20, 112);
            chkCreateNew.Name = "chkCreateNew";
            chkCreateNew.Size = new Size(177, 19);
            chkCreateNew.TabIndex = 5;
            chkCreateNew.Text = "Create new master password";
            chkCreateNew.UseVisualStyleBackColor = true;
            chkCreateNew.CheckedChanged += chkCreateNew_CheckedChanged;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(124, 200);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(205, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 240);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(chkCreateNew);
            Controls.Add(txtConfirm);
            Controls.Add(lblConfirm);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Password Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirm;
        private TextBox txtConfirm;
        private CheckBox chkCreateNew;
        private Button btnOk;
        private Button btnCancel;
    }
}
