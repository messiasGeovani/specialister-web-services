using Data.Base.Repositories;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class ProfileRepository : BaseRepository<ProfileEntity>, IProfileRepository
    {
        private IAppDbContext _context;

        public ProfileRepository(IAppDbContext context) : base(context, context.Profiles)
        {
            _context = context;
        }

        public Task<List<ProfileEntity>> Search(Expression<Func<ProfileEntity, bool>> query)
        {
            return _context.Profiles
                .AsQueryable()
                .Where(query)
                .ToListAsync();
        }

        public Task<ProfileEntity?> GetByUserId(Guid id)
        {
            return _context.Profiles
                .AsQueryable()
                .Where(x => x.UserId == id)
                .FirstOrDefaultAsync();
        }
    }
}
