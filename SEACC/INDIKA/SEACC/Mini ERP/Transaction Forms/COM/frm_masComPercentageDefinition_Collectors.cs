using DataTire;
using Digiteq_Logic;
using SEACC.DATA.Data.Com;
using SEACC.DATA.Domain.Com;
using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.COM
{
    public partial class frm_masComPercentageDefinition_Collectors : MettroForm
    {
        #region Class Variables
        public int iFormID;
        public bool bNoAccess;
      //  public bool bHasApproved;
        static bool IsUpdateMode = false;

     //   private BindingSource SBind;
     //   DataTable dtCollectors;

        int iPID;
        #endregion
         
        #region Form Load

        #region Init Form
        public frm_masComPercentageDefinition_Collectors()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.Com_ComissionPeriodMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        }
        #endregion

        private void frm_masComPercentageDefinition_Collectors_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorSales;

            #region Init Data Table
            //dtCollectors = new DataTable();
            //dtCollectors.Columns.Add("No", typeof(int));
            //dtCollectors.Columns.Add("ColID_1", typeof(string));
            //dtCollectors.Columns.Add("Col_1", typeof(string));
            //dtCollectors.Columns.Add("ColPer_1", typeof(decimal));
            //dtCollectors.Columns.Add("ColID_2", typeof(string));
            //dtCollectors.Columns.Add("Col_2", typeof(string));
            //dtCollectors.Columns.Add("ColPer_2", typeof(decimal));
            //dtCollectors.Columns.Add("Active", typeof(bool));
            #endregion

            #region Init Data Grid
         //   SBind = new BindingSource();
            dgvCollectors.AutoGenerateColumns = false;
         //   SBind.DataSource = dtCollectors;
         //   dgvCollectors.DataSource = SBind;
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #endregion

        #region Action Buttons
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long lIndex = 0;
            try
            {
                Cursor = Cursors.Arrow;

                if (CheckValidity())
                {
                    //Update
                    if (IsUpdateMode)
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, true))
                        {
                            ComPercentageDefinition_Data oData = new ComPercentageDefinition_Data();
                            tbl_comCollectorsPercentageDef oCP = new tbl_comCollectorsPercentageDef();

                            oCP.p_ID = iPID;
                            oCP.collector_ID1 = txtCol1.Tag.ToString();
                            oCP.collector_ID2 = txtCol2.Tag.ToString();
                            oCP.percentage1 = decimal.Parse(txtPer1.Text);
                            oCP.percentage2 = decimal.Parse(txtPer2.Text);
                            oCP.isActive = chkActive.Checked;
                            oCP.user_ID = clsSecurity.UserIDLoged;

                            var result = oData.Save(oCP, IsUpdateMode);
                            if (!result.IsSuccess)
                                MessageBox.Show(result.OutMsg);
                            else
                                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.Afterupdate, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    //Insert
                    else
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                        {
                            ComPercentageDefinition_Data oData = new ComPercentageDefinition_Data();
                            tbl_comCollectorsPercentageDef oCP = new tbl_comCollectorsPercentageDef();

                            oCP.collector_ID1 = txtCol1.Tag.ToString();
                            oCP.collector_ID2 = txtCol2.Tag.ToString();
                            oCP.percentage1 = decimal.Parse(txtPer1.Text);
                            oCP.percentage2 = decimal.Parse(txtPer2.Text);
                            oCP.isActive = chkActive.Checked;
                            oCP.user_ID = clsSecurity.UserIDLoged;

                            var result = oData.Save(oCP, IsUpdateMode);
                            if (!result.IsSuccess)
                                MessageBox.Show(result.OutMsg);
                            else
                                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.Afterinsert, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                RefreshGrid();
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdateMode = false;

            iPID = -1;
            txtCol1.Tag = null;
            txtCol2.Tag = null;
            txtCol1.Text = "";
            txtCol2.Text = "";
            txtPer1.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(0);
            txtPer2.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(0);
            chkActive.Checked = true;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
            //    dtCollectors.Rows.Clear();
                               
                var oComPeriod = new ComPercentageDefinition_Data();
                var ComDetail = oComPeriod.SelectAll();
                dgvCollectors.DataSource = ComDetail;
                //foreach (tbl_comCollectorsPercentageDef ComDetail in oComPeriod.SelectAll())
                //{
                //    dtCollectors.Rows.Add(ComDetail.p_ID, ComDetail.collector_ID1, ComDetail.collector_1, clsFormatter.FormatDecimalPlaces_Price(ComDetail.percentage1),
                //        ComDetail.collector_ID2, ComDetail.collector_2, clsFormatter.FormatDecimalPlaces_Price(ComDetail.percentage2), ComDetail.isActive);
                //}
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;

            if (CheckValidity_EmptyField())
                if (CheckValidity_Duplicate())
                    if (CheckValidity_Duplicate_Collectors())
                        if (CheckValidity_Percentage())
                            if (CheckValidity_TotPercentage())
                                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCol1, "Collector 1"))
                bStatus = true;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCol2, "Collector 2"))
                bStatus = true;
                       
            return bStatus;
        }

        private bool CheckValidity_Percentage()
        {
            bool bStatus = false;
            if (clsValidate.DecimalValidate(txtPer1) > 0 && clsValidate.DecimalValidate(txtPer2) > 0)
                bStatus = true;
            
            if (bStatus == false)
                MessageBox.Show("Percentage can not be zero", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);


            return bStatus;
        }

        private bool CheckValidity_Duplicate()
        {
            bool bStatus = true;
            if (txtCol1.Text == txtCol2.Text)
            {
                MessageBox.Show("Collector 1 AND 2 can not be same..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bStatus = false;
            }

            return bStatus;
        }

        private bool CheckValidity_Duplicate_Collectors()
        {
            bool bStatus = true;

            var oComPeriod = new ComPercentageDefinition_Data();
            //var ComDetail = oComPeriod.SelectAllBy_Collecor_ID(txtCol1.Tag.ToString(), txtCol2.Tag.ToString());
            foreach (tbl_comCollectorsPercentageDef ComDetail in oComPeriod.SelectAllBy_Collecor_ID(iPID, txtCol1.Tag.ToString(), txtCol2.Tag.ToString()))
            {
                bStatus = false;
                break;
            }

            if (!bStatus)
                MessageBox.Show("Collector Commission Pairs can not be Duplicate..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        private bool CheckValidity_TotPercentage()
        {
            bool bStatus = false;
            if (decimal.Parse(txtPer1.Text) + decimal.Parse(txtPer2.Text) == 100)
                bStatus = true;
            else
                MessageBox.Show("Total Percentage should be 100% ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            return bStatus;
        }

        #endregion

       
        #region Grid Event
        private void dgvCollectors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {                   
                    IsUpdateMode = true;
                    iPID = int.Parse(dgvCollectors.Rows[e.RowIndex].Cells["No"].Value.ToString());
                    txtCol1.Tag = dgvCollectors.Rows[e.RowIndex].Cells["ColID_1"].Value.ToString();
                    txtCol1.Text = dgvCollectors.Rows[e.RowIndex].Cells["Col_1"].Value.ToString();
                    txtPer1.Text = clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(dgvCollectors.Rows[e.RowIndex].Cells["ColPer_1"].Value.ToString()));
                    txtCol2.Tag = dgvCollectors.Rows[e.RowIndex].Cells["ColID_2"].Value.ToString();
                    txtCol2.Text = dgvCollectors.Rows[e.RowIndex].Cells["Col_2"].Value.ToString();
                    txtPer2.Text = clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(dgvCollectors.Rows[e.RowIndex].Cells["ColPer_2"].Value.ToString()));
                    chkActive.Checked = bool.Parse(dgvCollectors.Rows[e.RowIndex].Cells["Active"].Value.ToString());
                   
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        private void dgvCollectors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCollectors_CellContentClick(sender, e);
        }

        #endregion

        private void txtCol1_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterCollector(ref txtCol1);
        }
               
        private void txtCol2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterCollector(ref txtCol2);
        }
    }
}