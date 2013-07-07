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
using NHibernate.Utility;
using Net.Utility.Security;

namespace Business
{
    public class LotteryDAL
    {
        private readonly List<int> LotteryNumber = new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27 };
        private ISession Session { get; set; }
        private IEnumerable<LotteryType> LotteryDictionary
        {
            get { return Session.QueryOver<LotteryType>().List<LotteryType>().ToList(); }
        }
        public LotteryDAL()
        {
            Session = NHibernateHelper.GetSession();
        }
        private List<int> GetNotAppearNo(List<int> appearNo)
        {
            var notAppearNo = new List<int>();
            LotteryNumber.ForEach(p =>
            {
                if (!appearNo.Contains(p)
                    && !notAppearNo.Contains(p))
                {
                    notAppearNo.Add(p);
                }
            });
            return notAppearNo;
        }
        private List<int> GetNotAppearNo(List<LotteryForBJ> lotteries)
        {
            var appearNo = (from a in lotteries
                            select a.RetNum).ToList();
            var notAppearNo = new List<int>();
            LotteryNumber.ForEach(p =>
            {
                if (!appearNo.Contains(p)
                    && !notAppearNo.Contains(p))
                {
                    notAppearNo.Add(p);
                }
            });
            return notAppearNo;
        }
        private List<LotteryForBJ> MappingType(List<LotteryForBJ> lotteries)
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
        public string GenerateToken(string userId,string psw)
        {
            return CiphertextService.MD5Encryption(string.Format("{0}_{1}",
                                                                 userId,
                                                                 psw));
        }
        public string GenerateToken(string str)
        {
            return CiphertextService.MD5Encryption(str);
        }
        public bool ValidateToken(string userId,string psw,string token)
        {
            return GenerateToken(userId,psw) == token;
        }
        public bool ValidateToken(string str,string token)
        {
            return GenerateToken(str) == token;
        }

