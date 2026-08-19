using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic;


namespace Digiteq
{
    public partial class frmForm : Form
    {
        #region Variables
        string s_FileName;
        string sFinalQuary = "";
        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable(); 
        #endregion


        #region Form Load
        public frmForm()
        {
            InitializeComponent();
        }

        private void frm_AutoNumber_Load(object sender, EventArgs e)
        {
            ClearFields();
            CreateDataTable();
            dgvDetail.DataSource = source;
                            
            RefreshGrid();
            CusDataGridViewFormat();         
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    try
                    {
                        Byte[] img = new byte[0];
                        if (txtFormID.TextLength > 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_securityFormMaster oldRecord = tbl_securityFormMaster.Select(int.Parse(txtFormID.Text.Trim()));
                            if (oldRecord != null)
                            {
                                if (s_FileName.Length > 0)
                                {
                                    FileStream fs = new FileStream(s_FileName, FileMode.Open);
                                    img = new Byte[fs.Length];
                                    fs.Read(img, 0, (int)fs.Length);
                                    fs.Close();
                                }
                                else if (oldRecord.Image.Length > 0)
                                {
                                    img = oldRecord.Image;
                                }
                                //update records
                                tbl_securityFormMaster detail = new tbl_securityFormMaster(int.Parse(txtFormID.Text.Trim()), int.Parse(txtOrder.Text.Trim()), 
                                    txtFormName.Text.Trim(), img, txtCategoryID.Tag.ToString(), txtDisplayName.Text.Trim(), chkActivate.Checked, chkVisible.Checked, chkViewer.Checked,txtDoc.Text);
                                detail.Update();
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", 0,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        //ClearFields();
                        //RefreshGrid();
                    }
                }
            }
        } 
        #endregion

        #region Btn Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Btn Load Image
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog();

            filedialog.Filter = "PNG Images|*.png|Icon Images|*.ico|JPG Files|*.Jpg|" + "JPEG Files|*.Jpeg|GIF Images|*.gif|BITMAPS|*.bmp"; 
            filedialog.ShowDialog();
            s_FileName = filedialog.FileName;
            pbxImage.ImageLocation = s_FileName;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id            
            txtFormID.Enabled = true;

            source.RemoveFilter();
            txtFormID.Clear();           
            txtFormName.Clear();           
            txtDisplayName.Clear();
            txtCategoryID.Clear();
            txtCategoryID.Tag = null;
            txtOrder.Clear();
            txtCategory.Tag = null;
            txtCategory.Clear();
            txtDoc.Clear();

            s_FileName = "";
            pbxImage.Image = null;
            chkActivate.Checked = false;
            chkVisible.Checked = false;
            chkViewer.Checked = false;

            if (txtFormID.Enabled)
                txtFormID.Focus();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
           // int iRow;
            dtAllRecodes.Rows.Clear();            
            List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAll();
            foreach (tbl_securityFormMaster detail in details)
            {
                int iFormId=detail.Form_ID;
                string sFormName=detail.FormName;
                string sCategoryId = detail.FormCategory_ID;
                string sDisplayName=detail.DisplayName;
                string sSortOrder=detail.SortOrder.ToString();
                string sCategoryName="";
                tbl_securityFormCategory catDetail = tbl_securityFormCategory.Select(detail.FormCategory_ID);
                if(catDetail != null)
                   sCategoryName = catDetail.CategoryName;

                dtAllRecodes.Rows.Add(iFormId, sFormName, sCategoryId, sDisplayName, sCategoryName, sSortOrder);
            }
            source.DataSource = dtAllRecodes;
        }
        #endregion

        #region Fill Details
        private void FillDetails(int iFormID)
        {
            try
            {
                if (iFormID > 0)
                {
                    tbl_securityFormMaster detail = tbl_securityFormMaster.Select(iFormID);

                    if (detail != null)
                    {
                        //asign values
                       
                        txtFormID.Text = detail.Form_ID.ToString();
                        txtFormName.Text = detail.FormName;                       
                        txtDisplayName.Text = detail.DisplayName;
                        txtOrder.Text = detail.SortOrder.ToString();
                        chkActivate.Checked = detail.IsEnable;
                        chkVisible.Checked = detail.IsVisible;
                        chkViewer.Checked = detail.IsViewer;
                        txtCategoryID.Tag = detail.FormCategory_ID;
                        txtDoc.Text = detail.DocumentCode;
                        tbl_securityFormCategory cat = tbl_securityFormCategory.Select(detail.FormCategory_ID);
                        if (cat != null)
                            txtCategoryID.Text = cat.CategoryName;

                        //Image                    
                        if (detail.Image != null)
                        {
                            if (detail.Image.Length > 0)
                            {
                                MemoryStream ms = new MemoryStream(detail.Image);
                                pbxImage.Image = Image.FromStream(ms);
                            }
                            else
                            {
                                pbxImage.Image = Digiteq.Properties.Resources.no_image;
                            }
                        }
                        else
                        {
                            pbxImage.Image = pbxImage.InitialImage;
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
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";// " Please Enter the Details... ";
            bool bStatus = true;

            if (txtFormID.TextLength == 0)
            {
                strMessage += "\n" + "Config ID ";
                bStatus = false;
            }

            if (txtCategoryID.TextLength == 0)
            {
                strMessage += "\n" + "Category Name";
                bStatus = false;
            }

            if (txtFormName.TextLength == 0)
            {
                strMessage += "\n" + "Form Name";
                bStatus = false;
            }

          

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = " ";
            bool bStatus = true;

            try
            {
                
              
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);           
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int sID = int.Parse(dgvDetail["FormID", e.RowIndex].Value.ToString());
                if (sID > 0)
                {
                    //fills the values to controls
                    FillDetails(sID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int sID = int.Parse(dgvDetail["FormID", e.RowIndex].Value.ToString());
                if (sID > 0)
                {
                    //fills the values to controls
                    FillDetails(sID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        } 
        #endregion

        #region Events Keydown
        private void txtFormID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmSearchTransaction frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_FromMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    FillDetails(int.Parse(frmSearchTransaction.s_SearchID));
                }
            }
        }
        private void txtCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmSearchMaster frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_FromCategoryMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCategoryID.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCategoryID.Tag = frmSearchMaster.s_SearchID;
            }
        }
        private void frmAutoFormNumber_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        } 
        #endregion

        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_SecurityFormCategory(ref txtCategory);
            if (txtCategory.Tag != null)
                 createFilterQuary();
        }

        #region Create Data Table 
        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("FormCode", typeof(int));
            dtAllRecodes.Columns.Add("FormName", typeof(string));
            dtAllRecodes.Columns.Add("formCategory_ID", typeof(string));
            dtAllRecodes.Columns.Add("DisplayName", typeof(string));
            dtAllRecodes.Columns.Add("CategoryName", typeof(string));
            dtAllRecodes.Columns.Add("Order", typeof(string));
        } 
        #endregion

        #region BindingSource Filtering
        private void createFilterQuary()
        {
            // If Category selected
            if (txtCategory.Tag != null)
            {
                sFinalQuary = "formCategory_ID LIKE '%" + txtCategory.Tag.ToString() + "%'";

                if (txtFormName.TextLength > 0)
                    sFinalQuary += "AND formName LIKE '%" + txtFormName.Text.Trim() + "%'";
                source.Filter = sFinalQuary;
            }
            else
            {
                sFinalQuary = "formName LIKE '%" + txtFormName.Text.Trim() + "%'";
                source.Filter = sFinalQuary;
            }
        }
        #endregion

        private void txtFormName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary();
        }

    }
}