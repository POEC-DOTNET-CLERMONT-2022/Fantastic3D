using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    public enum UserRole {Admin = 9, Premium = 5, Basic = 0 };
    public class User : ObservableModel, IManageable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BillingAddress { get; set; }
        public UserRole Role { get; set; }
        public static string[] Roles => Enum.GetNames<UserRole>();
        public bool Active { get; set; }
        public User() {}

        public User(int id, string username, string firstName, string lastName, string email, string password, string billingAddress, UserRole role)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BillingAddress = billingAddress;
            Role = role;
        }

        public override string ToString()
        {
            return $"Email : {Email}, Pass : {Password}, BillingAdresse : {BillingAddress}, Role : {Role})";
        }
    }
}