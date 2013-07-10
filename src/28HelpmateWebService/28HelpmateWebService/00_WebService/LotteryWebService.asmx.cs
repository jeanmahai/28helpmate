using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System;
using Business;
using Model;
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
            //if (Dal.ValidateToken(header.ToString(SessionValue.Key),header.Token))
            //{
            return true;
            //}
            //return false;
        }

        [WebMethod(Description = "查询模块1-模块4的数据",EnableSession = true)]
        [SoapHeader("Token")]
        public ResultRM<CustomModules> GetCustomeModule()
        {
            var result = new ResultRM<CustomModules>();
            if (ValidateToken(Token))
            {
                result.Data = new CustomModules();
                var lastestLottery = Dal.MaxPeriod_28BJ();

                result.Data.M1 = Dal.QueryNextLotteryWithSameNumber(lastestLottery.RetNum,Token.SiteSourceSysNo,GetTableName(Token.RegionSourceSysNo));
                result.Data.M2 = Dal.QueryLotteryByHourStep(lastestLottery.RetTime.AddMinutes(5),Token.SiteSourceSysNo,GetTableName(Token.RegionSourceSysNo));
                result.Data.M3 = Dal.QueryLotteryByDay(lastestLottery.RetTime.AddMinutes(5),Token.SiteSourceSysNo,GetTableName(Token.RegionSourceSysNo));
                result.Data.M4 = Dal.QueryTop20(Token.SiteSourceSysNo,GetTableName(Token.RegionSourceSysNo));
                result.Data.CurrentLottery = lastestLottery;
                if (GetTableName(Token.RegionSourceSysNo)==ConstValue.Source_Data_10001_28_BeiJing)
                {
                    result.Data.NextLottery = new LotteryForBJ()
                    {
                        PeriodNum = lastestLottery.PeriodNum + 1
                    };
                    if(lastestLottery.RetTime.ToString("HH:mm")=="23:55")
                    {
                        result.Data.NextLottery.RetTime =
                            DateTime.Parse(lastestLottery.RetTime.AddDays(1).ToString("yyyy-MM-dd 09:05:00"));
                    }
                    else
                    {
                        result.Data.NextLottery.RetTime =
                            lastestLottery.RetTime.AddMinutes(AppSettingValues.BJLotteryInteval);
                    }
                }
                if (GetTableName(Token.RegionSourceSysNo) == ConstValue.Source_Data_10002_28_Canada)
                {
                    result.Data.NextLottery = new LotteryForBJ()
                    {
                        PeriodNum = lastestLottery.PeriodNum + 1,
                        RetTime = lastestLottery.RetTime.AddMinutes(AppSettingValues.CanadaLotteryInteval)
                    };
                }
                
                result.Success = true;
                result.Key = Dal.generateKey();
                SessionValue.Key = result.Key;
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
        public ResultRM<PageList<LotteryForBJ>> Query(LotteryFilterForBJ filterForBj)
        {
            var result = new ResultRM<PageList<LotteryForBJ>>();
            if (ValidateToken(Token))
            {
                result.Data = Dal.Query_28BJ(filterForBj);
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
                //SessionValue.UserName = userName;
                //SessionValue.Key = Guid.NewGuid().ToString();
                //return SessionValue.Key;
            }
            return "";
        }

        [WebMethod(Description = "注册")]
        public int Register(User user)
        {
            return Dal.Register(user);
        }

        [WebMethod(Description = "生成验证码")]
        public string GenerateCode()
        {
            var code = Dal.GenerateCode();
            //SessionValue.Code = code;
            return code;
        }

        [WebMethod(Description = "一般走势图,分页从1开始",EnableSession = true)]
        [SoapHeader("Token")]
        public ResultRM<LotteryTrend> QueryTrend(int pageIndex)
        {
            //LotteryTrend
            var result = new ResultRM<LotteryTrend>();
            if (ValidateToken(Token))
            {
                result.Data = Dal.QueryTrend(Token.SiteSourceSysNo,pageIndex,AppSettingValues.PageCount,GetTableName(Token.RegionSourceSysNo));
                result.Success = true;
                result.Key = Dal.generateKey();
                SessionValue.Key = result.Key;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }

        [WebMethod(Description = "遗漏号码",EnableSession = true)]
        [SoapHeader("Token")]
        public ResultRM<List<OmitStatistics>> QueryOmission()
        {
            var result = new ResultRM<List<OmitStatistics>>();
            if (ValidateToken(Token))
            {
                var data = Dal.QueryOmissionAll(Token.GameSourceSysNo,Token.SiteSourceSysNo,Token.RegionSourceSysNo);
                result.Data = data;
                result.Success = true;
                result.Key = Dal.generateKey();
                SessionValue.Key = result.Key;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }

        [WebMethod(Description = "超级走势图,分页从1开始",EnableSession = true)]
        [SoapHeader("Token")]
        public ResultRM<LotteryTrend> QuerySupperTrend(int pageIndex,
            int pageSize,
            string date,
            string hour,
            string minute)
        {
            var result = new ResultRM<LotteryTrend>();
            if (ValidateToken(Token))
            {
                result.Data = Dal.QuerySupperTrend(Token.SiteSourceSysNo,pageIndex,pageSize,AppSettingValues.MaxTotal,date,hour,minute,GetTableName(Token.RegionSourceSysNo));
                result.Success = true;
                result.Key = Dal.generateKey();
                SessionValue.Key = result.Key;
            }
            else
            {
                result.Success = false;
                result.Message = ERROR_VALIDATE_TOKEN;
            }
            return result;
        }
        [WebMethod(Description = "获得服务器的时间")]
        public DateTime GetServerDate()
        {
            return DateTime.Now;
        }

        private string GetTableName(int regionSourceSysNo)
        {
            string tableName;
            if (regionSourceSysNo == 10002)
            {
                tableName = ConstValue.Source_Data_10002_28_Canada;
            }
            else
            {
                tableName = ConstValue.Source_Data_10001_28_BeiJing;
            }
            return tableName;
        }
    }
}
