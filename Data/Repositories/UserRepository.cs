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

        public Task<List<UserEntity>> Get()
        {
            return _context.Users.ToListAsync();
        }

        public ValueTask<UserEntity?> GetById(Guid id)
        {
            return _context.Users.FindAsync(id);
        }

        public Task Create(UserEntity model)
        {
            _context.Users.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task Update(UserEntity model)
        {
            _context.Users.Update(model);
            return _context.SaveChangesAsync();
        }

        public Task<List<UserEntity>> Search(Expression<Func<UserEntity, bool>> query)
        {
            return _context.Users
                .AsQueryable()
                .Where(query)
                .ToListAsync();
        }
    }
}
