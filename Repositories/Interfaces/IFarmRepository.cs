using CropConnect.Models;

namespace CropConnect.Repositories.Interfaces
{
    public interface IFarmRepository
    {
        public void RegisterFarm(Farm farm);
        public Farm GetFarmById(int id);
        public void UpdateFarm(Farm farm);
    }
}
