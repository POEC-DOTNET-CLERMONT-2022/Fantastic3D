using System.Runtime.Serialization;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    public enum UserRole { admin, premium, basic };

    [DataContract]
    public class User : IPersistable
    {
        [DataMember]
        private Guid _id;
        [DataMember]
        private string _email;
        [DataMember]
        private string _password;
        [DataMember]
        private string _billingAdress;
        [DataMember]
        private UserRole _role;

        public User(Guid id, string email, string password, string billingAdresse, UserRole role)
        {
            _id = id;
            _email = email;
            // TODO : hash du password
            _password = password;
            _billingAdress = billingAdresse;
            _role = role;
        }

        // TODO : fonction qui récupère un password envoyé en paramètre, le hash et le compare au password stocké.

        public override string ToString()
        {
            return $"Email : {_email}, Pass : {_password}, BillingAdresse : {_billingAdress}, Role : {_role})";
        }
    }
}