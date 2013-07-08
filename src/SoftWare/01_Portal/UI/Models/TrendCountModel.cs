using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;

namespace Helpmate.UI.Forms.Models
{
    public class TrendCountModel
    {
        public TrendCountModel()
        {
            Times = "次数";
            T0 = "0";
            T1 = "1";
            T2 = "2";
            T3 = "3";
            T4 = "4";
            T5 = "5";
            T6 = "6";
            T7 = "7";
            T8 = "8";
            T9 = "9";
            T10 = "10";
            T11 = "11";
            T12 = "12";
            T13 = "13";
            T14 = "14";
            T15 = "15";
            T16 = "16";
            T17 = "17";
            T18 = "18";
            T19 = "19";
            T20 = "20";
            T21 = "21";
            T22 = "22";
            T23 = "23";
            T24 = "24";
            T25 = "25";
            T26 = "26";
            T27 = "27";
            Odd = "64";
            Dual = "134";
            Middle = "43";
            Side = "16";
            Big = "12";
            Small = "43";
        }
        public string Times { get; set; }
        public string T0 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
        public string T10 { get; set; }
        public string T11 { get; set; }
        public string T12 { get; set; }
        public string T13 { get; set; }
        public string T14 { get; set; }
        public string T15 { get; set; }
        public string T16 { get; set; }
        public string T17 { get; set; }
        public string T18 { get; set; }
        public string T19 { get; set; }
        public string T20 { get; set; }
        public string T21 { get; set; }
        public string T22 { get; set; }
        public string T23 { get; set; }
        public string T24 { get; set; }
        public string T25 { get; set; }
        public string T26 { get; set; }
        public string T27 { get; set; }
        public string Odd { get; set; }
        public string Dual { get; set; }
        public string Middle { get; set; }
        public string Side { get; set; }
        public string Big { get; set; }
        public string Small { get; set; }

        public List<TrendCountModel> GetCountList(LotteryTimes[] data)
        {
            List<TrendCountModel> headerList = new List<TrendCountModel>();
            TrendCountModel count = new TrendCountModel();
            if (data != null && data.Length > 0)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    switch (data[i].Name)
                    {
                        case "0":
                            count.T0 = data[i].Total.ToString();
                            break;
                        case "1":
                            count.T1 = data[i].Total.ToString();
                            break;
                        case "2":
                            count.T2 = data[i].Total.ToString();
                            break;
                        case "3":
                            count.T3 = data[i].Total.ToString();
                            break;
                        case "4":
                            count.T4 = data[i].Total.ToString();
                            break;
                        case "5":
                            count.T5 = data[i].Total.ToString();
                            break;
                        case "6":
                            count.T6 = data[i].Total.ToString();
                            break;
                        case "7":
                            count.T7 = data[i].Total.ToString();
                            break;
                        case "8":
                            count.T8 = data[i].Total.ToString();
                            break;
                        case "9":
                            count.T9 = data[i].Total.ToString();
                            break;
                        case "10":
                            count.T10 = data[i].Total.ToString();
                            break;
                        case "11":
                            count.T11 = data[i].Total.ToString();
                            break;
                        case "12":
                            count.T13 = data[i].Total.ToString();
                            break;
                        case "14":
                            count.T14 = data[i].Total.ToString();
                            break;
                        case "15":
                            count.T15 = data[i].Total.ToString();
                            break;
                        case "16":
                            count.T16 = data[i].Total.ToString();
                            break;
                        case "17":
                            count.T17 = data[i].Total.ToString();
                            break;
                        case "18":
                            count.T18 = data[i].Total.ToString();
                            break;
                        case "19":
                            count.T19 = data[i].Total.ToString();
                            break;
                        case "20":
                            count.T20 = data[i].Total.ToString();
                            break;
                        case "21":
                            count.T21 = data[i].Total.ToString();
                            break;
                        case "22":
                            count.T22 = data[i].Total.ToString();
                            break;
                        case "23":
                            count.T23 = data[i].Total.ToString();
                            break;
                        case "24":
                            count.T24 = data[i].Total.ToString();
                            break;
                        case "25":
                            count.T25 = data[i].Total.ToString();
                            break;
                        case "26":
                            count.T26 = data[i].Total.ToString();
                            break;
                        case "27":
                            count.T27 = data[i].Total.ToString();
                            break;
                        case "大":
                            count.Big = data[i].Total.ToString();
                            break;
                        case "小":
                            count.Small = data[i].Total.ToString();
                            break;
                        case "中":
                            count.Middle = data[i].Total.ToString();
                            break;
                        case "边":
                            count.Side = data[i].Total.ToString();
                            break;
                        case "单":
                            count.Odd = data[i].Total.ToString();
                            break;
                        case "双":
                            count.Dual = data[i].Total.ToString();
                            break;
                    }
                }
            }
            headerList.Add(count);
            return headerList;
        }
    }
}
