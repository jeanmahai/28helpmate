using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.ComponentModel;
using System.Net;

namespace Common.Utility
{
    public static class MailSender
    {
        #region SendMail

        public static bool SendMail(string fromAddress, string toAddress, string subject, string body)
        {
            return SendMail(fromAddress, fromAddress, toAddress, subject, body);
        }

        public static bool SendMail(string fromAddress, string fromDisplay, string toAddress, string subject, string body)
        {
            return SendMail(fromAddress, fromDisplay, toAddress, subject, body, false);
        }

        public static bool SendMail(string fromAddress, string fromDisplay, string toAddress, string subject, string body, bool isBodyHtml)
        {
            return SendMail(fromAddress, fromDisplay, toAddress, subject, body, Encoding.GetEncoding("gb2312"), isBodyHtml);
        }

        public static bool SendMail(string fromAddress, string fromDisplay, string toAddress, string subject, string body, Encoding charset, bool isBodyHtml)
        {
            return SendMail(fromAddress, fromDisplay, toAddress, subject, body, charset, isBodyHtml, MailPriority.Normal);
        }

        public static bool SendMail(string fromAddress, string fromDisplay, string toAddress, string subject, string body, Encoding charset, bool isBodyHtml, MailPriority priority)
        {
            return SendMail(fromAddress, fromDisplay, toAddress, null, null, subject, body, null, charset, isBodyHtml, priority);
        }

