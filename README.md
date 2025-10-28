# 🔐 Pedro's Password Manager

[![Build Status](https://github.com/tiubak/myOwnPasswordManager/actions/workflows/ci.yml/badge.svg)](https://github.com/tiubak/myOwnPasswordManager/actions/workflows/ci.yml)
[![Release](https://github.com/tiubak/myOwnPasswordManager/actions/workflows/release.yml/badge.svg)](https://github.com/tiubak/myOwnPasswordManager/actions/workflows/release.yml)
[![Latest Release](https://img.shields.io/github/v/release/tiubak/myOwnPasswordManager)](https://github.com/tiubak/myOwnPasswordManager/releases/latest)
[![Downloads](https://img.shields.io/github/downloads/tiubak/myOwnPasswordManager/total)](https://github.com/tiubak/myOwnPasswordManager/releases)
[![License](https://img.shields.io/badge/license-Personal%20Project-blue)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-9.0-blue)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![Platform](https://img.shields.io/badge/platform-Windows-blue)](https://www.microsoft.com/windows)

A simple, secure Windows Forms application for managing database and server passwords with AES-256 encryption.

## ✨ Features

- **🔒 Master Password Protection**: All passwords encrypted with AES-256
- **💾 JSON Storage**: Credentials stored locally in `credentials.json`
- **📦 Single Executable**: Self-contained .exe with embedded .NET runtime
- **🎯 Simple UI**: One screen with DataGridView for easy management
- **🔑 Password Generator**: Built-in strong password generator
- **📋 Quick Copy**: Copy passwords to clipboard with one click
- **✏️ Edit Support**: Double-click rows to edit credentials

## � Download & Installation

### Quick Start
1. **[Download the latest release](https://github.com/tiubak/myOwnPasswordManager/releases/latest)**
2. **Choose your version:**
   - `win-x64-standalone.exe` - No .NET required (~80MB) ⭐ **Recommended**
   - `win-x64-requires-dotnet.exe` - Needs .NET 9.0 (~200KB)
   - `win-arm64-standalone.exe` - For ARM devices (~80MB)
3. **Run the .exe** - No installation needed!

## �🚀 Getting Started

### First Run

1. **Launch the application** - Double-click the downloaded `.exe` file
2. **Create master password** - You'll be prompted to create a master password on first run
3. **Remember it!** - This password cannot be recovered if lost

### Daily Use

1. **Enter master password** - Required every time you open the app
2. **Manage credentials**:
   - ➕ **Add** - Add new server/database credentials
   - ✏️ **Edit** - Edit existing entries (or double-click row)
   - 🗑️ **Delete** - Remove credentials
   - 📋 **Copy Password** - Copy password to clipboard
   - 💾 **Save** - Save all changes to disk

## 🛠️ Development

### Prerequisites

- .NET 9.0 SDK or later
- Windows OS
- Visual Studio Code (recommended)

### Building from Source

```powershell
# Debug build
dotnet build

# Run in debug mode
dotnet run

# Or use VS Code tasks (F5 to debug)
```

### Publishing Single-File Executable

```powershell
# Option 1: Use the VS Code task
# Press Ctrl+Shift+P → "Tasks: Run Task" → "publish-single-file"

# Option 2: Command line
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

**Output location**: `bin\Release\net9.0-windows\win-x64\publish\PedroPasswordManager.exe`

## 📁 File Structure

```
PedroPasswordManager/
├── PasswordEntry.cs           # Data models (PasswordEntry, AppData)
├── EncryptionHelper.cs        # AES-256 encryption/decryption
├── PasswordStore.cs           # JSON file operations
├── MasterPasswordDialog.cs    # Master password entry dialog
├── EntryDialog.cs             # Add/Edit credential dialog
├── Form1.cs                   # Main form logic
├── Form1.Designer.cs          # Main form UI design
├── Program.cs                 # Application entry point
└── PedroPasswordManager.csproj # Project configuration
```

## 🔒 Security Features

| Feature | Implementation |
|---------|---------------|
| **Encryption** | AES-256-CBC with random IV |
| **Key Derivation** | PBKDF2 (10,000 iterations, SHA-256) |
| **Master Password** | SHA-256 hashed for validation |
| **Salt** | Random 128-bit salt per password |
| **Storage** | Local JSON file (not cloud) |

### What's Encrypted?

- ✅ **Passwords** - Fully encrypted
- ❌ **Server URLs** - Stored in plaintext
- ❌ **Usernames** - Stored in plaintext
- ❌ **Notes** - Stored in plaintext

> **Note**: Only passwords are encrypted. This is intentional for usability - you can search/view servers and usernames without decryption.

## 📝 Data Storage

**Location**: `credentials.json` (same folder as `.exe`)

**Structure**:
```json
{
  "MasterPasswordHash": "hashed_master_password",
  "Entries": [
    {
      "Id": "unique-guid",
      "ServerUrl": "localhost",
      "Username": "admin",
      "EncryptedPassword": "base64_encrypted_data",
      "Notes": "MySQL production server"
    }
  ]
}
```

## ⚙️ VS Code Tasks

| Task | Description |
|------|-------------|
| `build` (default) | Build the project in Debug mode |
| `publish-single-file` | Create single-file executable |
| `watch` | Auto-rebuild on file changes |
| `clean` | Clean build artifacts |

**Run tasks**: `Ctrl+Shift+P` → `Tasks: Run Task`

## 🎨 UI Design

- **Modern Flat Design** with accent colors
- **Responsive Layout** (minimum 800x400)
- **DataGridView** for credential display
- **Color-coded Buttons**:
  - 🔵 Blue - Add, Edit, Generate
  - 🔴 Red - Delete
  - 🟢 Green - Save, Copy

## ⚠️ Important Notes

1. **Master Password Recovery**: There is NO way to recover your master password. Keep it safe!
2. **Backup**: Regularly backup `credentials.json` to prevent data loss
3. **Corrupted File**: Automatic backup created as `credentials.json.backup` if file is corrupted
4. **Local Only**: No network/cloud sync - all data stays on your machine

## 📊 Project Timeline

Built in approximately **30 minutes** with:
- 5 min: Data models
- 10 min: UI design
- 5 min: Master password dialog
- 10 min: Core functionality
- Publishing configuration

## 🐛 Troubleshooting

### "Invalid master password" on startup
- You entered the wrong master password
- If forgotten, you'll need to delete `credentials.json` (loses all data)

### Can't see changes after edit
- Make sure to click the **💾 Save** button after making changes

### Application crashes on startup
- Ensure .NET 9.0 runtime is installed (or use self-contained build)
- Check `credentials.json` for corruption

### Published .exe is too large
- Normal size: ~70-90 MB (includes full .NET runtime)
- To reduce: Remove `SelfContained` property (requires .NET installed)

## 📄 License

This is a personal project. Feel free to use and modify as needed.

## 👤 Author

Built for Pedro to solve database password management challenges.

---

**Version**: 1.0  
**Framework**: .NET 9.0 Windows Forms  
**Encryption**: AES-256-CBC  
**Last Updated**: October 28, 2025
