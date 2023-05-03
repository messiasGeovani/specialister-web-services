using Data.Base.Repositories;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class ProfessionalRepository : BaseRepository<ProfessionalEntity>, IProfessionalRepository
    {

        public ProfessionalRepository(IAppDbContext context) : base(context, context.Professionals)
        {
        }
    }
}
