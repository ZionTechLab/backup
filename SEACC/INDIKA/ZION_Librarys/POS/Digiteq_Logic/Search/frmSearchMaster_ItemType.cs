using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using DataTire;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frmSearchMaster_ItemType : Form
    {
        #region Variables

           public int iFormID;
        public DataTable dtAllRecodes = new DataTable();

        #endregion

        #region Form Load
        public frmSearchMaster_ItemType()
        {
            InitializeComponent();
        }

        public void Search(ref DataTable dt)
        {
            clsFormatter.ApplyGridFormatModify(dgv_Search);
            CreateDataTable();
            if (dt.Rows.Count>0)
                dtAllRecodes.Merge(dt);
            else
                RefreshGrid();
            dgv_Search.DataSource = dtAllRecodes;

            this.ShowDialog();
            dt.Clear();
            dt.Merge(dtAllRecodes);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            dtAllRecodes.Rows.Clear();
            dgv_Search.DataSource = dtAllRecodes;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                foreach (tbl_zItemType detail in tbl_zItemType.SelectAll())
                {
                    if (detail.ItemType_ID != "default")
                        dtAllRecodes.Rows.Add(false, detail.ItemType_ID, detail.TypeName);
                }
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
            dtAllRecodes.Columns.Add("TypeCode", typeof(string));
            dtAllRecodes.Columns.Add("TypeName", typeof(string));
        }
        #endregion

        #region BindingSource Filtering
        //private void createFilterQuary()
        //{
        //    try
        //    {
        //        string sFinalQuary = "";
        //        //sFinalQuary += " SabeelID LIKE '%" + txtSearchSabeelNo.Text.Trim() + "%'"; //ToDo

        //        //  dtAllRecodes.fil = "";
        //        //   dtAllRecodes.Filter = sFinalQuary;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        #endregion

        #region Btn Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            int iRecordcount = 0;
            foreach (DataGridViewRow row in dgv_Search.Rows)
            {  
                string sTypeCode = string.Empty, sTypeName = string.Empty;
                if (clsValidate.ValidateGridValue(dgv_Search, "IsSelect", row.Index, false))
                    iRecordcount++;
            }
            if (iRecordcount <= 0)
                MessageBox.Show("Please Select One or More Records", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                this.Close();
                //frm_rpt_pmsStandardReport.bisPressOK = true;
            }
        }

        //private static void PrintColumns(DataTableReader reader)
        //{
        //    // Loop through all the rows in the DataTableReader 
        //    while (reader.Read())
        //    {
        //        for (int i = 0; i < reader.FieldCount; i++)
        //        {
        //            Console.Write(reader[i] + " ");
        //            //MessageBox.Show(reader[i].ToString());
        //        }
        //        Console.WriteLine();
        //    }
        //}


    }
}
