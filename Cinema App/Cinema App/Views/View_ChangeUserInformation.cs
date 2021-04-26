using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_ChangeUserInformation : View
    {
        Menu UserMenu;

        public View_ChangeUserInformation(Controller controller, string title, string subTitle = "", int permLevel = 0)
           : base(controller, title, subTitle, permLevel)
        {
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            UserMenu = new Menu(Controller, "Change User Information");

            UserMenu.AddMenuOption("Change username", new Action(ChangeUsername));
            UserMenu.AddMenuOption("Change password", new Action(ChangePassword));
            UserMenu.AddMenuOption("Change name", new Action(ChangeName));
            UserMenu.AddMenuOption("Change age", new Action(ChangeAge));
            UserMenu.AddMenuOption("Change email-address\n", new Action(ChangeEmailAddress));

            UserMenu.AddMenuOption("Return to Main Menu", new Action(Controller.ShowMainMenu));

            Controller.SwitchView(UserMenu);
        }

        void ChangeUsername()
        {
            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine("  Enter your username:");
            string enteredUsername = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredUsername))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Username can not be empty!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }

            while (Controller.DataStore.GetUserByUsername(enteredUsername) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Username already in use!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }

            user.ChangeUsername(enteredUsername);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine("Username has been changed successfully!");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();

            Controller.SwitchView(UserMenu);

        }
        void ChangePassword()
        {
            Controller.ClearScreen();

            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine("  Enter new password:");

            string enteredPassword = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredPassword))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Password can not be empty!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredPassword = Console.ReadLine().Trim();
            }

            user.ChangePassword(enteredPassword);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine("Password has been changed successfully!");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();

            Controller.SwitchView(UserMenu);
        }
        void ChangeName()
        {
            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine("  Enter your name:");
            string enteredName = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Name can not be empty!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredName = Console.ReadLine().Trim();
            }

            user.ChangeName(enteredName);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine("Name has been changed successfully!");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();

            Controller.SwitchView(UserMenu);
        }
        void ChangeAge()
        {

            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

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
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"  Please enter a valid number!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            user.ChangeAge(enteredAge);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine("Age has been changed successfully!");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();

            Controller.SwitchView(UserMenu);
        }
        void ChangeEmailAddress()
        {
            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine("  Enter your email-address:");
            string enteredEmailAddress = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredEmailAddress) && !IsValidEmail(enteredEmailAddress))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Enter a valid emailaddress!");
                Console.ForegroundColor = ConsoleColor.White;

                enteredEmailAddress = Console.ReadLine().Trim();
            }

            user.ChangeEmailAddress(enteredEmailAddress);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine("Email-address has been changed successfully!");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            
            Controller.SwitchView(UserMenu);
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
