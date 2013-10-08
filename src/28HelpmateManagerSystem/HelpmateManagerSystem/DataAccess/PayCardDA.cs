using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

using DataEntity;
using Common.Utility;
using Common.Utility.Encryption;
using Common.Utility.DataAccess;

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

                DataCommand cmd = DataCommandManager.GetDataCommand("PayCard_CreateCard");
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
            PagingInfoEntity page = new PagingInfoEntity();
            page.MaximumRows = pageSize;
            page.StartRowIndex = pageIndex * pageSize;
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("PayCard_Query");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "SysNo DESC"))
            {
                if (category > 0)
                    sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "CategorySysNo", DbType.Int32, "@CategorySysNo", QueryConditionOperatorType.Equal, category);
                if (status >= 0)
                    sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32, "@Status", QueryConditionOperatorType.Equal, status);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "BeginTime", DbType.DateTime, "@BeginTime", QueryConditionOperatorType.MoreThanOrEqual, beginTime);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "EndTime", DbType.DateTime, "@EndTime", QueryConditionOperatorType.LessThanOrEqual, endTime);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                List<PayCard> result = cmd.ExecuteEntityList<PayCard>();

                int totalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));
                return new PageList<List<PayCard>>(result, pageIndex, pageSize, totalCount);
            }
        }

        /// <summary>
        /// 获取单张充值卡
        /// </summary>
        /// <param name="sysNo">充值卡编号</param>
        /// <returns></returns>
        public static PayCard GetBySysNo(int sysNo)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("PayCard_GetBySysNo");
            cmd.SetParameterValue("@SysNo", sysNo);
            return cmd.ExecuteEntity<PayCard>();
        }

        /// <summary>
        /// 更新充值卡状态
        /// </summary>
        /// <param name="sysNo">充值卡编号</param>
        /// <param name="status">充值卡状态</param>
        /// <returns></returns>
        public static bool UpdateStatus(int sysNo, PayCardStatus status)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("PayCard_UpdateStatus");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.SetParameterValue("@Status", (int)status);
            cmd.ExecuteNonQuery();
            return true;
        }

        /// <summary>
        /// 删除充值卡
        /// </summary>
        /// <param name="sysNo">充值卡编号</param>
        /// <returns></returns>
        public static bool Delete(int sysNo)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("PayCard_Delete");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.ExecuteNonQuery();
            return true;
        }

        /// <summary>
        /// 编辑充值卡
        /// </summary>
        /// <param name="entity">充值卡</param>
        /// <returns></returns>
        public static bool Edit(PayCard entity)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("PayCard_Edit");
            cmd.SetParameterValue("@SysNo", entity.SysNo);
            cmd.SetParameterValue("@CategorySysNo", (int)entity.CategorySysNo);
            cmd.SetParameterValue("@Status", (int)entity.Status);
            cmd.SetParameterValue("@BeginTime", entity.BeginTime);
            cmd.SetParameterValue("@EndTime", entity.EndTime);
            cmd.ExecuteNonQuery();
            return true;
        }

        /// <summary>
        /// 获取充值卡类型
        /// </summary>
        /// <returns></returns>
        public static List<PayCardCategorys> GetPayCardCategory()
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("PayCard_GetCategory");
            return cmd.ExecuteEntityList<PayCardCategorys>();
        }
    }
}
