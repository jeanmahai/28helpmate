using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.UI.Forms.Models
{
    public class RemindStatisticsModel
    {
        public string Game { get; set; }
        public string Source { get; set; }
        public string Site { get; set; }
        public string RetNum { get; set; }
        public string Cnt { get; set; }
        public string Opt { get; set; }

        public List<RemindStatisticsModel> GetHeader()
        {
            List<RemindStatisticsModel> result = new List<RemindStatisticsModel>();
            RemindStatisticsModel item = new RemindStatisticsModel();
            item.Game = "游戏";
            item.Source = "源";
            item.Site = "网站";
            item.RetNum = "结果";
            item.Cnt = "次数";
            item.Opt = "操作";
            result.Add(item);
            return result;
        }
        public List<RemindStatisticsModel> GetDataList()
        {
            List<RemindStatisticsModel> result = new List<RemindStatisticsModel>();
            return result;
        }
    }
}
