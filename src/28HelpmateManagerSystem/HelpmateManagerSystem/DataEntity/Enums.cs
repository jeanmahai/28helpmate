using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataEntity
{
    /// <summary>
    /// 后台系统登录用户状态
    /// </summary>
    public enum SystemUserStatus
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 0,
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Valid = 1
    }

    /// <summary>
    /// 充值卡类型
    /// </summary>
    public enum PayCardCategory
    {
        /// <summary>
        /// 天卡
        /// </summary>
        [Description("天卡")]
        Day = 1,
        /// <summary>
        /// 月卡
        /// </summary>
        [Description("月卡")]
        Month = 2
    }

    /// <summary>
    /// 充值卡状态
    /// </summary>
    public enum PayCardStatus
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 0,
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Valid = 1,
        /// <summary>
        /// 已充值
        /// </summary>
        [Description("已充值")]
        Recharge = 2
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 0,
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Valid = 1
    }
}
