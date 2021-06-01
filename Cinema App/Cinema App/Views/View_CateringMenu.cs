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


            mainmenu.AddEmptyLine();

            mainmenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, false);

            Controller.SwitchView(mainmenu);
        }

        void ShowCaterItemInformation(CateringItem caterItem)
        {
            View_OrderItem ii = new View_OrderItem(Controller, caterItem.Name, this, caterItem);

            Controller.SwitchView(ii);
        }
        //void CaterItem()
        //{
        //    CateringItem cateringItem = new CateringItem("Popcorn", "Our delicious new pepcorn!", 4.50, 100);
        //}

        //void CaterItem1()
        //{
        //    CateringItem cateringItem = new CateringItem("Coke", "Fresh coke, now with less sugar!", 2.95, 100);
        //}

        //void CaterItem2()
        //{
        //    CateringItem cateringItem = new CateringItem("Fanta", "Fresh fanta, now with less sugar!", 2.95, 100);
        //}

        //void CaterItem3()
        //{
        //    CateringItem cateringItem = new CateringItem("Chips", "Our delicious new chips!", 3.50, 100);
        //}
    }
}