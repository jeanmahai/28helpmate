using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System;
using Business;
using Model.Model;
using Model.ResponseModel;

namespace WebService
{
    /// <summary>
    /// LotteryWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [XmlInclude(typeof(LotteryByTwentyPeriod))]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LotteryWebService:System.Web.Services.WebService
    {
        public TokenHeader Token;
        private static LotteryDAL _mDal;
        private readonly string ERROR_VALIDATE_TOKEN = "TOKEN验证失败";
        private readonly string MESSAGE_SUCCESS = "执行成功";

        private LotteryDAL Dal
        {
            get
            {
                if (_mDal == null)
                {
                    _mDal = new LotteryDAL();
                }
                return _mDal;
            }
        }
        private bool ValidateToken(TokenHeader header)
        {
            var token = Dal.GenerateToken(header.ToString(SessionValue.UserName,SessionValue.Key));
            return Dal.ValidateToken(header.ToString(),
                token);
        }

        [WebMethod(Description = "查询最近20期号码相同的下一期的开奖结果")]
        [SoapHeader("Token")]
        public ResultRM<LotteryByTwentyPeriod> QueryNextLotteryWithSameNumber(int number,string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriod>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryNextLotteryWithSameNumberForBJ(number,userSite.SysNo);
                }
                else
                {
                    result.Data = new LotteryByTwentyPeriod();
                }

                result.Message = MESSAGE_SUCCESS;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }
        [WebMethod(Description = "查询同一时间点的近20小时的数据")]
        [SoapHeader("Token")]
        public ResultRM<LotteryByTwentyPeriod> QueryLotteryByHourStep(DateTime time,string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriod>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryLotteryByHourStepForBJ(time,userSite.SysNo);
                }
                else
                {
                    result.Data = new LotteryByTwentyPeriod();
                }

                result.Success = true;
                result.Message = MESSAGE_SUCCESS;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }
        [WebMethod(Description = "查询同一时间点的近20天的数据")]
        [SoapHeader("Token")]
        public ResultRM<LotteryByTwentyPeriod> QueryLotteryByDay(DateTime time,string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriod>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryLotteryByDayForBJ(time,userSite.SysNo);
                }
                else
                {
                    result.Data = new LotteryByTwentyPeriod();
                }

                result.Success = true;
                result.Message = MESSAGE_SUCCESS;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }
        [WebMethod(Description = "查询最近20期的结果")]
        [SoapHeader("Token")]
        public ResultRM<LotteryByTwentyPeriod> QueryLotteryByTwenty(string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriod>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryTop20ForBJ(userSite.SysNo);
                }
                else
                {
                    result.Data = new LotteryByTwentyPeriod();
                }
                result.Success = true;
                result.Message = MESSAGE_SUCCESS;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }
        [WebMethod(Description = "查询最近1期的结果")]
        [SoapHeader("Token")]
        public ResultRM<LotteryForBJ> QueryCurrentLottery(string siteName)
        {
            var result = new ResultRM<LotteryForBJ>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = (from a in Dal.QueryTop20ForBJ(userSite.SysNo).Lotteries
                                   select a).FirstOrDefault();
                }
                else
                {
                    result.Data = new LotteryForBJ();
                }
                result.Success = true;
                result.Message = MESSAGE_SUCCESS;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }
        [WebMethod(Description = "查询开奖结果")]
        [SoapHeader("Token")]
        public ResultRM<PageList<LotteryForBJ>> Query(LotteryFilter filter)
        {
            var result = new ResultRM<PageList<LotteryForBJ>>();
            if (ValidateToken(Token))
            {
                result.Data = Dal.QueryForBJ(filter);
                result.Success = true;
                result.Message = MESSAGE_SUCCESS;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }
        [WebMethod(Description = "登录,如果返回空字符串则登录失败,成功返回key")]
        public string Login(string userName,string psw)
        {
            var isSuccess = Dal.Login(userName,psw);
            if (isSuccess)
            {
                SessionValue.UserName = userName;
                SessionValue.Key = Guid.NewGuid().ToString();
                return SessionValue.Key;
            }
            return "";
        }
        [WebMethod(Description = "注册")]
        public int Register(User user)
        {
            return Dal.Register(user);
        }
    }
}
