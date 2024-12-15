﻿using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IPostingRepository
    {
        public void CreatePosting(Posting posting, byte[] imageData);
        public List<Posting> GetAllPostings();
        public List<Posting> GetPostingsById(int id);
        public Posting GetPostingById(int id);
        public void UpdatePosting(Posting posting);
        public void DeletePosting(Posting posting);
        public void BuyProduct(Posting posting);
        public void SetProductImage(int id, byte[] imageData);
    }
}
