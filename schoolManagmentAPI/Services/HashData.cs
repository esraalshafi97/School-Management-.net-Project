using System.Text;
using XSystem.Security.Cryptography;

namespace schoolManagmentAPI.Services
{
    public class HashData
    {
        public static String HashPassword(String value)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(value);
                byte[] hashBytes = md5.ComputeHash(passwordBytes);
                string hashedPassword = Convert.ToBase64String(hashBytes);
                
                return hashedPassword;
            }
        }
    }
}
