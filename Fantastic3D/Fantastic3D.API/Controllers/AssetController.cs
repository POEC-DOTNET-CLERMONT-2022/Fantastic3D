using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.API.Controllers
{
    public class AssetController : GenericController<AssetDto, AssetEntity>
    {
        public AssetController(IDataManager<AssetDto, AssetEntity> dataManager) : base(dataManager)
        {
        }
    }
}
