using System.Security.Cryptography;
using System.Text;

namespace Servicios_22MS
{
    public class Crypto_22MS
    {
        public static string Hash_22MS(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesInput = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytesInput);

                StringBuilder stringBuilder = new StringBuilder();

                foreach (byte hashByte in hashBytes)
                {
                    stringBuilder.Append(hashByte.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}