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



namespace Digiteq
{
    public partial class frm_scsStockControl : MettroForm
    {

        

        //to manage update and insert


        //For Buttons
        public static bool bEMail = false;
        public static bool bSMS = false;
        public static bool bCancel = false;
        public static bool bPrint = false;
        public static bool bExport = false;

        //For Manage Dynamic Buttons
        int i_locX = 0, i_locY = 0, i_cnt = 0, i_columns = 2;  

 

        #region Form Loader
        public frm_scsStockControl()
        {
           // sFormConfigCode = clsAutocode.getFormConfigCode(FormName.FinanceMaster);
            iFormID = clsSecurity.getFormID(FormName.StockControlPanel);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_scsStockControl_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "SCS Control Panel", 4, iFormID);
            RefreshGrid();
            CusDataGridViewFormat();

            ClearFields();
            //PendingNotes("default", false, false, false, false);

        }
        #endregion

        #region Btn Show All
        private void btnNew_Click(object sender, EventArgs e)
        {
            PendingNotes("default", true, true, true, true);
        }
        private void btnAllStores_Click(object sender, EventArgs e)
        {
            PendingNotes("default", false, false, false, true);
        }

        private void btnAllSections_Click(object sender, EventArgs e)
        {
            PendingNotes("default", false, false, true, false);
        }

        private void btnAllDepartments_Click(object sender, EventArgs e)
        {
            PendingNotes("default", false, true, false, false);
        }
        #endregion

        #region btn SR
        private void btnSR_Click(object sender, EventArgs e)
        {
            frm_scsStoreRequisitionNote frm = new frm_scsStoreRequisitionNote(FormName.sasSRNTradingStock);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
        }
        #endregion

        #region btn GIN
        private void btnGIN_Click(object sender, EventArgs e)
        {
            frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
        }
        #endregion

        #region btn GRN
        private void btnGRN_Click(object sender, EventArgs e)
        {
            frm_scsStoreGoodReceiveNote frm = new frm_scsStoreGoodReceiveNote(FormName.sasGRNTradingStock);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
        }
        #endregion

        #region btn Section SR
        private void btnSeSR_Click(object sender, EventArgs e)
        {
            frm_scsSectionRequisitionNote frm = new frm_scsSectionRequisitionNote(FormName.scsSRNSectionStock);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();
        }
        #endregion

        #region btn Section GIN
        private void btnSeGIN_Click(object sender, EventArgs e)
        {
            //frm_scsSectionGoodIssueNote frm = new frm_scsSectionGoodIssueNote();
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();
        }
        #endregion

        #region btn Section GRN
        private void btnSeGRN_Click(object sender, EventArgs e)
        {
            //frm_scsSectionGoodReceiveNote frm = new frm_scsSectionGoodReceiveNote();
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();
        }
        #endregion

        #region btn Department SR
        private void btnDeSR_Click(object sender, EventArgs e)
        {
            frm_scsDepartmentRequisitionNote frm = new frm_scsDepartmentRequisitionNote(FormName.scsSRNDeparmentStock);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
            ////frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();
        }
        #endregion

        #region btn Department GIN
        private void btnDeGIN_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region btn Department GRN
        private void btnDeGRN_Click(object sender, EventArgs e)
        {
           
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
        
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStore, true);

            txtStoreID.Tag = null;            
            txtSectionID.Tag = null;
            txtDepartmentID.Tag = null;
            txtStoreID2.Tag = "default";
            txtSectionID2.Tag = "default";
            txtDepartmentID2.Tag = "default";

            txtStoreID.Clear();
            txtSectionID.Clear();
            txtDepartmentID.Clear();
            txtStoreID2.Clear();
            txtSectionID2.Clear();
            txtDepartmentID2.Clear();

            zpnlPending.Controls.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                //int iRow;
                //dgvGIN.Rows.Clear();

