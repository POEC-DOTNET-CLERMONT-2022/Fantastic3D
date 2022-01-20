using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Define an purchase, the asset, the price and if the creator has been paid
    /// </summary>

    public class Purchase : ObservableModel, IManageable
    {
        public int Id { get; set; }
        private Guid _id;
        
        private bool _isPaidToCreator;
        
        private float _purchasePrice;
        
        private Asset _asset;

        public Purchase(Guid id, bool isPaidToCreator, float purchasePrice, Asset asset)
        {
            _id = id;
            _isPaidToCreator = isPaidToCreator;
            _purchasePrice = purchasePrice;
            _asset = asset;
        }

        public override string ToString()
        {
            return $"Payé au créateur : {_isPaidToCreator}, Prix : {_purchasePrice}, Asset : {_asset}";
        }
    }
}
