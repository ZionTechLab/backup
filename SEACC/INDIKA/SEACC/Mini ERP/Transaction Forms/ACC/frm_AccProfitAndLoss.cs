using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_AccProfitAndLoss : MettroForm
    {
        
        public int iFormID;

  

        #region Form Load
        public frm_AccProfitAndLoss()
        {
            //  sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accDoubleEntrySlot);
            iFormID = clsSecurity.getFormID(FormName.accReportBuilder);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_AccProfitAndLoss_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            CusDataGridViewFormat();
            FillDetails_PNL();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

        #region Fill Details
        private void FillDetails_PNL()
        {
            int iRow;
            dgvDetail.Rows.Clear();

            foreach (tbl_accGLMaster_PNL detail in tbl_accGLMaster_PNL.SelectAll())
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;

                dgvDetail["LineNo", iRow].Value = detail.Pnl_LineNo;
                dgvDetail["glSubCatagory_ID", iRow].Value = detail.GlSubCatagory_ID;
                dgvDetail["glSubCatagoryName", iRow].Value = detail.GlSubCatagory_Name;
                dgvDetail["isTotal", iRow].Value = detail.IsTotal;
                dgvDetail["deleteRow", iRow].Value = "X";
               
                tbl_zAccGLMaster_SubCatagory oSubCatagory = tbl_zAccGLMaster_SubCatagory.Select(detail.GlSubCatagory_ID);
                if(oSubCatagory!=null)
                    dgvDetail["note", iRow].Value = oSubCatagory.Note;
            }
        }

        private void FillDetails_BS()
        {
            int iRow;
            dgvBS.Rows.Clear();

           foreach(tbl_rbInsBalanceSheet  oBS in tbl_rbInsBalanceSheet.SelectAll())
           {
               dgvBS.Rows.Add();
               iRow = dgvBS.Rows.Count - 1;

               dgvBS["TypeName", iRow].Value = oBS.DisplayName;
               dgvBS["IsMainCat", iRow].Value = true;
               dgvBS["IsType", iRow].Value = false;

              // dgvBS.Rows[iRow].Cells[1].Style.font = Color.Blue;
               dgvBS.Rows[iRow].Cells[0].Style.BackColor = Color.Gray;
               dgvBS.Rows[iRow].Cells[1].Style.BackColor = Color.Gray;
               dgvBS.Rows[iRow].Cells[2].Style.BackColor = Color.Gray;
               foreach (tbl_zAccGLMaster_MainCatagory oGLMainCAT in tbl_zAccGLMaster_MainCatagory.SelectAll().Where(p=>p.BalanceSheet_Node==oBS.Node_ID))
               {
                   foreach (tbl_zAccGLMaster_SubCatagory oGLSubCat in tbl_zAccGLMaster_SubCatagory.SelectAllByGlMainCatagory_ID(oGLMainCAT.GlMainCatagory_ID))
                   {
                       dgvBS.Rows.Add();
                       iRow = dgvBS.Rows.Count - 1;

                       dgvBS["TypeName", iRow].Value = oGLSubCat.GlSubCatagoryName;
                       dgvBS["IsSubCat", iRow].Value = true;
                       dgvBS["IsType", iRow].Value = false;

                    //   dgvBS.Rows[iRow].Cells[1].Style.ForeColor = Color.Blue;
                       dgvBS.Rows[iRow].Cells[0].Style.BackColor = Color.Silver;
                       dgvBS.Rows[iRow].Cells[1].Style.BackColor = Color.Silver;
                       dgvBS.Rows[iRow].Cells[2].Style.BackColor = Color.Silver;
                       foreach (tbl_zAccGLMaster_AccountType oGLType in tbl_zAccGLMaster_AccountType.SelectAllByGlSubCatagory_ID(oGLSubCat.GlSubCatagory_ID))
                       {
                           dgvBS.Rows.Add();
                           iRow = dgvBS.Rows.Count - 1;
                           dgvBS["TypeID", iRow].Value = oGLType.GlAccountType_ID;
                           dgvBS["TypeName", iRow].Value = oGLType.GlAccountTypeName;
                           dgvBS["Notet", iRow].Value = oGLType.Note;
                           dgvBS["IsType", iRow].Value = true;
                       }
                   }
               }
           }
        }
        #endregion

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                    if (sColName == "glSubCatagory_ID" )
                    {
                        List<string> lstParameeters = new List<string>();

                        //   lstParameeters.Add(GLCode);
                        frmSearch RowDataSearch = new frmSearch(lstParameeters);
                        List<string> lstResult = RowDataSearch.Show(Search.SubGLName_PnlOnly);
                        if (RowDataSearch.DialogResult == DialogResult.OK)
                        {
                            bool bIsAdd = true;
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                string sGlSubCatagory_ID = clsValidate.ValidateGridValue(dgvDetail, "glSubCatagory_ID", row.Index, "");
                                if (sGlSubCatagory_ID == lstResult[0])
                                {
                                    MessageBox.Show("This Sub Catagory is already added..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bIsAdd = false;
                                    break;
                                }
                            }

                            //List<tbl_accGLMaster_PNL> oPNL = tbl_accGLMaster_PNL.SelectAll().Where(p => p.GlSubCatagory_ID == lstResult[0]).ToList();
                            //if (oPNL.Count < 1)
                            //{
                            if (bIsAdd)
                            {
                                dgvDetail.CurrentRow.Cells["glSubCatagory_ID"].Value = lstResult[0];
                                dgvDetail.CurrentRow.Cells["glSubCatagoryName"].Value = lstResult[1];
                            }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("This Sub Catagory is already exist..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                    if (sColName == "deleteRow")
                    {
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Add();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                {
                    tbl_accGLMaster_PNL.DeleteAll();
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        int iLineno = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, 0);
                        string sGlSubCatagory_ID = clsValidate.ValidateGridValue(dgvDetail, "glSubCatagory_ID", row.Index, "");
                        string sGlSubCatagoryName = clsValidate.ValidateGridValue(dgvDetail, "glSubCatagoryName", row.Index, "");
                        int iNote = clsValidate.ValidateGridValue(dgvDetail, "Note", row.Index, 0);
                        bool bIsTotal = clsValidate.ValidateGridValue(dgvDetail, "isTotal", row.Index, false);

                        tbl_accGLMaster_PNL oPnlItem = new tbl_accGLMaster_PNL(iLineno, sGlSubCatagory_ID, sGlSubCatagoryName, false, bIsTotal);
                        oPnlItem.Insert();

                        tbl_zAccGLMaster_SubCatagory oSubCatagory = tbl_zAccGLMaster_SubCatagory.Select(sGlSubCatagory_ID);
                        if (oSubCatagory != null)
                        {
                            oSubCatagory.Note = iNote;
                            oSubCatagory.Update();
                        }
                    }
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDetails_PNL();
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_PNL)
                FillDetails_PNL();
            else
                FillDetails_BS();
        }

        private void btnSaveBS_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
                {
                    foreach (DataGridViewRow row in dgvBS.Rows)
                    {
                        bool bIsType = false;
                        try
                        {
                             bIsType = clsValidate.ValidateGridValue(dgvBS, "IsType", row.Index, false);
                        }
                        catch (Exception)
                        {
                        }
                        if (bIsType)
                        {
                            string sGlType_ID = clsValidate.ValidateGridValue(dgvBS, "TypeID", row.Index, "");
                            int iNote = clsValidate.ValidateGridValue(dgvBS, "Notet", row.Index, 0);

                            tbl_zAccGLMaster_AccountType oType = tbl_zAccGLMaster_AccountType.Select(sGlType_ID);
                            if (oType != null)
                            {
                                oType.Note = iNote;
                                oType.Update();
                            }
                        }
                    }
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDetails_BS();
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void dgvDetail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
         //   if (!(char.IsDigit(e.KeyCode) )
           //     e.Handled = true;
        }
    }
}