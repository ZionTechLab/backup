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
using Digiteq_Logic;
using System.IO;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_Reports.xaml
    /// </summary>
    public partial class UC_Reports : UserControl
    {
        string sImagePath = "";
    
        public UC_Reports()
        {
            InitializeComponent();
     
            SEACC_Form.enmFormName = FormName.Reports;
            SEACC_Form.Initialize();
            btn_Clear_Click(null, null);
        }

       

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txt_Year, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txt_Month, true, false, false);
            lbl_ReportName.Content = "";
            txt_Year.Text = "";
            txt_Month.Text = "";
        }

        private void txt_Year_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRYear);
            if (RowDataSearch.DialogResult == true)
            {
                txt_Year.Text = lstResult[0];
            }
        }

        private void txt_Month_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HRMonth);
            if (RowDataSearch.DialogResult == true)
            {
                txt_Month.Text = lstResult[1];
            }
        }

      
        private static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(Directory.GetCurrentDirectory()+ imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }
        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
           // frm_EPF fepf = new frm_EPF();
            frm_WaitingMessege_mini ww = new frm_WaitingMessege_mini();
            ww.ShowDialog();

            if (sImagePath == "1")
            {
                Window w = new frm_EPF();
                w.ShowDialog();
            }
            else if (sImagePath == "2")
            {
                frm_ETF fepf = new frm_ETF();
                fepf.ShowDialog(); 
            }
            else if (sImagePath == "3")
            {
                frm_UpdaidEmp fepf = new frm_UpdaidEmp();
                fepf.ShowDialog();
            } 
            else if (sImagePath == "4")
            {
                frm_pays fepf = new frm_pays();
                fepf.ShowDialog();
            }
            else if (sImagePath == "5")
            {
                frm_salary fepf = new frm_salary();
                fepf.ShowDialog();
            }
            else if (sImagePath == "6")
            {
                frm_slips fepf = new frm_slips();
                fepf.ShowDialog();
            }
            else if (sImagePath == "7")
            {
                frm_salarypf fepf = new frm_salarypf();
                fepf.ShowDialog();
            }
            else if (sImagePath == "8")
            {
                frm_saltax fepf = new frm_saltax();
                fepf.ShowDialog();
            }
            else if (sImagePath == "9")
            {
                frm_salsum fepf = new frm_salsum();
                fepf.ShowDialog();
            }
        }

        private void btn_Form_c_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_Form_c.Content;
            sImagePath = "1";
        }
        private void btn_R4_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_R4.Content;
            sImagePath = "2";
        }

        private void btn_Employee_Category1_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_Employee_Category1.Content;
            sImagePath = "3";
        }

        private void btn_Employee_Category2_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_Employee_Category2.Content;
            sImagePath = "4";
        }

        private void btn_Employee_Category3_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_Employee_Category3.Content;
            sImagePath = "5";
        }

        private void btn_Section_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_Section.Content;
            sImagePath = "6";
        }

        private void btn_salpf_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_salpf.Content;
            sImagePath = "7";
        }

        private void btn_saltax_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_saltax.Content;
            sImagePath = "8";
        }

        private void btn_salsum_Click(object sender, RoutedEventArgs e)
        {
            lbl_ReportName.Content = btn_salsum.Content;
            sImagePath = "9";
        } 
    }
}
