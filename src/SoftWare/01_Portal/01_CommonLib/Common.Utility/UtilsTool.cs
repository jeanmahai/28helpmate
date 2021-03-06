﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
using System.Text.RegularExpressions;
using Helpmate.BizEntity;
using System.IO;

namespace Common.Utility
{
    public class UtilsTool
    {
        public static SoundPlayer Play = new SoundPlayer();

        public static String MD5(String info)
        {
            String UserPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(info, "md5").ToLower();
            return UserPassword.ToLower();
        }

        public static void PlayMusic(string musicName, bool isLooping)
        {
            Play.SoundLocation = Application.StartupPath + "//" + musicName;
            Play.Load();
            if (isLooping)
            {
                Play.PlayLooping();
            }
            else
            {
                Play.Play();
            }
        }

        public static string ConvertDateToTrendDate(DateTime dtNow)
        {
            string result = "{0}-{1} {2}:{3}";
            string month = dtNow.Month < 10 ? string.Format("0{0}", dtNow.Month) : dtNow.Month.ToString();
            string day = dtNow.Day < 10 ? string.Format("0{0}", dtNow.Day) : dtNow.Day.ToString();
            string hour = dtNow.Hour < 10 ? string.Format("0{0}", dtNow.Hour) : dtNow.Hour.ToString();
            string minute = dtNow.Minute < 10 ? string.Format("0{0}", dtNow.Minute) : dtNow.Minute.ToString();
            result = string.Format(result, month, day, hour, minute);
            return result;
        }

        public static Color ToColor(string color)
        {
            int red, green, blue = 0;
            char[] rgb;
            color = color.TrimStart('#');
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            switch (color.Length)
            {
                case 3:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[0].ToString(), 16);
                    green = Convert.ToInt32(rgb[1].ToString() + rgb[1].ToString(), 16);
                    blue = Convert.ToInt32(rgb[2].ToString() + rgb[2].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                case 6:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[1].ToString(), 16);
                    green = Convert.ToInt32(rgb[2].ToString() + rgb[3].ToString(), 16);
                    blue = Convert.ToInt32(rgb[4].ToString() + rgb[5].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                default:
                    return Color.FromName(color);

            }
        }

