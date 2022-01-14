using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    public enum UserRole { Admin, Premium, Basic };


    [DataContract, Table("users")]
    public class User : IPersistable
    {
        [Key, DataMember, Column("id")]
        public Guid Id { get; set; }
        [DataMember, Column("username")]
        private string _username;
        [DataMember, Column("first_name")]
        private string _firstName;
        [DataMember, Column("last_name")]
        private string _lastName;
        [DataMember, Column("email")]
        private string _email;
        [DataMember, Column("password")]
        private string _password;
        [DataMember, Column("hash_salt")]
        private string _hashSalt;
        [DataMember, Column("billing_address")]
        private string _billingAddress;
        [DataMember, Column("role")]
        private UserRole _role;

        public User() {}

        public User(Guid id, string username, string firstName, string lastName, string email, string password, string billingAdress, UserRole role)
        {
            Id = id;
            _username = username;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = Utilities.PasswordHash(password, out _hashSalt);
            _billingAddress = billingAdress;
            _role = role;
        }
        
        public void SetNewPassword(string plainPassword)
        {
            _password = Utilities.PasswordHash(plainPassword, out _hashSalt);
        }

        public bool MatchPassword(string plainPassword)
        {
            return (_password == Utilities.PasswordHash(plainPassword, _hashSalt));
        }

        public override string ToString()
        {
            return $"Email : {_email}, Pass : {_password}, BillingAdresse : {_billingAddress}, Role : {_role})";
        }
    }
}