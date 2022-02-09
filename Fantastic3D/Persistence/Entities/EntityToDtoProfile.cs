using AutoMapper;
using Fantastic3D.Dto;

namespace Fantastic3D.Persistence.Entities
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<TagTypeEntity, TagTypeDto>().ReverseMap();
            CreateMap<TagEntity, TagDto>().ReverseMap();

            CreateMap<AssetEntity, AssetDto>().ReverseMap();

            CreateMap<OrderEntity, OrderDto>().ReverseMap();
            CreateMap<PurchaseEntity, PurchaseDto>().ReverseMap();
            CreateMap<ReviewEntity, ReviewDto>().ReverseMap();
        }
    }
}
