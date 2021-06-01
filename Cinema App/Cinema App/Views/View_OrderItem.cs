using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_OrderItem : View
    {
        private CateringItem CateringItem;
        private View_CateringMenu cateringMenu;

        public View_OrderItem(Controller controller, string title, View_CateringMenu cm, CateringItem item, string subTitle = "", int permLevel = 0)
          : base(controller, title, subTitle, permLevel)
        {
            CateringItem = item;
            cateringMenu = cm;

            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            DrawField(Strings.CaterName, CateringItem.Name);
            DrawField(Strings.MoviePrice, "€" + CateringItem.Price);

            Console.WriteLine("\n\n\n");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(Strings.AmountMess);

            bool correctAmount = false;
            int enteredAmount = 0;
            

            if(Controller.CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL)
            {
                Menu adminMenu = new Menu(Controller, "Admin menu", fullScreen:false);

                adminMenu.AddMenuOption("Remove Item", (x) => { Controller.DataStore.DeleteCateringItem(CateringItem); Controller.SwitchView(cateringMenu); }, null);
                adminMenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.SwitchView(cateringMenu); }, null);

                Controller.SwitchView(adminMenu, false);
            }
            else
            {
                while (!correctAmount)
                {
                    try
                    {
                        enteredAmount = Int32.Parse(Console.ReadLine());
                        correctAmount = true;
                    }
                    catch { }
                }

                Controller.Basket.AddItem(CateringItem, enteredAmount);
                Controller.SwitchView(cateringMenu);
            }
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
