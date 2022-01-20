using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fantastic3D.DataManager;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define an order, the order date, the buyer and the list of his purchase
    /// </summary>
    [Table("Order")]
    public class OrderEntity : IManageable
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int PurchasingUserId { get; set; }
        public virtual UserEntity PurchasingUser { get; private set; }
        public virtual ICollection<PurchaseEntity> PurchaseList { get; private set; }

        public OrderEntity() {}

        public override string ToString()
        {
            return $"Date : {Date}, Acheteur :{PurchasingUser}";
        }
    }
}
