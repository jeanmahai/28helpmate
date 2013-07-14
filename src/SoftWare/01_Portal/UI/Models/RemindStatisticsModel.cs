using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebSvc;

namespace Helpmate.UI.Forms.Models
{
    public class RemindStatisticsModel
    {
        public string Game { get; set; }
        public string Source { get; set; }
        public string Site { get; set; }
        public string RetNum { get; set; }
        public string Cnt { get; set; }
        //public string Opt { get; set; }

        public List<RemindStatisticsModel> GetHeader()
        {
            List<RemindStatisticsModel> result = new List<RemindStatisticsModel>();
            RemindStatisticsModel item = new RemindStatisticsModel();
            item.Game = "游戏";
            item.Source = "源";
            item.Site = "网站";
            item.RetNum = "结果";
            item.Cnt = "次数";
            //item.Opt = "操作";
            result.Add(item);
            return result;
        }
        public List<RemindStatisticsModel> GetDataList(RemindStatistics[] data)
        {
            List<RemindStatisticsModel> result = new List<RemindStatisticsModel>();
            if (data != null && data.Length > 0)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    RemindStatistics _item = data[i];
                    RemindStatisticsModel item = new RemindStatisticsModel();
                    //item.Opt = _item.SysNo.ToString();
                    item.Game = GetGameName(_item.GameSysNo);
                    item.Source = GetSourceName(_item.SourceSysNo);
                    item.Site = GetSiteName(_item.SiteSysNo);
                    item.RetNum = _item.RetNum.ToString();
                    item.Cnt = _item.Cnt.ToString();
                    result.Add(item);
                }
            }
            return result;
        }
        private string GetGameName(int sysNo)
        {
            string result = "";
            switch (sysNo)
            {
                case 10001:
                    result = "28游戏";
                    break;
            }
            return result;
        }
        private string GetSourceName(int sysNo)
        {
            string result = "";
            switch (sysNo)
            {
                case 10001:
                    result = "北京";
                    break;
                case 10002:
                    result = "加拿大";
                    break;
            }
            return result;
        }
        private string GetSiteName(int sysNo)
        {
            string result = "";
            switch (sysNo)
            {
                case 10001:
                    result = "53游";
                    break;
                case 10002:
                    result = "71豆";
                    break;
                case 10003:
                    result = "芝麻西西";
                    break;
            }
            return result;
        }
    }
}
