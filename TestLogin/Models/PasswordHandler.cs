using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestLogin.Models
{
    public class PasswordHandler
    {
        byte[] salt;
        byte[] hash;
        byte[] hashedPassword;
        public PasswordHandler(string password)
        {
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            hash = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(20);

        }
        public string GetHashedPassword()
        {
            hashedPassword = new byte[36];
            Array.Copy(salt, 0, hashedPassword, 0, 16);
            Array.Copy(hash, 0, hashedPassword, 16, 20);
            string pass= Convert.ToBase64String(hashedPassword); 

            int le = pass.Length;
            return pass;
        }
        public PasswordHandler(string password, string hashedPasswordStored)
        {
            int length = hashedPasswordStored.Length;
            hashedPassword = Convert.FromBase64String(hashedPasswordStored);
            salt = new byte[16];
            Array.Copy(hashedPassword, 0, salt, 0, 16);
            hash = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(20);

        }
        public bool ValidatePassword()
        {
            for(int i = 0; i < 20; i++)
            {
                if (hash[i] != hashedPassword[i + 16]) return false;
            }
            return true;
        }
    }
}
