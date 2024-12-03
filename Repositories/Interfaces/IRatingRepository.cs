using CropConnect.DTO;
using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        public void CreateRating(Rating rating);
        public List<Rating> GetRatings(int id);
        public Rating GetRatingById(int id);
        public void UpdateRating(Rating rating);
        public void DeleteRating(Rating rating);
    }
}
