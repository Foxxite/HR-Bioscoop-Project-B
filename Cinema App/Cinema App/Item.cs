using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    abstract class Item
    {
        protected string Name;
        protected double Price;
        protected int StockAvailable;

        public abstract bool IsAvailable();
    }
}
