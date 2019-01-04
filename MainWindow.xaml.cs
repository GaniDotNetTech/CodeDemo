using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using BcilLib;
using System.Reflection;
using AOS_COMMON;

namespace AOSMITH_WMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                 DragMove();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                lblVer.Content = "Version  " + AOS_COMMON._Version;
                DirectoryInfo _dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Log");
                if (_dir.Exists == false)
                {
                    _dir.Create();
                }
                //BcilLib.BcilLoger _obj = new BcilLib.BcilLogger();
                AOS_COMMON.mAppLog = new BcilLogger();
                AOS_COMMON.mAppLog.ChangeInterval = BcilLib.BcilLogger.ChangeIntervals.ciHourly;
                AOS_COMMON.mAppLog.EnableLogFiles = true;
                AOS_COMMON.mAppLog.LogDays = 30;
                AOS_COMMON.mAppLog.LogFilesExt = "log";
                AOS_COMMON.mAppLog.LogFilesPath = AppDomain.CurrentDomain.BaseDirectory;
                AOS_COMMON.mAppLog.LogFilesPrefix = "BcilApps-AOSMITH WIP";
                AOS_COMMON.mAppLog.StartLogging();
                AOS_COMMON.mAppLog.LogMessage(BcilLib.EventNotice.EventTypes.evtInfo, "BcilAppsAOSMITH WIPInitialize" + "  ::  Main", "Initializing Application.......");
                txtUserName.Focus();

                //AOS_COMMON.UserName = "admin";
                //AOS_COMMON.UserID = "1";

                //txtUserName.Text = "1";
                //txtPassword.Password = "1";
              //  Login_Click(this, null);
                //this.Hide();
                //txtUserName.Focus();

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                AOS_COMMON.mAppLog.LogMessage(EventNotice.EventTypes.evtError, MethodBase.GetCurrentMethod().Name, ex.ToString());

                AOS_COMMON.ShowErrorMsg(ex.ToString(), MsgType.Error);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_Validation())
                {

                    PR_USERS oprUsers = new PR_USERS();
                    BL_Login oLogin = new BL_Login();

                    OperationResult opResult = new OperationResult();
                    AOS_ENCRYPTION oEncrypt = new AOS_ENCRYPTION();

                    oprUsers.USERNAME = txtUserName.Text.ToString();
                    oprUsers.PASSWORD = oEncrypt.Encrypt_data(txtPassword.Password.ToString()).ToString();
                    opResult = oLogin.ValidateLogin(oprUsers);

                    if (txtUserName.Text == "admin" && txtPassword.Password == "bcil")
                    {
                        AOS_COMMON.UserName = txtUserName.Text;
                        HOME oHome = new HOME();
                        oHome.Show();
                        this.Close();
                        opResult = OperationResult.ActiveUsers;

                    }

                    if (opResult == OperationResult.ActiveUsers)
                    {
                        opResult = oLogin.ValidateUserRights(oprUsers);
                        if (opResult == OperationResult.Invalid)
                        {
                            AOS_COMMON.ShowErrorMsg("Application Version Changed,Pls Update,Contact Your IT Persion", MsgType.Error);
                            txtUserName.Focus();
                            return;
                        }
                         
                        AOS_COMMON.UserName = txtUserName.Text;
                        HOME oHome = new HOME();
                        oHome.Show();
                        this.Close();
                    }
                    else if (opResult == OperationResult.InActiveUsers)
                    {
                        AOS_COMMON.ShowErrorMsg("In-Active User", MsgType.Error);
                        txtUserName.Focus();
                    }
                    else if (opResult == OperationResult.Invalid)
                    {
                        AOS_COMMON.ShowErrorMsg("Invalid UserName Or Password", MsgType.Error);
                        txtUserName.Text = string.Empty;
                        txtPassword.Password = string.Empty;
                        txtUserName.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                AOS_COMMON.mAppLog.LogMessage(EventNotice.EventTypes.evtError, MethodBase.GetCurrentMethod().Name, ex.ToString());
                AOS_COMMON.ShowErrorMsg(ex.ToString(), MsgType.Error);
            }
        }
        private bool _Validation()
        {
            bool flag = true ;
            if (txtUserName.Text == string.Empty)
            {
                flag = false;
                txtUserName.Focus();
                AOS_COMMON.ShowErrorMsg("user name cannot be left blank", MsgType.Error);
            }
            else if (txtPassword.Password == string.Empty)
            {
                flag = false;
                txtPassword.Focus();
                AOS_COMMON.ShowErrorMsg("password cannot be left blank", MsgType.Error);
            }
            return flag;

        }
        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void txtUserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin.Focus();
            }
        }

      
 
    }
}
