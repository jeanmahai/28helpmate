using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public static bool IsEmail(string source)
        {
            return Regex.IsMatch(source, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        }

        public static bool IsMobile(string source)
        {
            return Regex.IsMatch(source, @"^1[35]\d{9}$", RegexOptions.IgnoreCase);
        }
    }
}
