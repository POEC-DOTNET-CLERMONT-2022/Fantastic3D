using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.API.Controllers
{
    public class PurchaseController : GenericController<PurchaseDto, PurchaseEntity>
    {
        public PurchaseController(IDataManager<PurchaseDto, PurchaseEntity> dataManager) : base(dataManager)
        {
        }
    }
}