                //string sLocationID = "default", sSelectAreaID = "default";
                //if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
                //{
                //    sLocationID = txtStoreID.Tag.ToString();
                //    sSelectAreaID = clsAutocode.getSelectAreaCode(SelectArea.Store);
                //}

                //if (sLocationID.Length > 0 && sLocationID != "default")
                //{
                //    #region Store Reqosition
                //    List<tbl_scsStoreReqositionNote> oST_SRs = tbl_scsStoreReqositionNote.SelectAllByToSelectArea_ID(sSelectAreaID);
                //    foreach (tbl_scsStoreReqositionNote detail in oST_SRs)
                //    {
                //        if ((detail.ToStore_ID == sLocationID || detail.ToSection_ID == sLocationID) && !detail.IsDeleted && !detail.IsSeattled)
                //        {
                //            dgvGIN.Rows.Add();
                //            iRow = dgvGIN.Rows.Count - 1;
                //            dgvGIN["noteID", iRow].Value = detail.StoreRecositionNote_ID;
                //            dgvGIN["noteDate", iRow].Value = clsFormatter.FormatDate_Short(detail.StoreRecositionNoteDate);
                //            dgvGIN["note", iRow].Value = "Store Requisition Note";
                //            dgvGIN["tLocation", iRow].Value = clsGenaralName.getName_Store(detail.FromStore_ID);
                //        }
                //    }
                //    #endregion

