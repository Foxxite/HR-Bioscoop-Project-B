using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Cinema_App
{
    abstract class View
    {
        protected Controller Controller;
        private string Title;
        private string SubTitle = "";
        private int NeededPermLevel = 0;

        /// <summary>
        ///     Base View Class.
        ///     Define default behavior for any view.
        /// </summary>
        /// <param name = "controller">Reference to the application controller.</param>
        /// <param name = "title">Title of view.</param>
        /// <param name = "subTitle">Sub title of view.</param>
        /// <param name = "permLevel">Permission level needed to view View, default 0 (everyone).</param>
        public View(Controller controller, string title, string subTitle = "", int permLevel = 0)
        {
            Controller = controller;
            Title = title;
            SubTitle = subTitle;
            NeededPermLevel = permLevel;
        }

        /// <summary>
        ///     The Views render behavior.
        /// </summary>
        abstract public void Render();

        /// <summary>
        ///     Determines if the user has the permission to view.
        /// </summary>
        /// <param name="user">The user you want to check the permission of.</param>
        /// <returns>True if user can view, else False.</returns>
        public bool CanView(User user)
        {
            return true;
        }

        /// <summary>
        ///     Waiting for user class to be implemented...
        /// </summary>
        protected void ShowPermError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Strings.ViewPermError);

            Console.WriteLine("\n\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Strings.ReturnToMain);

            // Wait for user to press any key and return to main menu.
            Console.ReadKey(); 
            Controller.ShowMainMenu();
        }

    }
}
