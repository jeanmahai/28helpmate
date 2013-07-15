using System;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
using UnitTest.LotteryWebService;
using RemindStatistics = Model.Model.RemindStatistics;

namespace UnitTest
{
    [TestClass]
    public class WebServiceUT
    {
        private static LotteryWebServiceSoapClient m_client = new LotteryWebServiceSoapClient();
        private static LotteryDAL m_Dal = new LotteryDAL();
        private const string SITE_NAME = "龙虎";

        //[TestMethod]
        //public void QueryLotteryByTwentyServiceTest()
        //{
        //    var data = m_client.QueryLotteryByTwenty(new TokenHeader()
        //                                  {
        //                                      Token = "1"
        //                                  },SITE_NAME);
        //    Console.WriteLine(data.Message);
        //    var rm = data.Data;
        //    if (rm != null)
        //    {
        //        foreach (var a in rm.Lotteries)
        //        {
        //            Console.WriteLine("期号{0}",a.PeriodNum);
        //        }
        //    }
        //}

        //[TestMethod]
        //public void QueryCurrentLotteryServiceTest()
        //{
        //    var data = m_client.QueryCurrentLottery(new TokenHeader()
        //    {
        //        Token = "1"
        //    },SITE_NAME);
        //    Console.WriteLine(data.Message);
        //    Console.WriteLine("期号{0}",data.Data.PeriodNum);
        //}

