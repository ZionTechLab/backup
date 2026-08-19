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
using DataTire;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_BudgetPlan.xaml
    /// </summary>
    public partial class UC_BudgetPlan : UserControl
    {
        #region Form Load
        public UC_BudgetPlan()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Budget_Plan;
            SEACC_Form.Initialize(); 
            #endregion

            RefreshGrid();
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Category";
            textColumn1.Width = 150;
            grd_Plan.Columns.Add(textColumn1);

            foreach (tbl_payPeriod_Month oPayYear in tbl_payPeriod_Month.SelectAll())
            {
                DataGridTextColumn textColumn = new DataGridTextColumn();
                DataGridTextColumn Row2Col1 = new DataGridTextColumn();
                DataGridTextColumn Row2col2 = new DataGridTextColumn();
                DataGridTextColumn Row2col3 = new DataGridTextColumn();

                int a = 1;
                for (int i = 0; i < a; i++)
                {
                    textColumn.Header = oPayYear.Month_Tittle;
                    textColumn.Width = 150;
                    // textColumn.Binding = new Binding("FirstName");
                    grd_Plan.Columns.Add(textColumn);

                }
                a++;
            }
        } 
        #endregion
    }
}
