using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.UI.Forms.Models
{
    public class SpecialTrendModel
    {
        public SpecialTrendModel()
        {
            Title = "输赢天数对比";
            AriseTitle = "出现天数/次数";
        }

        public string Title { get; set; }
        public string NumberOne { get; set; }
        public string NumberTwo { get; set; }
        public string NumberThree { get; set; }
        public string NumberFour { get; set; }
        public string NumberFive { get; set; }
        public string NumberSix { get; set; }

        public string AriseTitle { get; set; }
        public string AriseNumberOne { get; set; }
        public string AriseNumberTwo { get; set; }
        public string AriseNumberThree { get; set; }
    }
}
