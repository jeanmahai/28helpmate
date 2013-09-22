using System;
using System.Text;
using System.Collections.Generic;

using Framework.Util.Encoding;
using Framework.Util.Encryption;
using Framework.Util.Database.MSSQL;
using DataEntity;
using System.Data;

namespace DataAccess
{
    /// <summary>
    /// 充值卡
    /// </summary>
    public class PayCardDA
    {
        /// <summary>
        /// 生成充值卡
        /// </summary>
        /// <param name="category">卡类型</param>
        /// <param name="counts">生成张数</param>
        /// <param name="beginTime">有效期起</param>
        /// <param name="endTime">有效期止</param>
        /// <returns></returns>
        public static bool CreatePayCard(PayCardCategory category, int counts, DateTime beginTime, DateTime endTime)
        {
            bool result = false;

            int sigleCounts = 500;
            string formats = "<row ID=\"{0}\" Pwd=\"{1}\" />";

            while (counts > 0)
            {
                StringBuilder dataXML = new StringBuilder();
                dataXML.Append("<root>");
                int forMaxCounts = counts > sigleCounts ? sigleCounts : counts;
                for (int i = 0; i < forMaxCounts; i++)
                {
                    string ID = GetPayCardIDByRdmVal();
                    string Pwd = GetPayCardPwdByRdmVal();
                    dataXML.Append(string.Format(formats, ID, Pwd));
                }
                dataXML.Append("</root>");

                DbCommand cmd = new DbCommand("PayCard_CreateCard", System.Data.CommandType.StoredProcedure);
                cmd.SetParameterValue("@DataXML", dataXML.ToString());
                cmd.SetParameterValue("@CategorySysNo", (int)category);
                cmd.SetParameterValue("@BeginTime", beginTime);
                cmd.SetParameterValue("@EndTime", endTime);
                cmd.ExecuteNonQuery();

                counts -= sigleCounts;
            }
            result = true;

            return result;
        }

        #region 产生卡号密码
        /// <summary>
        /// 随机对象
        /// </summary>
        private static Random rdm = new Random();
        /// <summary>
        /// 计算虚拟奖品的密码
        /// </summary>
        /// <returns></returns>
        private static string GetPayCardPwdByRdmVal()
        {
            string result = string.Empty;
            string str = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] ret = str.Split(',');
            for (int i = 0; i < 8; i++)
            {
                lock (rdm)
                {
                    result += ret[rdm.Next(0, ret.Length)];
                }
            }
            return Base64.Encode(result.ToUpper());
        }

        /// <summary>
        /// 计算虚拟奖品的ID
        /// </summary>
        /// <returns></returns>
        private static string GetPayCardIDByRdmVal()
        {
            string result = string.Empty;
            lock (rdm)
            {
                result = GuidCode.GetGuid("D") + DateTime.Now.ToString();
            }
            return MD5Encrypt.MD5Encrypt16(result).ToUpper();
        }
        #endregion

        /// <summary>
        /// 查询充值卡
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <param name="pageSize">每页显示几条</param>
        /// <param name="category">卡类型</param>
        /// <param name="status">状态</param>
        /// <param name="beginTime">有效期起</param>
        /// <param name="endTime">有效期止</param>
        /// <returns></returns>
        public static PageList<List<PayCard>> QueryPayCard(int pageIndex, int pageSize, int category, int status, DateTime beginTime, DateTime endTime)
        {
            int startRows = (pageIndex - 1) * pageSize;
            DbCommand cmd = new DbCommand("PayCard_Query", System.Data.CommandType.StoredProcedure);
            cmd.SetParameterValue("@StartRows", startRows);
            cmd.SetParameterValue("@PageSize", pageSize);
            cmd.SetParameterValue("@Status", status);
            cmd.SetParameterValue("@CategorySysNo", category);
            cmd.SetParameterValue("@BeginTime", beginTime);
            cmd.SetParameterValue("@EndTime", endTime);
            DataSet ds = cmd.ExecuteDataSet();

            List<PayCard> result = Util.FillModelList<PayCard>(ds.Tables[0]);
            int totalCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());

            return new PageList<List<PayCard>>(result, pageIndex, pageSize, totalCount);
        }
    }
}
