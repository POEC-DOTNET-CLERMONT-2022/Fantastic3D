namespace Fantastic3D.Models
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    public enum UserRole { admin, premium, basic };
    public class User
    {
        private Guid _id;
        private string _email;
        private string _password;
        private string _billingAdress;
        private UserRole _role;

        public User(Guid id, string email, string password, string billingAdresse, UserRole role)
        {
            _id = id;
            _email = email;
            _password = password;
            _billingAdress = billingAdresse;
            _role = role;
        }

        public override string ToString()
        {
            return $"Email : {_email}, Pass : {_password}, BillingAdresse : {_billingAdress}, Role : {_role})";
        }
    }
}