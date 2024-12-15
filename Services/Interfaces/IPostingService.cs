using CropConnect.DTO;
using CropConnect.Models;

namespace CropConnect.Services.Interfaces
{
    public interface IPostingService
    {
        public void CreatePosting(PostingDTO postingDTO, IFormFile imageFile);
        public List<Posting> GetAllPostings();
        public List<Posting> GetPostingsById(int id);
        public void UpdatePosting(int id, PostingDTO postingDTO);
        public bool DeletePosting(int id);
        public bool BuyProduct(int id);
        public void SetProductImage(int id, IFormFile imageFile);
    }
}
