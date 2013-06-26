using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using FTAlgorithm;
using KTDictSeg;

namespace Common.Utility
{
    public static class CommonUtility
    {
        /// <summary>
        /// 移除List<typeparamref name="T"/>中的重复实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="comparison">自定义重复实体的具体含义</param>
        public static void RemoveRepeatEntity<T>(List<T> list, Comparison<T> comparison)
        {
            if (list != null & list.Count > 0)
            {
                if (comparison != null)
                {
                    list.Sort(comparison);
                }
                else
                {
                    if (list[0] is IComparable<T>)
                    {
                        list.Sort();
                    }
                    else
                    {
                        return;
                    }
                }

                T t = list[list.Count - 1];
                for (int i = list.Count - 2; i >= 0; i--)
                {
                    if (comparison(t, list[i]) == 0)
                    {
                        list.RemoveAt(i);
                    }
                    else
                    {
                        t = list[i];
                    }
                }
            }
        }

        /// <summary>
        /// 数据验证扩展方法
        /// </summary>
        /// <typeparam name="T">需要进行数据验证的类</typeparam>
        /// <param name="t">需要进行验证的类的实例</param>
        /// <param name="predicate">验证方法,验证通过返回true，验证失败返回false</param>
        /// <param name="errorCallback">验证失败时回调</param>
        /// <returns></returns>
        public static T Validate<T>(this T t, Predicate<T> predicate, Action errorCallback)
        {
            if (!predicate(t))
            {
                errorCallback();
            }
            return t;
        }

        private static CSimpleDictSeg s_Segment;
        private static object s_Seg_SyncObj = new object();

        /// <summary>
        /// 中文分词方法
        /// </summary>
        /// <param name="text">待分词的文本</param>
        /// <returns></returns>
        public static List<string> WordSegment(string text)
        {
            if (text == null || text.Trim().Length <= 0)
            {
                return new List<string>(0);
            }
            if (s_Segment == null)
            {
                lock (s_Seg_SyncObj)
                {
                    if (s_Segment == null)
                    {
                        string path = ConfigurationManager.AppSettings["WordSegmentConfigPath"];
                        if (path == null || path.Trim().Length <= 0)
                        {
                            // 使用默认路径
                            path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration\\KTDictSeg.config");
                        }
                        else
                        {
                            string p = Path.GetPathRoot(path);
                            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
                            {
                                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                            }
                        }
                        CSimpleDictSeg tmp = new CSimpleDictSeg();
                        tmp.LoadConfig(path);
                        tmp.LoadDict();
                        s_Segment = tmp;
                    }
                }
            }
            List<T_WordInfo> list = s_Segment.SegmentToWordInfos(text);
            List<string> rstList = new List<string>(list.Count);
            foreach (T_WordInfo info in list)
            {
                if (info != null && info.Word.Length > 1)
                {
                    rstList.Add(info.Word);
                }
            }
            return rstList;
        }

        #region 工作时间的计算

        private static TimeSpan WorkStart = new TimeSpan(8, 30, 0);
        private static TimeSpan WorkEnd = new TimeSpan(17, 30, 0);

        public static DateTime AddWorkMinute(DateTime time, double mins)
        {
            if (mins == 0)
                return time;

            DateTime currentDay = DateTime.Parse(time.ToString("yyyy-MM-dd"));

            // 判断传入的起始时间是否是工作日
            if (time.DayOfWeek == DayOfWeek.Saturday || // 如果是周六
                time.DayOfWeek == DayOfWeek.Sunday) // 如果是周日
            {
                // 如果是加就往前推一天，否则往后倒一天
                time = (mins > 0) ? currentDay.AddDays(1) : currentDay.AddSeconds(-1);
                return AddWorkMinute(time, mins);
            }

            // 计算当前日期的工作时间
            double tempMin = 0;
            if (mins > 0)
            {
                tempMin = CalWorkMinute(time, currentDay.Add(WorkEnd), 0);
            }
            else
            {
                tempMin = CalWorkMinute(currentDay.Add(WorkStart), time, 0);
            }

            if (Math.Abs(mins) > tempMin) // 当天工作时间不能满足
            {
                time = (mins > 0) ? currentDay.AddDays(1) : currentDay.AddSeconds(-1);
                return AddWorkMinute(time, Math.Sign(mins) * (Math.Abs(mins) - tempMin));
            }
            else // 当天时间可以满足
            {
                if (mins > 0)
                {
                    if (time.TimeOfDay > WorkStart) //工作时间之前
                    {
                        return time.AddMinutes(mins);
                    }
                    else
                    {
                        return currentDay.Add(WorkStart).AddMinutes(mins);
                    }
                }
                else
                {
                    if (time.TimeOfDay < WorkEnd) //工作时间以后
                    {
                        return time.AddMinutes(mins);
                    }
                    else
                    {
                        return currentDay.Add(WorkEnd).AddMinutes(mins);
                    }
                }
            }
        }