                //    #region Store GIN
                //    List<tbl_scsStoreGoodIssueNote> oST_GINs = tbl_scsStoreGoodIssueNote.SelectAllByToSelectArea_ID(sSelectAreaID);
                //    foreach (tbl_scsStoreGoodIssueNote detail in oST_GINs)
                //    {
                //        if ((detail.ToStore_ID == sLocationID || detail.ToSection_ID == sLocationID) && !detail.IsDeleted && !detail.IsSeattled)
                //        {
                //            dgvGIN.Rows.Add();
                //            iRow = dgvGIN.Rows.Count - 1;
                //            dgvGIN["noteID", iRow].Value = detail.StoreGoodIssueNote_ID;
                //            dgvGIN["noteDate", iRow].Value = clsFormatter.FormatDate_Short(detail.StoreGoodIssueNoteDate);
                //            dgvGIN["note", iRow].Value = "Store Good Issue Note";
                //            dgvGIN["tLocation", iRow].Value = clsGenaralName.getName_Store(detail.FromStore_ID);
                //        }
                //    }
                //    #endregion
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Events Double Click
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            Search_Store();
        }
        private void txtDepartmentID_DoubleClick(object sender, EventArgs e)
        {
            Search_Department();
        }

        private void txtSectionID_DoubleClick(object sender, EventArgs e)
        {
            Search_Section();
        }
        private void txtStoreID2_DoubleClick(object sender, EventArgs e)
        {
            Search_Store2();
        }

        private void txtSectionID2_DoubleClick(object sender, EventArgs e)
        {
            Search_Section2();
        }

        private void txtDepartmentID2_DoubleClick(object sender, EventArgs e)
        {
            Search_Department2();
        }
        #endregion

        #region Events Key Down
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Store();
        }
        private void txtDepartmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Department();
        }

        private void txtSectionID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Section();
        }
        private void txtStoreID2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Store2();
        }

        private void txtSectionID2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Section2();
        }

        private void txtDepartmentID2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Department2();
        }
        #endregion

        
        #region Search Methods
        private void Search_Store()
        {
            string storeID;
            clsSearch.Search_MasterStore(ref txtStoreID, true);
            if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
            {
                RefreshGrid();
                storeID = txtStoreID.Tag.ToString();
                PendingNotes(storeID, false, false, false, false);
            }
        }
        private void Search_Store2()
        {
            string storeID;
            clsSearch.Search_MasterStore(ref txtStoreID2, true);
            if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
            {
                RefreshGrid();
                storeID = txtStoreID.Tag.ToString();
                PendingNotes(storeID, false, false, false, false);
            }
        }
        private void Search_Department()
        {
            string departmentID;
            clsSearch.Search_MasterDepartment(ref txtDepartmentID);
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString().Trim().Length > 0)
            {
                RefreshGrid();
                departmentID = txtDepartmentID.Tag.ToString();
                PendingNotes(departmentID, false, false, false, false);
            }
        }
        private void Search_Department2()
        {
            string departmentID;
            clsSearch.Search_MasterDepartment(ref txtDepartmentID2);
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString().Trim().Length > 0)
            {
                RefreshGrid();
                departmentID = txtDepartmentID.Tag.ToString();
                PendingNotes(departmentID, false, false, false, false);
            }
        }
        private void Search_Section()
        {
            string sectionID;
            clsSearch.Search_MasterSection(ref txtSectionID);
            if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim().Length > 0)
            {
                RefreshGrid();
                sectionID = txtSectionID.Tag.ToString();
                PendingNotes(sectionID, false, false, false, false);
            }
        }
        private void Search_Section2()
        {
            string sectionID;
            clsSearch.Search_MasterSection(ref txtSectionID2);
            if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim().Length > 0)
            {
                RefreshGrid();
                sectionID = txtSectionID.Tag.ToString();
                PendingNotes(sectionID, false, false, false, false);
            }
        }
        #endregion

        #region Load Pending Notes
        private void PendingNotes(string sLocationID, bool bShowAll, bool bShowAll_Dept, bool bShowAll_Section, bool bShowAll_Store)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //set the values
                this.i_locX = 10;
                this.i_locY = 10;
                this.i_cnt = 0;
                this.i_columns = 7;

                //clear the pannel
                zpnlPending.Controls.Clear();

                //counts
                int iGINs = 0, iSRs = 0;

                //Load SR Notes
                #region Store Requisition
                List<tbl_scsStoreReqositionNote> oSRs = tbl_scsStoreReqositionNote.SelectAll();
                foreach (tbl_scsStoreReqositionNote oSR in oSRs)
                {
                    if (!oSR.IsSeattled && !oSR.IsDeleted && oSR.StoreRecositionNote_ID != "default")
                    {
                        bool bValid = false;
                        if (bShowAll || bShowAll_Store)
                            bValid = true;
                        else if (sLocationID != "default")
                        {
                            //if From Store, Section or Depoartment is Selected
                            if (txtStoreID2.Tag.ToString().Trim() != "default" || txtSectionID2.Tag.ToString().Trim() != "default" || txtDepartmentID2.Tag.ToString().Trim() != "default")
                            {
                                bValid = (oSR.ToStore_ID == sLocationID && oSR.FromStore_ID == txtStoreID2.Tag.ToString() ? true
                                        : (oSR.ToSection_ID == sLocationID && oSR.FromStore_ID == txtStoreID2.Tag.ToString()) ? true
                                        : (oSR.ToDepartment_ID == sLocationID && oSR.FromStore_ID == txtStoreID2.Tag.ToString()) ? true : false);
                            }
                            else
                            {
                                bValid = (oSR.ToStore_ID == sLocationID ? true
                                : (oSR.ToSection_ID == sLocationID) ? true
                                : (oSR.ToDepartment_ID == sLocationID) ? true : false);
                            }
                        }
                        if (bValid)
                        {
                            string sDate = clsFormatter.FormatDate_Short(oSR.StoreRecositionNoteDate);
                            string sLocation = clsGenaralName.getName_Store(oSR.FromStore_ID), sNoteID = oSR.StoreRecositionNote_ID, sNote = "iSR";

                            Button btnCategory = new Button();
                            FillCategory(sNote, sNoteID, oSR.Job_ID, sDate, sLocation, btnCategory, 112, Color.YellowGreen, Color.DarkBlue);
                            btnCategory.Click += new EventHandler(StoreSR_Click);

                            //update counts
                            iSRs++;
                        }
                    }
                }
                #endregion

                #region Section Requisition
                List<tbl_scsSectionReqositionNote> oSection_SRs = tbl_scsSectionReqositionNote.SelectAll();
                foreach (tbl_scsSectionReqositionNote oSection_SR in oSection_SRs)
                {
                    if (!oSection_SR.IsSeattled && !oSection_SR.IsDeleted && oSection_SR.SectionReqositionNote_ID != "default")
                    {
                        bool bValid = false;
                        if (bShowAll || bShowAll_Section)
                            bValid = true;
                        else if (sLocationID != "default")
                        {
                            //if From Store, Section or Depoartment is Selected
                            if (txtStoreID2.Tag.ToString().Trim() != "default" || txtSectionID2.Tag.ToString().Trim() != "default" || txtDepartmentID2.Tag.ToString().Trim() != "default")
                            {
                                bValid = (oSection_SR.ToStore_ID == sLocationID && oSection_SR.FromSection_ID == txtSectionID2.Tag.ToString()) ? true
                               : (oSection_SR.ToSection_ID == sLocationID && oSection_SR.FromSection_ID == txtSectionID2.Tag.ToString()) ? true
                               : (oSection_SR.ToDepartment_ID == sLocationID && oSection_SR.FromSection_ID == txtSectionID2.Tag.ToString()) ? true : false;
                            }
                            else
                            {
                                bValid = (oSection_SR.ToStore_ID == sLocationID) ? true
                                : (oSection_SR.ToSection_ID == sLocationID) ? true
                                : (oSection_SR.ToDepartment_ID == sLocationID) ? true : false;
                            }
                        }
                        if (bValid)
                        {
                            string sDate = clsFormatter.FormatDate_Short(oSection_SR.SectionReqositionNoteDate);
                            string sLocation = clsGenaralName.getName_Section(oSection_SR.FromSection_ID), sNoteID = oSection_SR.SectionReqositionNote_ID, sNote = "iSR";

                            Button btnCategory = new Button();
                            FillCategory(sNote, sNoteID, oSection_SR.Job_ID, sDate, sLocation, btnCategory, 112, Color.YellowGreen, Color.DarkBlue);
                            btnCategory.Click += new EventHandler(SectionSR_Click);

                            //update counts
                            iSRs++;
                        }
                    }
                }
                #endregion

                #region Department Requisition
                List<tbl_scsDepartmentReqositionNote> oDRs = tbl_scsDepartmentReqositionNote.SelectAll();
                foreach (tbl_scsDepartmentReqositionNote oDR in oDRs)
                {
                    if (!oDR.IsSeattled && !oDR.IsDeleted && oDR.DepartmentReqositionNote_ID != "default")
                    {
                        bool bValid = false;
                        if (bShowAll || bShowAll_Dept)
                            bValid = true;
                        else if (sLocationID != "default")
                        {
                            //if From Store, Section or Depoartment is Selected
                            if (txtStoreID2.Tag.ToString().Trim() != "default" || txtSectionID2.Tag.ToString().Trim() != "default" || txtDepartmentID2.Tag.ToString().Trim() != "default")
                            {
                                bValid = (oDR.ToStore_ID == sLocationID && oDR.FromDepartment_ID == txtDepartmentID2.Tag.ToString() ? true
                               : (oDR.ToSection_ID == sLocationID && oDR.FromDepartment_ID == txtDepartmentID2.Tag.ToString()) ? true
                               : (oDR.ToDepartment_ID == sLocationID && oDR.FromDepartment_ID == txtDepartmentID2.Tag.ToString()) ? true : false);
                            }
                            else
                            {
                                bValid = (oDR.ToStore_ID == sLocationID ? true
                                : (oDR.ToSection_ID == sLocationID) ? true
                                : (oDR.ToDepartment_ID == sLocationID) ? true : false);
                            }
                        }
                        if (bValid)
                        {
                            string sDate = clsFormatter.FormatDate_Short(oDR.DepartmentReqositionNoteDate);
                            string sLocation = clsGenaralName.getName_Department(oDR.FromDepartment_ID), sNoteID = oDR.DepartmentReqositionNote_ID, sNote = "iSR";

                            Button btnCategory = new Button();
                            FillCategory(sNote, sNoteID, oDR.Job_ID , sDate, sLocation, btnCategory, 112, Color.YellowGreen, Color.DarkBlue);
                            btnCategory.Click += new EventHandler(DepartmentSR_Click);

                            //update counts
                            iSRs++;
                        }
                    }
                }
                #endregion

                //Load GIN Notes
                #region Store Goods Issue
                List<tbl_scsStoreGoodIssueNote> oGINs = tbl_scsStoreGoodIssueNote.SelectAll();
                foreach (tbl_scsStoreGoodIssueNote oGIN in oGINs)
                {
                    if (!oGIN.IsSeattled && !oGIN.IsDeleted && oGIN.StoreGoodIssueNote_ID != "default")
                    {
                        bool bValid = false;
                        if (bShowAll || bShowAll_Store)
                            bValid = true;
                        else if (sLocationID != "default")
                        {
                            //if From Store, Section or Depoartment is Selected
                            if (txtStoreID2.Tag.ToString().Trim() != "default" || txtSectionID2.Tag.ToString().Trim() != "default" || txtDepartmentID2.Tag.ToString().Trim() != "default")
                            {
                                bValid = (oGIN.ToStore_ID == sLocationID && oGIN.FromStore_ID == txtStoreID2.Tag.ToString()) ? true
                                : (oGIN.ToSection_ID == sLocationID && oGIN.FromStore_ID == txtStoreID2.Tag.ToString()) ? true
                                : (oGIN.ToDepartment_ID == sLocationID && oGIN.FromStore_ID == txtStoreID2.Tag.ToString()) ? true : false;
                            }
                            else
                            {
                                bValid = (oGIN.ToStore_ID == sLocationID) ? true
                                 : (oGIN.ToSection_ID == sLocationID) ? true
                                 : (oGIN.ToDepartment_ID == sLocationID) ? true : false;
                            }
                        }
                        if (bValid)
                        {
                            string sDate = clsFormatter.FormatDate_Short(oGIN.StoreGoodIssueNoteDate);
                            string sLocation = clsGenaralName.getName_Store(oGIN.FromStore_ID), sNoteID = oGIN.StoreGoodIssueNote_ID, sNote = "iGIN";
                            string sJobNo = oGIN.Job_ID.Trim();
                            if (oGIN.Job_ID.Length == 0 || oGIN.Job_ID.Trim() == "default")
                            {
                                foreach (tbl_scsStoreGoodIssueNote_Detail oItem in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oGIN.StoreGoodIssueNote_ID))
                                    sJobNo = oItem.Job_ID;
                            }
                            Button btnCategory = new Button();
                            FillCategory(sNote, sNoteID, sJobNo, sDate, sLocation, btnCategory, 112, Color.Green, Color.DarkBlue);
                            btnCategory.Click += new EventHandler(StoreGIN_Click);

                            //update counts
                            iGINs++;
                        }
                    }
                }
                #endregion

                #region Section Goods Issue
                List<tbl_scsSectionGoodIssueNote> oSection_GINs = tbl_scsSectionGoodIssueNote.SelectAll();
                foreach (tbl_scsSectionGoodIssueNote oSection_GIN in oSection_GINs)
                {
                    if (!oSection_GIN.IsSeattled && !oSection_GIN.IsDeleted && oSection_GIN.SectionGoodIssueNote_ID != "default")
                    {
                        bool bValid = false;
                        if (bShowAll || bShowAll_Section)
                            bValid = true;
                        else if (sLocationID != "default")
                        {
                            //if From Store, Section or Depoartment is Selected
                            if (txtStoreID2.Tag.ToString().Trim() != "default" || txtSectionID2.Tag.ToString().Trim() != "default" || txtDepartmentID2.Tag.ToString().Trim() != "default")
                            {
                                bValid = (oSection_GIN.ToStore_ID == sLocationID && oSection_GIN.FromSection_ID == txtSectionID2.Tag.ToString()) ? true
                                : (oSection_GIN.ToSection_ID == sLocationID && oSection_GIN.FromSection_ID == txtSectionID2.Tag.ToString()) ? true
                                : (oSection_GIN.ToDepartment_ID == sLocationID && oSection_GIN.FromSection_ID == txtSectionID2.Tag.ToString()) ? true : false;
                            }
                            else
                            {
                                bValid = (oSection_GIN.ToStore_ID == sLocationID) ? true
                                 : (oSection_GIN.ToSection_ID == sLocationID) ? true
                                 : (oSection_GIN.ToDepartment_ID == sLocationID) ? true : false;
                            }
                        }
                        if (bValid)
                        {
                            string sDate = clsFormatter.FormatDate_Short(oSection_GIN.SectionGoodIssueNoteDate);
                            string sLocation = clsGenaralName.getName_Section(oSection_GIN.FromSection_ID), sNoteID = oSection_GIN.SectionGoodIssueNote_ID, sNote = "iGIN";
                            string sJobNo = oSection_GIN.Job_ID.Trim();
                            if (oSection_GIN.Job_ID.Length == 0 || oSection_GIN.Job_ID.Trim() == "default")
                            {
                                foreach (tbl_scsStoreGoodIssueNote_Detail oItem in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oSection_GIN.SectionGoodIssueNote_ID))
                                    sJobNo = oItem.Job_ID;
                            }
                            Button btnCategory = new Button();
                            FillCategory(sNote, sNoteID, sJobNo, sDate, sLocation, btnCategory, 112, Color.Green, Color.DarkBlue);
                            btnCategory.Click += new EventHandler(SectionGIN_Click);

                            //update counts
                            iGINs++;
                        }
                    }
                }
                #endregion

                //Display the Counts
                txtCountGIN.Text = String.Format("{0:0}", iGINs);
                txtCountSR.Text = String.Format("{0:0}", iSRs);
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

        #region Fill Category
        private void FillCategory(String sNote, String sNoteID, string sJobNo, String sDate, String sLocation, Button btnCategory, int width, Color backColor, Color foreColor)
        {
         
            try
            {
                //Cursor = Cursors.WaitCursor;
                btnCategory.Size = new Size(106, 50);
                btnCategory.Font = new Font("calibri", 8, FontStyle.Bold); //clsCommon.defaultFont;
                btnCategory.Name = sNoteID;
                string sDocID = clsConfig.bShowJobNo_StockControllPanel_forDocNo ? clsCommon.GetForeignKeyValue(sJobNo) : sNoteID;
                btnCategory.Text = sDocID + "\n" + sLocation + "\n" + sDate;
                btnCategory.TextAlign = ContentAlignment.MiddleLeft;
                //  btnCategory.Tag = Category.ProcessNote_ID;
                btnCategory.AutoSize = false;


                btnCategory.BackColor = backColor;
                btnCategory.ForeColor = foreColor;
                btnCategory.FlatAppearance.BorderSize = 1;
                btnCategory.FlatAppearance.BorderColor = Color.Black;
                btnCategory.FlatStyle = FlatStyle.Flat;
                btnCategory.Location = new Point(this.i_locX, this.i_locY);
                btnCategory.TextImageRelation = TextImageRelation.ImageAboveText;


                zpnlPending.Controls.Add(btnCategory);

                //this.Controls.Add(b);
                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = 10;
                    this.i_locY += btnCategory.Size.Height + 10;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += btnCategory.Size.Width + 10;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                //Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Event SR Click
        private void StoreSR_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sID = ((Control)sender).Name.Trim();

                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sID);
                if (detail != null)
                {
                    frm_scsStoreRequisitionNote frm = new frm_scsStoreRequisitionNote(FormName.sasSRNTradingStock);
                    frm.glbSRNo = sID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
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
        private void SectionSR_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sID = ((Control)sender).Name.Trim();

                tbl_scsSectionReqositionNote detail = tbl_scsSectionReqositionNote.Select(sID);
                if (detail != null)
                {
                    frm_scsSectionRequisitionNote frm = new frm_scsSectionRequisitionNote(FormName.scsSRNSectionStock);
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
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
        private void DepartmentSR_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sID = ((Control)sender).Name.Trim();

                tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(sID);
                if (detail != null)
                {
                    frm_scsDepartmentRequisitionNote frm = new frm_scsDepartmentRequisitionNote(FormName.scsSRNDeparmentStock);
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
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

        #region Event GIN Click
        private void StoreGIN_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sID = ((Control)sender).Name.Trim();

                tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sID);
                if (detail != null)
                {
                    //frm_scsStoreGoodIssueNote GIN = new frm_scsStoreGoodIssueNote();
                    //GIN.glbGINNo = sID;
                    //GIN.MdiParent = this.ParentForm;
                    //GIN.glbSRNo = sID;
                    //GIN.Show();

                    frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
                    frm.glbGINNo = sID;
                    frm.glbSRNo = sID;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);

                    //GIN.ShowDialog();
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
        private void SectionGIN_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sID = ((Control)sender).Name.Trim();

                tbl_scsSectionGoodIssueNote detail = tbl_scsSectionGoodIssueNote.Select(sID);
                if (detail != null)
                {
                    //frm_scsSectionGoodIssueNote GIN = new frm_scsSectionGoodIssueNote();
                    //GIN.glbGINNo = sID;
                    //GIN.MdiParent = this.ParentForm;
                    //GIN.glbSRNo = sID;
                    //GIN.Show();
                   // GIN.ShowDialog();
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

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnEPR_Click(object sender, EventArgs e)
        {
            //frm_scsPurchaseRequisitionNote frm = new frm_scsPurchaseRequisitionNote();
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();

            frm_scsPurchaseRequisitionNote frm = new frm_scsPurchaseRequisitionNote(FormName.PurchaseRequisition);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
        }

        private void btnEPO_Click(object sender, EventArgs e)
        {
            //frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder();
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();

            frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder(FormName.scsPOSupplier);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
        }

        private void btnEGRN_Click(object sender, EventArgs e)
        {
            //frm_scsExternalGoodReceiveNote frm = new frm_scsExternalGoodReceiveNote();
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();

            frm_scsExternalGoodReceiveNote frm = new frm_scsExternalGoodReceiveNote(FormName.scsGRNSupplier);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
        }

        private void btnEPRN_Click(object sender, EventArgs e)
        {
            //frm_scsPurchaseReturnNote frm = new frm_scsPurchaseReturnNote();
            //frm.MdiParent = this.MdiParent;
            //if (frm.bNoAccess)
            //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    frm.Show();

            frm_scsPurchaseReturnNote frm = new frm_scsPurchaseReturnNote(FormName.scsPRNSupplier);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, this.MdiParent);
        }

        private void btnLoanIN_Click(object sender, EventArgs e)
        {
            frm_scsLoan frm = new frm_scsLoan();
            frm.MdiParent = this.MdiParent;
            frm.glbIsLoanIn = true;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        private void btnLoanOut_Click(object sender, EventArgs e)
        {
            frm_scsLoan frm = new frm_scsLoan();
            frm.MdiParent = this.MdiParent;
            frm.glbIsLoanIn = false;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
       
    }
}
