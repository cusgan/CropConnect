using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

namespace CropConnect.Services
{
    public class PostingService: IPostingService
    {
        private readonly IPostingRepository _postingRepository;
        public PostingService(IPostingRepository postingRepository) { _postingRepository = postingRepository; }
        public void CreatePosting(PostingDTO postingDTO, IFormFile imageFile)
        {
            Enum.TryParse(postingDTO.ProductType, true, out ProductType productType);
            Enum.TryParse(postingDTO.UnitType, true, out UnitType unitType);
            Posting newPosting = new Posting
            {
                Id = postingDTO.Id,
                PosterId = postingDTO.PosterId,
                ProductName = postingDTO.ProductName,
                ProductDescription = postingDTO.ProductDescription,
                ProductType = productType,
                UnitType = unitType,
                Price = postingDTO.Price,
                Stock = postingDTO.Stock,
                AdditionalInfo = postingDTO.AdditionalInfo,
            };
            byte[]? imageData = null;
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }
            }

            _postingRepository.CreatePosting(newPosting, imageData);
        }
        public List<Posting> GetAllPostings()
        {
            return _postingRepository.GetAllPostings();
        }
        public List<Posting> GetPostingsById(int id)
        {
            return _postingRepository.GetPostingsById(id);
        }
        public Posting GetPostingById(int id)
        {
            return _postingRepository.GetPostingById(id);
        }
        public void UpdatePosting(int id, PostingDTO postingDTO)
        {
            var posting = _postingRepository.GetPostingById(id);
            if (posting == null)
            {
                throw new Exception($"Posting with ID {id} not found.");
            }
            Enum.TryParse(postingDTO.ProductType, true, out ProductType productType);
            Enum.TryParse(postingDTO.UnitType, true, out UnitType unitType);
            posting.ProductName = postingDTO.ProductName;
            posting.ProductType = productType;
            posting.UnitType = unitType;
            posting.Price = postingDTO.Price;
            posting.Stock = postingDTO.Stock;
            posting.AdditionalInfo = postingDTO.AdditionalInfo;

            _postingRepository.UpdatePosting(posting);
        }
        public bool DeletePosting(int id)
        {
            var posting = _postingRepository.GetPostingById(id);
            if (posting == null)
                return false;

            _postingRepository.DeletePosting(posting);
            return true;
        }
        public bool BuyProduct(int id, int quantity)
        {
            var posting = _postingRepository.GetPostingById(id);
            if (posting == null)
            {
                throw new Exception($"Posting with ID {id} not found.");
            }

            if (posting.Stock == 0)
            {
                return false;
            }
            if (posting.Stock - quantity >= 0)
            {
                posting.Stock = posting.Stock - quantity;
            }
            else
            {
                throw new Exception($"Product stock is insufficient.");
            }

            _postingRepository.BuyProduct(posting);
            return true;
        }
        public void SetProductImage(int id, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    var imageData = memoryStream.ToArray();
                    _postingRepository.SetProductImage(id, imageData);
                }
            }
        }
    }
}
