using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;

namespace Cinema_App
{
    abstract class View
    {
        protected Controller Controller;
        protected string Title;
        protected string SubTitle = "";
        protected int NeededPermLevel = 0;

        /// <summary>
        ///     Base View Class.
        ///     Define default behavior for any view.
        /// </summary>
        /// <param name = "controller">Reference to the application controller.</param>
        /// <param name = "title">Title of view.</param>
        /// <param name = "subTitle">Sub title of view.</param>
        /// <param name = "permLevel">Permission level needed to view View, default 0 (everyone).</param>
        public View(Controller controller, string title, string subTitle = "", int permLevel = 0)
        {
            Controller = controller;
            Title = title;
            SubTitle = subTitle;
            NeededPermLevel = permLevel;
        }

        /// <summary>
        ///     The Views render behavior.
        /// </summary>
        abstract public void Render();

        /// <summary>
        /// Draw's the views title bar
        /// </summary>
        public void DrawTitleBar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"========== {Title} ========== \t {(Controller.CurrentUser != null ? "Welcome " + Controller.CurrentUser.Name : "")}");
            Console.WriteLine(!String.IsNullOrEmpty(SubTitle) ? $"  {SubTitle}\n" : "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///     Determines if the user has the permission to view.
        /// </summary>
        /// <param name="user">The user you want to check the permission of.</param>
        /// <returns>True if user can view, else False.</returns>
        public bool CanView(User user)
        {
            return true;
        }

        /// <summary>
        ///     Waiting for user class to be implemented...
        /// </summary>
        protected void ShowPermError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Strings.ViewPermError);

            Console.WriteLine("\n\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Strings.ReturnToMain);

            // Wait for user to press any key and return to main menu.
            Console.ReadKey(); 
            Controller.ShowMainMenu();
        }

        /// <summary>
        /// Write a long string pritty to the console
        /// </summary>
        /// <param name="paragraph"></param>
        protected void WordWrap(string paragraph)
        {
            if(paragraph.Length < 100)
                Console.WriteLine(paragraph);
            else
            {
                paragraph = new Regex(@" {2,}").Replace(paragraph.Trim(), @" ");
                var left = Console.CursorLeft; var top = Console.CursorTop; var lines = new List<string>();

                for (var i = 0; paragraph.Length > 0; i++)
                {
                    lines.Add(paragraph.Substring(0, Math.Min(Console.WindowWidth, paragraph.Length)));
                    var length = lines[i].LastIndexOf(" ", StringComparison.Ordinal);

                    if (length > 0) lines[i] = lines[i].Remove(length);

                    paragraph = paragraph.Substring(Math.Min(lines[i].Length + 1, paragraph.Length));

                    Console.SetCursorPosition(left, top + i);
                    Console.WriteLine(lines[i]);
                }
            }
        }
    }
}
