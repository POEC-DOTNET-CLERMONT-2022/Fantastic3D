using AutoMapper;
using Fantastic3D.Dto;

namespace Fantastic3D.Persistence.Entities
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<TagEntity, TagDto>().ReverseMap();
            CreateMap<TagTypeEntity, TagTypeDto>().ReverseMap();
            CreateMap<AssetEntity, AssetDto>().ReverseMap();
            CreateMap<OrderEntity, OrderDto>().ReverseMap();
            CreateMap<PurchaseEntity, PurchaseDto>().ReverseMap();
            CreateMap<ReviewEntity, ReviewDto>().ReverseMap();
        }
    }
}
