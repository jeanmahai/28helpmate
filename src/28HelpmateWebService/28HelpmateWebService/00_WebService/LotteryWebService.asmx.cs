﻿using System.Web.Services;
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
        private static LotteryDAL m_Dal;
        private readonly string ERROR_VALIDATE_TOKEN = "TOKEN验证失败";
        private readonly string MESSAGE_SUCCESS = "执行成功";

        private LotteryDAL Dal
        {
            get
            {
                if (m_Dal == null)
                {
                    m_Dal = new LotteryDAL();
                }
                return m_Dal;
            }
        }

        [WebMethod(Description = "查询最近20期号码相同的下一期的开奖结果")]
        [SoapHeader("Token")]
        public ResultRM<LotteryByTwentyPeriodRM> QueryNextLotteryWithSameNumber(int number)
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if (Token.ValidateToken())
            {
                result.Data = Dal.QueryNextLotteryWithSameNumber(number);
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
        [WebMethod(Description = "查询同一时间点的近20小时的数据")]
        [SoapHeader("Token")]
        public ResultRM<LotteryByTwentyPeriodRM> QueryLotteryByHourStep(DateTime time)
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if (Token.ValidateToken())
            {
                result.Data = Dal.QueryLotteryByHourStep(time);
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
        public ResultRM<LotteryByTwentyPeriodRM> QueryLotteryByDay(DateTime time)
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if (Token.ValidateToken())
            {
                result.Data = Dal.QueryLotteryByDay(time);
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
        public ResultRM<LotteryByTwentyPeriodRM> QueryLotteryByTwenty()
        {
            var result = new ResultRM<LotteryByTwentyPeriodRM>();
            if(Token.ValidateToken())
            {
                result.Data = Dal.QueryTop20();
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
            if (Token.ValidateToken())
            {
                result.Data = Dal.Query(filter);
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
        public string Login(string userName,string psw)
        {
            return "";
        }
        [WebMethod(Description = "注册")]
        public void Register()
        {
            
        }
        [WebMethod(Description = "注册并登录,注册成功后返回一个token")]
        public string RegisterAndLogin()
        {
            return "";
        }
    }
}
