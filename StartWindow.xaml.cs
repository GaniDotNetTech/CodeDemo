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

namespace AOSMITH_WMS
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
          //  txtversion.Text=Application.ru
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            MainWindow objLoginWindow = new MainWindow();
            objLoginWindow.ShowDialog();
            objLoginWindow = null;
            //MainWindow objMainWindow = new MainWindow();
            //objMainWindow.ShowDialog();
            //objMainWindow = null;
            this.Close();
            this.Dispatcher.InvokeShutdown();
            this.Cursor = Cursors.Arrow;
        }
    }
}
