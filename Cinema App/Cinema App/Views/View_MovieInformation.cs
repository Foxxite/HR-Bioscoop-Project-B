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

            Menu movieMenu = new Menu(Controller, "", fullScreen: false);

            if (Controller.CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL)
            {
                movieMenu.AddMenuOption(Strings.MovieSetAuditorium, (x) => { NewMenuAudi(); }, null);
                movieMenu.AddMenuOption(Strings.Delete, (x) => { Controller.DataStore.DeleteMovie(Movie); Controller.SwitchView(MovieCatalogue); }, null);
            }
            else
            {
                movieMenu.AddMenuOption(Strings.ReservateSeat, (x) => { Controller.SwitchView(new View_ReserveSeats(Movie, Controller, Strings.SeatReservation)); }, null);
            }

            movieMenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.SwitchView(MovieCatalogue); }, null);

            Controller.SwitchView(movieMenu, false);
        }

        void NewMenuAudi()
        {
            Menu AudiAdding = new Menu(Controller, Strings.MovieSetAuditorium);

            foreach (Auditorium audi in Controller.DataStore.GetAuditoria())
            {
                AudiAdding.AddMenuOption(audi.Name, (audi) => { Movie.SetAuditorium(audi); Controller.DataStore.SaveMovieData(); }, audi);
            }

            Controller.SwitchView(AudiAdding);
        }
    }
}
