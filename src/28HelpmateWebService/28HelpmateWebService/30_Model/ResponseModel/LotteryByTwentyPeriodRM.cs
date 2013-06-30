﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Enum;
using Model.Model;

namespace Model.ResponseModel
{
    [Serializable]
    public class LotteryByTwentyPeriodRM
    {
        private readonly string BIG = "大";
        private readonly string SMALL = "小";
        private readonly string ODD = "单";
        private readonly string EVEN = "双";
        private readonly string CENTER = "中";
        private readonly string SIDE = "边";

        public List<Lottery> Lotteries { get; set; }

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
                                where a.type.BigOrSmall == BIG
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
                                  where a.type.BigOrSmall == SMALL
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
                                   where a.type.MiddleOrSide == CENTER
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
                                 where a.type.MiddleOrSide == SIDE
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
                                where a.type.OddOrDual == ODD
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
                                 where a.type.OddOrDual == EVEN
                                 select a).Count();
                return evenTotal / Total;
            }
        }
    }
}
