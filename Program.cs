namespace myOwnPasswordManager;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        // Load or create app data
        var store = new PasswordStore();
        var appData = store.Load();
        
        // Determine if this is first run
        bool isFirstRun = string.IsNullOrEmpty(appData.MasterPasswordHash);
        
        // Show master password dialog
        using var passwordDialog = new MasterPasswordDialog(isFirstRun);
        if (passwordDialog.ShowDialog() != DialogResult.OK)
        {
            // User cancelled, exit application
            return;
        }
        
        string masterPassword = passwordDialog.MasterPassword;
        
        // Validate or set master password
        if (isFirstRun)
        {
            // First run - set the master password
            appData.MasterPasswordHash = EncryptionHelper.HashMasterPassword(masterPassword);
            store.Save(appData);
            
            MessageBox.Show(
                "Master password created successfully!\n\nRemember this password - it cannot be recovered if lost!",
                "Setup Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        else
        {
            // Validate master password
            var enteredHash = EncryptionHelper.HashMasterPassword(masterPassword);
            if (enteredHash != appData.MasterPasswordHash)
            {
                MessageBox.Show(
                    "Invalid master password!\n\nThe application will now close.",
                    "Authentication Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
        
        // Run main form with validated master password
        Application.Run(new Form1(masterPassword));
    }    
}