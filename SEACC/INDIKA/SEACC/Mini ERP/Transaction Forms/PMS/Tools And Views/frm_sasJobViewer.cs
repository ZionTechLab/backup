using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_sasJobViewer : Form
    {
        
        //to manage update and insert
        static bool IsUpdate = false;

        //form manage
        string sFormConfigCode;
        public string glbJobID;
        public string glbProductionJobID;
        string ItemID;

           public int iFormID;
        public bool bNoAccess;
        int iRow;
     

        #region Form Load
        public frm_sasJobViewer()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.JobViewer);
            iFormID = clsSecurity.getFormID(FormName.JobViewer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_sasJobViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Job Viewer", 2, iFormID);
            ClearFields();
            FillDetails(glbJobID);
            RefreshGridMaterial(glbJobID);
            CusDataGridViewFormat();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetailMaterial, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblCustomerName.Text = "";
            lblSalseRep.Text = "";
            lblSalseRep.Text = "";
            lblJobCategory.Text = "";
            lblProductName.Text = "";
            lblProductWidth.Text = "";
            lblThickness.Text = "";
            lblRemarks.Text = "";
            lblGussest.Text = "";
            lblHeight.Text = "";
            lblOrderedUOM.Text = "";
            lblQuantity.Text = "";
            lblTotalWeight.Text = "";
            lblSlittingType.Text = "";
            lblSealingType.Text = "";
            lblPolytheneType.Text = "";
            lblMesurementType.Text = "";
            lblLaminationType.Text = "";
            lblTreatnmentStates.Text = "";
            lblPouchType.Text = "";
            lblInstructions.Text = "";
            lblPrintingType.Text = "";
            lblPrintingMethod.Text = "";
            lblColour.Text = "";
            lblNoOfColumns.Text = "";
            lblNoOfBlocks.Text = "";
            lblProductCode.Text = "";
            lblJobCode.Text = "";
            lblJobDate.Text = "";
            lblProductionJobCategory.Text = "";
            lblProductionJobDate.Text = "";
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
                    tbl_sasJobRegister_ProductDetail Tdetails = tbl_sasJobRegister_ProductDetail.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;

                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null)
                        {
                            decimal dTransval = 1;
                            tbl_zJobMeasurementType measurment = tbl_zJobMeasurementType.Select(item.MeasureType_ID);
                            if (measurment != null)
                                dTransval = measurment.TranslateValue;
                            lblJobCode.Text = sID;
                            lblCustomerName.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                            lblSalseRep.Text = clsGenaralName.getName_SalesRep(detail.SelesRep_ID);
                            lblJobCategory.Text = detail.JobCategory_ID;
                            lblJobDate.Text = detail.JobDate.ToString("dd MMM yyyy");
                            lblProductCode.Text = detail.Item_ID;
                            lblProductName.Text = clsGenaralName.getName_Item(detail.Item_ID);
                            lblProductWidth.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces((item.Width/dTransval));
                            lblThickness.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(item.Thickness);
                            lblRemarks.Text = Tdetails.Remark;
                            lblGussest.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces((item.Gusset/dTransval));
                            lblHeight.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces((item.Height/dTransval));
                            lblOrderedUOM.Text = clsGenaralName.getName_Uom(detail.Uom_ID);
                            lblQuantity.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.Qty);
                            lblTotalWeight.Text = detail.Weight.ToString();
                            lblSlittingType.Text = clsGenaralName.getName_SlittingType(Tdetails.SlittingType_ID);
                            lblSealingType.Text = clsGenaralName.getName_SealingType(Tdetails.SealingType_ID);
                            lblPolytheneType.Text = clsGenaralName.getName_PolytheneType(Tdetails.PolytheneType_ID);
                            lblMesurementType.Text = clsGenaralName.getName_MesurementType(Tdetails.MeasureType_ID);
                            lblLaminationType.Text = clsGenaralName.getName_LaminationType(Tdetails.LaminationType_ID);
                            lblTreatnmentStates.Text = clsGenaralName.getName_TreatnmentStates(Tdetails.TreatnmentStatus_ID);
                            lblPouchType.Text = clsGenaralName.getName_PouchType(Tdetails.PouchType_ID);
                            lblInstructions.Text = Tdetails.InstructionDetail;
                            lblPrintingType.Text = clsGenaralName.getName_PrintingType(Tdetails.PrintingType_ID);
                            lblPrintingMethod.Text = clsGenaralName.getName_PrintMethod(Tdetails.PrintingMethod_ID);                            
                            lblSealSize.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(Tdetails.SealSize);
                            lblColour.Text = Tdetails.Colours;
                            lblNoOfColumns.Text = Tdetails.NoOfColour.ToString();
                            lblNoOfBlocks.Text = Tdetails.NoOfBlock.ToString();
                            

                            //tbl_pmsProductionJobRegister pdetail = tbl_pmsProductionJobRegister.Select(glbProductionJobID);
                            //if (pdetail != null)
                            //{
                            //    lblProductionJobCategory.Text = clsGenaralName.getName_ProductionJobType(pdetail.ProductionJobType_ID);
                            //    lblProductionJobDate.Text = pdetail.StartDate.ToString("dd MMM yyyy");
                            //}
                            if (Tdetails.Image != null)
                            {
                                if (Tdetails.Image.Length > 0)
                                {
                                    MemoryStream ms = new MemoryStream(Tdetails.Image);
                                    pbxImage.Image = Image.FromStream(ms);
                                }
                                else
                                {
                                    pbxImage.Image = pbxImage.InitialImage;
                                }
                            }
                            else
                            {
                                pbxImage.Image = pbxImage.InitialImage;
                            }

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

        #region Refresh Gird
        private void RefreshGridMaterial(string sJobID)
        {
            try
            {
                int iRow;
                dgvDetailMaterial.Rows.Clear();
                //List<tbl_sasJobRegister_Material> details = tbl_sasJobRegister_Material.SelectAllByJob_ID(sJobID);
                //foreach (tbl_sasJobRegister_Material detail in details)
                //{
                //    dgvDetailMaterial.Rows.Add();
                //    iRow = dgvDetailMaterial.Rows.Count - 1;

                //    if (detail.IsLamination)
                //    {
                //        dgvDetailMaterial["ItemCode", iRow].Value = detail.LaminationMaterailType_ID;
                //        dgvDetailMaterial["ItemName", iRow].Value = clsGenaralName.getName_LaminationMaterailType(detail.LaminationMaterailType_ID);
                //    }
                //    else if (detail.IsPolythine)
                //    {
                //        dgvDetailMaterial["ItemCode", iRow].Value = detail.PolytheneMaterailType_ID;
                //        dgvDetailMaterial["ItemName", iRow].Value = clsGenaralName.getName_PolytheneMaterailType(detail.PolytheneMaterailType_ID);
                //    }
                //    dgvDetailMaterial["IsLamination", iRow].Value = detail.IsLamination;
                //    dgvDetailMaterial["isPolythine", iRow].Value = detail.IsPolythine;
                //    dgvDetailMaterial["Weight", iRow].Value = clsFormatter.FormatToCurrecyWithThreeDecimalPlaces(detail.Width);
                //    dgvDetailMaterial["Thickness", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.Thickness);
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }



    }
}
