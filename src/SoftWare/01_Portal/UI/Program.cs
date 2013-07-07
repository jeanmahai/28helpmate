using System;
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
            Application.Run(new Default());
            Application.Exit();
            //LoginForm loginForm = new LoginForm();
            //loginForm.ShowDialog();
            //if (loginForm.DialogResult == DialogResult.OK)
            //{
            //    try
            //    {
            //        Application.Run(DefaultForm.Initialize());
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
        }
    }
}
