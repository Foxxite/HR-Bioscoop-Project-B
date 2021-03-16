using System;

namespace Cinema_App
{
    class Program
    {
        private static Controller Controller;

        static void Main(string[] args)
        {
            // ToDo Setup Main menu
            Controller = new Controller(args);
        }
    }
}
