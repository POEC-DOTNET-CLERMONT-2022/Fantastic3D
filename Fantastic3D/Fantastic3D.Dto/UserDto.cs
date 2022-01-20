using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    [DataContract]
    public class UserDto : IWithId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; } = string.Empty;
        [DataMember]
        public string FirstName { get; set; } = string.Empty;
        [DataMember]
        public string LastName { get; set; } = string.Empty;
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        public string Password { get; set; } = string.Empty;
        [DataMember]
        public string HashSalt { get; private set; } = string.Empty;
        [DataMember]
        public string BillingAddress { get; set; } = string.Empty;
        [DataMember]
        public string Role { get; set; } = string.Empty;
    }
}