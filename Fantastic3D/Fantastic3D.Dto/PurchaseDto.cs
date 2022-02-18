using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for a purchase
    /// </summary>
    [DataContract]
    public class PurchaseDto : IManageable
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public bool IsPaidToCreator { get; set; }
        [DataMember]
        public float PurchasePrice { get; set; }
        [DataMember]
        public int AssetId { get; set; }
        [DataMember]
        public string AssetName { get; set; }

    }
}
