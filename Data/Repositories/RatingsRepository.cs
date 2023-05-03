using Data.Base.Repositories;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class RatingsRepository : BaseRepository<RatingEntity>, IRatingRepository
    {
        public RatingsRepository(IAppDbContext context) : base(context, context.ProfileRatings)
        {
        }
    }
}
