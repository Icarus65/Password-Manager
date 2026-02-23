namespace Password_Manager.GUI
{
    partial class AddEditEntryForm
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
            entriesGrid = new DataGridView();
            lblFilter = new Label();
            cboFilterCategory = new ComboBox();
            lblWebsite = new Label();
            txtWebsite = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnCopyPassword = new Button();
            ((System.ComponentModel.ISupportInitialize)entriesGrid).BeginInit();
            SuspendLayout();
            // 
            // entriesGrid
            // 
            entriesGrid.AllowUserToAddRows = false;
            entriesGrid.AllowUserToDeleteRows = false;
            entriesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            entriesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            entriesGrid.Location = new Point(12, 40);
            entriesGrid.MultiSelect = false;
            entriesGrid.Name = "entriesGrid";
            entriesGrid.ReadOnly = true;
            entriesGrid.RowHeadersVisible = false;
            entriesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            entriesGrid.Size = new Size(520, 392);
            entriesGrid.TabIndex = 2;
            entriesGrid.CellContentClick += entriesGrid_CellContentClick;
            entriesGrid.SelectionChanged += entriesGrid_SelectionChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(12, 12);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(33, 15);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Filter";
            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.Location = new Point(60, 8);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Size = new Size(200, 23);
            cboFilterCategory.TabIndex = 1;
            cboFilterCategory.SelectedIndexChanged += cboFilterCategory_SelectedIndexChanged;
            // 
            // lblWebsite
            // 
            lblWebsite.AutoSize = true;
            lblWebsite.Location = new Point(548, 20);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new Size(49, 15);
            lblWebsite.TabIndex = 3;
            lblWebsite.Text = "Website";
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(548, 38);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(240, 23);
            txtWebsite.TabIndex = 4;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(548, 72);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(548, 90);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(240, 23);
            txtUsername.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(548, 124);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(548, 142);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(240, 23);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(548, 176);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 9;
            lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(548, 194);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(240, 23);
            cboCategory.TabIndex = 10;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(548, 228);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(38, 15);
            lblNotes.TabIndex = 11;
            lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(548, 246);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(240, 80);
            txtNotes.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(548, 342);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(629, 342);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(710, 342);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(548, 371);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCopyPassword
            // 
            btnCopyPassword.Location = new Point(629, 371);
            btnCopyPassword.Name = "btnCopyPassword";
            btnCopyPassword.Size = new Size(156, 23);
            btnCopyPassword.TabIndex = 17;
            btnCopyPassword.Text = "Copy Password";
            btnCopyPassword.UseVisualStyleBackColor = true;
            btnCopyPassword.Click += btnCopyPassword_Click;
            // 
            // AddEditEntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCopyPassword);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(cboCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtWebsite);
            Controls.Add(lblWebsite);
            Controls.Add(entriesGrid);
            Controls.Add(cboFilterCategory);
            Controls.Add(lblFilter);
            Name = "AddEditEntryForm";
            Size = new Size(800, 450);
            Load += AddEditEntryForm_Load;
            ((System.ComponentModel.ISupportInitialize)entriesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView entriesGrid;
        private Label lblFilter;
        private ComboBox cboFilterCategory;
        private Label lblWebsite;
        private TextBox txtWebsite;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnCopyPassword;
    }
}
