using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_UserInformation : View
    {
        User CurrentUser;
        public View_UserInformation(Controller controller, string title, string subTitle = "", int permLevel = 0, User cUser = null) : base(controller, title, subTitle, permLevel)
        {
            CurrentUser = (cUser != null ? cUser : Controller.CurrentUser);
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            DrawField(Strings.VarUserName, CurrentUser.Username);
            DrawField(Strings.VarName, CurrentUser.Name);
            DrawField(Strings.VarAge, CurrentUser.Age.ToString());
            DrawField(Strings.VarEmailAddress, CurrentUser.EmailAddress);

            Console.WriteLine();

            if (Controller.CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL && CurrentUser != Controller.CurrentUser)
            {                
                View LastView = new View_ManageAcc(Controller, Strings.ManageAccounts);
                Menu menu = new Menu(Controller, "", fullScreen: false);
                menu.AddMenuOption(Strings.Delete, (x) => { Controller.DataStore.DeleteUserData(CurrentUser); Controller.SwitchView(LastView); }, null);
                menu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.SwitchView(LastView); }, null);

                Controller.SwitchView(menu, false);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Strings.KeyPressToReturn);
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
