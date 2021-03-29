using System;
using System.Collections.Generic;
using System.Text;

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

            while(!CorrectPassword(enteredUsername, enteredPassword))
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

            Controller.ShowMainMenu();
        }

        private bool DoesUsernameExist(string username)
        {
            foreach (User u in Controller.DataStore.GetUsers())
                if (u.Username.Equals(username))
                    return true;

            return false;
        }


        private bool CorrectPassword(string username, string password)
        {
            User user = Controller.DataStore.GetUserByUsername(username);
            if(user != null)
                return user.VerifyPassword(password);

            return false;
        }




    }
}
