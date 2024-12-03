using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

namespace CropConnect.Services
{
    public class RatingService: IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository) { _ratingRepository = ratingRepository; }
        public void CreateRating(RatingDTO ratingDTO)
        {
            Rating newRating = new Rating
            {
                Id = ratingDTO.Id,
                RatedId = ratingDTO.RatedId,
                RaterId = ratingDTO.RaterId,
                Value = ratingDTO.Value,
                Content = ratingDTO.Content,
            };

            _ratingRepository.CreateRating(newRating);
        }
        public List<Rating> GetRatings(int id)
        {
            return _ratingRepository.GetRatings(id);
        }
        public void UpdateRating(int id, RatingDTO ratingDTO)
        {
            var rating = _ratingRepository.GetRatingById(id);
            if (rating == null)
            {
                throw new Exception($"Rating with ID {id} not found.");
            }

            // Only update if the rating exists
            rating.Value = ratingDTO.Value;
            rating.Content = ratingDTO.Content;

            _ratingRepository.UpdateRating(rating);
        }
        public bool DeleteRating(int id)
        {
            var rating = _ratingRepository.GetRatingById(id);
            if (rating == null)
                return false;

            _ratingRepository.DeleteRating(rating);
            return true;
        }

    }
}
