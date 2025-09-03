using System.Security.Cryptography;
using System.Text;

namespace EquilibrApp_BACK.DTO
{
    public static class Utilidades
    {
        public static Byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                return sha256.ComputeHash(inputBytes);
            }
        }
    }
}
