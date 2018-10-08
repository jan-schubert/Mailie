using System;
using System.IO;
using System.Security.Cryptography;

namespace Mailie.Cryptography
{
  internal class CryptographyService : ICryptographyService
  {
    private const string Con = "j{Jw@$Khn|C{T}u)q0l1u7";

    public string Encrypt(string clearValue)
    {
      using (var aes = Aes.Create())
      {
        aes.Key = CreateKey(Con);
        var encrypted = AesEncryptStringToBytes(clearValue, aes.Key, aes.IV);
        return Convert.ToBase64String(encrypted) + ";" + Convert.ToBase64String(aes.IV);
      }
    }

    public string Decrypt(string encryptedValue)
    {
      var iv = encryptedValue.Substring(encryptedValue.IndexOf(';') + 1,
        encryptedValue.Length - encryptedValue.IndexOf(';') - 1);
      encryptedValue = encryptedValue.Substring(0, encryptedValue.IndexOf(';'));

      return AesDecryptStringFromBytes(Convert.FromBase64String(encryptedValue), CreateKey(Con),
        Convert.FromBase64String(iv));
    }

    private static byte[] CreateKey(string password, int keyBytes = 32)
    {
      var salt = new byte[] {80, 70, 60, 50, 40, 30, 20, 10};
      const int iterations = 300;
      var keyGenerator = new Rfc2898DeriveBytes(password, salt, iterations);
      return keyGenerator.GetBytes(keyBytes);
    }

    private static byte[] AesEncryptStringToBytes(string plainText, byte[] key, byte[] iv)
    {
      if (plainText == null || plainText.Length <= 0)
        throw new ArgumentNullException($"{nameof(plainText)}");
      if (key == null || key.Length <= 0)
        throw new ArgumentNullException($"{nameof(key)}");
      if (iv == null || iv.Length <= 0)
        throw new ArgumentNullException($"{nameof(iv)}");

      using (var aes = Aes.Create())
      {
        aes.Key = key;
        aes.IV = iv;

        byte[] encrypted;
        using (var memoryStream = new MemoryStream())
        {
          using (var encryptor = aes.CreateEncryptor())
          {
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
              using (var streamWriter = new StreamWriter(cryptoStream))
              {
                streamWriter.Write(plainText);
              }
            }

            encrypted = memoryStream.ToArray();
          }
        }

        return encrypted;
      }
    }

    private static string AesDecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
    {
      if (cipherText == null || cipherText.Length <= 0)
        throw new ArgumentNullException($"{nameof(cipherText)}");
      if (key == null || key.Length <= 0)
        throw new ArgumentNullException($"{nameof(key)}");
      if (iv == null || iv.Length <= 0)
        throw new ArgumentNullException($"{nameof(iv)}");

      string plaintext;

      using (var aes = Aes.Create())
      {
        aes.Key = key;
        aes.IV = iv;

        using (var memoryStream = new MemoryStream(cipherText))
        {
          using (var decryptor = aes.CreateDecryptor())
          {
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
              using (var streamReader = new StreamReader(cryptoStream))
              {
                plaintext = streamReader.ReadToEnd();
              }
            }
          }
        }
      }

      return plaintext;
    }
  }
}