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
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;


namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_RecuirtmentType.xaml
    /// </summary>
    public partial class UC_RecuirtmentType : UserControl
    {
        #region Form Load
        public UC_RecuirtmentType()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Recruitment_Type_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("RCode");
            dgr_Main.dt.Columns.Add("RName"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Code", "RCode", 60, false);
            dgr_Main.Add_DatagridColoumn("Name", "RName", 450); 
            #endregion
        
            ClearFields();
            RefershGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        } 
        #endregion

        #region Action Button
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtRecuirtCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_hrMasRecuirtmentType detail = tbl_hrMasRecuirtmentType.Select(txtRecuirtCode.Text);
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                RefershGrid();
                                ClearFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_hrMasRecuirtmentType OldRecord = tbl_hrMasRecuirtmentType.Select(txtRecuirtCode.Text);
                            if (OldRecord != null)
                            {
                                tbl_hrMasRecuirtmentType oRecType = new tbl_hrMasRecuirtmentType(txtRecuirtCode.Text, txtRecuirtType.Text, OldRecord.IsCanceled, OldRecord.UserID_Created, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Canceled, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
                                oRecType.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    } 
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtRecuirtCode.Text = SEACC_Form.getAutoGeneratedCode();
                        tbl_hrMasRecuirtmentType ORecType = new tbl_hrMasRecuirtmentType(txtRecuirtCode.Text, txtRecuirtType.Text, false, clsSecurity.UserIDLoged, clsSecurity.TerminalID, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        ORecType.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);

                    } 
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefershGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRecuirtCode, true, false,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRecuirtType, true, false,false);

            txtRecuirtCode.Text = "";
            txtRecuirtCode.Tag = null;
            txtRecuirtType.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtRecuirtCode.setReadOnlyStatus(true);
                txtRecuirtCode.Text = "<Auto Generate>";
            }
            else
                txtRecuirtCode.setReadOnlyStatus(false);
        }
        #endregion

        #region Refersh Grid
        private void RefershGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_hrMasRecuirtmentType detail in tbl_hrMasRecuirtmentType.SelectAll().Where(p => p.IsCanceled == false && p.RecuirtmentType_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(detail.RecuirtmentType_ID, detail.RecuirtmentType);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            if (!ChekValidity_DuplicateNames())
                bStatus = false;
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

           if (!clsValidation.Validate_EmptyValue(txtRecuirtCode))
                bStatus = false;
           if (!clsValidation.Validate_EmptyValue(txtRecuirtType))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {

            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrMasRecuirtmentType oDetail = tbl_hrMasRecuirtmentType.Select(txtRecuirtCode.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                }
            }
            return bStatus;

        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_hrMasRecuirtmentType detail1 in tbl_hrMasRecuirtmentType.SelectAll().Where(p => p.RecuirtmentType == txtRecuirtType.Text && p.IsCanceled ==false && p.RecuirtmentType_ID != txtRecuirtCode.Text))
            {
                if (detail1 != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                    break;
                }
            }
            return bStatus;
        }

        #endregion
   
        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_hrMasRecuirtmentType detail = tbl_hrMasRecuirtmentType.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtRecuirtCode.IsEnabled = false;
                        txtRecuirtCode.Text = detail.RecuirtmentType_ID;
                        txtRecuirtCode.Tag = detail.RecuirtmentType_ID;
                        txtRecuirtType.Text = detail.RecuirtmentType;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion
                
        #region Search Event
        private void txtRecuirtCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void txtRecuirtType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.RecruitmentTypes);
            if (RowDataSearch.DialogResult == true)
            {
                txtRecuirtCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Grid Event
        private void grd_RecType_MouseLeftButtonUp1(object sender, EventArgs e)
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
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        
    }
}
