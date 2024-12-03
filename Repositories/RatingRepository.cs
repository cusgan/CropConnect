using CropConnect.Models;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CropConnect.Repositories
{
    public class RatingRepository: IRatingRepository
    {
        private readonly AppDbContext _appDbContext;
        public RatingRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }

        public void CreateRating(Rating rating)
        {
            _appDbContext.Rating.Add(rating);
            _appDbContext.SaveChanges();
        }
        public List<Rating> GetRatings(int id)
        {
            return _appDbContext.Rating
                .Where(n => n.RatedId == id)
                .ToList();
        }
        public Rating GetRatingById(int id)
        {
            return _appDbContext.Rating
                .FirstOrDefault(r => r.Id == id);
        }
        public void UpdateRating(Rating rating)
        {
            _appDbContext.Rating.Update(rating);
            _appDbContext.SaveChanges();
        }
        public void DeleteRating(Rating rating)
        {
            _appDbContext.Rating.Remove(rating);
            _appDbContext.SaveChanges();
        }
    }
}
