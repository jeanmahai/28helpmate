﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebUI.Utility
{
    public class PageBase:Page
    {
        public virtual void PageLoad() { }

        public void Page_Load(object sender,EventArgs e)
        {
            PageLoad();
        }

        public void Alert(string message)
        {
            ScriptManager.RegisterStartupScript(this,
                GetType(),
                string.Format("alert_{0}",new Random().Next(1000)),
                string.Format("$(document).ready(function(){{ var timer=setTimeout(function(){{alert('{0}');clearTimeout(timer)}},1000); }}); ",message),
                true);
        }
    }
}