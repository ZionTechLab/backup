using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_toolAttachmentUpload : Form
    {
        #region Form
        public frm_toolAttachmentUpload()
        {
            InitializeComponent();
        }

        private void frm_toolAttachmentUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        } 
        #endregion

        #region Action Buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd_Attachments.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Add_AttachmentRow(ofd_Attachments.FileName, Path.GetFileName(ofd_Attachments.FileName), true, "0", 0);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvAttachment.SelectedRows.Count > 0)
            {
                dgvAttachment["isDeleted", dgvAttachment.SelectedRows[0].Index].Value = "True";
             //   dgvAttachment.Rows[dgvAttachment.SelectedRows[0].Index]["isDeleted"] = "";      //.["isDeleted", dgvAttachment.SelectedRows[0].Index].Value = "True";    //.RemoveAt(dgvAttachment.SelectedRows[0].Index);
                dgvAttachment.Rows[dgvAttachment.SelectedRows[0].Index].Visible = false;
            }
        }
        #endregion

        #region Clear Fields
        public void Clear()
        {
            iform = 0;
            sTreansaction_ID = "";

            dgvAttachment.Rows.Clear();
            dgvAttachment.Refresh();
        } 
        #endregion

        #region Grid Events
        private void dgvAttachment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAttachment.RowCount > 0)
                {
                    string strTaskId = dgvAttachment.SelectedRows[0].Cells["FilePath"].Value.ToString();
                    System.Diagnostics.Process.Start(strTaskId);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        private void dgvAttachment_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAttachment.SelectedRows.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dgvAttachment.CurrentCell = dgvAttachment.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvAttachment.Rows[e.RowIndex].Selected = true;
                    dgvAttachment.Focus();
                }
            }
        }
        #endregion

        #region Help Methods

        private void Add_AttachmentRow(string FilePath, string FileName, bool isNewItem, string task_id, int Attachment_id)
        {
            int iRow = dgvAttachment.Rows.Add();
            dgvAttachment["FilePath", iRow].Value = FilePath;
            dgvAttachment["FileName", iRow].Value = FileName;
            dgvAttachment["isNew", iRow].Value = isNewItem.ToString();
            
            if (!isNewItem)
            {
                dgvAttachment["Task_ID1", iRow].Value = task_id.ToString();
                dgvAttachment["Attachment_Index", iRow].Value = Attachment_id.ToString();
            }
            switch (Path.GetExtension(FileName))
            {
                case ".pdf":
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("PDF");
                    break;
                case ".docx":
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("Docx");
                    break;
                case ".xls":
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("Xls");
                    break;
                case ".png":
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("jpg");
                    break;
                case ".jpg":
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("jpg");
                    break;
                case ".zip":
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("Zip");
                    break;
                case ".ppt":
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("ppt");
                    break;
                default:
                    dgvAttachment["icon", iRow].Value = Properties.Resources.ResourceManager.GetObject("others");
                    break;
            }
        }


        int iform = 0;
        string sTreansaction_ID = "";
        public void FillAttachments(int Iform, string sTx_ID)
        {
            Clear();
            iform = Iform;
            sTreansaction_ID = sTx_ID;
            foreach (tbl_sasAttachments oAttachments in tbl_sasAttachments.SelectAllByForm_ID(iform).Where(r => r.Transaction_ID == sTx_ID))
            {
                string sDestFile = @""+clsConfig.sAttachmentPath_Server+"\\" + oAttachments.Attachment;
                //Add_AttachmentRow(@"Attachments\" + oAttachments.Attachment, oAttachments.DipsplayName, false, oAttachments.Transaction_ID, oAttachments.Attachment_Index);
                Add_AttachmentRow(sDestFile, oAttachments.DipsplayName, false, oAttachments.Transaction_ID, oAttachments.Attachment_Index);
            }
        }

        #endregion

        public void Insert(int Iform, string sTx_ID)
        {
            iform = Iform;
            sTreansaction_ID = sTx_ID;
            Attachments_Insert(iform, sTreansaction_ID, dgvAttachment);
        }
        public void Remove(int Iform, string sTx_ID)
        {
            iform = Iform;
            sTreansaction_ID = sTx_ID;
            Attachments_Remove(iform, sTreansaction_ID, dgvAttachment);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Remove deleted files
        public static void Attachments_Remove(int ifromID, string sTx_ID, DataGridView dgvAttches)
        {
            foreach (DataGridViewRow row in dgvAttches.Rows)
            {
                bool isDeleted = false;
                try
                {
                    isDeleted = row.Cells["isDeleted"].Value.ToString() == "True" ? true : false;
                }
                catch (Exception){ }

                if (isDeleted)
                {
                    if (row.Cells["isNew"].Value.ToString() != "True")
                    {
                        string file = row.Cells["FilePath"].Value.ToString();
                        if (System.IO.File.Exists(file))
                         System.IO.File.Delete(file);

                        foreach (tbl_sasAttachments oAttachments in tbl_sasAttachments.SelectAllByForm_ID(ifromID).Where(r => r.Transaction_ID == sTx_ID))
                        {
                            //if (oAttachments.Attachment == file.Replace("Attachments\\", ""))
                            if (oAttachments.Attachment == file.Replace(clsConfig.sAttachmentPath_Server, ""))
                                oAttachments.Delete();
                        }
                    }
                }
            }

            //string sTx_ID_Rev = sTx_ID.Replace("/", "-!");
            //sTx_ID_Rev = sTx_ID_Rev.Replace("\\", "-!");
            //string[] files = System.IO.Directory.GetFiles("Attachments", sTx_ID_Rev + ".*");
            //if (files.Length != 0)
            //{
            //    foreach (string file in files)
            //    {
            //        bool bIsDeletedFile = true;
            //        foreach (DataGridViewRow row in dgvAttches.Rows)
            //        {
            //            if (row.Cells["isNew"].Value.ToString() != "True")
            //            {
            //                if (row.Cells["FilePath"].Value.ToString() == file)
            //                {
            //                    bIsDeletedFile = false;
            //                    break;
            //               }
            //            }
            //            //else
            //            //    bIsDeletedFile = false;
            //        }
            //        if (bIsDeletedFile)
            //        {
            //            System.IO.File.Delete(file);
            //            foreach (tbl_sasAttachments oAttachments in tbl_sasAttachments.SelectAllByForm_ID(ifromID).Where(r => r.Transaction_ID == sTx_ID))
            //            {
            //                if (oAttachments.Attachment == file.Replace("Attachments\\", ""))
            //                    oAttachments.Delete();
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        #region Save new Attachments
        public static void Attachments_Insert(int ifromID, string sTx_ID, DataGridView dgvAttches)
        {
            string sTx_ID_Rev = sTx_ID.Replace("/", "-!");
            sTx_ID_Rev = sTx_ID_Rev.Replace("\\", "-!");
            foreach (DataGridViewRow row in dgvAttches.Rows)
            {
                bool isDeleted = false;
                try
                {
                    isDeleted = row.Cells["isDeleted"].Value.ToString() == "True" ? true : false;
                }
                catch (Exception) { }
                if (row.Cells["isNew"].Value.ToString() == "True" && !isDeleted)
                {
                    string SourcefilePath = row.Cells["FilePath"].Value.ToString();
                    string Sourcefilename = System.IO.Path.GetFileName(SourcefilePath);
                    int iAttachment_ID = GetAttachmentID(sTx_ID_Rev);
                    string newFilePath = sTx_ID_Rev + "." + iAttachment_ID + System.IO.Path.GetExtension(SourcefilePath);
                    string sDestPath = @""+clsConfig.sAttachmentPath_Server+ "\\" + newFilePath;
                    //System.IO.File.Copy(SourcefilePath, @"Attachments\" + newFilePath);
                    System.IO.File.Copy(SourcefilePath, sDestPath);

                    tbl_sasAttachments oAttachments = new tbl_sasAttachments(sTx_ID, iAttachment_ID, ifromID, newFilePath, Sourcefilename);
                    oAttachments.Insert();
                }
            }
        }
        #endregion

        private static int GetAttachmentID(string sTx_ID)
        {
            int i = 1;
            string sTx_ID_Rev = sTx_ID.Replace("/", "-!");
            sTx_ID_Rev = sTx_ID_Rev.Replace("\\", "-!");
            //string[] files = System.IO.Directory.GetFiles("Attachments", sTx_ID_Rev + "." + i + ".*");
            string[] files = System.IO.Directory.GetFiles(clsConfig.sAttachmentPath_Server, sTx_ID_Rev + "." + i + ".*");

            while (files.Length != 0)
            {
                i++;
                //files = System.IO.Directory.GetFiles("Attachments", sTx_ID_Rev + "." + i + ".*");
                files = System.IO.Directory.GetFiles(clsConfig.sAttachmentPath_Server, sTx_ID_Rev + "." + i + ".*");
            }

            return i;
        }

    }
}