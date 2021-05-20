using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_MovieInformation : View
    {
        private Movie Movie;
        private View_MovieCatalogue MovieCatalogue;

        public View_MovieInformation(Controller controller, string title, View_MovieCatalogue mc, Movie movie, string subTitle = "", int permLevel = 0)
          : base(controller, title, subTitle, permLevel)
        {
            MovieCatalogue = mc;
            Movie = movie;

            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            DrawField(Strings.MovieTitle, Movie.Name);
            DrawField(Strings.MovieDesc, Movie.Description);

            Console.WriteLine();

            DrawField(Strings.MovieTrailer, Movie.TrailerUrl);

            Console.WriteLine();

            DrawField(Strings.MovieAge, Movie.AgeRating.ToString());
            DrawField(Strings.MoveReviewScore, Movie.ReviewScore.ToString());

            Console.WriteLine();

            DrawField(Strings.MoviePrice, Movie.Price.ToString());

            Menu movieMenu = new Menu(Controller, "Movie Menu", fullScreen: false);

            movieMenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.SwitchView(MovieCatalogue); }, null);
            movieMenu.AddMenuOption("Set Audi", (x) => { }, null);

            Controller.SwitchView(movieMenu, false);
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
