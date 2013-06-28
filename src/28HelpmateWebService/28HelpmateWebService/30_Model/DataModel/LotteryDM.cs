using System;
using System.Data;
using Application.Framework.Data.Entity;

namespace Model.DataModel
{
    public class LotteryDM
    {
        /// <summary>
        /// 期号，所采集网站的期号
        /// </summary>
        [DataMapping("PeriodNum",DbType.Int32)]
        public int PeriodNum { get; set; }

        /// <summary>
        /// 开奖时间，5分钟一开
        /// </summary>
        [DataMapping("RetTime",DbType.DateTime)]
        public DateTime RetTime { get; set; }

        /// <summary>
        /// 计算公式网站编号
        /// </summary>
        [DataMapping("SiteSysNo",DbType.Int32)]
        public int SiteSysNo { get; set; }

        /// <summary>
        /// 每位开奖结果，如：425
        /// </summary>
        [DataMapping("RetOddNum",DbType.Int32)]
        public int RetOddNum { get; set; }

        /// <summary>
        /// 开奖结果，如：11
        /// </summary>
        [DataMapping("RetNum",DbType.Int32)]
        public int RetNum { get; set; }

        /// <summary>
        /// 每段值，如：44|192|335
        /// </summary>
        [DataMapping("RetMidNum",DbType.String)]
        public string RetMidNum { get; set; }

        /// <summary>
        /// 采集结果，20个数字，如：1|2|3
        /// </summary>
        [DataMapping("CollectRet",DbType.String)]
        public string CollectRet { get; set; }

        /// <summary>
        /// 采集成功时间
        /// </summary>
        [DataMapping("CollectTime",DbType.DateTime)]
        public DateTime CollectTime { get; set; }

        /// <summary>
        /// 状态，-1.失败，0.创建，1.成功
        /// </summary>
        [DataMapping("Status",DbType.Int32)]
        public int Status { get; set; }


        [DataMapping("BigSmall",DbType.Int32)]
        public int BigSmall { get; set; }

        [DataMapping("CenterSide",DbType.Int32)]
        public int CenterSide { get; set; }

        [DataMapping("OddEven",DbType.Int32)]
        public int OddEven { get; set; }
    }
}
