using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.UI.Forms.Models
{
    public class OmissionHeadModel
    {
        public OmissionHeadModel()
        {
            TitleOne = "号码";
            TitleTwo = "当前遗漏期数";
            TitleThree = "最长遗漏期数";
            TitleFour = "标准遗漏期数";
            TitleFive = "号码";
            TitleSix = "当前遗漏期数";
            TitleSeven = "最长遗漏期数";
            TitleEight = "标准遗漏期数";
        }

        public string TitleOne { get; set; }
        public string TitleTwo { get; set; }
        public string TitleThree { get; set; }
        public string TitleFour { get; set; }
        public string TitleFive { get; set; }
        public string TitleSix { get; set; }
        public string TitleSeven { get; set; }
        public string TitleEight { get; set; }
    }
}
