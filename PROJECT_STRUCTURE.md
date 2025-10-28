# 📁 Project Structure

```
PedroPasswordManager/
│
├── 📄 Core Application Files
│   ├── Program.cs                    # Entry point with master password validation
│   ├── Form1.cs                      # Main form logic (Add/Edit/Delete/Save)
│   ├── Form1.Designer.cs             # Main form UI design (DataGridView, buttons)
│   ├── MasterPasswordDialog.cs       # Master password entry dialog
│   ├── EntryDialog.cs                # Add/Edit credential dialog
│   ├── PasswordEntry.cs              # Data models (PasswordEntry + AppData)
│   ├── EncryptionHelper.cs           # AES-256 encryption/decryption
│   └── PasswordStore.cs              # JSON save/load operations
│
├── 📄 Configuration Files
│   ├── PedroPasswordManager.csproj   # Project config + single-file publish
│   └── PedroPasswordManager.csproj.user
│
├── 📂 .vscode/                       # VS Code settings
│   ├── tasks.json                    # Build & publish tasks
│   └── launch.json                   # Debug configuration
│
├── 📂 obj/                           # Build intermediate files
│   ├── project.assets.json
│   ├── PedroPasswordManager.csproj.nuget.dgspec.json
│   ├── PedroPasswordManager.csproj.nuget.g.props
│   └── PedroPasswordManager.csproj.nuget.g.targets
│
├── 📂 bin/                           # Build outputs
│   ├── Debug/
│   │   └── net9.0-windows/
│   │       └── PedroPasswordManager.exe
│   └── Release/
│       └── net9.0-windows/
│           └── win-x64/
│               └── publish/
│                   └── PedroPasswordManager.exe  ⭐ (Single-file distribution)
│
├── 📄 Documentation
│   ├── README.md                     # Complete project documentation
│   ├── QUICKSTART.md                 # Quick start guide for users
│   ├── BUILD_SUMMARY.md              # Build summary and checklist
│   └── PROJECT_STRUCTURE.md          # This file
│
└── 📄 Git Configuration
    └── .gitignore                    # Git ignore rules (excludes credentials.json)
```

---

## 🎯 Key Components Explained

### Data Flow
```
User Input
    ↓
MasterPasswordDialog (validates password)
    ↓
Form1 (main UI)
    ↓
EntryDialog (add/edit credentials)
    ↓
EncryptionHelper (encrypt passwords)
    ↓
PasswordStore (save to JSON)
    ↓
credentials.json (persistent storage)
```

### Architecture

```
┌─────────────────────────────────────────┐
│         Program.cs (Entry Point)        │
│  - Master password validation           │
│  - First-run detection                  │
└─────────────────────┬───────────────────┘
                      ↓
┌─────────────────────────────────────────┐
│       MasterPasswordDialog.cs           │
│  - Password entry UI                    │
│  - Create/validate master password      │
└─────────────────────┬───────────────────┘
                      ↓
┌─────────────────────────────────────────┐
│            Form1.cs (Main UI)           │
│  - DataGridView display                 │
│  - Add/Edit/Delete/Copy/Save buttons    │
│  - Credential management                │
└───┬─────────────────┬───────────────┬───┘
    ↓                 ↓               ↓
┌───────────┐  ┌──────────────┐  ┌──────────────┐
│ EntryDialog│  │PasswordStore │  │EncryptionHelper│
│           │  │              │  │              │
│ Add/Edit  │  │ JSON I/O     │  │ AES-256      │
│ UI        │  │ File ops     │  │ Encryption   │
└───────────┘  └──────────────┘  └──────────────┘
                      ↓
              ┌──────────────┐
              │PasswordEntry │
              │  (Models)    │
              │ AppData      │
              └──────────────┘
```

---

## 📦 Distribution Package

When you publish, distribute these files together:

```
MyPasswordManager/
├── PedroPasswordManager.exe    ⭐ Single executable (~75 MB)
└── credentials.json            📝 Created on first run (do not include)
```

**Important**: Only distribute the `.exe`. The `credentials.json` is created automatically and should NOT be shared (contains user data).

---

## 🔄 Development Workflow

### 1. Development (Debug)
```powershell
# Edit code in VS Code
# Press F5 to debug
# Test features
# credentials.json created in bin/Debug/net9.0-windows/
```

### 2. Testing
```powershell
dotnet build
dotnet run
# Test all features
```

### 3. Publishing
```powershell
# Use VS Code task: publish-single-file
# OR
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

### 4. Distribution
```powershell
# Copy from: bin/Release/net9.0-windows/win-x64/publish/
# File: PedroPasswordManager.exe
# Distribute: Just the .exe file!
```

---

## 📊 File Sizes (Approximate)

| File | Lines | Purpose |
|------|-------|---------|
| **PasswordEntry.cs** | ~30 | Data models |
| **EncryptionHelper.cs** | ~90 | Encryption logic |
| **PasswordStore.cs** | ~60 | File I/O |
| **MasterPasswordDialog.cs** | ~120 | Master password UI |
| **EntryDialog.cs** | ~230 | Add/Edit dialog |
| **Form1.cs** | ~220 | Main form logic |
| **Form1.Designer.cs** | ~250 | Main form UI |
| **Program.cs** | ~60 | Entry point |
| **TOTAL** | ~1,200 | Complete application |

---

## 🎨 UI Component Hierarchy

```
Form1 (Main Window)
├── lblTitle (Header)
├── lblStatus (Status bar)
├── panel1 (Button toolbar)
│   ├── btnAdd
│   ├── btnEdit
│   ├── btnDelete
│   ├── btnCopyPassword
│   └── btnSave
└── dgvPasswords (DataGridView)
    ├── colServerUrl
    ├── colUsername
    ├── colPassword
    └── colNotes

EntryDialog (Add/Edit Window)
├── lblServerUrl
├── txtServerUrl
├── lblUsername
├── txtUsername
├── lblPassword
├── txtPassword
├── btnGeneratePassword
├── chkShowPassword
├── lblNotes
├── txtNotes
├── btnOK
└── btnCancel

MasterPasswordDialog (Login Window)
├── lblPrompt
├── txtMasterPassword
├── chkShowPassword
├── btnOK
└── btnCancel
```

---

## 🔐 Security Architecture

```
User enters password
    ↓
SHA256 hash → MasterPasswordHash (stored in JSON)
    ↓
PBKDF2 key derivation (10k iterations)
    ↓
AES-256 encryption
    ↓
Base64 encoded → EncryptedPassword (stored in JSON)
```

**Decryption Flow**:
```
User enters master password
    ↓
SHA256 hash → Compare with stored hash
    ↓
If valid: PBKDF2 key derivation
    ↓
AES-256 decryption
    ↓
Display decrypted password
```

---

## 📝 Runtime Files

After first run, the application folder contains:

```
PedroPasswordManager.exe         # Main executable
credentials.json                 # Encrypted credentials
credentials.json.backup          # Auto-backup (if corruption detected)
```

---

**Last Updated**: October 28, 2025  
**Project Status**: ✅ Complete and tested
