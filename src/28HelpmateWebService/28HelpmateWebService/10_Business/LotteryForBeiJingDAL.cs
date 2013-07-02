using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Model.Model;
using Model.ResponseModel;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Impl;

namespace Business
{
    public class LotteryForBeiJingDAL
    {
        private readonly List<int> Lotterynumber = new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27 };
        private ISession Session { get; set; }
        private IEnumerable<LotteryType> LotteryDictionary
        {
            get { return Session.QueryOver<LotteryType>().List<LotteryType>().ToList(); }
        }
        public LotteryForBeiJingDAL()
        {
            Session = NHibernateHelper.GetSession();
        }
        private List<int> GetNotAppearNo(List<int> appearNo)
        {
            var notAppearNo = new List<int>();
            Lotterynumber.ForEach(p =>
            {
                if (!appearNo.Contains(p)
                    && !notAppearNo.Contains(p))
                {
                    notAppearNo.Add(p);
                }
            });
            return notAppearNo;
        }
        private List<int> GetNotAppearNo(List<Lottery> lotteries)
        {
            var appearNo = (from a in lotteries
                            select a.RetNum).ToList();
            var notAppearNo = new List<int>();
            Lotterynumber.ForEach(p =>
            {
                if (!appearNo.Contains(p)
                    && !notAppearNo.Contains(p))
                {
                    notAppearNo.Add(p);
                }
            });
            return notAppearNo;
        }
        private List<Lottery> MappingType(List<Lottery> lotteries)
        {
            lotteries.ForEach(p =>
            {
                p.type = LotteryDictionary.Single(s => s.RetNum == p.RetNum);
            });
            return lotteries;
        }
        public UserSite QueryUserSite(string name)
        {
            var result = Session
                .QueryOver<UserSite>()
                .List<UserSite>().SingleOrDefault(p => p.SiteName == name);
            return result;
        } 
        /// <summary>
        /// 查询最近20期的结果
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriodRM QueryTop20(int siteSysNo)
        {
            var criteria = Session.CreateCriteria(typeof(Lottery));
            criteria.SetMaxResults(20);
            criteria.AddOrder(new Order("PeriodNum",false));
            criteria.Add(Restrictions.Eq("SiteSysNo", siteSysNo));

            var lotteries = criteria.List<Lottery>().ToList();
            MappingType(lotteries);
            var result = new LotteryByTwentyPeriodRM();
            result.Lotteries = lotteries;
            result.NotAppearNumber = GetNotAppearNo(lotteries);
            return result;
        }

        /// <summary>
        /// 查询最近20期开奖号码相同的结果
        /// </summary>
        /// <param name="number"></param>
        /// <param name="siteSysNo"> </param>
        /// <returns></returns>
        public List<Lottery> Query20BySameNo(int number,int siteSysNo)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Lottery));
            criteria.AddOrder(new Order("PeriodNum",false));
            criteria.SetMaxResults(20);
            criteria.Add(Restrictions.Eq("RetNum",number));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));
            var data = criteria.List<Lottery>().ToList();
            MappingType(data);
            return data;
        }
        /// <summary>
        /// 查询最近20期号码相同的下一期的开奖结果
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public LotteryByTwentyPeriodRM QueryNextLotteryWithSameNumber(int number,int siteSysNo)
        {
            var sameLotteries = Query20BySameNo(number,siteSysNo);
            var periods = (from a in sameLotteries
                           select a.PeriodNum + 1).ToList();
            var criteria = Session.CreateCriteria(typeof(Lottery));
            criteria.Add(Restrictions.In("PeriodNum",periods));
            criteria.AddOrder(new Order("PeriodNum",false));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            var data = criteria.List<Lottery>().ToList();
            MappingType(data);
            var result = new LotteryByTwentyPeriodRM();
            result.Lotteries = data;
            result.NotAppearNumber = GetNotAppearNo(data);
            return result;
        }
        /// <summary>
        /// 查询同一时间点的近20小时的数据
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public LotteryByTwentyPeriodRM QueryLotteryByHourStep(DateTime dateTime,int siteSysNo)
        {
            var dates = new List<DateTime>();
            for (var i = 1;i <= 20;i++)
            {
                dates.Add(dateTime.AddHours(-i));
            }
            var criteria = Session.CreateCriteria(typeof(Lottery));
            criteria.Add(Restrictions.In("RetTime",dates));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            var data = criteria.List<Lottery>().ToList();
            MappingType(data);
            var result = new LotteryByTwentyPeriodRM();
            result.Lotteries = data;
            result.NotAppearNumber = GetNotAppearNo(data);
            return result;
        }
        /// <summary>
        /// 查询同一时间点的近20天的数据
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriodRM QueryLotteryByDay(DateTime dateTime,int siteSysNo)
        {
            var dates = new List<DateTime>();
            for (var i = 1;i <= 20;i++)
            {
                dates.Add(dateTime.AddDays(-i));
            }
            var criteria = Session.CreateCriteria(typeof(Lottery));
            criteria.Add(Restrictions.In("RetTime",dates));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            var data = criteria.List<Lottery>().ToList();
            MappingType(data);
            var result = new LotteryByTwentyPeriodRM();
            result.Lotteries = data;
            result.NotAppearNumber = GetNotAppearNo(data);
            return result;
        }
        /// <summary>
        /// 查询开奖结果
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PageList<Lottery> Query(LotteryFilter filter)
        {
            var criteriaCountCondition = Session.CreateCriteria(typeof(Lottery));
            
            if (filter.From.HasValue && filter.To.HasValue)
            {
                criteriaCountCondition.Add(Restrictions.Between("RetTime",filter.From.Value,
                                                  filter.To.Value));
            }
            if(!string.IsNullOrEmpty(filter.SiteName))
            {
                var userSite = QueryUserSite(filter.SiteName);
                if(userSite!=null)
                {
                    criteriaCountCondition.Add(Restrictions.Eq("SiteSysNo", userSite.SysNo));
                }
            }
            var criteriaQueryCondition = criteriaCountCondition.Clone() as ICriteria;
            var total =criteriaCountCondition
                .SetProjection(Projections.Count("PeriodNum"))
                .UniqueResult<int>();

            var result = new PageList<Lottery>();
            result.Total = total;

            
            criteriaQueryCondition.AddOrder(new Order("PeriodNum",false));
            
            criteriaQueryCondition.SetFirstResult((filter.PageIndex-1) *filter.PageSize);
            criteriaQueryCondition.SetMaxResults(filter.PageSize);
            
            
            result.List = criteriaQueryCondition.List<Lottery>().ToList();
            return result;
        }
    }
}
