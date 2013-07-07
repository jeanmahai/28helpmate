using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity.Enum;
using Helpmate.UI.Forms.Properties;

namespace Helpmate.UI.Forms.UserContorl
{
    public partial class LoadingCtrl : UserControl
    {
        private static LoadingCtrl loadingCtrl;

        private static LoadingCtrl LoadingInstance()
        {
            if (loadingCtrl == null)
            {
                loadingCtrl = new LoadingCtrl();
            }
            return loadingCtrl;
        }

        public LoadingCtrl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载框样式设置
        /// </summary>
        /// <param name="enumType">Right,Error</param>
        /// <param name="msg">提示信息</param>
        public static LoadingCtrl LoadModel(AppMessage enumType, string msg)
        {
            loadingCtrl = LoadingInstance();
            switch (enumType)
            {
                case AppMessage.Right:
                    loadingCtrl.picLoading.Image = Resources.right;
                    loadingCtrl.lblMsg.Text = msg;
                    loadingCtrl.lblMsg.ForeColor = Color.Black;
                    break;
                case AppMessage.Error:
                    loadingCtrl.picLoading.Image = Resources.error;
                    loadingCtrl.lblMsg.Text = msg;
                    loadingCtrl.lblMsg.ForeColor = Color.Red;
                    break;
                default:
                    loadingCtrl.picLoading.Image = Resources.loading;
                    loadingCtrl.lblMsg.Text = msg;
                    loadingCtrl.lblMsg.ForeColor = Color.Black;
                    break;
            }
            return loadingCtrl;
        }

        /// <summary>
        /// 默认启动加载样式
        /// </summary>
        public static LoadingCtrl LoadModel()
        {
            loadingCtrl = LoadingInstance();
            loadingCtrl.picLoading.Image = Resources.loading;
            loadingCtrl.lblMsg.Text = "请稍后正在加载中...";
            loadingCtrl.lblMsg.ForeColor = Color.Black;
            return loadingCtrl;
        }
    }
}
