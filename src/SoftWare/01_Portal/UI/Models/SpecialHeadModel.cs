using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.UI.Forms.Models
{
    public class SpecialHeadModel
    {
        public SpecialHeadModel()
        {
            TitleOne = "开奖时间";
            TitleTwo = "大";
            TitleThree = "小";
            TitleFour = "单";
            TitleFive = "双";
            TitleSix = "中";
            TitleSeven = "边";
            TitleEight = "未出现号码";
            TitleNine = "极品号";
            TitleTen = "详情";
        }

        public string TitleOne { get; set; }
        public string TitleTwo { get; set; }
        public string TitleThree { get; set; }
        public string TitleFour { get; set; }
        public string TitleFive { get; set; }
        public string TitleSix { get; set; }
        public string TitleSeven { get; set; }
        public string TitleEight { get; set; }
        public string TitleNine { get; set; }
        public string TitleTen { get; set; }
    }
}
