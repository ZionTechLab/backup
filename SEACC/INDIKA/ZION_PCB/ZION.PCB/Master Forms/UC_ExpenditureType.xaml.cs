using DataTire;
using Digiteq_Logic;
using ZION.PCB.Search;
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

namespace ZION.PCB
{
    /// <summary>
    /// Interaction logic for UC_ExpenditureType.xaml
    /// </summary>
    public partial class UC_ExpenditureType : UserControl
    {
        #region Class Variables
        DataTable dtTypes = new DataTable();
        DataTable dtCat = new DataTable();
        int iRowExpType = -1;    
        #endregion

        #region Form Load
        public UC_ExpenditureType()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_ExpenditureType;

            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ExpTypeID");
            dgr_Main.dt.Columns.Add("ExpTypeDes");
            dgr_Main.dt.Columns.Add("ExpCatID");
            dgr_Main.dt.Columns.Add("ExpCatDes");

            #region Exp Type Data Table
            dtTypes.Columns.Add("TypeID");
            dtTypes.Columns.Add("GLID");
            dtTypes.Columns.Add("TypeDes");
            #endregion

            #region Exp Category Data Table
            dtCat.Columns.Add("CatID");
            dtCat.Columns.Add("CatDes");
            #endregion

            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Type ID", "ExpTypeID", 90);
            dgr_Main.Add_DatagridColoumn("Exp. Description", "ExpTypeDes", 200);
            dgr_Main.Add_DatagridColoumn("Category ID", "ExpCatID", 90);
            dgr_Main.Add_DatagridColoumn("Cat. Description", "ExpCatDes", 200);
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

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Check validity

        private bool CheckValidity(string sExCatName)
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField(sExCatName))
            {
                if (ChekValidity_DuplicateNames(sExCatName))
                    bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField(string sExCatName)
        {
            bool bStatus = true;

            if (!Validate_EmptyValues(sExCatName))
                bStatus = false;

            return bStatus;
        }

        private bool Validate_EmptyValues(string sExCatName)
        {
            bool bStatus = true;
            if (sExCatName == "")
            {
                bStatus = false;
                SEACCMessageBox.Show("Empty Values !!", "Can not Insert empty values", MessageBoxButton.OK);
            }

            return bStatus;
        }

        public bool ChekValidity_DuplicateNames(string sExCatName)
        {
            bool bStatus = true;
            foreach (tbl_pcbRefExpenditureCategory oDept in tbl_pcbRefExpenditureCategory.SelectAll().Where(p => p.PcbExpenditureCategoryName == sExCatName))
            {
                bStatus = false;
                SEACCMessageBox.Show("Already Exist !!", "Can not Insert duplicate values", MessageBoxButton.OK);
                break;
            }
            return bStatus;
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;       
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                string sCatID = "";
                string sCatName = "";
                bool bAdd = true;

                dgr_Main.dt.Clear();
                dtTypes.Rows.Clear();

                foreach (tbl_pcbRefExpenditureType detail in tbl_pcbRefExpenditureType.SelectAll().Where(p => p.PcbExpenditureType_ID != "default" && !p.IsCanceled))
                {
                    bAdd = true;
                    foreach (tbl_pcbRefExpenditureCategory detailCat in tbl_pcbRefExpenditureCategory.SelectAll().Where(p => p.PcbExpenditureCategory_ID != "default" && !p.IsCanceled && p.PcbExpenditureType_ID == detail.PcbExpenditureType_ID))
                    {
                        sCatID = detailCat.PcbExpenditureCategory_ID;
                        sCatName = detailCat.PcbExpenditureCategoryName;

                        dgr_Main.dt.Rows.Add(detail.PcbExpenditureType_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), sCatID, sCatName);                        
                        bAdd = false;
                    }

                    if (bAdd)
                    {
                        dgr_Main.dt.Rows.Add(detail.PcbExpenditureType_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), "", "");
                        sCatID = "";
                    }
                }
                dgr_Main.RefreshGrid();

