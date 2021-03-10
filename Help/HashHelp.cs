using System.Security.Cryptography;
using System.Text;

namespace Bibliotheek.Help
{
    public static class HashHelp
    {
        public static string GetSha512Hash(string plainText)
        {
            using (var sha512 = SHA512.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] hashedBytes = sha512.ComputeHash(sourceBytes);
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    // Convert from decimals to hexadecimal.
                    sBuilder.Append(hashedBytes[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
