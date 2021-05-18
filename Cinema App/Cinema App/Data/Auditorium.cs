using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    /// <summary>
    ///     Class representing an auditorium.
    /// </summary>
    /// <param name = "Name">Name of the auditorium.</param>
    /// <param name = "Seat">Number of the seat.</param>
    class Auditorium
    {
        [JsonProperty]
        private string Name;
        [JsonProperty]
        private Seat[][] Seats;

        public Auditorium(string name)
        {
            Name = name;
        }
        
        [JsonConstructor]
        public Auditorium(string name, Seat[][] seats)
        {
            Name = name;
            Seats = seats;
        }

        public void SetSeats(Seat[][] seats)
        {
            Seats = seats;
        }
    }
}
