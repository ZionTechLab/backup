using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;


namespace Digiteq
{
    public partial class frmFormCategory : Form
    {
        string s_FileName;
        public frmFormCategory()
        {
            InitializeComponent();
        }

        private void frm_AutoNumber_Load(object sender, EventArgs e)
        {
            ClearFields();

            //add data to the datagrid and format            
            RefreshGrid();
            CusDataGridViewFormat();         
        }

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
                        if (txtFormCategoryID.TextLength > 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_securityFormCategory oldRecord = tbl_securityFormCategory.Select(txtFormCategoryID.Text.Trim());
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
                                tbl_securityFormCategory detail = new tbl_securityFormCategory(txtFormCategoryID.Text.Trim(), int.Parse(txtOrder.Text.Trim()), 
                                    txtCategoryName.Text.Trim(), img, txtDisplayName.Text.Trim(), chkActivate.Checked, chkVisible.Checked);
                                detail.Update();
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", -1,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        ClearFields();
                        RefreshGrid();
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
            txtFormCategoryID.Enabled = true;

            txtFormCategoryID.Clear();           
            txtCategoryName.Clear();           
            txtDisplayName.Clear();
            txtOrder.Clear();

            s_FileName = "";
            pbxImage.Image = null;
            chkActivate.Checked = false;
            chkVisible.Checked = false;

            if (txtFormCategoryID.Enabled)
                txtFormCategoryID.Focus();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();

            List<tbl_securityFormCategory> details = tbl_securityFormCategory.SelectAll();
            foreach (tbl_securityFormCategory detail in details)
            {
                dgvDetail.Rows.Add();
                iRow = dgvDetail.Rows.Count - 1;
                dgvDetail["CategoryID", iRow].Value = detail.FormCategory_ID;
                dgvDetail["CategoryName", iRow].Value = detail.CategoryName;
                dgvDetail["DisplayName", iRow].Value = detail.DisplayName;
                dgvDetail["SortOrder", iRow].Value = detail.SortOrder.ToString();
                dgvDetail["IsActivate", iRow].Value = detail.IsEnable;
                dgvDetail["IsVisible", iRow].Value = detail.IsVisible;                
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string s_CategoryID)
        {
            try
            {
                if (s_CategoryID.Length > 0)
                {
                    tbl_securityFormCategory detail = tbl_securityFormCategory.Select(s_CategoryID.Trim());

                    if (detail != null)
                    {
                        //asign values
                       
                        txtFormCategoryID.Text = detail.FormCategory_ID;
                        txtCategoryName.Text = detail.CategoryName;                       
                        txtDisplayName.Text = detail.DisplayName;
                        chkActivate.Checked = detail.IsEnable;
                        chkVisible.Checked = detail.IsVisible;
                        txtOrder.Text = detail.SortOrder.ToString();


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
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";// " Please Enter the Details... ";
            bool bStatus = true;

            if (txtFormCategoryID.TextLength == 0)
            {
                strMessage += "\n" + "Config ID ";
                bStatus = false;
            }

          

            if (txtCategoryName.TextLength == 0)
            {
                strMessage += "\n" + "Form Name";
                bStatus = false;
            }
            if (txtOrder.TextLength == 0)
            {
                strMessage += "\n" + "Sort Order";
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
                if (!clsCommon.isCurrency(txtOrder.Text.Trim()))
                {
                    strMessage += "\n Sort Order";
                    bStatus = false;
                }
              
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes .WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string sID = dgvDetail["CategoryID", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID.Trim());
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
                string sID = dgvDetail["CategoryID", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    //fills the values to controls
                    FillDetails(sID.Trim());
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
        private void txtFormCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_FromCategory();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    FillDetails(frmSearchTransaction.s_SearchID);
                }
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

       


    }
}