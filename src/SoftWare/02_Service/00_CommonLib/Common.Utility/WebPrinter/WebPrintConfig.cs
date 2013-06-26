using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Configuration;
using System.IO;
using System.Runtime.Caching;

namespace Common.Utility
{
    internal static class WebPrintConfig
    {
        private const string CACHE_KEY = "ECCEntral-WebPrinterConfig";
        private static object s_SyncObj = new object();

        public static string GetConfigFilePath()
        {
            string path = ConfigurationManager.AppSettings["WebPrintConfigPath"];
            if (string.IsNullOrWhiteSpace(path))
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration\\PrintTemplates\\WebPrinter.config");
            }
            path = path.Replace("/", "\\");
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        private static WebPrinterConfigData GetData()
        {
            WebPrinterConfigData data = MemoryCache.Default.Get(CACHE_KEY) as WebPrinterConfigData;
            if (data == null)
            {
                lock (s_SyncObj)
                {
                    data = MemoryCache.Default.Get(CACHE_KEY) as WebPrinterConfigData;
                    if (data == null)
                    {
                        string path = GetConfigFilePath();
                        if (File.Exists(path))
                        {
                            data = SerializationUtility.LoadFromXml<WebPrinterConfigData>(path);
                        }
                        else
                        {
                            data = new WebPrinterConfigData
                            {
                                HandlerRegister = new HandlerRegister
                                {
                                    Handlers = new List<WebPrintHandlerSetting>(0)
                                },
                                PrinterSetting = new WebPrinterSetting
                                {
                                    Printers = new List<WebPrinter>(0)
                                }
                            };
                        }
                        CacheItemPolicy policy = new CacheItemPolicy();
                        policy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string> { path }));
                        policy.AbsoluteExpiration = new DateTimeOffset(2999, 12, 31, 23, 59, 59, TimeSpan.Zero); 
                        MemoryCache.Default.Set(CACHE_KEY, data, policy);
                    }
                }
            }
            return data;
        }

        public static string GetHandlerTypeName(string extention)
        {
            if(string.IsNullOrWhiteSpace(extention))
            {
                return null;
            }
            extention = extention.Trim().ToUpper();
            WebPrinterConfigData data = GetData();
            WebPrintHandlerSetting handler = data.HandlerRegister.Handlers.Find(h => 
            {
                if(h == null || string.IsNullOrWhiteSpace(h.Extention))
                {
                    return false;
                }
                string[] x = h.Extention.Trim().ToUpper().Split(',', ';');
                return new List<string>(x).Exists(n => n != null && n.Trim() == extention);
            });
            if (handler == null || string.IsNullOrWhiteSpace(handler.TypeName))
            {
                return null;
            }
            return handler.TypeName.Trim();
        }

        public static void GetPrinterSetting(string printerName, string languageCode, out string templateFullPath, out string dataBuilderTypeName)
        {
            templateFullPath = null;
            dataBuilderTypeName = null;
            WebPrinterConfigData data = GetData();
            WebPrinter printer = data.PrinterSetting.Printers.Find(p => p != null && p.Name == printerName);
            if (printer == null)
            {
                return;
            }
            dataBuilderTypeName = printer.DataBuilder;
            languageCode = languageCode.Trim().ToUpper();
            if (printer.Templates != null)
            {
                WebPrintTemplate t = printer.Templates.Find(x => x != null && x.LanguageCode != null && x.LanguageCode.Trim().ToUpper() == languageCode);
                templateFullPath = t.Path;
                if (string.IsNullOrWhiteSpace(templateFullPath))
                {
                    templateFullPath = null;
                }
                else
                {
                    string p = Path.GetPathRoot(templateFullPath);
                    if (p == null || p.Trim().Length <= 0) // 说明是相对路径
                    {
                        string cp = GetConfigFilePath();
                        templateFullPath = Path.Combine(Path.GetDirectoryName(cp), templateFullPath);
                    }
                }
            }
        }
    }


    [XmlRoot("webPrinter")]
    public class WebPrinterConfigData
    {
        [XmlElement("handlerRegisters")]
        public HandlerRegister HandlerRegister
        {
            get;
            set;
        }

        [XmlElement("printerSettings")]
        public WebPrinterSetting PrinterSetting
        {
            get;
            set;
        }
    }

    [XmlRoot("handlerRegisters")]
    public class HandlerRegister
    {
        [XmlElement("handler")]
        public List<WebPrintHandlerSetting> Handlers
        {
            get;
            set;
        }
    }

    [XmlRoot("handler")]
    public class WebPrintHandlerSetting
    {
        [XmlAttribute("extention")]
        public string Extention
        {
            get;
            set;
        }

        [XmlAttribute("type")]
        public string TypeName
        {
            get;
            set;
        }
    }

    [XmlRoot("printerSettings")]
    public class WebPrinterSetting
    {
        [XmlElement("printer")]
        public List<WebPrinter> Printers
        {
            get;
            set;
        }
    }

    [XmlRoot("printer")]
    public class WebPrinter
    {
        [XmlAttribute("name")]
        public string Name
        {
            get;
            set;
        }

        [XmlAttribute("dataBuilder")]
        public string DataBuilder
        {
            get;
            set;
        }

        [XmlElement("template")]
        public List<WebPrintTemplate> Templates
        {
            get;
            set;
        }
    }

    [XmlRoot("template")]
    public class WebPrintTemplate
    {
        [XmlAttribute("languageCode")]
        public string LanguageCode
        {
            get;
            set;
        }

        [XmlAttribute("path")]
        public string Path
        {
            get;
            set;
        }
    }
}
