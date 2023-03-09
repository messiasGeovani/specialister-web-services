using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User FindById(Guid id);
        User? Find(string username, string password);
    }
}
