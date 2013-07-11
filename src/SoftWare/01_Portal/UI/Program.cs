﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Helpmate.UI.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var login = new LoginForm();
            var result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new Default());
            }
            Application.Exit();
        }
    }
}
