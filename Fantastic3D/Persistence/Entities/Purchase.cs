using System.Runtime.Serialization;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define an purchase, the asset, the price and if the creator has been paid
    /// </summary>
    [DataContract]
    public class Purchase : IPersistable
    {
        [DataMember]
        private Guid _id;
        [DataMember]
        private bool _isPaidToCreator;
        [DataMember]
        private float _purchasePrice;
        [DataMember]
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
