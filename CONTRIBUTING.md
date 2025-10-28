# Contributing to Pedro's Password Manager 🔐

Thank you for your interest in contributing to this password manager project! This guide will help you get started.

## 📋 Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
- [Development Setup](#development-setup)
- [Making Changes](#making-changes)
- [Testing](#testing)
- [Submitting Changes](#submitting-changes)
- [Security Considerations](#security-considerations)

## 🤝 Code of Conduct

This project follows a simple code of conduct:
- Be respectful and constructive
- Focus on what's best for the community
- Use welcoming and inclusive language
- Report unacceptable behavior to the project maintainer

## 🚀 Getting Started

### Prerequisites

- Windows 10/11 (for testing Windows Forms UI)
- .NET 9.0 SDK or later
- Visual Studio Code or Visual Studio
- Git

### Development Setup

1. **Fork and clone the repository**
   ```bash
   git clone https://github.com/YOUR-USERNAME/myOwnPasswordManager.git
   cd myOwnPasswordManager
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

## 🔧 Making Changes

### Branch Naming Convention

- `feature/description` - New features
- `bugfix/description` - Bug fixes
- `security/description` - Security improvements
- `docs/description` - Documentation updates

### Code Style

- Follow existing C# coding conventions
- Use meaningful variable and method names
- Add XML documentation comments for public methods
- Keep methods focused and concise

### Commit Messages

Use conventional commit format:
- `feat:` - New features
- `fix:` - Bug fixes
- `docs:` - Documentation changes
- `style:` - Code style changes
- `refactor:` - Code refactoring
- `security:` - Security improvements

Example:
```
feat: add password strength indicator to generator

- Implemented real-time strength calculation
- Added visual feedback with color coding
- Updated UI to show strength meter
```

## 🧪 Testing

### Manual Testing Checklist

Before submitting changes, test:

1. **Core Functionality**
   - [ ] Master password creation (new user)
   - [ ] Master password validation (returning user)
   - [ ] Add new password entry
   - [ ] Edit existing entry
   - [ ] Delete entry
   - [ ] Copy password to clipboard
   - [ ] Save/load credentials.json

2. **UI Testing**
   - [ ] Application starts without errors
   - [ ] All buttons work as expected
   - [ ] Dialogs open and close properly
   - [ ] Data grid updates correctly

3. **Security Testing**
   - [ ] Passwords are encrypted in credentials.json
   - [ ] Master password is hashed (not stored in plaintext)
   - [ ] Application handles wrong master password gracefully
   - [ ] File corruption doesn't crash the app

### Build Testing

Test all build configurations:
```bash
# Debug build
dotnet build --configuration Debug

# Release build
dotnet build --configuration Release

# Single-file publish
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

## 📝 Submitting Changes

### Pull Request Process

1. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make your changes**
   - Write clean, documented code
   - Follow existing patterns and conventions
   - Test thoroughly

3. **Commit your changes**
   ```bash
   git add .
   git commit -m "feat: add your feature description"
   ```

4. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

5. **Create a Pull Request**
   - Use the provided PR template
   - Fill out all relevant sections
   - Link related issues
   - Add screenshots for UI changes

### Pull Request Requirements

- [ ] Code builds successfully
- [ ] No new compiler warnings
- [ ] Manual testing completed
- [ ] PR description is complete
- [ ] Security implications considered

## 🔒 Security Considerations

This is a password manager, so security is paramount:

### Security Guidelines

1. **Encryption Changes**
   - Never weaken existing encryption
   - Use established cryptographic libraries
   - Don't implement custom crypto algorithms

2. **Password Handling**
   - Never log passwords or master passwords
   - Clear sensitive data from memory when possible
   - Use SecureString for temporary password storage

3. **File Operations**
   - Validate file paths to prevent directory traversal
   - Handle file corruption gracefully
   - Backup existing data before overwriting

4. **UI Security**
   - Don't display passwords in plain text unnecessarily
   - Implement proper clipboard clearing
   - Be careful with error messages (don't leak info)

### Security Review Process

Security-related PRs will receive extra scrutiny:
- Code review by maintainer
- Manual security testing
- Verification of crypto implementations

## 📋 Issue Guidelines

### Bug Reports
- Use the bug report template
- Include steps to reproduce
- Specify your Windows version and build type
- Include error messages if any

### Feature Requests
- Use the feature request template
- Explain the problem you're solving
- Consider if it fits the project's scope (simple, secure, local)
- Provide mockups for UI changes

### Security Issues
- Use the security issue template
- For critical vulnerabilities, report privately first
- Don't include exploit code in public issues

## 🎯 Project Goals

Keep these goals in mind when contributing:

1. **Simplicity**: Easy to use, minimal UI
2. **Security**: Strong encryption, secure by default
3. **Local**: No cloud features, data stays local
4. **Reliability**: Stable, doesn't lose data
5. **Performance**: Fast startup and operations

## 📞 Getting Help

- Open an issue for questions
- Check existing issues and PRs
- Review the README.md for basic information

## 📄 License

By contributing, you agree that your contributions will be licensed under the same license as the project.

---

Thank you for contributing to Pedro's Password Manager! 🔐✨