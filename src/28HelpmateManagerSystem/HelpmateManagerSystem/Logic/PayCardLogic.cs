using System;
using DataEntity;
using DataAccess;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// 充值卡
    /// </summary>
    public class PayCardLogic
    {
        /// <summary>
        /// 生成充值卡
        /// </summary>
        /// <param name="category">卡类型</param>
        /// <param name="counts">生成张数</param>
        /// <param name="beginTime">有效期起</param>
        /// <param name="endTime">有效期止</param>
        /// <returns>返回值为空，则生成成功；否则生成失败，返回值为失败信息。</returns>
        public static string CreatePayCard(PayCardCategory category, int counts, DateTime beginTime, DateTime endTime)
        {
            string result = "";

            if (counts < 1 || counts > 1000)
            {
                result = "生成失败，一次最多只能生成1-1000（含）张充值卡。";
                return result;
            }
            if (!PayCardDA.CreatePayCard(category, counts, beginTime, endTime))
                result = "生成失败。";

            return result;
        }

        /// <summary>
        /// 查询充值卡
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <param name="pageSize">每页显示几条</param>
        /// <param name="category">卡类型，全部则为null</param>
        /// <param name="status">状态，全部则为null</param>
        /// <param name="beginTime">有效期起，不限制时间则为null</param>
        /// <param name="endTime">有效期止，不限制时间则为null</param>
        /// <returns></returns>
        public static PageList<List<PayCard>> QueryPayCard(int pageIndex, int pageSize, PayCardCategory? category, PayCardStatus? status, DateTime? beginTime, DateTime? endTime)
        {
            int nCategory = category == null ? 0 : (int)category;
            int nStatus = status == null ? -1 : (int)status;
            DateTime dtBegin = beginTime == null ? DateTime.Now.AddYears(-100) : beginTime.Value;
            DateTime dtEnd = endTime == null ? DateTime.Now.AddYears(100) : endTime.Value;
            return PayCardDA.QueryPayCard(pageIndex, pageSize, nCategory, nStatus, dtBegin, dtEnd);
        }

        /// <summary>
        /// 获取单张充值卡
        /// </summary>
        /// <param name="sysNo">充值卡编号</param>
        /// <returns></returns>
        public static PayCard GetBySysNo(int sysNo)
        {
            return PayCardDA.GetBySysNo(sysNo);
        }

        /// <summary>
        /// 启用充值卡
        /// </summary>
        /// <param name="sysNo">充值卡编号</param>
        /// <returns></returns>
        public static bool EnablePayCard(int sysNo)
        {
            return PayCardDA.UpdateStatus(sysNo, PayCardStatus.Valid);
        }

        /// <summary>
        /// 禁用充值卡
        /// </summary>
        /// <param name="sysNo">充值卡编号</param>
        /// <returns></returns>
        public static bool DisablePayCard(int sysNo)
        {
            return PayCardDA.UpdateStatus(sysNo, PayCardStatus.Invalid);
        }

        /// <summary>
        /// 删除充值卡
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public static bool DeletePayCard(int sysNo)
        {
            return PayCardDA.Delete(sysNo);
        }

        /// <summary>
        /// 编辑充值卡
        /// </summary>
        /// <param name="entity">充值卡</param>
        /// <returns></returns>
        public static bool Edit(PayCard entity)
        {
            return PayCardDA.Edit(entity);
        }
    }
}
