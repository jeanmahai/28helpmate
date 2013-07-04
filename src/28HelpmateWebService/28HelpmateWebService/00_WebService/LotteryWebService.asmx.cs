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
    [XmlInclude(typeof(LotteryByTwentyPeriodRM))]
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
            return Dal.ValidateToken(header.UserId, Token.Psw, header.Token);
        }

        [WebMethod(Description = "查询最近20期号码相同的下一期的开奖结果")]
        [SoapHeader("Token")]
        public ResultRM<LotteryByTwentyPeriodRM> QueryNextLotteryWithSameNumber(int number,string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryNextLotteryWithSameNumberForBJ(number,userSite.SysNo);
                }
                else
                {
                    result.Data = new LotteryByTwentyPeriodRM();
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
        public ResultRM<LotteryByTwentyPeriodRM> QueryLotteryByHourStep(DateTime time,string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryLotteryByHourStepForBJ(time,userSite.SysNo);
                }
                else
                {
                    result.Data = new LotteryByTwentyPeriodRM();
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
        public ResultRM<LotteryByTwentyPeriodRM> QueryLotteryByDay(DateTime time,string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryLotteryByDayForBJ(time,userSite.SysNo);
                }
                else
                {
                    result.Data = new LotteryByTwentyPeriodRM();
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
        public ResultRM<LotteryByTwentyPeriodRM> QueryLotteryByTwenty(string siteName)
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if (ValidateToken(Token))
            {
                var userSite = Dal.QueryUserSite(siteName);
                if (userSite != null)
                {
                    result.Data = Dal.QueryTop20ForBJ(userSite.SysNo);
                }else
                {
                    result.Data=new LotteryByTwentyPeriodRM();
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
        public ResultRM<Lottery> QueryCurrentLottery(string siteName)
        {
            var result = new ResultRM<Lottery>();
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
                    result.Data = new Lottery();
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
        public ResultRM<PageList<Lottery>> Query(LotteryFilter filter)
        {
            var result = new ResultRM<PageList<Lottery>>();
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
        [WebMethod(Description = "登录")]
        public bool Login(int sysNo,string psw)
        {
            return Dal.Login(sysNo,psw);
        }
        [WebMethod(Description = "注册")]
        public int Register(User user)
        {
            return Dal.Register(user);
        }
    }
}
