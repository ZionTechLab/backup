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

namespace SEACC_FACTORING.UserControls
{
    /// <summary>
    /// Interaction logic for Attachments.xaml
    /// </summary>
    public partial class Attachments : UserControl
    {
        bool bIsItemChanged = false;
        public Attachments()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // dlg.DefaultExt = ".txt";
            //  dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                bIsItemChanged = true;
                // Open document
                string filename = dlg.FileName;
                //   FileNameTextBox.Text = filename;
            }
        }
    }
}
