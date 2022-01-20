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
        public string Name { get; set; } = string.Empty;
        [DataMember]
        public Guid TagType { get; set; }   // Tag Type ID

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
