using CropConnect.DTO;
using CropConnect.Models;

namespace CropConnect.Services.Interfaces
{
    public interface IRatingService
    {
        public void CreateRating(RatingDTO ratingDTO);
        public List<Rating> GetRatings(int id);
        public void UpdateRating(int id, RatingDTO ratingDTO);
        public bool DeleteRating(int id);
    }
}
