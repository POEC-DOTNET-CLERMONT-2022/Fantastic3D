using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Define an order, the order date, the buyer and the list of his purchase
    /// </summary>
    
    public class Order : ObservableModel, IManageable
    {

        public int Id { get; set; }

        public DateTime Date { get;  set; }

        public List<Purchase> PurchaseList { get;  set; }

        public int PurchasingUserId { get;  set; }


        public override string ToString()
        {
            return $"Date : {Date}, Acheteur :{PurchasingUserId}";        }
    }
}
