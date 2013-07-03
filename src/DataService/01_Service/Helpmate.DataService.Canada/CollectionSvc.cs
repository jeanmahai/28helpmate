﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Configuration.Install;

using Helpmate.DataService.Utility;

namespace Helpmate.DataService.Canada
{
    [RunInstallerAttribute(true)]
    public class CollectionSvcInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public CollectionSvcInstaller()
        {
            // Instantiate installers for process and services.
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // The services run under the system account.
            processInstaller.Account = ServiceAccount.LocalSystem;

            // The services are started manually.
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            // ServiceName must equal those on ServiceBase derived classes.            
            serviceInstaller.ServiceName = GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName");

            serviceInstaller.DisplayName = GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName");
            serviceInstaller.Description = GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceDesciption");

            // Add installers to collection. Order is not important.
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
            this.AfterInstall += new InstallEventHandler(MyProjectInstaller_AfterInstall);
        }

        void MyProjectInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            if (ServiceIsExist(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName")))
                StartService(new string[] { });
        }

        public static void InstallService()
        {
            string[] cmdline = { };
            string serviceFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;

            TransactedInstaller instutil = new TransactedInstaller();
            AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);

            Console.WriteLine(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName"));

            instutil.Installers.Add(assemblyInstaller);
            instutil.Install(new System.Collections.Hashtable());
            instutil.Dispose();

        }

        public static void UnInstallService()
        {
            string[] cmdline = { };
            string serviceFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;

            TransactedInstaller instutil = new TransactedInstaller();
            AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);

            Console.WriteLine("开始卸载" + GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName") + "。");

            instutil.Installers.Add(assemblyInstaller);
            instutil.Uninstall(null);
            instutil.Dispose();

        }

        public static void StartService(string[] args)
        {
            if (ServiceIsExist(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName")))
            {
                ServiceController sc = new ServiceController(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName"));
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    Console.WriteLine("开始服务……");

                    if (args.Length == 2 && args[1] == "runnow")

                        sc.Start(new string[] { "runnow" });
                    else
                        sc.Start();

                    sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 5));

                    Console.WriteLine("服务已开始。");
                }
                else
                {
                    Console.WriteLine("服务并未处在停止状态。");
                }
            }
            else
            {
                Console.WriteLine("服务尚未安装。");
            }
        }

        public static void StopService()
        {
            if (ServiceIsExist(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName")))
            {
                ServiceController sc = new ServiceController(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName"));
                if (sc.Status != ServiceControllerStatus.Stopped && sc.Status != ServiceControllerStatus.StopPending)
                {
                    Console.WriteLine("停止服务……");

                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));

                    Console.WriteLine("服务已停止。");
                }
                else
                {
                    Console.WriteLine("服务已停止或正在响应停止请求。");
                }
            }
            else
            {
                Console.WriteLine("服务尚未安装。");
            }
        }

        private static bool ServiceIsExist(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public partial class CollectionSvc : ServiceBase
    {
        private static Thread mainThread;

        public CollectionSvc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Program.isService = true;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.ExceptionLogger);

            EventLog.WriteEntry(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName"), "服务接收到开始指令。", EventLogEntryType.Information);

            SvcMain.running = true;
            mainThread = new Thread(new ThreadStart(SvcMain.Run));
            mainThread.Start();
        }

        protected override void OnStop()
        {
            this.RequestAdditionalTime(10000);

            SvcMain.running = false;
            //等待计算即时数据完成
            if ((mainThread != null) && (mainThread.IsAlive))
            {
                if (mainThread.Join(new TimeSpan(0, 0, 8)))
                {
                    mainThread.Abort();
                }
            }

            EventLog.WriteEntry(GetConfig.GetXMLValue(ConfigSource.Canadan, "ServiceName"), "服务接收到终止指令，已终止。", EventLogEntryType.Information);
        }
    }
}
