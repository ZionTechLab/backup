using DataTire;
using Digiteq_Logic;
using ZION.PCB.Common;
using ZION.PCB.Search;
using SEACC_PCB.Transaction_Forms;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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
using ZION.PCB.Transaction_Forms;

namespace SEACC_PCB
{
    /// <summary>
    /// Interaction logic for UC_PettyCashBook.xaml
    /// </summary>
    public partial class UC_PettyCashBook : UserControl
    {
        bool isViewMode = true;

        #region Class Variables
        DataTable dtPCB = new DataTable();
        DataTable dtIOU = new DataTable();
        string slblPCAccID = "";
        decimal dFloatAmnt = 0;
        bool bShowAll = false;
        decimal dAvailableBal = 0;
        #endregion

        #region Form Load
        public UC_PettyCashBook()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_PettyCashBook;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            #endregion

            #region PCB Data Table
            dtPCB.Columns.Add("Date");
            dtPCB.Columns.Add("ExpID");
            dtPCB.Columns.Add("CatID");
            dtPCB.Columns.Add("CatCode");
            dtPCB.Columns.Add("SpentBy");
            dtPCB.Columns.Add("Remarks");
            dtPCB.Columns.Add("Expenses");
            dtPCB.Columns.Add("Income");
            dtPCB.Columns.Add("isCanceled");
            dtPCB.Columns.Add("Balance");
            dtPCB.Columns.Add("BalanceAct");
            #endregion

            #region IOU Data Table
            dtIOU.Columns.Add("IOUDate");
            dtIOU.Columns.Add("IOUTxnCode");
            dtIOU.Columns.Add("IOURemarks");
            dtIOU.Columns.Add("IOUExpenses");
            dtIOU.Columns.Add("IOUUnSettledAmnt");
            dtIOU.Columns.Add("IOUBalance");
            dtIOU.Columns.Add("IOUBalanceAct");
            #endregion

            #region Initialize Data Grid
            #endregion

            ClearFields();
            RefreshGridIOU();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (SEACC_Form.ActualWidth < 850)
            //    rowB.Height = new GridLength(210);
            //else
            //    rowB.Height = new GridLength(670);
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            #region Financial year start date
            string s = clsMethods_GL.getFinancialYear_ID_Current().ToString();
            txtFinYear.Tag = clsMethods_GL.getFinancialYear_ID_Current();
            txtFinYear.Text = txtFinYear.Tag.ToString();
            dtpFrom_Date.SetTime(clsMethods_GL.getFinancialYear_StartDate(txtFinYear.Tag.ToString()));
            #endregion

            dtpTo_Date.SetTime(clsSecurity.getServerDateTime());
            string sPCAccName = "";
            var oPCAccounts = tbl_pcbMasAccount.SelectAllByAssignedUser_ID(clsSecurity.UserIDLoged).FirstOrDefault();
            if (oPCAccounts != null && oPCAccounts.IsCanceled == false)
            {
                slblPCAccID = oPCAccounts.PcbAccount_ID;
                sPCAccName = oPCAccounts.PcbAccountName;
                string sCurreecy = oPCAccounts.Currency_ID;
                dFloatAmnt = oPCAccounts.FloatAmount;
                isViewMode = false;
            }
            else
            {
                SEACCMessageBox.Show("No Account Assigned..", "You do not have an assigned petty cash book account. System will Continue as view mode", MessageBoxButton.OK);
                var oPCAccounts2 = tbl_pcbMasAccount.SelectAll().Where(p => !p.IsCanceled).FirstOrDefault();
                if (oPCAccounts2 != null && oPCAccounts2.IsCanceled == false)
                {
                    slblPCAccID = oPCAccounts2.PcbAccount_ID;
                    sPCAccName = oPCAccounts2.PcbAccountName;
                    string sCurreecy = oPCAccounts2.Currency_ID;
                    dFloatAmnt = oPCAccounts2.FloatAmount;
                }
            }

            lblAmountVal.Content = clsFormatter.FormatDecimalPlaces_Price(dFloatAmnt);

            lblBookBalVal.Content = "0.00";
            lblIOUAmntVal.Content = "0.00";
            lblAvilableBalVal.Content = "0.00";

            chkShowAll.IsChecked = false;

            SEACC_Form.FormName += " - " + sPCAccName;
        }
        #endregion

