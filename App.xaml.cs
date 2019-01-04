using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Threading;
using AOS_COMMON;

namespace AOSMITH_WMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // give the mutex a  unique name
        private const string MutexName = "AOSMITH_WMS";

        // declare the mutex
        private readonly Mutex _mutex;

        bool createdNew;

        // overload the constructor
        public App()
        {
            _mutex = new Mutex(true, MutexName, out createdNew);

            if (!createdNew)
            {
                // if the mutex already exists, notify and quit
                MessageBox.Show("This program is already running");
                Application.Current.Shutdown(0);
            }
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if (!createdNew) return;
                MainWindow _omain = new MainWindow();
                _omain.Show();
            }
            catch (Exception ex)
            { AOS_COMMON.ShowErrorMsg(ex.ToString(), MsgType.Error); }
        }
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    if (Process.GetProcessesByName("AnnexGlas").Length > 1)
        //    {
        //        AOS_COMMON.ShowErrorMsg("Application already running", MsgType.Info);
        //        return;
        //    }

        //    base.OnStartup(e);
        //}
    }
}
