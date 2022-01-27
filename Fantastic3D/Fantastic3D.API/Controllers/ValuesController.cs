using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fantastic3D.API.Controllers
{
    public class AssetController : GenericController<AssetDto, AssetEntity>
    {
        public AssetController(IDataManager<AssetDto, AssetEntity> dataManager) : base(dataManager)
        {
        }
    }
    public class ReviewController : GenericController<ReviewDto, ReviewEntity>
    {
        public ReviewController(IDataManager<ReviewDto, ReviewEntity> dataManager) : base(dataManager)
        {
        }
    }
    public class OrderController : GenericController<OrderDto, OrderEntity>
    {
        public OrderController(IDataManager<OrderDto, OrderEntity> dataManager) : base(dataManager)
        {
        }
    }
    public class TagController : GenericController<TagDto, TagEntity>
    {
        public TagController(IDataManager<TagDto, TagEntity> dataManager) : base(dataManager)
        {
        }
    }
    public class TagTypeController : GenericController<TagTypeDto, TagTypeEntity>
    {
        public TagTypeController(IDataManager<TagTypeDto, TagTypeEntity> dataManager) : base(dataManager)
        {
        }
    }
    public class PurchaseController : GenericController<PurchaseDto, PurchaseEntity>
    {
        public PurchaseController(IDataManager<PurchaseDto, PurchaseEntity> dataManager) : base(dataManager)
        {
        }
    }
}
