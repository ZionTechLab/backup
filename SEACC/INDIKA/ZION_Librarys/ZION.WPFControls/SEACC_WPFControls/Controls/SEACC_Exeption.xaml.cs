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

namespace SEACC_WPFControls
{
    /// <summary>
    /// Interaction logic for SEACC_Exeption.xaml
    /// </summary>
    public partial class SEACC_Exeption : Window
    {
        public SEACC_Exeption()
        {
            InitializeComponent();
        }

        public SEACC_Exeption(System.Exception ex)
        {
            InitializeComponent();

             System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
              //  MessageBox.Show("Line: " + trace.GetFrame(0).GetFileLineNumber());
              // // MessageBox.Show("Line: " + trace.GetFrame(0).GetMethod());
               //  MessageBox.Show("Line: " + trace.GetFrame(0).GetFileName());

                 lbl_LineNo.Text = trace.GetFrame(0).GetFileLineNumber().ToString();
                 lbl_Method.Text = trace.GetFrame(0).GetMethod().ToString();
                 try
                 {
                     lbl_File.Text = trace.GetFrame(0).GetFileName().ToString();
                 }
                 catch (Exception)
                 {

                 }
                 lbl_Messege.Text = ex.Message;
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
