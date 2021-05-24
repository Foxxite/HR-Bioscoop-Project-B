using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Seat : Item
    {

        public Seat(String name, double price = 0.0, int stock = 0)
            : base(name, price, stock)
        {
            return;
        }

        public new bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
