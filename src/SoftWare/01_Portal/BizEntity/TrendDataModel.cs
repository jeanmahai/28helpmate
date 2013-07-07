using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Helpmate.BizEntity
{
    public class TrendDataModel
    {
        public TrendDataModel()
        {
            byte[] TNA = File.ReadAllBytes("Resources/data/na.gif");
            byte[] TNAColor = File.ReadAllBytes("Resources/data/nacolor.gif");
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
        public byte[] T0 { get; set; }
        public byte[] T1 { get; set; }
        public byte[] T2 { get; set; }
        public byte[] T3 { get; set; }
        public byte[] T4 { get; set; }
        public byte[] T5 { get; set; }
        public byte[] T6 { get; set; }
        public byte[] T7 { get; set; }
        public byte[] T8 { get; set; }
        public byte[] T9 { get; set; }
        public byte[] T10 { get; set; }
        public byte[] T11 { get; set; }
        public byte[] T12 { get; set; }
        public byte[] T13 { get; set; }
        public byte[] T14 { get; set; }
        public byte[] T15 { get; set; }
        public byte[] T16 { get; set; }
        public byte[] T17 { get; set; }
        public byte[] T18 { get; set; }
        public byte[] T19 { get; set; }
        public byte[] T20 { get; set; }
        public byte[] T21 { get; set; }
        public byte[] T22 { get; set; }
        public byte[] T23 { get; set; }
        public byte[] T24 { get; set; }
        public byte[] T25 { get; set; }
        public byte[] T26 { get; set; }
        public byte[] T27 { get; set; }
        public string Odd { get; set; }
        public string Dual { get; set; }
        public string Middle { get; set; }
        public string Side { get; set; }
        public string Big { get; set; }
        public string Small { get; set; }
    }
}
