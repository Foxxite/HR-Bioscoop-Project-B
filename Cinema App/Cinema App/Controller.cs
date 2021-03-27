using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Controller
    {
        private DataStore DataStore { get; set; }
        private User CurrentUser { get; set; }
        private View CurrentView { get; set; }
        private Basket Basket { get; set; }
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

            //ShowMainMenu();

            //User user = new User("John Doe", "Password", "John");
            //var json = JsonConvert.SerializeObject(user);
            //Console.WriteLine(json);
            //var user2 = JsonConvert.DeserializeObject<User>(json);
            //DataStore.AddUser(user);
            //DataStore.AddUser(user2);

            ////View testView = new TestView(this, "test");
        }

        /// <summary>
        /// Clears the current View and makes the application return to the Main Menu.
        /// </summary>
        public void ShowMainMenu()
        {
            Menu mainMenu = new Menu(this, "Main Menu");
            mainMenu.AddMenuOption("About", new Action(About));
            mainMenu.AddMenuOption("Exit", new Action(CloseApp));

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

        /// <summary>
        /// Shows a crude about message.
        /// </summary>
        private void About()
        {
            ClearScreen();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cinema App \n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Created by: INF1C Groep 3\n\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press any key to return to the Main Menu.");
            
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
    }
}
