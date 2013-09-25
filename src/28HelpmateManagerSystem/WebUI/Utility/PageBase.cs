using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebUI.Utility
{
    public class PageBase : Page
    {
        public virtual void PageLoad(){}

        public void Page_Load(object sender,EventArgs e)
        {
            PageLoad();
        }
    }
}