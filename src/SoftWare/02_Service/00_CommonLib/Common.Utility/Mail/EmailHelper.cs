using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Common.Utility
{
    /// <summary>
    /// 邮件发送Helper(如果重载方法不包含IsAsyncMail,IsInternalMail参数，则默认为：发送外部邮件;异步发送)
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="templateID">模板ID</param>
        public static void SendEmailByTemplate(string toAddress, string templateID)
        {
            SendEmailByTemplate(toAddress, string.Empty, string.Empty, templateID, null, null, false, true, Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        public static void SendEmailByTemplate(string toAddress, string templateID, KeyValueVariables keyValueVariables)
        {
            SendEmailByTemplate(toAddress, string.Empty, string.Empty, templateID, keyValueVariables, null, false, true, Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        /// <param name="isInternalMail">是否为内部邮件</param>
        public static void SendEmailByTemplate(string toAddress, string templateID, KeyValueVariables keyValueVariables, bool isInternalMail, bool isAsyncMail)
        {
            SendEmailByTemplate(toAddress, string.Empty, string.Empty, templateID, keyValueVariables, null, isInternalMail, isAsyncMail, Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        /// <param name="isInternalMail">是否为内部邮件</param>
        /// <param name="languageCode">语言编号</param>
        public static void SendEmailByTemplate(string toAddress, string templateID, KeyValueVariables keyValueVariables, bool isInternalMail, string languageCode)
        {
            SendEmailByTemplate(toAddress, string.Empty, string.Empty, templateID, keyValueVariables, null, isInternalMail, true, languageCode);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        /// <param name="keyTableVariables">Key-Tables变量</param>
        public static void SendEmailByTemplate(string toAddress, string templateID, KeyValueVariables keyValueVariables, KeyTableVariables keyTableVariables)
        {
            SendEmailByTemplate(toAddress, string.Empty, string.Empty, templateID, keyValueVariables, keyTableVariables, false, true, Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        /// <param name="keyTableVariables">Key-Tables变量</param>
        /// <param name="languageCode">语言编码</param>
        public static void SendEmailByTemplate(string toAddress, string templateID, KeyValueVariables keyValueVariables, KeyTableVariables keyTableVariables, string languageCode)
        {
            SendEmailByTemplate(toAddress, string.Empty, string.Empty, templateID, keyValueVariables, keyTableVariables, false, true, languageCode);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        /// <param name="keyTableVariables">Key-Tables变量</param>
        /// <param name="isInternalMail">是否为内部邮件</param>
        public static void SendEmailByTemplate(string toAddress, string templateID, KeyValueVariables keyValueVariables, KeyTableVariables keyTableVariables, bool isInternalMail)
        {
            SendEmailByTemplate(toAddress, string.Empty, string.Empty, templateID, keyValueVariables, keyTableVariables, isInternalMail, true, Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="ccAddress">抄送人地址(多个地址用;隔开)</param>
        /// <param name="bccAddress">暗送人地址(多个地址用;隔开)</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        /// <param name="keyTableVariables">Key-Tables变量</param>
        /// <param name="isInternalMail">是否为内部邮件</param>
        /// <param name="isAsyncMail">是否为异步发送邮件</param>
        public static void SendEmailByTemplate(string toAddress, string ccAddress, string bccAddress, string templateID, KeyValueVariables keyValueVariables, KeyTableVariables keyTableVariables, bool isInternalMail, bool isAsyncMail)
        {
            SendEmailByTemplate(toAddress, ccAddress, bccAddress, templateID, keyValueVariables, keyTableVariables, isInternalMail, isAsyncMail, Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// 发送模板邮件
        /// </summary>
        /// <param name="toAddress">收件人地址(多个地址用;隔开),默认先加载模板中配置的ToAddress</param>
        /// <param name="ccAddress">抄送人地址(多个地址用;隔开)</param>
        /// <param name="bccAddress">暗送人地址(多个地址用;隔开)</param>
        /// <param name="templateID">模板ID</param>
        /// <param name="keyValueVariables">Key-Values变量</param>
        /// <param name="keyTableVariables">Key-Tables变量</param>
        /// <param name="isInternalMail">是否为内部邮件</param>
        /// <param name="isAsyncMail">是否为异步发送邮件</param>
        /// <param name="languageCode">语言编码</param>
        public static void SendEmailByTemplate(string toAddress, string ccAddress, string bccAddress, string templateID, KeyValueVariables keyValueVariables, KeyTableVariables keyTableVariables, bool isInternalMail, bool isAsyncMail, string languageCode)
        {
            if (!string.IsNullOrEmpty(templateID))
            {
                MailMessageModel msg = new MailMessageModel()
                {
                    ToName = toAddress,
                    CCName = ccAddress,
                    BCCName = bccAddress
                };
                EmailTemplateHelper.BuildEmailBodyByTemplate(msg, templateID, keyValueVariables, keyTableVariables, languageCode);
                CheckMailEntity(msg);
                ObjectFactory<IEmailSend>.Instance.SendMail(msg, isAsyncMail, isInternalMail);
            }
        }

        /// <summary>
        /// 发送邮件时，检查邮件实体
        /// </summary>
        /// <param name="msg"></param>
        private static void CheckMailEntity(MailMessageModel msg)
        {
            if (string.IsNullOrEmpty(msg.FromName))
            {
                throw new ApplicationException("邮件发件人不能为空!");
            }
            if (string.IsNullOrEmpty(msg.ToName))
            {
                throw new ApplicationException("邮件收件人不能为空!");
            }
            if (string.IsNullOrEmpty(msg.Subject))
            {
                throw new ApplicationException("邮件主题不能为空!");
            }
            if (string.IsNullOrEmpty(msg.Body))
            {
                throw new ApplicationException("邮件内容不能为空!");
            }
        }
    }
}
