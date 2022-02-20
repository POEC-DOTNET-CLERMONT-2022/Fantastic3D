using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fantastic3D.DataManager;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define an purchase, the asset, the price and if the creator has been paid
    /// </summary>
    [Table("Purchase")]
    public class PurchaseEntity : IManageable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool IsPaidToCreator { get; set; }
        public float PurchasePrice { get; set; }
        public int AssetId { get; set; }
        public virtual AssetEntity Asset { get; private set; }
        public virtual OrderEntity Order { get; private set; }

        public PurchaseEntity() {}

        public PurchaseEntity(int orderId, bool isPaidToCreator, float purchasePrice, int assetId)
        {
            OrderId = orderId;
            IsPaidToCreator = isPaidToCreator;
            PurchasePrice = purchasePrice;
            AssetId = assetId;
        }
    }
}
