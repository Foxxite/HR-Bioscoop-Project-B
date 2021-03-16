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
        private string Address;1
        private int Age;


        private byte[] CreateSalt(string enterPassword)
        { 
            var buffer = Encoding.UTF8.GetBytes(Age + Name + enterPassword + Address + Username);
            for(int i = 0; i < buffer.Length; i++)
            {
                buffer[i] += 0b1011001;


            }
            return buffer;
        }


        public bool VerifyPassword(string password)
        {
            


            return true;
        }


       

    }
}