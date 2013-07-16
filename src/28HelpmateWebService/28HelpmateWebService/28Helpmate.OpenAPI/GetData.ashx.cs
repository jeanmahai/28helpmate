using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Business;

namespace _28Helpmate.OpenAPI
{
    /// <summary>
    /// GetData 的摘要说明
    /// </summary>
    public class GetData:IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            var dal = new LotteryDAL();
            var site = 10002;
            var game = 10001;
            var user = 24;
            var region = 10001;

            var lastestLottery = dal.GetCurrentLottery(site,GetTableName(region));
            var result = dal.QueryNextLotteryWithSameNumber(lastestLottery.RetNum,site,GetTableName(region));
            var json = new JavaScriptSerializer().Serialize(result);
            //var json = fastJSON.JSON.Instance.ToJSON(result);

            context.Response.Clear();
            context.Response.Write(json);
            context.Response.End();
        }
        private string GetTableName(int regionSourceSysNo)
        {
            string tableName;
            if (regionSourceSysNo == 10002)
            {
                tableName = "SourceData_28_Canada";
            }
            else
            {
                tableName = "SourceData_28_Beijing";
            }
            return tableName;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}