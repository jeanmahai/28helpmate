using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    public class ValidationTool
    {
        public static string IsInt(string conInfo, string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(conInfo))
                {
                    return "请输入" + msg + "！";
                }

                int temp = Convert.ToInt32(conInfo);
            }
            catch (Exception)
            {
                return msg + "必须为数字类型！";
            }
            return string.Empty;
        }

        public static string IsEmpty(string conInfo, string msg)
        {
            if (string.IsNullOrEmpty(conInfo))
            {
                return "请输入" + msg + "！";
            }
            return string.Empty;
        }


        public static Boolean IsIp(string conInfo, ref string msg)
        {
            if (string.IsNullOrEmpty(conInfo))
            {
                msg = "请输入正确的IP地址！";
                return false;
            }
            return true;
        }
    }
}
