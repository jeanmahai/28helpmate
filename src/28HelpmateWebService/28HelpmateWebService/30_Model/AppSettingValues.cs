﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Model
{
    public class AppSettingValues
    {
        public static int PageCount {
            get { return int.Parse(ConfigurationManager.AppSettings["PageCount"]); }
        }
    }
}