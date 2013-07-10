using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Model
{
    public class AppSettingValues
    {
        public static int PageCount
        {
            get { return int.Parse(ConfigurationManager.AppSettings["PageCount"]); }
        }
        public static int MaxTotal
        {
            get { return int.Parse(ConfigurationManager.AppSettings["MaxTotal"]); }
        }
        public static int BJLotteryInteval
        {
            get { return int.Parse(ConfigurationManager.AppSettings["BJLotteryInteval"]); }
        }
        public static int CanadaLotteryInteval
        {
            get { return int.Parse(ConfigurationManager.AppSettings["CanadaLotteryInteval"]); }
        }
    }
}
