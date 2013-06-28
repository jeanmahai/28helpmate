using System.Web.Services;
using Model.ResponseModel;
using System;

namespace WebService
{
    /// <summary>
    /// LotteryWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LotteryWebService:System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public LotteryByTwentyPeriodRM QueryNextLotteryWithSameNumber(int number)
        {
            return null;
        }
        [WebMethod]
        public LotteryByTwentyPeriodRM QueryLotteryByHourStep(DateTime time)
        {
            return null;
        }
        [WebMethod]
        public LotteryByTwentyPeriodRM QueryLotteryByDay(DateTime time)
        {
            return null;
        }
        [WebMethod]
        public LotteryByTwentyPeriodRM QueryLotteryByTwenty()
        {
            return null;
        }
    }
}
