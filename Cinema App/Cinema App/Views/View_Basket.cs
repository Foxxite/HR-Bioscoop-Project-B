using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_Basket : View
    {
        public View_Basket(Controller controller, string title, string subTitle = "", int permLevel = 0)
           : base(controller, title, subTitle, permLevel)
        {
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            List<BasketItem> basketItems = Controller.Basket.GetAllItems();



        }
    }
}
