using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Fantastic3D.DataManager;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define an user, email, pass, billing adress and his role 
    /// </summary>
    public enum UserRole {Admin, Premium, Basic};


    [Table("User")]
    public class UserEntity : IManageable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Username { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [Required, StringLength(160), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(160), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, StringLength(64)]   // Note : un salt de 64 caractères nous permet d'aller jusqu'à l'algo SHA-256.
        public string HashSalt { get; private set; }
        [Required, StringLength(200)]
        public string BillingAddress { get; set; }
        [Required, StringLength(200)]
        public UserRole Role { get; set; }

        public virtual ICollection<AssetEntity> CreatedAssets { get; private set; }
        public virtual ICollection<ReviewEntity> Reviews { get; private set; }

        public UserEntity() {}

        public UserEntity(string username, string firstName, string lastName, string email, string password, string billingAdress, UserRole role)
        {
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
    }
}