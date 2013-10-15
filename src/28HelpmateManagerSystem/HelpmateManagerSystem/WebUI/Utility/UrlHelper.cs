using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebUI.Utility
{
    public class UrlHelper
    {
        public static Dictionary<string,string> GetParams(string url)
        {
            var result = new Dictionary<string, string>();
            var index = url.IndexOf("?", System.StringComparison.Ordinal);
            if(index<0) return result;
            var urlParams = url.Substring(index+1).Split(new char[]{'&'}).ToList();
            urlParams.ForEach(p=>
                              {
                                  var strs = p.Split(new char[]{'='});
                                  var key = strs[0];
                                  string val=string.Empty;
                                  if(strs.Length>1) val = strs[1];
                                  result.Add(key,val);
                              });
            return result;
        } 
        public static string ToUrlParamsString(Dictionary<string,string> urlParams )
        {
            var result = urlParams.Select(item => string.Format("{0}={1}", item.Key, item.Value)).ToList();
            return String.Join("&",result);
        }
        public static string GetPageUrl(string url)
        {
            var index = url.IndexOf("?",System.StringComparison.Ordinal);
            if (index < 0) return url;
            return url.Substring(0, index);
        }
    }
}