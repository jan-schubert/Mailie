namespace Mailie.Cryptography
{
  public interface ICryptographyService
  {
    string Encrypt(string textToEncrypt);
    string Decrypt(string textToEncrypt);
  }
}