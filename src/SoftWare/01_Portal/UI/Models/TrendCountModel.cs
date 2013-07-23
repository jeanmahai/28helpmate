using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebSvc;

namespace Helpmate.UI.Forms.Models
{
    public class TrendCountModel
    {
        public TrendCountModel()
        {
            Times = "次数";
            T0 = "0";
            T1 = "0";
            T2 = "0";
            T3 = "0";
            T4 = "0";
            T5 = "0";
            T6 = "0";
            T7 = "0";
            T8 = "0";
            T9 = "0";
            T10 = "0";
            T11 = "0";
            T12 = "0";
            T13 = "0";
            T14 = "0";
            T15 = "0";
            T16 = "0";
            T17 = "0";
            T18 = "0";
            T19 = "0";
            T20 = "0";
            T21 = "0";
            T22 = "0";
            T23 = "0";
            T24 = "0";
            T25 = "0";
            T26 = "0";
            T27 = "0";
            Odd = "0";
            Dual = "0";
            Middle = "0";
            Side = "0";
            Big = "0";
            Small = "0";
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
                            count.T12 = data[i].Total.ToString();
                            break;
                        case "13":
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
