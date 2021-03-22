using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Seat : Item
    {
        private int[][] Position;
        private Auditorium Auditorium;

        public override bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
