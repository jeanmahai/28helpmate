using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Common.Utility
{
    public class UtilsTool
    {
        public static String MD5(String info)
        {
            String UserPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(info, "md5").ToLower();
            return UserPassword.ToLower();
        }

        public static DialogResult ShowMsg(String msg)
        {
            DialogResult diaLog = MessageBox.Show(msg, " 系统提示 ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return diaLog;
        }

        public static void PlayMusic(string musicName,bool isLooping)
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
    }
}
