using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Cinema_App
{
    class View_CateringItemAdd : View
    {
        public View_CateringItemAdd(Controller controller, string title, string subTitle = "", int permLevel = 0)
            : base(controller, title, subTitle, permLevel)
        {

        }

        public override void Render()
        {
            DrawTitleBar();

            Console.WriteLine("Enter catering item name:");
            string catItemName = Console.ReadLine();
            while (string.IsNullOrEmpty(catItemName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Catering item name can't be empty");
                catItemName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine("Enter price:");
            double catItemPrice = -1;

            while (catItemPrice == -1)
            {
                string input = Console.ReadLine();
                catItemPrice = GetDouble(input, -1);

                if (String.IsNullOrEmpty(input) || catItemPrice == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Double");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Controller.DataStore.AddCaterItem(new CateringItem(catItemName, catItemPrice));

            Controller.SwitchToLastView();
        }

        public static double GetDouble(string value, double defaultValue)
        {
            double result;

            // Try parsing in the current culture
            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                // Then try in US english
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                // Then in neutral language
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }
            return result;
        }
    }
}
