using CropConnect.DTO;

namespace CropConnect.Services.Interfaces
{
    public interface IFarmService
    {
        public void RegisterFarm(FarmDTO farmDTO);
        public void UpdateFarm(int id, FarmDTO farmDTO);
    }
}
