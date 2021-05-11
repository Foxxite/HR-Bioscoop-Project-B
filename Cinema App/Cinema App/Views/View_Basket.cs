using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_Basket : View
    {
        Basket Basket;

        public View_Basket(Controller controller, string title, string subTitle = "", int permLevel = 0)
           : base(controller, title, subTitle, permLevel)
        {
            Basket = Controller.Basket;
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            List<BasketItem> basketItems = Basket.GetAllItems();

            Menu basketMenu = new Menu(Controller, "Basket", $"Total: €{String.Format("{0:N}", Basket.TotalPrice())}");

            foreach (BasketItem item in Basket.GetAllItems())
            {
                basketMenu.AddMenuOption(item.Item.Name + " " + item.Quantity + "x", null, null);
            }

            basketMenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, null);

            Controller.SwitchView(basketMenu);
        }
    }
}
