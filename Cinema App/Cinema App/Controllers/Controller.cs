﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Controller
    {
        public DataStore DataStore { get; }
        public User CurrentUser { get; set; }
        private View CurrentView { get; set; }
        private View_Basket Basket { get; set; }
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

            ShowMainMenu();
        }

        /// <summary>
        /// Clears the current View and makes the application return to the Main Menu.
        /// </summary>
        public void ShowMainMenu()
        {
            Menu mainMenu = new Menu(this, "Main Menu");

            // Show options if user isn't logged in.
            if(CurrentUser == null)
            {
                mainMenu.AddMenuOption("Register New Account", new Action(ShowRegistationScreen));
                mainMenu.AddMenuOption("Login with existing account", new Action(ShowLoginScreen));
            }
            // Show options if user is logged in.
            else
            {
                mainMenu.AddMenuOption("View Current Movies", new Action(ViewMovies));
                mainMenu.AddMenuOption("View account information", new Action(ViewUserInfo));
                mainMenu.AddMenuOption("Change account information", new Action(ChangeUserInfo));
                mainMenu.AddMenuOption("Log out", new Action(LogOut));
            }
            
            //Always show those options
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

        private void ShowRegistationScreen()
        {
            View_RegistrationScreen rs = new View_RegistrationScreen(this, "Registration Screen");
            SwitchView(rs);
        }

        private void ShowLoginScreen()
        {
            View_LoginScreen ls = new View_LoginScreen(this, "Login screen");
            SwitchView(ls);
        }

        private void ViewMovies()
        {
            View_MovieCatalogue mc = new View_MovieCatalogue(this, "Movie Catalogue");
            SwitchView(mc);
        }

        private void ViewUserInfo()
        {
            View_UserInformation ui = new View_UserInformation(this, "Account Information");
            SwitchView(ui);
        }

        private void ChangeUserInfo()
        {
            View_ChangeUserInformation cui = new View_ChangeUserInformation(this, "Change Account Information");
            SwitchView(cui);
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