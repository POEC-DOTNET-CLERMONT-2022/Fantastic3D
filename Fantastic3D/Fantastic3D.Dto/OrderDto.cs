using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for an order
    /// </summary>
    [DataContract]
    internal class OrderDto
    {
        [DataMember]
        private Guid _orderId;
        [DataMember]
        private DateTime _date;
        [DataMember]
        private List<Guid> _purchaseList;
        [DataMember]
        private int _purchasingUser;
    }
}
