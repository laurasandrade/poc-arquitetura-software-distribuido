using System.Security.Cryptography;
using System.Text;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Tools
{
    public static class PasswordTools
    {
        // Encoding
        public static string Encrypt(string strData)
        {
            using (var crypt = new SHA256Managed())
            {
                var hash = new StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(strData));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
        }
    }
}
