using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    static class PasswordManager
    {
        static public byte[] CreateSalt(string salt = "")
        {
            var buffer = Encoding.UTF8.GetBytes(salt);
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] += 0b1011001;
            }
            return buffer;
        }

        static public string HashPassword(string enteredPassword, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(enteredPassword));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return Convert.ToBase64String(argon2.GetBytes(16));
        }

        static public bool VerifyPassword(string enteredPassword, string hash, byte[] salt)
        {
            var newHash = HashPassword(enteredPassword, salt);
            return hash.Equals(newHash);
        }
    }
}
