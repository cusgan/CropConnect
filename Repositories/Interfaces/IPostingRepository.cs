using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IPostingRepository
    {
        public void CreatePosting(Posting posting);
        public List<Posting> GetAllPostings();
        public List<Posting> GetPostingsById(int id);
        public Posting GetPostingById(int id);
        public void UpdatePosting(Posting posting);
        public void DeletePosting(Posting posting);
    }
}
