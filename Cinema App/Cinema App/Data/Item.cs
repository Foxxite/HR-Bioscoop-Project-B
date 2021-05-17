using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    ///<summary>
    /// Makes a new class called Item
    ///</summary>
    class Item
    {
        public string Name { get;  }
        public double Price { get; }
        public int StockAvailable { get; }

        /// <summary>
        /// Create a new instance of an Item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>        
        public Item(String name, double price = 0.0, int stock = 0)
        {
            Name = name;
            Price = price;
            StockAvailable = stock;
        }

        public bool IsAvailable() { return false; }

        ///<summary>
        /// Method to check if seats are available
        ///</summary>
    }
}
