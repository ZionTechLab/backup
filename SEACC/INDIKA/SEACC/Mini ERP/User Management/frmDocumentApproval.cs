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
    public partial class frmDocumentApproval : Form
    {

        
        //to manage update and insert
        static bool IsUpdate = false;        
      
        //to keep form detail       
           public int iFormID;       
        
        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime(); 

        private string sFilteQuary = "";

        int i_locX = 0, i_locY = 0, i_cnt = 0, i_columns = 2;  
 

        #region Form Load
        public frmDocumentApproval()
        {
            iFormID = clsSecurity.getFormID(FormName.PendingApproval);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frmGroupApproval_Load(object sender, EventArgs e)
        {          
            clsFormatter.setFormatForm(this, "Document Approval ", 2, iFormID);
            ClearFields();
            CusDataGridViewFormat();

            txtUnApprovedUnChecked.ForeColor = clsFormatter.colorStatusUnApprovedUnChecked;
            txtUnApproved.ForeColor = clsFormatter.colorStatusUnApproved;
            txtUnChecked.ForeColor = clsFormatter.colorStatusUnChecked;
            txtCancelled.ForeColor = clsFormatter.colorStatusCancelled;
            txtApproveChecked.ForeColor = clsFormatter.colorStatusApprovedChecked;

            lblUserName.Text = "User ID : " + clsSecurity.UserIDLoged + "   User Name : " + clsGenaralName.getName_User(clsSecurity.UserIDLoged);
            LoadCategory();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();            
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
                        ValidateEmptyForeignKey();
                        if (IsUpdate)  //update records
                        {

                        }
                        else  //insert records
                        {
                            #region Insert
                            if (txtAuditCode.Text.Trim().Length > 0)
                            {
                                //Document Audid                                
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    try
                                    {
                                        string sNoteID = "";
                                        bool bChecked = false;
                                        if (dgvDetail["Check", row.Index].Value != null)
                                            bChecked = bool.Parse(dgvDetail["Check", row.Index].Value.ToString());
                                        sNoteID = clsValidate.ValidateGridValue(dgvDetail, "NoteNumber", row.Index, "default");

                                        if (bChecked && sNoteID.Length > 0 && sNoteID != "default")
                                        {
                                            #region Sales
                                            if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder).ToString())
                                            {
                                                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder).ToString())
                                            {
                                                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.Invoice).ToString())
                                            {
                                                tbl_sasInvoice detail = tbl_sasInvoice.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            } 
                                            #endregion

                                            #region Stock
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseOrder).ToString())
                                            {
                                                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodReceivedNote).ToString())
                                            {
                                                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodIssuedNote).ToString())
                                            {
                                                tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseReturned).ToString())
                                            {
                                                tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseRequisition).ToString())
                                            {
                                                tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.StockAdjustment).ToString())
                                            {
                                                tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ItemSplitNote).ToString())
                                            {
                                                tbl_scsItemSpred detail = tbl_scsItemSpred.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.DamageGoodNote).ToString())
                                            {
                                                tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.DisGoodNote).ToString())
                                            {
                                                tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iGRN_Store).ToString())
                                            {
                                                tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iGIN_Store).ToString())
                                            {
                                                tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Store).ToString())
                                            {
                                                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.GoodsTransferNote).ToString())
                                            {
                                                tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.FinishedGoodsTransferNote).ToString())
                                            {
                                                tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            #endregion

                                            #region Bills
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.Receipt).ToString())
                                            {
                                                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();

                                                    List<tbl_bpsChequeRegister> cheques = tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID);
                                                    foreach (tbl_bpsChequeRegister cheque in cheques)
                                                    {
                                                        //  cheque.IsApproved = true;
                                                        //  cheque.DateApproved = clsSecurity.getServerDateTime();
                                                        //  cheque.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                        cheque.Update();
                                                    }
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned).ToString())
                                            {
                                                string sCreditNoteID = "";
                                                clsProcessMethods.Update_Approval_SRN(sNoteID, clsSecurity.UserIDLoged, ref sCreditNoteID, true);
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.CreditNote).ToString())
                                            {
                                                tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.Cheque).ToString())
                                            {
                                                tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    //   detail.IsApproved = true;
                                                    //  detail.DateApproved = clsSecurity.getServerDateTime();
                                                    //  detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            } 
                                            #endregion

                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ProductionJob).ToString())
                                            {
                                                //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(sNoteID);
                                                //if (detail != null)
                                                //{
                                                //    detail.IsApproved = true;
                                                //    detail.DateApproved = clsSecurity.getServerDateTime();
                                                //    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                //    detail.Update();

                                                //      clsAlerts_Email.createEmail_ProductionJobConfirmed(detail.ProductionJob_ID);
                                                //}
                                            }
                                            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Dept).ToString())
                                            {
                                                tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(sNoteID);
                                                if (detail != null)
                                                {
                                                    detail.IsApproved = true;
                                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID,ex);
                                        SEACCException.Show(ex);
                                    }//error may come because last row of the grid may not have information
                                }                            
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Document Audit Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        SEACCException.Show(ex);
                        clsValidate.WriteErrorLog("", iFormID,ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;                        
                        ClearFields();

                        //assing pending approval count to label in the main form
                        foreach (Control con in this.MdiParent.Controls)
                        {
                            if (con is StatusStrip)
                            {
                                StatusStrip stp = (StatusStrip)con;
                                foreach (ToolStripItem item in stp.Items)
                                {
                                  //  if (item.Name == "tslPendingApproval")
                                      //  item.Text = clsHelpMethods_Local.GetPendingApprovalCount().ToString();
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        
        #region Load Category
        private void LoadCategory()
        {
            //set the values
            this.i_locX = 5;
            this.i_locY = 5;
            this.i_cnt = 0;
            this.i_columns = 3;
            //clear the pannel
            xPnlCategory.Controls.Clear();

            List<tbl_securityProcessNoteCatogory> details = tbl_securityProcessNoteCatogory.SelectAll().Where(p=> p.IsEnable_bulkApprove).ToList();
            foreach (tbl_securityProcessNoteCatogory detail in details)
            {
                if (detail.ProcessNoteCategory_ID != 0)
                {
                    Button btnCategory = new Button();
                    FillCategory(detail, btnCategory, 95);
                    btnCategory.Click += new EventHandler(CategoryClick);
                    btnCategory.MouseLeave += new EventHandler(Text_MouseLeave);
                    btnCategory.MouseMove += new MouseEventHandler(Text_MouseMove);
                }
            }
        }
        #endregion

        #region Fill Category
        private void FillCategory(tbl_securityProcessNoteCatogory Category, Button btnCategory, int width)
        {
            try
            {
                btnCategory.Size = new Size(width, 36);
                btnCategory.Font = new Font("calibri", 8, FontStyle.Bold); //clsCommon.defaultFont;
                btnCategory.Name = Category.ProcessNoteCategory_ID.ToString();
                btnCategory.Text = Category.ProcessNoteCategoryName + " (" + clsHelpMethods_Local.GetPendingApprovalCount_ProcessNoteCategory(Category.ProcessNoteCategory_ID).ToString() + ")";
                //clsGenaralName.getName_ProcessNote(Category.ProcessNote_ID) + " (" + GetPendingAuditCount(Category.ProcessNote_ID.ToString(), Category.Audit_ID).ToString() + ")";
                btnCategory.TextAlign = ContentAlignment.MiddleCenter;
                //  btnCategory.Tag = Category.ProcessNote_ID;
                btnCategory.AutoSize = false;

                btnCategory.BackColor = Color.LightGreen;
                btnCategory.ForeColor = Color.Red;
                btnCategory.FlatAppearance.BorderSize = 1;
                btnCategory.FlatAppearance.BorderColor = Color.Black;
                btnCategory.FlatStyle = FlatStyle.Flat;
                btnCategory.Location = new Point(this.i_locX, this.i_locY);
                btnCategory.TextImageRelation = TextImageRelation.ImageAboveText;

                xPnlCategory.Controls.Add(btnCategory);

                //this.Controls.Add(b);
                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = 5;
                    this.i_locY += btnCategory.Size.Height + 5;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += btnCategory.Size.Width + 5;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Click on Category
        private void CategoryClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sCategoryID = ((Control)sender).Name.Trim();
                foreach (Control con in xPnlCategory.Controls)
                {
                    con.BackColor = Color.LightGreen;
                    con.ForeColor = Color.Red;
                }
                ((Control)sender).BackColor = Color.Green;
                ((Control)sender).ForeColor = Color.Yellow;

                txtAuditCode.Text = sCategoryID;
                tbl_securityProcessNoteCatogory cat = tbl_securityProcessNoteCatogory.Select(int.Parse(sCategoryID));
                if (cat != null)
                    LoadNotes(int.Parse(sCategoryID));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Load Notes
        private void LoadNotes(int sCategoryID)
        {
            //set the values
            this.i_locX = 5;
            this.i_locY = 5;
            this.i_cnt = 0;
            this.i_columns = 5;
            int iProcessNoteID = 0;

            //clear the pannel
            xFlow.Controls.Clear();
            

            List<tbl_securityProcessNoteMaster> notes = tbl_securityProcessNoteMaster.SelectAllByProcessNoteCategory_ID(sCategoryID);
            foreach (tbl_securityProcessNoteMaster note in notes)
            {
                iProcessNoteID = note.ProcessNote_ID;
                if (clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, iProcessNoteID) && iProcessNoteID != 0)
                {
                    int width = GetCategoryWidth();
                    Button btnNote = new Button();
                    FillNotes(note, btnNote, width);
                    btnNote.Click += new EventHandler(NoteClick);
                    btnNote.MouseLeave += new EventHandler(Text_MouseLeave);
                    btnNote.MouseMove += new MouseEventHandler(Text_MouseMove);
                }
            }

        }
        #endregion

        #region Fill Notes
        private void FillNotes(tbl_securityProcessNoteMaster Category, Button btnCategory, int width)
        {
            try
            {
                int iNoOfProcessNote = clsHelpMethods_Local.GetPendingApprovalCount_ProcessNote(Category.ProcessNote_ID);
                if (iNoOfProcessNote > 0)
                {
                    btnCategory.Size = new Size(width, 36);
                    btnCategory.Font = new Font("calibri", 8, FontStyle.Bold); //clsCommon.defaultFont;
                    btnCategory.Name = Category.ProcessNote_ID.ToString();
                    btnCategory.Text = Category.ProcessNoteName + " (" + iNoOfProcessNote.ToString() + ")";
                    btnCategory.TextAlign = ContentAlignment.MiddleCenter;
                    btnCategory.Tag = Category.ProcessNote_ID;
                    btnCategory.AutoSize = false;

                    btnCategory.BackColor = Color.FromArgb(250, 244, 133);
                    btnCategory.ForeColor = Color.Red;
                    btnCategory.FlatAppearance.BorderSize = 1;
                    btnCategory.FlatAppearance.BorderColor = Color.Black;
                    btnCategory.FlatStyle = FlatStyle.Flat;
                    btnCategory.Location = new Point(this.i_locX, this.i_locY);
                    btnCategory.TextImageRelation = TextImageRelation.ImageAboveText;

                    xFlow.Controls.Add(btnCategory);

                    //this.Controls.Add(b);
                    this.i_cnt += 1;
                    if (((this.i_cnt) % this.i_columns) == 0)
                    {
                        this.i_locX = 5;
                        this.i_locY += btnCategory.Size.Height + 5;
                        this.i_cnt = 0;
                    }
                    else
                    {
                        this.i_locX += btnCategory.Size.Width + 5;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Click on Note
        private void NoteClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sNoteID = ((Control)sender).Name.Trim();
                foreach (Control con in xFlow.Controls)
                {
                    con.BackColor = Color.FromArgb(250, 244, 133);
                }
                ((Control)sender).BackColor = Color.FromArgb(250, 200, 1);

                txtNoteID.Text = sNoteID;

                if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.CustomerOrder);
                    RefreshGridCustomerOrder();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder).ToString())
                {
                    RefreshGridDeliveryOrder();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Invoice).ToString())
                    RefreshGridInvoice();
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Receipt).ToString())
                    RefreshGridReceipt();
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned).ToString())
                    RefreshGridSalesReturned();
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CreditNote).ToString())
                    RefreshGridCreditNote();
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Cheque).ToString())
                    RefreshGridChequeRegister();
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ProductionJob).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.ProductionJob);
                    RefreshGridProductionJob();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Dept).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.iSR_Dept);
                    RefreshGridDepartment_iSR();
                }

                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseOrder).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.PurchaseOrder);
                    RefreshGridPurchaseOrder();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodReceivedNote).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.ExternalGoodReceivedNote);
                    RefreshGridGRN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodIssuedNote).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.ExternalGoodIssuedNote);
                    RefreshGridGIN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.StockAdjustment).ToString())
                {
                    RefreshGridAdjustment();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ItemSplitNote).ToString())
                {
                    RefreshGridSplitNote();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DamageGoodNote).ToString())
                {
                    RefreshGridDGN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DisGoodNote).ToString())
                {
                    RefreshGridDisGN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseReturned).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.PurchaseReturned);
                    RefreshGridPurchaseReturn();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseRequisition).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.PurchaseRequisition);
                    RefreshGridPurchaseRequisition();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iGRN_Store).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.iGRN_Store);
                    RefreshGridIGRN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iGIN_Store).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.iGIN_Store);
                    RefreshGridIGIN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Store).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.iSR_Store);
                    RefreshGridISRN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.GoodsTransferNote).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.GoodsTransferNote);
                    RefreshGridGTN();
                }
                else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.FinishedGoodsTransferNote).ToString())
                {
                    //clsHelpMethods_Local.FormatGrid_DocumentCheckingOrApproval(dgvDetail, ProcessNote.FinishedGoodsTransferNote);
                    RefreshGridFGTN();
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
            }
        }
        #endregion

        #region Get Sizes

        #region Get Category Width
        private int GetCategoryWidth()
        {
            int value = 0;
            int count = 0;
            //List<tbl_audAudit_Users> details = tbl_audAudit_Users.SelectAllByUser_ID(clsSecurity.UserIDLoged);
            //foreach (tbl_audAudit_Users detail in details)
            //{
            //    if (detail.IsActive)
            //        count++;
            //}
            if (count > 9)
                value = 90;
            else
                value = 96;
            return value;
        }
        #endregion

        #region Get Form Columns
        private int getFormColumes(int count)
        {
            int value = 0;
            if (count >= 20)
                value = 3;
            else
                value = 3;
            return value;
        }
        #endregion

        #region Get Form Width
        private int getFormWidth(int count)
        {
            int value = 0;
            if (count > 15)
                value = 45;
            else
                value = 50;

            return value;
        }
        #endregion

        #region Get Form Height
        private int getFormHeight(int count)
        {
            int value = 0;
            if (count <= 6)
                value = 45;
            else
                value = 45;
            return value;
        }
        #endregion

        #region Get Form GapWidth
        private int getFormGapWith(int count)
        {
            int value = 0;
            if (count <= 6)
                value = 5;
            else if (count <= 12)
                value = 5;
            else if (count > 12)
                value = 5;
            return value;
        }
        #endregion

        #region Get Form GapHeight
        private int getFormGapHeight(int count)
        {
            int value = 0;
            if (count <= 6)
                value = 5;
            else if (count <= 12)
                value = 5;
            else if (count > 12)
                value = 5;
            return value;
        }
        #endregion
        #endregion       
        
        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAuditCode, true);

            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);




            dgvDetail.Columns["CustomerName"].Width = 215;
            dgvDetail.Rows.Clear();

            txtAuditCode.Tag = null;

            txtNoteID.Clear();
            txtAuditCode.Clear();
            chkOnlyDeleted.Checked = false;

            xFlow.Controls.Clear();
            xPnlCategory.Controls.Clear();

            LoadCategory();

            txtApprovedBy.Clear();
            txtCheckedBy.Clear();
            bHasApproved = false;
            bHasChecked = false;
        }
        #endregion

        #region Fill Datagrid
        //private void FillDataGrid(int iRow, string sCustomerID, string sCustomerName, string sNoteNumber, string sNoteDate, string sAmount, Color Col, decimal dAge30to60, decimal dAge60to90, decimal dAge90plus, string dChequesInHand, string dReturnedOutstanding)
        private void FillDataGrid(int iRow, string sCustomerID, string sCustomerName, string sNoteNumber, string sNoteDate, string sAmount, Color Col)
        {
            dgvDetail["CustomerID", iRow].Value = sCustomerID;
            dgvDetail["CustomerName", iRow].Value = sCustomerName;


            dgvDetail["NoteNumber", iRow].Value = sNoteNumber;
            dgvDetail["NoteDate", iRow].Value = sNoteDate;
            //dgvDetail["Age30to60", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAge30to60);
            //dgvDetail["Age60to90", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAge60to90);
            //dgvDetail["Age90plus", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAge90plus);
            //dgvDetail["ChequesInHand", iRow].Value = dChequesInHand;
            //dgvDetail["ReturnedOutstanding", iRow].Value = dReturnedOutstanding;
            dgvDetail["Amount", iRow].Value = sAmount;

            dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = Col;
        }
        #endregion

        #region Refresh Grid

        #region Sales
        //Customer Order
        private void RefreshGridCustomerOrder()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvDetail.Rows.Clear();
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.CustomerOrder_ID != "default")
                    {
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount; 
                        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                        sCustomerID = detail.Customer_ID;
                        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.CustomerOrderDate);
                        sNoteNumber = detail.CustomerOrder_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        //dAge30to60 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice30to60(sCustomerID);
                        //dAge60to90 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice60to90(sCustomerID);
                        //dAge90plus = clsHelpMethods_Local.GetCustomerTotalDues_Invoice90plus(sCustomerID);
                        //dChequesInHand = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(sCustomerID));
                        //dReturnedOutstanding = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_ReturnedCheque(sCustomerID));

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            //FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted), dAge30to60, dAge60to90, dAge90plus, dChequesInHand, dReturnedOutstanding);
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        //Delivery Order
        private void RefreshGridDeliveryOrder()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvDetail.Rows.Clear();
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DeliveryOrder_ID != "default")
                    {
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                        sCustomerID = detail.Customer_ID;
                        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.DeliveryOrderDate);
                        sNoteNumber = detail.DeliveryOrder_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        //dAge30to60 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice30to60(sCustomerID);
                        //dAge60to90 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice60to90(sCustomerID);
                        //dAge90plus = clsHelpMethods_Local.GetCustomerTotalDues_Invoice90plus(sCustomerID);
                        //dChequesInHand = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(sCustomerID));
                        //dReturnedOutstanding = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_ReturnedCheque(sCustomerID));

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 22)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        //Invoice
        private void RefreshGridInvoice()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvDetail.Rows.Clear();
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && !detail.IsOpeningBalance && !detail.IsReturnedCheque && detail.Invoice_ID != "default")
                    {
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                        sCustomerID = detail.Customer_ID;
                        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.InvoiceDate);
                        sNoteNumber = detail.Invoice_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        //dAge30to60 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice30to60(sCustomerID);
                        //dAge60to90 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice60to90(sCustomerID);
                        //dAge90plus = clsHelpMethods_Local.GetCustomerTotalDues_Invoice90plus(sCustomerID);
                        //dChequesInHand = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(sCustomerID));
                        //dReturnedOutstanding = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_ReturnedCheque(sCustomerID));

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 22)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        //Receipt
        private void RefreshGridReceipt()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvDetail.Rows.Clear();
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.Receipt_ID != "default")
                    {
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                        sCustomerID = detail.Customer_ID;
                        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.ReceiptDate);
                        sNoteNumber = detail.Receipt_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.TotalAmount);
                        //dAge30to60 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice30to60(sCustomerID);
                        //dAge60to90 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice60to90(sCustomerID);
                        //dAge90plus = clsHelpMethods_Local.GetCustomerTotalDues_Invoice90plus(sCustomerID);
                        //dChequesInHand = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(sCustomerID));
                        //dReturnedOutstanding = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_ReturnedCheque(sCustomerID));

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 22)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        //Sales Returned
        private void RefreshGridSalesReturned()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvDetail.Rows.Clear();
                List<tbl_sasSalesReturnedNote> details = tbl_sasSalesReturnedNote.SelectAll();
                foreach (tbl_sasSalesReturnedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.SalesReturnedNote_ID != "default")
                    {
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                            //dChequesInHand = "0", dReturnedOutstanding = "0";

                        sCustomerID = detail.Customer_ID;
                        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.SalesReturnedNoteDate);
                        sNoteNumber = detail.SalesReturnedNote_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        //dAge30to60 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice30to60(sCustomerID);
                        //dAge60to90 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice60to90(sCustomerID);
                        //dAge90plus = clsHelpMethods_Local.GetCustomerTotalDues_Invoice90plus(sCustomerID);
                        //dChequesInHand = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(sCustomerID));
                        //dReturnedOutstanding = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_ReturnedCheque(sCustomerID));

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 22)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region Bills
        //Credit Note
        private void RefreshGridCreditNote()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].Width = 215;
                dgvDetail.Rows.Clear();
                List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
                foreach (tbl_bpsCreditNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.CreditNote_ID != "default")
                    {
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                        sCustomerID = detail.Customer_ID;
                        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.CreditNoteDate);
                        sNoteNumber = detail.CreditNote_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.TotalAmount);
                        //dAge30to60 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice30to60(sCustomerID);
                        //dAge60to90 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice60to90(sCustomerID);
                        //dAge90plus = clsHelpMethods_Local.GetCustomerTotalDues_Invoice90plus(sCustomerID);
                        //dChequesInHand = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(sCustomerID));
                        //dReturnedOutstanding = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_ReturnedCheque(sCustomerID));

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 22)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        //Sales Register
        private void RefreshGridChequeRegister()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].Width = 215;
                dgvDetail.Rows.Clear();
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (//!detail.IsApproved && !detail.IsFinished                        && 
                        !detail.IsDeleted && detail.ChequeRegister_ID != "default")
                    {
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                        sCustomerID = detail.Customer_ID;
                        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.DateRegister);
                        sNoteNumber = detail.ChequeRegister_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                        //dAge30to60 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice30to60(sCustomerID);
                        //dAge60to90 = clsHelpMethods_Local.GetCustomerTotalDues_Invoice60to90(sCustomerID);
                        //dAge90plus = clsHelpMethods_Local.GetCustomerTotalDues_Invoice90plus(sCustomerID);
                        //dChequesInHand = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerChequesInHand(sCustomerID));
                        //dReturnedOutstanding = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.GetCustomerTotalDues_ReturnedCheque(sCustomerID));

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(false, false, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 22)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region Stock
        private void RefreshGridPurchaseOrder()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsPurchaseOrder> details = tbl_scsPurchaseOrder.SelectAll();
                foreach (tbl_scsPurchaseOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseOrder_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = detail.Supplier_ID;
                        sSupplierName = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.PurchaseOrderDate);
                        sNoteNumber = detail.PurchaseOrder_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridGRN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsExternalGoodReceivedNote> details = tbl_scsExternalGoodReceivedNote.SelectAll();
                foreach (tbl_scsExternalGoodReceivedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ExternalGoodReceivedNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = detail.Supplier_ID;
                        sSupplierName = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.ExternalGoodReceivedNoteDate);
                        sNoteNumber = detail.ExternalGoodReceivedNote_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridGIN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsExternalGoodIssueNote> details = tbl_scsExternalGoodIssueNote.SelectAll();
                foreach (tbl_scsExternalGoodIssueNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ExternalGoodIssueNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.ExternalGoodIssueNoteDate);
                        sNoteNumber = detail.ExternalGoodIssueNote_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridAdjustment()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsStockAdjustment> details = tbl_scsStockAdjustment.SelectAll();
                foreach (tbl_scsStockAdjustment detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StockAdjustment_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.StockAdjustmentDate);
                        sNoteNumber = detail.StockAdjustment_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridDGN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsDamagedGoodNote> details = tbl_scsDamagedGoodNote.SelectAll();
                foreach (tbl_scsDamagedGoodNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DamagedGoodNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.DamagedGoodNoteDate);
                        sNoteNumber = detail.DamagedGoodNote_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridDisGN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsDiscardedGoodNote> details = tbl_scsDiscardedGoodNote.SelectAll();
                foreach (tbl_scsDiscardedGoodNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DiscardedGoodNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.DiscardedGoodNoteDate);
                        sNoteNumber = detail.DiscardedGoodNote_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridSplitNote()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsItemSpred> details = tbl_scsItemSpred.SelectAll();
                foreach (tbl_scsItemSpred detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ItemSpred_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.ItemSpredDate);
                        sNoteNumber = detail.ItemSpred_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        } 
        private void RefreshGridPurchaseReturn()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsPurchaseReturnedNote> details = tbl_scsPurchaseReturnedNote.SelectAll();
                foreach (tbl_scsPurchaseReturnedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseReturnedNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = detail.Supplier_ID;
                        sSupplierName = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.PurchaseReturnedNoteDate);
                        sNoteNumber = detail.PurchaseReturnedNote_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridPurchaseRequisition()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsPurchaseRequisition> details = tbl_scsPurchaseRequisition.SelectAll();
                foreach (tbl_scsPurchaseRequisition detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseRequisitionNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.PurchaseRequisitionNoteDate);
                        sNoteNumber = detail.PurchaseRequisitionNote_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridIGRN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsStoreGoodReceiveNote> details = tbl_scsStoreGoodReceiveNote.SelectAll();
                foreach (tbl_scsStoreGoodReceiveNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreGoodReceiveNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.StoreGoodReceiveNoteDate);
                        sNoteNumber = detail.StoreGoodReceiveNote_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridIGIN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsStoreGoodIssueNote> details = tbl_scsStoreGoodIssueNote.SelectAll();
                foreach (tbl_scsStoreGoodIssueNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreGoodIssueNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.StoreGoodIssueNoteDate);
                        sNoteNumber = detail.StoreGoodIssueNote_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridISRN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsStoreReqositionNote> details = tbl_scsStoreReqositionNote.SelectAll();
                foreach (tbl_scsStoreReqositionNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreRecositionNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.StoreRecositionNoteDate);
                        sNoteNumber = detail.StoreRecositionNote_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridGTN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsGoodTransferNote> details = tbl_scsGoodTransferNote.SelectAll();
                foreach (tbl_scsGoodTransferNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.GoodTransferNote_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.GoodTransferNoteDate);
                        sNoteNumber = detail.GoodTransferNote_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void RefreshGridFGTN()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].HeaderText = "Supplier Name";
                dgvDetail.Rows.Clear();
                List<tbl_scsStoreProduction> details = tbl_scsStoreProduction.SelectAll();
                foreach (tbl_scsStoreProduction detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreProduction_ID != "default")
                    {
                        string sSupplierID, sSupplierName, sNoteDate, sNoteNumber, sAmount;

                        sSupplierID = "-";
                        sSupplierName = "-";
                        sNoteDate = clsFormatter.FormatDate_Short(detail.StoreProductionDate);
                        sNoteNumber = detail.StoreProduction_ID;
                        sAmount = "0.00";

                        if (sSupplierID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sSupplierID, sSupplierName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 16;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        //Production Job
        private void RefreshGridProductionJob()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].Width = 240;
                dgvDetail.Rows.Clear();
                //List<tbl_pmsProductionJobRegister> details = tbl_pmsProductionJobRegister.SelectAll();
                //foreach (tbl_pmsProductionJobRegister detail in details)
                //{
                //    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ProductionJob_ID != "default")
                //    {
                //        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                //        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                //        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                //        sCustomerID = detail.Customer_ID;
                //        sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                //        sNoteDate = clsFormatter.FormatDate_Short(detail.ProductionOrderDate);
                //        sNoteNumber = detail.ProductionJob_ID;
                //        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(detail.Qty);
                //        //dChequesInHand = clsGenaralName.getName_Item(detail.Item_ID);
                //        //dReturnedOutstanding = clsHelpMethods_Local.GetItemSizeByItemID(detail.Item_ID);                      

                //        if (sCustomerID != "default")
                //        {
                //            int iRow;
                //            dgvDetail.Rows.Add();
                //            iRow = dgvDetail.Rows.Count - 1;
                //            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                //        }
                //    }
                //}
                //if (dgvDetail.Rows.Count > 19)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        //Department iSR
        private void RefreshGridDepartment_iSR()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvDetail.Columns["CustomerName"].Width = 140;
                dgvDetail.Rows.Clear();
                List<tbl_scsDepartmentReqositionNote> details = tbl_scsDepartmentReqositionNote.SelectAll();
                foreach (tbl_scsDepartmentReqositionNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DepartmentReqositionNote_ID != "default")
                    {
                        string sCustomerID, sCustomerName, sNoteDate, sNoteNumber, sAmount;
                        //    dChequesInHand = "0", dReturnedOutstanding = "0";
                        //decimal dAge30to60 = 0, dAge60to90 = 0, dAge90plus = 0;

                        sCustomerID = clsGenaralName.getName_Department(detail.FromDepartment_ID);
                        sCustomerName = clsGenaralName.getName_User(detail.CreateUser_ID);
                        sNoteDate = clsFormatter.FormatDate_Short(detail.DepartmentReqositionNoteDate);                        
                        sNoteNumber = detail.DepartmentReqositionNote_ID;
                        sAmount = clsFormatter.FormatToCurrecyWithThousendSep(0);
                        //dChequesInHand = clsGenaralName.getName_Store(detail.ToStore_ID); 
                        //dReturnedOutstanding = detail.Remark;

                        if (sCustomerID != "default")
                        {
                            int iRow;
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            FillDataGrid(iRow, sCustomerID, sCustomerName, sNoteNumber, sNoteDate, sAmount, getColourCode(detail.IsApproved, detail.IsChecked, detail.IsDeleted));
                        }
                    }
                }
                //if (dgvDetail.Rows.Count > 22)
                //    dgvDetail.Columns["CustomerName"].Width -= 17;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtAuditCode.TextLength == 0)
            {
                strMessage += "\n" + "Document Audit Code ";
                bStatus = false;
            }          
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Events MouseLeave
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events MouseMove
        private void Text_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        #endregion

        #region Events DataGrid
        #region Events CellMouseMove
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sColName = "";
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex >= 0)
                sColName = dgv.Columns[e.ColumnIndex].Name;


            if (sColName == "CustomerName" || sColName == "NoteNumber")
            {
                Cursor = Cursors.Hand;
            }
        } 
        #endregion

        #region Events CellMouseLeave
        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            string sColName = "";
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex >= 0)
                sColName = dgv.Columns[e.ColumnIndex].Name;


            if (sColName == "CustomerName" || sColName == "NoteNumber")
            {
                Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region Events CellClick
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
        } 
        #endregion

        #region Cell Double Click
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "CustomerName" || sColName == "CustomerID")
                {
                    frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                    frm.glbCustomerID = dgvDetail["CustomerID", e.RowIndex].Value.ToString();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                else if (sColName == "NoteNumber" || sColName == "Amount" || sColName == "NoteDate")
                {
                    DisplayNoteView(dgvDetail["NoteNumber", e.RowIndex].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;              
            }
        }
        #endregion 
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtCheckedBy);
                clsCommon.ValidateForeignKey(ref txtApprovedBy);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion        

        #region Display Note View
        private void DisplayNoteView(string NoteID)
        {
            #region Sales
            //for Customer Order
            if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder).ToString())
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(NoteID);
                if (detail != null)
                {
                    frm_sasCustomerOrder frm = new frm_sasCustomerOrder(FormName.CustomerOrder);
                    frm.glbCustomerOrderID = detail.CustomerOrder_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                }
            }
            //for Delivery Order
            if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder).ToString())
            {
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(NoteID);
                if (detail != null)
                {
                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    {
                        frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                        frm.glbDeliveryOrderID = detail.DeliveryOrder_ID;
                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                    }
                    else
                    {
                        frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                        frm.glbDeliveryOrderID = detail.DeliveryOrder_ID;
                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                    }
                }
            }
            //for Invoice
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.Invoice).ToString())
            {
                
                int iFormID_Inv2 = (int)FormName.SalesInvoice2;
                tbl_sasInvoice detail = tbl_sasInvoice.Select(NoteID);
                if (detail != null)
                {
                    tbl_securityFormMaster oForm = tbl_securityFormMaster.Select(iFormID_Inv2);
                    if (oForm.IsEnable == true)
                    {
                        frm_sasInvoice frm = new frm_sasInvoice(FormName.Invoice_TAXReverced);
                        frm.glbInvoiceID = detail.Invoice_ID;
                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                    }
                    else
                    {
                        frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                        frm.glbInvoiceID = detail.Invoice_ID;
                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                    }
                }

                //tbl_sasInvoice detail = tbl_sasInvoice.Select(NoteID);
                //if (detail != null)
                //{
                //    frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                //    frm.glbInvoiceID = detail.Invoice_ID;
                //    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                //}
            }
            
            //for Sales Returned
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned).ToString())
            {
                tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(NoteID);
                if (detail != null)
                {
                    frm_sasSalseReturnNote frm = new frm_sasSalseReturnNote(FormName.sasSalesReturenNote);
                    frm.glbSalesReturnedNoteID = detail.SalesReturnedNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                }
            }
            //for Production Job
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ProductionJob).ToString())
            {
                //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(NoteID);
                //if (detail != null)
                //{
                //    //frm_pmsProductionJobRegister frm = new frm_pmsProductionJobRegister();
                //    //frm.glbProductionJobID = detail.ProductionJob_ID;
                //    //frm.MdiParent = this.MdiParent;
                //    //frm.Show();
                //}
            } 
            #endregion

            #region Bills
            //for Receipt
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.Receipt).ToString())
            {
                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(NoteID);
                if (detail != null)
                {
                    if (detail.IsSalesReceipt)
                    {
                      //  frm_bpsReceipt_Sales frm = new frm_bpsReceipt_Sales();
                       // frm.gReceiptID = detail.Receipt_ID;
                      //  frm.MdiParent = this.MdiParent;
                      //  frm.Show();
                    }
                    else
                    {
                        //frm_bpsReceipt_Interim frm = new frm_bpsReceipt_Interim();
                        //frm.gReceiptID = detail.Receipt_ID;
                        //frm.MdiParent = this.MdiParent;
                        //frm.Show();
                    }
                }
            } 
            #endregion

            #region Stock
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseOrder).ToString())
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(NoteID);
                if (detail != null)
                {
                    frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder(FormName.scsPOSupplier);
                    frm.glbPurchaseOrderID = detail.PurchaseOrder_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodReceivedNote).ToString())
            {
                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(NoteID);
                if (detail != null)
                {                   
                    frm_scsExternalGoodReceiveNote frm = new frm_scsExternalGoodReceiveNote(FormName.scsGRNSupplier);
                    frm.glbGoodReceiveNote = detail.ExternalGoodReceivedNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodIssuedNote).ToString())
            {
                tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsExternalGoodIssueNote frm = new frm_scsExternalGoodIssueNote(FormName.scsGINExternal);
                    frm.glbGINNo = detail.ExternalGoodIssueNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseReturned).ToString())
            {
                tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsPurchaseReturnNote frm = new frm_scsPurchaseReturnNote(FormName.scsPRNSupplier);
                    frm.glbPRNNo = detail.PurchaseReturnedNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseRequisition).ToString())
            {
                tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(NoteID);
                if (detail != null)
                {
                    frm_scsPurchaseRequisitionNote frm = new frm_scsPurchaseRequisitionNote(FormName.PurchaseRequisition);
                    frm.glbPRNo = detail.PurchaseRequisitionNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.StockAdjustment).ToString())
            {
                tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(NoteID);
                if (detail != null)
                {
                    frm_scsStockAdjustment frm = new frm_scsStockAdjustment(FormName.scsStockAdjusment);
                    frm.glbStockAdjustmentNo = detail.StockAdjustment_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.ItemSplitNote).ToString())
            {
                tbl_scsItemSpred detail = tbl_scsItemSpred.Select(NoteID);
                if (detail != null)
                {
                    frm_sasItemSpradeNote frm = new frm_sasItemSpradeNote(FormName.scsStockAdjusment);
                    frm.glbSplitNoteID = detail.ItemSpred_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.DamageGoodNote).ToString())
            {
                tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsDamageGoodsNote frm = new frm_scsDamageGoodsNote(FormName.scsStockAdjusment);
                    frm.glbDGNNo = detail.DamagedGoodNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.DisGoodNote).ToString())
            {
                tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsDiscardedGoodNote frm = new frm_scsDiscardedGoodNote(FormName.scsDiscardedGoodsNote);
                    frm.glbDisGnNo = detail.DiscardedGoodNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.GoodsTransferNote).ToString())
            {
                tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsGoodTransferNote_new frm = new frm_scsGoodTransferNote_new(FormName.scsGoodTransferNote);
                    frm.glbGTNNo = detail.GoodTransferNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.FinishedGoodsTransferNote).ToString())
            {
                tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(NoteID);
                if (detail != null)
                {
                    frm_scsStoreProduction frm = new frm_scsStoreProduction(FormName.scsStoreProduction);
                    frm.glbFGTNID = detail.StoreProduction_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iGRN_Store).ToString())
            {
                tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsStoreGoodReceiveNote frm = new frm_scsStoreGoodReceiveNote(FormName.sasGRNTradingStock);
                    frm.glbGRNNo = detail.StoreGoodReceiveNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iGIN_Store).ToString())
            {
                tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
                    frm.glbGINNo = detail.StoreGoodIssueNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Store).ToString())
            {
                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsStoreRequisitionNote frm = new frm_scsStoreRequisitionNote(FormName.sasSRNTradingStock);
                    frm.glbSRNo = detail.StoreRecositionNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }

            //for Department Requsition
            else if (txtNoteID.TextLength > 0 && txtNoteID.Text.Trim() == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Dept).ToString())
            {
                tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(NoteID);
                if (detail != null)
                {
                    frm_scsDepartmentRequisitionNote frm = new frm_scsDepartmentRequisitionNote(FormName.scsSRNDeparmentStock);
                    frm.glbSRNo = detail.DepartmentReqositionNote_ID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
                }
            }
            #endregion
        } 
        #endregion

        #region Get Colour Code
        private Color getColourCode(bool bApproved, bool bChecked, bool bCancelled)
        {
            Color col = Color.Black;
            if (bCancelled)
                col = clsFormatter.colorStatusCancelled;
            else if (!bApproved && !bChecked)
                col = clsFormatter.colorStatusUnApprovedUnChecked;
            else if (bChecked && bApproved)
                col = clsFormatter.colorStatusApprovedChecked;
            else if (!bChecked)
                col = clsFormatter.colorStatusUnChecked;
            else if (!bApproved)
                col = clsFormatter.colorStatusUnApproved;
            return col;
        }
        #endregion       
       
    }
}
