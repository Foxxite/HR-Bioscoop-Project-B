using Konscious.Security.Cryptography;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Cinema_App
{
    /// <summary>
    /// Class representing an user.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    class User
    {
        [JsonProperty]
        private Guid GUID;

        [JsonProperty]
        public string Username { get; set; }
        [JsonProperty]
        public string Password { get; set; }

        [JsonProperty]
        public int Permlevel { get; }

        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string EmailAddress { get; set; }
        [JsonProperty]
        public int Age { get; set; }

        public User(string username, string password, string name, string emailaddress = "", int age = 0)
        {
            GUID = Guid.NewGuid();
            
            Username = username;
            Password = password;
            Name = name;
            EmailAddress = emailaddress;
            Age = age;

            Permlevel = 0;
        }

        [JsonConstructor]
        public User(Guid guid, string username, string password, string name, string emailaddress, int age, int permlevel)
        {
            GUID = guid;

            Username = username;
            Password = password;
            Name = name;
            EmailAddress = emailaddress;
            Age = age;

            Permlevel = permlevel;
        }

        /// <summary>
        /// Creates salt based on user info.
        /// </summary>
        /// <param name="enterPassword">String password.</param>
        /// <returns>Salt based on user info.</returns>
        private byte[] CreateSalt(string enterPassword)
        {
            return PasswordManager.CreateSalt(GUID + enterPassword);
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

        /// <summary>
        /// Changes the username.
        /// </summary>
        /// <param name="newUserName"></param>
        public void ChangeUsername(string newUserName)
        {
            Username = newUserName;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="newPassword"></param>
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
            ConvertPasswordToHash();
        }

        /// <summary>
        /// Changes the name.
        /// </summary>
        /// <param name="newName"></param>
        public void ChangeName(string newName)
        {
            Name = newName;
        }

        /// <summary>
        /// Changes the age.
        /// </summary>
        /// <param name="newAge"></param>
        public void ChangeAge(int newAge)
        {
            Age = newAge;
        }

        /// <summary>
        /// Changes the email-address.
        /// </summary>
        /// <param name="newEmailAddress"></param>
        public void ChangeEmailAddress(string newEmailAddress)
        {
            EmailAddress = newEmailAddress;
        }

    }
}