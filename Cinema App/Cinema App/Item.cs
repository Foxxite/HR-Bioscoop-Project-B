using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    abstract class Item

        ///<summary>
        ///makes a new class called Item
        ///</summary>
    {
        protected string Name;
        protected double Price;
        protected int StockAvailable;

        /// <summary>
        /// Name = gives the name of the movie as a string
        /// Price = gives the price of the movie as a double
        /// StockAvailable = shows what stock is available as a integer
        /// </summary>
        /// <returns></returns>

        public abstract bool IsAvailable();

        ///<summary>
        ///method to check if seats are available
        ///</summary>
    }
}
