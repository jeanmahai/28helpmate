using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Enum;

namespace Model.ResponseModel
{
    [Serializable]
    public class LotteryByTwentyPeriodRM
    {
        public List<LotteryRM> Lotteries { get; set; }
        public List<int> NotAppearNumber { get; set; }
        private decimal Total
        {
            get { return Convert.ToDecimal(Lotteries.Count); }
        }
        public decimal BigP
        {
            get
            {
                if (Total == 0) return 0;
                var bigTotal = (from a in Lotteries
                                where a.BigSmall == BigSmallEnum.Big
                                select a).Count();
                return bigTotal / Total;
            }
        }
        public decimal SmallP
        {
            get
            {
                if (Total == 0) return 0;
                var smallTotal = (from a in Lotteries
                                where a.BigSmall == BigSmallEnum.Small
                                select a).Count();
                return smallTotal / Total;
            }
        }
        public decimal CenterP
        {
            get
            {
                if (Total == 0) return 0;
                var centerTotal = (from a in Lotteries
                                  where a.CenterSide == CenterSideEnum.Center
                                  select a).Count();
                return centerTotal / Total;
            }
        }
        public decimal SideP
        {
            get
            {
                if (Total == 0) return 0;
                var sideTotal = (from a in Lotteries
                                   where a.CenterSide == CenterSideEnum.Side
                                   select a).Count();
                return sideTotal / Total;
            }
        }
        public decimal OddP
        {
            get
            {
                if (Total == 0) return 0;
                var oddTotal = (from a in Lotteries
                                   where a.OddEven == OddEvenEnum.Odd
                                   select a).Count();
                return oddTotal / Total;
            }
        }
        public decimal EvenP
        {
            get
            {
                if (Total == 0) return 0;
                var evenTotal = (from a in Lotteries
                                where a.OddEven == OddEvenEnum.Even
                                select a).Count();
                return evenTotal / Total;
            }
        }
    }
}
