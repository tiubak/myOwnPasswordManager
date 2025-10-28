namespace myOwnPasswordManager;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.dgvPasswords = new DataGridView();
        this.colServerUrl = new DataGridViewTextBoxColumn();
        this.colUsername = new DataGridViewTextBoxColumn();
        this.colPassword = new DataGridViewTextBoxColumn();
        this.colNotes = new DataGridViewTextBoxColumn();
        this.btnAdd = new Button();
        this.btnEdit = new Button();
        this.btnDelete = new Button();
        this.btnSave = new Button();
        this.btnCopyPassword = new Button();
        this.lblTitle = new Label();
        this.panel1 = new Panel();
        this.lblStatus = new Label();
        
        ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).BeginInit();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        this.lblTitle.ForeColor = Color.FromArgb(0, 120, 215);
        this.lblTitle.Location = new Point(20, 15);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new Size(300, 30);
        this.lblTitle.Text = "🔐 My Own Password Manager";
        
        // 
        // panel1
        // 
        this.panel1.BackColor = Color.FromArgb(240, 240, 240);
        this.panel1.Controls.Add(this.btnAdd);
        this.panel1.Controls.Add(this.btnEdit);
        this.panel1.Controls.Add(this.btnDelete);
        this.panel1.Controls.Add(this.btnCopyPassword);
        this.panel1.Controls.Add(this.btnSave);
        this.panel1.Dock = DockStyle.Top;
        this.panel1.Location = new Point(0, 60);
        this.panel1.Name = "panel1";
        this.panel1.Size = new Size(1000, 60);
        
        // 
        // btnAdd
        // 
        this.btnAdd.BackColor = Color.FromArgb(0, 120, 215);
        this.btnAdd.FlatStyle = FlatStyle.Flat;
        this.btnAdd.FlatAppearance.BorderSize = 0;
        this.btnAdd.ForeColor = Color.White;
        this.btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnAdd.Location = new Point(20, 15);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new Size(100, 32);
        this.btnAdd.Text = "➕ Add";
        this.btnAdd.Cursor = Cursors.Hand;
        this.btnAdd.Click += new EventHandler(this.BtnAdd_Click!);
        
        // 
        // btnEdit
        // 
        this.btnEdit.BackColor = Color.FromArgb(0, 99, 177);
        this.btnEdit.FlatStyle = FlatStyle.Flat;
        this.btnEdit.FlatAppearance.BorderSize = 0;
        this.btnEdit.ForeColor = Color.White;
        this.btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnEdit.Location = new Point(130, 15);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new Size(100, 32);
        this.btnEdit.Text = "✏️ Edit";
        this.btnEdit.Cursor = Cursors.Hand;
        this.btnEdit.Click += new EventHandler(this.BtnEdit_Click!);
        
        // 
        // btnDelete
        // 
        this.btnDelete.BackColor = Color.FromArgb(232, 17, 35);
        this.btnDelete.FlatStyle = FlatStyle.Flat;
        this.btnDelete.FlatAppearance.BorderSize = 0;
        this.btnDelete.ForeColor = Color.White;
        this.btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnDelete.Location = new Point(240, 15);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new Size(100, 32);
        this.btnDelete.Text = "🗑️ Delete";
        this.btnDelete.Cursor = Cursors.Hand;
        this.btnDelete.Click += new EventHandler(this.BtnDelete_Click!);
        
        // 
        // btnCopyPassword
        // 
        this.btnCopyPassword.BackColor = Color.FromArgb(16, 124, 16);
        this.btnCopyPassword.FlatStyle = FlatStyle.Flat;
        this.btnCopyPassword.FlatAppearance.BorderSize = 0;
        this.btnCopyPassword.ForeColor = Color.White;
        this.btnCopyPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnCopyPassword.Location = new Point(350, 15);
        this.btnCopyPassword.Name = "btnCopyPassword";
        this.btnCopyPassword.Size = new Size(140, 32);
        this.btnCopyPassword.Text = "📋 Copy Password";
        this.btnCopyPassword.Cursor = Cursors.Hand;
        this.btnCopyPassword.Click += new EventHandler(this.BtnCopyPassword_Click!);
        
        // 
        // btnSave
        // 
        this.btnSave.BackColor = Color.FromArgb(16, 124, 16);
        this.btnSave.FlatStyle = FlatStyle.Flat;
        this.btnSave.FlatAppearance.BorderSize = 0;
        this.btnSave.ForeColor = Color.White;
        this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnSave.Location = new Point(880, 15);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new Size(100, 32);
        this.btnSave.Text = "💾 Save";
        this.btnSave.Cursor = Cursors.Hand;
        this.btnSave.Click += new EventHandler(this.BtnSave_Click!);
        
        // 
        // dgvPasswords
        // 
        this.dgvPasswords.AllowUserToAddRows = false;
        this.dgvPasswords.AllowUserToDeleteRows = false;
        this.dgvPasswords.BackgroundColor = Color.White;
        this.dgvPasswords.BorderStyle = BorderStyle.None;
        this.dgvPasswords.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
        this.dgvPasswords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        this.dgvPasswords.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.dgvPasswords.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        this.dgvPasswords.ColumnHeadersHeight = 35;
        this.dgvPasswords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.dgvPasswords.Columns.AddRange(new DataGridViewColumn[] {
            this.colServerUrl,
            this.colUsername,
            this.colPassword,
            this.colNotes});
        this.dgvPasswords.Dock = DockStyle.Fill;
        this.dgvPasswords.EnableHeadersVisualStyles = false;
        this.dgvPasswords.Location = new Point(0, 120);
        this.dgvPasswords.MultiSelect = false;
        this.dgvPasswords.Name = "dgvPasswords";
        this.dgvPasswords.ReadOnly = true;
        this.dgvPasswords.RowHeadersVisible = false;
        this.dgvPasswords.RowTemplate.Height = 30;
        this.dgvPasswords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvPasswords.Size = new Size(1000, 450);
        this.dgvPasswords.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        this.dgvPasswords.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
        this.dgvPasswords.DefaultCellStyle.SelectionForeColor = Color.White;
        this.dgvPasswords.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
        this.dgvPasswords.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);
        this.dgvPasswords.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvPasswords_CellDoubleClick!);
        
        // 
        // colServerUrl
        // 
        this.colServerUrl.HeaderText = "Server / URL";
        this.colServerUrl.Name = "colServerUrl";
        this.colServerUrl.ReadOnly = true;
        this.colServerUrl.Width = 300;
        
        // 
        // colUsername
        // 
        this.colUsername.HeaderText = "Username";
        this.colUsername.Name = "colUsername";
        this.colUsername.ReadOnly = true;
        this.colUsername.Width = 200;
        
        // 
        // colPassword
        // 
        this.colPassword.HeaderText = "Password";
        this.colPassword.Name = "colPassword";
        this.colPassword.ReadOnly = true;
        this.colPassword.Width = 150;
        
        // 
        // colNotes
        // 
        this.colNotes.HeaderText = "Notes";
        this.colNotes.Name = "colNotes";
        this.colNotes.ReadOnly = true;
        this.colNotes.Width = 320;
        
        // 
        // lblStatus
        // 
        this.lblStatus.AutoSize = true;
        this.lblStatus.Location = new Point(500, 25);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new Size(200, 15);
        this.lblStatus.ForeColor = Color.Gray;
        this.lblStatus.Font = new Font("Segoe UI", 9F);
        
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(1000, 600);
        this.Controls.Add(this.dgvPasswords);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblStatus);
        this.MinimumSize = new Size(800, 400);
        this.Name = "Form1";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "My Own Password Manager";
        try { this.Icon = new Icon("final_icon.ico"); } catch { /* Icon not found, continue without */ }
        this.Load += new EventHandler(this.Form1_Load!);
        
        ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).EndInit();
        this.panel1.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
    
    private DataGridView dgvPasswords;
    private DataGridViewTextBoxColumn colServerUrl;
    private DataGridViewTextBoxColumn colUsername;
    private DataGridViewTextBoxColumn colPassword;
    private DataGridViewTextBoxColumn colNotes;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnSave;
    private Button btnCopyPassword;
    private Label lblTitle;
    private Panel panel1;
    private Label lblStatus;
}
