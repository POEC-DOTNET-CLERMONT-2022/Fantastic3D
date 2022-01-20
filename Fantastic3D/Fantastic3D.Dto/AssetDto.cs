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
        public static string[] AvailableStatus = new string[] { "Unpublished", "Published", "Rejected", "Removed" };
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; } = string.Empty;
        [DataMember]
        public string Description { get; set; } = string.Empty;
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public string FilePath { get; set; } = string.Empty;
        [DataMember]
        public string PicturePath { get; set; } = string.Empty;
        [DataMember]
        public List<Guid> Tags { get; set; } = new();    // List of Tags Ids
        [DataMember]
        public int Creator { get; set; }        // User ID
        [DataMember]
        /// <summary>
        /// Status ID. Use the AvailableStatus Array to match Status and IDs
        /// </summary>
        public int Status { get; set; }

    }
}
