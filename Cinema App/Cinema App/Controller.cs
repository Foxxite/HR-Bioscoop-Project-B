using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Controller
    {
        private User CurrentUser { get; set; }
        private View CurrentView { get; }
        private Basket Basket { get; }
        private Menu MainMenu { get; }


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

            // ToDo create Main Menu

            
        }

        public void ShowMainMenu()
        {

        }

        public void SwitchView(View newView)
        {
            ClearScreen();
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
    }
}
