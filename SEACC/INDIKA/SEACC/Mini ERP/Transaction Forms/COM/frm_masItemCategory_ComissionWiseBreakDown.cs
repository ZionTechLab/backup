using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
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
    public partial class frm_masItemCategory_ComissionWiseBreakDown : MettroForm
    {
        #region Class Variables

        private bool IsUpdateMode = false;

        private BindingSource SBind;
        DataTable dtItem_Category;
        #endregion

        #region Form Load

        #region Init From
        public frm_masItemCategory_ComissionWiseBreakDown()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.Com_ComissionCalculation);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        }
        #endregion

        private void frm_masItemCategory_ComissionWiseBreakDown_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorSales;

            #region Init Data Table
            dtItem_Category = new DataTable();
            dtItem_Category.Columns.Add("LineNo", typeof(int));
            dtItem_Category.Columns.Add("CategoryID", typeof(string));
            dtItem_Category.Columns.Add("CategoryName", typeof(string));
            dtItem_Category.Columns.Add("NormalSalesRate_SR", typeof(string));
            dtItem_Category.Columns.Add("DiscountedSalesRate_SR", typeof(string));
            dtItem_Category.Columns.Add("TargetForSalePeriod_SR", typeof(string));
            dtItem_Category.Columns.Add("NormalSalesRate_AM", typeof(string));
            dtItem_Category.Columns.Add("DiscountedSalesRate_AM", typeof(string));
            dtItem_Category.Columns.Add("TargetForSalePeriod_AM", typeof(string));
            dtItem_Category.Columns.Add("NormalSalesRate_SM", typeof(string));
            dtItem_Category.Columns.Add("DiscountedSalesRate_SM", typeof(string));
            dtItem_Category.Columns.Add("TargetForSalePeriod_SM", typeof(string));
            dtItem_Category.Columns.Add("NormalSalesRate_Col", typeof(string));
            dtItem_Category.Columns.Add("DiscountedSalesRate_Col", typeof(string));
            dtItem_Category.Columns.Add("TargetForSalePeriod_Col", typeof(string));
            #endregion

            #region Init Data Grid
            SBind = new BindingSource();
            dgvItemCategory.AutoGenerateColumns = false;
            SBind.DataSource = dtItem_Category;
            dgvItemCategory.DataSource = SBind;
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, true))
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    foreach (DataGridViewRow row in dgvItemCategory.Rows)
                    {
                        string sCategotyID = "";
                        decimal dNormalSalesRate_SR = 0,
                            dDiscountedSalesRate_SR = 0,
                            dTargetForSalePeriod_SR = 0,
                            dNormalSalesRate_AM = 0,
                            dDiscountedSalesRate_AM = 0,
                            dTargetForSalePeriod_AM = 0,
                            dNormalSalesRate_SM = 0,
                            dDiscountedSalesRate_SM = 0,
                            dTargetForSalePeriod_SM = 0,
                            dNormalSalesRate_Col = 0,
                            dDiscountedSalesRate_Col = 0,
                            dTargetForSalePeriod_Col = 0;

                        sCategotyID = clsValidate.ValidateGridValue(dgvItemCategory, "CategoryID", row.Index, "default");
                        dNormalSalesRate_SR = clsValidate.ValidateGridValue(dgvItemCategory, "NormalSalesRate_SR", row.Index, 0m);
                        dDiscountedSalesRate_SR = clsValidate.ValidateGridValue(dgvItemCategory, "DiscountedSalesRate_SR", row.Index, 0m);
                        dTargetForSalePeriod_SR = clsValidate.ValidateGridValue(dgvItemCategory, "TargetForSalePeriod_SR", row.Index, 0m);
                        dNormalSalesRate_AM = clsValidate.ValidateGridValue(dgvItemCategory, "NormalSalesRate_AM", row.Index, 0m);
                        dDiscountedSalesRate_AM = clsValidate.ValidateGridValue(dgvItemCategory, "DiscountedSalesRate_AM", row.Index, 0m);
                        dTargetForSalePeriod_AM = clsValidate.ValidateGridValue(dgvItemCategory, "TargetForSalePeriod_AM", row.Index, 0m);
                        dNormalSalesRate_SM = clsValidate.ValidateGridValue(dgvItemCategory, "NormalSalesRate_SM", row.Index, 0m);
                        dDiscountedSalesRate_SM = clsValidate.ValidateGridValue(dgvItemCategory, "DiscountedSalesRate_SM", row.Index, 0m);
                        dTargetForSalePeriod_SM = clsValidate.ValidateGridValue(dgvItemCategory, "TargetForSalePeriod_SM", row.Index, 0m);
                        dNormalSalesRate_Col = clsValidate.ValidateGridValue(dgvItemCategory, "NormalSalesRate_Col", row.Index, 0m);
                        dDiscountedSalesRate_Col = clsValidate.ValidateGridValue(dgvItemCategory, "DiscountedSalesRate_Col", row.Index, 0m);
                        dTargetForSalePeriod_Col = clsValidate.ValidateGridValue(dgvItemCategory, "TargetForSalePeriod_Col", row.Index, 0m);

                        tbl_comItemCategory_comissionRates oCommisionRate = tbl_comItemCategory_comissionRates.Select(sCategotyID);
                        if (oCommisionRate != null)
                        {
                            oCommisionRate.NormalSalesRate_SR = dNormalSalesRate_SR;
                            oCommisionRate.DiscountedSalesRate_SR = dDiscountedSalesRate_SR;
                            oCommisionRate.TargetForSalePeriod_SR = dTargetForSalePeriod_SR;
                            oCommisionRate.NormalSalesRate_AM = dNormalSalesRate_AM;
                            oCommisionRate.DiscountedSalesRate_AM = dDiscountedSalesRate_AM;
                            oCommisionRate.TargetForSalePeriod_AM = dTargetForSalePeriod_AM;
                            oCommisionRate.NormalSalesRate_SM = dNormalSalesRate_SM;
                            oCommisionRate.DiscountedSalesRate_SM = dDiscountedSalesRate_SM;
                            oCommisionRate.TargetForSalePeriod_SM = dTargetForSalePeriod_SM;
                            oCommisionRate.NormalSalesRate_Col = dNormalSalesRate_Col;
                            oCommisionRate.DiscountedSalesRate_Col = dDiscountedSalesRate_Col;
                            oCommisionRate.TargetForSalePeriod_Col = dTargetForSalePeriod_Col;
                            oCommisionRate.Update();
                        }
                        else
                        {
                            tbl_comItemCategory_comissionRates oCommisionRate_new =
                                new tbl_comItemCategory_comissionRates(sCategotyID, 
                                    dNormalSalesRate_SR,
                                    dDiscountedSalesRate_SR,
                                    dTargetForSalePeriod_SR,
                                    dNormalSalesRate_AM,
                                    dDiscountedSalesRate_AM,
                                    dTargetForSalePeriod_AM,
                                    dNormalSalesRate_SM,
                                    dDiscountedSalesRate_SM,
                                    dTargetForSalePeriod_SM,
                                    dNormalSalesRate_Col,
                                    dDiscountedSalesRate_Col,
                                    dTargetForSalePeriod_Col);

                            oCommisionRate_new.Insert();
                        }
                    }

                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("Saving Error", iFormID, ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    RefreshGrid();
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdateMode = false;
            RefreshGrid();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dtItem_Category.Rows.Clear();
                int iLine_no = 0;
                foreach (tbl_zItemCategory oItemCategory in tbl_zItemCategory.SelectAll().Where(r => r.ItemCategory_ID != "default"))
                {
                    tbl_comItemCategory_comissionRates oComRate =
                        tbl_comItemCategory_comissionRates.Select(oItemCategory.ItemCategory_ID);

                    dtItem_Category.Rows.Add(
                        ++iLine_no, oItemCategory.ItemCategory_ID, oItemCategory.CategoryName,
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.NormalSalesRate_SR : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.DiscountedSalesRate_SR : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.TargetForSalePeriod_SR : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.NormalSalesRate_AM : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.DiscountedSalesRate_AM : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.TargetForSalePeriod_AM : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.NormalSalesRate_SM : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.DiscountedSalesRate_SM : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.TargetForSalePeriod_SM : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.NormalSalesRate_Col : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.DiscountedSalesRate_Col : 0, 4),
                        clsFormatter.FormatDecimal(oComRate != null ? oComRate.TargetForSalePeriod_Col : 0, 4)
                    );
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion
    }
}
