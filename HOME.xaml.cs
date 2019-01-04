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
using AOSMITH_WMS.Main.UI.Master;
using AOSMITH_WMS.Main.UI.Transaction;
using AOSMITH_WMS.Main.UI.Report;
using System.Configuration;

namespace AOSMITH_WMS
{
    /// <summary>
    /// Interaction logic for HOME.xaml
    /// </summary>
    public partial class HOME : Window
    {
        
      
        public HOME()
        {
            InitializeComponent();
        }

        #region Button Events

        private void Minimize_program(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void close_program(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            this.Close();
        }
        private void hypLocationRM_Click(object sender, RoutedEventArgs e)
        {
            UCLocation oLoc = new UCLocation("RM");
            stpContent.Children.Clear();
            stpContent.Children.Add(oLoc);
            expMenu.IsExpanded = false;
        }
        private void hypLocationFG_Click(object sender, RoutedEventArgs e)
        {
            UCLocation oLoc = new UCLocation("FG");
            stpContent.Children.Clear();
            stpContent.Children.Add(oLoc);
            expMenu.IsExpanded = false;
        }

        private void hypLine_Click(object sender, RoutedEventArgs e)
        {
            UCLine oLine = new UCLine();
            stpContent.Children.Clear();
            stpContent.Children.Add(oLine);
            expMenu.IsExpanded = false;
        }

        private void hypUser_Click(object sender, RoutedEventArgs e)
        {
            UCUsers oUsers = new UCUsers();
            stpContent.Children.Clear();
            stpContent.Children.Add(oUsers);
            expMenu.IsExpanded = false;
        }

        private void hypUserRight_Click(object sender, RoutedEventArgs e)
        {
            UCUsersRights oUsersRights = new UCUsersRights();
            stpContent.Children.Clear();
            stpContent.Children.Add(oUsersRights);
            expMenu.IsExpanded = false;
        }
 

        private void expMenu_Expanded(object sender, RoutedEventArgs e)
        {
            if (stpContent != null)
            {
                if (stpContent.Children.Count > 0)
                {
                    stpContent.Children.Clear();
                }
               
            }
            if (expdashbord != null)
            {
                expdashbord.IsExpanded = false;
                expdashbord.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void expdashbord_Expanded(object sender, RoutedEventArgs e)
        {
            if (stpContent != null)
            {
                if (stpContent.Children.Count > 0)
                {
                    stpContent.Children.Clear();
                }
                if (stpDashbord.Children.Count > 0)
                {
                    stpDashbord.Children.Clear();
                }
                UCFGDashBordReports obj = new UCFGDashBordReports();
                stpContent.Children.Add(obj);
                expdashbord.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (expMenu != null)
            {
                expMenu.IsExpanded = false;
            }
        }

        #endregion

        private void hypPickList_Click(object sender, RoutedEventArgs e)
        {
            UCPickList oPickList = new UCPickList();
            stpContent.Children.Clear();
            stpContent.Children.Add(oPickList);
            expMenu.IsExpanded = false;
        }

        private void hypPrinting_Click(object sender, RoutedEventArgs e)
        {
            UCPrinting oPrint = new UCPrinting();
            stpContent.Children.Clear();
            stpContent.Children.Add(oPrint);
            expMenu.IsExpanded = false;
        }

        private void hypMinPickList_Click(object sender, RoutedEventArgs e)
        {
            UCJOMINPicking oMinPicking = new UCJOMINPicking();
            stpContent.Children.Clear();
            stpContent.Children.Add(oMinPicking);
            expMenu.IsExpanded = false;
        }

        private void hypSerialPrint_Click(object sender, RoutedEventArgs e)
        {
            UCFGMOPrinting oFGMOPrint = new UCFGMOPrinting();
            stpContent.Children.Clear();
            stpContent.Children.Add(oFGMOPrint);
            expMenu.IsExpanded = false;
        }
         

        private void UCHOME_Loaded(object sender, RoutedEventArgs e)
        {
            StringBuilder sbDetails = new StringBuilder();


            string value = ConfigurationManager.ConnectionStrings["AOSMITH"].ConnectionString.ToString();

            string[] sconstr = value.Split(';');
            string _DataSouce = sconstr[0].Substring(sconstr[0].IndexOf("=") + 1);
            string _DatabaseName = sconstr[1].Substring(sconstr[1].IndexOf("=") + 1);
            //string _UserID = sconstr[2].Substring(sconstr[2].IndexOf("=") + 1);
            //string _Password = sconstr[3].Substring(sconstr[3].IndexOf("=") + 1);


            sbDetails.Append(" Welcome : " + AOS_COMMON.UserName + " | Server Name : " + _DataSouce + " |  Database Name : " + _DatabaseName + " | Application Version : " + AOS_COMMON._Version + " | Date : " + System.DateTime.Now.ToString("dd-MMM-yyyy"));

            txtBDetails.Text = sbDetails.ToString();


            txtUserName.Text = " Welcome : " + AOS_COMMON.UserName;
        
            
        }
  
        // RM REPORTS

        private void hypGrnReport_Click(object sender, RoutedEventArgs e)
        {
            UCGRNReports obj = new UCGRNReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

        private void hypRMInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            UCRMInventoryReports obj = new UCRMInventoryReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }
          
        private void hypMRSPickSlip_Click(object sender, RoutedEventArgs e)
        {
            UCMRSPICKSLIPReports obj = new UCMRSPICKSLIPReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

        
        private void hypRMInventoryMovementReport_Click(object sender, RoutedEventArgs e)
        {
            UCRMINVENTORYMOVEMENTReports obj = new UCRMINVENTORYMOVEMENTReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

        // FG Report

        private void hypMODetailsReport_Click(object sender, RoutedEventArgs e)
        {
            UCFGMODetailsReports obj = new UCFGMODetailsReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }
        
        private void hypFGInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            UCFGINVENTORYReports obj = new UCFGINVENTORYReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

        private void hypFGInventoryMovement_Click(object sender, RoutedEventArgs e)
        {
            UCFGINVENTORYMOVEMENTReports obj = new UCFGINVENTORYMOVEMENTReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

        private void hypFGDispatch_Click(object sender, RoutedEventArgs e)
        {
            UCDISPATCHReports obj = new UCDISPATCHReports();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

        private void hypBarcodeStatus_Click(object sender, RoutedEventArgs e)
        {
            UCAllStatusReprint obj = new UCAllStatusReprint();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

        private void hypChangePassword_Click(object sender, RoutedEventArgs e)
        {
            UCChangePassword obj = new UCChangePassword();
            stpContent.Children.Clear();
            stpContent.Children.Add(obj);
            expMenu.IsExpanded = false;
        }

    }
}
