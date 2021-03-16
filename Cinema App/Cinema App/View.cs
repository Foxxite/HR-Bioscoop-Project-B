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

        public View(Controller controller, string title, string subTitle = "", int permLevel = 0)
        {
            Controller = controller;
            Title = title;
            SubTitle = subTitle;
            NeededPermLevel = permLevel;
        }

        abstract public void Render();
        

        public bool CanView(User user)
        {
            return true;
        }

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
