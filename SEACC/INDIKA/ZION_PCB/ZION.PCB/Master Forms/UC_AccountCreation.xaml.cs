using DataTire;
using Digiteq_Logic;
using ZION.PCB.Search;
using SEACC_WPFControls;
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

namespace ZION.PCB
{
    /// <summary>
    /// Interaction logic for UC_AccountCreation.xaml
    /// </summary>
    public partial class UC_AccountCreation : UserControl
    {
        #region Form Load
        public UC_AccountCreation()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_PettyCashAccCreation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("AccCode");
            dgr_Main.dt.Columns.Add("AccName");
            dgr_Main.dt.Columns.Add("User");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("P.C. Acc.", "AccCode", 90);
            dgr_Main.Add_DatagridColoumn("Name", "AccName", 250);
            dgr_Main.Add_DatagridColoumn("User", "User", 120);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
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
            if (CheckValidity())
            {
                if (txtCurrency.Tag == null)
                    txtCurrency.Tag = "CUR/048";
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                          //  List<tbl_pcbTxReimbursment> oReimbursment = tbl_pcbTxReimbursment.SelectAllByPcbAccount_ID(txtPCAccountCode.Tag.ToString()).Where(p => !p.IsCanceled).ToList();
                         //   if (oReimbursment.Count == 0)
                            {
                                tbl_pcbMasAccount oOldAcc = tbl_pcbMasAccount.Select(txtPCAccountCode.Tag.ToString());
                                if (oOldAcc != null)
                                {
                                    if (!oOldAcc.IsCanceled)
                                    {
                                        tbl_pcbMasAccount oAcc = new tbl_pcbMasAccount(txtPCAccountCode.Tag.ToString(), txtPCAcountName.Text, txtUser.Tag.ToString(), txtCurrency.Tag.ToString(), decimal.Parse(txtFloatAmount.Text), txtRemarks.Text, txtMainAcount.Tag.ToString(), oOldAcc.Prefix, oOldAcc.IsCanceled, oOldAcc.CreateUser_ID, clsSecurity.UserIDLoged, oOldAcc.CanceldUser_ID, oOldAcc.DateCreate, clsSecurity.getServerDateTime(), oOldAcc.DateCanceled, oOldAcc.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldAcc.CanceledUserTerminal_ID, oOldAcc.Counter);
                                        oAcc.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                        SEACCMessageBox.Show("Can not Update..", "This Account is already cancelled", MessageBoxButton.OK);
                                }
                            }
                          //  else
                         //       SEACCMessageBox.Show("Can not Update..", "", MessageBoxButton.OK);
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            if (SEACC_Form.isAutoGenaratedCode)
                                txtPCAccountCode.Tag = SEACC_Form.getAutoGeneratedCode();

                            tbl_pcbMasAccount oNewAcc = new tbl_pcbMasAccount(txtPCAccountCode.Tag.ToString(), txtPCAcountName.Text, txtUser.Tag.ToString(), txtCurrency.Tag.ToString(), decimal.Parse(txtFloatAmount.Text), txtRemarks.Text, txtMainAcount.Tag.ToString(), "", false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default",0);
                            oNewAcc.Insert();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                    //fillDetails(txtPCAccountCode.Tag.ToString());
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtPCAccountCode.Tag != null)
                    {
                        List<tbl_pcbTxExpenditure> oExp = tbl_pcbTxExpenditure.SelectAllByPcbAccount_ID(txtPCAccountCode.Tag.ToString()).ToList();
                        if (oExp.Count > 0)
                        {
                            SEACCMessageBox.Show("Record Locked", "", MessageBoxButton.OK, "Red");
                        }

                        else
                        {
                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                            if (bMessegeBoxResult)
                            {
                                tbl_pcbMasAccount Details = tbl_pcbMasAccount.Select(txtPCAccountCode.Tag.ToString());
                                if (Details != null)
                                {
                                    Details.IsCanceled = true;
                                    Details.DateCanceled = clsSecurity.getServerDateTime();
                                    Details.CanceldUser_ID = clsSecurity.UserIDLoged;
                                    Details.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                    Details.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                    ClearFields();
                                    RefreshGrid();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Check validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (ChekValidity_DuplicateNames())
                {
                    if (ChekValidity_Amount())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyValue(txtMainAcount))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPCAcountName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUser))
                bStatus = false;            
            
            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtPCAccountCode.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtPCAccountCode.Text = txtPCAccountCode.Tag.ToString();
                }               
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_pcbMasAccount oDept in tbl_pcbMasAccount.SelectAll().Where(p => p.PcbAccountName == txtPCAcountName.Text && p.PcbAccount_ID != txtPCAccountCode.Text))
            {
                bStatus = false;
                //SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                SEACCMessageBox.Show("Can not Add..",  txtPCAcountName.Text + " : This Account Name is already exist", MessageBoxButton.OK);
                break;
            }
            return bStatus;
        }

        public bool ChekValidity_Amount()
        {
            bool bStatus = true;
            if (decimal.Parse(txtFloatAmount.Text) == 0)
            {
                bStatus = false;
                SEACCMessageBox.Show("", "Float amount should be greater than 0", MessageBoxButton.OK);
            }

            return bStatus;
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPCAccountCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPCAcountName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUser, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMainAcount, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCurrency, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFloatAmount, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtPCAccountCode.Tag = null;
            txtUser.Tag = null;
            txtMainAcount.Tag = null;
            txtCurrency.Tag = null;

            txtPCAccountCode.Text = "";
            txtPCAcountName.Text = "";
            txtUser.Text = "";
            txtMainAcount.Text = "";            
            txtCurrency.Text = "";
            txtFloatAmount.Text = "0.00";
            txtRemarks.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtPCAccountCode.setReadOnlyStatus(true);
                txtPCAccountCode.Text = "<Auto Generate>";
            }
            else
                txtPCAccountCode.setReadOnlyStatus(false);

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_pcbMasAccount detail in tbl_pcbMasAccount.SelectAll().Where(p => p.PcbAccount_ID != "default" && !p.IsCanceled))
                {
                    dgr_Main.dt.Rows.Add(detail.PcbAccount_ID, detail.PcbAccountName, clsGenaralName.getName_User(detail.AssignedUser_ID));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_pcbMasAccount detail = tbl_pcbMasAccount.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPCAccountCode, false, false, false);
                        cls_Formater.SetEnableDisable_LableTextbox(txtFloatAmount, true, true, false);

