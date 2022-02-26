using AutoMapper;
using Fantastic3D.Dto;

namespace Fantastic3D.Persistence.Entities
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => "")
                );
            CreateMap<UserDto, UserEntity>()
                .AfterMap((src, dest) =>
                    {
                        if (dest.Password != string.Empty)
                            dest.SetNewPassword(dest.Password);
                    }
                );
            CreateMap<TagTypeEntity, TagTypeDto>().ReverseMap();
            CreateMap<TagEntity, TagDto>().ReverseMap();

            CreateMap<AssetEntity, AssetDto>()
                .ForMember(
                    dest => dest.CreatorName,
                    opt => opt.MapFrom(src => src.Creator.Username)
                );
            CreateMap<AssetDto, AssetEntity>()
                .AfterMap((src, dest) =>
                {
                    dest.Tags = new List<TagEntity>();
                }
                );

            CreateMap<OrderDto, OrderEntity>();
            CreateMap<OrderEntity, OrderDto>()
                .ForMember(
                        dest => dest.PurchasingUserName ,
                        opt => opt.MapFrom(src => src.PurchasingUser.Username)
                    )
                .ForMember(
                        dest => dest.TotalPurchasedItems,
                        opt => opt.MapFrom(src => src.Purchases.Count())
                    )
                .ForMember(
                        dest => dest.TotalPurchasePrice,
                        opt => opt.MapFrom(src => src.Purchases.Sum(p => p.PurchasePrice))
                    );

            CreateMap<PurchaseDto, PurchaseEntity>();
            CreateMap<PurchaseEntity, PurchaseDto>()
                .ForMember(
                    dest => dest.AssetName,
                    opt => opt.MapFrom(src => src.Asset.Name)
                );

            CreateMap<ReviewDto, ReviewEntity>();
            CreateMap<ReviewEntity, ReviewDto>()
                .ForMember(
                    dest => dest.AuthorName,
                    opt => opt.MapFrom(src => src.Author.Username)
                );
        }
    }
}
