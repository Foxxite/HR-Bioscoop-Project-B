﻿using System;
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

            
            Console.WriteLine(Strings.EnterMovieTitle);
            string movTitle = Console.ReadLine();
            while (string.IsNullOrEmpty(movTitle))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.EmptyInput);
                movTitle = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine(Strings.EnterMovieDesc);
            string movDesc = Console.ReadLine();
            while (string.IsNullOrEmpty(movDesc))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.EmptyInput);
                movDesc = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine(Strings.EnterMovieAgeRating);
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
            Console.WriteLine(Strings.EnterMovieReviewScore);
            double movRating = -1;

            while (movRating == -1)
            {
                string input = Console.ReadLine();
                movRating = GetDouble(input, -1);

                if (String.IsNullOrEmpty(input) || movRating == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Strings.InvalidDoubleInput);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine();
            Console.WriteLine(Strings.EnterMovieTrailerUrl);
            string movUrl = Console.ReadLine();
            while (string.IsNullOrEmpty(movUrl))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.EmptyInput);
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
