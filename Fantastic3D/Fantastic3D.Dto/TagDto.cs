using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    [DataContract]
    public class TagDto
    {
        [DataMember]
        private string _name;
        [DataMember]
        private Guid _tagType;   // Tag Type ID

    }
}
