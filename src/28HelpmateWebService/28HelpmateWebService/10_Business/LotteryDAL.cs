﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using Model;
using Model.Model;
using Model.ResponseModel;
using NHibernate;
using NHibernate.Cfg;
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
        private ISession Session
        {
            get { return NHibernateHelper.GetSession(); }
        }
        private IEnumerable<LotteryType> LotteryDictionary
        {
            get { return Session.QueryOver<LotteryType>().List<LotteryType>().ToList(); }
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

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection("Server=117.25.148.58,3520;Database=Helpmate;User Id=helpmate;Password=1qa123!@#;");
        }

        #region 28

        public SpecialLottery GetSpecialInfo(int regionSysNo,int siteSysNo,int startHour,int endHour)
        {
            SpecialLottery result = new SpecialLottery();
            var strSql = "exec SpecialAnalysis {0},{1},{2},{3}";
            strSql = string.Format(strSql,regionSysNo,siteSysNo,startHour,endHour);
            using (var cnn = GetSqlConnection())
            {
                var cmd = new SqlCommand(strSql);
                cmd.Connection = cnn;
                cnn.Open();
                var adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                var typeCount = ds.Tables[0].AsEnumerable().Select(s => new LotteryTypeCount()
                                                                                  {
                                                                                      Big = s.Field<int>("Big"),
                                                                                      Date = s.Field<string>("Date"),
                                                                                      Dual = s.Field<int>("Dual"),
                                                                                      Middle = s.Field<int>("Middle"),
                                                                                      Odd = s.Field<int>("Odd"),
                                                                                      Side = s.Field<int>("Side"),
                                                                                      Small = s.Field<int>("Small")
                                                                                  }).ToList();
                var noAppearNo = ds.Tables[1].AsEnumerable().Select(s => new LotteryNumber()
                {
                    Date = s.Field<string>("Date"),
                    RetNum = s.Field<int>("RetNum")
                }).ToList();
                var bestNo = ds.Tables[2].AsEnumerable().Select(s => new LotteryNumber()
                {
                    Date = s.Field<string>("Date"),
                    RetNum = s.Field<int>("RetNum")
                }).ToList();
                typeCount.ForEach(s =>
                                  {
                                      s.NoAppearNum = string.Join(",",noAppearNo.Where(w => w.Date == s.Date).Select(ss => ss.RetNum).ToList());
                                      s.BestNum = string.Join(",",bestNo.Where(ww => ww.Date == s.Date).Select(ss => ss.RetNum).ToList());
                                  });
                result.LotteryTypeCount = typeCount;

                var typeAvg = ds.Tables[3].AsEnumerable().Select(s => new LotteryTypeAvg()
                {
                    AvgBig = s.Field<int>("AvgBig"),
                    AvgDual = s.Field<int>("AvgDual"),
                    AvgMiddle = s.Field<int>("AvgMiddle"),
                    AvgOdd = s.Field<int>("AvgOdd"),
                    AvgSide = s.Field<int>("AvgSide"),
                    AvgSmall = s.Field<int>("AvgSmall")
                }).ToList();
                result.LotteryTypeAvg = typeAvg.SingleOrDefault();
                if (result.LotteryTypeAvg != null)
                {
                    var obj = ds.Tables[5].AsEnumerable().SingleOrDefault();
                    if(obj!=null)
                    {
                        result.LotteryTypeAvg.PBig =
                            obj.Field<int>("BigCnt");
                        result.LotteryTypeAvg.PSmall =
                            obj.Field<int>("SmallCnt");
                        result.LotteryTypeAvg.PMiddle =
                            obj.Field<int>("MiddleCnt");
                        result.LotteryTypeAvg.PSide =
                            obj.Field<int>("SideCnt");
                        result.LotteryTypeAvg.POdd =
                            obj.Field<int>("OddCnt");
                        result.LotteryTypeAvg.PDual =
                            obj.Field<int>("DualCnt");
                    }
                }
                //typeAvg.ForEach(s =>
                //                {
                //                    var count = 0m;
                //                    decimal tuijian;
                //                    //count = typeCount.Select(w => w.Big).Sum() + typeCount.Select(w => w.Small).Sum();
                //                    count = Convert.ToDecimal(s.AvgBig + s.AvgSmall);
                //                    if (count > 0)
                //                    {
                //                        var pb = s.AvgBig / count;
                //                        var ps = s.AvgSmall / count;
                //                        if (pb > 0.5m)
                //                        {
                //                            s.PBig = pb.ToString("P");
                //                        }
                //                        if (ps > 0.5m)
                //                        {
                //                            s.PSmall = ps.ToString("P");
                //                        }
                //                    }
                //                    else
                //                    {
                //                        s.PBig = "";
                //                        s.PSmall = "";
                //                    }

                //                    count = Convert.ToDecimal(s.AvgDual + s.AvgOdd);
                //                    if (count > 0)
                //                    {
                //                        var pd = s.AvgDual / count;
                //                        var po = s.AvgOdd / count;
                //                        if (pd > 0.5m)
                //                        {
                //                            s.PDual = pd.ToString("P");
                //                        }
                //                        if (po > 0.5m)
                //                        {
                //                            s.POdd = po.ToString("P");
                //                        }
                //                    }
                //                    else
                //                    {
                //                        s.PDual = "";
                //                        s.POdd = "";
                //                    }
                //                    count = Convert.ToDecimal(s.AvgMiddle + s.AvgSide);
                //                    if (count > 0)
                //                    {
                //                        var pm = s.AvgMiddle / count;
                //                        var ps = s.AvgSide / count;
                //                        if (pm > 0.5m)
                //                        {
                //                            s.PMiddle = pm.ToString("P");
                //                        }
                //                        if (ps > 0.5m)
                //                        {
                //                            s.PSide = ps.ToString("P");
                //                        }
                //                    }
                //                    else
                //                    {
                //                        s.PMiddle = "";
                //                        s.PSide = "";
                //                    }

                //                });


                var stableNo = ds.Tables[4].AsEnumerable().Select(s => new LotteryStableNumber()
                {
                    Cnt = s.Field<int>("Cnt"),
                    Days = s.Field<int>("Days"),
                    RetNum = s.Field<int>("RetNum")
                }).ToList();
                result.LotteryStableNumber = new LotteryStableNumberVM();
                if (stableNo.Count >= 1)
                {
                    result.LotteryStableNumber.RetNum1 = stableNo[0].RetNum;
                    result.LotteryStableNumber.DayAndCnt1 = string.Format("{0}天/{1}次",stableNo[0].Days,stableNo[0].Cnt);
                }
                if (stableNo.Count >= 2)
                {
                    result.LotteryStableNumber.RetNum2 = stableNo[1].RetNum;
                    result.LotteryStableNumber.DayAndCnt2 = string.Format("{0}天/{1}次",stableNo[1].Days,stableNo[1].Cnt);
                }
                if (stableNo.Count >= 3)
                {
                    result.LotteryStableNumber.RetNum3 = stableNo[2].RetNum;
                    result.LotteryStableNumber.DayAndCnt3 = string.Format("{0}天/{1}次",stableNo[2].Days,stableNo[2].Cnt);
                }
                return result;
            }
        }

        public bool ValidateUserTime(int userSysNo,out string error)
        {
            error = "";

            var user = Queryuser(userSysNo);
            if (user == null)
            {
                error = "当前用户不存在";
                return false;
            }

            if (user.RechargeUseEndTime < DateTime.Now)
            {
                error = "需要充值才能查看分析数据";
                return false;
            }

            return true;
        }

        public bool DelRemind(int sysNo)
        {
            Session.CreateSQLQuery("delete RemindStatistics where SysNo=:sn")
                .SetParameter("sn",sysNo)
                .ExecuteUpdate();
            return true;
        }

        public List<RemindStatistics> QueryRemind(int gameSysNo,int regionSysNo,int siteSysNo,int userSysNo)
        {
            RefreshRemind(gameSysNo,regionSysNo,siteSysNo);
            var q = from a in Session.Query<RemindStatistics>()
                    where a.GameSysNo == gameSysNo
                          && a.SourceSysNo == regionSysNo
                          && a.SiteSysNo == siteSysNo
                          && a.UserSysNo == userSysNo
                          && a.Status == 1
                    select a;
            var reminds = q.ToList();

            var sysNos = string.Join(",",reminds.Select(p => p.SysNo).ToList());

            if (!string.IsNullOrEmpty(sysNos))
                Session.CreateSQLQuery("update RemindStatistics set Status=0 where SysNo in (" + sysNos + ")")
                    .ExecuteUpdate();

            return reminds;
        }

        public bool SaveRemind(RemindStatistics remind,out string error)
        {
            error = "";
            var q = from a in Session.Query<RemindStatistics>()
                    where a.SiteSysNo == remind.SiteSysNo
                          && a.SourceSysNo == remind.SourceSysNo
                          && a.UserSysNo == remind.UserSysNo
                          && a.GameSysNo == remind.GameSysNo
                          && a.RetNum == remind.RetNum
                    select a;
            if (q.SingleOrDefault() != null)
            {
                error = "此提醒已经设置";
                return false;
            }

            remind.Status = 0;
            Session.Save(remind);
            Session.Flush();
            return true;
        }

        /// <summary>
        /// 刷新连号提醒数据
        /// </summary>
        /// <param name="gameSysNo"></param>
        /// <param name="regionSysNo"></param>
        /// <param name="siteSysNo"></param>
        public void RefreshRemind(int gameSysNo,int regionSysNo,int siteSysNo)
        {
            var sql = SqlManager.GetSqlText("RefreshRemind");
            sql = string.Format(sql,gameSysNo,regionSysNo,siteSysNo);
            Session.CreateSQLQuery(sql).ExecuteUpdate();
        }

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
            result.Forecast = number.ToString(CultureInfo.InvariantCulture);
            return result;
        }

        /// <summary>
        /// 查询同一时间点的近20小时的数据
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="siteSysNo"> </param>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryLotteryByHourStep(DateTime dateTime,int siteSysNo,string tableName,int regionSysNo)
        {
            var datesStr = new List<string>();
            if (regionSysNo == 10001)
            {
                //北京
                if (dateTime.Hour == 0)
                {
                    dateTime = DateTime.Parse(dateTime.ToString("yyyy-MM-dd 09:05:00"));
                }
            }
            if (regionSysNo == 10002)
            {
                //加拿大
            }
            DateTime temp = dateTime;
            for (var i = 1;i <= 20;i++)
            {
                temp = temp.AddHours(-1);
                if (regionSysNo == 10001)
                {
                    if (temp.Hour < 9)
                    {
                        temp = DateTime.Parse(temp.AddDays(-1).ToString("yyyy-MM-dd 23:mm:ss"));
                    }
                }

                datesStr.Add("'" + temp.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            }

            var sql = @"
select top 20 *
from {0} with(nolock)
where  SiteSysNo={1} and datepart(minute,RetTime)="+dateTime.Minute.ToString()+@"
order by PeriodNum desc
";
            sql = string.Format(sql,tableName,siteSysNo);

            var q = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryForBJ))
                .List<LotteryForBJ>().ToList();

            MappingType(q);
            var result = new LotteryByTwentyPeriod();
            result.Lotteries = q;
            result.NotAppearNumber = GetNotAppearNo(q);
            result.Forecast = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }
        /// <summary>
        /// 查询同一时间点的近20天的数据
        /// </summary>
        /// <returns></returns>
        public LotteryByTwentyPeriod QueryLotteryByDay(DateTime dateTime,int siteSysNo,string tableName,int regionSysNo)
        {
            var datesStr = new List<string>();
            if (regionSysNo == 10001)
            {
                //北京
                if (dateTime.Hour == 0)
                {
                    dateTime = DateTime.Parse(dateTime.ToString("yyyy-MM-dd 09:05:00"));
                }
            }
            if (regionSysNo == 10002)
            {
                //加拿大
            }

            for (var i = 1;i <= 20;i++)
            {
                datesStr.Add("'" + dateTime.AddDays(-i).ToString("yyyy-MM-dd HH:mm:ss") + "'");
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
            result.Forecast = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
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
            //var times = Session.CreateSQLQuery(sql)
            //    .AddEntity(typeof(LotteryTimes))
            //    .SetParameter("START_DATE",DateTime.Parse(curDate.AddDays(-pageCount).AddDays(1).ToString("yyyy-MM-dd 00:00:00")))
            //    .SetParameter("END_DATE",DateTime.Now)
            //    .SetParameter("SiteSysNo",siteSysNo)
            //    .List<LotteryTimes>().ToList();

            //每页的数据
            sql = SqlManager.GetSqlText("QueryTrend3");
            sql = string.Format(sql,tableName,@from,to,siteSysNo);
            var data = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryExtByBJ))
                //.SetParameter("START_DATE",@from)
                //.SetParameter("END_DATE",to)
                //.SetParameter("SiteSysNo",siteSysNo)
                .List<LotteryExtByBJ>().ToList();


            var q = from a in data
                    group a by a.RetNum
                        into g
                        select new LotteryTimes()
                               {
                                   Name = g.Key.ToString(CultureInfo.InvariantCulture),
                                   Total = g.Count()
                               };
            var q2 = from a in data
                     group a by a.BigOrSmall
                         into g
                         select new LotteryTimes()
                                {
                                    Name = g.Key,
                                    Total = g.Count()
                                };
            var q3 = from a in data
                     group a by a.OddOrDual
                         into g
                         select new LotteryTimes()
                         {
                             Name = g.Key,
                             Total = g.Count()
                         };
            var q4 = from a in data
                     group a by a.MiddleOrSide
                         into g
                         select new LotteryTimes()
                         {
                             Name = g.Key,
                             Total = g.Count()
                         };

            var times = q.ToList();
            times.AddRange(q2);
            times.AddRange(q3);
            times.AddRange(q4);

            MappingType(data);

            var result = new LotteryTrend();
            result.LotteryTimeses = times;
            result.DataList = data;
            result.PageCount = pageCount;
            result.PageIndex = pageIndex + 1;

            return result;
        }
        public LotteryForBJ GetCurrentLottery(int siteSysNo,string tableName)
        {
            var sql = SqlManager.GetSqlText("GetCurrentLottery");
            sql = string.Format(sql,tableName,siteSysNo);

            var q = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryForBJ))
                .List<LotteryForBJ>().SingleOrDefault();
            return q;
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
            var curLottery = GetCurrentLottery(siteSysNo,tableName);
            var maxPeriod = curLottery.PeriodNum;
            var minPeriod = maxPeriod - maxTotal;

            //condition
            var condition = new StringBuilder();
            if (string.IsNullOrEmpty(date))
            {
                //condition.AppendFormat(" and CONVERT(varchar(100),BJ.RetTime,23)='{0}'",DateTime.Now.ToString("yyyy-MM-dd"));
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
                //.SetParameter("MIN_PERIOD",minPeriod)
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
        public LotteryTrend QuerySupperTrend(int siteSysNo,
            string date,
            int bHour,
            int eHour,
            string tableName)
        {

            var result = new LotteryTrend();
            //查询每个号码及类型的出现次数,总次数以maxTotal为准

            //condition
            var condition = new StringBuilder();
            if (string.IsNullOrEmpty(date))
            {
            }
            else
            {
                condition.AppendFormat(" and CONVERT(varchar(100),BJ.RetTime,23)='{0}'",DateTime.Parse(date).ToString("yyyy-MM-dd"));
            }
            if (bHour == eHour)
                condition.AppendFormat(" and datepart(hour,BJ.RetTime)={0}",bHour);
            else
            {
                eHour--;
                condition.AppendFormat(" and datepart(hour,BJ.RetTime)>={0}",bHour);
                condition.AppendFormat(" and datepart(hour,BJ.RetTime)<={0}",eHour);
            }

            //查询数字的出现次数
            var sql = @"
SELECT 
	CONVERT(NCHAR(40),BJ.RetNum) as Name,
	COUNT(BJ.RetNum) AS Total
FROM {1} BJ with(nolock)
	JOIN dbo.UseSite US  with(nolock)
		ON BJ.SiteSysNo=US.SysNo
WHERE BJ.SiteSysNo=:SITE_SYS_NO
    {0}
GROUP BY BJ.RetNum";
            sql = string.Format(sql,condition,tableName);
            var q1 = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryTimes))
                .SetParameter("SITE_SYS_NO",siteSysNo)
                .List<LotteryTimes>();
            //查询类型的出现次数
            sql = SqlManager.GetSqlText("QuerySupperTrend_28BJ_2");
            sql = string.Format(sql,condition,tableName);
            var q2 = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryTimes))
                .SetParameter("SITE_SYS_NO",siteSysNo)
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
            //            sql = @"SELECT COUNT(1) Total,
            //       :PAGE_INDEX PageIndex,
            //       :PAGE_SIZE PageSize,
            //       CEILING(COUNT(1)/CONVERT(DECIMAL,:PAGE_SIZE)) AS [PageCount]
            //FROM {1} BJ with(nolock)
            //	JOIN dbo.UseSite US with(nolock)
            //		ON BJ.SiteSysNo=US.SysNo
            //	JOIN dbo.ResultCategory_28 RC with(nolock)
            //		ON BJ.RetNum=RC.RetNum
            //WHERE BJ.SiteSysNo=:SITE_SYS_NO
            //      AND BJ.PeriodNum>:MIN_PERIOD";
            //            sql = string.Format(sql,condition,tableName);
            //            var q3 = Session.CreateSQLQuery(sql)
            //                .AddEntity(typeof(PageInfo))
            //                .SetParameter("SITE_SYS_NO",siteSysNo)
            //                .UniqueResult<PageInfo>();
            //            result.PageCount = q3.PageCount;
            //            result.PageIndex = q3.PageIndex;
            //list
            sql = @"
