using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    struct SeatCoord
    {
        public int X;
        public int Y;

        public SeatCoord(int x , int y)
        {
            X = x;
            Y = y;
        }
    }

    class View_ReserveSeats : View
    {
        Movie Movie;
        List<SeatCoord> SeatCoords = new List<SeatCoord>();

        bool FirstDraw = true;
        int CurTop = 0;
        int CurLeft = 0;

        public View_ReserveSeats(Movie m, Controller controller, string title, string subTitle = "", int permLevel = 0)
           : base(controller, title, subTitle, permLevel)
        {
            Movie = m;
            return;
        }

        public override void Render()
        {
            DrawTitleBar();

            InternalRender();
        }

        void InternalRender()
        {
            if (FirstDraw)
            {
                CurTop = Console.CursorTop;
                CurLeft = Console.CursorLeft;
                FirstDraw = false;
            }
            else
            {
                Console.SetCursorPosition(CurLeft, CurTop);
            }

            var mapping = new SeatPriceMapping();

            int width = Movie.Auditorium.Seats.Length;
            int height = Movie.Auditorium.Seats[0].Length;

            for (int X = 0; X < width; X++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var p = X < 10 ? $"0{X}" : $"{X}";

                var o = X == 0 ? "   " : "";
                Console.Write($"{o}{p} ");
            }

            for (int Y = 0; Y < height; Y++)
            {
                Console.ForegroundColor = ConsoleColor.White;

                var p = Y < 10 ? $"0{Y}" : $"{Y}";
                Console.Write($"\n{p} ");

                for (int X = 0; X < width; X++)
                {
                    var seat = Movie.Auditorium.Seats[X][Y];

                    if (IsSeatInResverationList(X, Y) )
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;
                    if (Movie.Auditorium.Seats[X][Y].StockAvailable == 1)              
                        Console.ForegroundColor = mapping.ConsoleMapping.GetValueOrDefault(seat.Price);                   
                    else                   
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    
                    Console.Write("#");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("    |");
            for (int i = 0; i < width - 2; i++)
                Console.Write("---");
            Console.Write("|");



            Console.WriteLine("\n\nLegend:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("# €4,99 \t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("# €7,49 \t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("# €9,99 \t");
            Console.WriteLine("\n\n");


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Strings.EnterSeats + "\n");
            Console.WriteLine(Strings.EnterSeatsExample + "\n");

            string input = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop-1);
            for (int i = 0; i < input.Length; i++)
                Console.Write(" ");

            if (input.Equals(Strings.Cancel, StringComparison.OrdinalIgnoreCase))
            {
                Controller.SwitchView(new View_MovieCatalogue(Controller, Strings.MovCat));
            }

            if (input.Equals(Strings.Done, StringComparison.OrdinalIgnoreCase))
            {
                foreach( var SeatCoord in SeatCoords)
                {
                    Movie.Auditorium.Seats[SeatCoord.X][SeatCoord.Y].SetSeatName(Movie.Name + $"{SeatCoord.X}:{SeatCoord.Y}");
                    //Movie.Auditorium.Seats[SeatCoord.X][SeatCoord.Y].StockAvailable = 0;
                    Controller.Basket.AddItem(Movie.Auditorium.Seats[SeatCoord.X][SeatCoord.Y]);
                }

                Controller.SwitchView(new View_Basket(Controller, Strings.Basket));
            }

            var coordSet = input.Split(' ');

            foreach (var coord in coordSet)
            {
                try
                {
                    var seatCoord = coord.Split(',');
                    var x = seatCoord[0];
                    var y = seatCoord[1];

                    var ySplit = y.Split('*');
                    y = ySplit[0];
                    var amount = int.Parse(ySplit.Length == 2 ? ySplit[1] : "1");

                    int X = int.Parse(x);
                    int Y = int.Parse(y);

                    // Only continue with seat if coord is vailid
                    if (X > 0 && X < width && Y > 0 && Y < height && Movie.Auditorium.Seats[X][Y].StockAvailable == 1 && !IsSeatInResverationList(X,Y) )
                    {
                        SeatCoords.Add(new SeatCoord(X, Y));
                    }
                    
                } catch { }
            }

            InternalRender();
        }

        bool IsSeatInResverationList(int x, int y)
        {
            foreach (SeatCoord sc in SeatCoords)
                if (sc.X == x && sc.Y == y)
                    return true;

            return false;
        }
    }
}
