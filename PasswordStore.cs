using System.Text.Json;

namespace myOwnPasswordManager;

/// <summary>
/// Manages loading and saving password data to JSON file
/// </summary>
public class PasswordStore
{
    private readonly string _filePath;
    private static readonly JsonSerializerOptions _jsonOptions = new() 
    { 
        WriteIndented = true 
    };
    
    public PasswordStore()
    {
        // Store JSON file in the same directory as the executable
        var exeDirectory = AppContext.BaseDirectory;
        _filePath = Path.Combine(exeDirectory, "credentials.json");
    }
    
    /// <summary>
    /// Loads application data from JSON file. Creates new file if not exists.
    /// </summary>
    public AppData Load()
    {
        if (!File.Exists(_filePath))
        {
            var newData = new AppData();
            Save(newData);
            return newData;
        }
        
        try
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<AppData>(json) ?? new AppData();
        }
        catch
        {
            // If file is corrupted, create backup and return new data
            if (File.Exists(_filePath))
            {
                File.Copy(_filePath, _filePath + ".backup", true);
            }
            return new AppData();
        }
    }
    
    /// <summary>
    /// Saves application data to JSON file
    /// </summary>
    public void Save(AppData data)
    {
        try
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Error saving credentials: {ex.Message}", 
                "Save Error", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
    
    /// <summary>
    /// Gets the full path to the credentials file
    /// </summary>
    public string FilePath => _filePath;
}
