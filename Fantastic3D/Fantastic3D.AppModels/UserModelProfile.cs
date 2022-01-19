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
            CreateMap<UserDto, User>();

            CreateMap<TagDto, Tag>();

            CreateMap<TagTypeDto, TagType>();

            CreateMap<AssetDto, Asset>();

            CreateMap<OrderDto, Order>();

            CreateMap<PurchaseDto, Purchase>();

            CreateMap<ReviewDto, Review>();


        }
    }
}
