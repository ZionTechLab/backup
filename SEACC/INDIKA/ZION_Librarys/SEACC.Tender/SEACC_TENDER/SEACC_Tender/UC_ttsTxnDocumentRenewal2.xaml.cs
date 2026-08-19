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
using SEACC_WPFControls;
using DataTire;
using SEACC_Tender.UserControls;
using System.Data;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;
using System.IO;


namespace SEACC_Tender
{

    public partial class UC_ttsTxnDocumentRenewal2 : UserControl
    {
        #region Class Variables
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
       // private System.Windows.Forms.BindingSource bsInward = new System.Windows.Forms.BindingSource();
        public int iFormID;
        //bool bIsItemChanged = false;
        #endregion

        #region Form Load
        public UC_ttsTxnDocumentRenewal2()
        {
            InitializeComponent();

            #region Initialize Form
            SEACC_Form.enmFormName = FormName.DocumentLicenceRenewal2;
            iFormID = clsSecurity.getFormID(FormName.DocumentLicenceRenewal);
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt.Columns.Add("DocRenewalID");
            dt.Columns.Add("DocumentID");
            dt.Columns.Add("DocumentCode");
            dt.Columns.Add("DocumentName");
            dt.Columns.Add("RenewalType");
            dt.Columns.Add("RenewalsID");
            dt.Columns.Add("Renewals");
            dt.Columns.Add("ExpiryDate");
            dgr_Documents.ItemsSource = dt.DefaultView;

            dt2.Columns.Add("FileName");
            dt2.Columns.Add("FilePath");
            dt2.Columns.Add("isNew");
            dt2.Columns.Add("isDeleted");
            dt2.Columns.Add("Attachment_ID");
            dt2.Columns.Add("icon");
            dgr_Upload.ItemsSource = dt2.DefaultView;
            #endregion

            #region Action Button Initialize
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            //this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrids();

            txtItemCode.Visibility = Visibility.Collapsed;
            txtBrandName.Visibility = Visibility.Collapsed;
            txtSupplier.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualHeight < 650)
                dgr_Documents.Height = 200;
            else
                dgr_Documents.Height = 450;
        }
        #endregion

