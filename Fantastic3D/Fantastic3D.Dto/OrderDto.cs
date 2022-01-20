using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for an order
    /// </summary>
    [DataContract]
    public class OrderDto : IWithId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public List<Guid> PurchaseList { get; set; } = new();
        [DataMember]
        public int PurchasingUser { get; set; }
    }
}
