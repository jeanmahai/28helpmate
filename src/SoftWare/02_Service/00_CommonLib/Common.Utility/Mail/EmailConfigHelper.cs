using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Configuration;

namespace Common.Utility
{
    public class EmailConfigHelper
    {
        #region MailTemplateConfig配置

        private static readonly string MAIL_TEMPLATES_FILES_CONFIG_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["MailTemplatesFilesConfigPath"]);
        private static object s_SyncMailTemplatesObj = new object();
        private static Dictionary<string, List<MailTemplate>> s_MailTemplatesList = new Dictionary<string, List<MailTemplate>>();

        #endregion

        #region [Private Methods]

        /// <summary>
        /// 根据当前线程语言，加载模板组.
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        private static List<MailTemplate> GetMailTemplatesByLanguageCode(string languageCode)
        {
            if (!File.Exists(MAIL_TEMPLATES_FILES_CONFIG_PATH))
            {
                throw new ApplicationException("未找到模板配置文件 MailTemplatesFiles.config !");
            }
            List<MailTemplate> returnList = new List<MailTemplate>();
            XElement doc = XElement.Load(MAIL_TEMPLATES_FILES_CONFIG_PATH);
            var getList = (from x in doc.Descendants("templateList") where x.Attribute("languageCode").Value == languageCode select x);
            if (getList == null || 0 >= getList.Count())
            {
                throw new ApplicationException(string.Format("找不到相关的templateList languageCode={0}，在MailTemplatesFiles.config文件下.", languageCode));
            }
            XElement list = getList.SingleOrDefault();
            if (null != list)
            {
                List<XElement> getTemplateItems = (from x in list.Elements("template") select x).ToList();
                foreach (var templateItem in getTemplateItems)
                {
                    string filePath = templateItem.Attribute("path").Value;
                    returnList.Add(BuildMailTemplate(filePath));
                }
            }
            return returnList;
        }

        /// <summary>
        /// 根据模板文件路径，构建邮件模板实体
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <returns></returns>
        private static MailTemplate BuildMailTemplate(string templateFileName)
        {
            string getDefaultTemplatesFolder = Directory.GetParent(MAIL_TEMPLATES_FILES_CONFIG_PATH).FullName;
            string getSingleTemplteFullPath = string.Empty;
            if (!Path.IsPathRooted(templateFileName))
            {
                //如果是相对路径：
                getSingleTemplteFullPath = Path.Combine(getDefaultTemplatesFolder, templateFileName);

            }

            if (!File.Exists(getSingleTemplteFullPath))
            {
                throw new ApplicationException(string.Format("未找到模板配置文件 :{0} !", templateFileName));
            }
            MailTemplate returnTemplate = new MailTemplate();
            XElement doc = XElement.Load(getSingleTemplteFullPath);
            if (null != doc)
            {
                int mailPriority = 0;
                int.TryParse(doc.Element("mailPriority").Value, out mailPriority);

                returnTemplate.Sender = doc.Element("sender").Value;
                returnTemplate.SenderDisplayName = (doc.Element("senderDisplayName") == null ? string.Empty : doc.Element("senderDisplayName").Value);
                returnTemplate.To = (doc.Element("to") == null ? string.Empty : doc.Element("to").Value);
                returnTemplate.TemplateID = doc.Element("id").Value;
                returnTemplate.IsHtmlType = doc.Element("isHtmlType").Value == "1" ? true : false;
                returnTemplate.MailPriority = mailPriority;
                returnTemplate.Subject = doc.Element("subject").Value.Replace("\n", string.Empty).Trim();
                //returnTemplate.Body = doc.Element("body").Value;
                List<KeyValuePair<string, string>> templateList =
                    doc.Element("body").Elements("template").Select(x => new KeyValuePair<string, string>(x.Attribute("reference") == null ? null : x.Attribute("reference").Value, x.Value)).ToList();
                if (templateList != null && templateList.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var entry in templateList)
                    {
                        if (string.IsNullOrWhiteSpace(entry.Key))
                        {
                            sb.Append(entry.Value);
                        }
                        else
                        {
                            string path = entry.Key;
                            if (!Path.IsPathRooted(path))
                            {
                                path = Path.Combine(Path.GetDirectoryName(getSingleTemplteFullPath), path);
                            }
                            if (File.Exists(path))
                            {
                                sb.Append(File.ReadAllText(path));
                            }
                        }
                    }
                    returnTemplate.Body = sb.ToString();
                }
                else
                {
                    returnTemplate.Body = string.Empty;
                }
            }
            return returnTemplate;
        }

        #endregion

        #region [Public Methods]

        /// <summary>
        /// 根据当前线程语言和模板ID,从缓存中获取模板内容
        /// </summary>
        /// <param name="templateID"></param>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public static MailTemplate GetMailTemplate(string templateID, string languageCode)
        {
            var getList = s_MailTemplatesList.Where(i => i.Key == languageCode);
            if (null == getList || getList.Count() <= 0)
            {
                lock (s_SyncMailTemplatesObj)
                {
                    s_MailTemplatesList.Add(languageCode, GetMailTemplatesByLanguageCode(languageCode));
                }
            }
            return s_MailTemplatesList[languageCode].SingleOrDefault(i => i.TemplateID == templateID);
        }

        #endregion
    }
}