        /// <summary>
        /// 密码问题
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> ProtectionQuestion()
        {
            List<KeyValue> keys = new List<KeyValue>();
            keys.Add(new KeyValue() { Key = "", Value = "请选择" });
            keys.Add(new KeyValue() { Key = "你父亲的姓名是什么？", Value = "你父亲的姓名是什么？" });
            keys.Add(new KeyValue() { Key = "你母亲的姓名是什么？", Value = "你母亲的姓名是什么？" });
            keys.Add(new KeyValue() { Key = "你的出生地？", Value = "你的出生地？" });
            keys.Add(new KeyValue() { Key = "你的宠物的名字？", Value = "你的宠物的名字？" });
            keys.Add(new KeyValue() { Key = "你的职业是什么？", Value = "你的职业是什么？" });
            keys.Add(new KeyValue() { Key = "你配偶的职业是什么？", Value = "你配偶的职业是什么？" });
            return keys;
        }
        /// <summary>
        /// 游戏列表
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> GameList()
        {
            List<KeyValue> keys = new List<KeyValue>();
            keys.Add(new KeyValue() { Key = "10001", Value = "28游戏" });
            return keys;
        }
        /// <summary>
        /// 源数据列表
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> SourceList()
        {
            List<KeyValue> keys = new List<KeyValue>();
            keys.Add(new KeyValue() { Key = "10001", Value = "北京" });
            keys.Add(new KeyValue() { Key = "10002", Value = "加拿大" });
            return keys;
        }
        /// <summary>
        /// 网站列表
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> SiteList()
        {
            List<KeyValue> keys = new List<KeyValue>();
            keys.Add(new KeyValue() { Key = "10001", Value = "53游" });
            keys.Add(new KeyValue() { Key = "10002", Value = "71豆" });
            keys.Add(new KeyValue() { Key = "10003", Value = "芝麻西西" });
            return keys;
        }
        /// <summary>
        /// 开奖结果类型列表
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> RetNumCategoryList()
        {
            List<KeyValue> keys = new List<KeyValue>();
            keys.Add(new KeyValue() { Key = "大", Value = "大" });
            keys.Add(new KeyValue() { Key = "小", Value = "小" });
            keys.Add(new KeyValue() { Key = "中", Value = "中" });
            keys.Add(new KeyValue() { Key = "边", Value = "边" });
            keys.Add(new KeyValue() { Key = "单", Value = "单" });
            keys.Add(new KeyValue() { Key = "双", Value = "双" });
            return keys;
        }
        /// <summary>
        /// 根据游戏ID获取游戏名称
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public static string GetGameName(int sysNo)
        {
            string result = "";
            switch (sysNo)
            {
                case 10001:
                    result = "28游戏";
                    break;
            }
            return result;
        }
        /// <summary>
        /// 根据源ID获取名称
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public static string GetSourceName(int sysNo)
        {
            string result = "";
            switch (sysNo)
            {
                case 10001:
                    result = "北京";
                    break;
                case 10002:
                    result = "加拿大";
                    break;
            }
            return result;
        }
        /// <summary>
        /// 根据站点ID获取站点名称
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public static string GetSiteName(int sysNo)
        {
            string result = "";
            switch (sysNo)
            {
                case 10001:
                    result = "53游";
                    break;
                case 10002:
                    result = "71豆";
                    break;
                case 10003:
                    result = "芝麻西西";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取本期预测分析间隔刷新时间（返回毫秒）
        /// </summary>
        /// <param name="dtNow">当前服务器时间</param>
        /// <param name="gameSourceSysNo">游戏编号</param>
        /// <param name="regionSourceSysNo">地区编号</param>
        /// <param name="siteSourceSysNo">网站编号</param>
        /// <returns>返回毫秒</returns>
        public static int GetIntervalSeconds(DateTime dtNow, int gameSourceSysNo, int regionSourceSysNo, int siteSourceSysNo)
        {
            int result = 30;

            DateTime dtNext = dtNow.AddMinutes(5);
            int minute = dtNow.Minute;
            int second = dtNow.Second;
            if (regionSourceSysNo == 10001)
            {
                if (gameSourceSysNo == 10001)
                {
                    minute = 5 - minute % 5;
                    second = 30 - second;
                    dtNext = dtNow.AddMinutes(minute).AddSeconds(second);
                    result = (int)(dtNext - dtNow).TotalSeconds;
                }
            }
            else if (regionSourceSysNo == 10002)
            {
                if (gameSourceSysNo == 10001)
                {
                    switch (siteSourceSysNo)
                    {
                        case 10001:
                            minute = 4 - minute % 4;
                            second = 30 - second;
                            dtNext = dtNow.AddMinutes(minute).AddSeconds(second);
                            result = (int)(dtNext - dtNow).TotalSeconds;
                            break;
                        case 10002:
                            minute = 4 - minute % 4 + 1;
                            second = 30 - second;
                            dtNext = dtNow.AddMinutes(minute).AddSeconds(second);
                            result = (int)(dtNext - dtNow).TotalSeconds;
                            break;
                        case 10003:
                            minute = 4 - minute % 4 + 1;
                            second = 30 - second;
                            dtNext = dtNow.AddMinutes(minute).AddSeconds(second);
                            result = (int)(dtNext - dtNow).TotalSeconds;
                            break;
                    }
                }
            }

            return result * 1000;
        }

        /// <summary>
        /// 获取短时间
        /// </summary>
        /// <param name="dtTime"></param>
        /// <returns></returns>
        public static string GetShortTime(DateTime dtTime)
        {
            string result = "{0}:{1}:{2}";
            string hour = dtTime.Hour < 10 ? string.Format("0{0}", dtTime.Hour) : dtTime.Hour.ToString();
            string minute = dtTime.Minute < 10 ? string.Format("0{0}", dtTime.Minute) : dtTime.Minute.ToString();
            string second = dtTime.Second < 10 ? string.Format("0{0}", dtTime.Second) : dtTime.Second.ToString();
            result = string.Format(result, hour, minute, second);
            return result;
        }

        /// <summary>
        /// 开奖小时
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> LotteryHours(int areaCode)
        {
            List<KeyValue> keys = new List<KeyValue>();

            if (areaCode == 10001) //北京
            {
                keys.Add(new KeyValue() { Key = "09", Value = "09时" });
                keys.Add(new KeyValue() { Key = "10", Value = "10时" });
                keys.Add(new KeyValue() { Key = "11", Value = "11时" });
                keys.Add(new KeyValue() { Key = "12", Value = "12时" });
                keys.Add(new KeyValue() { Key = "13", Value = "13时" });
                keys.Add(new KeyValue() { Key = "14", Value = "14时" });
                keys.Add(new KeyValue() { Key = "15", Value = "15时" });
                keys.Add(new KeyValue() { Key = "16", Value = "16时" });
                keys.Add(new KeyValue() { Key = "17", Value = "17时" });
                keys.Add(new KeyValue() { Key = "18", Value = "18时" });
                keys.Add(new KeyValue() { Key = "19", Value = "19时" });
                keys.Add(new KeyValue() { Key = "20", Value = "20时" });
                keys.Add(new KeyValue() { Key = "21", Value = "21时" });
                keys.Add(new KeyValue() { Key = "22", Value = "22时" });
                keys.Add(new KeyValue() { Key = "23", Value = "23时" });

                keys.Add(new KeyValue() { Key = "9-12", Value = "9时-12时 " });
                keys.Add(new KeyValue() { Key = "12-15", Value = "12时-15时" });
                keys.Add(new KeyValue() { Key = "15-18", Value = "15时-18时" });
                keys.Add(new KeyValue() { Key = "18-21", Value = "18时-21时" });
                keys.Add(new KeyValue() { Key = "21-24", Value = "21时-24时" });
            }
            else if (areaCode == 10002) //加拿大
            {
                keys.Add(new KeyValue() { Key = "01", Value = "01时" });
                keys.Add(new KeyValue() { Key = "02", Value = "02时" });
                keys.Add(new KeyValue() { Key = "03", Value = "03时" });
                keys.Add(new KeyValue() { Key = "04", Value = "04时" });
                keys.Add(new KeyValue() { Key = "05", Value = "05时" });
                keys.Add(new KeyValue() { Key = "06", Value = "06时" });
                keys.Add(new KeyValue() { Key = "07", Value = "07时" });
                keys.Add(new KeyValue() { Key = "08", Value = "08时" });
                keys.Add(new KeyValue() { Key = "09", Value = "09时" });
                keys.Add(new KeyValue() { Key = "10", Value = "10时" });
                keys.Add(new KeyValue() { Key = "11", Value = "11时" });
                keys.Add(new KeyValue() { Key = "12", Value = "12时" });
                keys.Add(new KeyValue() { Key = "13", Value = "13时" });
                keys.Add(new KeyValue() { Key = "14", Value = "14时" });
                keys.Add(new KeyValue() { Key = "15", Value = "15时" });
                keys.Add(new KeyValue() { Key = "16", Value = "16时" });
                keys.Add(new KeyValue() { Key = "17", Value = "17时" });
                keys.Add(new KeyValue() { Key = "18", Value = "18时" });
                //19,20时不开奖，顾不用查询
                //keys.Add(new KeyValue() { Key = "19", Value = "19时" });
                //keys.Add(new KeyValue() { Key = "20", Value = "20时" });
                keys.Add(new KeyValue() { Key = "21", Value = "21时" });
                keys.Add(new KeyValue() { Key = "22", Value = "22时" });
                keys.Add(new KeyValue() { Key = "23", Value = "23时" });

                keys.Add(new KeyValue() { Key = "0-3", Value = "0时-3时" });
                keys.Add(new KeyValue() { Key = "3-6", Value = "3时-6时" });
                keys.Add(new KeyValue() { Key = "6-9", Value = "6时-9时" });
                keys.Add(new KeyValue() { Key = "9-12", Value = "9时-12时 " });
                keys.Add(new KeyValue() { Key = "12-15", Value = "12时-15时" });
                keys.Add(new KeyValue() { Key = "15-18", Value = "15时-18时" });
                //19,20时不开奖，顾不用查询
                //keys.Add(new KeyValue() { Key = "18-21", Value = "18时-21时" });
                keys.Add(new KeyValue() { Key = "21-24", Value = "21时-24时" });
            }
            return keys;
        }

    }
}
