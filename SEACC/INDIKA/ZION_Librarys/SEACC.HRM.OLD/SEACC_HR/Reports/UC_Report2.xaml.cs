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
using System.Threading;
using System.Data;
using DataTire;
using Digiteq_Logic;
using Digiteq.DataSets;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_Report2.xaml
    /// </summary>
    public partial class UC_Report2 : UserControl
    {
        public UC_Report2()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Reports;
            SEACC_Form.Initialize();
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
        }

        private void SEACC_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_EPF cForm = new frm_EPF();
            cForm.Show();
        }

        private void SEACC_Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_ETF ETF = new frm_ETF();
            ETF.Show();

        }

        private void SEACC_Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_pays pays = new frm_pays();
            pays.Show();
        }

        private void SEACC_Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_salary salary = new frm_salary();
            salary.Show();
        }

        private void SEACC_Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_salarypf salaryPF = new frm_salarypf();
            salaryPF.Show();
        }

        private void SEACC_Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_salsum salSum = new frm_salsum();
            salSum.Show();
        }

        private void SEACC_Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_saltax saltax = new frm_saltax();
            saltax.Show();
        }

        private void SEACC_Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_slips slips = new frm_slips();
            slips.Show();
        }

        private void SEACC_Button_Click_8(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(2000);
            this.Cursor = Cursors.Arrow;
            frm_UpdaidEmp unpaidEmp = new frm_UpdaidEmp();
            unpaidEmp.Show();
        }
    }
}
