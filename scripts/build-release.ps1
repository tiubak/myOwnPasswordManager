#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Build and package My Own Password Manager for release
.DESCRIPTION
    This script builds the password manager for multiple platforms and creates release packages
.PARAMETER Version
    The version number for the release (e.g., "1.0.0")
.PARAMETER OutputPath
    The output directory for release files (default: "./release")
.PARAMETER Configuration
    Build configuration (default: "Release")
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$Version,
    
    [Parameter(Mandatory = $false)]
    [string]$OutputPath = "./release",
    
    [Parameter(Mandatory = $false)]
    [string]$Configuration = "Release"
)

# Colors for output
function Write-ColorOutput {
    param([string]$Text, [string]$Color = "White")
    Write-Host $Text -ForegroundColor $Color
}

function Write-Step {
    param([string]$Text)
    Write-ColorOutput "🔧 $Text" "Cyan"
}

function Write-Success {
    param([string]$Text)
    Write-ColorOutput "✅ $Text" "Green"
}

function Write-Error {
    param([string]$Text)
    Write-ColorOutput "❌ $Text" "Red"
}

# Validate inputs
if (-not ($Version -match '^\d+\.\d+\.\d+$')) {
    Write-Error "Version must be in format x.y.z (e.g., 1.0.0)"
    exit 1
}

Write-ColorOutput "🔐 My Own Password Manager - Release Builder" "Yellow"
Write-ColorOutput "Version: $Version" "White"
Write-ColorOutput "Output: $OutputPath" "White"
Write-ColorOutput "Configuration: $Configuration" "White"
Write-Host ""

# Clean and create output directory
Write-Step "Preparing output directory..."
if (Test-Path $OutputPath) {
    Remove-Item $OutputPath -Recurse -Force
}
New-Item -ItemType Directory -Force -Path $OutputPath | Out-Null

# Define build targets
$targets = @(
    @{
        Name = "Windows x64 (Standalone)"
        Runtime = "win-x64"
        SelfContained = $true
        OutputName = "myOwnPasswordManager-v$Version-win-x64-standalone.exe"
    },
    @{
        Name = "Windows x64 (Framework-Dependent)"
        Runtime = "win-x64"
        SelfContained = $false
        OutputName = "myOwnPasswordManager-v$Version-win-x64-requires-dotnet.exe"
    },
    @{
        Name = "Windows ARM64 (Standalone)"
        Runtime = "win-arm64"
        SelfContained = $true
        OutputName = "myOwnPasswordManager-v$Version-win-arm64-standalone.exe"
    }
)

# Build each target
foreach ($target in $targets) {
    Write-Step "Building $($target.Name)..."
    
    $publishDir = "./publish/$($target.Runtime)"
    if ($target.SelfContained) {
        $publishDir += "-selfcontained"
    } else {
        $publishDir += "-fxdependent"
    }
    
    # Clean publish directory
    if (Test-Path $publishDir) {
        Remove-Item $publishDir -Recurse -Force
    }
    
    # Build command
    $buildArgs = @(
        "publish"
        "--configuration", $Configuration
        "--runtime", $target.Runtime
        "--self-contained", $target.SelfContained.ToString().ToLower()
        "--output", $publishDir
        "/p:PublishSingleFile=true"
    )
    
    if ($target.SelfContained) {
        $buildArgs += "/p:IncludeNativeLibrariesForSelfExtract=true"
        $buildArgs += "/p:EnableCompressionInSingleFile=true"
    }
    
    try {
        & dotnet @buildArgs
        if ($LASTEXITCODE -ne 0) {
            throw "Build failed with exit code $LASTEXITCODE"
        }
        
        # Copy and rename executable
        $sourceExe = Join-Path $publishDir "myOwnPasswordManager.exe"
        $destExe = Join-Path $OutputPath $target.OutputName
        
        if (Test-Path $sourceExe) {
            Copy-Item $sourceExe $destExe
            Write-Success "Built: $($target.OutputName)"
        } else {
            Write-Error "Expected executable not found: $sourceExe"
        }
    }
    catch {
        Write-Error "Failed to build $($target.Name): $_"
        exit 1
    }
}

# Create release README
Write-Step "Creating release documentation..."

$releaseReadme = @"
# 🔐 My Own Password Manager v$Version

## 📦 Release Files

### Windows x64 (Recommended for most users)

**myOwnPasswordManager-v$Version-win-x64-standalone.exe** (~80MB)
- ✅ No .NET installation required
- ✅ Works on any Windows 10/11 x64 machine  
- ✅ Single executable file - just download and run!

**myOwnPasswordManager-v$Version-win-x64-requires-dotnet.exe** (~200KB)
- ⚠️ Requires .NET 9.0 Runtime to be installed
- ✅ Much smaller download size
- 🔗 Download .NET Runtime: https://dotnet.microsoft.com/download/dotnet/9.0

### Windows ARM64 (For ARM-based Windows devices)

**myOwnPasswordManager-v$Version-win-arm64-standalone.exe** (~80MB)
- ✅ For Windows on ARM devices (Surface Pro X, etc.)
- ✅ No .NET installation required
- ✅ Optimized for ARM64 processors

## 🚀 Quick Start Guide

