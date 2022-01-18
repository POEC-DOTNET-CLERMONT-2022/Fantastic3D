using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Persistence.Entities
{
    internal static class Utilities
    {
        /// <summary>
        /// Returns the hashed password and outs the salt.
        /// </summary>
        public static string PasswordHash(string password, out string hashsalt)
        {
            // Todo : créer la méthode.
            hashsalt = "";
            return password;
        }

        /// <summary>
        /// Returns the password hashed with a given salt.
        /// </summary>
        public static string PasswordHash(string password, string hashsalt)
        {
            return password;
        }
    }
}
