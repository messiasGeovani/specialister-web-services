using Data.Interfaces;
using Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Base.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly IAppDbContext _context;
        private readonly DbSet<TEntity> DbSet;

        public BaseRepository(IAppDbContext context, DbSet<TEntity> dbSet)
        {
            _context = context;
            DbSet = dbSet;
        }

        public Task Create(TEntity model)
        {
            DbSet.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task<List<TEntity>> Get()
        {
            return DbSet.ToListAsync();
        }

        public ValueTask<TEntity?> GetById(Guid id)
        {
            return DbSet.FindAsync(id);
        }

        public Task Update(TEntity model)
        {
            DbSet.Update(model);

            return _context.SaveChangesAsync();
        }
    }
}
