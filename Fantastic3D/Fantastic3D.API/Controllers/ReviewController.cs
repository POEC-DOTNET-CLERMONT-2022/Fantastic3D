using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.API.Controllers
{
    public class ReviewController : GenericController<ReviewDto, ReviewEntity>
    {
        public ReviewController(IDataManager<ReviewDto, ReviewEntity> dataManager) : base(dataManager)
        {
        }
    }
}
