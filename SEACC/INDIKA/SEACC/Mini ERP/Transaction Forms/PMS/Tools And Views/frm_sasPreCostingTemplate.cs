using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Digiteq
{
    public partial class frm_sasPreCostingTemplate : Form
    {

        
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
           public int iFormID;
        //string s_FileName = "";
        private BindingSource source = new BindingSource();
        private string sFilteQuary = "";
        public DataTable dtAllRecodes = new DataTable();


     

        #region Form Load
        public frm_sasPreCostingTemplate()
        {
            InitializeComponent();
        }

        private void frm_sasJobTemplate_Load(object sender, EventArgs e)
        {
            CusDataGridViewFormat();
            dgvDetail.DataSource = source;
            RefreshGrid();
            //ClearFields();
        } 
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
          //  int iRow;
            //dgvDetail.Rows.Clear();

            CreateDataTable();
            List<tbl_sasPreCosting> details = tbl_sasPreCosting.SelectAll();
            try
            {
                foreach (tbl_sasPreCosting detail in details)
                {
                    if (detail.PreCosting_ID != "default")
                    {
                        tbl_sasJobRegister Jdetails = tbl_sasJobRegister.Select(detail.Job_ID);
                        if (Jdetails != null)
                        {
                            tbl_genItemMaster item = tbl_genItemMaster.Select(Jdetails.Item_ID);
                            if (item != null)
                            {
                                dtAllRecodes.Rows.Add(detail.PreCosting_ID, detail.Job_ID, clsGenaralName.getName_Item(Jdetails.Item_ID).ToString(),
                                clsGenaralName.getName_Customer(Jdetails.Customer_ID).ToString(), item.Width.ToString(),
                                item.Thickness.ToString(), detail.KiloPrice.ToString());
                            }
                        }
                    }
                }
                source.DataSource = dtAllRecodes;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
            // CalculateChequeAmount();
        }

        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("PreCostingCode", typeof(string));
            dtAllRecodes.Columns.Add("JobID", typeof(string));
            dtAllRecodes.Columns.Add("ProductName", typeof(string));
            dtAllRecodes.Columns.Add("CustomerName", typeof(string));
            dtAllRecodes.Columns.Add("ProductWith", typeof(string));
            dtAllRecodes.Columns.Add("ThicknessGauge", typeof(string));
            dtAllRecodes.Columns.Add("KGPrice", typeof(string));        
        }

        private void RefreshGridMaterial(string sPreCostingID)
        {
            try
            {
                int iRow;
                dgvDetailMaterial.Rows.Clear();

                List<tbl_sasPreCosting_Material> details = tbl_sasPreCosting_Material.SelectAllByPreCosting_ID(sPreCostingID);
                foreach (tbl_sasPreCosting_Material detail in details)
                {
                    dgvDetailMaterial.Rows.Add();
                    iRow = dgvDetailMaterial.Rows.Count - 1;

                    dgvDetailMaterial["ItemCode", iRow].Value = detail.Item_ID;
                    dgvDetailMaterial["ItemName", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                    dgvDetailMaterial["Width", iRow].Value = detail.Width.ToString();
                    dgvDetailMaterial["Height", iRow].Value = detail.Height.ToString();
                    dgvDetailMaterial["Gusset", iRow].Value = detail.Gusset.ToString();
                    dgvDetailMaterial["Gauge", iRow].Value = detail.Gauge.ToString();
                    dgvDetailMaterial["UOM", iRow].Tag = detail.Uom_ID;
                    dgvDetailMaterial["UOM", iRow].Value = clsGenaralName.getName_Uom(detail.Uom_ID);
                    dgvDetailMaterial["Quantity", iRow].Value = detail.Qty.ToString();
                    dgvDetailMaterial["Weight", iRow].Value = detail.Weight.ToString();
                    dgvDetailMaterial["WeightCalculated", iRow].Value = detail.WeightCalculated.ToString();
                    dgvDetailMaterial["KiloPrice", iRow].Value = detail.CostPrice.ToString();
                    dgvDetailMaterial["Amount", iRow].Value = detail.Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGridMachine(string sPreCostingID)
        {
            try
            {
                int iRow;
                dgvDetailMachine.Rows.Clear();

                List<tbl_sasPreCosting_Machine> details = tbl_sasPreCosting_Machine.SelectAllByPreCosting_ID(sPreCostingID);
                foreach (tbl_sasPreCosting_Machine detail in details)
                {
                    dgvDetailMachine.Rows.Add();
                    iRow = dgvDetailMachine.Rows.Count - 1;
                    dgvDetailMachine["macLineNo", iRow].Value = iRow.ToString();
                    dgvDetailMachine["MachineCode", iRow].Value = detail.Machine_ID;
                    dgvDetailMachine["MachineName", iRow].Value = clsGenaralName.getName_MachineMaster(detail.Machine_ID);
                    dgvDetailMachine["MachineHourlyRate", iRow].Value = detail.MachineCostPerHour.ToString();
                    dgvDetailMachine["MachineHours", iRow].Value = detail.MachineHours.ToString();
                    dgvDetailMachine["MachineCost", iRow].Value = detail.MachineCostTotal.ToString();
                }

                //if (dgvDetailMachine.SelectedRows.Count > 0)
                //{
                //    FillDetailsMachine(dgvDetailMachine.SelectedRows[0].Index);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }



        #endregion
        
        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_sasPreCosting detail = tbl_sasPreCosting.Select(sID);
                if (detail != null)
                {
                    txtOrderedLabourCost.Text = detail.CostLabour.ToString();
                    txtOrderedMachineCost.Text = detail.CostMachine.ToString();
                    txtOrderedMaterialCost.Text = detail.CostMaterial.ToString();
                    txtOrderedOtherCost.Text = detail.CostOther.ToString();
                    txtOrderedRejection.Text = detail.RejectionCost.ToString();
                    txtOrderedRejectionPercentage.Text = detail.RejectionCostPercentage.ToString();
                    txtOrderedTotalCost.Text = detail.CostTotal.ToString();
                }
            }
        }
        #endregion



        #region Key UpEvent
        private void txtJobID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtJobID);
        }

        private void txtProduct_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtProduct);
        }

        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtCustomerName);
        }

        private void txtProductWith_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtProductWith);
        }

        private void txtThikness_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtProductThikness);
        }

        private void txtPreCostingCode_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtPreCostingCode);
        }

        private void txtOrderedKiloPrice_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtProductKGPrice);
        }

        #endregion

        #region  Event Checkbox ChechChange
        private void chkProductName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProductName.Checked)
            {
                txtProduct.Enabled = false;
            }
            else
            {
                txtProduct.Enabled = true;
                txtProduct.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtProduct);
            }
        }

        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomerName.Checked)
            {
                txtCustomerName.Enabled = false;
            }
            else
            {
                txtCustomerName.Enabled = true;
                txtCustomerName.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtCustomerName);
            }
        }

        private void chkJobName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkJobName.Checked)
            {
                txtJobID.Enabled = false;
            }
            else
            {
                txtJobID.Enabled = true;
                txtJobID.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtJobID);
            }
        }

        private void chkGussest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGussest.Checked)
            {
                txtProductGussest.Enabled = false;
            }
            else
            {
                txtProductGussest.Enabled = true;
                txtProductGussest.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtProductGussest);
            }
        }

        private void chkWidth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWidth.Checked)
            {
                txtProductWith.Enabled = false;
            }
            else
            {
                txtProductWith.Enabled = true;
                txtProductWith.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtProductWith);
            }
        }

        private void chkThickness_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThickness.Checked)
            {
                txtProductThikness.Enabled = false;
            }
            else
            {
                txtProductThikness.Enabled = true;
                txtProductThikness.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtProductThikness);
            }
        }

        private void chkKGPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKGPrice.Checked)
            {
                txtProductKGPrice.Enabled = false;
            }
            else
            {
                txtProductKGPrice.Enabled = true;
                txtProductKGPrice.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtProductKGPrice);
            }
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["PreCostingCode", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID.Trim());
                    RefreshGridMaterial(sID);
                    RefreshGridMachine(sID);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        #endregion

        #region BindingSource Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";
                //iGridCount = 1;

                if (chkJobName.Checked && argText.Name != "txtJobID")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND JobID LIKE '%" + txtJobID.Text.Trim() + "%'";
                    else
                        sFilteQuary = " JobID LIKE '%" + txtJobID.Text.Trim() + "%'";
                }
                if (chkProductName.Checked && argText.Name != "txtProduct")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND ProductName LIKE '%" + txtProduct.Text.Trim() + "%'";
                    else
                        sFilteQuary = " ProductName LIKE '%" + txtProduct.Text.Trim() + "%'";
                }
                if (chkCustomerName.Checked && argText.Name != "txtCustomerName")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND CustomerName LIKE '%" + txtCustomerName.Text.Trim() + "%'";
                    else
                        sFilteQuary = " CustomerName LIKE '%" + txtCustomerName.Text.Trim() + "%'";
                }
                if (chkWidth.Checked && argText.Name != "txtProductWith")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND ProductWith LIKE '%" + txtProductWith.Text.Trim() + "%'";
                    else
                        sFilteQuary = " ProductWith LIKE '%" + txtProductWith.Text.Trim() + "%'";
                }
                if (chkThickness.Checked && argText.Name != "txtThikness")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND ThicknessGauge LIKE '%" + txtProductThikness.Text.Trim() + "%'";
                    else
                        sFilteQuary = " ThicknessGauge LIKE '%" + txtProductThikness.Text.Trim() + "%'";
                }

                if (argText.Name != "txtPreCostingCode")
                {
                    //if (sFilteQuary.Trim().Length > 0)
                    //    sFilteQuary += " AND PreCostingCode LIKE '%" + txtPreCostingCode.Text.Trim() + "%'";
                    //else
                    //    sFilteQuary = " PreCostingCode LIKE '%" + txtPreCostingCode.Text.Trim() + "%'";
                }
                if (chkKGPrice.Checked && argText.Name != "txtOrderedKiloPrice")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND KGPrice LIKE '%" + txtProductKGPrice.Text.Trim() + "%'";
                    else
                        sFilteQuary = " KGPrice LIKE '%" + txtProductKGPrice.Text.Trim() + "%'";
                }

                if (argText.Name == "txtJobID")
                    sTemp = " JobID LIKE '%" + txtJobID.Text.Trim() + "%'";
                if (argText.Name == "txtProduct")
                    sTemp = " ProductName LIKE '%" + txtProduct.Text.Trim() + "%'";
                if (argText.Name == "txtCustomerName")
                    sTemp = " CustomerName LIKE '%" + txtCustomerName.Text.Trim() + "%'";
                if (argText.Name == "txtProductWith")
                    sTemp = " ProductWith LIKE '%" + txtProductWith.Text.Trim() + "%'";
                if (argText.Name == "txtThikness")
                    sTemp = " ThicknessGauge LIKE '%" + txtProductThikness.Text.Trim() + "%'";
                if (argText.Name == "txtPreCostingCode")
                    sTemp = " PreCostingCode LIKE '%" + txtPreCostingCode.Text.Trim() + "%'";
                if (argText.Name == "txtOrderedKiloPrice")
                    sTemp = " KGPrice LIKE '%" + txtProductKGPrice.Text.Trim() + "%'";

                if (sTemp.Trim().Length > 0)
                {
                    if (sFilteQuary.Trim().Length > 0)
                    {
                        sFinalQuary = sFilteQuary + " AND " + sTemp;
                    }
                    else
                    {
                        sFinalQuary = sTemp;
                    }
                }
                source.Filter = "";
                if (sFinalQuary.Trim().Length > 0)
                    source.Filter = sFinalQuary;
                else
                    source.Filter = sTemp;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnLogon_Click(object sender, EventArgs e)
        {

            frm_sasPreCostingTemplate detail = new frm_sasPreCostingTemplate();
            detail.Close();
        }

      

    }
}
