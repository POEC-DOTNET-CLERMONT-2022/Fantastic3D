using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.API.Controllers
{
    public class TagController : GenericController<TagDto, TagEntity>
    {
        public TagController(IDataManager<TagDto, TagEntity> dataManager) : base(dataManager)
        {
        }
    }
}
