using CropConnect.Models;
using CropConnect.Repositories.Interfaces;

namespace CropConnect.Repositories
{
    public class FarmRepository : IFarmRepository
    {
        private readonly AppDbContext _appDbContext;
        public FarmRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }
        public void RegisterFarm(Farm farm)
        {
            _appDbContext.Farm.Add(farm);
            _appDbContext.SaveChanges();
        }
        public Farm GetFarmById(int id)
        {
            return _appDbContext.Farm
                .FirstOrDefault(f => f.Id == id);
        }
        public void UpdateFarm(Farm farm)
        {
            _appDbContext.Farm.Update(farm);
            _appDbContext.SaveChanges();
        }
    }
}
