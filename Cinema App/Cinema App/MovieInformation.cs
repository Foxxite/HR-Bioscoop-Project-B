using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class MovieInformation : View
    {
        private Movie Movie;
        private MovieCatalogue MovieCatalogue;

        public MovieInformation(Controller controller, string title, MovieCatalogue mc, Movie movie, string subTitle = "", int permLevel = 0)
          : base(controller, title, subTitle, permLevel)
        {
            MovieCatalogue = mc;
            Movie = movie;

            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            DrawField("Title", Movie.Name);
            DrawField("Description", Movie.Description);

            Console.WriteLine();

            DrawField("Trailer", Movie.TrailerUrl);

            Console.WriteLine();

            DrawField("Age Rating", Movie.AgeRating.ToString());
            DrawField("Review Score", Movie.ReviewScore.ToString());

            Console.WriteLine();

            DrawField("Price", Movie.Price.ToString());


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress any key to return to the movie catalogue...");
            Console.ReadKey();
            Controller.SwitchView(MovieCatalogue);
        }

        /// <summary>
        /// Draws a field from the movie class in a pretty way.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        private void DrawField(string name, string field)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{name}: ");
            Console.ForegroundColor = ConsoleColor.White;
            WordWrap($"{field}\n");
        }

    }
}
