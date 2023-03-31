using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private IAppDbContext _context;

        public ProfileRepository(IAppDbContext context)
        {
            _context = context;
        }

        public Task<List<ProfileEntity>> Get()
        {
            return _context.Profiles.ToListAsync();
        }

        public ValueTask<ProfileEntity?> GetById(Guid id)
        {
            return _context.Profiles.FindAsync(id);
        }

        public Task Create(ProfileEntity model)
        {
            _context.Profiles.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task Update(ProfileEntity model)
        {
            _context.Profiles.Update(model);
            return _context.SaveChangesAsync();
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
