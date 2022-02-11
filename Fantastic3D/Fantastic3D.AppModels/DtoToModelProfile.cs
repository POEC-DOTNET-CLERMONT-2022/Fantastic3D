using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fantastic3D.Dto;

namespace Fantastic3D.AppModels
{
    public class DtoToModelProfile : Profile 
    {
        public DtoToModelProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<TagTypeDto, TagType>().ReverseMap();
            CreateMap<TagDto, Tag>().ReverseMap();
            CreateMap<AssetDto, Asset>();
            CreateMap<Asset, AssetDto>()
                .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.Creator.Id));
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<PurchaseDto, Purchase>().ReverseMap();
            CreateMap<ReviewDto, Review>().ReverseMap();
        }
    }
}
