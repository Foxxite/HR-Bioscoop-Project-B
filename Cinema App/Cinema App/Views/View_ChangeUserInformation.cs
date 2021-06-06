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

            UserMenu = new Menu(Controller, Strings.ChangeUserInfo);

            UserMenu.AddMenuOption(Strings.ChangeUserName, (x) => { ChangeUsername(); }, false);
            UserMenu.AddMenuOption(Strings.ChangePass, (x) => { ChangePassword(); }, false);
            UserMenu.AddMenuOption(Strings.ChangeName, (x) => { ChangeName(); }, false);
            UserMenu.AddMenuOption(Strings.ChangeAge, (x) => { ChangeAge(); }, false);
            UserMenu.AddMenuOption(Strings.ChangeMail + "\n", (x) => { ChangeEmailAddress(); }, false);

            UserMenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, false);

            Controller.SwitchView(UserMenu);
        }

        void ChangeUsername()
        {
            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine(Strings.EnterUserName);
            string enteredUsername = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredUsername))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.UsernameNotEmpty);
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }

            while (Controller.DataStore.GetUserByUsername(enteredUsername) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.UsernameInUse);
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }

            user.ChangeUsername(enteredUsername);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine(Strings.UserNameChangeSucces);

            Console.WriteLine("\n" + Strings.ReturnToMain);
            Console.ReadKey();

            Controller.SwitchView(this);

        }
        void ChangePassword()
        {
            Controller.ClearScreen();

            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine(Strings.EnterPW);

            string enteredPassword = Console.ReadLine().Trim();
            int wrongPasswordCounter = 0;

            while (String.IsNullOrEmpty(enteredPassword) || !CorrectPassword(user.Username, enteredPassword))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.PWNotEmpty);
                Console.ForegroundColor = ConsoleColor.White;
                wrongPasswordCounter++;
                if (wrongPasswordCounter > 3)
                {
                    Controller.ShowMainMenu();
                }
                enteredPassword = Console.ReadLine().Trim();
            }

            Console.WriteLine(Strings.EnterNewPW);
            string newPassword = Console.ReadLine().Trim();
            while (String.IsNullOrEmpty(newPassword))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.PWNotEmpty);
                Console.ForegroundColor = ConsoleColor.White;
                newPassword = Console.ReadLine().Trim();
            }
            
            user.ChangePassword(newPassword);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine(Strings.PWChangeSucces);

            Console.WriteLine("\n" + Strings.KeyPressToReturn);
            Console.ReadKey();

            Controller.SwitchView(this);
        }
        void ChangeName()
        {
            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine(Strings.EnterName);
            string enteredName = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.NameNotEmpty);
                Console.ForegroundColor = ConsoleColor.White;

                enteredName = Console.ReadLine().Trim();
            }

            user.ChangeName(enteredName);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine(Strings.NameChangeSucces);

            Console.WriteLine("\n" + Strings.KeyPressToReturn);
            Console.ReadKey();

            Controller.SwitchView(this);
        }
        void ChangeAge()
        {

            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine(Strings.EnterAge);

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
                    Console.WriteLine(Strings.AgeNotValid);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            user.ChangeAge(enteredAge);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine(Strings.AgeChangeSucces);

            Console.WriteLine("\n" + Strings.KeyPressToReturn);
            Console.ReadKey();

            Controller.SwitchView(this);
        }
        void ChangeEmailAddress()
        {
            Controller.ClearScreen();
            DrawTitleBar();

            User user = Controller.CurrentUser;

            Console.WriteLine(Strings.EnterMail);
            string enteredEmailAddress = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredEmailAddress) && !IsValidEmail(enteredEmailAddress))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.EmailNotValid);
                Console.ForegroundColor = ConsoleColor.White;

                enteredEmailAddress = Console.ReadLine().Trim();
            }

            user.ChangeEmailAddress(enteredEmailAddress);
            Controller.DataStore.SaveUserData();

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine(Strings.EmailChangeSucces);

            Console.WriteLine("\n" + Strings.KeyPressToReturn);
            Console.ReadKey();
            
            Controller.SwitchView(this);
        }

        private bool CorrectPassword(string username, string password)
        {
            User user = Controller.DataStore.GetUserByUsername(username);
            if (user != null)
                return user.VerifyPassword(password);

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