                foreach (tbl_pcbRefExpenditureType detail in tbl_pcbRefExpenditureType.SelectAll().Where(p => p.PcbExpenditureType_ID != "default" && !p.IsCanceled))
                {
                    dtTypes.Rows.Add(detail.PcbExpenditureType_ID, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID));
                    dgr_ExpType.ItemsSource = dtTypes.DefaultView;
                }
                
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Fill Ex. Category Grid
        private void dgr_ExpType_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            iRowExpType = dgr_ExpType.SelectedIndex;
            string sTypeID = dtTypes.Rows[iRowExpType]["TypeID"].ToString();

            dtCat.Clear();

            foreach (tbl_pcbRefExpenditureCategory detail in tbl_pcbRefExpenditureCategory.SelectAll().Where(p => p.PcbExpenditureCategory_ID != "default" && !p.IsCanceled && p.PcbExpenditureType_ID == sTypeID))
            {
                dtCat.Rows.Add(detail.PcbExpenditureCategory_ID, detail.PcbExpenditureCategoryName);
            }
            dgr_ExpCat.ItemsSource = dtCat.DefaultView;
        }
        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
           
        }
        #endregion        

        #region Search Events
        private void txtExpenditureID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtGLCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

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

        #region Grid Add Button
        private void btnGridAdd_Click(object sender, RoutedEventArgs e)
        {
            string sExType = "";

            frm_search RowDataSearch = new frm_search(false);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.AccName);
            if (RowDataSearch.DialogResult == true)
            {
                try
                {
                    bool bAddItem = false;
                    DataRow[] items = dtTypes.Select("GLID ='" + lstResult[0] + "'");
                    if (items.Length == 0)
                        bAddItem = true;
                    else
                    {
                        string sGLCode = items[0]["GLID"].ToString();
                    }

                    if (bAddItem)
                    {
                        tbl_accGLMaster oGL = tbl_accGLMaster.Select(lstResult[0]);
                        if (oGL != null)
                        {
                            //dtTypes.Rows.Add(sExType, oGL.Gl_ID, oGL.GlName);
                            //dgr_ExpType.ItemsSource = dtTypes.DefaultView;

                            //Insert
                            if (SEACC_Form.CheckPermission_ToSave(false))
                            {
                                sExType = SEACC_Form.getAutoGeneratedCode();
                                tbl_pcbRefExpenditureType oNewExType = new tbl_pcbRefExpenditureType(sExType, oGL.Gl_ID, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default");
                                oNewExType.Insert();
                            }

                            RefreshGrid();

                        }
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                    SEACCExeption.Show(ex);
                }
            }
        }

        private void btnGridAddCat_Click(object sender, RoutedEventArgs e)
        {
            if (iRowExpType == -1)
                SEACCMessageBox.Show("", "Please select an Expenditure Type", MessageBoxButton.OK);
            else
            {                
                dtCat.Rows.Add("", "");
            }

        }
        #endregion

        #region Grid Delete button
        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_ExpType.SelectedItem;
            if (selectedItem != null)
            {
                string sTypeID = (dgr_ExpType.SelectedCells[1].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] types = dtTypes.Select("TypeID ='" + sTypeID + "'");
                if (types.Length > 0)
                {
                    List<tbl_pcbRefExpenditureCategory> oCat = tbl_pcbRefExpenditureCategory.SelectAllByPcbExpenditureType_ID(sTypeID).ToList();
                    if (oCat.Count > 0)
                    {
                        SEACCMessageBox.Show("Can not Delete !!", "Expenditure Categories are Added for this Type", MessageBoxButton.OK);
                    }

                    else
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            foreach (DataRow type in types)
                            {
                                tbl_pcbRefExpenditureType oType = tbl_pcbRefExpenditureType.Select(sTypeID);
                                oType.IsCanceled = true;
                                oType.CanceldUser_ID = clsSecurity.UserIDLoged;
                                oType.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                oType.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);

                                dtTypes.Rows.Remove(type);
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
        }

        private void btnGridItemDeleteCat_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_ExpCat.SelectedItem;
            if (selectedItem != null)
            {
                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                if (bMessegeBoxResult)
                {
                    string sCatID = (dgr_ExpCat.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                    DataRow[] categories = dtCat.Select("CatID ='" + sCatID + "'");
                    if (categories.Length > 0)
                    {
                        List<tbl_pcbTxExpenditure_Detail> oCat = tbl_pcbTxExpenditure_Detail.SelectAll().Where(p=> p.PcbExpenditureCategory_ID == sCatID).ToList();
                        if (oCat.Count > 0)
                        {
                            SEACCMessageBox.Show("Can not Delete !!", "Trancactions are Added for this Expenditure Category", MessageBoxButton.OK);
                        }

                        else
                        {
                            foreach (DataRow category in categories)
                            {
                                if (sCatID != "")
                                {
                                    tbl_pcbRefExpenditureCategory oType = tbl_pcbRefExpenditureCategory.Select(sCatID);
                                    oType.IsCanceled = true;
                                    oType.CanceldUser_ID = clsSecurity.UserIDLoged;
                                    oType.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                    oType.Update();
                                }

                                dtCat.Rows.Remove(category);
                                RefreshGrid();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #endregion        

        #region Insert - Ex. Category
        private void dgr_ExpCat_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int irowID = dgr_ExpCat.SelectedIndex;
                string sColoumn = e.Column.Header.ToString();

                string sCatID = "", sCatName = "", sTypeID = "";

                sTypeID = dtTypes.Rows[iRowExpType]["TypeID"].ToString();
                sCatID = dtCat.Rows[irowID]["CatID"].ToString();
                sCatName = dtCat.Rows[irowID]["CatDes"].ToString();

                if (CheckValidity(sCatName))
                {
                    tbl_pcbRefExpenditureCategory oOldCat = tbl_pcbRefExpenditureCategory.Select(sCatID);
                    #region Update
                    if (oOldCat != null)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_pcbRefExpenditureCategory oCat = new tbl_pcbRefExpenditureCategory(sCatID, sTypeID, sCatName, oOldCat.IsCanceled, oOldCat.CreateUser_ID, clsSecurity.UserIDLoged, oOldCat.CanceldUser_ID, oOldCat.DateCreate, clsSecurity.getServerDateTime(), oOldCat.DateCanceled, oOldCat.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldCat.CanceledUserTerminal_ID);
                            oCat.Update();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                        }
                    }

                    #endregion
                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            SEACC_Form.enmFormName = FormName.PCB_ExpenditureCategory;

                            string sExCat = "";
                            sExCat = SEACC_Form.getAutoGeneratedCode();

                            tbl_pcbRefExpenditureCategory oNewExCat = new tbl_pcbRefExpenditureCategory(sExCat, sTypeID, sCatName, false, clsSecurity.UserIDLoged, "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default");
                            oNewExCat.Insert();

                            SEACC_Form.enmFormName = FormName.PCB_ExpenditureType;

                            RefreshGrid();
                            dtCat.Clear();
                            foreach (tbl_pcbRefExpenditureCategory detail in tbl_pcbRefExpenditureCategory.SelectAll().Where(p => p.PcbExpenditureCategory_ID != "default" && !p.IsCanceled && p.PcbExpenditureType_ID == sTypeID))
                            {
                                dtCat.Rows.Add(detail.PcbExpenditureCategory_ID, detail.PcbExpenditureCategoryName);
                            }
                            dgr_ExpCat.ItemsSource = dtCat.DefaultView;
                        }
                    }
                    #endregion
                }
                else
                    dtCat.Rows.RemoveAt(irowID);
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
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

        private void dgr_ExpType_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void dgr_ExpType_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void dgr_ExpCat_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        

        
    }
}
