using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Menu : View
    {
        private List<Tuple<string, Action>> MenuOptions = new List<Tuple<string, Action>>();
        private bool MenuActive = false;
        private int SelectionIndex = 0;

        public Menu(Controller controller, string title, string subTitle = "", int permLevel = 0) 
            : base(controller, title, subTitle, permLevel)
        {
            return;
        }

        public void AddMenuOption(string name, Action callback)
        {
            MenuOptions.Add(Tuple.Create(name, callback));
        }

        public void AddMenuOptions(Tuple<string, Action>[] options)
        {
            foreach(Tuple<string, Action> option in options)
                MenuOptions.Add(option);
        }

        public override void Render()
        {
            RenderMenu();
            HandleUserInput();
        }

        private void RenderMenu()
        {
            MenuActive = true;

            Controller.ClearScreen();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"========== {Title} ==========");
            Console.WriteLine(!String.IsNullOrEmpty(SubTitle) ? SubTitle : "\n");

            for(int i = 0; i < MenuOptions.Count; i++)
            {
                // Convert Tuple to named Tuple
                (string name, Action cb) option = (MenuOptions[i].Item1, MenuOptions[i].Item2);

                // Write Selection Visual
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"  {(i == SelectionIndex ? "»" : " ")} ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i}: {option.name} \n");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n  Use the ↑ and ↓ keys to selection and item.");
            Console.WriteLine("  Press return to make your chooise.");
        }


        private void HandleUserInput()
        {
            while (MenuActive)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;
                char keyChar = keyInfo.KeyChar;

                if (key.Equals(ConsoleKey.UpArrow))
                {
                    SelectionIndex -= 1;
                    if (SelectionIndex < 0) SelectionIndex = MenuOptions.Count - 1;
                }

                if (key.Equals(ConsoleKey.DownArrow))
                {
                    SelectionIndex += 1;
                    if (SelectionIndex > MenuOptions.Count - 1) SelectionIndex = 0;
                }

                if (key.Equals(ConsoleKey.Enter))
                {
                    MenuActive = false;
                    MenuOptions[SelectionIndex].Item2();
                }

                if (MenuActive)
                    RenderMenu();
            }
        }
    }
}
