using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    /// <summary>
    /// Renders and handles user input for a full screen console menu.
    /// </summary>
    class Menu : View
    {
        private List<Tuple<string, Action>> MenuOptions = new List<Tuple<string, Action>>();
        private bool MenuActive = false;
        private int SelectionIndex = 0;

        /// <summary>
        /// Setups the Menu class with basic info based on View.
        /// </summary>
        /// <param name="controller">Reference to the Application Controller.</param>
        /// <param name="title">Menu Title</param>
        /// <param name="subTitle">Menu Subtitle (can be used for description).</param>
        /// <param name="permLevel">Permission level needed to view.</param>
        public Menu(Controller controller, string title, string subTitle = "", int permLevel = 0) 
            : base(controller, title, subTitle, permLevel)
        {
            return;
        }

        /// <summary>
        /// Adds an option to the menu.
        /// </summary>
        /// <param name="name">Name displayed in the menu.</param>
        /// <param name="callback">Methoud (void) to call when option is selected.</param>
        public void AddMenuOption(string name, Action callback)
        {
            MenuOptions.Add(Tuple.Create(name, callback));
        }

        /// <summary>
        /// Adds multiple options to the menu.
        /// </summary>
        /// <param name="options">
        /// A tuple of type (String, Action) containing;
        /// <para>Name displayed in the menu.</para>
        /// <para>Methoud (void) to call when option is selected.</para>
        /// </param>
        public void AddMenuOption(Tuple<string, Action>[] options)
        {
            foreach(Tuple<string, Action> option in options)
                MenuOptions.Add(option);
        }

        /// <summary>
        /// Adds an emtpy line into the menu
        /// </summary>
        public void AddEmptyLine()
        {
            MenuOptions.Add(new Tuple<string, Action<dynamic>>(Strings.EmptyString, null));
        }

        /// <summary>
        /// Triggers rendering of the menu and the handling of user input.
        /// </summary>
        public override void Render()
        {
            RenderMenu();
            HandleUserInput();
        }

        /// <summary>
        /// Renders the menu.
        /// </summary>
        private void RenderMenu()
        {
            MenuActive = true;

            Controller.ClearScreen();

            DrawTitleBar();

            for(int i = 0; i < MenuOptions.Count; i++)
            {
                // Convert Tuple to named Tuple
                (string name, Action cb) option = (MenuOptions[i].Item1, MenuOptions[i].Item2);

                if(option.name != Strings.EmptyString)
                {
                    // Write Selection Visual
                    if (i == SelectionIndex)
                    {
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("» ");
                    }
                    else
                    {
                        Console.Write("   ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write($"{i}: {option.name} \n");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                    Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Strings.PressArrow);
            Console.WriteLine(Strings.PressReturn);
        }

        /// <summary>
        /// Handles the user's input and calls the right callback when an option is selected.
        /// </summary>
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
                else if (key.Equals(ConsoleKey.DownArrow))
                {
                    SelectionIndex += 1;
                    if (SelectionIndex > MenuOptions.Count - 1) SelectionIndex = 0;
                }
                else if (key.Equals(ConsoleKey.Enter))
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
