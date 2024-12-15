using CropConnect.Models;
using CropConnect.Repositories.Interfaces;

namespace CropConnect.Repositories
{
    public class PostingRepository: IPostingRepository
    {
        private readonly AppDbContext _appDbContext;
        public PostingRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }

        public void CreatePosting(Posting posting, byte[] imageData)
        {
            _appDbContext.Posting.Add(posting);
            posting.ProductImage = imageData;
            _appDbContext.SaveChanges();
        }
        public List<Posting> GetAllPostings()
        {
            return _appDbContext.Posting.ToList();
        }
        public List<Posting> GetPostingsById(int id)
        {
            return _appDbContext.Posting
                .Where(n => n.PosterId == id)
                .ToList();
        }
        public Posting GetPostingById(int id)
        {
            return _appDbContext.Posting
                .FirstOrDefault(p => p.Id == id);
        }
        public void UpdatePosting(Posting posting)
        {
            _appDbContext.Posting.Update(posting);
            _appDbContext.SaveChanges();
        }
        public void DeletePosting(Posting posting)
        {
            _appDbContext.Posting.Remove(posting);
            _appDbContext.SaveChanges();
        }
        public void BuyProduct(Posting posting)
        {
            _appDbContext.Posting.Update(posting);
            _appDbContext.SaveChanges();
        }
        public void SetProductImage(int id, byte[] imageData)
        {
            var posting = _appDbContext.Posting.FirstOrDefault(p => p.Id == id);
            if (posting != null)
            {
                posting.ProductImage = imageData;
                _appDbContext.SaveChanges();
            }
        }
    }
}
