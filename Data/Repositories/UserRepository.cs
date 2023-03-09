using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IAppDbContext _context;

        public UserRepository(IAppDbContext context)
        {
            _context = context;
        }

        public ValueTask<User?> FindById(Guid id)        
            => _context.Users.FindAsync(id);

        public Task<User?> Find(string username, string password)
            => _context.Users
                .Where(x => x.UserName == username && x.Password == password)
                .SingleOrDefaultAsync();
          
    }
}
