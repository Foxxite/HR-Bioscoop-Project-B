using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_UserInformation : View
    {
        public View_UserInformation(Controller controller, string title, string subTitle = "", int permLevel = 0) : base(controller, title, subTitle, permLevel)
        {
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            DrawField("Username", Controller.CurrentUser.Username);
            DrawField("Name", Controller.CurrentUser.Name);
            DrawField("Age", Controller.CurrentUser.Age.ToString());
            DrawField("Address", Controller.CurrentUser.Address);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Controller.ShowMainMenu();
        }

        /// <summary>
        /// Draws a field from the User class in a pretty way.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        private void DrawField(string name, string field)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{name}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{field}\n");
        }

    }
}
