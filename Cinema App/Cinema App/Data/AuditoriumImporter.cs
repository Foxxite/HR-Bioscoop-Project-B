using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;


namespace Cinema_App 
{
    class AuditoriumImporter
    {
        public Auditorium Auditorium;

        Controller Controller;
        /// <summary>
        /// Creates auditorium using png file
        /// </summary>
        /// <param name="controller"></param>
        public AuditoriumImporter(Controller controller)
        {
            Controller = controller;

            string AuditoriumName = "";
            Console.WriteLine("Enter the auditorium name: ");
            AuditoriumName = Console.ReadLine();

            Auditorium = new Auditorium(AuditoriumName);

            string FilePath = "";

            Console.WriteLine("Enter absolute path for image file: ");
            FilePath = Console.ReadLine();

            if (File.Exists(FilePath))
            {
                ParseImageData(FilePath);
            }
        }
        
        /// <summary>
        /// Parses image data and creates a new jagged Seat array.
        /// </summary>
        /// <param name="fp"></param>
        void ParseImageData(string fp)
        {
            Bitmap img = new Bitmap(fp);

            Seat[][] seats = new Seat[img.Width][];

            for (int x = 0; x < img.Width; x++)
            {
                seats[x] = new Seat[img.Height];

                for (int y = 0; y < img.Height; y++)
                {
                    Color pixel = img.GetPixel(x, y);
                    if (!pixel.Equals(Color.White))
                    {
                        var PriceMap = new SeatPriceMapping();
                        seats[x][y] = new Seat($"{x}:{y}", PriceMap.Mapping.GetValueOrDefault(pixel), 1);
                    }
                    else
                    {
                        seats[x][y] = null;
                    }
                }
            }

            Auditorium.SetSeats(seats);
            Controller.DataStore.AddAuditorium(Auditorium);
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
