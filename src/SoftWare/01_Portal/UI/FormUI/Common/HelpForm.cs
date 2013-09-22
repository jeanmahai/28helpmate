using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Policy;
using System.IO;
using Helpmate.UI.Forms.Code;

namespace Helpmate.UI.Forms.FormUI.Common
{
    public partial class HelpForm : Form
    {
        public PageForm Page { get; set; }

        public HelpForm(PageForm page)
        {
            Page = page;
            InitializeComponent();
        }

        private void HelpFrom_Load(object sender, EventArgs e)
        {
            if (Page != null)
            {
                webBrowser.ScriptErrorsSuppressed = true; //禁用错误脚本提示
                webBrowser.IsWebBrowserContextMenuEnabled = false; //禁用右键菜单
                webBrowser.WebBrowserShortcutsEnabled = false; //禁用快捷键
                webBrowser.AllowWebBrowserDrop = false;//禁止拖拽

                var htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Resource\{0}.html", Page));
                if (File.Exists(htmlPath))
                {
                    Uri url = new Uri(htmlPath);
                    webBrowser.Url = url;
                    return;
                }
            }
            webBrowser.DocumentText = "暂时未添加帮助文档，请联系管理员！";
        }
    }
}
