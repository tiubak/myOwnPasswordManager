namespace myOwnPasswordManager;

/// <summary>
/// Dialog for adding or editing password entries
/// </summary>
public class EntryDialog : Form
{
    private TextBox txtServerUrl = null!;
    private TextBox txtUsername = null!;
    private TextBox txtPassword = null!;
    private TextBox txtNotes = null!;
    private Button btnOK = null!;
    private Button btnCancel = null!;
    private CheckBox chkShowPassword = null!;
    private Label lblServerUrl = null!;
    private Label lblUsername = null!;
    private Label lblPassword = null!;
    private Label lblNotes = null!;
    private Button btnGeneratePassword = null!;
    
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string ServerUrl { get; set; } = string.Empty;
    
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string Username { get; set; } = string.Empty;
    
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string Password { get; set; } = string.Empty;
    
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string Notes { get; set; } = string.Empty;
    
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public bool IsEditMode { get; set; } = false;
    
    public EntryDialog()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        this.txtServerUrl = new TextBox();
        this.txtUsername = new TextBox();
        this.txtPassword = new TextBox();
        this.txtNotes = new TextBox();
        this.btnOK = new Button();
        this.btnCancel = new Button();
        this.chkShowPassword = new CheckBox();
        this.lblServerUrl = new Label();
        this.lblUsername = new Label();
        this.lblPassword = new Label();
        this.lblNotes = new Label();
        this.btnGeneratePassword = new Button();
        
        this.SuspendLayout();
        
        // Form properties
        this.ClientSize = new Size(500, 400);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Add Credential";
        this.AcceptButton = this.btnOK;
        this.CancelButton = this.btnCancel;
        this.BackColor = Color.White;
        
        // lblServerUrl
        this.lblServerUrl.Location = new Point(20, 20);
        this.lblServerUrl.Size = new Size(460, 20);
        this.lblServerUrl.Text = "Server / URL:";
        this.lblServerUrl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        
        // txtServerUrl
        this.txtServerUrl.Location = new Point(20, 45);
        this.txtServerUrl.Size = new Size(460, 27);
        this.txtServerUrl.Font = new Font("Segoe UI", 10F);
        this.txtServerUrl.PlaceholderText = "e.g., localhost, https://example.com, 192.168.1.100";
        
        // lblUsername
        this.lblUsername.Location = new Point(20, 85);
        this.lblUsername.Size = new Size(460, 20);
        this.lblUsername.Text = "Username:";
        this.lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        
        // txtUsername
        this.txtUsername.Location = new Point(20, 110);
        this.txtUsername.Size = new Size(460, 27);
        this.txtUsername.Font = new Font("Segoe UI", 10F);
        this.txtUsername.PlaceholderText = "e.g., admin, user@example.com";
        
        // lblPassword
        this.lblPassword.Location = new Point(20, 150);
        this.lblPassword.Size = new Size(460, 20);
        this.lblPassword.Text = "Password:";
        this.lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        
        // txtPassword
        this.txtPassword.Location = new Point(20, 175);
        this.txtPassword.Size = new Size(330, 27);
        this.txtPassword.Font = new Font("Segoe UI", 10F);
        this.txtPassword.UseSystemPasswordChar = true;
        
        // btnGeneratePassword
        this.btnGeneratePassword.Location = new Point(360, 175);
        this.btnGeneratePassword.Size = new Size(120, 27);
        this.btnGeneratePassword.Text = "🎲 Generate";
        this.btnGeneratePassword.BackColor = Color.FromArgb(0, 120, 215);
        this.btnGeneratePassword.ForeColor = Color.White;
        this.btnGeneratePassword.FlatStyle = FlatStyle.Flat;
        this.btnGeneratePassword.FlatAppearance.BorderSize = 0;
        this.btnGeneratePassword.Cursor = Cursors.Hand;
        this.btnGeneratePassword.Font = new Font("Segoe UI", 9F);
        this.btnGeneratePassword.Click += BtnGeneratePassword_Click;
        
        // chkShowPassword
        this.chkShowPassword.Location = new Point(20, 210);
        this.chkShowPassword.Size = new Size(150, 24);
        this.chkShowPassword.Text = "Show password";
        this.chkShowPassword.Font = new Font("Segoe UI", 9F);
        this.chkShowPassword.CheckedChanged += (s, e) =>
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        };
        
        // lblNotes
        this.lblNotes.Location = new Point(20, 245);
        this.lblNotes.Size = new Size(460, 20);
        this.lblNotes.Text = "Notes (optional):";
        this.lblNotes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        
        // txtNotes
        this.txtNotes.Location = new Point(20, 270);
        this.txtNotes.Size = new Size(460, 60);
        this.txtNotes.Font = new Font("Segoe UI", 9F);
        this.txtNotes.Multiline = true;
        this.txtNotes.ScrollBars = ScrollBars.Vertical;
        this.txtNotes.PlaceholderText = "e.g., Production database, Development server...";
        
        // btnOK
        this.btnOK.Location = new Point(315, 350);
        this.btnOK.Size = new Size(80, 32);
        this.btnOK.Text = "OK";
        this.btnOK.BackColor = Color.FromArgb(0, 120, 215);
        this.btnOK.ForeColor = Color.White;
        this.btnOK.FlatStyle = FlatStyle.Flat;
        this.btnOK.FlatAppearance.BorderSize = 0;
        this.btnOK.Cursor = Cursors.Hand;
        this.btnOK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnOK.Click += BtnOK_Click;
        
        // btnCancel
        this.btnCancel.Location = new Point(400, 350);
        this.btnCancel.Size = new Size(80, 32);
        this.btnCancel.Text = "Cancel";
        this.btnCancel.FlatStyle = FlatStyle.Flat;
        this.btnCancel.Cursor = Cursors.Hand;
        this.btnCancel.Font = new Font("Segoe UI", 10F);
        this.btnCancel.Click += (s, e) =>
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        };
        
        // Add controls
        this.Controls.Add(this.lblServerUrl);
        this.Controls.Add(this.txtServerUrl);
        this.Controls.Add(this.lblUsername);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblPassword);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.btnGeneratePassword);
        this.Controls.Add(this.chkShowPassword);
        this.Controls.Add(this.lblNotes);
        this.Controls.Add(this.txtNotes);
        this.Controls.Add(this.btnOK);
        this.Controls.Add(this.btnCancel);
        
        this.ResumeLayout(false);
        
        // Populate fields if in edit mode
        this.Load += (s, e) =>
        {
            if (IsEditMode)
            {
                this.Text = "Edit Credential";
                txtServerUrl.Text = ServerUrl;
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                txtNotes.Text = Notes;
            }
            txtServerUrl.Focus();
        };
    }
    
    private void BtnGeneratePassword_Click(object? sender, EventArgs e)
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789!@#$%&*";
        var random = new Random();
        var password = new string(Enumerable.Repeat(chars, 16)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        
        txtPassword.Text = password;
        chkShowPassword.Checked = true;
        
        MessageBox.Show(
            "Strong password generated!\n\nMake sure to save it.",
            "Password Generated",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
    
    private void BtnOK_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtServerUrl.Text))
        {
            MessageBox.Show(
                "Server/URL cannot be empty!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtServerUrl.Focus();
            return;
        }
        
        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            MessageBox.Show(
                "Username cannot be empty!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }
        
        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show(
                "Password cannot be empty!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }
        
        ServerUrl = txtServerUrl.Text.Trim();
        Username = txtUsername.Text.Trim();
        Password = txtPassword.Text;
        Notes = txtNotes.Text.Trim();
        
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
