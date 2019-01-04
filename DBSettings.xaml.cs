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
using System.Windows.Shapes;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using BcilLib;
using AOS_COMMON;

namespace AOSMITH_WMS
{
    /// <summary>
    /// Interaction logic for DBSettings.xaml
    /// </summary>
    public partial class DBSettings : Window
    {
          public string  _DataSouce 
        {
        get;
        set;
        }
        public string   _DatabaseName 
        {
        get;set;
        }
        public string  _UserID 
        {
        get;set;
        }
        public string _Password
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBSettings"/> class.
        /// </summary>
        public DBSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the program event of the close control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void close_program(object sender, RoutedEventArgs e)
        {
            MainWindow _oMainWindow = new MainWindow();
            _oMainWindow.Show();
            this.Close();
        }
        /// <summary>
        /// Handles the MouseDown event of the Grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        /// <summary>
        /// Shows the configuration.
        /// </summary>
        public void ShowConfig()
        {
            //foreach (string key in ConfigurationManager.ConnectionStrings)
            //{
                string value = ConfigurationManager.ConnectionStrings["AnnexGlas"].ConnectionString.ToString();
                 
                    string[] sconstr = value.Split(';');
                    _DataSouce = sconstr[0].Substring(sconstr[0].IndexOf("=") + 1);
                    _DatabaseName = sconstr[1].Substring(sconstr[1].IndexOf("=") + 1);
                    _UserID = sconstr[2].Substring(sconstr[2].IndexOf("=") + 1);
                    _Password = sconstr[3].Substring(sconstr[3].IndexOf("=") + 1);

                    txtServerName.Text = _DataSouce;
                    txtDatabaseName.Text = _DatabaseName;
                    txtUserName.Text = _UserID;
                    txtPassword.Password = _Password;
               
            //}
        }

        /// <summary>
        /// Gets the configuration file path.
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }

        /// <summary>
        /// Loads the configuration document.
        /// </summary>
        /// <returns></returns>
        private static XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(GetConfigFilePath());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return doc;
        }
        /// <summary>
        /// Writes the setting.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <exception cref="InvalidOperationException">appSettings section not found in config file.</exception>
        public static void WriteSetting(string name, string connectionString)
        {
            // load config document for current assembly
            XmlDocument doc = LoadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//connectionStrings");
            node.RemoveAll();
            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@name='{0}']", name));

                if (elem != null)
                {
                    // add value for key
                    elem.SetAttribute("value", connectionString);
                }
                else
                {
                    // key was not found so create the 'add' element 
                    // and set it's key/value attributes 
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("name", name);
                    elem.SetAttribute("connectionString", connectionString);
                    node.AppendChild(elem);
                }
                doc.Save(GetConfigFilePath());
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            bool result = true;
            if (txtServerName.Text == string.Empty)
            {
                AOS_COMMON.ShowErrorMsg("Server Name Cannot be left blank", txtServerName, MsgType.Error);
                result = false;
            }
            else if (txtDatabaseName.Text == string.Empty)
            {
                AOS_COMMON.ShowErrorMsg("Database Name Cannot be left blank", txtDatabaseName, MsgType.Error);
                result = false;
            }
            else if (txtUserName.Text == string.Empty)
            {
                AOS_COMMON.ShowErrorMsg("User Id Cannot be left blank", txtUserName, MsgType.Error);
                result = false;
            }
            else if (txtPassword.Password == string.Empty)
            {
                AOS_COMMON.ShowErrorMsg("Password Cannot be left blank", txtPassword, MsgType.Error);
                result = false;
            }
            return result;
        }
        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    WriteSetting("AnnexGlas", "Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=" + txtDatabaseName.Text.Trim() + ";User ID=" + txtUserName.Text.Trim() + ";Password=" + txtPassword.Password.Trim() + " ");
                }
                if (AOS_COMMON.ShowErrorMsg(" *** DB setting  changed successfully *** \n *** Setting will be refelected after restarting the application? ***",txtServerName,MsgType.Info)==MsgResult.OK)
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                AOS_COMMON.ShowErrorMsg(ex.ToString(), txtServerName, MsgType.Error);
                AOS_COMMON.mAppLog.LogMessage(EventNotice.EventTypes.evtError, MethodBase.GetCurrentMethod().Name, ex.ToString());
            }

        }

        /// <summary>
        /// Handles the Loaded event of the DBSettingsForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void DBSettingsForm_Loaded(object sender, RoutedEventArgs e)
        {
            ShowConfig();
        }
    }
}
