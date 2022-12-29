using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;

using static System.Console;
using static System.Convert;

namespace Inje.AIConvergence.Shared;

public static class Protector
{
  private static readonly byte[] salt = Encoding.Unicode.GetBytes("AIConvergence");
  private static readonly int iterations = 150_000;
  private static Dictionary<string, User> Users = new();
  public static string Encrypt(string plainText, string password)
  {
    byte[] encryptedBytes;
    byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
    using (Aes aes = Aes.Create())
    {
      Stopwatch timer = Stopwatch.StartNew();
      using (Rfc2898DeriveBytes pbkdf2 = new(password, salt, iterations))
      {
        aes.Key = pbkdf2.GetBytes(32);
        aes.IV = pbkdf2.GetBytes(16);
      }
      timer.Stop();
      WriteLine("{0:N0} milliseconds to generate Key and IV using {1:N0} iterations.",
        arg0: timer.ElapsedMilliseconds,
        arg1: iterations);
      using (MemoryStream ms = new())
      {
        using (ICryptoTransform transformer = aes.CreateEncryptor())
        {
          using (CryptoStream cs = new(ms, transformer, CryptoStreamMode.Write))
          {
            cs.Write(plainBytes, 0, plainBytes.Length);
          }
        }
        encryptedBytes = ms.ToArray();
      }
    }
    return ToBase64String(encryptedBytes);
  }
  public static string Decrypt(string ciperText, string password)
  {
    byte[] plainBytes;
    byte[] cryptoBytes = FromBase64String(ciperText);
    using (Aes aes = Aes.Create())
    {
      using (Rfc2898DeriveBytes pbkdf2 = new(password, salt, iterations))
      {
        aes.Key = pbkdf2.GetBytes(32);
        aes.IV = pbkdf2.GetBytes(16);
      }
      using (MemoryStream ms = new())
      {
        using (ICryptoTransform transformer = aes.CreateDecryptor())
        {
          using (CryptoStream cs = new(ms, transformer, CryptoStreamMode.Write))
          {
            cs.Write(cryptoBytes, 0, cryptoBytes.Length);
          }
        }
        plainBytes = ms.ToArray();
      }
    }
    return Encoding.Unicode.GetString(plainBytes);
  }
  private static string SaltAndHashPassword(string password, string salt) 
  {
    using (SHA256 sha = SHA256.Create())
    {
      string saltedPassword = password + salt;
      return ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
    }
  }
  public static User Register(string username, string password)
  {
    RandomNumberGenerator rng = RandomNumberGenerator.Create();
    byte[] saltBytes = new byte[16];
    rng.GetBytes(saltBytes);
    string saltText = ToBase64String(saltBytes);
    string saltedHashedPassword = SaltAndHashPassword(password, saltText);
    User user = new(username, saltText, saltedHashedPassword);
    Users.Add(user.Name, user);
    return user;
  }
  public static bool CheckPassword(string password, string salt, string hashedPassword)
  {
    string saltHashedPassword = SaltAndHashPassword(password, salt);
    return (hashedPassword == saltHashedPassword);
  }
  public static bool CheckPassword(string username, string password)
  {
    if (!Users.ContainsKey(username))
    {
      return false;
    }
    User u = Users[username];
    return CheckPassword(password, u.Salt, u.SaltedHashedPassword);
  }
}