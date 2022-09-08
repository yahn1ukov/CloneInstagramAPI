using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace CloneInstagramAPI.Infrastructure.Common.Authentication
{
    public class PasswordHashGenerator : IPasswordHashGenerator
    {
        public void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA256();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac = new HMACSHA256(passwordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computeHash.SequenceEqual(passwordHash);
        }
    }
}