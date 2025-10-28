namespace myOwnPasswordManager;

/// <summary>
/// Dialog for entering the master password on application startup
/// </summary>
public class MasterPasswordDialog : Form
{
    private TextBox txtMasterPassword = null!;
    private Button btnOK = null!;
    private Button btnCancel = null!;
    private Label lblPrompt = null!;
    private CheckBox chkShowPassword = null!;
    
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string MasterPassword { get; private set; } = string.Empty;
    
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public bool IsFirstRun { get; private set; }
    
    public MasterPasswordDialog(bool isFirstRun = false)
    {
        IsFirstRun = isFirstRun;
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        this.txtMasterPassword = new TextBox();
        this.btnOK = new Button();
        this.btnCancel = new Button();
        this.lblPrompt = new Label();
        this.chkShowPassword = new CheckBox();
        
        this.SuspendLayout();
        
        // Form properties
        this.ClientSize = new Size(450, 220);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = IsFirstRun ? "Create Master Password" : "Enter Master Password";
        this.AcceptButton = this.btnOK;
        this.CancelButton = this.btnCancel;
        
        // Label
        this.lblPrompt.Location = new Point(20, 15);
        this.lblPrompt.Size = new Size(410, 70);
        this.lblPrompt.Text = IsFirstRun 
            ? "Welcome to My Own Password Manager!\n\nCreate a master password to protect your credentials:"
            : "Enter your master password to unlock the vault:";
        this.lblPrompt.Font = new Font("Segoe UI", 9.5F);
        
        // TextBox
        this.txtMasterPassword.Location = new Point(20, 95);
        this.txtMasterPassword.Size = new Size(410, 27);
        this.txtMasterPassword.UseSystemPasswordChar = true;
        this.txtMasterPassword.Font = new Font("Segoe UI", 11F);
        
        // Show Password CheckBox
        this.chkShowPassword.Location = new Point(20, 130);
        this.chkShowPassword.Size = new Size(150, 24);
        this.chkShowPassword.Text = "Show password";
        this.chkShowPassword.Font = new Font("Segoe UI", 9F);
        this.chkShowPassword.CheckedChanged += (s, e) => 
        {
            txtMasterPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        };
        
        // OK Button
        this.btnOK.Location = new Point(265, 170);
        this.btnOK.Size = new Size(80, 32);
        this.btnOK.Text = "OK";
        this.btnOK.BackColor = Color.FromArgb(0, 120, 215);
        this.btnOK.ForeColor = Color.White;
        this.btnOK.FlatStyle = FlatStyle.Flat;
        this.btnOK.FlatAppearance.BorderSize = 0;
        this.btnOK.Cursor = Cursors.Hand;
        this.btnOK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnOK.Click += BtnOK_Click;
        
        // Cancel Button
        this.btnCancel.Location = new Point(350, 170);
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
        this.Controls.Add(this.lblPrompt);
        this.Controls.Add(this.txtMasterPassword);
        this.Controls.Add(this.chkShowPassword);
        this.Controls.Add(this.btnOK);
        this.Controls.Add(this.btnCancel);
        
        this.ResumeLayout(false);
        
        // Focus on textbox when shown
        this.Shown += (s, e) => txtMasterPassword.Focus();
    }
    
    private void BtnOK_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMasterPassword.Text))
        {
            MessageBox.Show(
                "Master password cannot be empty!", 
                "Invalid Password", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            txtMasterPassword.Focus();
            return;
        }
        
        if (IsFirstRun && txtMasterPassword.Text.Length < 4)
        {
            MessageBox.Show(
                "Master password must be at least 4 characters long!", 
                "Weak Password", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            txtMasterPassword.Focus();
            return;
        }
        
        MasterPassword = txtMasterPassword.Text;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
