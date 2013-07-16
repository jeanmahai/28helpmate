using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebSvc;
using Common.Utility;

namespace Helpmate.UI.Forms.Models
{
    public class RemindStatisticsModel
    {
        public string SysNo { get; set; }
        public string Game { get; set; }
        public string Source { get; set; }
        public string Site { get; set; }
        public string RetNum { get; set; }
        public string Cnt { get; set; }

        public List<RemindStatisticsModel> GetDefaultList()
        {
            List<RemindStatisticsModel> result = new List<RemindStatisticsModel>();
            RemindStatisticsModel item = new RemindStatisticsModel();
            item.SysNo = "11";
            item.Game = "28游戏";
            item.Source = "北京";
            item.Site = "71豆";
            item.RetNum = "5";
            item.Cnt = "3";
            result.Add(item);
            item = new RemindStatisticsModel();
            item.SysNo = "11";
            item.Game = "28游戏";
            item.Source = "北京";
            item.Site = "71豆";
            item.RetNum = "5";
            item.Cnt = "3";
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
                    item.SysNo = _item.SysNo.ToString();
                    item.Game = UtilsTool.GetGameName(_item.GameSysNo);
                    item.Source = UtilsTool.GetSourceName(_item.SourceSysNo);
                    item.Site = UtilsTool.GetSiteName(_item.SiteSysNo);
                    item.RetNum = _item.RetNum;
                    item.Cnt = _item.Cnt.ToString();
                    result.Add(item);
                }
            }
            return result;
        }
    }

    public class RemindStatisticsHeaderModel
    {
        public string SysNo { get; set; }
        public string Game { get; set; }
        public string Source { get; set; }
        public string Site { get; set; }
        public string RetNum { get; set; }
        public string Cnt { get; set; }
        public string Del { get; set; }
        public List<RemindStatisticsHeaderModel> GetHeader()
        {
            List<RemindStatisticsHeaderModel> result = new List<RemindStatisticsHeaderModel>();
            RemindStatisticsHeaderModel item = new RemindStatisticsHeaderModel();
            item.SysNo = "编号";
            item.Game = "游戏";
            item.Source = "源";
            item.Site = "网站";
            item.RetNum = "结果";
            item.Cnt = "次数";
            item.Del = "删除";
            result.Add(item);
            return result;
        }
    }
}
