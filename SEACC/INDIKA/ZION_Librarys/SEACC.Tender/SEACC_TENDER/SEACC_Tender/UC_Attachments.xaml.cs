using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace SEACC_Tender
{
    public partial class UC_Attachments : UserControl
    {
        bool bIsUpdateMode = false;
        string Transaction_ID = "";
        int Function_ID;

        public DataTable dt2 = new DataTable();

        public UC_Attachments()
        {
            InitializeComponent();

            #region DataTable Initialize
            dt2.Columns.Add("FileName");
            dt2.Columns.Add("FilePath");
            dt2.Columns.Add("isNew");
            dt2.Columns.Add("isDeleted");
            dt2.Columns.Add("Attachment_ID");
            dt2.Columns.Add("icon");
            dgr_Upload.ItemsSource = dt2.DefaultView; 
            #endregion
        }
        public void Clear(int FunctionID)
        {
            bIsUpdateMode = false;
            Transaction_ID = "";
            Function_ID = FunctionID;
            dt2.Clear();
        }

        #region Attachment Icons
        private string GetAttachment_Icon(string Filename)
        {
            string path1 = "";
            switch (System.IO.Path.GetExtension(Filename))
            {
                case ".docx":
                case ".doc":
                case ".wps":
                    path1 = new Uri("pack://application:,,,/Resources/Docx.png", UriKind.Absolute).ToString();
                    break;
                case ".xls":
                case ".xlsx":
                case ".et":
                    path1 = new Uri("pack://application:,,,/Resources/Xls.png", UriKind.Absolute).ToString();
                    break;
                case ".jpg":
                case ".jpeg":
                    path1 = new Uri("pack://application:,,,/Resources/jpg.png", UriKind.Absolute).ToString();
                    break;
                case ".ppt":
                case ".pptx":
                    path1 = new Uri("pack://application:,,,/Resources/ppt.png", UriKind.Absolute).ToString();
                    break;
                case ".pdf":
                    path1 = new Uri("pack://application:,,,/Resources/PDF.png", UriKind.Absolute).ToString();
                    break;
                case ".txt":
                    path1 = new Uri("pack://application:,,,/Resources/txt.png", UriKind.Absolute).ToString();
                    break;
                case ".png":
                    path1 = new Uri("pack://application:,,,/Resources/png.png", UriKind.Absolute).ToString();
                    break;
                case ".zip":
                    path1 = new Uri("pack://application:,,,/Resources/Zip.png", UriKind.Absolute).ToString();
                    break;
                default:
                    path1 = new Uri("pack://application:,,,/Resources/others.png", UriKind.Absolute).ToString();
                    break;
            }
            return path1;
        } 
        #endregion

        #region Button Upload
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog File = new Microsoft.Win32.OpenFileDialog();
            if (File.ShowDialog() == true)
            {
                string sFileName = System.IO.Path.GetFileName(File.FileName);
                bool bStatus = true;
                foreach (DataRow row in dt2.Rows)
                {
                    if (row["FileName"].ToString() == sFileName)
                    {
                        SEACCMessageBox.Show("Warning", "This file allready added", MessageBoxButton.OK);
                        bStatus = false;
                        break;
                    }
                }

                if (bStatus)
                {
                    if (bIsUpdateMode)
                        insertOneAttachment(Transaction_ID, File.FileName);
                    else
                        dt2.Rows.Add(sFileName, File.FileName, true, false, "", GetAttachment_Icon(File.FileName));
                }

            }
        } 
        #endregion

        #region Button Remove
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int iSelectedIndex = dgr_Upload.SelectedIndex;
                if (iSelectedIndex != -1)
                {
                    bool messageBox = SEACCMessageBox.Show("Warning", "Are you sure you want to delete this record?", MessageBoxButton.YesNo);
                    if (messageBox)
                    {
                        DataRowView dataRow = (DataRowView)dgr_Upload.SelectedItem;
                        if (bIsUpdateMode)
                        {
                            string Attachment_ID = dataRow.Row.ItemArray[4].ToString();

                            string sFilePath = dataRow.Row.ItemArray[1].ToString();
                            System.IO.File.Delete(sFilePath);

                            tbl_ttsAttachments oAttachments = tbl_ttsAttachments.Select(Attachment_ID, Transaction_ID, Function_ID);
                            if (oAttachments != null)
                                oAttachments.Delete();
                        }

                        dataRow.Delete();
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Information", "Please select item to remove", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Fill Details
        public void FillDetails(string Transaction_ID)
        {
            dt2.Clear();
            bIsUpdateMode = true;
            this.Transaction_ID = Transaction_ID;

            foreach (tbl_ttsAttachments oAttachments in tbl_ttsAttachments.SelectAllby_function_ID_transaction_ID(Transaction_ID, Function_ID))
            {
                dt2.Rows.Add(oAttachments.DipsplayName, @"Attachments\" + oAttachments.Attachment, false, false, oAttachments.Attachment_ID, GetAttachment_Icon(oAttachments.Attachment));
            }
        } 
        #endregion

        #region Insert One Attachment
        private void insertOneAttachment(string Transaction_ID, string filePath)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            string sAttachment_ID = SEACC_Tender.UserControls.clsCommon.getAutoGeneratedCode(FormName.Attachments);

            string newFileName = sAttachment_ID + System.IO.Path.GetExtension(filePath);
            System.IO.File.Copy(filePath, @"Attachments\" + newFileName);
            tbl_ttsAttachments oAttachments = new tbl_ttsAttachments(sAttachment_ID, Transaction_ID, Function_ID, newFileName, fileName);
            oAttachments.Insert();
          
            if (bIsUpdateMode)
                dt2.Rows.Add(System.IO.Path.GetFileName(filePath), newFileName, true, false, "", GetAttachment_Icon(newFileName));
        }
        #endregion

        #region Insert
        public void Insert(string Transaction_ID)
        {
            foreach (DataRow row in dt2.Rows)
            {
                string filePath = row["FilePath"].ToString();
                insertOneAttachment(Transaction_ID, filePath);
            }
        }
        #endregion

        #region Double Click Event
        private void dgr_Upload_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dgr_Upload.SelectedItem;
                string sFilePath = dataRow.Row.ItemArray[1].ToString();
                if (System.IO.File.Exists(sFilePath))
                    System.Diagnostics.Process.Start(sFilePath);
                else
                    SEACCMessageBox.Show("Information...", "File is not exist", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                //SEACCExeption.Show(ex);
            }
        } 
        #endregion
    }
}