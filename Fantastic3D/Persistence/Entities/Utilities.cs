using System;

using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Fantastic3D.Persistence.Entities
{
    
    internal static class Utilities
    {
        /// <summary>
        /// Returns the hashed password and outs the salt.
        /// </summary>
        public static string PasswordHash(string password, out string hashsalt)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(salt);
            }
            hashsalt = Convert.ToBase64String(salt);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }

        /// <summary>
        /// Returns the password hashed with a given salt.
        /// </summary>
        public static string PasswordHash(string password, string hashsalt)
        {
            byte[] salt = Convert.FromBase64String(hashsalt);
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }
    }
}
