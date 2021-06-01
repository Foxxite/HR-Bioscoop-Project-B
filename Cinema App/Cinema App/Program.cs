using System;

namespace Cinema_App
{
    class Program
    {
        public static int ADMIN_PERM_LEVEL = 777;

        private static Controller Controller;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ToDo Setup Main menu
            Controller = new Controller(args);
        }
    }
}
