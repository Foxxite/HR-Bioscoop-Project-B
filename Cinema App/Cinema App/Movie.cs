using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Movie : Item
    {
        private string Description;
        private int AgeRating;
        private int ReviewScore;
        private string TrailerUrl;
        private Auditorium Auditorium;

        public override bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
