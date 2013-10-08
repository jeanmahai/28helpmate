using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Utility;

namespace DataEntity
{
    /// <summary>
    /// 充值卡
    /// </summary>
    public class PayCard
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public long SysNo { get; set; }
        /// <summary>
        /// 充值卡卡号
        /// </summary>
        public string PayCardID { get; set; }
        /// <summary>
        /// 编码充值卡密码
        /// </summary>
        public string PayCardPwd { get; set; }
        /// <summary>
        /// 明文充值卡密码
        /// </summary>
        public string PlaintextPayCardPwd
        {
            get
            {
                return Base64.Decode(this.PayCardPwd);
            }
        }
        /// <summary>
        /// 充值卡类型
        /// </summary>
        public PayCardCategory CategorySysNo { get; set; }
        /// <summary>
        /// 充值卡类型文本
        /// </summary>
        public string StrCategory
        {
            get
            {
                return EnumHelper.GetDescription(this.CategorySysNo);
            }
        }
        /// <summary>
        /// 充值卡状态
        /// </summary>
        public PayCardStatus Status { get; set; }
        /// <summary>
        /// 充值卡状态文本
        /// </summary>
        public string StrStatus
        {
            get
            {
                return EnumHelper.GetDescription(this.Status);
            }
        }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 生成时间文本
        /// </summary>
        public string StrInDate
        {
            get
            {
                return this.InDate.ToString();
            }
        }
        /// <summary>
        /// 有效期起
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 有效期起文本
        /// </summary>
        public string StrBeginTime
        {
            get
            {
                return this.BeginTime.ToString();
            }
        }
        /// <summary>
        /// 有效期止
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 有效期止文本
        /// </summary>
        public string StrEndTime
        {
            get
            {
                return this.EndTime.ToString();
            }
        }
    }
}
