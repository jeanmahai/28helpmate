using System;
using System.Text;
using System.Collections.Generic;
using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.LotteryWebService;

namespace UnitTest
{
    [TestClass]
    public class WebServiceUT
    {
        private static LotteryWebServiceSoapClient m_client = new LotteryWebServiceSoapClient();
        private static LotteryDAL m_Dal = new LotteryDAL();

        [TestMethod]
        public void QueryLotteryByTwentyServiceTest()
        {
            var data = m_client.QueryLotteryByTwenty(new TokenHeader()
                                          {
                                              Token = "1"
                                          });
            Console.WriteLine(data.Message);
            var rm = data.Data as LotteryByTwentyPeriodRM;
            if(rm!=null)
            {
                foreach (var a in rm.Lotteries)
                {
                    Console.WriteLine("期号{0}", a.PeriodNum);
                }
            }
        }
        [TestMethod]
        public void Query20BySameNoTest()
        {
            var data = m_Dal.Query20BySameNo(17);
            foreach(var a in data)
            {
                Console.WriteLine("期号{0}",a.PeriodNum);
            }
        }
        [TestMethod]
        public void QueryNextLotteryWithSameNumberTest()
        {
            var data = m_Dal.QueryNextLotteryWithSameNumber(17);
            Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
                data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }

        [TestMethod]
        public void QueryLotteryByDayTest()
        {
            var data = m_Dal.QueryLotteryByDay(DateTime.Parse("2013-06-30 11:30:00.000"));
            Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
                data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }

        [TestMethod]
        public void QueryLotteryByHourStepTest()
        {
            var data = m_Dal.QueryLotteryByHourStep(DateTime.Parse("2013-06-30 11:30:00.000"));
            Console.WriteLine(string.Format("大{0},小{1},单{2},双{3},中{4},边{5}",
                data.BigP,data.SmallP,data.OddP,data.EvenP,data.CenterP,data.SideP));
        }
    }
}
