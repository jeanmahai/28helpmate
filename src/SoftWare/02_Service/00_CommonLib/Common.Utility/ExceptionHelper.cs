using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    public static class ExceptionHelper
    {
        private const string DEFAULT_CATEGORY = "ExceptionLog";

        private static string GetMethodArgumentValue(object[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                return "N/A";
            }
            string result = string.Empty;
            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] != null)
                {
                    if (arguments[i] is string)
                    {
                        result += Convert.ToString(arguments[i]);
                    }
                    else if (arguments[i].GetType().IsPrimitive)
                    {
                        result += arguments[i].ToString();
                    }
                    else
                    {
                        result += SerializationUtility.XmlSerialize(arguments[i]);
                    }
                    if (i != arguments.Length - 1)
                    {
                        result += ", ";
                    }
                }
            }
            return result;
        }

        private static string GetMethodArgumentType(object[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                return "N/A";
            }
            string result = string.Empty;

            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] == null)
                {
                    result += "NULL";
                }
                else
                {
                    result += arguments[i].GetType().ToString();
                }

                if (i != arguments.Length - 1)
                {
                    result += ", ";
                }
            }
            return result;
        }

        public static string HandleException(Exception ex)
        {
            return HandleException(ex, null, DEFAULT_CATEGORY, null);
        }

        public static string HandleException(Exception ex, object[] methodArguments)
        {
            return HandleException(ex, null, DEFAULT_CATEGORY, methodArguments);
        }

        public static string HandleException(Exception ex, string message, object[] methodArguments)
        {
            return HandleException(ex, message, DEFAULT_CATEGORY, methodArguments);
        }

        public static string HandleException(Exception ex, string message, string category, object[] methodArguments)
        {
            return HandleException(ex, message, category, methodArguments, null);
        }

        public static string HandleException(Exception ex, string message, string category, object[] methodArguments, string referenceKey)
        {
            List<ExtendedPropertyData> list = new List<ExtendedPropertyData>();
            if (message != null)
            {
                list.Add(new ExtendedPropertyData("Error Message", message));
            }
            list.Add(new ExtendedPropertyData("Method Arguments Type", GetMethodArgumentType(methodArguments)));
            list.Add(new ExtendedPropertyData("Method Arguments Value", GetMethodArgumentValue(methodArguments)));
            return HandleException(ex, category, list, referenceKey);
        }

        public static string HandleException(Exception ex, string category, List<ExtendedPropertyData> extendedProperties)
        {
            return HandleException(ex, category, extendedProperties, null);
        }

        public static string HandleException(Exception ex, string category, List<ExtendedPropertyData> extendedProperties, string referenceKey)
        {
            if (string.IsNullOrEmpty(category))
            {
                category = DEFAULT_CATEGORY;
            }
            LogEntry log = new LogEntry();
            log.Category = category;
            log.ExtendedProperties = extendedProperties;
            log.Content = GetExceptionDetail(ex);
            log.ReferenceKey = referenceKey;
            return Logger.WriteLog(log);
        }

        private static string GetExceptionDetail(Exception ex)
        {
            if (ex == null)
                return "";
            StringBuilder sb = new StringBuilder(1000);
            if (ex.Message != null)
            {
                sb.AppendFormat("Message: {0}.\r\n", ex.Message);
            }
            sb.AppendFormat("Exception Type: {0}.\r\n", ex.GetType().FullName);
            if (ex.Source != null)
            {
                sb.AppendFormat("Source: {0}.\r\n", ex.Source);
            }
            if (ex.TargetSite != null)
            {
                sb.AppendFormat("Module Name: {0}.\r\n", ex.TargetSite.Module.FullyQualifiedName);
            }
            if (ex.StackTrace != null)
            {
                sb.AppendFormat("Stack Trace: {0}.\r\n", ex.StackTrace);
            }
            if (ex.InnerException != null)
            {
                AppendInnerException(ex.InnerException, sb);
            }

            return sb.ToString();
        }

        private static void AppendInnerException(Exception ex, StringBuilder sb)
        {
            sb.Append("\r\n");
            sb.AppendFormat("Inner Exception:\r\n");
            sb.AppendFormat("\tMessage: {0}. \r\n", ex.Message);
            sb.AppendFormat("\tException Type: {0}.\r\n", ex.GetType().FullName);
            if (ex.Source != null)
            {
                sb.AppendFormat("\tSource: {0}.\r\n", ex.Source);
            }
            if (ex.StackTrace != null)
            {
                sb.AppendFormat("\tStack Trace: {0}.\r\n", ex.StackTrace);
            }
            if (ex.InnerException != null)
            {
                AppendInnerException(ex.InnerException, sb);
            }
        }
    }
}
