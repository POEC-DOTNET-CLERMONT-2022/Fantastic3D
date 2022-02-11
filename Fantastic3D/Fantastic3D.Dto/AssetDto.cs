using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for an asset
    /// </summary>
    [DataContract]
    public class AssetDto : IManageable
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public string FilePath { get; set; }
        [DataMember]
        public string PicturePath { get; set; }
        [DataMember]
        public int CreatorId { get; set; }
        [DataMember]
        /// <summary>
        /// Status ID. Use the AvailableStatus Array to match Status and IDs
        /// </summary>
        public string Status { get; set; }

    }
}
