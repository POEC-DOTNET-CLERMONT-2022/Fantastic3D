using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.API.Controllers
{
    public class UserController : GenericController<UserDto, UserEntity>
    {
        public UserController(IDataManager<UserDto, UserEntity> dataManager) : base(dataManager)
        {
        }
    }
}