1. **Download** the appropriate .exe file for your system
2. **Run** the executable directly (no installation needed!)
3. **Create** your master password on first launch
4. **Start** managing your passwords securely!

## 🔒 Security Features

- **🔐 AES-256 Encryption**: Military-grade encryption for all passwords
- **🔑 Master Password**: Single password protects everything
- **💾 Local Storage**: Your data never leaves your computer
- **🛡️ PBKDF2**: Strong key derivation with 10,000 iterations
- **🔄 Random IVs**: Each password encrypted with unique initialization vector

## ✨ Features

- **Simple UI**: Clean, intuitive Windows Forms interface
- **Password Generator**: Built-in strong password generator
- **Quick Copy**: One-click password copying to clipboard
- **Search & Filter**: Easy to find your credentials
- **Import/Export**: Backup and restore your password database
- **Portable**: No installation required, works from any folder

## 📋 System Requirements

- **Operating System**: Windows 10 (version 1809) or later / Windows 11
- **Architecture**: x64 or ARM64
- **.NET Runtime**: Not required for standalone versions
- **Memory**: Minimal (< 50MB RAM usage)
- **Storage**: < 100MB for application + your password database

## 🔧 File Information

| File | Size | .NET Required | Best For |
|------|------|---------------|----------|
| win-x64-standalone | ~80MB | No | Most users |
| win-x64-requires-dotnet | ~200KB | Yes | Developers/IT |
| win-arm64-standalone | ~80MB | No | ARM devices |

## ⚠️ Important Security Notes

- **Master Password Recovery**: There is NO way to recover your master password if forgotten
- **Backup Your Data**: Regularly backup your `credentials.json` file
- **Keep Updated**: Always use the latest version for security updates
- **Local Only**: This app does NOT sync to cloud services - your data stays local

## 🆘 Troubleshooting

### "Windows protected your PC" SmartScreen warning
This is normal for new executables. Click "More info" → "Run anyway"

### "Application failed to start" error  
For framework-dependent version, install .NET 9.0 Runtime from Microsoft

### Cannot remember master password
Unfortunately, the master password cannot be recovered. You'll need to delete `credentials.json` and start fresh (losing all data)

### File corruption issues
The app automatically creates `.backup` files. Look for `credentials.json.backup` in the same folder

## 📞 Support & Issues

- **Issues**: Report bugs at https://github.com/tiubak/myOwnPasswordManager/issues
- **Discussions**: Ask questions in GitHub Discussions
- **Security**: Report security issues privately (see SECURITY.md)

## 📄 License & Credits

**License**: Personal use project  
**Author**: tiubak  
**Framework**: .NET 9.0  
**UI**: Windows Forms  
**Encryption**: AES-256-CBC  

---

**Release Date**: $(Get-Date -Format 'yyyy-MM-dd')  
**Build**: v$Version  
**Checksum**: See release assets for SHA256 hashes

Thank you for using My Own Password Manager! 🔐✨
"@

$releaseReadme | Out-File -FilePath (Join-Path $OutputPath "README.txt") -Encoding UTF8

# Calculate checksums
Write-Step "Calculating checksums..."
$checksumFile = Join-Path $OutputPath "SHA256SUMS.txt"
$checksums = @()

Get-ChildItem $OutputPath -Filter "*.exe" | ForEach-Object {
    $hash = Get-FileHash $_.FullName -Algorithm SHA256
    $checksums += "$($hash.Hash.ToLower())  $($_.Name)"
    Write-Success "Checksum calculated for $($_.Name)"
}

$checksums | Out-File -FilePath $checksumFile -Encoding UTF8

# Create version info file
Write-Step "Creating version information..."
$versionInfo = @{
    version = $Version
    buildDate = (Get-Date -Format 'yyyy-MM-ddTHH:mm:ssZ')
    dotnetVersion = "9.0"
    targets = $targets | ForEach-Object { 
        @{
            name = $_.Name
            runtime = $_.Runtime
            selfContained = $_.SelfContained
            fileName = $_.OutputName
        }
    }
} | ConvertTo-Json -Depth 3

$versionInfo | Out-File -FilePath (Join-Path $OutputPath "version.json") -Encoding UTF8

# Summary
Write-Host ""
Write-ColorOutput "🎉 Release build completed successfully!" "Green"
Write-ColorOutput "📂 Output directory: $OutputPath" "White"
Write-Host ""
Write-ColorOutput "📦 Generated files:" "Yellow"

Get-ChildItem $OutputPath | ForEach-Object {
    $size = if ($_.PSIsContainer) { "DIR" } else { 
        $sizeKB = [math]::Round($_.Length / 1KB, 1)
        if ($sizeKB -gt 1024) {
            "$([math]::Round($sizeKB / 1024, 1)) MB"
        } else {
            "$sizeKB KB"
        }
    }
    Write-Host "  📄 $($_.Name) ($size)" -ForegroundColor White
}

Write-Host ""
Write-ColorOutput "🔗 Next steps:" "Cyan"
Write-Host "  1. Test the executables on different Windows versions"
Write-Host "  2. Create GitHub release with: gh release create v$Version $OutputPath/*"
Write-Host "  3. Update documentation with new version info"
Write-Host "  4. Announce the release!"