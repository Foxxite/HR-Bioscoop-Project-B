﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Menu : View
    {
        public Menu(Controller controller, string title, string subTitle = "", int permLevel = 0) : base(controller, title, subTitle, permLevel)
        {
            return;
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
