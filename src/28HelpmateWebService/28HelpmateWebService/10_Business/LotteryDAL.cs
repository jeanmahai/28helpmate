using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Model;
using Model.Model;
using Model.ResponseModel;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Impl;
using NHibernate.Linq;
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

        private List<LotteryExtByBJ> MappingType(List<LotteryExtByBJ> lotteries)
        {
            lotteries.ForEach(p =>
                              {
                                  var t = LotteryDictionary.Single(s => s.RetNum == p.RetNum);
                                  p.BigOrSmall = t.BigOrSmall;
                                  p.MiddleOrSide = t.MiddleOrSide;
                                  p.OddOrDual = t.OddOrDual;
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
        public UserSite QueryUserSite(int sysNo)
        {
            var result = Session
                .QueryOver<UserSite>()
                .List<UserSite>().SingleOrDefault(p => p.SysNo == sysNo);
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
        public string generateKey()
        {
            return Guid.NewGuid().ToString();
        }
        public bool ValidateToken(string userId,string psw,string token)
        {
            return GenerateToken(userId,psw) == token;
        }
        public bool ValidateToken(string str,string token)
        {
            return GenerateToken(str) == token;
        }
        public string GenerateCode()
        {
            var random = new Random();
            return random.Next(100000,999999).ToString(CultureInfo.InvariantCulture);
        }

        #region 28
        /// <summary>
        /// 查询最近20期的结果
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryTop20(int siteSysNo,
            string tableName)
        {
            var sql = SqlManager.GetSqlText("QueryTop20");
            sql = string.Format(sql,tableName,siteSysNo);

            var q = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryForBJ))
                .List<LotteryForBJ>().ToList();

            //var criteria = Session.CreateCriteria(typeof(LotteryForBJ));
            //criteria.SetMaxResults(20);
            //criteria.AddOrder(new Order("PeriodNum",false));
            //criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));

            //var lotteries = criteria.List<LotteryForBJ>().ToList();

            MappingType(q);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = q;
            result.NotAppearNumber = GetNotAppearNo(q);
            return result;
        }

        /// <summary>
        /// 查询最近20期开奖号码相同的结果,预测的号码是最新开的哪一期
        /// </summary>
        /// <param name="number"></param>
        /// <param name="siteSysNo"> </param>
        /// <param name="tableName"> </param>
        /// <returns></returns>
        public List<LotteryForBJ> Query20BySameNo(int siteSysNo,string tableName)
        {
            var sql = SqlManager.GetSqlText("Query20BySameNo");
            sql = string.Format(sql,tableName,siteSysNo);

            var q = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryForBJ))
                .List<LotteryForBJ>().ToList();

            //ICriteria criteria = Session.CreateCriteria(typeof(LotteryForBJ));
            //criteria.AddOrder(new Order("PeriodNum",false));
            //criteria.SetFirstResult(1);
            //criteria.SetMaxResults(20);
            //criteria.Add(Restrictions.Eq("RetNum",number));
            //criteria.Add(Restrictions.Eq("SiteSysNo",siteSysNo));
            //var data = criteria.List<LotteryForBJ>().ToList();

            MappingType(q);
            return q;
        }

        /// <summary>
        /// 查询最近20期号码相同的下一期的开奖结果,预测最近一期的下一期
        /// </summary>
        /// <param name="number"></param>
        /// <param name="siteSysNo"> </param>
        /// <param name="tableName"> </param>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryNextLotteryWithSameNumber(int number,int siteSysNo,string tableName)
        {
            var sameLotteries = Query20BySameNo(siteSysNo,tableName);

            var periods = string.Join(",",(from a in sameLotteries
                                           select a.PeriodNum + 1).ToList());

            var sql = SqlManager.GetSqlText("QueryNextLotteryWithSameNumber");
            sql = string.Format(sql,tableName,periods,siteSysNo);

            var q = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryForBJ))
                .List<LotteryForBJ>().ToList();


            MappingType(q);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = q;
            result.NotAppearNumber = GetNotAppearNo(q);
            return result;
        }

        /// <summary>
        /// 查询同一时间点的近20小时的数据
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="siteSysNo"> </param>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryLotteryByHourStep(DateTime dateTime,int siteSysNo,string tableName)
        {
            var datesStr = new List<string>();
            for (var i = 1;i <= 20;i++)
            {
                datesStr.Add("'"+dateTime.AddHours(-i).ToString("yyyy-MM-dd HH:mm:ss")+"'");
            }

            var sql = SqlManager.GetSqlText("QueryLotteryByHourStep");
            sql = string.Format(sql,tableName,string.Join(",",datesStr),siteSysNo);

            var q = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryForBJ))
                .List<LotteryForBJ>().ToList();

            MappingType(q);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = q;
            result.NotAppearNumber = GetNotAppearNo(q);
            return result;
        }
        /// <summary>
        /// 查询同一时间点的近20天的数据
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryLotteryByDay(DateTime dateTime,int siteSysNo,string tableName)
        {
            var datesStr = new List<string>();
            for (var i = 1;i <= 20;i++)
            {
                datesStr.Add("'" + dateTime.AddHours(-i).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            }
            var sql = SqlManager.GetSqlText("QueryLotteryByHourStep");
            sql = string.Format(sql,tableName,string.Join(",",datesStr),siteSysNo);

            var q = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryForBJ))
                .List<LotteryForBJ>().ToList();


            MappingType(q);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = q;
            result.NotAppearNumber = GetNotAppearNo(q);
            return result;
        }
        /// <summary>
        /// 查询开奖结果
        /// </summary>
        /// <param name="filterForBj"></param>
        /// <returns></returns>
        public PageList<LotteryForBJ> Query_28BJ(LotteryFilterForBJ filterForBj)
        {
            var criteriaCountCondition = Session.CreateCriteria(typeof(LotteryForBJ));

            if (filterForBj.From.HasValue && filterForBj.To.HasValue)
            {
                criteriaCountCondition.Add(Restrictions.Between("RetTime",filterForBj.From.Value,
                                                  filterForBj.To.Value));
            }
            if (!string.IsNullOrEmpty(filterForBj.SiteName))
            {
                var userSite = QueryUserSite(filterForBj.SiteName);
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

            criteriaQueryCondition.SetFirstResult((filterForBj.PageIndex - 1) * filterForBj.PageSize);
            criteriaQueryCondition.SetMaxResults(filterForBj.PageSize);


            result.List = criteriaQueryCondition.List<LotteryForBJ>().ToList();
            return result;
        }
        /// <summary>
        /// 一般走势图
        /// </summary>
        /// <param name="siteSysNo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public LotteryTrend QueryTrend(int siteSysNo,
            int pageIndex,
            int pageCount,
            string tableName)
        {
            pageIndex -= 1;
            var curDate = DateTime.Now.AddDays(-pageIndex);
            DateTime @from;
            @from = DateTime.Parse(curDate.ToString("yyyy-MM-dd 00:00:00"));
            DateTime to = DateTime.Parse(curDate.ToString("yyyy-MM-dd 23:59:59"));
            var sql = SqlManager.GetSqlText("QueryTrend2");
            sql = string.Format(sql,tableName);
            //每个号码及类型所出现的次数
            var times = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryTimes))
                .SetParameter("START_DATE",DateTime.Parse(curDate.AddDays(-pageCount).AddDays(1).ToString("yyyy-MM-dd 00:00:00")))
                .SetParameter("END_DATE",DateTime.Now)
                .SetParameter("SiteSysNo",siteSysNo)
                .List<LotteryTimes>().ToList();

            //每页的数据
            sql = SqlManager.GetSqlText("QueryTrend3");
            sql = string.Format(sql,tableName);
            var data = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryExtByBJ))
                .SetParameter("START_DATE",@from)
                .SetParameter("END_DATE",to)
                .SetParameter("SiteSysNo",siteSysNo)
                .List<LotteryExtByBJ>().ToList();

            MappingType(data);

            var result = new LotteryTrend();
            result.LotteryTimeses = times;
            result.DataList = data;
            result.PageCount = pageCount;
            result.PageIndex = pageIndex + 1;

            return result;
        }
        public LotteryForBJ MaxPeriod_28BJ()
        {
            return Session.QueryOver<LotteryForBJ>()
                .OrderBy(l => l.PeriodNum).Desc
                .Take(1)
                .SingleOrDefault<LotteryForBJ>();
        }
        //public OmissionLottery QueryOmissionForBJ(int number)
        //{
        //    var maxPeriod = MaxPeriodForBJ();
        //    var result = new OmissionLottery();
        //    result.Number = number;
        //    var nearLottery = Session.QueryOver<LotteryForBJ>()
        //        .OrderBy(l => l.PeriodNum).Desc
        //        .Where(l => l.RetNum == number)
        //        .Take(1).SingleOrDefault<LotteryForBJ>();
        //    result.NearPeriod = nearLottery.PeriodNum;
        //    result.Interval = maxPeriod.PeriodNum - nearLottery.PeriodNum;
        //    return result;
        //}
        public List<OmitStatistics> QueryOmissionAll(int gameSysNo,
            int siteSysNo,
            int sourceSysNo)
        {
            var sql = string.Format("exec RefreshOmitStatistics {0},{1},{2};",
                                    gameSysNo,sourceSysNo,siteSysNo);
            Session.CreateSQLQuery(sql)
                .ExecuteUpdate();

            return Session
                .QueryOver<OmitStatistics>()
                .Where(p => p.GameSysNo == gameSysNo && p.SiteSysNo == siteSysNo && p.SourceSysNo == sourceSysNo)
                .List<OmitStatistics>()
                .ToList();
        }

        /// <summary>
        /// 超级走势图;
        /// </summary>
        /// <param name="siteSysNo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"> </param>
        /// <param name="maxTotal"></param>
        /// <param name="day"></param>
        /// <param name="date"> </param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="tableName"> </param>
        /// <returns></returns>
        public LotteryTrend QuerySupperTrend(int siteSysNo,
            int pageIndex,
            int pageSize,
            int maxTotal,
            string date,
            string hour,
            string minute,
            string tableName)
        {


            var result = new LotteryTrend();
            //查询每个号码及类型的出现次数,总次数以maxTotal为准
            var curLottery = MaxPeriod_28BJ();
            var maxPeriod = curLottery.PeriodNum;
            var minPeriod = maxPeriod - maxTotal;

            //condition
            var condition = new StringBuilder();
            if (string.IsNullOrEmpty(date))
            {
                condition.AppendFormat(" and CONVERT(varchar(100),BJ.RetTime,23)='{0}'",DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
            {
                condition.AppendFormat(" and CONVERT(varchar(100),BJ.RetTime,23)='{0}'",DateTime.Parse(date).ToString("yyyy-MM-dd"));
            }
            if (!string.IsNullOrEmpty(hour))
            {
                condition.AppendFormat(" and datepart(hour,BJ.RetTime)={0}",hour);
            }
            if (!string.IsNullOrEmpty(minute))
            {
                condition.AppendFormat(" and datepart(minute,BJ.RetTime)={0}",minute);
            }

            //查询数字的出现次数
            var sql = SqlManager.GetSqlText("QuerySupperTrend_28BJ_1");
            sql = string.Format(sql,condition,tableName);
            var q1 = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryTimes))
                .SetParameter("SITE_SYS_NO",siteSysNo)
                .SetParameter("MIN_PERIOD",minPeriod)
                .List<LotteryTimes>();
            //查询类型的出现次数
            sql = SqlManager.GetSqlText("QuerySupperTrend_28BJ_2");
            sql = string.Format(sql,condition,tableName);
            var q2 = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryTimes))
                .SetParameter("SITE_SYS_NO",siteSysNo)
                .SetParameter("MIN_PERIOD",minPeriod)
                .List<LotteryTimes>();

            result.LotteryTimeses = new List<LotteryTimes>();
            result.LotteryTimeses.AddRange(q1);
            result.LotteryTimeses.AddRange(q2);
            foreach (var num in LotteryNumber)
            {
                if (!result.LotteryTimeses.Exists(p => p.Name.Trim() == num.ToString()))
                {
                    result.LotteryTimeses.Add(new LotteryTimes()
                                              {
                                                  Name = num.ToString(),
                                                  Total = 0
                                              });
                }
            }
            if (!result.LotteryTimeses.Exists(p => p.Name.Trim() == "大"))
            {
                result.LotteryTimeses.Add(new LotteryTimes()
                {
                    Name = "大",
                    Total = 0
                });
            }
            if (!result.LotteryTimeses.Exists(p => p.Name.Trim() == "小"))
            {
                result.LotteryTimeses.Add(new LotteryTimes()
                {
                    Name = "小",
                    Total = 0
                });
            }
            if (!result.LotteryTimeses.Exists(p => p.Name.Trim() == "单"))
            {
                result.LotteryTimeses.Add(new LotteryTimes()
                {
                    Name = "单",
                    Total = 0
                });
            }
            if (!result.LotteryTimeses.Exists(p => p.Name.Trim() == "双"))
            {
                result.LotteryTimeses.Add(new LotteryTimes()
                {
                    Name = "双",
                    Total = 0
                });
            }
            if (!result.LotteryTimeses.Exists(p => p.Name.Trim() == "中"))
            {
                result.LotteryTimeses.Add(new LotteryTimes()
                {
                    Name = "中",
                    Total = 0
                });
            }
            if (!result.LotteryTimeses.Exists(p => p.Name.Trim() == "单"))
            {
                result.LotteryTimeses.Add(new LotteryTimes()
                {
                    Name = "单",
                    Total = 0
                });
            }
            result.LotteryTimeses.ForEach(p => p.Name = p.Name.Trim());
            //total
            sql = SqlManager.GetSqlText("QuerySupperTrend_28BJ_3");
            sql = string.Format(sql,condition,tableName);
            var q3 = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(PageInfo))
                .SetParameter("SITE_SYS_NO",siteSysNo)
                .SetParameter("MIN_PERIOD",minPeriod)
                .SetParameter("PAGE_INDEX",pageIndex)
                .SetParameter("PAGE_SIZE",pageSize)
                .UniqueResult<PageInfo>();
            //result.PageInfo = q3;
            result.PageCount = q3.PageCount;
            result.PageIndex = q3.PageIndex;
            //list
            sql = SqlManager.GetSqlText("QuerySupperTrend_28BJ_4");
            sql = string.Format(sql,condition,tableName);
            var q4 = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryExtByBJ))
                .SetParameter("SITE_SYS_NO",siteSysNo)
                .SetParameter("MIN_PERIOD",minPeriod)
                .SetParameter("PAGE_INDEX",pageIndex)
                .SetParameter("PAGE_SIZE",pageSize)
                .List<LotteryExtByBJ>();
            result.DataList = q4.ToList();
            return result;
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
