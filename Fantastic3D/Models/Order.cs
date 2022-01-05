﻿

namespace Fantastic3D.Models
{
    /// <summary>
    /// Define an order, the order date, the buyer and the list of his purchase
    /// </summary>
    internal class Order
    {
        private Guid _orderId;
        private DateTime _date;
        private List<Purchase> _purchaseList;
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