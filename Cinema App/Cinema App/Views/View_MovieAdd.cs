using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Cinema_App
{
    class View_MovieAdd : View
    {
        public View_MovieAdd(Controller controller, string title, string subTitle = "", int permLevel = 0)
            : base(controller, title, subTitle, permLevel)
        {

        }

        public override void Render()
        {
            DrawTitleBar();

            
            Console.WriteLine("Enter movie title:");
            string movTitle = Console.ReadLine();
            while (string.IsNullOrEmpty(movTitle))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Movie title can't be empty");
                movTitle = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine("Enter the full movie description:");
            string movDesc = Console.ReadLine();
            while (string.IsNullOrEmpty(movDesc))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Movie description can't be empty");
                movDesc = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine("Enter age rating");
            bool correctAge = false;
            int movAge = 0;
            while (!correctAge)
            {
                try
                {
                    movAge = Int32.Parse(Console.ReadLine());
                    correctAge = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Strings.AgeNotValid);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Enter review score:");
            double movRating = -1;

            while (movRating == -1)
            {
                string input = Console.ReadLine();
                movRating = GetDouble(input, -1);

                if (String.IsNullOrEmpty(input) || movRating == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Double");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Enter trailer url:");
            string movUrl = Console.ReadLine();
            while (string.IsNullOrEmpty(movUrl))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Movie trailer url can't be empty");
                movUrl = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Controller.DataStore.AddMovie(new Movie(movTitle, movDesc, movAge, movRating, movUrl));

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
