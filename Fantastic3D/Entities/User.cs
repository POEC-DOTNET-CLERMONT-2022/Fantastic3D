using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    [DataContract]
    public enum UserRole {[DataMember] Admin = 'A', [DataMember] Premium = 'P', [DataMember] Basic = 'B'};


    [DataContract, Table("users")]
    public class User : IPersistable
    {
        [Key, DataMember, Column("id")]
        public Guid Id { get; set; }
        [DataMember][Required, StringLength(20)]
        public string Username { get; set; }
        [DataMember][StringLength(100)]
        public string FirstName { get; set; }
        [DataMember][StringLength(100)]
        public string LastName { get; set; }
        [DataMember][Required, StringLength(160), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataMember][Required, StringLength(160), DataType(DataType.Password)]
        public string Password { get; set; }
        [DataMember][Required, StringLength(64)]   // Note : un salt de 64 caractères nous permet d'aller jusqu'à l'algo SHA-256.
        public string HashSalt { get; private set; }
        [DataMember][Required, StringLength(200)]
        public string BillingAddress { get; set; }
        [DataMember]
        [Required, StringLength(200)]
        public UserRole Role { get; set; }

        public User() {}

        public User(Guid id, string username, string firstName, string lastName, string email, string password, string billingAdress, UserRole role)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = Utilities.PasswordHash(password, out string genereatedHashSalt);
            HashSalt = genereatedHashSalt;
            BillingAddress = billingAdress;
            Role = role;
        }
        
        public void SetNewPassword(string plainPassword)
        {
            Password = Utilities.PasswordHash(plainPassword, out string newHashSalt);
            HashSalt = newHashSalt;
        }

        public bool MatchPassword(string plainPassword)
        {
            return (Password == Utilities.PasswordHash(plainPassword, HashSalt));
        }

        public override string ToString()
        {
            return $"Email : {Email}, Pass : {Password}, BillingAdresse : {BillingAddress}, Role : {Role})";
        }
    }
}