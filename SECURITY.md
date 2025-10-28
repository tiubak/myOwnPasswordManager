# Security Policy 🔒

## Supported Versions

Security updates are provided for the following versions:

| Version | Supported          |
| ------- | ------------------ |
| 1.0.x   | ✅ Yes             |
| < 1.0   | ❌ No              |

## Reporting a Vulnerability

The security of My Own Password Manager is taken seriously. If you discover a security vulnerability, please follow these guidelines:

### 🚨 Critical Vulnerabilities

For **critical security issues** that could immediately compromise user data:

1. **DO NOT** open a public GitHub issue
2. **Email the maintainer directly** (check GitHub profile for contact)
3. **Use GitHub's private vulnerability reporting** if available
4. Include "SECURITY VULNERABILITY" in the subject line

### ⚠️ Non-Critical Security Issues

For security improvements or non-critical issues:

1. Use the Security Issue template in GitHub Issues
2. Clearly mark the severity level
3. Follow responsible disclosure practices

### 📋 What to Include

When reporting security vulnerabilities, please include:

- **Description** of the vulnerability
- **Steps to reproduce** the issue
- **Potential impact** on users
- **Affected versions**
- **Suggested fix** (if you have one)
- **Your contact information** for follow-up

### ⏱️ Response Timeline

- **Critical vulnerabilities**: Response within 24-48 hours
- **High severity**: Response within 1 week
- **Medium/Low severity**: Response within 2 weeks

*Note: This is a personal project, so response times may vary based on availability.*

### 🛡️ Security Disclosure Process

1. **Report received** - We acknowledge receipt within 48 hours
2. **Investigation** - We investigate and validate the issue
3. **Fix development** - We develop and test a fix
4. **Release** - We release a security update
5. **Public disclosure** - Details are made public after fix is available

### 🎯 Scope

This security policy covers:

- **Encryption vulnerabilities** (AES-256, key derivation)
- **Authentication bypasses** (master password)
- **Data leakage** (passwords in memory/logs)
- **File security** (credentials.json handling)
- **Input validation** (preventing injection attacks)

### 🚫 Out of Scope

The following are **not** considered security vulnerabilities:

- **Social engineering attacks**
- **Physical access** to the device
- **Operating system vulnerabilities**
- **Hardware-based attacks**
- **Network-based attacks** (this is local-only software)

### 🔐 Security Features

Current security implementations:

| Feature | Implementation |
|---------|---------------|
| **Password Encryption** | AES-256-CBC with random IV |
| **Key Derivation** | PBKDF2 with 10,000 iterations |
| **Master Password** | SHA-256 hashed |
| **Salt** | Random 128-bit salt per entry |
| **Storage** | Local JSON with encrypted passwords only |

### 💡 Security Best Practices

For users:

- **Use a strong master password**
- **Keep regular backups** of credentials.json
- **Update to latest versions** promptly
- **Run on updated Windows systems**
- **Use antivirus software**

For developers:

- **Follow secure coding practices**
- **Use established crypto libraries**
- **Validate all inputs**
- **Handle errors securely**
- **Clear sensitive data from memory**

### 🏆 Security Recognition

We appreciate security researchers who help keep this project secure. Contributors to security improvements will be:

- **Credited** in release notes (with permission)
- **Listed** in a security contributors file
- **Thanked** publicly (if desired)

### 📞 Contact Information

For security-related questions:

- **GitHub Issues**: Use the Security Issue template
- **Email**: Check maintainer's GitHub profile
- **Response Time**: 24-48 hours for critical issues

### 📝 Security Updates

Security updates will be:

- **Released promptly** for critical issues
- **Clearly marked** in release notes
- **Announced** in GitHub releases
- **Documented** with severity levels

### ⚖️ Legal

- **No bug bounties** are offered (personal project)
- **Good faith research** is encouraged and protected
- **Responsible disclosure** is expected
- **Cooperation** with fix development is appreciated

---

## Recent Security Updates

### Version 1.0.0
- Initial release with AES-256 encryption
- PBKDF2 key derivation implementation
- Secure master password hashing

---

**Last Updated**: October 28, 2025  
**Next Review**: January 2026

Thank you for helping keep My Own Password Manager secure! 🛡️