        [TestMethod]
        public void QueryLotteryByDayServiceTest()
        {
            //var data = m_client.QueryLotteryByDay(new TokenHeader(),DateTime.Now,SITE_NAME);
            //Console.WriteLine(data.Message);
            //foreach (var a in data.Data.Lotteries)
            //{
            //    Console.WriteLine("期号{0}",a.PeriodNum);
            //}
            //m_client.CookieContainer = "";
        }
        [TestMethod]
        public void QueryLotteryByHourStepServiceTest()
        {
            var data =m_Dal.QueryLotteryByHourStep(DateTime.Parse("2013-7-14 21:05:00"),10001,"SourceData_28_Beijing"); //m_client.QueryLotteryByHourStep(new TokenHeader(),DateTime.Parse("2013-7-2 21:45:00"),SITE_NAME);
            //Console.WriteLine(data.Message);
            Console.WriteLine(data.Lotteries.Count);
            foreach (var a in data.Lotteries)
            {
                Console.WriteLine("期号{0}",a.PeriodNum);
            }
        }
        [TestMethod]
        public void QueryNextLotteryWithSameNumberServiceTest()
        {
            //var data = m_client.QueryNextLotteryWithSameNumber(new TokenHeader(),1,SITE_NAME);
            //Console.WriteLine(data.Message);
            //foreach (var a in data.Data.Lotteries)
            //{
            //    Console.WriteLine("期号{0}",a.PeriodNum);
            //}
        }
        [TestMethod]
        public void Query20BySameNoTest()
        {
            //var data = m_Dal.Query20BySameNo(17,QueryUserSiteSysNo());
            //foreach (var a in data)
            //{
            //    Console.WriteLine("期号{0}",a.PeriodNum);
            //}
        }
        [TestMethod]
        public void QueryNextLotteryWithSameNumberTest()
        {
            //var data = m_Dal.QueryNextLotteryWithSameNumber(17,QueryUserSiteSysNo());
            //Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
            //    data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }
        [TestMethod]
        public void QueryLotteryByDayTest()
        {
            //var data = m_Dal.QueryLotteryByDay(DateTime.Parse("2013-06-30 11:30:00.000"),
            //    QueryUserSiteSysNo());
            //Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
            //    data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }
        [TestMethod]
        public void QueryLotteryByHourStepTest()
        {
            //var data = m_Dal.QueryLotteryByHourStep(DateTime.Parse("2013-06-30 11:30:00.000")
            //    ,QueryUserSiteSysNo());
            //Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
            //    data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
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
            string error;
            int userSysNo;
            Console.WriteLine(string.Format("{0},{1},{2}",m_Dal.Login("xxcode@163.com","115922",out error,out userSysNo),error,userSysNo));
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
        public void QueryTrend_Test()
        {
            //client
            var head = new TokenHeader()
                       {
                           GameSourceSysNo = 10001,
                           RegionSourceSysNo = 10001,
                           SiteSourceSysNo = 10001,
                           Token = "",
                           UserSysNo = 1
                       };
            var result = m_client.QueryTrend(head,1);

            var head2 = new TokenHeader()
            {
                GameSourceSysNo = 10001,
                RegionSourceSysNo = 10001,
                SiteSourceSysNo = 10002,
                Token = "",
                UserSysNo = 1
            };
            var result2 = m_client.QueryTrend(head2,1);

            for (var i = 0;i < 5;i++)
            {
                Console.WriteLine(string.Format("{0},{1},{2}",result.Data.DataList[i].PeriodNum,result.Data.DataList[i].RetNum,result.Data.DataList[i].RetTime.ToString()));
                Console.WriteLine(string.Format("{0},{1},{2}",result2.Data.DataList[i].PeriodNum,result2.Data.DataList[i].RetNum,result2.Data.DataList[i].RetTime.ToString()));
                Console.WriteLine("=============");
            }
        }
        [TestMethod]
        public void GetCustomeModule_Test()
        {
            var head = new TokenHeader()
            {
                GameSourceSysNo = 28,
                RegionSourceSysNo = 10001,
                SiteSourceSysNo = 10001,
                Token = "",
                UserSysNo = 1
            };
            var result = m_client.GetCustomeModule(head);

        }

        [TestMethod]
        public void QueryOmissionTest()
        {
            var head = new TokenHeader()
            {
                GameSourceSysNo = 10001,
                RegionSourceSysNo = 10001,
                SiteSourceSysNo = 10001,
                Token = "",
                UserSysNo = 1
            };
            var result = m_client.QueryOmission(head);
        }

        [TestMethod]
        public void QuerySupperTrend_Test()
        {
            var head = new TokenHeader()
            {
                GameSourceSysNo = 10001,
                RegionSourceSysNo = 10002,
                SiteSourceSysNo = 10001,
                Token = "",
                UserSysNo = 1
            };
            var result = m_client.QuerySupperTrend(head,1,10,"","","");
            foreach (var t in result.Data.LotteryTimeses)
            {
                Console.WriteLine(string.Format("{0}:{1}",t.Name,t.Total));
            }
            Console.WriteLine(string.Format("页数:{0},当前数量:{1},{2}",result.Data.PageCount,result.Data.DataList.Length,result.Data.PageIndex));
            foreach (var item in result.Data.DataList)
            {
                Console.WriteLine(string.Format("{0},{1},{2}",item.PeriodNum,item.RetNum,item.RetTime.ToString()));
            }
        }

        [TestMethod]
        public void GetClientIP_Test()
        {
            //Console.WriteLine(m_client.GetClientIP());
        }

        [TestMethod]
        public void TestSession()
        {
            var client = new LotteryService2.LotteryWebService();
            client.TokenHeaderValue = new LotteryService2.TokenHeader();
            //Console.WriteLine(m_client.GetClientIP());
        }

        [TestMethod]
        public void TestRegister()
        {
            var user = new UnitTest.LotteryWebService.User()
                       {
                           UserID = "jeanma",
                           UserPwd = "jeanma",
                           UserName = "jeanma",
                           SecurityQuestion1 = "1",
                           SecurityAnswer1 = "1"
                       };
            var result = m_client.Register(user);
            Console.WriteLine(result.Message);
        }

        [TestMethod]
        public void Test_QueryUser()
        {
            var a = m_Dal.Queryuser(9);
        }
        [TestMethod]
        public void Test_ChangePsw()
        {
            var h = new TokenHeader();
            h.UserSysNo = 5;
            var result= m_client.ChangePsw(h, "12345678", "123456", "你的出生地？", "abc", "", "");
            Console.WriteLine(result.Message);
            //Console.WriteLine(m_Dal.ChangePsw(5, "jeanma", "12345678", "你的出生地？", "abc", "", ""));
            //var a = m_Dal.ChangePsw(9,"115922","12345678","你的出生地？","abc","","");
        }
        [TestMethod]
        public void Test_Recharge()
        {
            string error;
            var a = m_Dal.Recharge(9,"123","123",out error);
            Console.WriteLine(error);
        }
        [TestMethod]
        public void Test_SaveRemind()
        {
            RemindStatistics data=new RemindStatistics();
            data.GameSysNo = 10001;
            data.RetNum = 1;
            data.SiteSysNo = 10001;
            data.Status = 1;
            data.UserSysNo = 5;
            data.Cnt = 1;
            
            string error;
            var a = m_Dal.SaveRemind(data,out error);
            Console.WriteLine(error);
        }

        [TestMethod]
        public void Test_QueryRemind()
        {

            var a = m_Dal.QueryRemind(10001,10001,10001,9,1,3);
            Console.WriteLine(a.List.Count);


            //var h = new TokenHeader();
            //h.UserSysNo = 9;
            //h.GameSourceSysNo = 10001;
            //h.RegionSourceSysNo = 10001;
            //h.SiteSourceSysNo = 10001;
            //var a = m_client.QueryRemind(h, 1, 23);
            //Console.WriteLine(a.Data.List.Length);
        }
    }
}
