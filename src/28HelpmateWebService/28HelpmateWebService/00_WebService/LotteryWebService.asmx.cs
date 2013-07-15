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
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LotteryWebService:System.Web.Services.WebService
    {
        public TokenHeader ReqHeader;
        private static LotteryDAL _mDal;
        private readonly int ERROR_VALIDATE_TOKEN_CODE = 10001;
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

        private bool ValidateToken(TokenHeader reqHeader,out string error)
        {
            error = "";
            //if (Dal.ValidateToken(header.ToString(SessionValue.Key), header.Token))
            if (!Dal.ValidateToken(reqHeader.ToString(UserKeys.ReadKey(reqHeader.UserSysNo)),reqHeader.Token))
            {
                error = ERROR_VALIDATE_TOKEN;
                return false;
            }
            //验证是否有充值时间
            //var user = Dal.Queryuser(reqHeader.UserSysNo);
            //if (user != null)
            //{
            //    if (user.RechargeUseEndTime < DateTime.Now)
            //    {
            //        error = "需要充值才能查看分析数据";
            //        return false;
            //    }
            //}
            //else
            //{
            //    error = "用户不存在";
            //    return false;
            //}
            return true;
        }

        [WebMethod(Description = "查询模块1-模块4的数据",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<CustomModules> GetCustomeModule()
        {
            var result = new ResultRM<CustomModules>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                if(!Dal.ValidateUserTime(ReqHeader.UserSysNo,out error))
                {
                    result.Success = false;
                    result.Message = error;
                    return result;
                }

                result.Data = new CustomModules();
                var lastestLottery = Dal.GetCurrentLottery(ReqHeader.SiteSourceSysNo,GetTableName(ReqHeader.RegionSourceSysNo));

                result.Data.M1 = Dal.QueryNextLotteryWithSameNumber(lastestLottery.RetNum,ReqHeader.SiteSourceSysNo,GetTableName(ReqHeader.RegionSourceSysNo));
                result.Data.M2 = Dal.QueryLotteryByHourStep(lastestLottery.RetTime.AddMinutes(5),ReqHeader.SiteSourceSysNo,GetTableName(ReqHeader.RegionSourceSysNo));
                result.Data.M3 = Dal.QueryLotteryByDay(lastestLottery.RetTime.AddMinutes(5),ReqHeader.SiteSourceSysNo,GetTableName(ReqHeader.RegionSourceSysNo));
                result.Data.M4 = Dal.QueryTop20(ReqHeader.SiteSourceSysNo,GetTableName(ReqHeader.RegionSourceSysNo));
                result.Data.CurrentLottery = lastestLottery;
                if (GetTableName(ReqHeader.RegionSourceSysNo) == ConstValue.Source_Data_10001_28_BeiJing)
                {
                    result.Data.NextLottery = new LotteryForBJ()
                    {
                        PeriodNum = lastestLottery.PeriodNum + 1
                    };
                    if (lastestLottery.RetTime.ToString("HH:mm") == "23:55")
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
                if (GetTableName(ReqHeader.RegionSourceSysNo) == ConstValue.Source_Data_10002_28_Canada)
                {
                    result.Data.NextLottery = new LotteryForBJ()
                    {
                        PeriodNum = lastestLottery.PeriodNum + 1,
                        RetTime = lastestLottery.RetTime.AddMinutes(AppSettingValues.CanadaLotteryInteval)
                    };
                }

                result.Success = true;
                NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
            }
            return result;
        }

        //[WebMethod(Description = "查询开奖结果",EnableSession = true)]
        //[SoapHeader("ReqHeader",Direction = SoapHeaderDirection.In)]
        //public ResultRM<PageList<LotteryForBJ>> Query(LotteryFilterForBJ filterForBj)
        //{
        //    var result = new ResultRM<PageList<LotteryForBJ>>();
        //    string error;
        //    if (ValidateToken(ReqHeader,out error))
        //    {
        //        result.Data = Dal.Query_28BJ(filterForBj);
        //        result.Success = true;
        //        result.Message = MESSAGE_SUCCESS;
        //        NewKey(result,ReqHeader.UserSysNo);
        //    }
        //    else
        //    {
        //        result.Success = false;
        //        result.Message = error;
        //        result.Code = ERROR_VALIDATE_TOKEN_CODE;
        //    }
        //    return result;
        //}

        [WebMethod(Description = "登录",EnableSession = true)]
        public ResultRM<string> Login(string userId,string psw,string code)
        {
            var result = new ResultRM<string>();
            if (code != SessionValue.Code)
            {
                result.Success = false;
                result.Message = "验证码错误";
                return result;
            }
            string error;
            int userSysNo = 0;
            var isSuccess = Dal.Login(userId,psw,out error,out userSysNo);
            if (isSuccess)
            {
                result.Data = userSysNo.ToString();
                result.Success = true;
                result.Message = "登录成功";
                NewKey(result,userSysNo);
            }
            else
            {
                result.Success = false;
                result.Message = error;
            }
            return result;
        }

        [WebMethod(Description = "注册")]
        public ResultRM<string> Register(User user)
        {
            MyTree.Utility.Log.Log4netExt.Info(Dal.GetClientIP());
            var result = new ResultRM<string>();
            string error;
            var data = Dal.Register(user,out error);
            if (data > 0)
            {
                result.Success = true;
                result.Message = "注册成功";
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = data;
            }
            return result;
        }

        [WebMethod(Description = "生成验证码",EnableSession = true)]
        public string GenerateCode()
        {
            var code = Dal.GenerateCode();
            SessionValue.Code = code;
            return code;
        }

        [WebMethod(Description = "一般走势图,分页从1开始",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<LotteryTrend> QueryTrend(int pageIndex)
        {
            //LotteryTrend
            var result = new ResultRM<LotteryTrend>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                if (!Dal.ValidateUserTime(ReqHeader.UserSysNo,out error))
                {
                    result.Success = false;
                    result.Message = error;
                    return result;
                }

                result.Data = Dal.QueryTrend(ReqHeader.SiteSourceSysNo,pageIndex,AppSettingValues.PageCount,GetTableName(ReqHeader.RegionSourceSysNo));
                result.Success = true;
                NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
            }
            return result;
        }

        [WebMethod(Description = "遗漏号码",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<List<OmitStatistics>> QueryOmission()
        {
            var result = new ResultRM<List<OmitStatistics>>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                if (!Dal.ValidateUserTime(ReqHeader.UserSysNo,out error))
                {
                    result.Success = false;
                    result.Message = error;
                    return result;
                }

                var data = Dal.QueryOmissionAll(ReqHeader.GameSourceSysNo,ReqHeader.SiteSourceSysNo,ReqHeader.RegionSourceSysNo);
                result.Data = data;
                result.Success = true;
                NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
            }
            return result;
        }

        [WebMethod(Description = "超级走势图,分页从1开始",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<LotteryTrend> QuerySupperTrend(int pageIndex,
            int pageSize,
            string date,
            string hour,
            string minute)
        {
            var result = new ResultRM<LotteryTrend>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                if (!Dal.ValidateUserTime(ReqHeader.UserSysNo,out error))
                {
                    result.Success = false;
                    result.Message = error;
                    return result;
                }
                result.Data = Dal.QuerySupperTrend(ReqHeader.SiteSourceSysNo,pageIndex,pageSize,AppSettingValues.MaxTotal,date,hour,minute,GetTableName(ReqHeader.RegionSourceSysNo));
                result.Success = true;
                NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
            }
            return result;
        }

        [WebMethod(Description = "获得服务器的时间")]
        public DateTime GetServerDate()
        {
            return DateTime.Now;
        }

        [WebMethod(Description = "修改密码",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<object> ChangePsw(string oldPsw,string newPsw,string q1,string a1,string q2,string a2)
        {
            var result = new ResultRM<object>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                var msg = Dal.ChangePsw(ReqHeader.UserSysNo,oldPsw,newPsw,q1,a1,q2,a2);
                if (string.IsNullOrEmpty(msg))
                {
                    result.Success = true;
                    NewKey(result,ReqHeader.UserSysNo);
                }
                else
                {
                    result.Success = false;
                    result.Message = msg;
                }
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
            }
            return result;
        }

        [WebMethod(Description = "连号提醒",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<RemindStatistics> QueryRemindLottery()
        {
            var result = new ResultRM<RemindStatistics>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                if (!Dal.ValidateUserTime(ReqHeader.UserSysNo,out error))
                {
                    result.Success = false;
                    result.Message = error;
                    return result;
                }
                result.Data = Dal.QueryRemind(ReqHeader.GameSourceSysNo,ReqHeader.RegionSourceSysNo,ReqHeader.SiteSourceSysNo,
                                              ReqHeader.UserSysNo);
                result.Success = true;
                NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
            }
            return result;
        }

        [WebMethod(Description = "获取用户信息",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<User> GetUserInfo()
        {
            var result = new ResultRM<User>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                var data = Dal.Queryuser(ReqHeader.UserSysNo);
                if (data == null)
                {
                    result.Success = false;
                    result.Message = "没有找到用户信息";
                }
                else
                {
                    result.Success = true;
                    result.Data = data;
                    NewKey(result,ReqHeader.UserSysNo);
                }
            }
            else
            {
                result.Success = false;
                result.Message = error;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
            }
            return result;
        }

        [WebMethod(Description = "获得公告",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<List<Notices>> GetNotice(int sysNo)
        {
            var result = new ResultRM<List<Notices>>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                result.Data = Dal.GetNotices(sysNo);
                result.Success = true;
                NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
                result.Message = error;
            }
            return result;
        }

        [WebMethod(Description = "获得当前开奖结果",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<LotteryForBJ> GetCurrentLottery()
        {
            var result = new ResultRM<LotteryForBJ>();
            //if (ValidateToken(ReqHeader))
            //{
            result.Data = Dal.GetCurrentLottery(ReqHeader.SiteSourceSysNo,GetTableName(ReqHeader.RegionSourceSysNo));
            result.Success = true;
            //NewKey(result,ReqHeader.UserSysNo);
            //}
            //else
            //{
            //    result.Success = false;
            //    result.Code = ERROR_VALIDATE_TOKEN_CODE;
            //    result.Message = ERROR_VALIDATE_TOKEN;
            //}
            return result;
        }

        [WebMethod(Description = "充值",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<bool> Recharge(string cardNo,string cardPsw)
        {
            var result = new ResultRM<bool>();
            string error;
            string error2;
            if (ValidateToken(ReqHeader,out error2))
            {

                result.Data = Dal.Recharge(ReqHeader.UserSysNo,cardNo,cardPsw,out error);
                result.Success = result.Data;
                result.Message = error;
                if (result.Success)
                    NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
                result.Message = error2;
            }
            return result;
        }

        [WebMethod(Description = "保存提醒",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<bool> SaveRemind(RemindStatistics remind)
        {
            var result = new ResultRM<bool>();
            string error2;
            if (ValidateToken(ReqHeader,out error2))
            {
                string error;
                result.Data = Dal.SaveRemind(remind,out error);
                result.Success = result.Data;
                result.Message = error;
                if (result.Success)
                    NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
                result.Message = error2;
            }
            return result;
        }

        [WebMethod(Description = "提醒+当前期",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<InfoForTimer> GetInfoForTimer()
        {
            var result = new ResultRM<InfoForTimer>();
            //if (ValidateToken(ReqHeader))
            //{

            result.Data = new InfoForTimer();
            result.Data.Lottery = Dal.GetCurrentLottery(ReqHeader.SiteSourceSysNo,
                                                        GetTableName(ReqHeader.RegionSourceSysNo));
            result.Data.Remind = Dal.QueryRemind(ReqHeader.GameSourceSysNo,ReqHeader.RegionSourceSysNo,ReqHeader.SiteSourceSysNo,
                                          ReqHeader.UserSysNo);
            result.Success = true;
            //result.Message = error;
            //NewKey(result,ReqHeader.UserSysNo);
            //}
            //else
            //{
            //    result.Success = false;
            //    result.Code = ERROR_VALIDATE_TOKEN_CODE;
            //    result.Message = ERROR_VALIDATE_TOKEN;
            //}
            return result;
        }

        [WebMethod(Description = "删除提醒",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<bool> DelRemind(int remindSysNo)
        {
            var result = new ResultRM<bool>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                result.Data = Dal.DelRemind(remindSysNo);
                result.Success = result.Data;
                if (result.Success)
                    NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
                result.Message = error;
            }
            return result;

        }

        [WebMethod(Description = "查询提醒列表",EnableSession = true)]
        [SoapHeader("ReqHeader")]
        public ResultRM<PageList<RemindStatistics>> QueryRemind(int pageIndex,int pageSize)
        {
            var result = new ResultRM<PageList<RemindStatistics>>();
            string error;
            if (ValidateToken(ReqHeader,out error))
            {
                result.Data = Dal.QueryRemind(ReqHeader.GameSourceSysNo,
                                              ReqHeader.RegionSourceSysNo,
                                              ReqHeader.SiteSourceSysNo,
                                              ReqHeader.UserSysNo,pageIndex,pageSize);
                result.Success = true;
                NewKey(result,ReqHeader.UserSysNo);
            }
            else
            {
                result.Success = false;
                result.Code = ERROR_VALIDATE_TOKEN_CODE;
                result.Message = error;
            }
            return result;
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

        private void NewKey<T>(ResultRM<T> result,int userSysNo)
        {
            result.Key = Dal.generateKey();
            //SessionValue.Key = result.Key;
            UserKeys.WriteKey(userSysNo,result.Key);
        }

    }
}
