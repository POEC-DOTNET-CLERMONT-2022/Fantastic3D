using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.API.Controllers
{
    public class TagTypeController : GenericController<TagTypeDto, TagTypeEntity>
    {
        public TagTypeController(IDataManager<TagTypeDto, TagTypeEntity> dataManager) : base(dataManager)
        {
        }
    }
}
