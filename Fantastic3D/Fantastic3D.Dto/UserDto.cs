using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string HashSalt { get; private set; }
        [DataMember]
        public string BillingAddress { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}