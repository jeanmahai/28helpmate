using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Utility;

namespace DataEntity
{
    /// <summary>
    /// 后台系统登录用户
    /// </summary>
    public class SystemUser
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public SystemUserStatus Status { get; set; }
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
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 最后登录时间文本
        /// </summary>
        public string StrLastLoginTime
        {
            get
            {
                return this.LastLoginTime.ToString();
            }
        }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public long LoginTimes { get; set; }
    }
}
