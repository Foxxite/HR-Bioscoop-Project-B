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

        private string USER_FILE = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/users.json";
        private string ITEM_FILE = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/items.json";

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

            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(USER_FILE));
            if (users != null)
                Users = users;

            var items = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(ITEM_FILE));
            if (items != null)
                Items = items;
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveUserData();
        }

        private void SaveUserData()
        {
            var userData = JsonConvert.SerializeObject(Users);
            File.WriteAllText(USER_FILE, userData);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            SaveItemData();
        }

        private void SaveItemData()
        {
            var itemData = JsonConvert.SerializeObject(Items);
            File.WriteAllText(ITEM_FILE, itemData);
        }
    }
}
