namespace Application.Common.Interfaces
{
    public interface IHashService
    {
        string Encrypt(string key);

        string EncryptPassword(string key);

        bool Compare(string hash, string key);
    }
}
