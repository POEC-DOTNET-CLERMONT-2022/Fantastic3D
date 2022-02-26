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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PurchasingUserId { get; set; }
        public virtual UserEntity PurchasingUser { get; set; }
        public virtual ICollection<PurchaseEntity> Purchases { get; set; }
        public bool Active { get; set; } = true;

        public OrderEntity() {}

        public OrderEntity(DateTime date, int purchasingUserId)
        {
            Date = date;
            PurchasingUserId = purchasingUserId;
        }

        public override string ToString()
        {
            return $"Date : {Date}, Acheteur :{PurchasingUser}";
        }
    }
}
