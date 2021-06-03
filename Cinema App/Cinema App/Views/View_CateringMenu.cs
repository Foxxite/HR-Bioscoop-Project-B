using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_CateringMenu : View
    {
        public View_CateringMenu(Controller controller, string productname, string productsubTitle = "", int permLevel = 0)
           : base(controller, productname, productsubTitle, permLevel)
        {
            return;
        }

        
        public override void Render()
        {
            DrawTitleBar();

            Menu mainmenu = new Menu(Controller, Strings.Catering);

            foreach (CateringItem caterItem in Controller.DataStore.GetCateringItems())
            {
                mainmenu.AddMenuOption($"{caterItem.Name}; €{caterItem.Price}", (catitem) => ShowCaterItemInformation(catitem), caterItem);
            }

            if (Controller.CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL)
            {
                mainmenu.AddMenuOption(Strings.AddCateringItem, (x) => { Controller.SwitchView(new View_CateringItemAdd(Controller, Strings.AddCateringItem)); }, null);
            }

            mainmenu.AddEmptyLine();

            mainmenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, false);

            Controller.SwitchView(mainmenu);
        }

        void ShowCaterItemInformation(CateringItem caterItem)
        {
            View_OrderItem ii = new View_OrderItem(Controller, caterItem.Name, this, caterItem);

            Controller.SwitchView(ii);
        }
    }
}