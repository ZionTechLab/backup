using DataTire;
using Digiteq_Logic;
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

namespace Digiteq.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_SecurityReportMaster.xaml
    /// </summary>
    public partial class UC_SecurityReportMaster : UserControl
    {
        #region Form Load
        public UC_SecurityReportMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Security_Report;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data table
            dgr_Main.dt.Columns.Add("ReportID");
            dgr_Main.dt.Columns.Add("ReportName");
            dgr_Main.dt.Columns.Add("ReportCategoryID");
            dgr_Main.dt.Columns.Add("ReportPath"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("#", "ReportID", 40);
            dgr_Main.Add_DatagridColoumn("Report Name", "ReportName", 250);
            dgr_Main.Add_DatagridColoumn("Report Cat ID", "ReportCategoryID", 90, false);
            dgr_Main.Add_DatagridColoumn("Report Path", "ReportPath", 350); 
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Variables
                    bool bEnable = false;
                    bool bSetPaper = false;
                    bool bSetPrinter = false;
                    bool bSetUser = false;
                    bool bSetTerminal = false;
                    bool bSetDefaultPrinter = false;

                    if (chk_isEnable.IsChecked == true)
                    {
                        bEnable = true;
                    }
                    if (chk_isSetPaper.IsChecked == true)
                    {
                        bSetPaper = true;
                    }
                    if (chk_isSetPrinter.IsChecked == true)
                    {
                        bSetPrinter = true;
                    }
                    if (chk_isSetUser.IsChecked == true)
                    {
                        bSetUser = true;
                    }
                    if (chk_isSetTerminal.IsChecked == true)
                    {
                        bSetTerminal = true;
                    }
                    if (chk_isDefaultPrinter.IsChecked == true)
                    {
                        bSetDefaultPrinter = true;
                    }
                    #endregion

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            //tbl_securityReportMaster oldRecord = tbl_securityReportMaster.Select(int.Parse(txtReportID.Text.Trim()));
                            //if (oldRecord != null)
                            //{
                            //    tbl_securityReportMaster OFormMaster = new tbl_securityReportMaster(int.Parse(txtReportID.Text), int.Parse(txtSortOrder.Text), txtReportName.Text, txtReportCategoryID.Text, txtDisplayName.Text, txtDisplayName2.Text, txtReportPath.Text, bEnable, bSetPaper, bSetPrinter, bSetTerminal, bSetUser, bSetDefaultPrinter, int.Parse(txtPrintCount.Text)); 
                            //    OFormMaster.Update();
                            //    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            //}
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        //tbl_securityReportMaster OFormMaster = new tbl_securityReportMaster(int.Parse(txtReportID.Text), int.Parse(txtSortOrder.Text), txtReportName.Text, txtReportCategoryID.Text, txtDisplayName.Text, txtDisplayName2.Text, txtReportPath.Text, bEnable, bSetPaper, bSetPrinter, bSetTerminal, bSetUser, bSetDefaultPrinter, int.Parse(txtPrintCount.Text)); 
                        //OFormMaster.Insert();
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
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtReportID, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReportName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSortOrder, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReportCategoryID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDisplayName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDisplayName2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReportPath, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrintCount, true, true, false);

            txtReportID.Text = "";
            txtReportName.Text = "";
            txtSortOrder.Text = "";
            txtDisplayName.Text = "";
            txtReportCategoryID.Text = "";
            txtDisplayName.Text = "";
            txtDisplayName2.Text = "";
            txtReportPath.Text = "";
            txtPrintCount.Text = "";

            chk_isEnable.IsChecked = false;
            chk_isSetPaper.IsChecked = false;
            chk_isSetPrinter.IsChecked = false;
            chk_isSetTerminal.IsChecked = false;
            chk_isSetUser.IsChecked = false;
            chk_isDefaultPrinter.IsChecked = false;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                //foreach (tbl_securityReportMaster oUser in tbl_securityReportMaster.SelectAll())
                //{
                //    dgr_Main.dt.Rows.Add(oUser.Report_ID, oUser.ReportName, oUser.ReportCategory_ID, oUser.ReportPath);
                //}
                
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
                if (CheckValidity_DuplicateRecords())
                {
                    if (CheckValidity_DuplicateFormName())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtReportID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtReportName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSortOrder))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDisplayName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDisplayName2))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtReportCategoryID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtReportPath))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPrintCount))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateRecords()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                //tbl_securityReportMaster oDetail = tbl_securityReportMaster.Select(int.Parse(txtReportID.Text));
                //if (oDetail != null)
                //{
                //    bStatus = false;
                //    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                //}
            }
            return bStatus;
        }

        public bool CheckValidity_DuplicateFormName()
        {
            bool bStatus = true;
           // foreach (tbl_securityFormMaster detail in tbl_securityFormMaster.SelectAll().Where(p => p.FormName == txtReportName.Text && p.Form_ID != int.Parse(txtReportID.Text)))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist, "Report Name");
              //  break;
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(int sID)
        {
            try
            {
                if (sID != null)
                {
                    //tbl_securityReportMaster Ouser = tbl_securityReportMaster.Select(sID);
                  //  if (Ouser != null)
                    {
                        //SEACC_Form.IsUpdateMode = true;
                        //txtReportID.IsEnabled = false;
                        //txtReportID.Text = Ouser.Report_ID.ToString();
                        //txtReportName.Text = Ouser.ReportName;
                        //txtReportCategoryID.Text = Ouser.ReportCategory_ID;
                        //txtDisplayName.Text = Ouser.DisplayName;
                        //txtDisplayName2.Text = Ouser.DisplayName2;
                        //txtSortOrder.Text = Ouser.SortOrder.ToString();
                        //txtReportPath.Text = Ouser.ReportPath;
                        //txtPrintCount.Text = Ouser.PrintCount.ToString();

                        //if (Ouser.IsSetPaper == true)
                        //{
                        //    chk_isSetPaper.IsChecked = true;
                        //}
                        //else
                        //{
                        //    chk_isSetPaper.IsChecked = false;
                        //}

                        //if (Ouser.IsSetPrinter == true)
                        //{
                        //    chk_isSetPrinter.IsChecked = true;
                        //}
                        //else
                        //{
                        //    chk_isSetPrinter.IsChecked = false;
                        //}

                        //if (Ouser.IsEnable == true)
                        //{
                        //    chk_isEnable.IsChecked = true;
                        //}
                        //else
                        //{
                        //    chk_isEnable.IsChecked = false;
                        //}

                        //if (Ouser.IsSetTerminal == true)
                        //{
                        //    chk_isSetTerminal.IsChecked = true;
                        //}
                        //else
                        //{
                        //    chk_isSetTerminal.IsChecked = false;
                        //}

                        //if (Ouser.IsDefaultPrinter == true)
                        //{
                        //    chk_isDefaultPrinter.IsChecked = true;
                        //}
                        //else
                        //{
                        //    chk_isDefaultPrinter.IsChecked = false;
                        //}

                        //if (Ouser.IsDefaultPrinter == true)
                        //{
                        //    chk_isDefaultPrinter.IsChecked = true;
                        //}
                        //else
                        //{
                        //    chk_isDefaultPrinter.IsChecked = false;
                        //}

                        //if (Ouser.IsSetUser == true)
                        //{
                        //    chk_isSetUser.IsChecked = true;
                        //}
                        //else
                        //{
                        //    chk_isSetUser.IsChecked = false;
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(int.Parse(GridID));
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtReportID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
          //  List<string> lstResult = RowDataSearch.Show(Search.SecurityReports);
            if (RowDataSearch.DialogResult == true)
            {
           //     txtReportID.Text = lstResult[0];
            //    fillDetails(int.Parse(lstResult[0]));
            }
        }
        #endregion
    }
}
