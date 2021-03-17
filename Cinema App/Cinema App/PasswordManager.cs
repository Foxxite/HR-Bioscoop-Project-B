using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    /// <summary>
    /// Handles the creation and verification of passwords using the Argon2id-algorithm. 
    /// </summary>
    static class PasswordManager
    {
        /// <summary>
        /// Creates a salt based on the inputted string.
        /// </summary>
        /// <param name="salt">String to use as salt.</param>
        /// <returns>Salt represented as byte-array.</returns>
        static public byte[] CreateSalt(string salt = "")
        {
            var buffer = Encoding.UTF8.GetBytes(salt);
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] += 0b1011001;
            }
            return buffer;
        }

        /// <summary>
        /// Creates a password hash based on the inputted string and salt.
        /// </summary>
        /// <param name="enteredPassword">Password string.</param>
        /// <param name="salt">Salt represented as byte-array.</param>
        /// <returns>Argon2 hash encoded in Base64.</returns>
        static public string HashPassword(string enteredPassword, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(enteredPassword));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return Convert.ToBase64String(argon2.GetBytes(16));
        }

        /// <summary>
        /// Verifies password against a Base64 encoded Argon2 hash.
        /// </summary>
        /// <param name="enteredPassword">Password to verify.</param>
        /// <param name="hash">Argon2 hash.</param>
        /// <param name="salt">Salt.</param>
        /// <returns>True if match, else False.</returns>
        static public bool VerifyPassword(string enteredPassword, string hash, byte[] salt)
        {
            var newHash = HashPassword(enteredPassword, salt);
            return hash.Equals(newHash);
        }
    }
}
