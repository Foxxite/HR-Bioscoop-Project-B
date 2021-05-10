using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;

namespace Cinema_App
{
    class DataStore
    {
        protected List<User> Users = new List<User>();
        protected List<Item> Items = new List<Item>();
        protected List<Movie> Movies = new List<Movie>();

        private string USER_FILE = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Settings.DefaultDataLocation + "/users.json";
        private string ITEM_FILE = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Settings.DefaultDataLocation + "/items.json";
        private string MOVIE_FILE = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Settings.DefaultDataLocation + "/movies.json";

        /// <summary>
        /// Initializes the DataStore class for use
        /// </summary>
        public DataStore()
        {
            // Create the users file if not exist.
            if (!File.Exists(USER_FILE))
                File.Create(USER_FILE);

            // Create the items file if not exist.
            if (!File.Exists(ITEM_FILE))
                File.Create(ITEM_FILE);

            // Create the movies file if not exist.
            if (!File.Exists(MOVIE_FILE))
                File.Create(MOVIE_FILE);

            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(USER_FILE));
            if (users != null)
                Users = users;

            var items = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(ITEM_FILE));
            if (items != null)
                Items = items;

            var movies = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(MOVIE_FILE));
            if (movies != null)
                Movies = movies;
        }
    

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveUserData();
        }

        public void SaveUserData()
        {
            var userData = JsonConvert.SerializeObject(Users);
            File.WriteAllText(USER_FILE, userData);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            SaveItemData();
        }

        public void SaveItemData()
        {
            var itemData = JsonConvert.SerializeObject(Items);
            File.WriteAllText(ITEM_FILE, itemData);
        }
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
            SaveMovieData();
        }
        public void SaveMovieData()
        {
            var movieData = JsonConvert.SerializeObject(Movies);
            File.WriteAllText(MOVIE_FILE, movieData);
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public List<Item> GetItems()
        {
            return Items;
        }

        public List<Movie> GetMovies()
        {
            return Movies;
        }

        public User GetUserByUsername(string username)
        {
            foreach (User u in GetUsers())
                if (u.Username.Equals(username))
                    return u;

            return null;
        }

    }
}