SELECT BJ.PeriodNum,
       BJ.RetTime,
       BJ.RetNum,
       RC.BigOrSmall,
       RC.MiddleOrSide,
       RC.OddOrDual
FROM {1} BJ with(nolock)
	JOIN dbo.UseSite US with(nolock)
		ON BJ.SiteSysNo=US.SysNo
	JOIN dbo.ResultCategory_28 RC with(nolock)
		ON BJ.RetNum=RC.RetNum
WHERE BJ.SiteSysNo=:SITE_SYS_NO
      {0}
order by BJ.RetTime DESC
";
            sql = string.Format(sql,condition,tableName);
            var q4 = Session.CreateSQLQuery(sql)
                .AddEntity(typeof(LotteryExtByBJ))
                .SetParameter("SITE_SYS_NO",siteSysNo)
                .List<LotteryExtByBJ>();
            result.DataList = q4.ToList();
            return result;
        }
        #endregion

        #region User
        public string ResetPsw(string userId,string q1,string a1,string q2,string a2,out string error)
        {
            error = "";
            var q = from a in Session.Query<User>()
                    where a.UserID == userId
                    select a;
            var user = q.SingleOrDefault();
            if (user == null)
            {
                error = "用户不存在";
                return "";
            }

            var ispass = false;
            if (user.SecurityQuestion1 == q1 && user.SecurityAnswer1 == a1)
            {
                ispass = true;
            }
            if (user.SecurityQuestion2 == q2 && user.SecurityAnswer2 == a2)
            {
                ispass = true;
            }
            if (!ispass)
            {
                error = "密保问题及答案不匹配";
                return "";
            }
            var newPsw = new Random().Next(100000,999999).ToString(CultureInfo.InvariantCulture);
            var result = newPsw;
            newPsw = CiphertextService.MD5Encryption(newPsw);
            newPsw = CiphertextService.MD5Encryption(newPsw);

            Session.CreateSQLQuery("update Users set UserPwd=:psw where SysNo=:sn")
                .SetParameter("psw",newPsw)
                .SetParameter("sn",user.SysNo)
                .ExecuteUpdate();
            error = "";
            return result;
        }
        public User Queryuser(int userSysNo)
        {
            var q = from a in Session.Query<User>()
                    where a.SysNo == userSysNo
                    select a;
            return q.SingleOrDefault();
        }
        public bool Login(string userId,string psw,out string error,out int userSysNo)
        {
            error = "";
            userSysNo = 0;
            var pswHash = CiphertextService.MD5Encryption(psw);
            var user = Session.QueryOver<User>().Where(p => p.UserID == userId && p.UserPwd == pswHash).SingleOrDefault<User>();
            if (user == null)
            {
                error = "用户不存在或密码错误";
                return false;
            }
            if (user.Status == -1)
            {
                error = "用户已锁定";
                return false;
            }
            if (user.Status == 0)
            {
                error = "用户未激活";
                return false;
            }
            //var pswHash = CiphertextService.MD5Encryption(psw);
            //if (pswHash != user.UserPwd)
            //{
            //    error = "密码错误";
            //    return false;
            //}
            //该用户的充值是否可用
            userSysNo = user.SysNo;
            return true;
        }
        public int Register(User user,out string error)
        {
            error = "";
            //检查用户是否存在
            var q = from a in Session.Query<User>()
                    where a.UserName == user.UserName
                    select a;
            if (q.SingleOrDefault() != null)
            {
                error = string.Format("用户名{0}已经存在",user.UserName);
                return -1;
            }
            //检查用户ID是否存在
            q = from a in Session.Query<User>()
                where a.UserID == user.UserID
                select a;
            if (q.SingleOrDefault() != null)
            {
                error = string.Format("用户ID{0}已经存在",user.UserID);
                return -2;
            }
            //每个ip只能每天只能注册3个
            var ip = GetClientIP();
            if (IPOver(ip))
            {
                error = string.Format("每个IP每天最多注册3个账号");
                return -3;
            }
            //电话号码验证

            //UserID必须是邮箱地址

            if (string.IsNullOrEmpty(user.SecurityQuestion1))
            {
                error = "问题1不能为空";
                return -4;
            }
            if (string.IsNullOrEmpty(user.SecurityAnswer1))
            {
                error = "答案1不能为空";
                return -5;
            }

            user.RegIP = GetClientIP();
            user.RegDate = DateTime.Now;
            user.RechargeUseBeginTime = DateTime.Now.AddYears(-1);
            user.RechargeUseEndTime = DateTime.Now.AddYears(-1);
            user.Status = 1;

            user.UserPwd = CiphertextService.MD5Encryption(user.UserPwd);
            var result = Session.Save(user);
            Session.Flush();
            IPAsc(ip);
            return (int)result;
        }
        public string ChangePsw(int userSysNo,string oldPsw,string newPsw,string q1,string a1,string q2,string a2)
        {
            var hasPsw = CiphertextService.MD5Encryption(oldPsw);
            var q = (from a in Session.Query<User>()
                     where a.SysNo == userSysNo && hasPsw == a.UserPwd
                     select a).SingleOrDefault();
            if (q == null)
            {
                return "密码错误或用户不存在";
            }
            bool isPass = q.SecurityQuestion1 == q1 && q.SecurityAnswer1 == a1;
            if (q.SecurityQuestion2 == q2 && q.SecurityAnswer2 == a2)
            {
                isPass = true;
            }
            if (!isPass)
            {
                return "问题验证失败";
            }

            q.UserPwd = CiphertextService.MD5Encryption(newPsw);
            Session.CreateSQLQuery("update Users set UserPwd=:psw where SysNo=:sysNo")
                .SetParameter("psw",q.UserPwd)
                .SetParameter("sysNo",q.SysNo)
                .ExecuteUpdate();

            return "";
        }
        #endregion

        public PageList<RemindStatistics> QueryRemind(int gameSysNo,int siteSysNo,int regionSysNo,int userSysNo,int pageIndex,int pageSize)
        {
            var count = Session.CreateSQLQuery("select count(1) from RemindStatistics with(nolock) where " +
                                               "UserSysNo=:usn " +
                //"and GameSysNo=:gsn " +
                //"and SourceSysNo=:ssn " +
                //"and SiteSysNo=:ssno" +
                                               "")
                                               .SetParameter("usn",userSysNo)
                //.SetParameter("gsn",gameSysNo)
                //.SetParameter("ssn",regionSysNo)
                //.SetParameter("ssno",siteSysNo)
                .UniqueResult<int>();

            //var q = Session.QueryOver<RemindStatistics>()
            //    .Where(p => p.GameSysNo == gameSysNo
            //                && p.SiteSysNo == siteSysNo
            //                && p.SourceSysNo == regionSysNo
            //                && p.UserSysNo == userSysNo)
            //    .Skip(pageIndex - 1)
            //    .Take(pageSize);

            var q =
                Session.CreateSQLQuery(@"
                    select * from 
                    (
                    select row_number() over(order by SysNo desc) as RowIndex,*
                    from dbo.RemindStatistics with(nolock)
                    where UserSysNo=:usn
                    ) as temp
                    where RowIndex>(:PageIndex-1)*:PageSize
	                    and RowIndex<:PageIndex*:PageSize
                    ")
                    .AddEntity(typeof(RemindStatistics))
                    .SetParameter("usn",userSysNo)
                //.SetParameter("gsn", gameSysNo).SetParameter("ssn", regionSysNo).
                //SetParameter("ssno", siteSysNo)
                    .SetParameter("PageIndex",pageIndex).SetParameter("PageSize",pageSize)
                    .List<RemindStatistics>();


            var result = new PageList<RemindStatistics>();
            result.Total = count;
            result.List = q.ToList();
            result.PageIndex = pageIndex;
            result.PageSize = pageSize;
            result.PageCount = (int)Math.Ceiling(count / (double)pageSize);
            return result;
        }

        public string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }


            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }

        public List<Notices> GetNotices()
        {
            return Session.QueryOver<Notices>()
                .Where(p => p.Status == 1)
                .OrderBy(p => p.Rank).Desc().Take(3).List<Notices>().ToList();
        }

        public void WritePayLog(PayLog log)
        {
            log.IP = GetClientIP();
            log.InDate = DateTime.Now;
            Session.Save(log);
            Session.Flush();
        }

        public void SavePayCard(PayCard card)
        {
            card.InDate = DateTime.Now;
            Session.Save(card);
            Session.Flush();
        }

        public PayCard GetPayCard(string cardNo,string base64Psw)
        {
            var q = from a in Session.Query<PayCard>()
                    where a.PayCardID == cardNo && a.PayCardPwd == base64Psw
                    select a;
            return q.SingleOrDefault();
        }

        public bool Recharge(int userSysNo,string cardNo,string cardPsw,out string error)
        {
            error = "";
            var pswb64 = Base64Encode(cardPsw);
            var card = GetPayCard(cardNo,pswb64);
            if (card == null)
            {
                error = "充值卡不存在";
                return false;
            }
            if (card.Status != 1)
            {
                error = "充值卡不可用";
                return false;
            }
            if (DateTime.Now > card.EndTime || DateTime.Now < card.BeginTime)
            {
                error = "充值卡已过期";
                return false;
            }
            //TimeSpan duation;
            //天
            //if (card.CategorySysNo == 1)
            //{
            //duation = card.EndTime - card.BeginTime;
            //}
            ////月
            //if (card.CategorySysNo == 2) { }
            //var duration = card.EndTime - card.BeginTime;

            var user = Queryuser(userSysNo);
            if (user == null)
            {
                error = "用户不存在";
                return false;
            }
            if (user.RechargeUseEndTime < DateTime.Now)
            {
                if (card.CategorySysNo == 1)
                    user.RechargeUseEndTime = DateTime.Now.AddDays(1);
                if (card.CategorySysNo == 2)
                    user.RechargeUseEndTime = DateTime.Now.AddMonths(1);
            }
            else
            {
                if (card.CategorySysNo == 1)
                    user.RechargeUseEndTime = user.RechargeUseEndTime.AddDays(1);
                if (card.CategorySysNo == 2)
                    user.RechargeUseEndTime = user.RechargeUseEndTime.AddMonths(1);
            }
            Session.CreateSQLQuery("update Users set PayUseEndTime=:endDate where SysNo=:sysNo")
                .SetParameter("endDate",user.RechargeUseEndTime)
                .SetParameter("sysNo",user.SysNo)
                .ExecuteUpdate();
            //Session.Update(user,user.SysNo);
            //Session.Flush();

            card.Status = 2;

            Session.CreateSQLQuery("update PayCard set Status=:s where SysNo=:sn")
                .SetParameter("s",2)
                .SetParameter("sn",card.SysNo)
                .ExecuteUpdate();
            //Session.Update(card,card.SysNo);
            //Session.Flush();

            var log = new PayLog();
            log.CardSysNo = card.SysNo;
            log.UserSysNo = userSysNo;

            WritePayLog(log);

            return true;
        }

        private void SetCache(string key,object val)
        {
            HttpContext.Current.Cache.Insert(key,val,null,DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59")),TimeSpan.Zero);
        }
        private T GetCache<T>(string key)
        {
            return (T)HttpContext.Current.Cache.Get(key);
        }
        private void IPAsc(string ip)
        {
            int? val = GetCache<int?>(ip);
            if (val.HasValue)
            {
                val++;

            }
            else
            {
                val = 1;
            }
            SetCache(ip,val);
        }
        private bool IPOver(string ip)
        {
            int? val = GetCache<int?>(ip);
            if (val.HasValue) return val.Value > 3;
            return false;
        }
        /// <summary>
        /// 进行base64编码
        /// </summary>
        /// <param name="data">被编码数据</param>
        /// <returns></returns>
        public static string Base64Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Base64Encode: " + ex.Message);
            }
        }

        /// <summary>
        /// 进行base64解码
        /// </summary>
        /// <param name="data">被解码数据</param>
        /// <returns></returns>
        public static string Base64Decode(string data)
        {
            try
            {
                var encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte,0,todecode_byte.Length);
                var decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte,0,todecode_byte.Length,decoded_char,0);
                var result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Base64Decode: " + ex.Message);
            }
        }

    }
}