        #region Refresh Grid
        #region Transaction Grid
        public void RefreshGrid()
        {
            try
            {
                dtPCB.Rows.Clear();
                decimal dBalanceExp = 0;

                #region Fill dgr_PCB

                string sQuary = "exec[sp_getPCB_TXN] '" + dtpFrom_Date.GetDateTime().Date + "','" + dtpTo_Date.GetDateTime().Date + "','" + slblPCAccID + "'";
                dtPCB = (DBHandling.ExecQuery(sQuary).Tables[0]);

                string sFilter = "";
                if (!bShowAll)
                    sFilter = "isCanceled = 0";
                dtPCB.DefaultView.RowFilter = sFilter;

                dgr_PCB.ItemsSource = dtPCB.DefaultView;

                #endregion

                int iRowCountEx = dgr_PCB.Items.Count;
                if (iRowCountEx > 0)
                {
                    object item = dgr_PCB.Items[iRowCountEx - 1];
                    dgr_PCB.SelectedItem = item;
                    dgr_PCB.ScrollIntoView(item);
                }
                SetLabelValue();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Set Label Values
        private void SetLabelValue()
        {
            #region Transaction
            int iRowCountEx = dgr_PCB.Items.Count;
            decimal dAmntEx = 0;
            decimal dAmntIOU = 0;
            if (iRowCountEx > 0)
            {
                dAmntEx = decimal.Parse(dtPCB.Rows[dtPCB.Rows.Count - 1]["BalanceAct"].ToString());
                lblBookBalVal.Content = dtPCB.Rows[dtPCB.Rows.Count - 1]["Balance"].ToString();
            }
            else
            {
                iRowCountEx = 0;
                lblBookBalVal.Content = "0.00";
                dAmntEx = 0;
            }
            #endregion

            #region IOU
            int iRowIOU = dgr_IOU.Items.Count;
            if (iRowIOU > 0)
            {
                dAmntIOU = decimal.Parse(dtIOU.Rows[iRowIOU - 1]["IOUBalanceAct"].ToString());
                lblIOUAmntVal.Content = dtIOU.Rows[iRowIOU - 1]["IOUBalance"].ToString();
            }
            else
            {
                lblIOUAmntVal.Content = "0.00";
                dAmntIOU = 0;
            }
            #endregion

            dAvailableBal = dAmntEx + dAmntIOU;
            lblAvilableBalVal.Content = dAvailableBal < 0 ? clsHelpMethods_PCB.WrapNegatives(dAvailableBal) : clsFormatter.FormatDecimalPlaces_Price(dAvailableBal);
        }
        #endregion

        #region IOU Grid
        public void RefreshGridIOU()
        {
            dtIOU.Rows.Clear();
            decimal dBalanceIOU = 0;

            #region Fill dgr_IOU
            foreach (tbl_pcbTxIOU detail in tbl_pcbTxIOU.SelectAll().Where(p => p.Iou_ID != "default" && !p.IsCanceled && !p.IsSettled && p.PcbAccount_ID == slblPCAccID))
            {
                dBalanceIOU -= (detail.IouAmount - detail.SettledAmount);

                dtIOU.Rows.Add(clsFormatter.FormatDate_Short(detail.IouDate), detail.Iou_ID, detail.Remarks, clsFormatter.FormatDecimalPlaces_Price(detail.IouAmount), clsFormatter.FormatDecimalPlaces_Price(detail.IouAmount - detail.SettledAmount), dBalanceIOU < 0 ? clsHelpMethods_PCB.WrapNegatives(dBalanceIOU) : clsFormatter.FormatDecimalPlaces_Price(dBalanceIOU), clsFormatter.FormatDecimalPlaces_Price(dBalanceIOU));
                dgr_IOU.ItemsSource = dtIOU.DefaultView;
            }
            #endregion

            SetLabelValue();
        }
        #endregion

        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion       

        #region Grid Add Buttons
        private void btnGridAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isViewMode)
            {
                SEACCMessageBox.Show("No Account Assigned..", "You do not have an assigned petty cash book account.", MessageBoxButton.OK);
                return;
            }

            frm_AddExpenditure frm = new frm_AddExpenditure(slblPCAccID, dAvailableBal, isViewMode);
            if (frm.SEACC_Form.PermissionTO_Read)
            {
                frm.Updated += Frm_Expenditure_Updated;
                frm.ShowDialog();
            }
        }

