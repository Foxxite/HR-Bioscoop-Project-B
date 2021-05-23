using Newtonsoft.Json;
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
        [JsonProperty]
        public string Description { get; }
        
        [JsonProperty]
        public int AgeRating { get; }
        
        [JsonProperty]
        public double ReviewScore { get; }
        
        [JsonProperty]
        public string TrailerUrl { get; }

        [JsonProperty]
        public Auditorium Auditorium;

        /// <summary>
        /// Create a new instance of a Movie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="ageRating"></param>
        /// <param name="reviewScore"></param>
        /// <param name="trailerUrl"></param>
        /// <param name="auditorium"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        public Movie(String name, string description, int ageRating, double reviewScore, string trailerUrl, Auditorium auditorium = null, double price = 0.0, int stock = 0)
            : base(name, price, stock)
        {
            Description = description;
            AgeRating = ageRating;
            ReviewScore = reviewScore;
            TrailerUrl = trailerUrl;
            Auditorium = auditorium;
        }
       
        

        ///<summary>
        /// Methods to check if seats are available
        ///</summary>
        public new bool IsAvailable()
        {
            throw new NotImplementedException();
        }

        public void SetAuditorium(Auditorium auditorium)
        {
            Auditorium = auditorium;
        }
    }
}
