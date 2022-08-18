namespace CloneInstagramAPI.Application.Common.Interfaces.Authentication
{
    public interface IPasswordHashGenerator
    {
        void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}