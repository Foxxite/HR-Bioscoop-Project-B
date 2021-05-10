using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_MovieCatalogue : View
    {
        public View_MovieCatalogue(Controller controller, string title, string subTitle = "", int permLevel = 0)
           : base(controller, title, subTitle, permLevel)
        {
            List<Movie> movies = new List<Movie>();
            Movie movie = new Movie("Honest Thief", "Not wanting his relationship with Annie to be based on lies, notorious bank robber Tom decides to turn himself in. However, the FBI has plans of its own with Tom's stolen money, triggering a bizarre game of cat and mouse.",
                12, 6.0, "https://www.youtube.com/watch?v=_TLtcw7ixRc", null, 4.99, 100);
            Movie movie2 = new Movie("The War With Grandpa", "What would you do if you had to hand over your bedroom to none other than your own grandpa? This happens to ten-year-old Peter because his grandfather Jack is forced to move in with the family.",
               6, 5.6, "https://www.youtube.com/watch?v=X0K5cA2hS6g", null, 4.99, 100);
            Movie movie3 = new Movie("The Dark and the Wicked", "A brother and sister return to their parents' home to watch over their father's deathbed. But what begins as a ritual of mourning and commemoration soon turns into their worst nightmare.",
               16, 6.1, "https://www.youtube.com/watch?v=zM-jmNmX50Q", null, 4.99, 100);
            Movie movie4= new Movie("Bigfoot Family", "Ever since his return from the wilderness, Bigfoot has been a real star, much to the dismay of his son Adam who wants nothing more than a normal life.",
              6, 5.8, "https://www.youtube.com/watch?v=z6eZplmUEFY", null, 4.99, 100);
            Movie movie5 = new Movie("Fatman", "Because the government has stopped the subsidy, Santa Claus has turned into a drunk ship. To keep his business alive, he works with the military and makes a different kind of toys.",
               16, 5.9, "https://www.youtube.com/watch?v=WjBjUF4Tb_k", null, 4.99, 100);
            movies.Add(movie); movies.Add(movie2); movies.Add(movie3); movies.Add(movie4); movies.Add(movie5);

            Controller.DataStore.AddMovie(movie);
            Controller.DataStore.AddMovie(movie2);
            Controller.DataStore.AddMovie(movie3);
            Controller.DataStore.AddMovie(movie4);
            Controller.DataStore.AddMovie(movie5);




            return;
        
        }


        public override void Render()
        {
            DrawTitleBar();

            Menu mainMenu = new Menu(Controller, "Movie Catalogue");

            mainMenu.AddMenuOption("Honest Thief", new Action(Movie));
            mainMenu.AddMenuOption("The War With Grandpa", new Action(Movie2));
            mainMenu.AddMenuOption("The Dark and the Wicked", new Action(Movie3));
            mainMenu.AddMenuOption("Bigfoot Family", new Action(Movie4));
            mainMenu.AddMenuOption("Fatman", new Action(Movie5));

            //mainMenu.AddEmptyLine();

            mainMenu.AddMenuOption("Return to Main Menu", new Action(Controller.ShowMainMenu));

            Controller.SwitchView(mainMenu);
        }

        void Movie()
        {
            Movie movie = new Movie("Honest Thief", "Not wanting his relationship with Annie to be based on lies, notorious bank robber Tom decides to turn himself in. However, the FBI has plans of its own with Tom's stolen money, triggering a bizarre game of cat and mouse.",
                12, 6.0, "https://www.youtube.com/watch?v=_TLtcw7ixRc", null, 4.99, 100);

            View_MovieInformation mi = new View_MovieInformation(Controller, "Honest Thief", this, movie);

            Controller.SwitchView(mi);
        }

        void Movie2()
        {
            Movie movie = new Movie("The War With Grandpa", "What would you do if you had to hand over your bedroom to none other than your own grandpa? This happens to ten-year-old Peter because his grandfather Jack is forced to move in with the family.",
                6, 5.6, "https://www.youtube.com/watch?v=X0K5cA2hS6g", null, 4.99, 100);

            View_MovieInformation mi = new View_MovieInformation(Controller, "The War With Grandpa", this, movie);

            Controller.SwitchView(mi);
        }

        void Movie3()
        {
            Movie movie = new Movie("The Dark and the Wicked", "A brother and sister return to their parents' home to watch over their father's deathbed. But what begins as a ritual of mourning and commemoration soon turns into their worst nightmare.", 
                16, 6.1, "https://www.youtube.com/watch?v=zM-jmNmX50Q", null, 4.99, 100);

            View_MovieInformation mi = new View_MovieInformation(Controller, "The Dark and the Wicked", this, movie);

            Controller.SwitchView(mi);
        }

        void Movie4()
        {
            Movie movie = new Movie("Bigfoot Family", "Ever since his return from the wilderness, Bigfoot has been a real star, much to the dismay of his son Adam who wants nothing more than a normal life.", 
                6, 5.8, "https://www.youtube.com/watch?v=z6eZplmUEFY", null, 4.99, 100);

            View_MovieInformation mi = new View_MovieInformation(Controller, "Bigfoot Family", this, movie);

            Controller.SwitchView(mi);
        }
        
        void Movie5()
        {
            Movie movie = new Movie("Fatman", "Because the government has stopped the subsidy, Santa Claus has turned into a drunk ship. To keep his business alive, he works with the military and makes a different kind of toys.", 
                16, 5.9, "https://www.youtube.com/watch?v=WjBjUF4Tb_k", null, 4.99, 100);

            View_MovieInformation mi = new View_MovieInformation(Controller, "Fatman", this, movie);

            Controller.SwitchView(mi);
        }
    
    }


         
}
