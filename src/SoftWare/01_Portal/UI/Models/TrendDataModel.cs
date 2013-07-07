using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Helpmate.UI.Forms.Properties;
using Helpmate.Facades.LotteryWebService;
using Common.Utility;

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

        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="list">Service实体</param>
        /// <returns></returns>
        public List<TrendDataModel> GetDataList(LotteryForBJ[] list)
        {
            List<TrendDataModel> dataList = new List<TrendDataModel>();
            if (list != null && list.Length > 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    TrendDataModel item = new TrendDataModel();
                    item.PeriodNum = list[i].PeriodNum;
                    item.RetTime = UtilsTool.ConvertDateToTrendDate(list[i].RetTime);
                    #region 大小、中边、单双
                    if (list[i].type != null)
                    {
                        if (list[i].type.BigOrSmall == "大")
                        {
                            item.Big = "大";
                            item.Small = "";
                        }
                        else
                        {
                            item.Big = "";
                            item.Small = "小";
                        }
                        if (list[i].type.OddOrDual == "单")
                        {
                            item.Odd = "单";
                            item.Dual = "";
                        }
                        else
                        {
                            item.Odd = "";
                            item.Dual = "双";
                        }
                        if (list[i].type.MiddleOrSide == "中")
                        {
                            item.Middle = "中";
                            item.Side = "";
                        }
                        else
                        {
                            item.Middle = "";
                            item.Side = "边";
                        }
                    }
                    #endregion
                    #region 28个数字
                    switch (list[i].RetNum)
                    {
                        case 0:
                            item.T0 = Resources.number_0x;
                            break;
                        case 1:
                            item.T1 = Resources.number_1x;
                            break;
                        case 2:
                            item.T2 = Resources.number_2x;
                            break;
                        case 3:
                            item.T3 = Resources.number_3x;
                            break;
                        case 4:
                            item.T4 = Resources.number_4x;
                            break;
                        case 5:
                            item.T4 = Resources.number_5x;
                            break;
                        case 6:
                            item.T6 = Resources.number_6x;
                            break;
                        case 7:
                            item.T7 = Resources.number_7x;
                            break;
                        case 8:
                            item.T8 = Resources.number_8x;
                            break;
                        case 9:
                            item.T9 = Resources.number_9x;
                            break;
                        case 10:
                            item.T10 = Resources.number_10x;
                            break;
                        case 11:
                            item.T11 = Resources.number_11x;
                            break;
                        case 12:
                            item.T12 = Resources.number_12x;
                            break;
                        case 13:
                            item.T13 = Resources.number_13x;
                            break;
                        case 14:
                            item.T14 = Resources.number_14x;
                            break;
                        case 15:
                            item.T15 = Resources.number_15x;
                            break;
                        case 16:
                            item.T16 = Resources.number_16x;
                            break;
                        case 17:
                            item.T17 = Resources.number_17x;
                            break;
                        case 18:
                            item.T18 = Resources.number_18x;
                            break;
                        case 19:
                            item.T19 = Resources.number_19x;
                            break;
                        case 20:
                            item.T20 = Resources.number_20x;
                            break;
                        case 21:
                            item.T21 = Resources.number_21x;
                            break;
                        case 22:
                            item.T22 = Resources.number_22x;
                            break;
                        case 23:
                            item.T23 = Resources.number_23x;
                            break;
                        case 24:
                            item.T24 = Resources.number_24x;
                            break;
                        case 25:
                            item.T25 = Resources.number_25x;
                            break;
                        case 26:
                            item.T26 = Resources.number_26x;
                            break;
                        case 27:
                            item.T27 = Resources.number_27x;
                            break;
                    }
                    #endregion
                    dataList.Add(item);
                }
            }
            return dataList;
        }

    }
}
