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

        private View LastView;

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
            if (CurrentUser == null)
            {
                mainMenu.AddMenuOption(Strings.RegisterNew, (x) => { ShowRegistationScreen(); }, null);
                mainMenu.AddMenuOption(Strings.LoginMenu, (x) => { ShowLoginScreen(); }, null);
            }
            // Show options if user is logged in.
            else
            {
                mainMenu.AddMenuOption(Strings.ViewCurrentMovies, (x) => { ViewMovies(); }, null);
                mainMenu.AddMenuOption(Strings.CateringMenu, (x) => { ViewCateringMenu(); }, false);   
                
                if(CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL)
                {
                    mainMenu.AddMenuOption("import audi", (x) => { new AuditoriumImporter(this); }, null);
                }
                else
                {
                    mainMenu.AddMenuOption(Strings.Basket, (x) => { ViewBasket(); }, null);
                }

                mainMenu.AddMenuOption(Strings.ViewAcc, (x) => { ViewUserInfo(); }, null);
                mainMenu.AddMenuOption(Strings.ChangeAcc, (x) => { ChangeUserInfo(); }, null);
                mainMenu.AddMenuOption(Strings.LogOut, (x) => { LogOut(); }, null);
            }
            
            //Always show those options
            mainMenu.AddMenuOption(Strings.About, (x) => { About(); }, null);
            mainMenu.AddMenuOption(Strings.Exit, (x) => { CloseApp(); }, null);

            SwitchView(mainMenu);
        }


        /// <summary>
        /// Clears the current View and makes the application show the supplied View.
        /// </summary>
        /// <param name="newView">View to use.</param>
        public void SwitchView(View newView, bool clearScreen = true)
        {
            if (clearScreen)
                ClearScreen();

            LastView = CurrentView;
            CurrentView = newView;
            newView.Render();
        }

        public void SwitchToLastView()
        {
            SwitchView(LastView);
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

        private void ViewBasket()
        {
            View_Basket vb = new View_Basket(this, Strings.Basket);
            SwitchView(vb);
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

        private void ViewCateringMenu()
        {
            View_CateringMenu cmn = new View_CateringMenu(this, "Catering menu");
            SwitchView(cmn);
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

            Console.WriteLine("\n\nColor Test");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("#");

            Console.WriteLine();

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