        #region BeiJing
        /// <summary>
        /// 查询最近20期的结果
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryTop20ForBJ(int siteSysNo)
        {
            var criteria = Session.CreateCriteria(typeof(LotteryForBJ));
            criteria.SetMaxResults(20);
            criteria.AddOrder(new Order("PeriodNum",false));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            var lotteries = criteria.List<LotteryForBJ>().ToList();
            MappingType(lotteries);
            var result = new LotteryByTwentyPeriod();
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
        public List<LotteryForBJ> Query20BySameNoForBJ(int number,int siteSysNo)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(LotteryForBJ));
            criteria.AddOrder(new Order("PeriodNum",false));
            criteria.SetMaxResults(20);
            criteria.Add(Restrictions.Eq("RetNum",number));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));
            var data = criteria.List<LotteryForBJ>().ToList();
            MappingType(data);
            return data;
        }
        /// <summary>
        /// 查询最近20期号码相同的下一期的开奖结果
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryNextLotteryWithSameNumberForBJ(int number,int siteSysNo)
        {
            var sameLotteries = Query20BySameNoForBJ(number,siteSysNo);
            var periods = (from a in sameLotteries
                           select a.PeriodNum + 1).ToList();
            var criteria = Session.CreateCriteria(typeof(LotteryForBJ));
            criteria.Add(Restrictions.In("PeriodNum",periods));
            criteria.AddOrder(new Order("PeriodNum",false));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            var data = criteria.List<LotteryForBJ>().ToList();
            MappingType(data);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = data;
            result.NotAppearNumber = GetNotAppearNo(data);
            return result;
        }
        /// <summary>
        /// 查询同一时间点的近20小时的数据
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryLotteryByHourStepForBJ(DateTime dateTime,int siteSysNo)
        {
            var dates = new List<DateTime>();
            for (var i = 1;i <= 20;i++)
            {
                dates.Add(dateTime.AddHours(-i));
            }
            var criteria = Session.CreateCriteria(typeof(LotteryForBJ));
            criteria.Add(Restrictions.In("RetTime",dates));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            var data = criteria.List<LotteryForBJ>().ToList();
            MappingType(data);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = data;
            result.NotAppearNumber = GetNotAppearNo(data);
            return result;
        }
        /// <summary>
        /// 查询同一时间点的近20天的数据
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryLotteryByDayForBJ(DateTime dateTime,int siteSysNo)
        {
            var dates = new List<DateTime>();
            for (var i = 1;i <= 20;i++)
            {
                dates.Add(dateTime.AddDays(-i));
            }
            var criteria = Session.CreateCriteria(typeof(LotteryForBJ));
            criteria.Add(Restrictions.In("RetTime",dates));
            criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            var data = criteria.List<LotteryForBJ>().ToList();
            MappingType(data);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = data;
            result.NotAppearNumber = GetNotAppearNo(data);
            return result;
        }
        /// <summary>
        /// 查询开奖结果
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PageList<LotteryForBJ> QueryForBJ(LotteryFilter filter)
        {
            var criteriaCountCondition = Session.CreateCriteria(typeof(LotteryForBJ));

            if (filter.From.HasValue && filter.To.HasValue)
            {
                criteriaCountCondition.Add(Restrictions.Between("RetTime",filter.From.Value,
                                                  filter.To.Value));
            }
            if (!string.IsNullOrEmpty(filter.SiteName))
            {
                var userSite = QueryUserSite(filter.SiteName);
                if (userSite != null)
                {
                    criteriaCountCondition.Add(Restrictions.Eq("SiteSysNo",userSite.SysNo));
                }
            }
            var criteriaQueryCondition = criteriaCountCondition.Clone() as ICriteria;
            var total = criteriaCountCondition
                .SetProjection(Projections.Count("PeriodNum"))
                .UniqueResult<int>();

            var result = new PageList<LotteryForBJ>();
            result.Total = total;


            criteriaQueryCondition.AddOrder(new Order("PeriodNum",false));

            criteriaQueryCondition.SetFirstResult((filter.PageIndex - 1) * filter.PageSize);
            criteriaQueryCondition.SetMaxResults(filter.PageSize);


            result.List = criteriaQueryCondition.List<LotteryForBJ>().ToList();
            return result;
        }

        public LotteryForBJ MaxPeriodForBJ()
        {
            return Session.QueryOver<LotteryForBJ>()
                .OrderBy(l => l.PeriodNum).Desc
                .Take(1)
                .SingleOrDefault<LotteryForBJ>();
        }
        public OmissionLottery QueryOmissionForBJ(int number)
        {
            var maxPeriod = MaxPeriodForBJ();
            var result = new OmissionLottery();
            result.Number = number;
            var nearLottery = Session.QueryOver<LotteryForBJ>()
                .OrderBy(l => l.PeriodNum).Desc
                .Where(l => l.RetNum == number)
                .Take(1).SingleOrDefault<LotteryForBJ>();
            result.NearPeriod = nearLottery.PeriodNum;
            result.Interval = maxPeriod.PeriodNum - nearLottery.PeriodNum;
            return result;
        }
        public List<OmissionLottery> QueryOmissionAllForBJ()
        {
            var query = Session.CreateSQLQuery(SqlManager.GetSqlText("QueryOmissionAllForBJ"))
                                             .AddEntity(typeof(OmissionLottery))
                                             .List<OmissionLottery>();
            return query.ToList();
        }
        #endregion

        #region User
        public bool Login(string userName,string psw)
        {

            var user = Session.QueryOver<User>().Where(p => p.UserName == userName).SingleOrDefault<User>();
            if (user == null) return false;
            var pswHash = CiphertextService.MD5Encryption(psw);
            if (pswHash != user.UserPwd) return false;
            return true;
        }
        public int Register(User user)
        {
            user.UserPwd = CiphertextService.MD5Encryption(user.UserPwd);
            var result = Session.Save(user);
            Session.Flush();
            return (int)result;
        }
        #endregion
    }
}
