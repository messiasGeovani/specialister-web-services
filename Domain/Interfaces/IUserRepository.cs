using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> FindById(int id);
    }
}
