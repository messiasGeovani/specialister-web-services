using Application.Modules.Ratings.DTOs;

namespace Application.Modules.Ratings.Interfaces
{
    public interface IRatingsUseCase
    {
        Task<RatingDTO?> CreateRating(RatingDTO dto);

        Task<RatingDTO?> UpdateRating(RatingDTO dto);
    }
}
