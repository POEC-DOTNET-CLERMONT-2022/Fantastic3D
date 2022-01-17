using System.Runtime.Serialization;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define an order, the order date, the buyer and the list of his purchase
    /// </summary>
    [DataContract]
    internal class Order : IPersistable
    {
        [DataMember]
        private Guid _orderId;
        [DataMember]
        private DateTime _date;
        [DataMember]
        private List<Purchase> _purchaseList;
        [DataMember]
        private User _purchasingUser;

        public Order(Guid orderId, DateTime date, List<Purchase> purchaseList, User purchasingUser)
        {
            _orderId = orderId;
            _date = date;
            _purchaseList = purchaseList;
            _purchasingUser = purchasingUser;
        }

        public override string ToString()
        {
            return $"Date : {_date}, Acheteur :{_purchasingUser}";
        }
    }
}
