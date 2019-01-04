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
using AOSMITH_WMS;

namespace AnnexGlas
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        public string OpenFrom
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalWindow"/> class.
        /// </summary>
        public ModalWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModalWindow"/> class.
        /// </summary>
        /// <param name="_OpenFromPage">The _ open from page.</param>
        public ModalWindow(string _OpenFromPage)
        {
            InitializeComponent();
            OpenFrom = _OpenFromPage;
        }

        /// <summary>
        /// Handles the program event of the close control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void close_program(object sender, RoutedEventArgs e)
        {
            if (OpenFrom == "GRNMASTER")
            {
                //UCGRNMaster _oGrnMst = new UCGRNMaster();
                //_oGrnMst._BindItemCode();
            }
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

         
    }
}
