using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.API.Controllers
{
    public class OrderController : GenericController<OrderDto, OrderEntity>
    {
        public OrderController(IDataManager<OrderDto, OrderEntity> dataManager) : base(dataManager)
        {
        }
    }
}
