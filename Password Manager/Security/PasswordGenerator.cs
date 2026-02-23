using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Security
{
    public class PasswordGenerator
    {
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string NumberChars = "0123456789";
        private const string SymbolChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        // Generate a random password
        public string GeneratePassword(
            int length = 16,
            bool includeUppercase = true,
            bool includeLowercase = true,
            bool includeNumbers = true,
            bool includeSymbols = true)
        {
            if (length < 4)
                throw new ArgumentException("Password length must be at least 4");

            if (!includeUppercase && !includeLowercase && !includeNumbers && !includeSymbols)
                throw new ArgumentException("At least one character type must be selected");

            // Build character set based on options
            StringBuilder charSet = new StringBuilder();
            if (includeUppercase) charSet.Append(UppercaseChars);
            if (includeLowercase) charSet.Append(LowercaseChars);
            if (includeNumbers) charSet.Append(NumberChars);
            if (includeSymbols) charSet.Append(SymbolChars);

            string availableChars = charSet.ToString();

            // Generate random password using cryptographically secure random
            StringBuilder password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    int index = randomBytes[i] % availableChars.Length;
                    password.Append(availableChars[index]);
                }
            }

            // Ensure at least one character from each selected type
            password = EnsureComplexity(password.ToString(),
                                       includeUppercase,
                                       includeLowercase,
                                       includeNumbers,
                                       includeSymbols);

            return password.ToString();
        }

        // Calculate password strength (0-100)
        public int CalculatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return 0;

            int score = 0;

            // Length scoring (up to 40 points)
            if (password.Length >= 8) score += 10;
            if (password.Length >= 12) score += 10;
            if (password.Length >= 16) score += 10;
            if (password.Length >= 20) score += 10;

            // Character variety (up to 40 points)
            if (password.Any(char.IsUpper)) score += 10;
            if (password.Any(char.IsLower)) score += 10;
            if (password.Any(char.IsDigit)) score += 10;
            if (password.Any(c => SymbolChars.Contains(c))) score += 10;

            // Bonus for mixing character types (up to 20 points)
            int charTypes = 0;
            if (password.Any(char.IsUpper)) charTypes++;
            if (password.Any(char.IsLower)) charTypes++;
            if (password.Any(char.IsDigit)) charTypes++;
            if (password.Any(c => SymbolChars.Contains(c))) charTypes++;

            if (charTypes >= 3) score += 10;
            if (charTypes == 4) score += 10;

            // Penalty for common patterns
            if (HasCommonPatterns(password)) score -= 20;

            return Math.Max(0, Math.Min(100, score));
        }

        // Get password strength as text
        public string GetPasswordStrengthText(int score)
        {
            if (score < 30) return "Weak";
            if (score < 60) return "Medium";
            if (score < 80) return "Strong";
            return "Very Strong";
        }

        // Ensure password has at least one character from each required type
        private StringBuilder EnsureComplexity(
            string password,
            bool needsUppercase,
            bool needsLowercase,
            bool needsNumbers,
            bool needsSymbols)
        {
            StringBuilder result = new StringBuilder(password);
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomByte = new byte[1];

                if (needsUppercase && !password.Any(char.IsUpper))
                {
                    rng.GetBytes(randomByte);
                    int pos = randomByte[0] % result.Length;
                    rng.GetBytes(randomByte);
                    result[pos] = UppercaseChars[randomByte[0] % UppercaseChars.Length];
                }

                if (needsLowercase && !password.Any(char.IsLower))
                {
                    rng.GetBytes(randomByte);
                    int pos = randomByte[0] % result.Length;
                    rng.GetBytes(randomByte);
                    result[pos] = LowercaseChars[randomByte[0] % LowercaseChars.Length];
                }

                if (needsNumbers && !password.Any(char.IsDigit))
                {
                    rng.GetBytes(randomByte);
                    int pos = randomByte[0] % result.Length;
                    rng.GetBytes(randomByte);
                    result[pos] = NumberChars[randomByte[0] % NumberChars.Length];
                }

                if (needsSymbols && !password.Any(c => SymbolChars.Contains(c)))
                {
                    rng.GetBytes(randomByte);
                    int pos = randomByte[0] % result.Length;
                    rng.GetBytes(randomByte);
                    result[pos] = SymbolChars[randomByte[0] % SymbolChars.Length];
                }
            }

            return result;
        }

        // Check for common patterns
        private bool HasCommonPatterns(string password)
        {
            string lower = password.ToLower();

            // Check for sequential characters
            if (lower.Contains("abc") || lower.Contains("123") ||
                lower.Contains("qwerty") || lower.Contains("password"))
                return true;

            // Check for repeated characters
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] && password[i] == password[i + 2])
                    return true;
            }

            return false;
        }
    }
}