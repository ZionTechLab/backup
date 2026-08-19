using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using SEACC_WPFControls;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string file = "SEACC_WPFControls.dll";
            string fileVersion = FileVersionInfo.GetVersionInfo(file).FileVersion;
            lbl1.Content = fileVersion;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frm_LandingPage oFrm = new frm_LandingPage(3);
            oFrm.Show();
        }
    }
}