                        txtPCAccountCode.Text = detail.PcbAccount_ID;
                        txtPCAccountCode.Tag = detail.PcbAccount_ID;
                        txtPCAcountName.Text = detail.PcbAccountName;

                        txtUser.Tag = detail.AssignedUser_ID;
                        txtUser.Text = clsGenaralName.getName_User(detail.AssignedUser_ID);
                        txtCurrency.Tag = detail.Currency_ID;
                        txtCurrency.Text = clsGenaralName.getName_Currency(detail.Currency_ID);
                        txtFloatAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.FloatAmount).ToString();
                        txtRemarks.Text = detail.Remarks;
                        txtMainAcount.Tag = detail.Gl_ID;
                        txtMainAcount.Text = clsGenaralName.getName_AccountName(detail.Gl_ID);

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion       

        #region Search Events

        private void txtPCAccountCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_PCAccount);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
            }
        }

        private void txtMainAcount_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.AccName);
            if (RowDataSearch.DialogResult == true)
            {
                txtMainAcount.Tag = lstResult[0];
                txtMainAcount.Text = lstResult[1];
            }
        }
       
        private void txtUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                List<tbl_pcbMasAccount> oPCAcc = tbl_pcbMasAccount.SelectAllByAssignedUser_ID(lstResult[0]).Where(p=> !p.IsCanceled).ToList();
                if (oPCAcc.Count == 0)
                {
                    txtUser.Tag = lstResult[0];
                    txtUser.Text = lstResult[1];
                }
                else
                {
                    SEACCMessageBox.Show("Already Assigned", "Please select another User", MessageBoxButton.OK);
                }
            }
        }        

        private void txtCurrency_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Currency);
            if (RowDataSearch.DialogResult == true)
            {
                txtCurrency.Tag = lstResult[0];
                txtCurrency.Text = lstResult[1];
            }
        }

        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        
    }
}
