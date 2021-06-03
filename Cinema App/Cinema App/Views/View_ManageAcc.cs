using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_ManageAcc : View
    {
        public View_ManageAcc(Controller controller, string title, string subTitle = "", int permLevel = 0) : base(controller, title, subTitle, permLevel)
        {

        }

        public override void Render()
        {
            DrawTitleBar();

            Menu menu = new Menu(Controller, "Manage Accounts");

            List<User> Users = Controller.DataStore.GetUsers();

            foreach(User user in Users)
            {
                menu.AddMenuOption(user.Username, (x) => { Controller.SwitchView(new View_UserInformation(Controller, "Manage Account", cUser: user)); },null);
            }

            menu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, null);
            Controller.SwitchView(menu);
        }
    }
}
