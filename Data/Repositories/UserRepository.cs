using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IAppDbContext _context;

        public UserRepository(IAppDbContext context)
        {
            _context = context;
        }

        public User FindById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User? Find(string username, string password)
        {
            return _context.Users
                .Where(x => x.UserName == username && x.Password == password)
                .FirstOrDefault();
        }        
    }
}
