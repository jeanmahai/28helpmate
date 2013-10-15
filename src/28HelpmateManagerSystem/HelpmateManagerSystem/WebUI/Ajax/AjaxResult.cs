using System;
using System.Web.Script.Serialization;

namespace WebUI.Ajax
{
    [Serializable]
    public class AjaxResult
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
        public int Code { get; set; }

        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}