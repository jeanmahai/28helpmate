using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Common.Utility
{
    public class UtilsTool
    {
        public static String MD5(String info)
        {
            String UserPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(info, "md5").ToLower();
            return UserPassword.ToLower();
        }

        public static DialogResult Confirm(String msg)
        {
            DialogResult diaLog = MessageBox.Show(msg, " 系统提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return diaLog;
        }

        public static void Alert(String msg)
        {
            DialogResult diaLog = MessageBox.Show(msg, " 系统提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
