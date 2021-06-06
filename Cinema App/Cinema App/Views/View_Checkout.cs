using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_Checkout : View
    {

        Basket Basket;

        public View_Checkout(Controller controller, string title, string subTitle = "", int permLevel = 0)
           : base(controller, title, subTitle, permLevel)
        {
            Basket = Controller.Basket;
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            List<BasketItem> basketItems = Basket.GetAllItems();

            Menu basketMenu = new Menu(Controller, Strings.Basket, $"Total: €{String.Format("{0:N}", Basket.TotalPrice())}");

            Console.WriteLine(Strings.EnterCreditcard);
            string cardNumber = Console.ReadLine();
            VerifyCard(cardNumber);

            basketMenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, null);

            while (VerifyCard(cardNumber) == false)
            {
                Console.WriteLine(Strings.EnterCreditcard);
                cardNumber = Console.ReadLine();
            }

            Order order = new Order(Basket.GetAllItems(), Controller);
            Controller.DataStore.AddOrder(order);
            
            foreach(BasketItem item in Basket.GetAllItems())
            {
                item.Item.StockAvailable -= 1;
            }

            Console.WriteLine("\n"+ Strings.Ordersucces +"\n\n" + Strings.OrderID  + $"{order.OrderId}\n\n" + Strings.KeyPressToReturn);
            
            Console.ReadKey();
            Controller.ShowMainMenu();
        }

        /// <summary>
        /// Verifies creditnumber
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        private bool VerifyCard(string cardNumber)
        {
            int[] cardInt = new int[cardNumber.Length];

            for (int i = 0; i < cardNumber.Length; i++)
            {
                cardInt[i] = (int)(cardNumber[i] - '0');
            }

            for (int i = cardInt.Length - 2; i >= 0; i = i - 2)
            {
                int tempValue = cardInt[i];

                tempValue = tempValue * 2;

                if (tempValue > 9)
                {
                    tempValue = tempValue % 10 + 1;
                }
                cardInt[i] = tempValue;
            }

            int total = 0;
            for (int i = 0; i < cardInt.Length; i++)
            {
                total += cardInt[i];
            }

            if (total % 10 == 0 && cardNumber.Length >= 13 && cardNumber.Length <= 19)
            {
                return true;
            }
            return false;
        }

    }
}
