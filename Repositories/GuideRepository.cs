using CropConnect.Models;
using CropConnect.Repositories.Interfaces;

namespace CropConnect.Repositories
{
    public class GuideRepository : IGuideRepository
    {
        private readonly AppDbContext _appDbContext;
        public GuideRepository(AppDbContext appDbContext){ _appDbContext = appDbContext; }

        public bool CreateGuide(Guide guide)
        {
            var author = _appDbContext.Account.SingleOrDefault(x => x.Id == guide.AuthorId);
            if (author == null)
                return false;
            guide.Author = author;
            _appDbContext.Guide.Add(guide);
            _appDbContext.SaveChanges();
            return true;
        }

        public void DeleteGuideById(int id)
        {
            Guide? guide = _appDbContext.Guide.SingleOrDefault(x =>  x.Id == id);
            if (guide != null){
                _appDbContext.Guide.Remove(guide);
                _appDbContext.SaveChanges();
            }
        }

        public Guide? GetGuideById(int id)
        {
            Guide? guide = _appDbContext.Guide.SingleOrDefault(x => x.Id == id);
            if (guide != null)
            {
                var author = _appDbContext.Account.SingleOrDefault(x => x.Id == guide.AuthorId);
                guide.Author = author;
            }
            return guide;
        }
        public List<Guide> GetGuides()
        {
            List<Guide> guides = _appDbContext.Guide.ToList();

            foreach(Guide guide in guides)
            {
                var author = _appDbContext.Account.SingleOrDefault(x => x.Id == guide.AuthorId);
                guide.Author = author;
            }

            return guides;
        }

        public bool UpdateGuide(Guide guide)
        {
            var old = _appDbContext.Guide.SingleOrDefault(x => x.Id == guide.Id);
            if (old == null) return false;

            old.Title = guide.Title;
            old.Content = guide.Content;
            old.LastUpdated = guide.LastUpdated;
            old.HeadingImage = guide.HeadingImage;
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