        public static bool SendMail(string fromAddress, string fromDisplay, string toAddress,
            string ccAddress, string bccAddress, string subject, string body,
            string attachmentFilePath, Encoding charset, bool isBodyHtml, MailPriority priority)
        {
            string[] toAddressList = string.IsNullOrWhiteSpace(toAddress) ? new string[0] : toAddress.Split(new char[] { ';', ','}, StringSplitOptions.RemoveEmptyEntries);
            string[] ccAddressList = string.IsNullOrWhiteSpace(ccAddress) ? new string[0] : ccAddress.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] bccAddressList = string.IsNullOrWhiteSpace(bccAddress) ? new string[0] : bccAddress.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] attachmentFilePathList = string.IsNullOrWhiteSpace(attachmentFilePath) ? new string[0] : attachmentFilePath.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            return SendMail(fromAddress, fromDisplay, toAddressList, ccAddressList, bccAddressList, subject, body, attachmentFilePathList, charset, isBodyHtml, priority);
        }

        public static bool SendMail(string fromAddress, string fromDisplay, string[] toAddressList,
            string[] ccAddressList, string[] bccAddressList, string subject, string body,
            string[] attachmentFilePathList, Encoding charset, bool isBodyHtml, MailPriority priority)
        {
            return InnerSendMail(fromAddress, fromDisplay, toAddressList, ccAddressList, bccAddressList, subject, body,
                attachmentFilePathList, charset, isBodyHtml, priority, false, null);
        }

        #endregion

        #region SendMailAsync

        public static void SendMailAsync(string fromAddress, string toAddress, string subject, string body, Action<bool> sendCompletedCallback = null)
        {
            SendMailAsync(fromAddress, fromAddress, toAddress, subject, body, sendCompletedCallback);
        }

        public static void SendMailAsync(string fromAddress, string fromDisplay, string toAddress, string subject, string body, Action<bool> sendCompletedCallback = null)
        {
            SendMailAsync(fromAddress, fromDisplay, toAddress, subject, body, false, sendCompletedCallback);
        }

        public static void SendMailAsync(string fromAddress, string fromDisplay, string toAddress, string subject, string body, bool isBodyHtml, Action<bool> sendCompletedCallback = null)
        {
            SendMailAsync(fromAddress, fromDisplay, toAddress, subject, body, Encoding.GetEncoding("gb2312"), isBodyHtml, sendCompletedCallback);
        }

        public static void SendMailAsync(string fromAddress, string fromDisplay, string toAddress, string subject, string body, Encoding charset, bool isBodyHtml, Action<bool> sendCompletedCallback = null)
        {
            SendMailAsync(fromAddress, fromDisplay, toAddress, subject, body, charset, isBodyHtml, MailPriority.Normal, sendCompletedCallback);
        }

        public static void SendMailAsync(string fromAddress, string fromDisplay, string toAddress, string subject, string body, Encoding charset, bool isBodyHtml, MailPriority priority, Action<bool> sendCompletedCallback = null)
        {
            SendMailAsync(fromAddress, fromDisplay, toAddress, null, null, subject, body, null, charset, isBodyHtml, priority, sendCompletedCallback);
        }

        public static void SendMailAsync(string fromAddress, string fromDisplay, string toAddress,
            string ccAddress, string bccAddress, string subject, string body,
            string attachmentFilePath, Encoding charset, bool isBodyHtml, MailPriority priority, Action<bool> sendCompletedCallback = null)
        {
            string[] toAddressList = string.IsNullOrWhiteSpace(toAddress) ? new string[0] : toAddress.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] ccAddressList = string.IsNullOrWhiteSpace(ccAddress) ? new string[0] : ccAddress.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] bccAddressList = string.IsNullOrWhiteSpace(bccAddress) ? new string[0] : bccAddress.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] attachmentFilePathList = string.IsNullOrWhiteSpace(attachmentFilePath) ? new string[0] : attachmentFilePath.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            SendMailAsync(fromAddress, fromDisplay, toAddressList, ccAddressList, bccAddressList, subject, body, attachmentFilePathList, charset, isBodyHtml, priority, sendCompletedCallback);
        }

        public static void SendMailAsync(string fromAddress, string fromDisplay, string[] toAddressList,
            string[] ccAddressList, string[] bccAddressList, string subject, string body,
            string[] attachmentFilePathList, Encoding charset, bool isBodyHtml, MailPriority priority,
            Action<bool> sendCompletedCallback = null)
        {
            InnerSendMail(fromAddress, fromDisplay, toAddressList, ccAddressList, bccAddressList, subject, body,
                attachmentFilePathList, charset, isBodyHtml, priority, true, sendCompletedCallback);
        }

        #endregion

        private static bool InnerSendMail(string fromAddress, string fromDisplay, string[] toAddressList,
            string[] ccAddressList, string[] bccAddressList, string subject, string body,
            string[] attachmentFilePathList, Encoding charset, bool isBodyHtml, MailPriority priority, bool isAsync,
            Action<bool> sendCompletedCallback)
        {
            List<SmtpSetting> list = MailSection.GetSetting();
            if(list == null || list.Count <= 0)
            {
                LogError("没有配置任何的SMTP，请检查WebHost下的Web.config里的mail节点", null);
                return false;
            }
            System.Net.Mail.MailMessage emailInfo = new System.Net.Mail.MailMessage();
            emailInfo.From = new MailAddress(fromAddress, fromDisplay, charset);
            if (toAddressList != null && toAddressList.Length > 0)
            {
                foreach (string mailto in toAddressList)
                {
                    if (!string.IsNullOrWhiteSpace(mailto))
                    {
                        emailInfo.To.Add(mailto);
                    }
                }
            }

            if (ccAddressList != null && ccAddressList.Length > 0)
            {
                foreach (string cc in ccAddressList)
                {
                    if (!string.IsNullOrWhiteSpace(cc))
                    {
                        emailInfo.CC.Add(cc);
                    }
                }
            }

            if (bccAddressList != null && bccAddressList.Length > 0)
            {
                foreach (string bcc in bccAddressList)
                {
                    if (!string.IsNullOrWhiteSpace(bcc))
                    {
                        emailInfo.Bcc.Add(bcc);
                    }
                }
            }

            if (attachmentFilePathList != null && attachmentFilePathList.Length > 0)
            {
                foreach(string file in attachmentFilePathList)
                {
                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        emailInfo.Attachments.Add(new Attachment(file));
                    }
                }
            }

            emailInfo.Subject = subject;
            emailInfo.Body = body;
            emailInfo.Priority = priority;
            emailInfo.IsBodyHtml = isBodyHtml;
            emailInfo.BodyEncoding = charset;
            emailInfo.SubjectEncoding = charset;
            
            if (isAsync)
            {
                InnerSendMailAsync(0, emailInfo, sendCompletedCallback);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    try
                    {
                        SmtpClient smtpMail = new SmtpClient(list[i].Address, list[i].Port);
                        smtpMail.Credentials = new NetworkCredential(list[i].UserName, list[i].Password);
                        smtpMail.EnableSsl = list[i].EnableSsl;
                        smtpMail.Send(emailInfo);
                        break;
                    }
                    catch(Exception ex)
                    {
                        LogError(ex, list[i]);
                        if(i == list.Count - 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static void LogError(Exception ex, SmtpSetting setting)
        {
            LogError(ex.ToString(), setting);
        }

        private static void LogError(string msg, SmtpSetting setting)
        {
            List<ExtendedPropertyData> list = new List<ExtendedPropertyData>();
            list.Add(new ExtendedPropertyData("Smtp Setting", setting == null ? "没有SMTP的配置" : setting.ToXmlString()));

            LogEntry log = new LogEntry();
            log.Category = "SMTP邮件发送错误";
            log.ExtendedProperties = list;
            log.Content = msg;
            log.ReferenceKey = null;
            Logger.WriteLog(log);
        }

        private static void InnerSendMailAsync(int index, System.Net.Mail.MailMessage emailInfo, Action<bool> callback)
        {
            List<SmtpSetting> list = MailSection.GetSetting();
            SmtpClient smtpMail = new SmtpClient(list[index].Address, list[index].Port);
            smtpMail.Credentials = new NetworkCredential(list[index].UserName, list[index].Password);
            smtpMail.EnableSsl = list[index].EnableSsl;
            smtpMail.SendCompleted += (sender, e) =>
            {
                UserStateContainer state = e.UserState as UserStateContainer;
                if (state != null)
                {
                    if (e.Cancelled) // 发送被取消
                    {
                        if (state.SendCompletedCallback != null)
                        {
                            state.SendCompletedCallback(false);
                        }
                    }
                    else if (e.Error != null) // 发送出错
                    {
                        List<SmtpSetting> slist = MailSection.GetSetting();
                        LogError(e.Error, slist[state.Index]);
                        if (state.Index == slist.Count - 1) // 所有smtp配置都发送出错，结束发送，回调方法，通知发送失败
                        {
                            if (state.SendCompletedCallback != null)
                            {
                                state.SendCompletedCallback(false); 
                            }
                        }
                        else
                        {
                            InnerSendMailAsync(state.Index + 1, state.EmailInfo, state.SendCompletedCallback);
                        }
                    }
                    else // 发送成功
                    {
                        if (state.SendCompletedCallback != null)
                        {
                            state.SendCompletedCallback(true);
                        }
                    }
                }
            };
            smtpMail.SendAsync(emailInfo, new UserStateContainer() { Index = index, SendCompletedCallback = callback, EmailInfo = emailInfo });
        }

        private class UserStateContainer
        {
            public int Index;

            public Action<bool> SendCompletedCallback;

            public System.Net.Mail.MailMessage EmailInfo;
        }
    }
}
