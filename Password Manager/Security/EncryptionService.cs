using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Security
{
    public class EncryptionService
    {
        // Encrypt a plain text password
        public string Encrypt(string plainText, string masterPassword)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentException("Plain text cannot be empty");

            if (string.IsNullOrEmpty(masterPassword))
                throw new ArgumentException("Master password cannot be empty");

            // Convert master password to a 256-bit key
            byte[] key = DeriveKeyFromPassword(masterPassword);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();  // Generate random IV (Initialization Vector)

                // Create encryptor
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Write IV to the beginning (we need it for decryption)
                    msEncrypt.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // Write the plain text
                        swEncrypt.Write(plainText);
                    }

                    // Convert encrypted bytes to Base64 string
                    byte[] encrypted = msEncrypt.ToArray();
                    return Convert.ToBase64String(encrypted);
                }
            }
        }

        // Decrypt an encrypted password
        public string Decrypt(string encryptedText, string masterPassword)
        {
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentException("Encrypted text cannot be empty");

            if (string.IsNullOrEmpty(masterPassword))
                throw new ArgumentException("Master password cannot be empty");

            // Convert Base64 string back to bytes
            byte[] cipherTextWithIV = Convert.FromBase64String(encryptedText);

            // Derive the same key from master password
            byte[] key = DeriveKeyFromPassword(masterPassword);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;

                // Extract IV from the beginning (first 16 bytes)
                byte[] iv = new byte[16];
                Array.Copy(cipherTextWithIV, 0, iv, 0, iv.Length);
                aes.IV = iv;

                // Create decryptor
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherTextWithIV, iv.Length, cipherTextWithIV.Length - iv.Length))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    // Read the decrypted text
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        // Derive a 256-bit encryption key from the master password
        private byte[] DeriveKeyFromPassword(string password)
        {
            // Use a fixed salt for key derivation
            // In production, you might want to store this salt in the database
            byte[] salt = Encoding.UTF8.GetBytes("PasswordManager2025Salt");

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                return deriveBytes.GetBytes(32);  // 32 bytes = 256 bits
            }
        }
    }
}