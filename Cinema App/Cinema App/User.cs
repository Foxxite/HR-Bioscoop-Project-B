using Konscious.Security.Cryptography;
using System;
using System.Text;

namespace Cinema_App
{
    /// <summary>
    /// Class representing a user.
    /// </summary>
    
    class User
    {
        private Guid GUID;

        private string Username;
        private string Password;

        private int Permlevel;

        private string Name;
        private string Address;
        private int Age;

        /// <summary>
        /// Creates salt based on user info.
        /// </summary>
        /// <param name="enterPassword">String password.</param>
        /// <returns>Salt based on user info.</returns>
        private byte[] CreateSalt(string enterPassword)
        {
            return PasswordManager.CreateSalt(Age + Name + enterPassword + Address + Username);
        }

        /// <summary>
        /// Creates Argon2-hash of password.
        /// </summary>
        /// <param name="enteredPassword">String password.</param>
        /// <returns>Hash.</returns>
        public string HashPassword (string enteredPassword)
        {
            return PasswordManager.HashPassword(enteredPassword, CreateSalt(enteredPassword));
        }

        /// <summary>
        /// Verifies password given compared to users password.
        /// </summary>
        /// <param name="enteredPassword">Password to verify.</param>
        /// <returns>True if match, else False.</returns>
        public bool VerifyPassword(string enteredPassword)
        {
            return PasswordManager.VerifyPassword(enteredPassword, Password, CreateSalt(enteredPassword));
        }





    }
}