using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq.User_Management
{
    public partial class frmSearchMaster_ItemCategory : Form
    {

        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;

        public int iFormID;
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;

      //  DateTime glbApprovedDate = clsSecurity.getServerDateTime();
     //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        DateTime StartDate = clsSecurity.getServerDateTime();
        string planID = "";

        //data binding

        public static List<string> glbSelectedList = new List<string>();
        public DataTable dtAllRecodes = new DataTable();
        public DataTable dtSelectedRecords = new DataTable();
        DataTable dtError = new DataTable();
        private BindingSource source = new BindingSource();
        #endregion


        public frmSearchMaster_ItemCategory()
        {
            InitializeComponent();
        }

        private void frmSearchMaster_ItemCategory_Load(object sender, EventArgs e)
        {
            clsFormatter.ApplyGridFormatModify(dgv_Search);
            dtSelectedRecords.Rows.Clear();
            CreateDataTable();
            dgv_Search.DataSource = source;
            RefreshGrid();
        }

        #region Clear Fields
        private void ClearFields()
        {
            dtAllRecodes.Rows.Clear();
            dgv_Search.DataSource = source;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgv_Search.Rows.Clear();
                foreach (tbl_zItemCategory detail in tbl_zItemCategory.SelectAll())
                {
                    if (detail.ItemType_ID != "default")
                        dtAllRecodes.Rows.Add(false, detail.ItemCategory_ID, detail.CategoryName);

                    //if (detail.ItemType_ID != "default")
                    //{
                    //    dgv_Search.Rows.Add();
                    //    iRow = dgv_Search.Rows.Count - 1;
                    //    dgv_Search["IsSelect", iRow].Value = false;
                    //    dgv_Search["TypeCode", iRow].Value = detail.ItemType_ID;
                    //    dgv_Search["TypeName", iRow].Value = detail.TypeName;
                    //}
                }
                source.DataSource = dtAllRecodes;
            }
            catch (Exception ex)
            {

                clsValidate.WriteErrorLog("", iFormID,ex);
                //SEACCException.Show(ex);
            }
        }
        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("IsSelect", typeof(bool));
            dtAllRecodes.Columns.Add("CategoryCode", typeof(string));
            dtAllRecodes.Columns.Add("CategoryName", typeof(string));

            dtSelectedRecords.Columns.Clear();
            dtSelectedRecords.Columns.Add("IsSelect", typeof(bool));
            dtSelectedRecords.Columns.Add("CategoryCode", typeof(string));
            dtSelectedRecords.Columns.Add("CategoryName", typeof(string));
        }
        #endregion

        #region BindingSource Filtering
        private void createFilterQuary()
        {
            try
            {
                source.Filter = "Convert(CategoryName, 'System.String') Like '%" + txt_ContenttoSearch.Text.Trim() + "%' ";

                //string sFinalQuary = "";
                ////sFinalQuary += " SabeelID LIKE '%" + txtSearchSabeelNo.Text.Trim() + "%'"; //ToDo

                //source.Filter = "";
                //source.Filter = sFinalQuary;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                //SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Close

        #endregion

        #region Key Event
        private void txt_ContenttoSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (btn_Ok.Enabled)
                        btn_Ok.Focus();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Power Construction ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
                //SEACCException.Show(ex);
            }
        }

        private void txt_ContenttoSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txt_ContenttoSearch.Text.Length > 0 && s_searchtxt != txt_ContenttoSearch.Text)
            //{
            //    s_TempCriteria = cmb_Searchby.Text.Trim() + " like '%" + txt_ContenttoSearch.Text.Trim() + "%'";
            //    s_searchtxt = txt_ContenttoSearch.Text;
            //    FillData();
            //}
            //else
            //    s_TempCriteria = " 1=1 ";

            createFilterQuary();


        }
        #endregion



        private static void PrintColumns(DataTableReader reader)
        {
            // Loop through all the rows in the DataTableReader 
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                    //MessageBox.Show(reader[i].ToString());
                }
                Console.WriteLine();
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_Search.Rows)
            {

                bool bIsSelect = false;
                string sTypeCode = string.Empty, sTypeName = string.Empty;

                bIsSelect = clsValidate.ValidateGridValue(dgv_Search, "IsSelect", row.Index, false);
                sTypeCode = clsValidate.ValidateGridValue(dgv_Search, "CategoryCode", row.Index, "default");
                sTypeName = clsValidate.ValidateGridValue(dgv_Search, "CategoryName", row.Index, "default");

                if (bIsSelect)
                    dtSelectedRecords.Rows.Add(bIsSelect, sTypeCode, sTypeName);
            }

            if (dtSelectedRecords.Rows.Count > 0)
            {
                foreach (DataRow row in dtSelectedRecords.Rows)
                {
                    glbSelectedList.Add(row["CategoryCode"].ToString());
                }
                this.Close();
            }
            else
                MessageBox.Show("Please Select One or More Records", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }








    }
}
