namespace myOwnPasswordManager;

/// <summary>
/// Represents a single password entry in the manager
/// </summary>
public class PasswordEntry
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ServerUrl { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string EncryptedPassword { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    
    // Transient property for display purposes only (not serialized)
    [System.Text.Json.Serialization.JsonIgnore]
    public string DecryptedPassword { get; set; } = string.Empty;
}

/// <summary>
/// Application data structure for JSON serialization
/// </summary>
public class AppData
{
    public string MasterPasswordHash { get; set; } = string.Empty;
    public List<PasswordEntry> Entries { get; set; } = new();
}
