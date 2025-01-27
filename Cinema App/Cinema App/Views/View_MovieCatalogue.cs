﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_MovieCatalogue : View
    {
        public View_MovieCatalogue(Controller controller, string title, string subTitle = "", int permLevel = 0)
           : base(controller, title, subTitle, permLevel)
        {
            return; 
        }

        public override void Render()
        {
            DrawTitleBar();

            Menu mainMenu = new Menu(Controller, Strings.MovCat);
           
            foreach (Movie movie in Controller.DataStore.GetMovies())
            {
                mainMenu.AddMenuOption(movie.Name, (mov) => ShowMovieInformation(mov), movie);
            }

            if (Controller.CurrentUser.Permlevel == Program.ADMIN_PERM_LEVEL)
            {
                mainMenu.AddMenuOption(Strings.AddMovie, (x) => { Controller.SwitchView(new View_MovieAdd(Controller, Strings.AddMovie)); }, null);
            }

            mainMenu.AddMenuOption(Strings.ReturnToMainOption, (x) => { Controller.ShowMainMenu(); }, false);

            Controller.SwitchView(mainMenu);
        }

        void ShowMovieInformation(Movie movie)
        {
            View_MovieInformation mi = new View_MovieInformation(Controller, movie.Name, this, movie);

            Controller.SwitchView(mi);
        }
    }        
}