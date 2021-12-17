using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers
{
    public static class Hashing
    {
        public static byte[] HashedValue(byte[] value)
        {
            using var hmac = new HMACSHA512();
            var result = hmac.ComputeHash(value);
            return result;
        }

        public static string HashSha512Data (string input)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

             return hash;
            }
        }
    }
}