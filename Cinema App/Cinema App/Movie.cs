using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    /// <summary> 
    /// inheritates the item class
    /// </summary>
    class Movie : Item
    {
        public string Description { get; }
        public int AgeRating { get; }
        public double ReviewScore { get; }
        public string TrailerUrl { get; }
        public Auditorium Auditorium { get; }

        /// <summary>
        /// Create a new instance of a Movie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="ageRating"></param>
        /// <param name="reviewScore"></param>
        /// <param name="trailerUrl"></param>
        /// <param name="auditorium"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        public Movie(String name, string desc, int ageRating, double reviewScore, string trailerUrl, Auditorium auditorium = null, double price = 0.0, int stock = 0)
            : base(name, price, stock)
        {
            Description = desc;
            AgeRating = ageRating;
            ReviewScore = reviewScore;
            TrailerUrl = trailerUrl;
            Auditorium = auditorium;
        }
       


        ///<summary>
        /// Methods to check if seats are available
        ///</summary>
        public override bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
