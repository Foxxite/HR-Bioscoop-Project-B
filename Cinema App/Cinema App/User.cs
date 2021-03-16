using Konscious.Security.Cryptography;
using System;
using System.Text;

namespace Cinema_App
{
    class User
    {
        private Guid GUID;

        private string Username;
        private string Password;

        private int Permlevel;

        private string Name;
        private string Address;
        private int Age;

        private byte[] CreateSalt(string enterPassword)
        {
            return PasswordManager.CreateSalt(Age + Name + enterPassword + Address + Username);
        }

        public string HashPassword (string enteredPassword)
        {
            return PasswordManager.HashPassword(enteredPassword, CreateSalt(enteredPassword));
        }

        public bool VerifyPassword(string enteredPassword)
        {
             return PasswordManager.VerifyPassword(enteredPassword, Password, CreateSalt(enteredPassword))
        }





    }
}