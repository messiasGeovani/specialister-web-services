using Application.Common.Interfaces;

namespace Application.Common.Services
{
    public class HashService : IHashService
    {
        private string salt;

        public HashService()
        {
            salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public string Encrypt(string key)
        {
            return BCrypt.Net.BCrypt.HashString(key);
        }

        public string EncryptPassword(string key)
        {
            return BCrypt.Net.BCrypt.HashPassword(key, salt);
        }

        public bool Compare(string key, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(key, hash);
        }

    }
}
