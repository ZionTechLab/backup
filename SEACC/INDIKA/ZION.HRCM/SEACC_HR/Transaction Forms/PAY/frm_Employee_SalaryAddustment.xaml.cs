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
using System.Data;
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using ZION.HRCM.DOMAIN.PAY;
using ZION.HRCM.DATA.PAY;

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for frm_Employee_SalaryAddustment.xaml
    /// </summary>
    public partial class frm_Employee_SalaryAddustment : Window
    {
        string sGrid_GroupID = "";
        int Period_SubID;
        public frm_Employee_SalaryAddustment(string _sGrid_GroupID, string _sGrid_Period_SubID)
        {
            InitializeComponent();

            #region Initialize Process  Period DataGrid
            dgr_PayItems.Add_DatagridColoumn("Employee ID", "employee_ID", 70, true);
            dgr_PayItems.Add_DatagridColoumn("EPF No.", "epfNo", 70, true);
            dgr_PayItems.Add_DatagridColoumn("Name", "fullName", 200, true);
            dgr_PayItems.Add_DatagridColoumn(ColoumnType.Numaric, "", "Salary Advance", "AmountAdvance", 100, true,false);
            dgr_PayItems.Add_DatagridColoumn(ColoumnType.Numaric, "", "Loan Deduction", "amountLoan", 100, true, false);
            dgr_PayItems.Add_DatagridColoumn(ColoumnType.Numaric, "", "Adjustments", "amountAdjustment", 100, true, false);
            dgr_PayItems.Add_DatagridColoumn(ColoumnType.Numaric, "", "Telephone Deduction", "amountTelephone", 100,true, false);
            #endregion
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;

            sGrid_GroupID = _sGrid_GroupID;
            Period_SubID = int.Parse(_sGrid_Period_SubID);

            SEACC_Form.SetVisibility_ActionButons(false, false, true, false);

            string sQry = "exec [dbo].[sp_GET_EmployeesForAdj]  '" + clsSecurity.CompanyID + "' , '" + clsSecurity.BranchID + "' , '" + sGrid_GroupID + "' , " + Period_SubID;
            DataTable dt_result = DBHandling.ExecQuery(sQry).Tables[0];

            dgr_PayItems.dt = dt_result;
            dgr_PayItems.RefreshGrid();
        }
        private decimal getDecimalValue(DataRow Row, string Field)
        {
            decimal Amount = 0;
            decimal.TryParse(Row[Field].ToString(), out Amount);
            return Amount;
        }
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var para = new List<tbl_payTxSalaryAdjustment>();

            foreach (DataRow row in dgr_PayItems.dt.Rows)
            {                 
                var Adj = new tbl_payTxSalaryAdjustment
                {
                    company_ID = clsSecurity.CompanyID,
                    companyBranch_ID = clsSecurity.BranchID,
                    processGroup_ID = sGrid_GroupID,
                    processPeriod_Sub_ID = Period_SubID,
                    employee_ID = row["employee_ID"].ToString(),
                    amountAdvance = getDecimalValue(row, "AmountAdvance"),
                    amountLoan = getDecimalValue(row, "amountLoan"),
                    amountAdjustment = getDecimalValue(row, "amountAdjustment"),
                    amountTelephone = getDecimalValue(row, "amountTelephone"),
                };
                para.Add(Adj);
            }

            if (para.Count != 0)
            {
                PayProcessData oData = new PayProcessData();
              var Responce=  oData.Update_SalaryAdjustment(para);
                if (Responce.IsSuccess)
                    MessageBox.Show("save-successfull");
                else
                    MessageBox.Show(Responce.OutMsg);

            }
            else
            {
                MessageBox.Show("No Records");
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void grdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgr_PayItems_CellEditBegining(object sender, DataGridBeginningEditEventArgs e)
        {

        }

        private void dgr_PayItems_MouseLeftButtonUp1(object sender, EventArgs e)
        {

        }

        private void dgr_PayItems_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
