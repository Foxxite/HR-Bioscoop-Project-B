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
        Dictionary<Color, double> PriceMapping = new Dictionary<Color, double>();
        public Auditorium Auditorium;

        Controller Controller;
        public AuditoriumImporter(Controller controller)
        {
            Controller = controller;

            PriceMapping.Add(Color.FromArgb(255, 255, 0, 0), 9.99);
            PriceMapping.Add(Color.FromArgb(255, 0, 255, 0), 7.49);
            PriceMapping.Add(Color.FromArgb(255, 0, 0, 255), 4.99);

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
                        seats[x][y] = new Seat($"{x}:{y}", PriceMapping.GetValueOrDefault(pixel), 1);
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
