using Data.Base.Repositories;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class PersonRepository : BaseRepository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(IAppDbContext context) : base(context, context.People)
        {
        }
    }
}
