using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Cinema_App
{
    class LoginScreen : View
    {
        public LoginScreen(Controller controller, string title, string subTitle = "", int permLevel = 0)
            : base(controller, title, subTitle, permLevel)
        {
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            Console.WriteLine("  Enter your username here:");
            string enteredUsername = Console.ReadLine();
            
            while(!DoesUsernameExist(enteredUsername))
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  This user does not exist.");
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine("  Enter your password here:");
            string enteredPassword = Console.ReadLine();

            int wrongPasswordCounter = 0;

            while(String.IsNullOrEmpty(enteredPassword) || !CorrectPassword(enteredUsername, enteredPassword))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Wrong password, please try again.");
                Console.ForegroundColor = ConsoleColor.White;

                wrongPasswordCounter++;
                if(wrongPasswordCounter >= 3)
                {
                    Controller.ClearScreen();
                }

                enteredPassword = Console.ReadLine();
            }

            Controller.CurrentUser = Controller.DataStore.GetUserByUsername(enteredUsername);

            Controller.ClearScreen();

            DrawTitleBar();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine($"  Welcome {Controller.CurrentUser.Name},");
            Console.WriteLine("  You will be redirected to the main menu in in a few moments...");

            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(3000);

            Controller.ShowMainMenu();
        }
        /// <summary>
        /// Method to check if username already exists in Json.
        /// </summary>
        /// <param name="username">The username inputted by user.</param>
        /// <returns></returns>
        private bool DoesUsernameExist(string username)
        {
            foreach (User u in Controller.DataStore.GetUsers())
                if (u.Username.Equals(username))
                    return true;

            return false;
        }

        /// <summary>
        /// Method to check if password given is correct.
        /// </summary>
        /// <param name="username">Username given by user.</param>
        /// <param name="password">Password given by user.</param>
        /// <returns></returns>
        private bool CorrectPassword(string username, string password)
        {
            User user = Controller.DataStore.GetUserByUsername(username);
            if(user != null)
                return user.VerifyPassword(password);

            return false;
        }




    }
}
