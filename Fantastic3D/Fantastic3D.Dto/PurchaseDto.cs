using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for a purchase
    /// </summary>
    [DataContract]
    public class PurchaseDto
    {
        [DataMember]
        private Guid _id;
        [DataMember]
        private bool _isPaidToCreator;
        [DataMember]
        private float _purchasePrice;
        [DataMember]
        private Guid _asset;        // Asset ID

    }
}
