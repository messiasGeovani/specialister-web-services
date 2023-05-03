using Data.Base.Repositories;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private IAppDbContext _context;

        public UserRepository(IAppDbContext context) : base(context, context.Users)
        {
            _context = context;
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
