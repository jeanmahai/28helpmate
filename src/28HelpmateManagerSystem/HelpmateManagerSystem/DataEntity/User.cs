using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Utility;

namespace DataEntity
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 用户登录名（邮箱）
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        //public string UserPwd { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 安全问题1
        /// </summary>
        public string SecurityQuestion1 { get; set; }
        /// <summary>
        /// 安全问题1答案
        /// </summary>
        public string SecurityAnswer1 { get; set; }
        /// <summary>
        /// 安全问题2
        /// </summary>
        public string SecurityQuestion2 { get; set; }
        /// <summary>
        /// 安全问题2答案
        /// </summary>
        public string SecurityAnswer2 { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public UserStatus Status { get; set; }
        /// <summary>
        /// 状态文本
        /// </summary>
        public string StrStatus
        {
            get
            {
                return EnumHelper.GetDescription(this.Status);
            }
        }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string RegIP { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        /// 注册时间文本
        /// </summary>
        public string StrRegDate
        {
            get
            {
                return this.RegDate.ToString();
            }
        }
        /// <summary>
        /// 充值使用时间起
        /// </summary>
        public DateTime PayUseBeginTime { get; set; }
        /// <summary>
        /// 充值使用时间起文本
        /// </summary>
        public string StrPayUseBeginTime
        {
            get
            {
                return this.PayUseBeginTime.ToString();
            }
        }
        /// <summary>
        /// 充值使用时间止
        /// </summary>
        public DateTime PayUseEndTime { get; set; }
        /// <summary>
        /// 充值使用时间止文本
        /// </summary>
        public string StrPayUseEndTime
        {
            get
            {
                return this.PayUseEndTime.ToString();
            }
        }
    }
}