        #region Action Button
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    string sDocID = "";
                    try
                    {
                        sDocID = txtDocRenewalID.Text;
                        if (SEACC_Form.IsUpdateMode)
                        {
                            #region Update
                            tbl_ttsTenderDocumentRenewal oldDetail = tbl_ttsTenderDocumentRenewal.Select(txtDocRenewalID.Text);
                            if (oldDetail != null)
                            {
                                string sRenewals = "";
                                if (rdoDocument.IsChecked == true)
	                            {
		                            sRenewals = Renewals.DocumentBased.ToString();
	                            }
                                else if (rdoItem.IsChecked == true)
	                            {
		                            sRenewals = Renewals.ItemBased.ToString();
	                            }
                                else if (rdoManufacturer.IsChecked == true)
	                            {
		                            sRenewals = Renewals.ManufacturerBased.ToString();
	                            }

                                //tbl_ttsTenderDocumentRenewal oDetails = new tbl_ttsTenderDocumentRenewal(txtDocRenewalID.Text, int.Parse(sRenewals), txtItemCode.Tag.ToString(), "", txtDocCode.Tag.ToString(), int.Parse(txtRenewalType1.Tag.ToString()), 0, dtpExpiryDate.GetDateTime().Date, txtRemarks.Text, int.Parse(txtReminderDays.Text), cmbFrequence.GetSelectedIndex(), dtpTime.GetDateTime().Date, true, false);
                                //oDetails.Update();
                                Attachments_Insert_Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                            #endregion
                        }
                        else
                        {
                            #region Insert
                            string sRenewals = "";
                            if (rdoDocument.IsChecked == true)
                            {
                                sRenewals = Renewals.DocumentBased.ToString();
                            }
                            else if (rdoItem.IsChecked == true)
                            {
                                sRenewals = Renewals.ItemBased.ToString();
                            }
                            else if (rdoManufacturer.IsChecked == true)
                            {
                                sRenewals = Renewals.ManufacturerBased.ToString();
                            }

                            if (SEACC_Form.isAutoGenaratedCode)
                                sDocID = txtDocRenewalID.Text = SEACC_Form.getAutoGeneratedCode();

                            //tbl_ttsTenderDocumentRenewal oDetail = new tbl_ttsTenderDocumentRenewal(txtDocRenewalID.Text, int.Parse(sRenewals), txtItemCode.Tag.ToString(), "", txtDocCode.Tag.ToString(), int.Parse(txtRenewalType1.Tag.ToString()), 0, dtpExpiryDate.GetDateTime().Date, txtRemarks.Text, int.Parse(txtReminderDays.Text), cmbFrequence.GetSelectedIndex(), dtpTime.GetDateTime(), true, false);
                            //oDetail.Insert();
                            Attachments_Insert_Update();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            #endregion
                        }
                    }
                    catch (Exception Ex)
                    {
                        SEACCExeption.Show(Ex);
                    }
                    finally
                    {
                        ClearFields();
                        FillDetails(sDocID);
                    }
                }

            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.IsUpdateMode)
            {
                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                if (bMessegeBoxResult)
                {
                    tbl_ttsTenderDocumentRenewal Detail = tbl_ttsTenderDocumentRenewal.Select(txtDocRenewalID.Tag.ToString());
                    if (Detail != null)
                    {
                        Detail.IsCanceled = true;
                        Detail.IsActive = false;
                        Detail.Update();

                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                        string sItemCode = Detail.Item_ID.ToString();
                        ClearFields();;
                    }
                }
            }
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dt.Clear();
            dt2.Clear();

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtDocRenewalID, false, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtReminderDays, true, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpTime, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpExpiryDate, true, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItemCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDocCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRenewalType1, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrandName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSupplier, true, false, true);
            

            //rdoGCertification.IsChecked = false;
            //rdoPBCertification.IsChecked = true;

            //stackGeneralandProduct.Visibility = Visibility.Collapsed;

            //txtCategory.Text = "";
            txtDocCode.Text = "";
            txtDocDescription.Text = "";
            txtDocRenewalID.Text = "";
            txtDocType.Text = "";
            txtItemCode.Text = "";
            txtRemarks.Text = "";
            txtReminderDays.Text = "0";
            txtRenewalType1.Text = "";
            //txtType.Text = "";

            txtItemCode.Tag = null;
            txtDocRenewalID.Tag = null;
            txtDocCode.Tag = null;
            txtRenewalType1.Tag = null;

            if (SEACC_Form.isAutoGenaratedCode)
                txtDocRenewalID.Text = "<Auto Generated>";

            RefreshGrids();

            cmbFrequence.comboBox.ItemsSource = Common.clsHelpMethods.GetEnumDescription(typeof(Frequence));
            cmbFrequence.SetSelectedIndex(0);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrids()
        {
            dt.Clear();
            foreach (tbl_ttsTenderDocumentRenewal oDetails in tbl_ttsTenderDocumentRenewal.SelectAll().Where(p => p.IsCanceled != true))
            {
                string sDocumentTypes = "", sRenewals = "";
                tbl_ttsTenderDocumentMaster oDocument = tbl_ttsTenderDocumentMaster.Select(oDetails.Doc_ID);
                if (oDocument != null)
                {
                    sDocumentTypes = (Common.clsHelpMethods.GetEnumDescription(typeof(DocumentType)))[oDocument.Doc_Type];
                    sRenewals = (Common.clsHelpMethods.GetEnumDescription(typeof(Renewals)))[oDetails.Renewals];

                    dt.Rows.Add(oDetails.Doc_Renewal_ID, oDetails.Doc_ID, oDocument.Doc_Code, sDocumentTypes, clsRef_Name.get_Renewal_Types(oDetails.Renewal_Type1_ID.ToString()),oDetails.Renewals, sRenewals, oDetails.ExpiryDate.ToShortDateString());
                }
            }
        }

        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID != null)
            {
                ClearFields();
                SEACC_Form.IsUpdateMode = true;

                tbl_ttsTenderDocumentRenewal oDetails = tbl_ttsTenderDocumentRenewal.Select(sID);             
                if (oDetails != null)
                {
                    txtDocRenewalID.Text = oDetails.Doc_Renewal_ID;
                    txtDocRenewalID.Tag = oDetails.Doc_Renewal_ID.ToString();
                    
                    txtRenewalType1.Text = clsRef_Name.get_Renewal_Types(oDetails.Renewal_Type1_ID.ToString());
                    txtRenewalType1.Tag = oDetails.Renewal_Type1_ID.ToString();
                    dtpExpiryDate.SetTime(oDetails.ExpiryDate);
                    txtRemarks.Text = oDetails.Remarks.ToString();

                    txtReminderDays.Text = oDetails.ReminderDays.ToString();
                    dtpTime.SetTime(oDetails.ReminderTime);
                    cmbFrequence.SetSelectedIndex(oDetails.ReminderFrequence);

                    tbl_ttsTenderDocumentMaster oDocument = tbl_ttsTenderDocumentMaster.Select(oDetails.Doc_ID);
                    if (oDocument != null)
                    {
                        txtDocCode.Tag = oDetails.Doc_ID.ToString();
                        txtDocCode.Text = oDocument.Doc_Code.ToString();
                        txtDocDescription.Text = oDocument.Doc_Description.ToString();
                        int sDocType = int.Parse(oDocument.Doc_Type.ToString());
                        txtDocType.Text = (Common.clsHelpMethods.GetEnumDescription(typeof(DocumentType)))[sDocType];
                    }

                    foreach (tbl_ttsAttachments oAttachments in tbl_ttsAttachments.SelectAll().Where(p => p.Transaction_ID == oDetails.Doc_Renewal_ID))
                    {
                        dt2.Rows.Add(oAttachments.DipsplayName,@"Attachments\"+ oAttachments.Attachment, false, false,oAttachments.Attachment_ID , null);
                    }
                    FillDetails_Item(oDetails.Item_ID.ToString());
                }
            }
        }

        private void FillDetails_Item(string sItemID)
        {
            if (sItemID != null)
            {
                try
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
                    if (oItem != null)
                    {
                        string sItemFullName = sItemID + " - " + clsRef_Name.get_Item_Name(sItemID);

                        txtItemCode.Tag = sItemID;
                        txtItemCode.Text = sItemFullName.ToString();

                        dt.Clear();
                        foreach (tbl_ttsTenderDocumentRenewal oDetails in tbl_ttsTenderDocumentRenewal.SelectAllByItem_ID(sItemID).Where(p => p.IsCanceled != true))
                        {
                            string sDocumentTypes = "", sRenewals = "";
                            tbl_ttsTenderDocumentMaster oDocument = tbl_ttsTenderDocumentMaster.Select(oDetails.Doc_ID);
                            if (oDocument != null)
                            {
                                sDocumentTypes = (Common.clsHelpMethods.GetEnumDescription(typeof(DocumentType)))[oDocument.Doc_Type];
                                sRenewals = (Common.clsHelpMethods.GetEnumDescription(typeof(Renewals)))[oDetails.Renewals];

                                dt.Rows.Add(oDetails.Doc_Renewal_ID, oDetails.Doc_ID, oDocument.Doc_Code, sDocumentTypes, clsRef_Name.get_Renewal_Types(oDetails.Renewal_Type1_ID.ToString()), oDetails.Renewals, sRenewals, oDetails.ExpiryDate.ToShortDateString());
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }
        }
        #endregion

        #region Search
        private void txtDocCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch DataRowSearch = new Search_Forms.frmSearch();
            List<string> lstResult = DataRowSearch.Show(Search.Ten_Document);
            if (DataRowSearch.DialogResult == true)
            {
                txtDocCode.Tag = lstResult[0];
                txtDocCode.Text = lstResult[1];


                int iTypeId = int.Parse(lstResult[2]);
                string sVal = (Common.clsHelpMethods.GetEnumDescription(typeof(DocumentType)))[iTypeId];
                txtDocType.Text = sVal;

                txtDocDescription.Text = lstResult[3];
            }
        }

        private void txtItemCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Items);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                FillDetails_Item(lstResult[0]);
            }
        }
    

        private void txtRenewalType1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch DataRowSearch = new Search_Forms.frmSearch();
            List<string> lstResult = DataRowSearch.Show(Search.Ten_RenewalTypes);
            if (DataRowSearch.DialogResult == true)
            {
                txtRenewalType1.Text = lstResult[1];
                txtRenewalType1.Tag = lstResult[0];
            }
        }

        private void txtDocRenewalID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Ten_DocumentRenewal);
            if (RowDataSearch.DialogResult == true)
            {
                FillDetails(lstResult[0]);
            }
        }

        private void txtBrandName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Brand);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                //FillDetails_Item("",lstResult[0],"");
            }
        }

        private void txtSupplier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //frmSearch RowDataSearch = new frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.Manufacturers);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    ClearFields();
            //      FillDetails_Item(lstResult[0]);
            //}
        }

        #endregion

        #region Grid Event
        private void dgr_Documents_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oItem = dgr_Documents.SelectedItem;
                if (oItem != null)
                {
                    string sId = (dgr_Documents.SelectedCells[0].Column.GetCellContent(oItem) as TextBlock).Text;
                    FillDetails(sId);
                }
            }
            catch (Exception ex)
            {

                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                //if (CheckGridvalidity())
                //{
                //    if (CheckValidity_DuplicateKey())
                //    {
                //        if (CheckValidity_GrossAmount())
                bStatus = true;
                //    }
                //}
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            //if (!clsValidation.Validate_EmptyValue(txtItemCode, ref strMessage))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDocCode, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtRenewalType1, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(cmbFrequence))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage, MessageBoxButton.OK);

            return bStatus;
        }
        #endregion

        #region File Upload
        #region Upload Files
        private void btnUploadLetter_Click(object sender, RoutedEventArgs e)
        {
            //if (txtDocRenewalID.Text != "<Auto Generated>" && txtDocRenewalID.Text != "")
            //{
            Microsoft.Win32.OpenFileDialog File = new Microsoft.Win32.OpenFileDialog();
            if (File.ShowDialog() == true)
            {
                //foreach (DataRow row in dt2.Rows)
                //{
                //BitmapImage img;
                object obj = "";
                //ImageSource imageSource = new BitmapImage(new Uri(openFileDialog1.FileName));
                switch (System.IO.Path.GetExtension(File.FileName))
                {
                    case ".pdf":
                        obj = Properties.Resources.ResourceManager.GetObject("PDF");
                        break;
                    case ".docx":
                        obj = Properties.Resources.ResourceManager.GetObject("Docx");
                        break;
                    case ".txt":
                        obj = Properties.Resources.ResourceManager.GetObject("txt");
                        break;
                    case ".xls":
                        obj = Properties.Resources.ResourceManager.GetObject("Xls");
                        break;
                    case ".xlsx":
                        obj = Properties.Resources.ResourceManager.GetObject("Xls");
                        break;
                    case ".png":
                        obj = Properties.Resources.ResourceManager.GetObject("png");
                        break;
                    case ".jpg":
                        obj = Properties.Resources.ResourceManager.GetObject("jpg");
                        break;
                    case ".jpeg":
                        obj = Properties.Resources.ResourceManager.GetObject("jpg");
                        break;
                    case ".zip":
                        obj = Properties.Resources.ResourceManager.GetObject("Zip");
                        break;
                    case ".ppt":
                        obj = Properties.Resources.ResourceManager.GetObject("ppt");
                        break;
                    case ".pptx":
                        obj = Properties.Resources.ResourceManager.GetObject("ppt");
                        break;
                    default:
                        obj = Properties.Resources.ResourceManager.GetObject("others");
                        break;
                }
                //}

                dt2.Rows.Add(System.IO.Path.GetFileName(File.FileName), File.FileName, true, false, "", obj);
                //Add_AttachmentRow(File.FileName, System.IO.Path.GetFileName(File.FileName), true, "0", 0);
            }
            //}
            //else
            //{
            //    SEACCMessageBox.Show("Fields cannot be Empty....", "Document Renewal ID", MessageBoxButton.OK);
            //}
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Upload.SelectedIndex;
            if (irowID != -1)
            {
                dt2.Rows[irowID]["isDeleted"] = "True";

                object selectedItem = dgr_Upload.SelectedItem;
                dt2.DefaultView.RowFilter = "isDeleted=False";
            }
        }
        #endregion

        #region Add Attachment Row
        private void Add_AttachmentRow(string FilePath, string FileName, bool isNewItem, string task_id, int Attachment_id)
        {
            dt2.Rows.Add(FileName, FilePath, isNewItem.ToString(), false, task_id.ToString(), Attachment_id.ToString(), "");
            //foreach (DataRow row in dt2.Rows)
            //{
            //    switch (System.IO.Path.GetExtension(FileName))
            //    {
            //        case ".pdf":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("PDF");
            //            break;
            //        case ".docx":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("Docx");
            //            break;
            //        case ".txt":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("txt");
            //            break;
            //        case ".xls":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("Xls");
            //            break;
            //        case ".xlsx":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("Xls");
            //            break;
            //        case ".png":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("png");
            //            break;
            //        case ".jpg":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("jpg");
            //            break;
            //        case ".jpeg":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("jpg");
            //            break;
            //        case ".zip":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("Zip");
            //            break;
            //        case ".ppt":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("ppt");
            //            break;
            //        case ".pptx":
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("ppt");
            //            break;
            //        default:
            //            row["icon"] = Properties.Resources.ResourceManager.GetObject("others");
            //            break;
            //    }
            // }
        }
        #endregion

        #region Attachments Insert / Update
        public void Attachments_Insert_Update()
        {
            foreach (DataRow row in dt2.Rows)
            {
                bool isDeleted = row["isDeleted"].ToString() == "True" ? true : false;
                bool isNew = row["isNew"].ToString() == "True" ? true : false;
                string filePath = row["FilePath"].ToString();
                string fileName = System.IO.Path.GetFileName(filePath);

                if (isNew && !isDeleted)
                {
                    string sAttachment_ID = SEACC_Tender.UserControls.clsCommon.getAutoGeneratedCode(FormName.Attachments);

                    string newFileName = sAttachment_ID + System.IO.Path.GetExtension(filePath);
                    System.IO.File.Copy(filePath, @"Attachments\" + newFileName);
                    tbl_ttsAttachments oAttachments = new tbl_ttsAttachments(sAttachment_ID, txtDocRenewalID.Text, 0, newFileName, fileName);
                    oAttachments.Insert();
                }
                if (!isNew && isDeleted)
                {
                    string sAttachment_ID = row["Attachment_ID"].ToString();
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);

                    //tbl_ttsTenderAttachments oAttachments = tbl_ttsTenderAttachments.Select(sAttachment_ID);
                    //if (oAttachments != null)
                    //{
                    //    if (oAttachments.Attachment == fileName)
                    //        oAttachments.Delete();
                    //}
                }
            }
        }
        #endregion

        #region Display Files
        private void dgr_Upload_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oItem = dgr_Upload.SelectedItem;
                if (oItem != null)
                {
                    string sId = (dgr_Upload.SelectedCells[1].Column.GetCellContent(oItem) as TextBlock).Text;
                    System.Diagnostics.Process.Start(sId);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion 
        #endregion

        #region Radio Button Events
        private void rdoGCertification_Click(object sender, RoutedEventArgs e)
        {
            txtItemCode.Visibility = Visibility.Collapsed;
        }

        private void rdoPBCertification_Click(object sender, RoutedEventArgs e)
        {
            txtItemCode.Visibility = Visibility.Visible;
        }
        #endregion

        #region Radion Button Events
        private void rdoDocument_Click(object sender, RoutedEventArgs e)
        {
            txtItemCode.Visibility = Visibility.Collapsed;
            txtBrandName.Visibility = Visibility.Collapsed;
            txtSupplier.Visibility = Visibility.Collapsed;

            ClearFields();

            string sDocumentBased = "";
            int iDocumentBased = (int)Renewals.DocumentBased;
            sDocumentBased = (Common.clsHelpMethods.GetEnumDescription(typeof(Renewals)))[iDocumentBased];
            
            if (sDocumentBased != null)
                dt.DefaultView.RowFilter = "Renewals='" + sDocumentBased + "'";
            else
                dt.DefaultView.RowFilter = string.Empty;
        }

        private void rdoItem_Click(object sender, RoutedEventArgs e)
        {
            txtItemCode.Visibility = Visibility.Visible;
            txtBrandName.Visibility = Visibility.Visible;
            txtSupplier.Visibility = Visibility.Collapsed;

            ClearFields();

            string sItemBased = "";
            int iItemBased = (int)Renewals.ItemBased;
            sItemBased = (Common.clsHelpMethods.GetEnumDescription(typeof(Renewals)))[iItemBased];

            if (sItemBased != null && sItemBased != "")
                dt.DefaultView.RowFilter = "Renewals='" + sItemBased + "'";
            else
                dt.DefaultView.RowFilter = string.Empty;
        }

        private void rdoManufacturer_Click(object sender, RoutedEventArgs e)
        {
            txtItemCode.Visibility = Visibility.Visible;
            txtBrandName.Visibility = Visibility.Visible;
            txtSupplier.Visibility = Visibility.Visible;

            ClearFields();

            string sManufactureBased = "";
            int iManufactureBased = (int)Renewals.ManufacturerBased;
            sManufactureBased = (Common.clsHelpMethods.GetEnumDescription(typeof(Renewals)))[iManufactureBased];

            if (sManufactureBased != null && sManufactureBased != "")
                dt.DefaultView.RowFilter = "Renewals='" + sManufactureBased + "'";
            else
                dt.DefaultView.RowFilter = string.Empty;
        } 
        #endregion
    }
}