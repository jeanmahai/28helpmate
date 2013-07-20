using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Helpmate.UI.Forms.Models
{
    public class SpecialNumberModel
    {
        public SpecialNumberModel()
        {
            Title = "平均开奖次数";
            StableTitle = "最稳定的号码";
        }

        public string Title { get; set; }
        public string NumberOne { get; set; }
        public string NumberTwo { get; set; }
        public string NumberThree { get; set; }
        public string NumberFour { get; set; }
        public string NumberFive { get; set; }
        public string NumberSix { get; set; }

        public string StableTitle { get; set; }
        public Image StableNumberOne { get; set; }
        public Image StableNumberTwo { get; set; }
        public Image StableNumberThree { get; set; }
    }
}
