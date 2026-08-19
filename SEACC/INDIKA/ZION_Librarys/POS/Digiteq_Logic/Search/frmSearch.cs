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
using System.Runtime.InteropServices;
namespace Digiteq
{
    public partial class frmSearch : Form
    {
        #region Class Variables
        string sSearch_ID = "", strTable = "", strFields = "", strSelection = "", strSelection2 = "", strOrderBy = "";
        protected List<string> lstReturn = new List<string>();
        protected List<string> lstPara = new List<string>();
        Dictionary<string, string> dicFilter = new Dictionary<string, string>();
        DataTable dtResult;
        bool bWithCancels = false;
        #endregion

        #region form Load
        public frmSearch(bool bCancels)
        {
            InitializeComponent();
            bWithCancels = bCancels;
            dgvSearch.AutoGenerateColumns = false;
            //controlsToMove.Add(this.panel1);
        }

        public frmSearch()
        {
            InitializeComponent();
            dgvSearch.AutoGenerateColumns = false;
        }

        public frmSearch(List<string> lstParameeters)
        {
            InitializeComponent();
            lstPara = lstParameeters;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                ucTittleBar1.DisplayName = "";
                txtFillter.Select();
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

                DataTable dtResult_Table = DBHandling.ExecQuery("select * from tbl_cfgSearch Where searchId='" + sSearch_ID + "'").Tables[0];
                if (dtResult_Table != null && dtResult_Table.Rows.Count > 0)
                {
                    int iWidth = 0;
                    foreach (DataRow dtRow1 in dtResult_Table.Rows)
                    {
                        strTable += dtRow1["searchtable"].ToString();
                        //lblHeader.Text = dtRow1["displayName"].ToString();
                        ucTittleBar1.DisplayName = dtRow1["displayName"].ToString();
                        strSelection = dtRow1["Selection1"].ToString();
                        strSelection2 = dtRow1["Selection2"].ToString();
                        strOrderBy = dtRow1["orderBy"].ToString();
                        iWidth = int.Parse(dtRow1["width"].ToString());
                    }
                    if (iWidth != 0)
                        this.Width = iWidth;

                    #region Filters
                    DataTable dtResult_Filters = DBHandling.ExecQuery("select fieldName,displayName from tbl_cfgSearchDetail Where SearchId='" + sSearch_ID + "'" + " and isFilter=1  order by FilterOrder").Tables[0];
                    if (dtResult_Filters != null && dtResult_Filters.Rows.Count > 0)
                    {
                        foreach (DataRow dtRow in dtResult_Filters.Rows)
                        {
                            string strDname = dtRow["displayName"].ToString();
                            string strfName = dtRow["fieldName"].ToString();

                            if (strfName.Contains(" "))
                            {
                                string[] words = strfName.Split(' ');
                                strfName = words[words.Length - 1];
                            }
                            else if (strfName.Contains("."))
                            {
                                string[] words = strfName.Split('.');
                                strfName = words[1];
                            }

                            cbxSearch.Items.Add(strDname);
                            dicFilter.Add(strDname, strfName);
                        }
                    }
                    cbxSearch.SelectedIndex = 0;
                    #endregion

                    #region fields
                    DataTable dtResult_Fields = DBHandling.ExecQuery("select * from tbl_cfgsearchDetail Where SearchId='" + sSearch_ID + "'").Tables[0];
                    if (dtResult_Fields != null && dtResult_Fields.Rows.Count > 0)
                    {
                        foreach (DataRow dtRow in dtResult_Fields.Rows)
                        {
                            strFields += dtRow["fieldName"].ToString() + " , ";

                            string strDname = dtRow["displayName"].ToString();
                            string strfName = dtRow["fieldName"].ToString();
                            string strFType = dtRow["dataType"].ToString();

                            if (strfName.Contains(" "))
                            {
                                string[] words = strfName.Split(' ');
                                strfName = words[words.Length - 1];
                            }
                            else if (strfName.Contains("."))
                            {
                                string[] words = strfName.Split('.');
                                strfName = words[1];
                            }
                            int iSize = int.Parse(dtRow["size"].ToString());

                            if (strFType == "c")
                            {
                                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                                checkBoxColumn.HeaderText = strDname;
                                checkBoxColumn.DataPropertyName = strfName;
                                checkBoxColumn.Width = iSize;
                                checkBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

                                //if (strFType == "d")
                                //    checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dgvSearch.Columns.Add(checkBoxColumn);

                                if (iSize == 0)
                                    checkBoxColumn.Visible = false;
                            }

                            else
                            {
                                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                                textColumn.HeaderText = strDname;
                                textColumn.DataPropertyName = strfName;
                                textColumn.Width = iSize;
                                textColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                                if (strFType == "d")
                                    textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                if (strFType == "n")
                                    textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dgvSearch.Columns.Add(textColumn);


                                if (iSize == 0)
                                    textColumn.Visible = false;
                            }
                        }
                    }
                    #endregion
                }
                RefrechAll();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
            }
        }

