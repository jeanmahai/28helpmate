using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common.Utility
{
    public class AppMessage
    {
        public static void AlertMessage(int code)
        {
            string message = string.Empty;
            switch (code)
            {
                case 500:
                    message = "服务器异常，请稍后重试！";
                    break;
                case 400:
                    message = "无法连接到服务器，请稍后重试！";
                    break;
                default:
                    break;
            }
            MessageBox.Show(message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AlertMessage(string msg)
        {
            MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
