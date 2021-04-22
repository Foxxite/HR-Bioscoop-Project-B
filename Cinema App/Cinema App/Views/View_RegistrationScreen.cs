using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Cinema_App
{
    class View_RegistrationScreen : View
    {
        public View_RegistrationScreen(Controller controller, string title, string subTitle = "", int permLevel = 0)
            : base(controller, title, subTitle, permLevel)
        {
            return;
        }
        
        public override void Render()
        {
            DrawTitleBar();

            Console.WriteLine("  Enter your username:");
            string enteredUsername = Console.ReadLine().Trim();

            while(String.IsNullOrEmpty(enteredUsername))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Username can not be empty!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }
            
            while (DoesUsernameExist(enteredUsername))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Username already in use!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }

            Console.WriteLine();

            Console.WriteLine("  Enter your password:");
            string enteredPassword = Console.ReadLine().Trim();
            
            while (String.IsNullOrEmpty(enteredPassword))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Password can not be empty!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredPassword = Console.ReadLine().Trim();
            }

            Console.WriteLine();

            Console.WriteLine("  Enter your name:");
            string enteredName = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Name can not be empty!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredName = Console.ReadLine().Trim();
            }

            Console.WriteLine();

            Console.WriteLine("  Enter your age:");

            bool correctAge = false;
            int enteredAge = 0;
            while (!correctAge)
            {
                try
                {
                    enteredAge = Int32.Parse(Console.ReadLine());
                    correctAge = true;
                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"  Please enter a valid number!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine();

            Console.WriteLine("  Enter your emial-address:");
            string enteredEmailAddress = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredEmailAddress) && !IsValidEmail(enteredEmailAddress))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Enter a valid emailaddress!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredEmailAddress = Console.ReadLine().Trim();
            }

            Controller.ClearScreen();

            DrawTitleBar();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Please wait while we are creating your account, this might take a few seconds...");

            User newUser = new User(enteredUsername, enteredPassword, enteredName, enteredEmailAddress, enteredAge);
            newUser.ConvertPasswordToHash();

            Controller.DataStore.AddUser(newUser);

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine("  Account has been created successfully!");
            Console.WriteLine("  You will be asked to log in in a few moments...");
            
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(3000);

            Controller.SwitchView(new View_LoginScreen(Controller, "Login Screen"));
        }

        /// <summary>
        /// Checks if username is already in database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool DoesUsernameExist(string username)
        {
            foreach(User u in Controller.DataStore.GetUsers())
                if (u.Username.Equals(username))
                    return true;

            return false;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
