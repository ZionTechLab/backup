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
using DataTire;
using SEACC_WPFControls;
using Digiteq_Logic;

namespace SEACC_FACTORING
{
    /// <summary>
    /// Interaction logic for frm_FactoringInterestRate.xaml
    /// </summary>
    public partial class frm_FactoringInterestRate : Window
    {
        string sAggrement_no = "";

        #region Form Load  
        public frm_FactoringInterestRate()
        {
            InitializeComponent();
        }

        public frm_FactoringInterestRate(string AgrementNo)
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_InterestRateHistory;
            SEACC_Form.Initialize();
            #endregion

            if (SEACC_Form.PermissionTO_Read)
            {
                #region Initialize Data Table
                dgr_PayItems.dt.Columns.Add("Date");
                dgr_PayItems.dt.Columns.Add("InterestCredit");
                dgr_PayItems.dt.Columns.Add("InterestRecurse");
                #endregion

                #region Initialize DataGrid
                dgr_PayItems.Add_DatagridColoumn("Date", "Date", 80);
                dgr_PayItems.Add_DatagridColoumn("Interest Credit", "InterestCredit", 100);
                dgr_PayItems.Add_DatagridColoumn("Interest Recurse", "InterestRecurse", 120);
                #endregion

                SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
                sAggrement_no = AgrementNo;

                RefreshGrid();
                ShowDialog();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_PayItems.dt.Clear();

                foreach (tbl_bpsFactoringInterest detail in tbl_bpsFactoringInterest.SelectAll().Where(p => p.FactoringAgreement_ID == sAggrement_no))
                {
                    dgr_PayItems.dt.Rows.Add(clsFormatter.FormatDate_Short(detail.DateCreate), clsFormatter.FormatDecimalPlaces_Price(detail.Interest_Credit), clsFormatter.FormatDecimalPlaces_Price(detail.Interest_Recurse));
                }
                dgr_PayItems.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Action Buttons     
        private void grdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
