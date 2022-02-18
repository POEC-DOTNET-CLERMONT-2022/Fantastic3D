using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Define an purchase, the asset, the price and if the creator has been paid
    /// </summary>

    public class Purchase : ObservableModel, IManageable
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool IsPaidToCreator { get; set; }
        public float PurchasePrice { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }

        public Purchase()
        {

        }
    }
}
