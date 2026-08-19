using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frm_pmsSectionViwer : Form
    {

        
        //to manage update and insert
      //  static bool IsUpdate = false;

        //to keep form detail       
      //  string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        public string glbSectionID = "";
    

        #region Form Load
        public frm_pmsSectionViwer()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerSectionViwer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            ClearFields();
            if (glbSectionID.Length > 0)
            {
                FillDetails(glbSectionID);
                RefreshGridPlanning();
                RefreshGridSectionStock();
                RefreshGridDepartmentStock();
            }
            CusDataGridViewFormat();
        } 
        #endregion


        #region Btn Refresh
        private void Refresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbSectionID.Length > 0)
                FillDetails(glbSectionID);
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetailSection, Color.FromArgb(240, 190, 210), Color.FromArgb(99, 50, 50));
            clsFormatter.ApplyGridFormat(dgvDetailStore, Color.FromArgb(240, 190, 210), Color.FromArgb(99, 50, 50));
            clsFormatter.ApplyGridFormat(dgvSectionEmployees, Color.FromArgb(240, 190, 210), Color.FromArgb(99, 50, 50));
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblContactPerson.Text = "";
            lblSectionCode.Text = "";
            lblSectionName.Text = "";
            lblTelephone.Text = "";
            lblFaxNo.Text = "";
            lblAddress.Text = "";
            lblRelatedDepartment.Text = "";       
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sSectionID)
        {
            tbl_genSectionMaster detail = tbl_genSectionMaster.Select(sSectionID);
            if (detail != null && detail.Section_ID != "default")
            {
                lblContactPerson.Text = detail.ContactPerson;
                lblSectionCode.Text = detail.Section_ID;
                lblSectionName.Text = detail.SectionName;
                lblTelephone.Text = detail.Telephone;
                lblFaxNo.Text = detail.Fax;
                lblAddress.Text = detail.Adress;
                lblRelatedDepartment.Text = detail.Department_ID;
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridPlanning()
        {
            try
            {
                int iRow;
                dgvDetailStore.Rows.Clear();
                //foreach (tbl_pmsPrePlan_SectionPath detail in tbl_pmsPrePlan_SectionPath.SelectAllBySection_ID(glbSectionID).Where(p => !p.IsJobClosed && p.PrePlan_ID != "default").OrderBy(p=>p.PlanDate))
                //{                   
                //    dgvDetailStore.Rows.Add();
                //    iRow = dgvDetailStore.Rows.Count - 1;
                //    dgvDetailStore["PrePlanID", iRow].Value = detail.PrePlan_ID;
                //    dgvDetailStore["PrePlanDate", iRow].Value = detail.PlanDate.ToString("dd MMM yyyy");
                //    dgvDetailStore["ShiftName", iRow].Value = clsGenaralName.getName_Shift(detail.Shift_ID);
                //    dgvDetailStore["TotalHours", iRow].Value = detail.TotalHours;
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshGridSectionStock()
        {
            try
            {
                int iRow;
                dgvDetailSection.Rows.Clear();
                List<tbl_genSection_Stock> SoreStokeDetails = tbl_genSection_Stock.SelectAllBySection_ID(glbSectionID);
                foreach (tbl_genSection_Stock detail in SoreStokeDetails)
                {
                    if (detail.Section_ID != "default")
                    {
                        dgvDetailSection.Rows.Add();
                        iRow = dgvDetailSection.Rows.Count - 1;
                        dgvDetailSection["ItmeID", iRow].Value = detail.Item_ID;
                        dgvDetailSection["ItemionName", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                        dgvDetailSection["SectionAvailableQuantity", iRow].Value = detail.Qty;
                        dgvDetailSection["SectionActualQuantity", iRow].Value = detail.Weight;
                        dgvDetailSection["SectionDamagedQuantity", iRow].Value = detail.DamageWeight;
                        dgvDetailSection["SectionWasteageQuantity", iRow].Value = detail.WasteageWeight;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshGridDepartmentStock()
        {
            try
            {
                //int iRow;
                //dgvDetailDepatment.Rows.Clear();
                //List<tbl_genDepartment_Stock> SoreStokeDetails = tbl_genDepartment_Stock.SelectAllByItem_ID(glbItemID);
                //foreach (tbl_genDepartment_Stock detail in SoreStokeDetails)
                //{
                //    if (detail.Department_ID != "default")
                //    {
                //        dgvDetailDepatment.Rows.Add();
                //        iRow = dgvDetailDepatment.Rows.Count - 1;
                //        dgvDetailDepatment["DepartmentID", iRow].Value = detail.Department_ID;
                //        dgvDetailDepatment["DepartmentName", iRow].Value = clsGenaralName.getName_Department(detail.Department_ID);
                //        dgvDetailDepatment["DepartmentAvailableQuantity", iRow].Value = detail.AvailableQty;
                //        dgvDetailDepatment["DepartmentActualQuantity", iRow].Value = detail.ActualQty;
                //        dgvDetailDepatment["DepartmentDamagedQuantity", iRow].Value = detail.DamageQty;
                //        dgvDetailDepatment["DepartmentWasteageQuantity", iRow].Value = detail.WasteageQty;
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
