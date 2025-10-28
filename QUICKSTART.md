# 🚀 Quick Start Guide

## How to Build and Run

### For Development (Debug)

1. **Open in VS Code**
   ```powershell
   cd c:\Projects\PedroPasswordManager
   code .
   ```

2. **Press F5** to debug, or use:
   ```powershell
   dotnet run
   ```

### For Production (Single .exe)

1. **Build single-file executable**:
   ```powershell
   dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
   ```

2. **Find your .exe**:
   ```
   bin\Release\net9.0-windows\win-x64\publish\PedroPasswordManager.exe
   ```

3. **Copy it anywhere** - it includes everything needed!

## First Time Setup

1. Run `PedroPasswordManager.exe`
2. You'll see: **"Create Master Password"**
3. Enter a password you'll remember (minimum 4 characters)
4. Click OK
5. You're ready to add credentials!

## Adding Your First Password

1. Click **➕ Add**
2. Fill in:
   - **Server/URL**: `localhost` or `https://mydb.com`
   - **Username**: `admin`
   - **Password**: `your_password` (or click 🎲 Generate)
   - **Notes**: `MySQL Production` (optional)
3. Click **OK**
4. Click **💾 Save** to persist to disk

## Daily Workflow

```
1. Open app → Enter master password
2. View your credentials
3. Double-click a row to edit
4. Click 📋 Copy Password to get password
5. Make changes as needed
6. Click 💾 Save before closing
```

## Using VS Code Tasks

**Build Project**:
- `Ctrl+Shift+B` (default build task)

**Publish Single-File**:
- `Ctrl+Shift+P`
- Type: `Tasks: Run Task`
- Select: `publish-single-file`
- Wait for completion
- Check: `bin\Release\net9.0-windows\win-x64\publish\`

## Tips & Tricks

### 💡 Generate Strong Passwords
- Click **🎲 Generate** button when adding/editing
- Creates 16-character strong password
- Automatically shows the generated password

### 💡 Quick Copy
- Select a row
- Click **📋 Copy Password**
- Paste anywhere (Ctrl+V)

### 💡 Quick Edit
- Double-click any row to edit
- No need to select + click Edit button

### 💡 Backup Your Data
- Copy `credentials.json` from app folder
- Paste to safe location (USB drive, cloud backup)
- You can restore by replacing the file

## File Locations

| File | Location | Description |
|------|----------|-------------|
| **Executable** | `bin\Release\...\publish\` | The .exe file |
| **Credentials** | Same folder as .exe | `credentials.json` |
| **Backup** | Same folder as .exe | `credentials.json.backup` (auto) |

## Keyboard Shortcuts

- **Ctrl+S** - Save (when form has focus)
- **Enter** - OK in dialogs
- **Escape** - Cancel in dialogs
- **Double-click row** - Edit credential

## What If...

### I forgot my master password?
❌ **No recovery possible**
- Delete `credentials.json` to start fresh
- All credentials will be lost
- **Prevention**: Write it down in a safe place!

### The app crashes on startup?
1. Check if `credentials.json` exists and is valid JSON
2. Rename it to `credentials.json.old`
3. Restart the app (creates new file)
4. Try to fix the old file manually

### I want to move to another computer?
1. Copy `PedroPasswordManager.exe`
2. Copy `credentials.json`
3. Paste both in same folder on new computer
4. Run the .exe
5. Use same master password

### The .exe is too large (70+ MB)?
This is normal! It includes:
- Full .NET 9 runtime
- Windows Forms libraries
- Crypto libraries
- Everything needed to run

**To reduce size**: Remove `SelfContained` from .csproj (requires .NET installed on target PC)

## Security Checklist

✅ Use a strong master password  
✅ Keep `credentials.json` backed up  
✅ Don't share your master password  
✅ Keep the app in a secure location  
✅ Close the app when not in use  

## Need Help?

Check `README.md` for detailed documentation.

---

**Happy password managing! 🔐**
