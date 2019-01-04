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
using AOS_COMMON;

namespace AOSMITH_WMS
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public MsgResult ReturnMsg
        {
            get;
            set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public CustomMessageBox(string msg)
        {
            InitializeComponent();
            txtBmsg.Text = msg;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="_msgType">Type of the _MSG.</param>
        public CustomMessageBox(string msg, MsgType _msgType, int FontSize)
        {
            InitializeComponent();
            txtBmsg.Text = msg;
            txtBmsg.FontSize = FontSize;

            btnCANEL.Visibility = System.Windows.Visibility.Collapsed;
            btnNO.Visibility = System.Windows.Visibility.Collapsed;
            btnOK.Visibility = System.Windows.Visibility.Collapsed;
            btnYES.Visibility = System.Windows.Visibility.Collapsed;

            if (_msgType == MsgType.Confirm)
            {
                btnYES.Visibility = System.Windows.Visibility.Visible;
                btnNO.Visibility = System.Windows.Visibility.Visible;
                //btnCANEL.Visibility = System.Windows.Visibility.Visible;
                btnYES.Focus();
            }
            else if (_msgType == MsgType.Error)
            {
                btnOK.Visibility = System.Windows.Visibility.Visible;
                btnOK.Focus();
            }
            else if (_msgType == MsgType.Info)
            {
                btnOK.Visibility = System.Windows.Visibility.Visible;
                btnOK.Focus();
            }
            else if (_msgType == MsgType.Success)
            {
                btnOK.Visibility = System.Windows.Visibility.Visible;
                btnOK.Focus();
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="_msgType">Type of the _MSG.</param>
        public CustomMessageBox(string msg, MsgType _msgType )
        {
            InitializeComponent();
            txtBmsg.Text = msg;
            

            btnCANEL.Visibility = System.Windows.Visibility.Collapsed;
            btnNO.Visibility = System.Windows.Visibility.Collapsed;
            btnOK.Visibility = System.Windows.Visibility.Collapsed;
            btnYES.Visibility = System.Windows.Visibility.Collapsed;

            if (_msgType == MsgType.Confirm)
            {
                btnYES.Visibility = System.Windows.Visibility.Visible;
                btnNO.Visibility = System.Windows.Visibility.Visible;
                //btnCANEL.Visibility = System.Windows.Visibility.Visible;
                btnYES.Focus();
            }
            else if (_msgType == MsgType.Error)
            {
                btnOK.Visibility = System.Windows.Visibility.Visible;
                btnOK.Focus();
            }
            else if (_msgType == MsgType.Info)
            {
                btnOK.Visibility = System.Windows.Visibility.Visible;
                btnOK.Focus();
            }
            else if (_msgType == MsgType.Success)
            {
                btnOK.Visibility = System.Windows.Visibility.Visible;
                btnOK.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the Yes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            this.ReturnMsg = MsgResult.YES;
            this.Close();
        }
        /// <summary>
        /// Handles the Click event of the NO control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NO_Click(object sender, RoutedEventArgs e)
        {
            this.ReturnMsg = MsgResult.NO;
            this.Close();
        }
        /// <summary>
        /// Handles the Click event of the OK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.ReturnMsg = MsgResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the CANCEL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            this.ReturnMsg = MsgResult.CANCEL;
            this.Close();
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// Handles the PreviewKeyDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
