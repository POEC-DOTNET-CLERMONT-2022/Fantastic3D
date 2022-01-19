using System.ComponentModel.DataAnnotations;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define an order, the order date, the buyer and the list of his purchase
    /// </summary>
    internal class OrderEntity : IPersistable
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; }
        public List<PurchaseEntity> PurchaseList { get; set; }
        public UserEntity PurchasingUser { get; set; }

        public OrderEntity(Guid orderId, DateTime date, List<PurchaseEntity> purchaseList, UserEntity purchasingUser)
        {
            OrderId = orderId;
            Date = date;
            PurchaseList = purchaseList;
            PurchasingUser = purchasingUser;
        }

        public override string ToString()
        {
            return $"Date : {Date}, Acheteur :{PurchasingUser}";
        }
    }
}
