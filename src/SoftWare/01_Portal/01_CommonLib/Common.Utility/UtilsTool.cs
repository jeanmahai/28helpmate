using System;
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
        public static String MD5(String info)
        {
            String UserPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(info, "md5").ToLower();
            return UserPassword.ToLower();
        }

        public static void PlayMusic(string musicName, bool isLooping)
        {
            SoundPlayer p = new SoundPlayer();
            p.SoundLocation = Application.StartupPath + "//" + musicName;
            p.Load();
            if (isLooping)
            {
                p.PlayLooping();
            }
            else
            {
                p.Play();
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
    }
}
