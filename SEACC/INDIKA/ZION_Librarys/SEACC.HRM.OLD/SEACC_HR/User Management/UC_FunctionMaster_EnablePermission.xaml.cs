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
using SEACC_WPFControls;
using DataTire;
using System.IO;
using Microsoft.Win32;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_UserPermission.xaml
    /// </summary>
    public partial class UC_FunctionMaster_EnablePermission : UserControl
    {
        #region Form Load
        public UC_FunctionMaster_EnablePermission()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Function_Master;
            SEACC_Form.Initialize();

            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;

            ClearFields();

            #region Data Grid Initialize
            dgr_Main.dt.Columns.Add("function_ID", typeof(int));
            dgr_Main.dt.Columns.Add("function_Code", typeof(int));
            dgr_Main.dt.Columns.Add("functionName");
            dgr_Main.dt.Columns.Add("functionCategory_ID");
            dgr_Main.dt.Columns.Add("isEnable", typeof(bool));
            dgr_Main.dt.Columns.Add("isReport", typeof(bool));

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "#", "function_ID", 40, true, false);
            dgr_Main.Add_DatagridColoumn("Report / Form Name", "functionName", 250);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Enable", "isEnable", 55, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Report", "isReport", 55, true, false); 
            #endregion
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(450);
        }
        #endregion

        #region Action Buttons
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    int function_ID = int.Parse((row["function_ID"].ToString()));
                    bool bIsEnable = bool.Parse(row["isEnable"].ToString());
                    bool bIsReport = bool.Parse(row["isReport"].ToString());

                    tbl_securityFunctionMaster oldRecord = tbl_securityFunctionMaster.Select(function_ID);
                    if (oldRecord != null)
                    {
                        oldRecord.IsEnable = bIsEnable;
                        oldRecord.IsReport = bIsReport;
                        oldRecord.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                RefreshGrid(txtCategory.Tag.ToString());
            }
        }
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            if (txtCategory.Tag != null)
                RefreshGrid(txtCategory.Tag.ToString());
            else
                RefreshGrid("%");
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);
            txtCategory.Text = "";
            txtCategory.Tag = null;

            chk_ReportAll.IsChecked = false;
            chk_EnableAll.IsChecked = false;

            dgr_Main.dt.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string functionCategoryID)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                dgr_Main.dt.Clear();
                dgr_Main.dt = DBHandling.ExecQuery("Exec sp_securityFunction_MasterSetup '" + functionCategoryID + "'").Tables[0];
                if (dgr_Main.dt != null && dgr_Main.dt.Rows.Count > 0)
                {
                    dgr_Main.RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region Search Events
        private void txtCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch(true);
            List<string> lstResult = RowDataSearch.Show(Search.FunctionCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtCategory.Text = lstResult[1];
                txtCategory.Tag = lstResult[0];
            }
        }
        #endregion

        #region Grid Mouse Click Event
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            #region Checkboxs update
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Enable")
                {
                    dgr_Main.dt.Rows[irowID]["Enable"] = dgr_Main.dt.Rows[irowID]["Enable"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "Report")
                {
                    dgr_Main.dt.Rows[irowID]["Report"] = dgr_Main.dt.Rows[irowID]["Report"].ToString() == "True" ? false : true;
                }
            }
            catch (Exception) { }
            #endregion
        }
        #endregion

        #region Check Uncheck All
        private void chk_EnableAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("isEnable", true);
        }

        private void chk_ReportAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("isReport", true);
        }

        private void chk_EnableAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("isEnable", false);
        }

        private void chk_ReportAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("isReport", false);
        }

        public void CheckAll(string columnName, bool status)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
                row[columnName] = status;
        }

        #endregion
    }
}