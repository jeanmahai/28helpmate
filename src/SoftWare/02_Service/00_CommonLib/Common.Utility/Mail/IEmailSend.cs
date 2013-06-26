using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    /// <summary>
    /// 发送邮件接口
    /// </summary>
    public interface IEmailSend
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailMessage">邮件主体</param>
        /// <param name="isAsync">是否同步邮件</param>
        /// <param name="isInternal">是否为发送内部邮件</param>
        void SendMail(MailMessageModel mailMessage, bool isAsync, bool isInternal);
    }
}
