using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    struct MenuItem
    {
        public String name { get; }
        public Action<dynamic> callback { get; }
        public dynamic cbValue { get;  }

        public MenuItem(string name, Action<dynamic> callback, dynamic cbValue)
        {
            this.name = name;
            this.callback = callback;
            this.cbValue = cbValue;
        }
    }

    /// <summary>
    /// Renders and handles user input for a full screen console menu.
    /// </summary>
    class Menu : View
    {
        private List<MenuItem> MenuOptions = new List<MenuItem>();
        private bool MenuActive = false;
        private int SelectionIndex = 0;
        private bool FullScreen = true;

        private int CurLeft = 0;
        private int CurTop = 0;
        private bool FirstDraw = true;

        /// <summary>
        /// Setups the Menu class with basic info based on View.
        /// </summary>
        /// <param name="controller">Reference to the Application Controller.</param>
        /// <param name="title">Menu Title</param>
        /// <param name="subTitle">Menu Subtitle (can be used for description).</param>
        /// <param name="permLevel">Permission level needed to view.</param>
        public Menu(Controller controller, string title, string subTitle = "", int permLevel = 0, bool fullScreen = true) 
            : base(controller, title, subTitle, permLevel)
        {
            FullScreen = fullScreen;
            return;
        }

        /// <summary>
        /// Adds an option to the menu.
        /// </summary>
        /// <param name="name">Name displayed in the menu.</param>
        /// <param name="callback">Action (void) to call when option is selected, will be passed the Callback Value.</param>
        /// <param name="cbValue">Any value to be passed to the callback.</param>
        public void AddMenuOption(string name, Action<dynamic> callback, dynamic cbValue)
        {
            MenuOptions.Add(new MenuItem(name, callback, cbValue));
        }

        /// <summary>
        /// Adds an emtpy line into the menu
        /// </summary>
        public void AddEmptyLine()
        {
            MenuOptions.Add(new MenuItem("", null, null));
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

            if (FullScreen && FirstDraw)
            {
                Controller.ClearScreen();

                DrawTitleBar();
            }

            if (FirstDraw)
            {
                CurLeft = Console.CursorLeft;
                CurTop = Console.CursorTop;
                FirstDraw = false;
            }

            Console.SetCursorPosition(CurLeft, CurTop);

            for(int i = 0; i < MenuOptions.Count; i++)
            {
                MenuItem option = MenuOptions[i];

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
                    MenuItem selectedOption = MenuOptions[SelectionIndex];

                    selectedOption.callback(selectedOption.cbValue);
                }

                if (MenuActive)
                    RenderMenu();
            }
        }
    }
}
