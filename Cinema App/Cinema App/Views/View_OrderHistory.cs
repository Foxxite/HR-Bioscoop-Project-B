using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_OrderHistory : View
    {
        public View_OrderHistory(Controller controller, string title, string subTitle = "", int permLevel = 0) : base(controller, title, subTitle, permLevel)
        {

        }

        public override void Render()
        {
            DrawTitleBar();

            if(Controller.CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL)
                RenderForAmdin();
            else
                RenderForUser();
        }
        
        public void RenderForUser()
        {
            List<Order> Orders = Controller.DataStore.GetOrdersByGUID(Controller.CurrentUser);
            Menu OrderHis = new Menu(Controller, "Order history");

            foreach(Order order in Orders)
            {
                OrderHis.AddMenuOption($"{order.OrderId}    {order.OrderDate}", (order) => { Controller.SwitchView(new View_Order(order, Controller, Title)); }, order);
            }

            OrderHis.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, null);
            Controller.SwitchView(OrderHis);
        }

        public void RenderForAmdin()
        {
            List<Order> Orders = Controller.DataStore.GetOrders();
            Menu OrderHis = new Menu(Controller, "Order history");

            foreach (Order order in Orders)
            {
                User oUser = Controller.DataStore.GetUserByGUID(order.UserId);
                string username = (oUser != null ? oUser.Username : "Invalid User");
                OrderHis.AddMenuOption($"{order.OrderId}    {order.OrderDate}   {username}", (order) => { Controller.SwitchView(new View_Order(order, Controller, Title)); }, order);
            }

            OrderHis.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, null);
            Controller.SwitchView(OrderHis);

        }
    }
}
