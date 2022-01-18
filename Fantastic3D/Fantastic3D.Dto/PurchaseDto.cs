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
        public Guid Id { get; set; }
        [DataMember]
        public bool IsPaidToCreator { get; set; }
        [DataMember]
        public float PurchasePrice { get; set; }
        [DataMember]
        public Guid Asset { get; set; }        // Asset ID

    }
}
