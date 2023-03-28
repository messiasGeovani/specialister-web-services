using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IAppDbContext _context;

        public PersonRepository(IAppDbContext context)
        {
            _context = context;
        }

        public Task Create(Person model)
        {
            _context.People.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task<List<Person>> Get()
            => _context.People.ToListAsync();

        public ValueTask<Person?> GetById(Guid id)
            => _context.People.FindAsync(id);

        public Task<List<Person>> Search(Expression<Func<Person, bool>> query)
        {
            return _context.People
                .AsQueryable()
                .Where(query)
                .ToListAsync();
        }

        public Task Update(Person model)
        {
            _context.People.Update(model);

            return _context.SaveChangesAsync();
        }
    }
}
