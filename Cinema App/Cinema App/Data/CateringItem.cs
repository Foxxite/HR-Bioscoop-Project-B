using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    /// <summary> 
    /// inheritates the item class
    /// </summary>
    class CateringItem : Item
    {
        public string Description { get; }


        /// <summary>
        /// Create a new instance of a Catering
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        public CateringItem(String name, double price = 0.0, int stock = 0)
            : base(name, price, stock)
        {

        }
        
        ///<summary>
        /// Methods to check if seats are available
        ///</summary>
        public new bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}