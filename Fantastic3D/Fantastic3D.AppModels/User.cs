using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    [DataContract]
    public enum UserRole {[DataMember] Admin = 'A', [DataMember] Premium = 'P', [DataMember] Basic = 'B'};
    public class User : ObservableModel, IManageable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string HashSalt { get; private set; }
        public string BillingAddress { get; set; }
        public UserRole Role { get; set; }

        public User() {}

        public User(int id, string username, string firstName, string lastName, string email, string password, string hashSalt, string billingAddress, UserRole role)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            HashSalt = hashSalt;
            BillingAddress = billingAddress;
            Role = role;
        }

        public override string ToString()
        {
            return $"Email : {Email}, Pass : {Password}, BillingAdresse : {BillingAddress}, Role : {Role})";
        }
    }
}