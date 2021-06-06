using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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

            Console.WriteLine(Strings.EnterUserName);
            string enteredUsername = Console.ReadLine().Trim();

            while(String.IsNullOrEmpty(enteredUsername))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.UsernameNotEmpty);
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }
            
            while (DoesUsernameExist(enteredUsername))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.UsernameInUse);
                Console.ForegroundColor = ConsoleColor.White;

                enteredUsername = Console.ReadLine().Trim();
            }

            Console.WriteLine();

            Console.WriteLine(Strings.EnterPW);
            string enteredPassword = Console.ReadLine().Trim();
            
            while (String.IsNullOrEmpty(enteredPassword))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.PWNotEmpty);
                Console.ForegroundColor = ConsoleColor.White;

                enteredPassword = Console.ReadLine().Trim();
            }

            Console.WriteLine();

            Console.WriteLine(Strings.EnterName);
            string enteredName = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.NameNotEmpty);
                Console.ForegroundColor = ConsoleColor.White;

                enteredName = Console.ReadLine().Trim();
            }

            Console.WriteLine();

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

            Console.WriteLine();

            Console.WriteLine(Strings.EnterMail);
            string enteredEmailAddress = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(enteredEmailAddress) || !IsValidEmail(enteredEmailAddress))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.EmailNotValid);
                Console.ForegroundColor = ConsoleColor.White;

                enteredEmailAddress = Console.ReadLine().Trim();
            }

            Controller.ClearScreen();

            DrawTitleBar();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Strings.WaitAccCreateMess);

            User newUser = new User(enteredUsername, enteredPassword, enteredName, enteredEmailAddress, enteredAge);
            newUser.ConvertPasswordToHash();

            Controller.DataStore.AddUser(newUser);

            Console.WriteLine();
            Console.Beep();
            Console.WriteLine(Strings.AccCreateSucces);
            Console.WriteLine(Strings.LoginMessage);
            
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(3000);

            Controller.SwitchView(new View_LoginScreen(Controller, Strings.LoginMenu));
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
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex rg = new Regex(pattern);

            return rg.IsMatch(email);
        }
    }
}
