using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Define an order, the order date, the buyer and the list of his purchase
    /// </summary>
    
    internal class Order : ObservableModel, IManageable
    {

        public int Id { get; set; }

        public DateTime Date { get; private set; }

        public List<Purchase> PurchaseList { get; private set; }

        public int PurchasingUserId { get; private set; }

        public Order(int id, DateTime date, List<Purchase> purchaseList, int purchasingUserId)
        {
            Id = id;
            Date = date;
            PurchaseList = purchaseList;
            PurchasingUserId = purchasingUserId;
        }

        public override string ToString()
        {
            return $"Date : {Date}, Acheteur :{PurchasingUserId}";        }
    }
}
