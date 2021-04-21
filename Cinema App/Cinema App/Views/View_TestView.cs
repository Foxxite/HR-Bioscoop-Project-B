using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class View_TestView : View
    {
        public View_TestView(Controller controller, string title, string subTitle = "", int permLevel = 0) : base(controller, title, subTitle, permLevel)
        {
            ShowPermError();
            return;
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
