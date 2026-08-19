using System;
using System.Data;
using System.Windows.Forms;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frmSearchTransaction : Form
    {      
        public static string s_TableName="";        
        public static string s_Criteria="";
        public static string s_Order = "";
        public static string s_Columns="";
        public static string s_SearchText="";
        public static string s_SearchID = "";
        public static int[] i_ColumnWidth;
        public static enum_GridFormat[] e_ColomnAlignment;
        public static bool bActiveChequeBox = false;
        public static DataTable dt_RefSearch;          

        string s_Query;
        string s_searchtxt = "";
        string s_TempCriteria = " 1=1 ";
        int i_Index = 0 , DefaultSearchSelectedIndex = 0;        
        public static int i_SelectedIndex = 0;

        public frmSearchTransaction()
        {
            InitializeComponent();
        }
        public frmSearchTransaction(bool isActiveScroll):this()
        {
            if (isActiveScroll)
                dgv_Search.ScrollBars = ScrollBars.Both;
        }
        public frmSearchTransaction(int Index):this()
        {            
            DefaultSearchSelectedIndex = Index;
        }
        public frmSearchTransaction(int Index, ref DataTable dt_Search)
            : this(Index)
        {
            dt_RefSearch = dt_Search;
        }
        private void frm_HelpSearch_Load(object sender, EventArgs e)
        {
            CusDataGridViewFormat();
            s_SearchText = "";
            s_SearchID = "";
            LoadColumns();
            FillData();
        }


        private void LoadColumns()
        {
            string s_TempColumns;
            int i_Position;
            string s_SplitColumns;
            int i_SplitPosition;
            s_TempColumns = s_Columns + ",";
            cmb_Searchby.Items.Clear();
            cmb_SearchShowby.Items.Clear();
            if (s_TempColumns.Length > 0)
            {
                while (s_TempColumns.Length > 0)
                {
                    i_Position = s_TempColumns.IndexOf(",");
                    s_SplitColumns = s_TempColumns.Substring(1, i_Position - 1);
                    //s_SplitColumns = s_TempColumns.Substring(0, i_Position - 1);
                    if (s_SplitColumns.Substring(0, 5) == "CASE ")
                    {
                        i_SplitPosition = s_SplitColumns.IndexOf(" AS ") + 3;
                        cmb_Searchby.Items.Add(s_SplitColumns.Substring(0, i_SplitPosition - 3));
                        cmb_SearchShowby.Items.Add(s_SplitColumns.Substring(i_SplitPosition + 1));
                    }
                    else
                    {
                        i_SplitPosition = s_SplitColumns.IndexOf(" ");

                        if (i_SplitPosition == -1)
                        {
                            cmb_Searchby.Items.Add(s_SplitColumns);
                            cmb_SearchShowby.Items.Add(s_SplitColumns);
                        }
                        else
                        {
                            cmb_Searchby.Items.Add(s_SplitColumns.Substring(0, i_SplitPosition));
                            cmb_SearchShowby.Items.Add(s_SplitColumns.Substring(i_SplitPosition + 1));
                        }
                    }
                    s_TempColumns = s_TempColumns.Substring(i_Position + 1);
                }
                if (cmb_Searchby.Items.Count >= 2)
                {
                    i_Index = DefaultSearchSelectedIndex;
                    cmb_Searchby.Text = cmb_Searchby.Items[DefaultSearchSelectedIndex].ToString();
                    cmb_SearchShowby.Text = cmb_SearchShowby.Items[DefaultSearchSelectedIndex].ToString();
                }             
            }
        }

        private void FillData()
        {
            DataSet ds;
            try
            {
                if (i_Index == DefaultSearchSelectedIndex)
                {
                    cmb_Searchby.Text = cmb_Searchby.Items[DefaultSearchSelectedIndex].ToString().Trim();
                    cmb_SearchShowby.Text = cmb_SearchShowby.Items[DefaultSearchSelectedIndex].ToString().Trim();
                }
                else
                {
                    cmb_Searchby.Text = cmb_Searchby.Items[i_Index].ToString().Trim();
                    cmb_SearchShowby.Text = cmb_SearchShowby.Items[i_Index].ToString().Trim();
                }
                s_Query = " Select " + s_Columns + " from " + s_TableName;
                if (s_Criteria.Length > 0)
                    s_Query += " Where 1=1 and " + s_Criteria + " and " + s_TempCriteria + s_Order;
                else
                    s_Query += " Where " + s_TempCriteria + s_Order;


                ds = clsDB.ExecQuery(s_Query, "TempTable");

                if (bActiveChequeBox)
                {
                    DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                    CheckboxColumn.Width = 20;
                    CheckboxColumn.HeaderText = "Select";
                    dgv_Search.Columns.Add(CheckboxColumn);
                    dgv_Search.ReadOnly = false;
                }

                dgv_Search.DataSource = ds.Tables["TempTable"];
                if (bActiveChequeBox)
                {
                    foreach (DataGridViewColumn cm in dgv_Search.Columns)
                    {
                        if (cm.Index != 0)
                            cm.ReadOnly = true;
                    }
                }
                if (i_ColumnWidth.GetUpperBound(0) > 0)
                {
                    for (int i_Cnt = 0; i_Cnt <= i_ColumnWidth.GetUpperBound(0); i_Cnt++)
                        dgv_Search.Columns[i_Cnt].Width = int.Parse(i_ColumnWidth.GetValue(i_Cnt).ToString()) + 26;
                }

                if (e_ColomnAlignment.GetUpperBound(0) > 0)
                {
                    DataGridViewCellStyle dgvcsNumaric = new DataGridViewCellStyle();                    
                    dgvcsNumaric.Format = "N2";
                    dgvcsNumaric.Alignment = DataGridViewContentAlignment.MiddleRight;

                    DataGridViewCellStyle dgvcsDate = new DataGridViewCellStyle();
                    dgvcsDate.Format = "dd/MM/yyyy";
                    dgvcsDate.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    for (int i_Cnt = 0; i_Cnt <= e_ColomnAlignment.GetUpperBound(0); i_Cnt++)
                    {
                        switch (e_ColomnAlignment[i_Cnt])
                        {
                            case enum_GridFormat.TextValue:
                                break;
                            case enum_GridFormat.NumaricValue:
                                dgv_Search.Columns[i_Cnt].DefaultCellStyle = dgvcsNumaric;
                                break;
                            case enum_GridFormat.DateValue:
                                dgv_Search.Columns[i_Cnt].DefaultCellStyle = dgvcsDate;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception )
            {
            }
        }



        private void FillData(bool IsMultiple)
        {
            DataSet ds;
            try
            {
                if (i_Index == DefaultSearchSelectedIndex)
                {
                    cmb_Searchby.Text = cmb_Searchby.Items[DefaultSearchSelectedIndex].ToString().Trim();
                    cmb_SearchShowby.Text = cmb_SearchShowby.Items[DefaultSearchSelectedIndex].ToString().Trim();
                }
                else
                {
                    cmb_Searchby.Text = cmb_Searchby.Items[i_Index].ToString().Trim();
                    cmb_SearchShowby.Text = cmb_SearchShowby.Items[i_Index].ToString().Trim();
                }
                s_Query = " Select " + s_Columns + " from " + s_TableName;
                if (s_Criteria.Length > 0)
                    s_Query += " Where 1=1 and " + s_Criteria + " and " + s_TempCriteria + s_Order;
                else
                    s_Query += " Where " + s_TempCriteria + s_Order;

                
                ds = clsDB.ExecQuery(s_Query, "TempTable");                
                dgv_Search.DataSource = ds.Tables["TempTable"];
                if (i_ColumnWidth.GetUpperBound(0) > 0)
                {
                    for (int i_Cnt = 0; i_Cnt <= i_ColumnWidth.GetUpperBound(0); i_Cnt++)
                        dgv_Search.Columns[i_Cnt].Width = int.Parse(i_ColumnWidth.GetValue(i_Cnt).ToString());
                }
            }
            catch (Exception)
            {
            }
        }

        private void cmb_Searchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            i_Index = cmb_Searchby.SelectedIndex;
        }


        private void btn_Close_Click(object sender, EventArgs e)
        {
            s_TableName = "";
            s_Criteria = "";
            s_Columns = "";
            s_Order = "";
            s_SearchText = "";
            s_SearchID = "";
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bActiveChequeBox)
                {
                    if (dgv_Search.RowCount > 0)
                    {
                        //dgv_Search.CurrentCell.RowIndex
                        //This was change by Gayan on 2016-12-06 
                        //Reason : Pasyale Customer had said that they couldn't select item using Arrow keys. Always select firest item.
                        int iRow = dgv_Search.SelectedRows[0].Index;

                        s_SearchText = dgv_Search[1, iRow].Value.ToString().Trim();
                        s_SearchID = dgv_Search[0, iRow].Value.ToString().Trim();
                        i_SelectedIndex = iRow;
                    }
                    else
                    {
                        s_SearchText = "";
                        s_SearchID = "";
                    }
                    s_TableName = "";
                    s_Criteria = "";
                    s_Columns = "";
                    s_Order = "";
                    this.Close();
                }
                else if(dt_RefSearch.Columns.Count > 0)
                {                    
                    foreach (DataGridViewRow row in dgv_Search.Rows)
                    {                        
                        if (row.Cells[0].Value!= null && bool.Parse(row.Cells[0].Value.ToString()))
                            dt_RefSearch.Rows.Add(row.Cells[1].Value, row.Cells[2].Value);                     
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("",-1,ex);
                //SEACCException.Show(ex);
            }            
        }

        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgv_Search);
            
        }

        private void txt_ContenttoSearch_KeyUp(object sender, KeyEventArgs e)
        {          
            bool bValue = bActiveChequeBox;

            if (e.KeyCode == Keys.F9)
                cmb_SearchShowby.SelectedIndex = ((cmb_SearchShowby.Items.Count-1) == cmb_SearchShowby.SelectedIndex) ? 0 : cmb_SearchShowby.SelectedIndex + 1;
            else if (e.KeyCode == Keys.Escape)
                btn_Close_Click(sender,e);
            else if (e.KeyCode == Keys.Enter)
                btn_Ok_Click(sender, e);
            else if (e.KeyCode == Keys.Up)
                Up(true);
            else if (e.KeyCode == Keys.Down)
                Up(false);
            else
            {
                bActiveChequeBox = false;
                if (txt_ContenttoSearch.Text.Length > 0 && s_searchtxt != txt_ContenttoSearch.Text)
                {
                    s_TempCriteria = cmb_Searchby.Text.Trim() + " like '%" + txt_ContenttoSearch.Text.Trim() + "%'";
                    FillData();
                }
                else
                {
                    s_TempCriteria = " 1=1 ";
                    FillData();
                }
            }
            bActiveChequeBox = bValue;
        }
        private void Up(bool UP)
        {
            try
            {
                int iCurentRow = dgv_Search.SelectedRows[0].Index;
                
                if (iCurentRow >= 0)
                {
                    if (UP)
                    {
                        if (iCurentRow == 0)
                            dgv_Search.Rows[dgv_Search.RowCount - 1].Selected = true;
                        else
                            dgv_Search.Rows[iCurentRow - 1].Selected = true;
                    }
                    else
                    {
                        if (iCurentRow == dgv_Search.RowCount - 1)
                            dgv_Search.Rows[0].Selected = true;
                        else
                            dgv_Search.Rows[iCurentRow + 1].Selected = true;
                    }
                }
                else
                    dgv_Search.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                // SEACCException.Show(ex);
            }
        }
        private void dgv_Search_DoubleClick(object sender, EventArgs e)
        {
            if (!bActiveChequeBox)
                btn_Ok_Click(sender, e);
        }

        private void cmb_SearchShowby_SelectedIndexChanged(object sender, EventArgs e)
        {
            i_Index = cmb_SearchShowby.SelectedIndex;
        }

        private void frm_HelpSearch_Deactivate(object sender, EventArgs e)
        {
            //s_TableName = "";
            //s_Criteria = "";
            //s_Columns = "";
            //s_Order = "";
            //s_SearchText = "";
        }

        private void txt_ContenttoSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    if (btn_Ok.Enabled)
                //        btn_Ok.Focus();
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                //SEACCException.Show(ex);
            }
        }

        private void dgv_Search_Click(object sender, EventArgs e)
        {
          
        }

        #region frm keys
        private void frmSearchTransaction_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Up)
            //    {
            //        if (dgv_Search.SelectedRows[0].Index > 0)
            //        {
            //           dgv_Search.Rows[dgv_Search.SelectedRows[0].Index - 1].Selected = true;
            //            dgv_Search.CurrentCell = dgv_Search.SelectedCells[0];
            //        }
            //    }
            //    if (e.KeyCode == Keys.Down)
            //    {                    
            //        dgv_Search.Rows[dgv_Search.SelectedRows[0].Index + 1].Selected = true;
            //        dgv_Search.CurrentCell = dgv_Search.SelectedCells[0];                   
            //    }
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        btn_Ok_Click(sender, e);
            //    }
            //}
            //catch { }
        }
        private void dgv_Search_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
        #endregion

        private void dgv_Search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            { 
              if (!bActiveChequeBox)
                btn_Ok_Click(sender, e);
            }
        }
    }
}