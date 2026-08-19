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
    /// Interaction logic for UC_Documents.xaml
    /// </summary>
    public partial class UC_Documents : UserControl
    {
        public UC_Documents()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Documents;
            SEACC_Form.Initialize();

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("Doc_TypeID");
            dgr_Main.dt.Columns.Add("DocName");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Document Type ID", "Doc_TypeID", 100);
            dgr_Main.Add_DatagridColoumn("Document Name", "DocName", 200);
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtDocTypeID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDocName, true, false, false);

            txtDocTypeID.Text = "";
            txtDocName.Text = "";
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                dgr_Main.dt = DBHandling.ExecQuery("Exec sp_GetDocumentTypeList").Tables[0];
                if (dgr_Main.dt != null && dgr_Main.dt.Rows.Count > 0)
                {
                    dgr_Main.RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtDocTypeID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDocName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_zDocument oDetail = tbl_zDocument.Select(txtDocTypeID.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
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
                    tbl_zDocument details = tbl_zDocument.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtDocTypeID.IsEnabled = false;
                        txtDocTypeID.Text = details.DocType_ID;
                        txtDocName.Text = details.DocName;
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    object item = dgr_Main.grdMain.SelectedItem;
            //    if (item != null)
            //    {
            //        string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            //        fillDetails(GridID);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            //}
        } 
        #endregion

    }
}
