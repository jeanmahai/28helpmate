using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Helpmate.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool mutexWasCreated;
            Mutex mutex = new Mutex(true, "Helpmate.Update", out mutexWasCreated);
            if (mutexWasCreated)
            {
                Application.Run(new UpdateProcess(args));
                mutex.ReleaseMutex();
            }
        }
    }
}
