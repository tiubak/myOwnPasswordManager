namespace myOwnPasswordManager;

public partial class Form1 : Form
{
    private readonly PasswordStore _store;
    private AppData _appData;
    private string _masterPassword = string.Empty;

    public Form1(string masterPassword)
    {
        InitializeComponent();
        _masterPassword = masterPassword;
        _store = new PasswordStore();
        _appData = new AppData();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Load existing data
        _appData = _store.Load();

        // Update status
        UpdateStatus();

        // Load passwords into grid
        RefreshGrid();
    }

    private void RefreshGrid()
    {
        dgvPasswords.Rows.Clear();

        foreach (var entry in _appData.Entries)
        {
            // Decrypt password for display
            var decryptedPassword = EncryptionHelper.Decrypt(entry.EncryptedPassword, _masterPassword);
            entry.DecryptedPassword = decryptedPassword;

            // Add row with masked password
            dgvPasswords.Rows.Add(
                entry.ServerUrl,
                entry.Username,
                new string('●', Math.Min(decryptedPassword.Length, 12)),
                entry.Notes
            );

            // Store entry reference in Tag
            dgvPasswords.Rows[dgvPasswords.Rows.Count - 1].Tag = entry;
        }

        UpdateStatus();
    }

    private void UpdateStatus()
    {
        lblStatus.Text = $"📁 {_store.FilePath} | {_appData.Entries.Count} credential(s)";
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        using var dialog = new EntryDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var entry = new PasswordEntry
            {
                ServerUrl = dialog.ServerUrl,
                Username = dialog.Username,
                EncryptedPassword = EncryptionHelper.Encrypt(dialog.Password, _masterPassword),
                Notes = dialog.Notes
            };

            _appData.Entries.Add(entry);
            RefreshGrid();

            MessageBox.Show(
                "Credential added successfully!\n\nDon't forget to save your changes.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        if (dgvPasswords.SelectedRows.Count == 0)
        {
            MessageBox.Show(
                "Please select a credential to edit.",
                "No Selection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        var selectedRow = dgvPasswords.SelectedRows[0];
        var entry = (PasswordEntry)selectedRow.Tag!;

        using var dialog = new EntryDialog
        {
            ServerUrl = entry.ServerUrl,
            Username = entry.Username,
            Password = entry.DecryptedPassword,
            Notes = entry.Notes,
            IsEditMode = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            entry.ServerUrl = dialog.ServerUrl;
            entry.Username = dialog.Username;
            entry.EncryptedPassword = EncryptionHelper.Encrypt(dialog.Password, _masterPassword);
            entry.Notes = dialog.Notes;

            RefreshGrid();

            MessageBox.Show(
                "Credential updated successfully!\n\nDon't forget to save your changes.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        if (dgvPasswords.SelectedRows.Count == 0)
        {
            MessageBox.Show(
                "Please select a credential to delete.",
                "No Selection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        var selectedRow = dgvPasswords.SelectedRows[0];
        var entry = (PasswordEntry)selectedRow.Tag!;

        var result = MessageBox.Show(
            $"Are you sure you want to delete this credential?\n\nServer: {entry.ServerUrl}\nUsername: {entry.Username}",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            _appData.Entries.Remove(entry);
            RefreshGrid();

            MessageBox.Show(
                "Credential deleted successfully!\n\nDon't forget to save your changes.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }

    private void BtnCopyPassword_Click(object sender, EventArgs e)
    {
        if (dgvPasswords.SelectedRows.Count == 0)
        {
            MessageBox.Show(
                "Please select a credential to copy password.",
                "No Selection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        var selectedRow = dgvPasswords.SelectedRows[0];
        var entry = (PasswordEntry)selectedRow.Tag!;

        try
        {
            Clipboard.SetText(entry.DecryptedPassword);
            MessageBox.Show(
                "Password copied to clipboard!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to copy password: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        _store.Save(_appData);
        MessageBox.Show(
            $"All credentials saved successfully!\n\n{_appData.Entries.Count} credential(s) saved to:\n{_store.FilePath}",
            "Saved",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void DgvPasswords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        // Double-click triggers edit
        if (e.RowIndex >= 0)
        {
            BtnEdit_Click(sender, e);
        }
    }
}
