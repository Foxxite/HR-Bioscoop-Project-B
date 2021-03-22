using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Movie : Item

        /// <summary> 
        /// inheritates the item class
        /// </summary>
    {
        private string Description;
        private int AgeRating;
        private int ReviewScore;
        private string TrailerUrl;
        private Auditorium Auditorium;

        /// <summary>
        /// Description = shows a description of the movie as a string
        /// AgeRating = shows what the minimum age of a movie is as a integer
        /// ReviewScore = the score of the movie based on the reviews given by people as a integer
        /// TrailerUrl = gives a link to the trailer of the movie as a string
        /// Auditorium = shows how many seats are left in the auditorium to reserve by the people
        /// </summary>
        /// <returns></returns>
        public override bool IsAvailable()
        {
            throw new NotImplementedException();

            ///<summary>
            ///methods to check if seats are available
            ///</summary>
        }
    }
}
