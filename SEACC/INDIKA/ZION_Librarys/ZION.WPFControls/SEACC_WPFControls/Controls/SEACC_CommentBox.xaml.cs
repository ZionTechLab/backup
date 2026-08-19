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
using System.Windows.Shapes;
using SEACC_WPFControls;

namespace SEACC_WPFControls
{
    /// <summary>
    /// Interaction logic for SEACC_CommentBox.xaml
    /// </summary>
    public partial class SEACC_CommentBox : Window
    {
       
        public SEACC_CommentBox()
        {
            InitializeComponent();
            
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtComment.Text !="")
            {
                this.DialogResult = true;
                GetCommnet();
                this.Close(); 
            }
            else
            {
                SEACCMessageBox.Show("Oops....", "Comment is Compulsory for Approvals or Rejections", MessageBoxButton.OK);
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Btn_OK_Click(null, null);

            e.Handled = true;
        }

        public  string GetCommnet()
        {
            return txtComment.Text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtComment.Focus();
        }

        

    }
}
