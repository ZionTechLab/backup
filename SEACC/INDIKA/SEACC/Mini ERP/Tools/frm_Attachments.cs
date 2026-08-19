using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_Attachments : Form
    {
        #region Class Variables
        private const int CS_DROPSHADOW = 0x20000;
        bool bIsUpdateMode = false;
        string sTransaction_ID = "";
        public int iFormID;
        public DataTable dtAttachments = new DataTable();
        #endregion

        #region Form Load
        public frm_Attachments()
        {
            InitializeComponent();

            #region DataTable Initialize
            dtAttachments.Columns.Add("icon", typeof(Bitmap));
            dtAttachments.Columns.Add("Attachment_ID");
            dtAttachments.Columns.Add("FileName");
            dtAttachments.Columns.Add("FilePath");
            dtAttachments.Columns.Add("isNew");
            dtAttachments.Columns.Add("isDeleted");
            dgv_Upload.DataSource = dtAttachments.DefaultView;
            #endregion
        }
        #endregion

        #region Dropshadow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            bIsUpdateMode = false;
            sTransaction_ID = "";
            iFormID = 0;
            dtAttachments.Clear();
        }
        #endregion

        #region Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region Attachment Icons
        private object GetAttachment_Icon(string Filename)
        {
            object path1 = "";
            switch (Path.GetExtension(Filename))
            {
                case ".docx":
                case ".doc":
                case ".wps":
                    path1 = Properties.Resources.ResourceManager.GetObject("Docx"); //new Uri("pack://application:,,,/Resources/Docx.png", UriKind.Absolute).ToString();
                    break;
                case ".xls":
                case ".xlsx":
                case ".et":
                    path1 = Properties.Resources.ResourceManager.GetObject("Xls"); //new Uri("pack://application:,,,/Resources/Xls.png", UriKind.Absolute).ToString();
                    break;
                case ".jpg":
                case ".jpeg":
                    path1 = Properties.Resources.ResourceManager.GetObject("jpg"); //new Uri("pack://application:,,,/Resources/jpg.png", UriKind.Absolute).ToString();
                    break;
                case ".ppt":
                case ".pptx":
                    path1 = Properties.Resources.ResourceManager.GetObject("ppt"); //new Uri("pack://application:,,,/Resources/ppt.png", UriKind.Absolute).ToString();
                    break;
                case ".pdf":
                    path1 = Properties.Resources.ResourceManager.GetObject("PDF"); //new Uri("pack://application:,,,/Resources/PDF.png", UriKind.Absolute).ToString();
                    break;
                case ".txt":
                    path1 = Properties.Resources.ResourceManager.GetObject("txt"); //new Uri("pack://application:,,,/Resources/txt.png", UriKind.Absolute).ToString();
                    break;
                case ".png":
                    path1 = Properties.Resources.ResourceManager.GetObject("png"); //new Uri("pack://application:,,,/Resources/png.png", UriKind.Absolute).ToString();
                    break;
                case ".zip":
                    path1 = Properties.Resources.ResourceManager.GetObject("Zip"); //new Uri("pack://application:,,,/Resources/Zip.png", UriKind.Absolute).ToString();
                    break;
                default:
                    path1 = Properties.Resources.ResourceManager.GetObject("others"); //new Uri("pack://application:,,,/Resources/others.png", UriKind.Absolute).ToString();
                    break;
            }
            return path1;
        }
        #endregion

        #region Button Upload
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
               OpenFileDialog File = new OpenFileDialog();
                if (File.ShowDialog() == DialogResult.OK)
                {
                    string sFileName = System.IO.Path.GetFileName(File.FileName);
                    bool bStatus = true;
                    foreach (DataRow row in dtAttachments.Rows)
                    {
                        if (row["FileName"].ToString() == sFileName)
                        {
                            MessageBox.Show("This file allready added", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bStatus = false;
                            break;
                        }
                    }

                    if (bStatus)
                    {
                        if (bIsUpdateMode)
                            insertOneAttachment(sTransaction_ID, File.FileName);
                        else
                            dtAttachments.Rows.Add(GetAttachment_Icon(File.FileName), "", sFileName, File.FileName, true, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Button Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Upload.SelectedCells.Count != 0)
                {
                    int iSelectedIndex = dgv_Upload.SelectedCells[1].RowIndex;
                    if (iSelectedIndex >= 0)
                    {
                        if (bIsUpdateMode)
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "Warning..!", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                string sTempFilePath = "";
                                int Attachment_ID = int.Parse(dgv_Upload["Attachment_ID", iSelectedIndex].Value.ToString());
                                string sFilePath = dgv_Upload["FilePath", iSelectedIndex].Value.ToString();

                                tbl_sasAttachments oAttachments = tbl_sasAttachments.Select(sTransaction_ID, Attachment_ID);
                                if (oAttachments != null)
                                {
                                    if (File.Exists(sFilePath))
                                    {
                                        File.Delete(sFilePath);

                                        oAttachments.Delete();
                                        dgv_Upload.Rows.RemoveAt(iSelectedIndex);
                                    }
                                    else
                                        MessageBox.Show("This file is not exists in the current folder", "Information", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            dgv_Upload.Rows.RemoveAt(iSelectedIndex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select item to remove", "Information", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Fill Details
        public void FillDetails(string Transaction_ID)
        {
            try
            {
                dtAttachments.Clear();
                bIsUpdateMode = true;
                this.sTransaction_ID = Transaction_ID;

                foreach (tbl_sasAttachments oAttachments in tbl_sasAttachments.SelectAllByForm_ID(iFormID).Where(r => r.Transaction_ID == Transaction_ID))
                {
                    dtAttachments.Rows.Add(GetAttachment_Icon(oAttachments.Attachment), oAttachments.Attachment_Index, oAttachments.DipsplayName, @"" + clsConfig.sAttachmentPath_Server + "\\" + oAttachments.Attachment, false, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Insert One Attachment
        private void insertOneAttachment(string Transaction_ID, string filePath)
        {
            try
            {
                string sTransaction_ID_Rev = Transaction_ID.Replace("/", "-!");
                sTransaction_ID_Rev = sTransaction_ID_Rev.Replace("\\", "-!");

                string fileName = System.IO.Path.GetFileName(filePath);
                int sAttachment_ID = clsHelpMethods_Local.GetAttachmentID(sTransaction_ID_Rev);
                string newFilePath = sTransaction_ID_Rev + "-" + sAttachment_ID + System.IO.Path.GetExtension(filePath);
                string sDestPath = @"" + clsConfig.sAttachmentPath_Server + "\\" + newFilePath;

                bool bStatus = FolderPermission(sDestPath);
                if (bStatus)
                {
                    if (!System.IO.File.Exists(sDestPath))
                    {
                        System.IO.File.Copy(filePath, sDestPath);
                        tbl_sasAttachments oAttachments = new tbl_sasAttachments(Transaction_ID, sAttachment_ID, iFormID, newFilePath, fileName);
                        oAttachments.Insert();
                    }
                    else
                        MessageBox.Show("File already exists in the current folder", "Information", MessageBoxButtons.OK);
                }

                if (bIsUpdateMode)
                    dtAttachments.Rows.Add(GetAttachment_Icon(newFilePath), sAttachment_ID, System.IO.Path.GetFileName(filePath), sDestPath, true, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Insert
        public void Insert(string Transaction_ID)
        {
            foreach (DataRow row in dtAttachments.Rows)
            {
                string filePath = row["FilePath"].ToString();
                insertOneAttachment(Transaction_ID, filePath);
            }
        }
        #endregion

        #region Double Click Event
        private void dgv_Upload_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int iSelectedIndex = dgv_Upload.SelectedCells[1].RowIndex;
                if (iSelectedIndex >= 0)
                {
                    string sFilePath = dgv_Upload["FilePath", iSelectedIndex].Value.ToString();
                    if (System.IO.File.Exists(sFilePath))
                        System.Diagnostics.Process.Start(sFilePath);
                    else
                        MessageBox.Show("File is not exist", "Information...", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Check Folder Permission
        private bool FolderPermission(string path)
        {
            bool bPermission = false;

            PermissionSet permissionSet = new PermissionSet(PermissionState.None);
            FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.AllAccess, path);

            permissionSet.AddPermission(writePermission);
            if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
            {
                bPermission = true;
            }
            else
            {
                MessageBox.Show("You don't have write permissions", "Information...", MessageBoxButtons.OK);
                bPermission = false;
            }

            return bPermission;
        }
        #endregion
    }
}
