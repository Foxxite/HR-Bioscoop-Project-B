using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Controller
    {
        public DataStore DataStore { get; }
        public User CurrentUser { get; set; }
        public Basket Basket { get; }
        private View CurrentView { get; set; }
        private Menu MainMenu { get; set; }

       

        /// <summary>
        ///     Main apllication controller.
        ///     Controls the flow and state of the application.
        ///     
        ///     <para>Onces created, it will setup the app with the default main menu and color settings.</para>
        /// </summary>
        /// <param name="args">Arguments passed to the app. Will be ignored for now.</param>
        public Controller(string[] args)
        {
            Console.WriteLine("Loading...");

            DataStore = new DataStore();
            Basket = new Basket();

            ShowMainMenu();
        }

        /// <summary>
        /// Clears the current View and makes the application return to the Main Menu.
        /// </summary>
        public void ShowMainMenu()
        {
            Menu mainMenu = new Menu(this, Strings.MainMenuName);

            // Show options if user isn't logged in.
            if(CurrentUser == null)
            {
                mainMenu.AddMenuOption(Strings.RegisterNew, new Action(ShowRegistationScreen));
                mainMenu.AddMenuOption(Strings.LoginMenu, new Action(ShowLoginScreen));
            }
            // Show options if user is logged in.
            else
            {
                mainMenu.AddMenuOption(Strings.ViewCurrentMovies, new Action(ViewMovies));
                mainMenu.AddMenuOption(Strings.ViewAcc, new Action(ViewUserInfo));
                mainMenu.AddMenuOption(Strings.ChangeAcc, new Action(ChangeUserInfo));
                mainMenu.AddMenuOption(Strings.LogOut, new Action(LogOut));
            }
            
            //Always show those options
            mainMenu.AddMenuOption(Strings.About, new Action(About));
            mainMenu.AddMenuOption(Strings.Exit, new Action(CloseApp));

            SwitchView(mainMenu);
        }


        /// <summary>
        /// Clears the current View and makes the application show the supplied View.
        /// </summary>
        /// <param name="newView">View to use.</param>
        public void SwitchView(View newView)
        {
            ClearScreen();
            CurrentView = newView;
            newView.Render();
        }

        /// <summary>
        ///     Removes all content from the window.
        ///     
        ///     <para>Will be called when a view is about to be switched.</para>
        /// </summary>
        /// <remarks>This operation can not be undone, only call when you absolutly need to clear the screen.</remarks>
        public void ClearScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void ShowRegistationScreen()
        {
            View_RegistrationScreen rs = new View_RegistrationScreen(this, Strings.RegScreen);
            SwitchView(rs);
        }

        private void ShowLoginScreen()
        {
            View_LoginScreen ls = new View_LoginScreen(this, Strings.LogScreen);
            SwitchView(ls);
        }

        private void ViewMovies()
        {
            View_MovieCatalogue mc = new View_MovieCatalogue(this, Strings.MovCat);
            SwitchView(mc);
        }

        private void ViewUserInfo()
        {
            View_UserInformation ui = new View_UserInformation(this, Strings.Accinfo);
            SwitchView(ui);
        }

        private void ChangeUserInfo()
        {
            View_ChangeUserInformation cui = new View_ChangeUserInformation(this, Strings.ChangeAcc);
            SwitchView(cui);
        }

        /// <summary>
        /// Shows a crude about message.
        /// </summary>
        private void About()
        {
            ClearScreen();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Strings.NameApp);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Strings.GroupInfo);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Strings.KeyPressToReturn);
            
            Console.ReadKey();
            ShowMainMenu();
        }

        /// <summary>
        /// Closes the app.
        /// </summary>
        private void CloseApp()
        {
            Environment.Exit(1);
        }

        /// <summary>
        /// Log out the current user
        /// </summary>
        private void LogOut()
        {
            CurrentUser = null;
            ShowMainMenu();
        }
    }
}
