using System;
using System.Text;
using System.Collections.Generic;
using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
using UnitTest.LotteryWebService;

namespace UnitTest
{
    [TestClass]
    public class WebServiceUT
    {
        private static LotteryWebServiceSoapClient m_client = new LotteryWebServiceSoapClient();
        private static LotteryDAL m_Dal = new LotteryDAL();
        private const string SITE_NAME = "龙虎";

        [TestMethod]
        public void QueryLotteryByTwentyServiceTest()
        {
            var data = m_client.QueryLotteryByTwenty(new TokenHeader()
                                          {
                                              Token = "1"
                                          },SITE_NAME);
            Console.WriteLine(data.Message);
            var rm = data.Data;
            if (rm != null)
            {
                foreach (var a in rm.Lotteries)
                {
                    Console.WriteLine("期号{0}",a.PeriodNum);
                }
            }
        }

        [TestMethod]
        public void QueryCurrentLotteryServiceTest()
        {
            var data = m_client.QueryCurrentLottery(new TokenHeader()
            {
                Token = "1"
            },SITE_NAME);
            Console.WriteLine(data.Message);
            Console.WriteLine("期号{0}",data.Data.PeriodNum);
        }

        [TestMethod]
        public void QueryLotteryByDayServiceTest()
        {
            var data = m_client.QueryLotteryByDay(new TokenHeader(),DateTime.Now,SITE_NAME);
            Console.WriteLine(data.Message);
            foreach (var a in data.Data.Lotteries)
            {
                Console.WriteLine("期号{0}",a.PeriodNum);
            }
        }

        [TestMethod]
        public void QueryLotteryByHourStepServiceTest()
        {
            var data = m_client.QueryLotteryByHourStep(new TokenHeader(),DateTime.Parse("2013-7-2 21:45:00"),SITE_NAME);
            Console.WriteLine(data.Message);
            foreach (var a in data.Data.Lotteries)
            {
                Console.WriteLine("期号{0}",a.PeriodNum);
            }
        }

        [TestMethod]
        public void QueryNextLotteryWithSameNumberServiceTest()
        {
            var data = m_client.QueryNextLotteryWithSameNumber(new TokenHeader(),1,SITE_NAME);
            Console.WriteLine(data.Message);
            foreach (var a in data.Data.Lotteries)
            {
                Console.WriteLine("期号{0}",a.PeriodNum);
            }
        }

        [TestMethod]
        public void Query20BySameNoTest()
        {
            var data = m_Dal.Query20BySameNo_28BJ(17,QueryUserSiteSysNo());
            foreach (var a in data)
            {
                Console.WriteLine("期号{0}",a.PeriodNum);
            }
        }
        [TestMethod]
        public void QueryNextLotteryWithSameNumberTest()
        {
            var data = m_Dal.QueryNextLotteryWithSameNumber_28BJ(17,QueryUserSiteSysNo());
            Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
                data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }
        [TestMethod]
        public void QueryLotteryByDayTest()
        {
            var data = m_Dal.QueryLotteryByDay_28BJ(DateTime.Parse("2013-06-30 11:30:00.000"),
                QueryUserSiteSysNo());
            Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
                data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }
        [TestMethod]
        public void QueryLotteryByHourStepTest()
        {
            var data = m_Dal.QueryLotteryByHourStep_28BJ(DateTime.Parse("2013-06-30 11:30:00.000")
                ,QueryUserSiteSysNo());
            Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
                data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }
        [TestMethod]
        public void QueryUserSiteTest()
        {
            var data = m_Dal.QueryUserSite("龙虎");
            Console.WriteLine(string.Format("{0},{1}",
                data.SysNo,data.SiteName));
            //return data.SysNo;
        }
        public int QueryUserSiteSysNo()
        {
            var data = m_Dal.QueryUserSite("龙虎");
            Console.WriteLine(string.Format("{0},{1}",
                data.SysNo,data.SiteName));
            return data.SysNo;
        }
        [TestMethod]
        public void QueryTest()
        {
            var filter = new Model.ResponseModel.LotteryFilterForBJ();
            filter.PageIndex = 1;
            filter.PageSize = 10;

            var data = m_Dal.Query_28BJ(filter);
            Console.WriteLine(string.Format("total:{0}",data.Total));
            foreach (var item in data.List)
            {
                Console.WriteLine(string.Format("期号{0}",item.PeriodNum));
            }

        }
        [TestMethod]
        public void RegisterTest()
        {
            //var user = new User()
            //           {
            //               UserID = "test28",
            //               RechargeUseBeginTime = DateTime.Now,
            //               RechargeUseEndTime = DateTime.Now,
            //               RegDate = DateTime.Now,
            //               RegIP = "123",
            //               Status = 0,
            //               UserName = "test28",
            //               UserPwd = "test28"
            //           };
            //var result=m_Dal.Register(user);
            //Console.WriteLine(result);
        }
        [TestMethod]
        public void LoginTest()
        {
            //Console.WriteLine(string.Format("{0}",m_Dal.Login(1,"test")));
        }
        [TestMethod]
        public void QueryOmissionAllForBJTest()
        {
            //var result=m_Dal.QueryOmissionAllForBJ();
        }

        [TestMethod]
        public void GenerateCodeTest()
        {
            Console.WriteLine(m_Dal.GenerateCode());
        }

        [TestMethod]
        public void QueryTrend_28BJTest()
        {
            var from = DateTime.Now.AddDays(-1);
            var to = DateTime.Now;
            var pageSize = 1000;
            var pageIndex = 0;
            var result=m_client.QueryTrend(from, to, pageSize, pageIndex);
            //m_Dal.QueryTrend_28BJ(from, to, pageIndex, pageSize);
        }
    }
}
