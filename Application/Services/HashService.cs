using Application.Interfaces;

namespace Application.Services
{
    public class HashService : IHashService
    {
        public string Encrypt(string key)
        {
            return BCrypt.Net.BCrypt.HashString(key);
        }

        public string EncryptPassword(string key)
        {
            return BCrypt.Net.BCrypt.HashPassword(key);
        }

        public bool Compare(string hash, string key)
        {
            return BCrypt.Net.BCrypt.Verify(hash, key);
        }

    }
}
