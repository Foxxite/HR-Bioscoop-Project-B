using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_Order : View
    {
        Order Order;
        public View_Order(Order order, Controller controller, string title, string subTitle = "", int permLevel = 0) : base(controller, title, subTitle, permLevel)
        {
            Order = order;
        }

        public override void Render()
        {
            DrawTitleBar();

            foreach (BasketItem bitem in Order.Items)
            {
                Console.WriteLine($"{bitem.Item.Name}   {bitem.Quantity}x : {bitem.Quantity * bitem.Item.Price}");
            }

            Console.WriteLine("\n");

            if (Controller.CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL)
            {
                View LastView = new View_OrderHistory(Controller, "Order History");

                Menu menu = new Menu(Controller, "", fullScreen:false);
                menu.AddMenuOption("Delete", (x) => { Controller.DataStore.DeleteOrder(Order); Controller.SwitchView(LastView); }, null);
                menu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.SwitchView(LastView); }, null);

                Controller.SwitchView(menu, false);
            }
            else
            {
                Console.WriteLine(Strings.KeyPressToReturn);
                Console.ReadLine();
                Controller.SwitchToLastView();
            }
        }
    }
}
