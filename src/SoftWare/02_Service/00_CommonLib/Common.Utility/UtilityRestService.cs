using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Reflection;
using System.Data;

namespace Common.Utility
{
    [ServiceContract]
    public class UtilityRestService
    {
        #region CodeNamePairs

        [WebInvoke(UriTemplate = "/CodeNamePair/GetCodeNamePairs", Method = "POST")]
        public BatchCodeNamePairList GetCodeNamePairs(CodeNamePairQueryFilter query)
        {
            BatchCodeNamePairList returnList = new BatchCodeNamePairList();
            if (query != null && query.Keys != null && query.Keys.Length > 0)
            {
                foreach (var key in query.Keys)
                {
                    returnList.Add(key, CodeNamePairManager.GetCodeNamePairList(query.DomainName, key, query.AppendItemType));
                }
            }
            return returnList;
        }

        [WebInvoke(UriTemplate = "/CodeNamePair/GetCodeNamePairByKey", Method = "POST")]
        public List<CodeNamePair> GetCodeNamePairByKey(CodeNamePairQueryFilter query)
        {
            return CodeNamePairManager.GetCodeNamePairList(query.DomainName, query.Keys[0], query.AppendItemType);
        }

        #endregion

        #region AppSetting

        [WebInvoke(UriTemplate = "/AppSetting/GetAppSetting", Method = "POST")]
        public string GetAppSetting(AppSettingQueryFilter filter)
        {
            return AppSettingManager.GetSetting(filter.DomainName, filter.Key);
        }

        [WebInvoke(UriTemplate = "/AppSetting/GetAllAppSettings/{domain}", Method = "GET")]
        public Dictionary<string, string> GetAllAppSettings(string domain)
        {
            return AppSettingManager.GetAllSettings(domain);
        }

        #endregion

        #region Cache Http Command

        private CacheStatisticItem Convert(CacheStatistic en, string methodName)
        {
            CacheStatisticItem item = new CacheStatisticItem();
            item.Method = methodName;
            item.CacheName = en.CacheName;
            item.HitCount = en.HitCount;
            item.TotalExecuteTimes = en.TotalExecuteTimes;
            item.HitRate = Math.Round((double)item.HitCount / (double)item.TotalExecuteTimes, 3);
            item.GroupName = en.GroupName;

            if (item.GroupName == null)
            {
                item.GroupName = string.Empty;
                item.ItemCount = 1;
                item.Keys = item.Method;
            }
            else
            {
                ICache cache = CacheFactory.GetInstance(item.CacheName);
                List<string> keys = cache.GetKeysByGroup(item.GroupName);
                item.ItemCount = keys.Count;
                item.Keys = string.Join("; ", keys.ToArray());
            }
            return item;
        }

        [WebInvoke(UriTemplate = "/Cache/{methodName}", Method = "GET")]
        public CacheStatisticItem GetStatisticByMethod(string methodName)
        {
            CacheStatistic en = CacheStatisticManager.GetStatisticByMethod(methodName);
            if (en != null)
            {
                return Convert(en, methodName);
            }
            return null;
        }

        [WebInvoke(UriTemplate = "/Cache/All", Method = "GET")]
        public CacheStatisticItemList GetAllStatistic()
        {
            Dictionary<string, CacheStatistic> list = CacheStatisticManager.GetAllStatistic();
            CacheStatisticItemList rst = new CacheStatisticItemList(list.Count);
            foreach (var entry in list)
            {
                rst.Add(Convert(entry.Value, entry.Key));
            }
            rst.Sort(new Comparison<CacheStatisticItem>((i1, i2) => i1.HitRate == i2.HitRate ? 0 : (i1.HitRate > i2.HitRate ? 1 : -1)));
            return rst;
        }

        [WebInvoke(UriTemplate = "/Cache/FlushAll/{cacheName}", Method = "GET")]
        public string CacheFlushAll(string cacheName)
        {
            ICache cache = CacheFactory.GetInstance(cacheName);
            cache.FlushAll();
            return "Succeed";
        }

        [WebInvoke(UriTemplate = "/Cache/RemoveByKey/{cacheName}/{key}", Method = "GET")]
        public string CacheRemoveByKey(string cacheName, string key)
        {
            ICache cache = CacheFactory.GetInstance(cacheName);
            cache.Remove(key);
            return "Succeed";
        }

