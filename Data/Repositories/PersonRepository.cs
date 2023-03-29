using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IAppDbContext _context;

        public PersonRepository(IAppDbContext context)
        {
            _context = context;
        }

        public Task Create(PersonEntity model)
        {
            _context.People.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task<List<PersonEntity>> Get()
            => _context.People.ToListAsync();

        public ValueTask<PersonEntity?> GetById(Guid id)
            => _context.People.FindAsync(id);

        public Task Update(PersonEntity model)
        {
            _context.People.Update(model);

            return _context.SaveChangesAsync();
        }
    }
}
