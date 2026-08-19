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
using System.IO;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_mtrChequeFormat : MettroForm
    {
        #region Variables

        public DataTable dtChequeDetail = new DataTable();
        private BindingSource sourceChequeDetail = new BindingSource();

        string sValue;
        #endregion

        #region Form Load
        public frm_mtrChequeFormat()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ZChequeFormat);
            iFormID = clsSecurity.getFormID(FormName.ZChequeFormat);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();

            #region DataTable Initialize
            dtChequeDetail.Columns.Add("element_ID");
            dtChequeDetail.Columns.Add("element_description");
            dtChequeDetail.Columns.Add("FontType");
            dtChequeDetail.Columns.Add("FontType_ID");
            dtChequeDetail.Columns.Add("xValue");
            dtChequeDetail.Columns.Add("yValue");
            dtChequeDetail.Columns.Add("length");
            #endregion
        }
        private void frm_mtrChequeFormat_Load(object sender, EventArgs e)
        {
            if (clsSecurity.UserIDLoged == "digiteq")
            {
                this.Height = 715;
                btnProcess.Visible = true;
            }
            else
            {
                btnProcess.Visible = false;
                this.Height = 475;
            }

            CusDataGridViewFormat();
            ClearFields();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtChequeFormatID.TextLength > 0)
                {
                    if (CheckValidity())
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_zChequeFormat detail = tbl_zChequeFormat.Select(int.Parse(txtChequeFormatID.Tag.ToString()));
                            if (detail != null)
                            {
                                detail.Delete();
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtChequeFormatID.Text, TxnActivity.Cancel);
                            }

                            Cursor = Cursors.Default;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            RefreshGrid();
                        }
                        else //if no permission to delete
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                if (sqlException.Number == 547)
                    MessageBox.Show("Unable to delete the recode.\nPlease remove Item Master references befor delete seleted data. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    clsValidate.WriteErrorLog(sqlException.Message, iFormID, null);
                    SEACCException.Show(sqlException);
                }
            }
            catch (Exception ex)
            {

                SEACCException.Show(ex);
            }
            finally { Cursor = Cursors.Default; }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        if (txtChequeFormatCode.TextLength > 0)
                        {
                            if (IsUpdate)
                            {
                                tbl_zChequeFormat oldRecord = tbl_zChequeFormat.Select(Convert.ToInt32(txtChequeFormatID.Tag.ToString()));
                                if (oldRecord != null)
                                {
                                    //update Format Header
                                    tbl_zChequeFormat detail = new tbl_zChequeFormat(Convert.ToInt32(txtChequeFormatID.Tag.ToString()), txtChequeFormatCode.Text.Trim(), txtDescription.Text.Trim(), int.Parse(txtXmargin.Text.Trim()), int.Parse(txtYmargin.Text.Trim()), true, int.Parse(txtCounterBookLength.Text.Trim()));
                                    detail.Update();                             
                                    foreach (DataGridViewRow row in dgvChequeDetail.Rows)
                                    {
                                        int iElement_id = 0, iFontid = 0, iXvalue = 0, iYvalue = 0, iLength = 0;
                                        string sElementDes = "";

                                        iElement_id = clsValidate.ValidateGridValue(dgvChequeDetail, "element_ID", row.Index, int.Parse("0"));
                                        iFontid = clsValidate.ValidateGridValue(dgvChequeDetail, "FontType_ID", row.Index, int.Parse("0"));
                                        iXvalue = clsValidate.ValidateGridValue(dgvChequeDetail, "xValue", row.Index, int.Parse("0"));
                                        iYvalue = clsValidate.ValidateGridValue(dgvChequeDetail, "yValue", row.Index, int.Parse("0"));
                                        iLength = clsValidate.ValidateGridValue(dgvChequeDetail, "length", row.Index, int.Parse("0"));

                                        sElementDes = clsValidate.ValidateGridValue(dgvChequeDetail, "element_description", row.Index, ("default"));

                                        tbl_zChequeFormat_Detail details = new tbl_zChequeFormat_Detail(int.Parse(txtChequeFormatID.Tag.ToString()), iElement_id, sElementDes, iFontid, iXvalue, iYvalue, iLength);
                                        details.Update();
                                    }
                                    clsHelpMethods.InsertTransactionHistory(iFormID, txtChequeFormatID.Text, TxnActivity.Update);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else  //insert records
                            {
                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    txtChequeFormatID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                tbl_zChequeFormat detail = new tbl_zChequeFormat(Convert.ToInt32(txtChequeFormatID.Text.Trim()), txtChequeFormatCode.Text.Trim(), txtDescription.Text.Trim(), int.Parse(txtXmargin.Text.Trim()), int.Parse(txtYmargin.Text.Trim()), true, int.Parse(txtCounterBookLength.Text.Trim()));
                                detail.Insert();

                                //insert Format Detail
                                #region Data Grid Save
                                foreach (DataGridViewRow row in dgvChequeDetail.Rows)
                                {
                                    int iElement_id = 0, iFontid = 0, iXvalue = 0, iYvalue = 0, iLength = 0;
                                    string sElementDes = "";

                                    iElement_id = clsValidate.ValidateGridValue(dgvChequeDetail, "element_ID", row.Index, int.Parse("0"));
                                    iFontid = clsValidate.ValidateGridValue(dgvChequeDetail, "FontType_ID", row.Index, int.Parse("0"));
                                    iXvalue = clsValidate.ValidateGridValue(dgvChequeDetail, "xValue", row.Index, int.Parse("0"));
                                    iYvalue = clsValidate.ValidateGridValue(dgvChequeDetail, "yValue", row.Index, int.Parse("0"));
                                    iLength = clsValidate.ValidateGridValue(dgvChequeDetail, "length", row.Index, int.Parse("0"));

                                    sElementDes = clsValidate.ValidateGridValue(dgvChequeDetail, "element_description", row.Index, ("default"));

                                    tbl_zChequeFormat_Detail details = new tbl_zChequeFormat_Detail(int.Parse(txtChequeFormatID.Text.Trim()), iElement_id, sElementDes, iFontid, iXvalue, iYvalue, iLength);
                                    details.Insert();
                                }
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtChequeFormatID.Text, TxnActivity.Insert);
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                #endregion
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cheque Format ID " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        ClearFields();
                    }
                }
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvChequeDes);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtChequeFormatID.Text = "<Auto Generate>";
            else
                txtChequeFormatID.Clear();

            txtChequeFormatID.Tag = null;
            txtChequeFormatCode.Clear();
            txtDescription.Clear();
            ChequeFormatDetail();
            txtXmargin.Clear();
            txtYmargin.Clear();
            txtCounterBookLength.Clear();
            RefreshGrid();
            txtChequeFormatCode.Enabled = true;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvChequeDes.Rows.Clear();
            foreach (tbl_zChequeFormat detail in tbl_zChequeFormat.SelectAll().Where(p => p.ChequeFormat_ID != -1))
            {
                dgvChequeDes.Rows.Add();
                iRow = dgvChequeDes.Rows.Count - 1;
                dgvChequeDes["ChequeFormat_ID", iRow].Value = detail.ChequeFormat_ID;
                dgvChequeDes["ChequeFormat_Code", iRow].Value = detail.ChequeFormat_Code;
                dgvChequeDes["ChequeFormatDescription", iRow].Value = detail.ChequeFormat_Desc;
            }
        }        

        #region Referesh GridCheque Detail
        private void RefreshGridChequeDetail(int FormatiD)
        {
            int iRow;
            dtChequeDetail.Clear();

            foreach (tbl_zChequeFormat_Detail detail in tbl_zChequeFormat_Detail.SelectAll().Where(p => p.ChequeFormat_ID == FormatiD))
            {
                dtChequeDetail.Rows.Add(detail.Element_ID, detail.Element_Desc, clsGenaralName.getName_FontTypeName(detail.FontType_ID.ToString()), detail.FontType_ID, detail.XValue, detail.YValue, detail.Length);
            }
            dgvChequeDetail.DataSource = dtChequeDetail;
        }
        #endregion
        #endregion

        #region Fill Details
        private void FillDetails(int sID)
        {
            if (sID > 0)
            {
                tbl_zChequeFormat detail = tbl_zChequeFormat.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    //asign values
                    txtChequeFormatID.Tag = detail.ChequeFormat_ID;
                    txtChequeFormatID.Text = detail.ChequeFormat_ID.ToString();
                    txtChequeFormatCode.Text = detail.ChequeFormat_Code;
                    txtDescription.Text = detail.ChequeFormat_Desc;
                    txtXmargin.Text = detail.XMargin.ToString();
                    txtYmargin.Text = detail.YMargin.ToString();
                    txtCounterBookLength.Text = detail.CounterBookLength.ToString();
                    RefreshGridChequeDetail(sID);
                    txtChequeFormatCode.Enabled = false;
                }
            }
        }
        #endregion

        #region Event Datagrid
        private void dgvChequeDes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvChequeDes_CellClick(sender, e);
        }
        private void dgvChequeDes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int sID = int.Parse(dgvChequeDes["ChequeFormat_ID", e.RowIndex].Value.ToString());
                    if (sID > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID);
                        txtChequeFormatCode.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvChequeDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    dgvChequeDetail["xValue", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvChequeDetail, "xValue", e.RowIndex, 0);
                    dgvChequeDetail["yValue", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvChequeDetail, "yValue", e.RowIndex, 0);
                    dgvChequeDetail["length", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvChequeDetail, "length", e.RowIndex, 0);

                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", 0,ex);
                    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvChequeDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sColName = "", sFontType = "", sFontType_ID = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvChequeDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "FontType")
                {
                    clsSearch.Search_FontType(ref sFontType_ID, ref sFontType);

                    if (sFontType.Length > 0)
                        dgvChequeDetail["FontType_ID", e.RowIndex].Value = sFontType;
                    if (sFontType_ID.Length > 0)
                    {
                        dgvChequeDetail["FontType_ID", e.RowIndex].Value = sFontType_ID;
                        dgvChequeDetail["FontType", e.RowIndex].Value = sFontType;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvChequeDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    string sColName = "", sFontType = "", sFontType_ID = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvChequeDetail.Columns[e.ColumnIndex].Name;

                    if (sColName == "FontType")
                    {
                        clsSearch.Search_FontType(ref sFontType_ID, ref sFontType);
                        
                        foreach (DataRow dr in dtChequeDetail.Rows)
                        {
                            dr["FontType_ID"] = sFontType_ID;
                            dr["FontType"] = sFontType;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvChequeDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvChequeDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "xValue" || sColName == "yValue" || sColName == "length")
                {
                    if (!clsCommon.isCurrency(e.Value.ToString()))
                        MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, e.Value.ToString()), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Events DoubleClick
        private void txtChequeFormatCode_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeFormtID();
            txtChequeFormatCode.Enabled = false;
        }
        #endregion

        #region Events KeyPress
        private void txtXmargin_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        private void txtYmargin_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bIsOk = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_ExistingData())
                {
                    bIsOk = true;
                }
            }

            return bIsOk;

        }
        #endregion

        #region Validate Existing Records
        private bool CheckValidity_ExistingData()
        {
            bool bStatus = true;
            if (!IsUpdate)
            {
                foreach (tbl_zChequeFormat detail in tbl_zChequeFormat.SelectAll())
                {
                    if (txtChequeFormatID.Text == detail.ChequeFormat_ID.ToString() || txtChequeFormatCode.Text == detail.ChequeFormat_Code)
                    {
                        bStatus = false;
                    }
                }
                if (bStatus == false)
                {
                    MessageBox.Show("This Format ID is already added", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return bStatus;
        }
        #endregion

        #region Validate Empty Fields
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtChequeFormatCode, "Cheque Format Code"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtDescription, "Cheque Format Description"))
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }
        #endregion

        #region Cheque Detail DataTable
        private void ChequeFormatDetail()
        {
            dtChequeDetail.Clear();

            #region Rows Define
            dtChequeDetail.Rows.Clear();
            dtChequeDetail.Rows.Add("0", "Payee Line One", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("1", "Payee Line Two", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("2", "Payee Line Three", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("3", "Payee Line Four", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("4", "Payee", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("5", "Amount Line One", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("6", "Amount Line Two", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("7", "Rupee Line One", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("8", "Rupee Line Two", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("9", "Rupee Line Three", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("10", "Date Value", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("11", "Day Value One", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("12", "Day Value Two", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("13", "Month Value One", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("14", "Month Value Two", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("15", "Year Value One", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("16", "Year Value Two", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("17", "Year Value Three", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("18", "Year Value Four", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("19", "Accout Payee", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("20", "Top Line", "", "-1", "0", "0", "0");
            dtChequeDetail.Rows.Add("21", "Bottom Line", "", "-1", "0", "0", "0");
            #endregion

            dgvChequeDetail.DataSource = dtChequeDetail;
        }
        #endregion

        #region Search Methods
        private void Search_ChequeFormtID()
        {
            clsSearch.Search_ChequeFormat(ref txtChequeFormatCode);
            if (txtChequeFormatCode.Tag != null && txtChequeFormatCode.TextLength > 0)
            {
                FillDetails(int.Parse(txtChequeFormatCode.Tag.ToString()));
            }
        }





        #endregion

        #region Btn Process
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtChequeFormatID.Tag != null && txtChequeFormatID.Tag.ToString().Length > 0)
            {
                //string sAccountPayee = "** Account Payee Only **" , sUnderline = "______________________";

                #region Intialize Array
                int[] x = new int[22];
                int[] y = new int[22];
                Font[] font = new Font[22];
                #endregion

                int i_Xvalue = 0, i_Yvalue = 0;
                tbl_zChequeFormat oFormat = tbl_zChequeFormat.Select(int.Parse(txtChequeFormatID.Text.Trim()));
                if (oFormat != null && oFormat.IsActive == true && oFormat.ChequeFormat_ID != -1)
                {
                    i_Xvalue = oFormat.XMargin;
                    i_Yvalue = oFormat.YMargin;

                    #region Fill Formats
                    foreach (tbl_zChequeFormat_Detail oFormats in tbl_zChequeFormat_Detail.SelectAll().Where(p => p.ChequeFormat_ID == oFormat.ChequeFormat_ID))
                    {
                        tbl_zFont oFont = tbl_zFont.Select(oFormats.FontType_ID.ToString());
                        Font Font = new Font(oFont.FontName, oFont.Size);

                        x[oFormats.Element_ID] = oFormats.XValue;
                        y[oFormats.Element_ID] = oFormats.YValue;
                        font[oFormats.Element_ID] = Font;
                    }
                    #endregion

                    #region Print Cheque
                    lblLine1.Location = new Point(i_Xvalue + x[20], i_Yvalue + y[20]);
                    lblAccountPayee.Location = new Point(i_Xvalue + x[19], i_Yvalue + y[19]);
                    lblLine2.Location = new Point(i_Xvalue + x[21], i_Yvalue + y[21]);

                    lblCBDate.Font = font[20];
                    lblCBPayee1.Font = font[19];
                    lblCBPayee2.Font = font[21];

                    #region Counter Book
                    lblCBDate.Location = new Point(i_Xvalue + x[10], i_Yvalue + y[10]);
                    lblCBPayee1.Location = new Point(i_Xvalue + x[0], i_Yvalue + y[0]);
                    lblCBPayee2.Location = new Point(i_Xvalue + x[1], i_Yvalue + y[1]);
                    lblCBPayee3.Location = new Point(i_Xvalue + x[2], i_Yvalue + y[2]);
                    lblCBPayee4.Location = new Point(i_Xvalue + x[3], i_Yvalue + y[3]);
                    lblAmountCB.Location = new Point(i_Xvalue + x[5], i_Yvalue + y[5]);

                    lblCBDate.Font = font[10];
                    lblCBPayee1.Font = font[0];
                    lblCBPayee2.Font = font[1];
                    lblCBPayee3.Font = font[2];
                    lblCBPayee4.Font = font[3];
                    lblAmountCB.Font = font[5];
                    #endregion

                    #region Cheque Area
                    lblPayee.Location = new Point(i_Xvalue + x[4], i_Yvalue + y[4]);
                    lblAmountWordLine1.Location = new Point(i_Xvalue + x[7], i_Yvalue + y[7]);
                    lblAmountWordLine2.Location = new Point(i_Xvalue + x[8], i_Yvalue + y[8]);
                    lblAmountWordLine3.Location = new Point(i_Xvalue + x[9], i_Yvalue + y[9]);
                    lblDay1.Location = new Point(i_Xvalue + x[11], i_Yvalue + y[11]);
                    lblDay2.Location = new Point(i_Xvalue + x[12], i_Yvalue + y[12]);
                    lblMonth1.Location = new Point(i_Xvalue + x[13], i_Yvalue + y[13]);
                    lblMonth2.Location = new Point(i_Xvalue + x[14], i_Yvalue + y[14]);
                    lblYear3.Location = new Point(i_Xvalue + x[17], i_Yvalue + y[17]);
                    lblYear4.Location = new Point(i_Xvalue + x[18], i_Yvalue + y[18]);
                    lblAmount.Location = new Point(i_Xvalue + x[6], i_Yvalue + y[6]);

                    lblPayee.Font = font[4];
                    lblAmountWordLine1.Font = font[7];
                    lblAmountWordLine2.Font = font[8];
                    lblAmountWordLine3.Font = font[9];
                    lblDay1.Font = font[11];
                    lblDay2.Font = font[12];
                    lblMonth1.Font = font[13];
                    lblMonth2.Font = font[14];
                    lblYear3.Font = font[17];
                    lblYear4.Font = font[18];
                    lblAmount.Font = font[6];
                    #endregion
                    #endregion
                }
            }
        } 
        #endregion
    }
}
