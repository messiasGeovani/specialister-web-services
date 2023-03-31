using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly AppDbContext _context;

        public ProfessionalRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public Task Create(ProfessionalEntity model)
        {
            _context.Professionals.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task<List<ProfessionalEntity>> Get()
        {
            return _context.Professionals.ToListAsync();
        }

        public ValueTask<ProfessionalEntity?> GetById(Guid id)
        {
            return _context.Professionals.FindAsync(id);
        }

        public Task Update(ProfessionalEntity model)
        {
            _context.Professionals.Update(model);

            return _context.SaveChangesAsync();
        }
    }
}
