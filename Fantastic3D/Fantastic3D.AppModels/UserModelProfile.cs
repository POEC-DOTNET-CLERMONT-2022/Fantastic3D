using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fantastic3D.Dto;

namespace Fantastic3D.AppModels
{
    public class UserModelProfile : Profile 
    {
        public UserModelProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<TagDto, Tag>().ReverseMap();

            CreateMap<TagTypeDto, TagType>().ReverseMap();

            CreateMap<AssetDto, Asset>().ReverseMap();

            CreateMap<OrderDto, Order>().ReverseMap();

            CreateMap<PurchaseDto, Purchase>().ReverseMap();

            CreateMap<ReviewDto, Review>().ReverseMap();


        }
    }
}