        [WebInvoke(UriTemplate = "/Cache/RemoveByMethod/{cacheName}/{methodName}", Method = "GET")]
        public string CacheRemoveByMethodName(string cacheName, string methodName)
        {
            string[] array = methodName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string fullName = string.Join(".", array, 0, array.Length - 1);
            string assemblyName = string.Join(".", array, 0, array.Length - 2);
            string method = array[array.Length - 1];
            Type type = Type.GetType(fullName + ", " + assemblyName);
            MethodInfo me = type.GetMethod(method);
            string group = CacheKeyGenerator.GenerateGroupName(me);
            string key = CacheKeyGenerator.GenerateKeyName(me, null, null);
            ICache cache = CacheFactory.GetInstance(cacheName);
            cache.Remove(key);
            cache.RemoveByGroup(group);
            return "Succeed";
        }

        [WebInvoke(UriTemplate = "/Cache/Memcached/Status/{cacheName}", Method = "GET")]
        public string GetMemcachedStatus(string cacheName)
        {
            MemcachedCache cache = CacheFactory.GetInstance(cacheName) as MemcachedCache;
            if (cache == null)
            {
                return "The cache '" + cacheName + "' is not memcached.";
            }
            Dictionary<string, Dictionary<string, string>> rst = cache.CacheManager.Status();
            return SerializationUtility.JsonSerialize(rst);
        }

        [WebInvoke(UriTemplate = "/Cache/Memcached/Stats/{cacheName}", Method = "GET")]
        public string GetMemcachedStats(string cacheName)
        {
            MemcachedCache cache = CacheFactory.GetInstance(cacheName) as MemcachedCache;
            if (cache == null)
            {
                return "The cache '" + cacheName + "' is not memcached.";
            }
            Dictionary<string, Dictionary<string, string>> rst = cache.CacheManager.Stats();
            return SerializationUtility.JsonSerialize(rst);
        }

        #endregion

        #region Send Email By Template

        [WebInvoke(UriTemplate = "/Email/SendByTemplate", Method = "POST")]
        public void SendMailByTemplate(MailInfoMsg req)
        {
            EmailHelper.SendEmailByTemplate(req.ToAddress,
                req.CcAddress,
                req.BccAddress,
                req.TemplateID,
                req.KeyValueVariables,
                req.KeyTableVariables,
                req.IsInternalMail.GetValueOrDefault(false),
                req.IsAsyncMail.GetValueOrDefault(true),
                req.LanguageCode);

        }

        [WebInvoke(UriTemplate = "/Email/BatchSendByTemplate", Method = "POST")]
        public void BatchSendMailByTemplate(List<MailInfoMsg> req)
        {
            if (req != null && req.Count > 0)
            {
                foreach (var item in req)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    EmailHelper.SendEmailByTemplate(item.ToAddress,
                        item.CcAddress,
                        item.BccAddress,
                        item.TemplateID,
                        item.KeyValueVariables,
                        item.KeyTableVariables,
                        item.IsInternalMail.GetValueOrDefault(false),
                        item.IsAsyncMail.GetValueOrDefault(true),
                        item.LanguageCode);
                }
            }
        }

        #endregion

        [WebInvoke(UriTemplate = "/ExportFile", Method = "POST")]
        public FileExportResult ExportFile(ForwardRequestData requestData)
        {
            return DataFileExporter.ExportFile(requestData, requestData.ExporterName);
        }

        [WebInvoke(UriTemplate = "/TinyWordSegment/{text}", Method = "GET")]
        public List<string> TinyWordSegment(string text)
        {
            return CommonUtility.WordSegment(text);
        }

        [WebInvoke(UriTemplate = "/WordSegment", Method = "POST")]
        public List<string> WordSegment(string text)
        {
            return CommonUtility.WordSegment(text);
        }

        [WebInvoke(UriTemplate = "/GetServerTimeNow", Method = "GET")]
        public DateTime GetServerTimeNow()
        {
            return DateTime.Now;
        }
    }

    public class CacheStatisticItemList : List<CacheStatisticItem>
    {
        public CacheStatisticItemList()
        {

        }

        public CacheStatisticItemList(int capacity)
            : base(capacity)
        {

        }
    }

    public class CacheStatisticItem
    {
        public string Method
        {
            get;
            set;
        }

        public string CacheName
        {
            get;
            set;
        }

        public int HitCount
        {
            get;
            set;
        }

        public int TotalExecuteTimes
        {
            get;
            set;
        }

        public double HitRate
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public int ItemCount
        {
            get;
            set;
        }

        public string Keys
        {
            get;
            set;
        }
    }

    public class MailInfoMsg
    {
        public string ToAddress { get; set; }
        public string CcAddress { get; set; }
        public string BccAddress { get; set; }
        public string TemplateID { get; set; }
        public KeyValueVariables KeyValueVariables { get; set; }
        public KeyTableVariables KeyTableVariables { get; set; }
        public bool? IsInternalMail { get; set; }
        public bool? IsAsyncMail { get; set; }
        public string LanguageCode { get; set; }
    }
}
