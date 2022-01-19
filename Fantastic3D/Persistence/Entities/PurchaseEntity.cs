using System.ComponentModel.DataAnnotations;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define an purchase, the asset, the price and if the creator has been paid
    /// </summary>
    public class PurchaseEntity : IPersistable
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsPaidToCreator { get; set; }
        public float PurchasePrice { get; set; }
        public AssetEntity Asset { get; set; }

        public PurchaseEntity(Guid id, bool isPaidToCreator, float purchasePrice, AssetEntity asset)
        {
            Id = id;
            IsPaidToCreator = isPaidToCreator;
            PurchasePrice = purchasePrice;
            Asset = asset;
        }

        public override string ToString()
        {
            return $"Payé au créateur : {IsPaidToCreator}, Prix : {PurchasePrice}, Asset : {Asset}";
        }
    }
}
