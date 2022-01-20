using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    [DataContract]
    public class TagDto : IWithId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; } = string.Empty;
        [DataMember]
        public Guid TagType { get; set; }   // Tag Type ID
    }
}