        #endregion

        public List<string> Show(Search SearcEnm)
        {
            try
            {
                sSearch_ID = ((int)SearcEnm).ToString();
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
            }
            return lstReturn;
        }

        public List<string> Show(FormName SearcEnm)
        {
            try
            {
                sSearch_ID = ((int)SearcEnm).ToString();
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
            }
            return lstReturn;
        }


        private void RefrechAll()
        {
            try
            {
                string sWhere = (strSelection != "" ? " WHERE " : "") + strSelection;
                string sOrderBy = (strOrderBy != "" ? " ORDER BY " : "") + strOrderBy;

                if (lstPara.Count > 0)
                {
                    int iListIndex = 1;
                    foreach (string s in lstPara)
                    {
                        strSelection2 = strSelection2.Replace("[" + iListIndex + "]", s);
                        strTable = strTable.Replace("[" + iListIndex + "]", s);
                        iListIndex++;
                    }
                    sWhere += (sWhere == "" ? " WHERE " : " AND ") + strSelection2;
                }

                string strScript = "SELECT " + strFields.Substring(0, strFields.Length - 2) + " FROM " + strTable + sWhere + sOrderBy;
                dtResult = DBHandling.ExecQuery(strScript).Tables[0];
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    dgvSearch.DataSource = dtResult;
                    FilterChanged(Keys.K);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                //SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", 0, ex);
            }
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                SelectionOk();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFillter.Focus();
        }

        private void txtFillter_KeyUp(object sender, KeyEventArgs e)
        {
            FilterChanged(e.KeyCode);
        }

        private void FilterChanged(Keys k)
        {
            try
            {
                if (k == Keys.F9)
                    cbxSearch.SelectedIndex = ((dicFilter.Count - 1) == cbxSearch.SelectedIndex) ? 0 : cbxSearch.SelectedIndex + 1;
                else if (k == Keys.Escape)
                    btn_Close_Click(null, null);
                else if (k == Keys.Enter)
                    SelectionOk();
                else if (k == Keys.Up)
                    Up(true);
                else if (k == Keys.Down)
                    Up(false);

                string sFilter = dicFilter[cbxSearch.Text] + " Like '%" + clsHelpMethods.CheckValue(txtFillter.Text) + "%' ";
                dtResult.DefaultView.RowFilter = sFilter;
            }
            catch (Exception ex)
            {
                try
                {
                    string sFilter = "";
                    if (txtFillter.Text != "")
                    {
                        sFilter = dicFilter[cbxSearch.Text] + " = '" + clsHelpMethods.CheckValue(txtFillter.Text) + "' ";
                    }


                    dtResult.DefaultView.RowFilter = sFilter;

                }
                catch (Exception)
                {

                    clsValidate.WriteErrorLog("", 0, ex);
                }
                //SEACCExeption.Show(ex);
            }
        }

        private void SelectionOk()
        {
            try
            {
                if (dgvSearch.SelectedCells.Count != 0)
                {
                    DataGridViewRow row = dgvSearch.SelectedRows[0];
                    if (row != null)
                    {
                        int iColumnIndex = 0;
                        foreach (DataGridViewColumn column in dgvSearch.Columns)
                        {
                            lstReturn.Add(row.Cells[iColumnIndex].Value.ToString());
                            iColumnIndex++;
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.No;
                clsValidate.WriteErrorLog("", 0, ex);
            }
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSearch_CellDoubleClick(sender, e);
        }

        private void Up(bool UP)
        {
            try
            {
                int iCurentRow = dgvSearch.SelectedRows[0].Index;
                if (iCurentRow >= 0)
                {
                    if (UP)
                    {
                        if (iCurentRow == 0)
                            dgvSearch.Rows[dgvSearch.RowCount - 1].Selected = true;
                        else
                            dgvSearch.Rows[iCurentRow - 1].Selected = true;
                    }
                    else
                    {
                        if (iCurentRow == dgvSearch.RowCount - 1)
                            dgvSearch.Rows[0].Selected = true;
                        else
                            dgvSearch.Rows[iCurentRow + 1].Selected = true;
                    }
                }
                else
                    dgvSearch.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                // SEACCExeption.Show(ex);
            }
        }

        private void dgvSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dgvSearch.Columns)
            {
                //column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void dgvSearch_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dgvSearch.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dgvSearch.SortedColumn;
            ListSortDirection direction;

            if (oldColumn != null)
            {
                if (oldColumn == newColumn && dgvSearch.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            dgvSearch.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
    }
}