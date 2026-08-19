using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    public partial class frm_PickBox : Form
    {
        protected TextBox Tbx;
        DataTable dtDetail;
        dbConnection DBConnection = new dbConnection();
        Dictionary<string, string> dicFilter = new Dictionary<string, string>();
        protected string strPickId = "", strTable = "", strFields = "", strSelection = "";
        protected List<string> lstReturn = new List<string>();

        public frm_PickBox()
        {
            InitializeComponent();
        }

        public List<string> Pick(string PickID)
        {
            strPickId = PickID;
            this.ShowDialog() ;
            return lstReturn;
        }

        void frm_PickBox_LostFocus(object sender, EventArgs e)
        {
            //MessageBox.Show("giya");
            Close();
        }

        private void frm_PickBox_Load(object sender, EventArgs e)
        {
            txtFillter.Select();
            try
            {
                bool bQuaryStatus1 = DBConnection.SelectToDataTable("select * from tbl_cfg_pick Where pickId='" + strPickId + "'");
                if (bQuaryStatus1)
                {
                    DataTable dtResult1 = DBConnection.ResultTable;
                    foreach (DataRow dtRow1 in dtResult1.Rows)
                    {
                        strTable += dtRow1["table"].ToString();
                        lblHeader.Text = dtRow1["displayName"].ToString();
                        strSelection = dtRow1["Selection"].ToString();
                    }

                    bool bQuaryStatus3 = DBConnection.SelectToDataTable("select fieldName,displayName from tbl_cfg_pickDetail Where pickId='" + strPickId + "'" + " and isFilter=1  order by FilterOrder");
                    if (bQuaryStatus3)
                    {
                        DataTable dtResult = DBConnection.ResultTable;
                        foreach (DataRow dtRow in dtResult.Rows)
                        {
                            string strDname = dtRow["displayName"].ToString();
                            string strfName = dtRow["fieldName"].ToString();

                            if (strfName.Contains(" "))
                            {
                                string[] words = strfName.Split(' ');
                                strfName = words[1];
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

                    bool bQuaryStatus2 = DBConnection.SelectToDataTable("select * from tbl_cfg_pickDetail Where pickId='" + strPickId + "'");
                    if (bQuaryStatus2)
                    {
                        DataTable dtResult = DBConnection.ResultTable;


                        foreach (DataRow dtRow in dtResult.Rows)
                        {
                            strFields += dtRow["fieldName"].ToString() + " , ";

                            string strDname = dtRow["displayName"].ToString();
                            string strfName = dtRow["fieldName"].ToString();

                            if (strfName.Contains(" "))
                            {
                                string[] words = strfName.Split(' ');
                                strfName = words[1];
                            }
                            else if (strfName.Contains("."))
                            {
                                string[] words = strfName.Split('.');
                                strfName = words[1];
                            }

                            int iSize = int.Parse(dtRow["size"].ToString());

                            DataGridViewTextBoxColumn DataGridColomn = new DataGridViewTextBoxColumn();
                            DataGridColomn.DataPropertyName = strfName;
                            DataGridColomn.HeaderText = strDname;
                            DataGridColomn.Name = strfName;
                            DataGridColomn.ReadOnly = true;
                            DataGridColomn.Width = iSize;
                            dgv1.Columns.Add(DataGridColomn);
                          
                            if (iSize == 0)
                                DataGridColomn.Visible = false;

                            if (dtRow["datatype"].ToString() == "T")
                                DataGridColomn.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

                            else if (dtRow["datatype"].ToString() == "D")
                                DataGridColomn.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

                            else if (dtRow["datatype"].ToString() == "N")
                                DataGridColomn.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                }
                if (cbxSearch.Items.Count > 0)
                    cbxSearch.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
            RefrechAll();
        }

        private void RefrechAll()
        {
            try
            {
                string strScript = "SELECT " + strFields.Substring(0, strFields.Length - 2) + " FROM " + strTable + (strSelection != "" ? " WHERE " + strSelection : "");
                bool bQuaryStatus = DBConnection.SelectToDataTable(strScript);
                if (bQuaryStatus)
                {
                    dtDetail = DBConnection.ResultTable;
                    dgv1.DataSource = dtDetail;
                    toolStripStatusLabel1.Text = "Count - " + dgv1.RowCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgv1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GridSelectionOk();
            else if (!(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
                txtFillter.Focus();
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void txtFillter_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F9)
                    cbxSearch.SelectedIndex = ((dicFilter.Count - 1) == cbxSearch.SelectedIndex) ? 0 : cbxSearch.SelectedIndex + 1;
                else if (e.KeyCode == Keys.Return)
                    GridSelectionOk();
                else if (e.KeyCode == Keys.Up)
                    dgv1.Focus();
                else if (e.KeyCode == Keys.Down)
                    dgv1.Focus();
                else if (e.KeyCode == Keys.Escape)
                    this.DialogResult = DialogResult.Cancel;
                else
                {
                    string s = string.Format(dicFilter[cbxSearch.Text] + " LIKE '%{0}%'", txtFillter.Text);
                    dtDetail.DefaultView.RowFilter = s;
                    toolStripStatusLabel1.Text = "Count - " + dgv1.RowCount.ToString();

                    if (strPickId == "100" || strPickId == "110" || strPickId == "605" || strPickId == "611")
                        this.Height = dgv1.RowCount < 15 ? ((dgv1.RowCount + 1) * 15) : (16 * 15);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                GridSelectionOk();
        }

        private void GridSelectionOk()
        {
            foreach (DataGridViewColumn column in dgv1.Columns)
            {
                lstReturn.Add(dgv1.SelectedRows[0].Cells[column.Index].Value.ToString());
         
            }
            this.DialogResult = DialogResult.OK;
            if (Tbx != null)
            {
                Tbx.Tag = dgv1.SelectedRows[0].Cells[0].Value.ToString();
                Tbx.Text = dgv1.SelectedRows[0].Cells[1].Value.ToString();
                this.Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
