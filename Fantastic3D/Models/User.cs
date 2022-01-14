using System.Runtime.Serialization;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    public enum UserRole { Admin, Premium, Basic };

    [DataContract]
    public class User : IPersistable
    {
        [DataMember]
        private Guid _id;
        [DataMember]
        private string _username;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _email;
        [DataMember]
        private string _password;
        [DataMember]
        private string _hashSalt;
        [DataMember]
        private string _billingAdress;
        [DataMember]
        private UserRole _role;

        public User(Guid id, string username, string firstName, string lastName, string email, string password, string hashSalt, string billingAdress, UserRole role)
        {
            _id = id;
            _username = username;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = Utilities.PasswordHash(password, out _hashSalt);
            _billingAdress = billingAdress;
            _role = role;
        }
        
        public void SetNewPassword(string plainPassword)
        {
            _password = Utilities.PasswordHash(password, out _hashSalt);
        }

        public bool MatchPassword(string plainPassword)
        {
            return (_password == Utilities.PasswordHash(plainPassword, _hashSalt));
        }

        public override string ToString()
        {
            return $"Email : {_email}, Pass : {_password}, BillingAdresse : {_billingAdress}, Role : {_role})";
        }
    }
}