        private void btnGridIOUAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isViewMode)
            {
                SEACCMessageBox.Show("No Account Assigned..", "You do not have an assigned petty cash book account.", MessageBoxButton.OK);
                return;
            }

            frm_AddIOU frm_IOU = new frm_AddIOU(slblPCAccID, isViewMode);
            if (frm_IOU.SEACC_Form.PermissionTO_Read)
            {
                frm_IOU.Updated += Frm_IOU_Updated;
                frm_IOU.ShowDialog();
            }
        }

        private void btnGridRefundAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isViewMode)
            {
                SEACCMessageBox.Show("No Account Assigned..", "You do not have an assigned petty cash book account.", MessageBoxButton.OK);
                return;
            }

            frm_IOURefund frm_Refund = new frm_IOURefund(slblPCAccID);
            if (frm_Refund.SEACC_Form.PermissionTO_Read)
            {
                frm_Refund.Updated += Frm_IOU_Updated;
                frm_Refund.ShowDialog();
            }
        }

        private void btnGridRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshGridIOU();
        }
        #endregion

        #region Date change event
        private void dtpTo_Date_DateTimeChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dtpFrom_Date_DateTimeChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        #endregion

        #region Search Events
        private void txtCurrency_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //frm_search RowDataSearch = new frm_search();
            //RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Currency);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    lblCurrency.Tag = lstResult[0];
            //    lblCurrency.Text = lstResult[1];
            //}
        }
        #endregion

        #region Loading Row
        private void dgr_PCB_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (bShowAll)
            {
                DataRowView item = e.Row.Item as DataRowView;
                if (item != null)
                {
                    if (item.Row["isCanceled"].ToString() == "1")
                        e.Row.Foreground = new SolidColorBrush(Colors.OrangeRed);
                    else
                        e.Row.Foreground = new SolidColorBrush(Colors.White);
                }
            }
        }
        #endregion

        #region Search Events
        private void dgr_PCB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDgv_Cell = dgr_PCB.CurrentCell;
                if (vDgv_Cell.Column != null)
                {
                    if (vDgv_Cell.Column.Header.ToString() == "Txn Code")
                    {
                        DataRowView dataRow = (DataRowView)dgr_PCB.SelectedItem;
                        int index = dgr_PCB.CurrentCell.Column.DisplayIndex;
                        string sTxnCode = dataRow.Row.ItemArray[index].ToString();

                        frm_AddExpenditure frm = new frm_AddExpenditure(slblPCAccID, dAvailableBal, isViewMode);
                        frm.Updated += Frm_Expenditure_Updated;
                        //frm.sPCAccountID = slblPCAccID;
                        frm.fillDetails(sTxnCode);
                        frm.ShowDialog();

                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_IOU_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //if (dgr_IOU.CurrentCell.Column.Header.ToString() == "Txn Code")
                //{
                //    string sTxnCode = dtIOU.Rows[dgr_IOU.SelectedIndex]["IOUTxnCode"].ToString();

                //    frm_AddIOU frm_IOU = new frm_AddIOU(slblPCAccID);
                //    frm_IOU.Updated += Frm_IOU_Updated;
                //    frm_IOU.fillDetails(sTxnCode);
                //    frm_IOU.ShowDialog();
                //}

                var vDgv_Cell = dgr_IOU.CurrentCell;
                if (vDgv_Cell.Column != null)
                {
                    if (vDgv_Cell.Column.Header.ToString() == "Txn Code")
                    {
                        DataRowView dataRow = (DataRowView)dgr_IOU.SelectedItem;
                        int index = dgr_IOU.CurrentCell.Column.DisplayIndex;
                        string sTxnCode = dataRow.Row.ItemArray[index].ToString();

                        frm_AddIOU frm_IOU = new frm_AddIOU(slblPCAccID, isViewMode);
                        frm_IOU.Updated += Frm_IOU_Updated;
                        frm_IOU.fillDetails(sTxnCode);
                        frm_IOU.ShowDialog();

                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        private void Frm_IOU_Updated(object sender, EventArgs e)
        {
            RefreshGridIOU();
        }

        private void Frm_Expenditure_Updated(object sender, EventArgs e)
        {
            RefreshGrid();
            RefreshGridIOU();
        }

        #region Check Events
        private void chkShowAll_Checked(object sender, RoutedEventArgs e)
        {
            bShowAll = true;
            string sFilter = "";
            dtPCB.DefaultView.RowFilter = sFilter;
            dgr_PCB.ItemsSource = dtPCB.DefaultView;

            int iRowCountEx = dgr_PCB.Items.Count;
            if (iRowCountEx > 0)
            {
                object item = dgr_PCB.Items[iRowCountEx - 1];
                dgr_PCB.SelectedItem = item;
                dgr_PCB.ScrollIntoView(item);
            }
        }

        private void chkShowAll_Unchecked(object sender, RoutedEventArgs e)
        {
            bShowAll = false;
            string sFilter = "isCanceled = 0";
            dtPCB.DefaultView.RowFilter = sFilter;
            dgr_PCB.ItemsSource = dtPCB.DefaultView;

            int iRowCountEx = dgr_PCB.Items.Count;
            if (iRowCountEx > 0)
            {
                object item = dgr_PCB.Items[iRowCountEx - 1];
                dgr_PCB.SelectedItem = item;
                dgr_PCB.ScrollIntoView(item);
            }
        }
        #endregion

        private void btnReimbursment_Click(object sender, RoutedEventArgs e)
        {
            if (isViewMode)
            {
                SEACCMessageBox.Show("No Account Assigned..", "You do not have an assigned petty cash book account.", MessageBoxButton.OK);
                return;
            }
            decimal FloatAmount = 0;
            decimal BookBalance = 0;
            decimal IOUAmount = 0;
            decimal AvailableBalance = 0;

            decimal.TryParse(lblAmountVal.Content.ToString(), out FloatAmount);
            decimal.TryParse(lblBookBalVal.Content.ToString(), out BookBalance);
            decimal.TryParse(lblIOUAmntVal.Content.ToString().Replace("(","").Replace(")",""), out IOUAmount);
            decimal.TryParse(lblAvilableBalVal.Content.ToString(), out AvailableBalance);

            frm_ReimbursmentReq frm = new frm_ReimbursmentReq(FloatAmount, BookBalance, IOUAmount, AvailableBalance);
            frm.ShowDialog();
        }
    }
}