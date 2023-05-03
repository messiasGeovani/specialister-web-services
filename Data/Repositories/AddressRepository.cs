using Data.Base.Repositories;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class AddressRepository : BaseRepository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(IAppDbContext context) : base(context, context.Addresses)
        {
        }
    }
}
