using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Cinema_App
{
    public class SeatPriceMapping
    {
        private Dictionary<Color, double> PriceMapping = new Dictionary<Color, double>();
        private Dictionary<double, ConsoleColor> ConsoleColorMapping = new Dictionary<double, ConsoleColor>();

        /// <summary>
        /// Creates pricemap for the seats.
        /// </summary>
        public SeatPriceMapping()
        {
            PriceMapping.Add(Color.FromArgb(255, 255, 0, 0), 9.99);
            PriceMapping.Add(Color.FromArgb(255, 0, 255, 0), 7.49);
            PriceMapping.Add(Color.FromArgb(255, 0, 0, 255), 4.99);

            ConsoleColorMapping.Add(9.99, ConsoleColor.Red);
            ConsoleColorMapping.Add(7.49, ConsoleColor.Yellow);
            ConsoleColorMapping.Add(4.99, ConsoleColor.Blue);
            ConsoleColorMapping.Add(0.00, ConsoleColor.Black);
        }

        public Dictionary<Color, double> Mapping
        {
            get
            {
                return PriceMapping;
            }
        }

        public Dictionary<double, ConsoleColor> ConsoleMapping
        {
            get
            {
                return ConsoleColorMapping;
            }
        }
    }


    /// <summary>
    ///     Class representing an auditorium.
    /// </summary>
    /// <param name = "Name">Name of the auditorium.</param>
    /// <param name = "Seat">Number of the seat.</param>
    /// 

    class Auditorium
    {
        [JsonProperty]
        public string Name;
        [JsonProperty]
        public Seat[][] Seats;

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
