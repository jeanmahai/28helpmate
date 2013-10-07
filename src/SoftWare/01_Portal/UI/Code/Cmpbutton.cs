using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Helpmate.UI.Forms.Code
{
    public class Cmpbutton : Button
    {
        public Cmpbutton()
        {
            
        }

        protected override bool ShowFocusCues
        {
            get { return false; }
        }
    }
}
