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
    public partial class frm_sasJobRegisterTemplate : Form
    {

        
        //to manage update and insert
        static bool IsUpdate = false;

        //form manage
      //  string sFormConfigCode;
           public int iFormID;
      //  string s_FileName = "";
        private BindingSource source = new BindingSource();
        private string sFilteQuary = "";
        public DataTable dtAllRecodes = new DataTable();

        public string glbCustomerID = "";
    

        #region Form Load
        public frm_sasJobRegisterTemplate()
        {
            InitializeComponent();
        }

        private void frm_sasJobTemplate_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Job Templates", 2, iFormID);
            CusDataGridViewFormat();
            CreateDataTable();
            dgvDetail.DataSource = source;
            RefreshGrid();

            //ClearFields();
        } 
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, Color.FromArgb(171, 201, 200), Color.Black);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;

            txtProduct.Clear();
            txtProductGussest.Clear();
            txtProductHeight.Clear();
            txtProductKGPrice.Clear();
            txtProductThikness.Clear();
            txtProductWith.Clear();
            txtCustomerName.Clear();           

            chkCustomerName.Checked = false;
            chkGussest.Checked = false;
            chkHeight.Checked = false;
            chkKGPrice.Checked = false;
            chkProductName.Checked = false;
            chkThickness.Checked = false;
            chkWidth.Checked = false;

            RefreshGrid();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_sasJobRegister detail = tbl_sasJobRegister.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;

                        txtdCustomerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSalesRep.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesRep(detail.SelesRep_ID));
                        txtdProductName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Item(detail.Item_ID));
                        //txtdJobCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_JobCategory(detail.JobCategory_ID));
                        txtdOrderedUOM.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(detail.Uom_ID));
                        txtdJobCode.Text = detail.Job_ID;


                        //product Details
                        tbl_sasJobRegister_ProductDetail Tdetails = tbl_sasJobRegister_ProductDetail.Select(sID);
                        if (Tdetails != null)
                        {
                            txtPolytheneType.Tag = Tdetails.PolytheneType_ID;
                            txtSealingType.Tag = Tdetails.SealingType_ID;
                            txtSlittingType.Tag = Tdetails.SlittingType_ID;
                            txtLaminationType.Tag = Tdetails.LaminationType_ID;
                            txtPouchType.Tag = Tdetails.PouchType_ID;
                            txtPrintType.Tag = Tdetails.PrintingType_ID;
                            // txtMesurementType.Tag = Tdetails.MeasureType_ID;
                            txtPrintMethod.Tag = Tdetails.PrintingMethod_ID;                            
                            txtTreatnmentStates.Tag = Tdetails.TreatnmentStatus_ID;

                            txtInstruction.Text = Tdetails.InstructionDetail;
                            txtPolytheneType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PolytheneType(Tdetails.PolytheneType_ID));
                            txtSealingType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SealingType(Tdetails.SealingType_ID));
                            txtSlittingType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SlittingType(Tdetails.SlittingType_ID));
                            txtLaminationType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_LaminationType(Tdetails.LaminationType_ID));
                            txtPouchType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PouchType(Tdetails.PouchType_ID));
                            txtPrintType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PrintingType(Tdetails.PrintingType_ID));
                            // txtMesurementType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_MesurementType(Tdetails.MeasureType_ID));
                            txtPrintMethod.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PrintMethod(Tdetails.PrintingMethod_ID));                            
                            txtTreatnmentStates.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_TreatnmentStates(Tdetails.TreatnmentStatus_ID));
                            //txtTreatnmentStates.Text = 


                            txtSealSize.Text = Tdetails.SealSize.ToString();
                            txtRemark.Text = Tdetails.Remark;
                            txtNumberOfColumns.Text = Tdetails.NoOfColour.ToString();
                            txtNumberOfBlocks.Text = Tdetails.NoOfBlock.ToString();
                            txtColour.Text = Tdetails.Colours;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dtAllRecodes.Clear();
                List<tbl_sasJobRegister> details = null;
                details = glbCustomerID.Length > 0 ? tbl_sasJobRegister.SelectAllByCustomer_ID(glbCustomerID) : tbl_sasJobRegister.SelectAll();
                foreach (tbl_sasJobRegister detail in details)
                {
                    if (detail.Job_ID != "default")
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null)
                        {
                            dtAllRecodes.Rows.Add(detail.Job_ID, clsGenaralName.getName_Item(detail.Item_ID).ToString(), clsGenaralName.getName_Customer(detail.Customer_ID).ToString(),
                            clsFormatter.FormatToNumberWithTwoDecimalPlaces(item.Width), clsFormatter.FormatToNumberWithTwoDecimalPlaces(item.Thickness),
                            clsFormatter.FormatToNumberWithTwoDecimalPlaces(item.Height), clsFormatter.FormatToNumberWithTwoDecimalPlaces(item.Gusset),
                            clsFormatter.FormatToCurrecyWithThousendSep(detail.KiloPrice));
                        }
                    }
                }
                source.DataSource = dtAllRecodes;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.ToString());
            }
            // CalculateChequeAmount();
        }

        private void CreateDataTable()
        {
            try
            {
                dtAllRecodes.Columns.Clear();
                dtAllRecodes.Columns.Add("JobID", typeof(string));
                dtAllRecodes.Columns.Add("ProductName", typeof(string));
                dtAllRecodes.Columns.Add("CustomerName", typeof(string));
                dtAllRecodes.Columns.Add("ProductWith", typeof(string));
                dtAllRecodes.Columns.Add("ThicknessGauge", typeof(string));
                dtAllRecodes.Columns.Add("ProductHeight", typeof(string));
                dtAllRecodes.Columns.Add("ProductGussest", typeof(string));
                dtAllRecodes.Columns.Add("KiloPrice", typeof(string));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #endregion

        #region BindingSource Filtering
        private void createFilterQuary(TextBox argText)
        {
            string sTemp = "";
            string sFinalQuary = "";
            //iGridCount = 1;

            if (argText.Name != "txtJobID") //doesn't use at the moment
            {
                //if (sFilteQuary.Trim().Length > 0)
                //    sFilteQuary += " AND JobID LIKE '%" + txtJobID.Text.Trim() + "%'";
                //else
                //    sFilteQuary = " JobID LIKE '%" + txtJobID.Text.Trim() + "%'";
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
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            source.Filter = "";
            sFilteQuary = "";
            ClearFields();
        } 
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["JobID", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID.Trim());
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

        #region Btn Select
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //frm_sasJobRegister.glbJobID = txtdJobCode.Text.Trim();
            //this.Close();
        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //frm_sasJobRegister.glbJobID = "";
            //this.Close();
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

        private void chkHeight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHeight.Checked)
            {
                txtProductHeight.Enabled = false;
            }
            else
            {
                txtProductHeight.Enabled = true;
                txtProductHeight.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtProductHeight);
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
    }
}
