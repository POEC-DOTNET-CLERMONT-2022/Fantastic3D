using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    [DataContract]
    public class TagDto : IManageable
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; } = string.Empty;
        [DataMember]
        public int TagTypeId { get; set; }   // Tag Type ID
    }
}
