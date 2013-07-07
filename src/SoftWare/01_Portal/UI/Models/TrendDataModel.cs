using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Helpmate.UI.Forms.Properties;

namespace Helpmate.UI.Forms.Models
{
    public class TrendDataModel
    {
        public TrendDataModel()
        {
            Bitmap TNA = Resources.na;
            Bitmap TNAColor = Resources.nacolor;
            T0 = TNAColor;
            T1 = TNAColor;
            T2 = TNAColor;
            T3 = TNAColor;
            T4 = TNAColor;
            T5 = TNAColor;
            T6 = TNAColor;
            T7 = TNAColor;
            T8 = TNAColor;
            T9 = TNAColor;
            T10 = TNA;
            T11 = TNA;
            T12 = TNA;
            T13 = TNA;
            T14 = TNA;
            T15 = TNA;
            T16 = TNA;
            T17 = TNA;
            T18 = TNAColor;
            T19 = TNAColor;
            T20 = TNAColor;
            T21 = TNAColor;
            T22 = TNAColor;
            T23 = TNAColor;
            T24 = TNAColor;
            T25 = TNAColor;
            T26 = TNAColor;
            T27 = TNAColor;
            Odd = "";
            Dual = "双";
            Middle = "";
            Side = "边";
            Big = "大";
            Small = "";
        }
        public long PeriodNum { get; set; }
        public string RetTime { get; set; }
        public System.Drawing.Bitmap T0 { get; set; }
        public Bitmap T1 { get; set; }
        public Bitmap T2 { get; set; }
        public Bitmap T3 { get; set; }
        public Bitmap T4 { get; set; }
        public Bitmap T5 { get; set; }
        public Bitmap T6 { get; set; }
        public Bitmap T7 { get; set; }
        public Bitmap T8 { get; set; }
        public Bitmap T9 { get; set; }
        public Bitmap T10 { get; set; }
        public Bitmap T11 { get; set; }
        public Bitmap T12 { get; set; }
        public Bitmap T13 { get; set; }
        public Bitmap T14 { get; set; }
        public Bitmap T15 { get; set; }
        public Bitmap T16 { get; set; }
        public Bitmap T17 { get; set; }
        public Bitmap T18 { get; set; }
        public Bitmap T19 { get; set; }
        public Bitmap T20 { get; set; }
        public Bitmap T21 { get; set; }
        public Bitmap T22 { get; set; }
        public Bitmap T23 { get; set; }
        public Bitmap T24 { get; set; }
        public Bitmap T25 { get; set; }
        public Bitmap T26 { get; set; }
        public Bitmap T27 { get; set; }
        public string Odd { get; set; }
        public string Dual { get; set; }
        public string Middle { get; set; }
        public string Side { get; set; }
        public string Big { get; set; }
        public string Small { get; set; }
    }
}