        /// <summary>
        /// 计算传入的时间段之间有多少时间属于工作时间
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="totalMinutes"></param>
        /// <returns></returns>
        public static double CalWorkMinute(DateTime startTime, DateTime endTime, double totalMinutes)
        {
            // 开始时间>=终止时间
            if (startTime >= endTime)
                return totalMinutes;

            // 判断传入的开始时间是否是工作日
            if (startTime.DayOfWeek == DayOfWeek.Saturday || // 如果是周六
                startTime.DayOfWeek == DayOfWeek.Sunday) // 如果是周日
            {
                startTime = DateTime.Parse(startTime.ToString("yyyy-MM-dd")).AddDays(1);
                return CalWorkMinute(startTime, endTime, totalMinutes);
            }

            TimeSpan dayStartTime = startTime.TimeOfDay;
            TimeSpan dayEndTime = endTime.TimeOfDay;
            if (startTime.ToString("yyyyMMdd") != endTime.ToString("yyyyMMdd")) // 开始时间和结束时间不是同一天
            {
                dayEndTime = WorkEnd;
            }

            if (dayStartTime > WorkEnd) // 开始时间在下班以后
            {
                startTime = DateTime.Parse(startTime.ToString("yyyy-MM-dd")).AddDays(1);
                return CalWorkMinute(startTime, endTime, totalMinutes);
            }

            double allMinutes = ((TimeSpan)(WorkEnd - WorkStart)).TotalMinutes;
            double beforeStartMinutes = ((TimeSpan)(dayStartTime - WorkStart)).TotalMinutes;
            double aboveEndMinutes = ((TimeSpan)(WorkEnd - dayEndTime)).TotalMinutes;

            double dayMinutes = allMinutes - Math.Max(Math.Min(beforeStartMinutes, allMinutes), 0) -
                                              Math.Max(Math.Min(aboveEndMinutes, allMinutes), 0);

            totalMinutes += dayMinutes;

            startTime = DateTime.Parse(startTime.ToString("yyyy-MM-dd")).AddDays(1);
            return CalWorkMinute(startTime, endTime, totalMinutes);
        }

        #endregion 工作时间的计算

        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            if (data == null || data.Count == 0)
                return new DataTable();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name, property.PropertyType);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTableNoType<T>(this IList<T> data)
        {
            if (data == null || data.Count == 0)
                return new DataTable();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    dt.Columns.Add(property.Name, typeof(int));
                }
                else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    dt.Columns.Add(property.Name, typeof(bool));
                }
                else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    dt.Columns.Add(property.Name, typeof(DateTime));
                }
                else
                {
                    dt.Columns.Add(property.Name, typeof(object));
                }
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        public static int ToInteger(this object val)
        {
            int returnVal = 0;
            return (!int.TryParse(val.ToString().Trim(), out returnVal) ? 0 : returnVal);
        }

        public static decimal ToDecimal(this object val)
        {
            decimal returnVal = 0m;
            return (!decimal.TryParse(val.ToString().Trim(), out returnVal) ? 0m : returnVal);
        }

        public static int ToInteger(this int? val)
        {
            return val.HasValue ? val.Value : 0;
        }

        public static decimal ToDecimal(this decimal? val)
        {
            return val.HasValue ? val.Value : 0m;
        }
    }
}