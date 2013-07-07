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
        public string GenerateCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(CultureInfo.InvariantCulture);
        }

        #region 28 BeiJing
        /// <summary>
        /// 查询最近20期的结果
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryTop20_28BJ(int siteSysNo)
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
        public List<LotteryForBJ> Query20BySameNo_28BJ(int number,int siteSysNo)
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
        /// <param name="siteSysNo"> </param>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryNextLotteryWithSameNumber_28BJ(int number,int siteSysNo)
        {
            var sameLotteries = Query20BySameNo_28BJ(number,siteSysNo);
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
        /// <param name="siteSysNo"> </param>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryLotteryByHourStep_28BJ(DateTime dateTime,int siteSysNo)
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
        public LotteryByTwentyPeriod QueryLotteryByDay_28BJ(DateTime dateTime,int siteSysNo)
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
        public LotteryTrend QueryTrend_28BJ(DateTime from,DateTime to,int pageIndex,int pageSize)
        {

            var total=Session.CreateSQLQuery(@"
SELECT COUNT(1) AS TOTAL
FROM dbo.SourceData_28_Beijing
WHERE (RetTime BETWEEN :START_DATE AND :END_DATE)
")
                .SetParameter("START_DATE",from)
                .SetParameter("END_DATE",to)
                
                .UniqueResult<int>();
            var times = Session.CreateSQLQuery(@"
(
SELECT RC.BigOrSmall AS Name
      ,COUNT(RC.BigOrSmall) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.RetTime BETWEEN :START_DATE AND :END_DATE
GROUP BY RC.BigOrSmall
)
union
(
SELECT RC.MiddleOrSide AS Name
      ,COUNT(RC.MiddleOrSide) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.RetTime BETWEEN :START_DATE AND :END_DATE
GROUP BY RC.MiddleOrSide
)
union
(
SELECT RC.OddOrDual AS Name
      ,COUNT(RC.OddOrDual) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.RetTime BETWEEN :START_DATE AND :END_DATE
GROUP BY RC.OddOrDual
)
union
(
SELECT convert(nvarchar(40),RetNum) as Name,
	   COUNT(RetNum) AS Total
FROM dbo.SourceData_28_Beijing
WHERE (RetTime BETWEEN :START_DATE AND :END_DATE)
GROUP BY RetNum
)
")
                .AddEntity(typeof (LotteryTimes))
                .SetParameter("START_DATE", from)
                .SetParameter("END_DATE", to)
                .List<LotteryTimes>().ToList();

            //var times2=Session.QueryOver<LotteryForBJ>()
            //    .JoinAlias(p=>p.RetNum,()=>qtest)


            var data = Session.CreateSQLQuery(@"

SELECT *
FROM (
SELECT 
	ROW_NUMBER() OVER  (ORDER BY PERIODNUM DESC) AS ROWNO,
	*
FROM dbo.SourceData_28_Beijing
WHERE (RetTime BETWEEN :START_DATE AND :END_DATE)
	) AS TEMP
WHERE ROWNO>(:PAGE_SIZE * :PAGE_INDEX) AND ROWNO<( :PAGE_INDEX + 1) * :PAGE_SIZE
")
                .AddEntity(typeof(LotteryExtByBJ))
                .SetParameter("START_DATE",from)
                .SetParameter("END_DATE",to)
                .SetParameter("PAGE_INDEX",pageIndex)
                .SetParameter("PAGE_SIZE",pageSize)
                .List<LotteryExtByBJ>().ToList();

            var result = new LotteryTrend();
            result.LotteryTimeses = times;


            var pageList = new PageList<LotteryExtByBJ>();
            pageList.PageIndex = pageIndex;
            pageList.PageSize = pageSize;
            pageList.List = data;
            pageList.Total = total;
            result.PageList = pageList;
            //var typeTimes=

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
        public List<OmitStatistics> QueryOmissionAll_28BJ(int gameSysNo,
            int siteSysNo,
            int sourceSysNo)
        {
            return Session
                .QueryOver<OmitStatistics>()
                .Where(p => p.GameSysNo == gameSysNo && p.SiteSysNo == siteSysNo && p.SourceSysNo == sourceSysNo)
                .List<OmitStatistics>()
                .ToList();
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
