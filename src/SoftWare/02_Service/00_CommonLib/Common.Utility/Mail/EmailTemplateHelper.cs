using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Text.RegularExpressions;

namespace Common.Utility
{
    public class EmailTemplateHelper
    {
        private const string HTML_DISPLAY = "#HTML_STYLE_DISPLAY#";
        private const string HTML_DISPLAY_NONE = "#HTML_STYLE_DISPLAY_NONE#";
        private const string PLACE_HOLDER = @"<%=\s*{0}\s*%>";

        /// <summary>
        /// 根据邮件模板ID,获取邮件模板信息
        /// </summary>
        /// <param name="templateID">模板邮件模板ID</param>
        /// <returns>返回邮件模板实体</returns>
        public static MailTemplate GetTemplateByID(string templateID, string languageCode)
        {
            MailTemplate returnEntity = new MailTemplate();

            returnEntity = EmailConfigHelper.GetMailTemplate(templateID, languageCode);

            if (null == returnEntity)
            {
                throw new ApplicationException("目标模板[" + templateID + "]（语言为" + languageCode + "）未找到!");
            }
            return returnEntity;
        }

        public static void BuildEmailBodyByTemplate(MailMessageModel mailInfoMessage, string templateID, KeyValueVariables keyValues, KeyTableVariables keyTables, string languageCode)
        {
            if (!string.IsNullOrEmpty(templateID))
            {
                MailTemplate getTemplate = GetTemplateByID(templateID, languageCode);
                mailInfoMessage.FromName = getTemplate.Sender;
                mailInfoMessage.DisplaySenderName = getTemplate.SenderDisplayName;
                mailInfoMessage.ToName = (!string.IsNullOrEmpty(getTemplate.To) ? getTemplate.To + ";" : string.Empty) + mailInfoMessage.ToName;
                mailInfoMessage.IsHtmlType = getTemplate.IsHtmlType;
                mailInfoMessage.Priority = getTemplate.MailPriority;
                //构建MailSubject:
                mailInfoMessage.Subject = BuildMailSubject(getTemplate.Subject, keyValues);
                //构建MailBody:
                mailInfoMessage.Body = TemplateString.BuildHtml(getTemplate.Body, keyValues, keyTables);
            }
            else
            {
                throw new ArgumentException("参数不能为null或空白字符串!", "templateID");
            }
        }

        private static string BuildMailSubject(string mailSubject, KeyValueVariables keyValues)
        {
            foreach (var replaceItem in keyValues)
            {
                string pa = string.Format(PLACE_HOLDER, replaceItem.Key);
                mailSubject = Regex.Replace(mailSubject, pa, replaceItem.Value == null ? String.Empty : replaceItem.Value.ToString());
            }
            return mailSubject;
        }

    }

    internal static class ValueConverter
    {
        public static string CovertToString(object value)
        {
            if (value == null || value == DBNull.Value || value.ToString().Trim().Length <= 0)
            {
                return string.Empty;
            }
            Type type = value.GetType();
            while (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && type.GetGenericArguments() != null
                    && type.GetGenericArguments().Length == 1 && type.IsEnum)
            {
                type = type.GetGenericArguments()[0];
            }
            if (type.IsEnum)
            {
                return ((Enum)value).ToDisplayText();
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
