using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for an order
    /// </summary>
    [DataContract]
    public class OrderDto : IManageable
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int PurchasesCount { get; set; }
        [DataMember]
        public int PurchasingUserId { get; set; }
        [DataMember]
        public int PurchasingUserName { get; set; }
        [DataMember]
        public int TotalPurchasedItems { get; private set; }
        [DataMember]
        public float TotalPurchasePrice { get; private set; }
    }
}
