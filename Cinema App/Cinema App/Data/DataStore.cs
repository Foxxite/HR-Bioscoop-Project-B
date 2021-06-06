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
        protected List<CateringItem> CateringItems = new List<CateringItem>();
        protected List<Order> Orders = new List<Order>();
        protected List<Auditorium> Auditoria = new List<Auditorium>();

        private string PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Settings.DefaultDataLocation;

        private string USER_FILE =  "/users.json";
        private string ITEM_FILE =  "/items.json";
        private string MOVIE_FILE =  "/movies.json";
        private string CATERINGITEM_FILE = "/cateringitems.json";
        private string ORDER_FILE =  "/orders.json";
        private string AUDITORIUM_FILE = "/auditoria.json";

        /// <summary>
        /// Initializes the DataStore class for use
        /// </summary>
        public DataStore()
        {
            // Make sure all CONSTANTS use the correct path
            USER_FILE = PATH + USER_FILE;
            ITEM_FILE = PATH + ITEM_FILE;
            MOVIE_FILE = PATH + MOVIE_FILE;
            CATERINGITEM_FILE = PATH + CATERINGITEM_FILE;
            ORDER_FILE = PATH + ORDER_FILE;
            AUDITORIUM_FILE = PATH + AUDITORIUM_FILE;

            // Create data directory if not exist
            if (!Directory.Exists(PATH))            
                Directory.CreateDirectory(PATH);
            
            // Create the users file if not exist.
            if (!File.Exists(USER_FILE))
                File.Create(USER_FILE);

            // Create the items file if not exist.
            if (!File.Exists(ITEM_FILE))
                File.Create(ITEM_FILE);

            // Create the movies file if not exist.
            if (!File.Exists(MOVIE_FILE))
                File.Create(MOVIE_FILE);

            // Create the cateringitem file if not exist.
            if (!File.Exists(CATERINGITEM_FILE))
                File.Create(CATERINGITEM_FILE);

            // Create the orders file if not exist.
            if (!File.Exists(ORDER_FILE))
                File.Create(ORDER_FILE);

            // Create the auditoria file if not exist.
            if (!File.Exists(AUDITORIUM_FILE))
                File.Create(AUDITORIUM_FILE);

            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(USER_FILE));
            if (users != null)
                Users = users;

            var items = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(ITEM_FILE));
            if (items != null)
                Items = items;

            var movies = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(MOVIE_FILE));
            if (movies != null)
                Movies = movies;

            var cateritems = JsonConvert.DeserializeObject<List<CateringItem>>(File.ReadAllText(CATERINGITEM_FILE));
            if (cateritems != null)
                CateringItems = cateritems;

            var orderitems = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(ORDER_FILE));
            if (orderitems != null)
                Orders = orderitems;

            var auditoria = JsonConvert.DeserializeObject<List<Auditorium>>(File.ReadAllText(AUDITORIUM_FILE));
            if(auditoria != null)
            {
                Auditoria = auditoria;
            }
        }
    

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveUserData();
        }

        public void SaveUserData()
        {
            var userData = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(USER_FILE, userData);
        }

        public void DeleteUserData(User user)
        {
            Users.Remove(user);
            SaveUserData();
        }

        public void AddAuditorium(Auditorium auditorium)
        {
            Auditoria.Add(auditorium);
            SaveAuditoriumData();
        }

        public void SaveAuditoriumData()
        {
            var auditoriumData = JsonConvert.SerializeObject(Auditoria, Formatting.Indented);
            File.WriteAllText(AUDITORIUM_FILE, auditoriumData);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            SaveItemData();
        }

        public void SaveItemData()
        {
            var itemData = JsonConvert.SerializeObject(Items, Formatting.Indented);
            File.WriteAllText(ITEM_FILE, itemData);
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
            SaveMovieData();
        }

        public void DeleteMovie(Movie movie)
        {
            Movies.Remove(movie);
            SaveMovieData();
        }

        public void SaveMovieData()
        {
            var movieData = JsonConvert.SerializeObject(Movies, Formatting.Indented);
            File.WriteAllText(MOVIE_FILE, movieData);
        }

        public void AddCaterItem(CateringItem cateringItem)
        {
            CateringItems.Add(cateringItem);
            SaveCaterItemData();
        }

        public void DeleteCateringItem(CateringItem cateringItem)
        {
            CateringItems.Remove(cateringItem);
            SaveCaterItemData();
        }

        public void SaveCaterItemData()
        {
            var cateritemData = JsonConvert.SerializeObject(CateringItems, Formatting.Indented);
            File.WriteAllText(CATERINGITEM_FILE, cateritemData);
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
            SaveOrderData();
        }

        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);
            SaveOrderData();
        }

        public void SaveOrderData()
        {
            var orderitemData = JsonConvert.SerializeObject(Orders, Formatting.Indented);
            File.WriteAllText(ORDER_FILE, orderitemData);
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public List<Item> GetItems()
        {
            return Items;
        }

        public List<Auditorium> GetAuditoria()
        {
            return Auditoria;
        }


        public List<Movie> GetMovies()
        {
            return Movies;
        }


        public List<CateringItem> GetCateringItems()
        {
            return CateringItems;
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }

        public User GetUserByUsername(string username)
        {
            return Users.Find(u => u.Username == username);
        }

        public User GetUserByGUID(Guid guid)
        {
            return Users.Find(u => u.GUID == guid);
        }

        public Order GetOrderByID(short orderId)
        {
            return Orders.Find(o => o.OrderId == orderId);
        }

        public List<Order> GetOrdersByGUID(User user)
        {
            return Orders.FindAll(o => o.UserId == user.GUID);
        }
    }
}
