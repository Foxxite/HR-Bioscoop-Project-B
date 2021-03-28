using Konscious.Security.Cryptography;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Cinema_App
{
    /// <summary>
    /// Class representing a user.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    class User
    {
        [JsonProperty]
        private Guid GUID;

        [JsonProperty]
        private string Username;
        [JsonProperty]
        private string Password;

        [JsonProperty]
        private int Permlevel;

        [JsonProperty]
        private string Name;
        [JsonProperty]
        private string Address;
        [JsonProperty]
        private int Age;

        public User(string username, string password, string name, string address = "", int age = 0)
        {
            GUID = Guid.NewGuid();

            Username = username;
            Password = password;
            Name = name;
            Address = address;
            Age = age;

            Permlevel = 0;
        }

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
        /// Converts the stored password to a Argon2 hash
        /// </summary>
        public void ConvertPasswordToHash()
        {
            Password = HashPassword(Password);
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