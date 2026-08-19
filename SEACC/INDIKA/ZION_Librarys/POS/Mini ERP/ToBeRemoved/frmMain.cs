using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using System.Reflection;
using VistaButtonTest;
using Digiteq;
using Digiteq_Logic;
using System.Threading;
using Digiteq.User_Management;
using Digiteq.Reports;
using System.Diagnostics;
using Digiteq.Transaction_Forms.ACC;

namespace Digiteq
{
    public partial class frmMain : Form
    {
        int i_locX = 0, i_locY = 0, i_cnt = 0, i_columns = 2;

        frmAlert obj_frmAlert = new frmAlert();
        frmChat obj_frmChat = new frmChat();
        NewMessageDisplayPopup obj_frmNewMessage = new NewMessageDisplayPopup();

        public bool bChatShow = true;

        #region Form Load
        public frmMain()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            //tbl_utlUserPool pool = tbl_utlUserPool.Select(clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            //if (pool != null)
            //{
            //    if (pool.IsForceLogout || pool.IsForceShoutdown)
            //    {
            //        pool.IsForceShoutdown = false;
            //        pool.IsForceLogout = false;
            //        pool.Update();
            //    }
            //}
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            clsBackProcess.AutoAssignCompanyValue();

            this.Text = clsFormatter.DigiteqTitle + "  :  LICENSED USER  :  " + clsSecurity.CompanyName + "  [--" + clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID) + "--]";

            lblTest.Visible = (clsConfig.bIsTestLabelVisibleInMainForm) ? true : false;
            clsConfig.bIsTestLabelVisibleInMainForm = false;

            LoadCategory();
            FillProfileDetail();

            #region Check for Sub Folders
            string path1 = "ReportExportTemp";
            if (!System.IO.Directory.Exists(path1))
                System.IO.Directory.CreateDirectory(path1);

            string path2 = "Attachments";
            if (!System.IO.Directory.Exists(path2))
                System.IO.Directory.CreateDirectory(path2);
            #endregion

            if (backgroundWorker1.IsBusy != true)
                backgroundWorker1.RunWorkerAsync();

