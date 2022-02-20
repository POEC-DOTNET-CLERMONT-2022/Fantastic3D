﻿using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Define an order, the order date, the buyer and the list of his purchase
    /// </summary>
    
    public class Order : ObservableModel, IManageable
    {

        public int Id { get; set; }
        public DateTime Date { get; private set; }

        public int PurchasesCount { get; private set; }
        public int PurchasingUserId { get; private set; }
        public string PurchasingUserName { get; private set; }
        public int TotalPurchasedItems { get; private set; }
        public float TotalPurchasePrice { get; private set; }


        public override string ToString()
        {
            return $"Date : {Date}, Acheteur :{PurchasingUserId}";        }
    }
}
