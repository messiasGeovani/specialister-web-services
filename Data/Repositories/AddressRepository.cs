using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IAppDbContext _context;

        public AddressRepository(IAppDbContext context)
        {
            _context = context;
        }

        public Task Create(AddressEntity model)
        {
            _context.Addresses.Add(model);

            return _context.SaveChangesAsync();
        }

        public Task<List<AddressEntity>> Get()
        {
            return _context.Addresses.ToListAsync();
        }

        public ValueTask<AddressEntity?> GetById(Guid id)
        {
            return _context.Addresses.FindAsync(id);
        }

        public Task Update(AddressEntity model)
        {
            _context.Addresses.Update(model);

            return _context.SaveChangesAsync();
        }
    }
}
