using CropConnect.DTO;
using CropConnect.Models;
using CropConnect.Repositories;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services.Interfaces;

namespace CropConnect.Services
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;
        public FarmService(IFarmRepository farmRepository) { _farmRepository = farmRepository; }
        public void RegisterFarm(FarmDTO farmDTO)
        {
            Enum.TryParse(farmDTO.FarmType, true, out FarmType farmType);
            Enum.TryParse(farmDTO.FarmSize, true, out FarmSize farmSize);
            Farm newFarm = new Farm
            {
                Id = farmDTO.Id,
                OwnerAccountId = farmDTO.OwnerAccountId,
                FarmName = farmDTO.FarmName,
                Location = farmDTO.Location,
                FarmType = farmType,
                FarmSize = farmSize,
                ContactInfo = farmDTO.ContactInfo,
            };

            _farmRepository.RegisterFarm(newFarm);
        }
        public void UpdateFarm(int id, FarmDTO farmDTO)
        {
            var farm = _farmRepository.GetFarmById(id);
            if (farm == null)
            {
                throw new Exception($"Farm with ID {id} not found.");
            }
            Enum.TryParse(farmDTO.FarmType, true, out FarmType farmType);
            Enum.TryParse(farmDTO.FarmSize, true, out FarmSize farmSize);
            farm.FarmName = farmDTO.FarmName;
            farm.Location = farmDTO.Location;
            farm.FarmType = farmType;
            farm.FarmSize = farmSize;
            farm.ContactInfo = farmDTO.ContactInfo;

            _farmRepository.UpdateFarm(farm);
        }
    }
}
