using System.Security.Cryptography;
using System.Text;

namespace myOwnPasswordManager;

/// <summary>
/// Provides AES-256 encryption/decryption and password hashing
/// </summary>
public static class EncryptionHelper
{
    private const int KeySize = 256;
    private const int BlockSize = 128;
    
    /// <summary>
    /// Creates a SHA256 hash of the master password for validation
    /// </summary>
    public static string HashMasterPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
    
    /// <summary>
    /// Derives a 256-bit encryption key from the master password
    /// </summary>
    private static byte[] DeriveKey(string masterPassword, byte[] salt)
    {
        using var deriveBytes = new Rfc2898DeriveBytes(
            masterPassword, 
            salt, 
            10000, 
            HashAlgorithmName.SHA256);
        return deriveBytes.GetBytes(32); // 256 bits
    }
    
    /// <summary>
    /// Encrypts a password using AES-256
    /// </summary>
    public static string Encrypt(string plainText, string masterPassword)
    {
        if (string.IsNullOrEmpty(plainText))
            return string.Empty;
            
        using var aes = Aes.Create();
        aes.KeySize = KeySize;
        aes.BlockSize = BlockSize;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        
        // Generate random salt and IV
        var salt = RandomNumberGenerator.GetBytes(16);
        aes.Key = DeriveKey(masterPassword, salt);
        aes.GenerateIV();
        
        using var encryptor = aes.CreateEncryptor();
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        
        // Combine salt + IV + encrypted data
        var result = new byte[salt.Length + aes.IV.Length + encryptedBytes.Length];
        Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
        Buffer.BlockCopy(aes.IV, 0, result, salt.Length, aes.IV.Length);
        Buffer.BlockCopy(encryptedBytes, 0, result, salt.Length + aes.IV.Length, encryptedBytes.Length);
        
        return Convert.ToBase64String(result);
    }
    
    /// <summary>
    /// Decrypts a password using AES-256
    /// </summary>
    public static string Decrypt(string encryptedText, string masterPassword)
    {
        if (string.IsNullOrEmpty(encryptedText))
            return string.Empty;
            
        try
        {
            var fullCipher = Convert.FromBase64String(encryptedText);
            
            // Extract salt, IV, and encrypted data
            var salt = new byte[16];
            var iv = new byte[16];
            var cipherBytes = new byte[fullCipher.Length - 32];
            
            Buffer.BlockCopy(fullCipher, 0, salt, 0, 16);
            Buffer.BlockCopy(fullCipher, 16, iv, 0, 16);
            Buffer.BlockCopy(fullCipher, 32, cipherBytes, 0, cipherBytes.Length);
            
            using var aes = Aes.Create();
            aes.KeySize = KeySize;
            aes.BlockSize = BlockSize;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = DeriveKey(masterPassword, salt);
            aes.IV = iv;
            
            using var decryptor = aes.CreateDecryptor();
            var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        catch
        {
            return "[Decryption Failed]";
        }
    }
}
