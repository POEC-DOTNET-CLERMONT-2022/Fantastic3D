using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.Persistence.Entities
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserEntity, UserDto>();

            CreateMap<TagEntity, TagDto>();

            CreateMap<TagTypeEntity, TagTypeDto>();

            CreateMap<AssetEntity, AssetDto>();

            CreateMap<OrderEntity, OrderDto>();

            CreateMap<PurchaseEntity, PurchaseDto>();

            CreateMap<ReviewEntity, ReviewDto>();


        }
    }
}
