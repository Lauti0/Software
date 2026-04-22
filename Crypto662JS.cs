using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad662JS
{
    public class Crypto662JS
    {
        private static readonly string key = "1234567890123456"; // 16 chars
        private static readonly string iv = "abcdefghijklmnop";  // 16 chars

        public static string Encrypt662JS(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                var encryptor = aes.CreateEncryptor();

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(texto);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt662JS(string textoEncriptado)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                var decryptor = aes.CreateDecryptor();

                using (var ms = new MemoryStream(Convert.FromBase64String(textoEncriptado)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
