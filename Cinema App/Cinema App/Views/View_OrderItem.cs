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
            DrawField(Strings.MoviePrice, "" + Item.Price);

            Console.WriteLine();


            Console.WriteLine();

            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n" + Strings.KeyPressToReturn);
            Console.ReadKey();
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
//private Movie Movie;
//private View_MovieCatalogue MovieCatalogue;

//public View_MovieInformation(Controller controller, string title, View_MovieCatalogue mc, Movie movie, string subTitle = "", int permLevel = 0)
//          : base(controller, title, subTitle, permLevel)
//        {
//    MovieCatalogue = mc;
//    Movie = movie;

//    return;
//}
