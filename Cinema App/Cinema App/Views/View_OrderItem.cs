using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_OrderItem : View
    {
        private Item Item;
        private View_CateringMenu cateringMenu;

        public View_OrderItem(Controller controller, string title, View_CateringMenu cm, Item item, string subTitle = "", int permLevel = 0)
          : base(controller, title, subTitle, permLevel)
        {
            Item = item;
            cateringMenu = cm;

            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            DrawField(Strings.CaterName, Item.Name);
            DrawField(Strings.MoviePrice, "€" + Item.Price);

            Console.WriteLine();



            Console.WriteLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(Strings.AmountMess);
            bool correctAmount = false;
            int enteredAmount = 0;

            while (!correctAmount)
            {
                try
                {
                    enteredAmount = Int32.Parse(Console.ReadLine());
                    correctAmount = true;
                }
                catch
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine(Strings.AgeNotValid);
                    //Console.ForegroundColor = ConsoleColor.White;
                    Controller.SwitchView(cateringMenu);
                }
            }

            Controller.Basket.AddItem(Item, enteredAmount);
            Controller.SwitchView(cateringMenu);


        }
        private void DrawField(string name, string field)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{name}: ");
            Console.ForegroundColor = ConsoleColor.White;
            WordWrap($"{field}\n");
        }
    }

}
