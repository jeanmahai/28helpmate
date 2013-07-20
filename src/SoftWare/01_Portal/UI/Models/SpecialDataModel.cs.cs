using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.UI.Forms.Models
{
    public class SpecialDataModel
    {
        public SpecialDataModel()
        {
            LookTitle = "查看";
        }

        public string Date { get; set; }

        public string Big { get; set; }

        public string Small { get; set; }

        public string Odd { get; set; }

        public string Dual { get; set; }

        public string Middle { get; set; }

        public string Side { get; set; }

        public string NoAppearNum { get; set; }

        public string BestNum { get; set; }

        public string LookTitle { get; set; }
    }
}