            timer1.Start();
            tmrAlert.Start();
        }
        #endregion

        #region Btn Digiteq
        private void lblDigiteq_DoubleClick(object sender, EventArgs e)
        {
            frmDigiteqPannel item = new frmDigiteqPannel();
            item.MdiParent = this;
            item.Show();
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
            pnlCategory.Controls.Clear();

            List<tbl_securityFormCategory> details = tbl_securityFormCategory.SelectAll();
            foreach (tbl_securityFormCategory detail in details)
            {
                if (detail != null && detail.IsVisible)
                {
                    int width = GetCategoryWidth();
                    VistaButton btnCategory = new VistaButton();
                    FillCategory(detail, btnCategory, width);
                    btnCategory.Click += new EventHandler(CategoryClick);
                    btnCategory.MouseLeave += new EventHandler(Text_MouseLeave);
                    btnCategory.MouseMove += new MouseEventHandler(Text_MouseMove);
                    btnCategory.MouseHover += new EventHandler(Category_MouseHover);
                }
            }
        }
        #endregion

        #region Fill Category
        private void FillCategory(tbl_securityFormCategory Category, VistaButton btnCategory, int width)
        {
            try
            {
                btnCategory.Name = Category.FormCategory_ID;
                btnCategory.ButtonText = Category.DisplayName;
                btnCategory.Tag = Category.FormCategory_ID;
                btnCategory.Image = getCategoryImage(Category.FormCategory_ID);

                btnCategory.Size = new Size(width, 45);
                btnCategory.Location = new Point(this.i_locX, this.i_locY);
                btnCategory.BaseColor = Color.FromArgb(140, 199, 199);
                btnCategory.ButtonColor = Color.Black;
                btnCategory.GlowColor = Color.FromArgb(255, 192, 192);
                btnCategory.HighlightColor = Color.White;
                btnCategory.Font = new Font("calibri", 7, FontStyle.Bold);
                btnCategory.ImageAlign = ContentAlignment.TopCenter;
                btnCategory.TextAlign = ContentAlignment.BottomCenter;
                btnCategory.CornerRadius = 3;
                btnCategory.ForeColor = Color.WhiteSmoke;
                btnCategory.AutoSize = false;



                //btnCategory.BackColor = Color.FromArgb(179,113,113);
                //btnCategory.ForeColor = Color.White;


                if (!Category.IsEnable)
                    btnCategory.Enabled = false;

                pnlCategory.Controls.Add(btnCategory);

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
                string s = ((Control)sender).Tag.ToString().Trim();
                foreach (Control con in pnlCategory.Controls)
                {
                    con.BackColor = Color.FromArgb(179, 113, 113);
                }
                ((Control)sender).BackColor = Color.Red;
                FillForm(s);
                FillViewer(s);
                #region Check Expiration Date
                if (clsConfig.dtmDateExpiration < DateTime.Now)
                {
                    MessageBox.Show("Product has been Expired....." + Keys.Return + "Please contact Digiteq for more details");
                    Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                //SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Fill Form
        private void DisplayForm(tbl_securityFormMaster form, int w, int h, int gapW, int gapH, int count)
        {
            try
            {

                VistaButton btnForm = new VistaButton();
                //int fontsize = 7;
                btnForm.ButtonText = form.DisplayName.Trim();
                btnForm.Name = form.Form_ID.ToString();
                btnForm.Image = getFormImage(form.Form_ID);
                FormatButton(ref btnForm, w, h, form.IsEnable);

                if (!form.IsEnable)
                    btnForm.Enabled = false;

                //add to the pannel
                pnlForm.Controls.Add(btnForm);

                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = gapW;
                    this.i_locY += btnForm.Size.Height + gapH;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += btnForm.Size.Width + gapW;
                }

                // btnForm.Click += new EventHandler(Form_Click);
                btnForm.MouseDown += new MouseEventHandler(Form_MouseDown);
                btnForm.MouseLeave += new EventHandler(Text_MouseLeave);
                btnForm.MouseMove += new MouseEventHandler(Text_MouseMove);
                btnForm.MouseHover += new EventHandler(Form_MouseHover);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex); ;
            }
        }
        private void FillForm(string sCategoryID)
        {
            try
            {
                //clear the item panel
                pnlForm.Controls.Clear();

                //set the values
                this.i_cnt = 0;

                tbl_securityFormCategory category = tbl_securityFormCategory.Select(sCategoryID);

                if (category != null)
                {
                    bool bPass = false;
                    if (category.FormCategory_ID == clsConfig.sAdminCategoryID)
                    {
                        if (clsSecurity.UserIDLoged.Trim().ToUpper() == "ADMIN" || clsSecurity.UserIDLoged.Trim().ToUpper() == "DIGITEQ")
                            bPass = true;
                    }
                    else
                    {
                        if (clsSecurity.UserIDLoged.Trim().ToUpper() != "ADMIN")
                            bPass = true;
                    }

                    if (bPass)
                    {
                        int iformCount = getFormCount(sCategoryID);
                        this.i_columns = getFormColumes(iformCount);
                        int iFormWidth = getFormWidth(iformCount);
                        int iFormHeight = getFormHeight(iformCount);
                        int iFormGepWidth = getFormGapWith(iformCount);
                        int iFormGepHeight = getFormGapHeight(iformCount);
                        this.i_locX = iFormGepWidth;
                        this.i_locY = iFormGepWidth;

                        List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAllByFormCategory_ID(sCategoryID);
                        foreach (tbl_securityFormMaster detail in details)
                        {
                            if (detail != null && detail.IsVisible && !detail.IsViewer)
                                DisplayForm(detail, iFormWidth, iFormHeight, iFormGepWidth, iFormGepHeight, this.i_columns);
                        }
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog(ex.Message, 0);
                //SEACCException.Show(ex);
            }
        }
        //private void DisplayForm(tbl_securityFormMaster form, int w, int h, int gapW, int gapH, int count)
        //{
        //    try
        //    {

        //        VistaButton btnForm = new VistaButton();
        //        //int fontsize = 7;
        //        btnForm.ButtonText = form.DisplayName.Trim();
        //        btnForm.Name = form.Form_ID.ToString();
        //        btnForm.Image = getFormImage(form.Form_ID);
        //        FormatButton(ref btnForm, w, h, form.IsEnable);

        //        if (!form.IsEnable)
        //            btnForm.Enabled = false;

        //        //add to the pannel
        //        pnlForm.Controls.Add(btnForm);

        //        this.i_cnt += 1;
        //        if (((this.i_cnt) % this.i_columns) == 0)
        //        {
        //            this.i_locX = gapW;
        //            this.i_locY += btnForm.Size.Height + gapH;
        //            this.i_cnt = 0;
        //        }
        //        else
        //        {
        //            this.i_locX += btnForm.Size.Width + gapW;
        //        }

        //        // btnForm.Click += new EventHandler(Form_Click);
        //        btnForm.MouseDown += new MouseEventHandler(Form_MouseDown);
        //        btnForm.MouseLeave += new EventHandler(Text_MouseLeave);
        //        btnForm.MouseMove += new MouseEventHandler(Text_MouseMove);
        //        btnForm.MouseHover += new EventHandler(Form_MouseHover);
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCException.Show(ex);;
        //    }
        //}
        #endregion



        #region Mouse Down
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_FormID = "";
                switch (e.Button)
                {
                    case (MouseButtons.Left):
                        s_FormID = ((Control)sender).Name.ToString().Trim();
                        getCallForm(int.Parse(s_FormID));
                        break;
                    case (MouseButtons.Right):
                        s_FormID = ((Control)sender).Name.ToString().Trim();
                        getCallFormViewer(int.Parse(s_FormID));
                        break;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Fill Viewer
        private void FillViewer(string sCategoryID)
        {
            //clear the item panel
            pnlViewer.Controls.Clear();

            //set the values
            this.i_cnt = 0;

            tbl_securityFormCategory category = tbl_securityFormCategory.Select(sCategoryID);
            if (category != null)
            {
                bool bPass = false;
                if (category.FormCategory_ID == clsConfig.sAdminCategoryID)
                {
                    if (clsSecurity.UserIDLoged.Trim().ToUpper() == "ADMIN" || clsSecurity.UserIDLoged.Trim().ToUpper() == "DIGITEQ")
                        bPass = true;
                }
                else
                {
                    if (clsSecurity.UserIDLoged.Trim().ToUpper() != "ADMIN")
                        bPass = true;
                }

                if (bPass)
                {
                    int iformCount = getViewerCount(sCategoryID);
                    this.i_columns = getFormColumes(iformCount);
                    int iFormWidth = getFormWidth(iformCount);
                    int iFormHeight = getFormHeight(iformCount);
                    int iFormGepWidth = getFormGapWith(iformCount);
                    int iFormGepHeight = getFormGapHeight(iformCount);
                    this.i_locX = iFormGepWidth;
                    this.i_locY = iFormGepWidth;

                    List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAllByFormCategory_ID(sCategoryID);
                    foreach (tbl_securityFormMaster detail in details)
                    {
                        if (detail != null && detail.IsVisible && detail.IsViewer)
                            DisplayViewer(detail, iFormWidth, iFormHeight, iFormGepWidth, iFormGepHeight, this.i_columns);

                    }
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DisplayViewer(tbl_securityFormMaster form, int w, int h, int gapW, int gapH, int count)
        {
            try
            {

                VistaButton btnForm = new VistaButton();
                //int fontsize = 7;
                btnForm.ButtonText = form.DisplayName.Trim();
                btnForm.Name = form.Form_ID.ToString();
                btnForm.Image = getFormImage(form.Form_ID);
                FormatButton(ref btnForm, w, h, form.IsEnable);

                if (!form.IsEnable)
                    btnForm.Enabled = false;

                //add to the pannel
                pnlViewer.Controls.Add(btnForm);

                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = gapW;
                    this.i_locY += btnForm.Size.Height + gapH;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += btnForm.Size.Width + gapW;
                }

                btnForm.MouseDown += new MouseEventHandler(Form_MouseDown);
                btnForm.MouseLeave += new EventHandler(Text_MouseLeave);
                btnForm.MouseMove += new MouseEventHandler(Text_MouseMove);
                btnForm.MouseHover += new EventHandler(Form_MouseHover);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);;
            }
        }
        #endregion

        #region MouseHover
        private void Form_MouseHover(object sender, EventArgs e)
        {
            string s_FormID = ((Control)sender).Name.ToString().Trim();
            if (clsCommon.isCurrency(s_FormID))
            {
                tbl_securityFormMaster detail = tbl_securityFormMaster.Select(int.Parse(s_FormID));
                if (detail != null)
                {
                    this.tslStatus.Text = detail.FormName;
                }
            }
        }
        private void Category_MouseHover(object sender, EventArgs e)
        {
            string s_CateogryID = ((Control)sender).Name.ToString().Trim();
            tbl_securityFormCategory detail = tbl_securityFormCategory.Select(s_CateogryID);
            if (detail != null)
            {
                this.tslStatus.Text = detail.CategoryName;
            }

        }
        #endregion

        #region Get Sizes

        #region Get Category Width
        private int GetCategoryWidth()
        {
            int value = 0;
            int count = 0;
            List<tbl_securityFormCategory> details = tbl_securityFormCategory.SelectAll();
            foreach (tbl_securityFormCategory detail in details)
            {
                if (detail.IsVisible)
                    count++;
            }
            if (count > 9)
                value = 45;
            else
                value = 50;
            return value;
        }
        #endregion

        #region Get Form Count
        private int getFormCount(string sCategoryID)
        {
            int count = 0;
            List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAllByFormCategory_ID(sCategoryID);
            foreach (tbl_securityFormMaster detail in details)
            {
                if (detail != null && detail.IsVisible && !detail.IsViewer)
                {
                    count++;
                }
            }
            return count;
        }
        private int getViewerCount(string sCategoryID)
        {
            int count = 0;
            List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAllByFormCategory_ID(sCategoryID);
            foreach (tbl_securityFormMaster detail in details)
            {
                if (detail != null && detail.IsVisible && detail.IsViewer)
                {
                    count++;
                }
            }
            return count;
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

        #region FormatButtons
        private void FormatButton(ref VistaButton button, int w, int h, bool bEnable)
        {
            button.Size = new Size(w, h);
            button.Location = new Point(this.i_locX, this.i_locY);
            button.BaseColor = bEnable ? Color.Maroon : Color.Maroon;
            button.ButtonStyle = bEnable ? VistaButton.Style.Default : VistaButton.Style.Flat;
            button.BackColor = bEnable ? Color.Transparent : Color.FromArgb(200, 160, 180);
            button.ButtonColor = Color.FromArgb(200, 160, 180);
            button.GlowColor = Color.FromArgb(255, 192, 192);
            button.HighlightColor = Color.White;
            button.Font = new Font("calibri", 7, FontStyle.Bold);
            button.ImageAlign = ContentAlignment.TopCenter;
            button.TextAlign = ContentAlignment.BottomCenter;
            button.CornerRadius = 3;
            button.ForeColor = Color.White;
            button.AutoSize = false;

        }
        #endregion

        #region Get Image
        private Image getCategoryImage(string sCategoryID)
        {
            Image image = Digiteq.Properties.Resources.accept;
            tbl_securityFormCategory detail = tbl_securityFormCategory.Select(sCategoryID);
            if (detail != null && detail.Image != null)
            {
                if (detail.Image.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(detail.Image);
                    image = Image.FromStream(ms);
                }
            }
            return image;
        }
        private Image getFormImage(int iFormID)
        {
            Image image = Digiteq.Properties.Resources.delete;
            tbl_securityFormMaster detail = tbl_securityFormMaster.Select(iFormID);
            if (detail != null && detail.Image != null)
            {
                if (detail.Image.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(detail.Image);
                    image = Image.FromStream(ms);
                }
            }
            return image;
        }
        #endregion

        #region Fill Profile Detail
        private void FillProfileDetail()
        {
            // lblUserName.Text = clsSecurity.UserNameLoged;
            //  lblDepartment.Text = clsSecurity.UserGroupLoged;

            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
            if (detail != null)
            {
                //   lblTimeLoged.Text = detail.LastLogedDateTime.ToShortDateString() + "    " + detail.LastLogedDateTime.ToShortTimeString(); ;
                if (detail.Image != null)
                {
                    if (detail.Image.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(detail.Image);
                        pbxProfilePic.Image = Image.FromStream(ms);
                    }
                    else
                        pbxProfilePic.Image = Digiteq.Properties.Resources.no_image;
                }
                else
                    pbxProfilePic.Image = Digiteq.Properties.Resources.no_image;
            }
        }
        #endregion


        #region Display Viewer
        #region SAS Viewer - Inquiry
        private void DisplayViewerInquiry()
        {
            frm_sasInquiryViewer frm = new frm_sasInquiryViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region SAS Viewer - Quotation
        private void DisplayViewerQuotation()
        {

        }
        #endregion

        #region SAS Viewer - Customer Order
        private void DisplayViewerCustomerOrder()
        {
            frm_sasCustomerOrderViewer frm = new frm_sasCustomerOrderViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region SAS Viewer - Proforema Invoice
        private void DisplayViewerProforemaInvoice()
        {

        }
        #endregion

        #region SAS Viewer - Delivery Order
        private void DisplayViewerDeliveryOrder()
        {
            frm_sasDeliveryOrderViewer frm = new frm_sasDeliveryOrderViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region SAS Viewer - Invoice
        private void DisplayViewerInvoice()
        {
            frm_sasInvoiceViewer frm = new frm_sasInvoiceViewer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region BSS Viewer - Receipt
        private void DisplayViewerReceipt()
        {
            frm_bpsReceiptTracer frm = new frm_bpsReceiptTracer();
            frm.MdiParent = this;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #endregion
 

        #region Get Call Viewer ID
        private string getCallFormViewer(int iFormID)
        {
            string sConfigFormID = "";
            switch (iFormID)
            {
                case 9:
                    DisplayViewerCustomerOrder();
                    break;
                case 10:
                    DisplayViewerInvoice();
                    break;
                case 11:
                    DisplayViewerDeliveryOrder();
                    break;
                case 21:
                    DisplayViewerReceipt();
                    break;
                case 22:
                    DisplayViewerInquiry();
                    break;
                case 23:
                    DisplayViewerQuotation();
                    break;
                case 24:
                    DisplayViewerQuotation();
                    break;
                case 155:
                    DisplayViewerInquiry();
                    break;
                case 176:
                    //SalesReturnNote();
                    break;
            }
            return sConfigFormID;
        }
        #endregion

        #region Btn Logout
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //tbl_utlUserPool uPool = tbl_utlUserPool.Select(clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            //if (uPool != null)
            //    uPool.Delete();

            //Program.IsLogOff = true;
            this.Dispose();
        }
        #endregion

        #region Btn My Protal
        private void btnMyPortal_Click(object sender, EventArgs e)
        {
            this.tslStatus.Text = "My Portal";
            frmMyPortal frm = new frmMyPortal();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region Events FormClosing
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ////update user pool
            //tbl_utlUserPool uPool = tbl_utlUserPool.Select(clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            //if (uPool != null)
            //{
            //    uPool.Delete();
            //}

            ////MessageBox.Show("Please Logout to Close the Applicatoin..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////e.Cancel = true;
        }
        #endregion

        #region Btn Alert
        private void btnAlert_Click(object sender, EventArgs e)
        {
            frm_dashBord frm = new frm_dashBord();
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.ShowDialog();
        }
        #endregion

        #region Profile Picture Clicks
        private void pbxProfilePic_Click(object sender, EventArgs e)
        {
            if (clsSecurity.UserIDLoged == "digiteq")
            {
                frmDigiteqLogin login = new frmDigiteqLogin();
                login.ShowDialog();
                if (frmDigiteqLogin.bLoged)
                {
                    frmDigiteqPannel item = new frmDigiteqPannel();
                    item.MdiParent = this;
                    item.Show();
                }
            }
        }
        #endregion

        #region Btn Pending Approval
        private void tslPendingApproval_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmDocumentApproval frm = new frmDocumentApproval();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Pending Checking
        //private void tslPendingCheck_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        frmDocumentChecking frm = new frmDocumentChecking();
        //        frm.MdiParent = this;
        //        if (frm.bNoAccess)
        //            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        else
        //            frm.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCException.Show(ex);
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //    }
        //}
        #endregion

        #region Btn Pending Audit
        private void tslPendingAudit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmDocumentAudit frm = new frmDocumentAudit();
                frm.MdiParent = this;
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Background Workers
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {  
                #region Check Product expire date
                clsBackProcess.AutoAssignConfigStatus();
                clsBackProcess.AutoAssignConfigValue();
                DateTime dtmProductExpire = clsSecurity.GetSystemExpireDate();
                //if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date.AddDays(-7).Date)
                //{
                //    //Continue
                //}
                 if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date.AddDays(-7).Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date)
                {
                    MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software will be expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.AddDays(7))
                {
                    MessageBox.Show("Please contact 'hepldesk@digiteq.biz' Unless the product will be stopped on " + clsFormatter.FormatDate_Short(dtmProductExpire.AddDays(7)), "Software has been expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RemoveUsersAfterProductExpired();
                }
                else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.AddDays(7))
                {
                    MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software has been expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    RemoveUsersAfterProductExpired();
                                        
                    Application.Exit();
                    this.Dispose();
                }
                else if (clsConfig.bProductActivated == false)
                {
                    MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software has been expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                    Application.Exit();
                    this.Dispose();
                }
                #endregion
              //  clsBackProcess.AutoAssignPaymentMethods();
              //  clsBackProcess.AutoAssignStockExceedLock();
                clsBackProcess.AutoAssignCommissionValues();
                clsBackProcess.AutoAssignGLCodes();

                if (clsConfig.bIsEnableStartupStocReconcilation)
                {
                    #region srh_scsFlowStock Reconcilation
                    try
                    {
                        List<srh_scsFlowStock> oDetail = srh_scsFlowStock.Select(clsSecurity.getServerDateTime().Date, "%", "%", "");

                        foreach (var oStock in oDetail.GroupBy(cm => new { cm.Item_ID, cm.ItemName, cm.Brand_ID, cm.Store_ID, cm.ItemCategory_ID, cm.ItemCategorySub_ID, cm.ItemSubCategory2_ID, cm.ItemSerialNo, cm.ItemSerialNo2, cm.ItemType_ID, cm.Uom, cm.IsWeightCalculation }, (key, group) => new { itemId = key.Item_ID, itemName = key.ItemName, brandId = key.Brand_ID, storeID = key.Store_ID, itemCatID = key.ItemCategory_ID, itemSubcat1 = key.ItemCategorySub_ID, itemSubcat2 = key.ItemSubCategory2_ID, itemSerialNo1 = key.ItemSerialNo, itemSerialNo2 = key.ItemSerialNo2, typeId = key.ItemType_ID, uom = key.Uom, qty = group.Sum(p => p.Qty), waight = group.Sum(p => p.Weight), isWaight = key.IsWeightCalculation }).ToList())
                        {
                            tbl_genStore_Stock oStoreStock = tbl_genStore_Stock.Select(oStock.storeID, oStock.itemId, "default", oStock.itemSubcat1, oStock.itemSubcat2, oStock.itemSerialNo1, oStock.itemSerialNo2);
                            if (oStoreStock != null)
                            {
                                if (oStoreStock.Qty != oStock.qty || oStoreStock.Weight != oStock.waight)
                                {
                                    tbl_genStore_Stock_reconciliation oSR = new tbl_genStore_Stock_reconciliation(oStoreStock.Store_ID, oStoreStock.Item_ID, oStoreStock.Job_ID, oStoreStock.ItemSubCategory_ID, oStoreStock.ItemSubCategory2_ID, oStoreStock.ItemSerialNo, oStoreStock.ItemSerialNo2, oStoreStock.Qty, oStock.qty, oStoreStock.Weight, oStock.waight, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.TerminalID);
                                    oSR.Insert();

                                    oStoreStock.Qty = oStock.qty;
                                    oStoreStock.Weight = oStock.waight;
                                    oStoreStock.Update();
                                }
                            }
                            else
                            {
                                tbl_genStore_Stock_reconciliation oSR = new tbl_genStore_Stock_reconciliation(oStock.storeID, oStock.itemId, "default", oStock.itemSubcat1, oStock.itemSubcat2, oStock.itemSerialNo1, oStock.itemSerialNo2, 0, oStock.qty, 0, oStock.waight, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.TerminalID);
                                oSR.Insert();

                                tbl_genStore_Stock oStoreStockNew = new tbl_genStore_Stock(oStock.storeID, oStock.itemId, "default", oStock.itemSubcat1, oStock.itemSubcat2, oStock.itemSerialNo1, oStock.itemSerialNo2, oStock.qty, oStock.qty, oStock.waight, oStock.waight, 0, 0, 0, 0);
                                oStoreStockNew.Insert();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Store Stock Reconcilation failed. Please contact system administrator");
                        throw;
                    }
                    #endregion
                }

                //Validate Version Control
                //string sExeVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //if (clsConfig.sVersion != sExeVersion)
                //{
                //    frmMessageForm frm = new frmMessageForm();
                //    frm.sMessage = clsFormatter.GetMessageFrom(MessageType.VersionInCompatible);
                //    frm.sHeader = clsFormatter.GetMessageCaption();
                //    frm.ShowDialog();
                //    Application.Exit();
                //}


             //   tslPendingApproval.Text = clsHelpMethods_Local.GetPendingApprovalCount().ToString();
               // tslPendingCheck.Text = clsHelpMethods_Local.GetPendingCheckingCount().ToString();
               // tslPendingAudit.Text = clsHelpMethods_Local.GetPendingAuditCount().ToString();
                // toolLoginUser.Text = clsGenaralName.getName_User(clsBackProcess.GetNewLogedUserID());
                toolLoginUser.Text = clsSecurity.UserNameLoged;
               // if (clsConfig.bChequeAutoRealizedOn && clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.idealWheels.ToString())  //don't auto realize for appolo                  
                  //  clsBackProcess.AutoChequeRealized();

             //   clsBackProcess.AutoWeeklyStockTake();
                clsBackProcess.AutoReceiptSettle();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog(ex.Message, 0);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Timer Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string sUnreadChatID = clsBackProcess.GetUnReadChatID();
                if (sUnreadChatID.Length > 0)
                {
                    obj_frmChat.glbChatID = sUnreadChatID;
                    obj_frmChat.MdiParent = this;
                    obj_frmChat.Show();
                }

                //string sUnreadChatID = clsBackProcess.GetUnReadChatID();
                //if (sUnreadChatID.Length > 0)
                //{
                //    obj_frmNewMessage._sChatID = sUnreadChatID;
                //    obj_frmNewMessage.Show();
                //}

                //Show Desktop Alert
                string sUserID = clsBackProcess.GetNewLogedUserID();
                if (sUserID.Length > 0)
                {
                    frmDesktopAlert frm = new frmDesktopAlert();
                    frm.glbUserID = sUserID;
                    frm.Show();
                }

                //Force ShoutDown
                if (clsBackProcess.IsForceShutDown())
                    Application.Exit();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog(ex.Message, 0);
                SEACCException.Show(ex);
            }
        }
        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.DailyStatusAlert))
        //            clsAlerts.createEmail_DailyStatusAlert();
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog(ex.Message, 0);
        //        SEACCException.Show(ex);
        //    }
        //}
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlDock.Visible)
            {
                pnlDock.Visible = false;
                btnMenu.Location = new System.Drawing.Point(0, 3);
            }
            else
            {
                pnlDock.Visible = true;
                btnMenu.Location = new System.Drawing.Point(170, 3);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sFYClosed=clsSecurity.GetCofigValue();
            //frmMainNew frm = new frmMainNew();
           // frm.Show();

            foreach (tbl_scsFixedAsset oFA in tbl_scsFixedAsset.SelectAll().Where(p=>!p.IsDeleted && !p.IsDepreciated))
            {
           //     string 
             //   decimal dDepreciatonRate = oFA.DepreciationRate;
              //  decimal dWrittenDownValue = oFA.WriteDownValue;
          //      decimal dDayRate = oFA.Cost / oFA.LifeTime ;
            //    tbl_genItemMaster_Barcode oBarcode =tbl_genItemMaster_Barcode.Select(oFA.Barcode_ID);
            //    if(oBarcode!=null)
            //    {
            //        foreach(tbl_scsAssetsTransferNote_Detail oATNdetails in tbl_scsAssetsTransferNote_Detail.SelectAllByItem_ID(oBarcode.Item_ID).Where(p=>p.FixedAsset_Code==oFA.FixedAsset_Code))//filter financial year
            //        {
                    
            //        }
            //    }
            
            }
        }
        #endregion

        #region Chat Event and Method
        private void btnChat_Click(object sender, EventArgs e)
        {
            ChatMethod();
        }

        public void ChatMethod()
        {
            if (bChatShow)
            {
                obj_frmChat.MdiParent = this;
                if (obj_frmChat.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    obj_frmChat.Show();

                bChatShow = false;
            }
            else
            {
                obj_frmChat.Hide();
                bChatShow = true;
            }
        }
        #endregion

        private void RemoveUsersAfterProductExpired()
        {
            tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(281);//Product Activated - bool
            if (oConfig != null)
            {
                oConfig.ConfigValue = false;
                oConfig.Update();
            }
            else
            {                
                Application.Exit();
                this.Dispose();
            }

            foreach (tbl_utlUserPool oPool in tbl_utlUserPool.SelectAll().Where(r => r.LoginStatus_ID != ((int)LoginStatus.Offline).ToString()))
                oPool.IsForceShoutdown = true;
        }
    }
}