using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IAppDbContext _context;

        public UserRepository(IAppDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> Get()
            => _context.Users.ToListAsync();


        public ValueTask<User?> GetById(Guid id)
            => _context.Users.FindAsync(id);

        public Task Create(User model)
        {
            _context.Users.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task Update(User model)
        {
            _context.Users.Update(model);
            return _context.SaveChangesAsync();
        }

        public Task<List<User>> Search(Expression<Func<User, bool>> query)
        {
            return _context.Users
                .AsQueryable()
                .Where(query)
                .ToListAsync();
        }
    }
}
