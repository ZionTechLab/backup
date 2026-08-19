using Digiteq_Logic;
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
using SEACC_Tender.Search_Forms;

namespace SEACC_Tender
{
    public partial class UC_ttsTxnTenderNotice : UserControl
    {
        #region Class Variables
        private DataTable dt_Item = new DataTable();
        private DataTable dt_Delevary = new DataTable();

        DateTime defaultDateTime = new DateTime(1800, 1, 1);
        #endregion

        #region Form Load
        public UC_ttsTxnTenderNotice()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Tender;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            //dt_Item.Columns.Add("LineNo");
            dt_Item.Columns.Add("SRNo");
            dt_Item.Columns.Add("ItemID");
            dt_Item.Columns.Add("ItemName");
            dt_Item.Columns.Add("GenericName");
            dt_Item.Columns.Add("Specification");
            dt_Item.Columns.Add("UoMCode");
            dt_Item.Columns.Add("UoM");
            dt_Item.Columns.Add("Quantity");
            //dt_Item.Columns.Add("Delivery");
            dt_Item.Columns.Add("Icon");
            dt_Item.Columns.Add("Strength");
            dt_Item.Columns.Add("ShelfLife");
            dt_Item.Columns.Add("Packing");
            dgr_Tender.ItemsSource = dt_Item.DefaultView;

            dt_Delevary.Columns.Add("DeliveryID");
            dt_Delevary.Columns.Add("SRNo");
            dt_Delevary.Columns.Add("DeliveryDate");
            dt_Delevary.Columns.Add("Qty");
            dt_Delevary.Columns.Add("Location");
            dgv_DeliveryDetails.ItemsSource = dt_Delevary.DefaultView;

            dgr_Main.dt.Columns.Add("TenderID");
            dgr_Main.dt.Columns.Add("TenderNo");
            dgr_Main.dt.Columns.Add("Customer");
            dgr_Main.dt.Columns.Add("NoticeDate");
            dgr_Main.dt.Columns.Add("DocCollectionDate");
            dgr_Main.dt.Columns.Add("TenClosingDate");
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Tender ID", "TenderID", 100, false);
            dgr_Main.Add_DatagridColoumn("Tender/Bid No", "TenderNo", 100);
            dgr_Main.Add_DatagridColoumn("Customer", "Customer", 100);
            dgr_Main.Add_DatagridColoumn("Notice Date", "NoticeDate", 100);
            dgr_Main.Add_DatagridColoumn("Doc. Collection Date", "DocCollectionDate", 100);
            dgr_Main.Add_DatagridColoumn("Ten. Closing Date", "TenClosingDate", 100);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtTenderNo.Focus();
        }

        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                ColumnA.Width = new GridLength(200);
            else
                ColumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons
        #region New
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion

        #region Cancel
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                    if (bMessegeBoxResult)
                    {
                        tbl_ttsTenderNotice oDetail = tbl_ttsTenderNotice.Select(txtTenderID.Tag.ToString());
                        if (oDetail != null)
                        {
                            oDetail.IsCanceled = true;
                            oDetail.Update();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                            ClearFields();
                            RefreshGrid();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Save
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    Cursor = Cursors.Wait;
                    string sTenderID = "", sItemIDs = "", sUoMs = "";
                    try
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_ttsTenderNotice oldDetail = tbl_ttsTenderNotice.Select(txtTenderID.Tag.ToString());
                            if (oldDetail != null)
                            {
                                tbl_ttsTenderNotice oDetail = new tbl_ttsTenderNotice(txtTenderID.Tag.ToString(), txtTenderNo.Text, "", txtProjectSponsor.Tag.ToString(), txtTenderSource.Tag.ToString(), txtTenderDescription.Text,
                                dtpNoticeDate.GetDateTime(), dtpSubClosingDate.GetDateTime(), dtpDocCloseDate.GetDateTime(), txtTenderer.Tag.ToString(), txtName.Text, txtDesignation.Text,
                                txtEmail.Text, txtOfficeNo.Text, txtMobileNo.Text, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtCountry.Tag.ToString(),
                                txtCity.Tag.ToString(), txtTown.Tag.ToString(), oldDetail.PreBidMeetingDate, oldDetail.PreBidMeetingAddress1, oldDetail.PreBidMeetingAddress2, oldDetail.PreBidMeetingCountry_ID, oldDetail.PreBidMeetingCity_ID, oldDetail.PreBidMeetingTown_ID, false, false, 1); 
                                oDetail.Update();

                                #region Delete Old Record
                                tbl_ttsTenderNotice_Delivery.DeleteAllByTender_ID(txtTenderID.Tag.ToString());
                                //tbl_ttsTenderNotice_Detail.DeleteAllByTender_ID(txtTenderID.Tag.ToString());
                                //string sSRRef = "";
                                //foreach (DataRow row in dt_Item.Rows)
                                //{
                                //    sSRRef = row["SRNo"].ToString();
                                //    foreach (tbl_ttsTenderNotice_Delivery oDelDetails in tbl_ttsTenderNotice_Delivery.SelectAllByTender_ID_SerialNo(oDetail.Tender_ID, sSRRef))
                                //    {
                                //        oDelDetails.Delete();
                                //    }
                                //}

                                foreach (tbl_ttsTenderNotice_Detail oDetails in tbl_ttsTenderNotice_Detail.SelectAllByTender_ID(oDetail.Tender_ID))
                                {
                                    oDetails.Delete();
                                } 
                                #endregion

                                #region Notice Details
                                foreach (DataRow row in dt_Item.Rows)
                                {
                                    string sSRRefNo = row["SRNo"].ToString();
                                    string sItemName = row["GenericName"].ToString();
                                    string sSpecification = row["Specification"].ToString();
                                    string sStrength = row["Strength"].ToString();
                                    string sShelfLife = row["ShelfLife"].ToString();
                                    string sPacking = row["Packing"].ToString();
                                    string sUoM = row["UoMCode"].ToString();
                                    decimal dQty = decimal.Parse(row["Quantity"].ToString());
                                    string sItemID = row["ItemID"].ToString();

                                    if (sItemID != "")
                                        sItemIDs = sItemID;
                                    else
                                        sItemIDs = "default";

                                    if (sUoM != "")
                                        sUoMs = sUoM;
                                    else
                                        sUoMs = "default";

                                    tbl_ttsTenderNotice_Detail oDetails = new tbl_ttsTenderNotice_Detail(txtTenderID.Tag.ToString(), sSRRefNo, sItemName, sSpecification, sStrength, sShelfLife, sPacking, sUoMs, dQty, sItemIDs, false);
                                    oDetails.Insert();
                                } 
                                #endregion

                                #region Delivery Details
                                int iDelevaryId = 0;
                                foreach (DataRow row in dt_Delevary.Rows)
                                {
                                    string sSRRefNo = row["SRNo"].ToString();
                                  //  string sDelID = row["DeliveryID"].ToString();
                                    DateTime dtDeliveryDate = DateTime.Parse(row["DeliveryDate"].ToString());
                                    decimal sQty = decimal.Parse(row["Qty"].ToString());
                                    string sLocation = row["Location"].ToString();

                                    tbl_ttsTenderNotice_Delivery oDetails = new tbl_ttsTenderNotice_Delivery(txtTenderID.Tag.ToString(), sSRRefNo, iDelevaryId.ToString(), dtDeliveryDate, sQty, sLocation);
                                    oDetails.Insert();
                                    iDelevaryId++;
                                }
                                
                                #endregion

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            string sSponsor = "";
                            if (txtProjectSponsor.Tag != null)
                            {
                                sSponsor = txtProjectSponsor.Tag.ToString();
                            }
                            else
                            {
                                sSponsor = "default";
                            }
                            //auto genarated number
                            if (SEACC_Form.isAutoGenaratedCode)   
                                txtTenderID.Tag = SEACC_Form.getAutoGeneratedCode();

                            tbl_ttsTenderNotice oDetail = new tbl_ttsTenderNotice(txtTenderID.Tag.ToString(), txtTenderNo.Text, "", sSponsor, txtTenderSource.Tag.ToString(), txtTenderDescription.Text,
                                dtpNoticeDate.GetDateTime(), dtpSubClosingDate.GetDateTime(), dtpDocCloseDate.GetDateTime(), txtTenderer.Tag.ToString(), txtName.Text, txtDesignation.Text,
                                txtEmail.Text, txtOfficeNo.Text, txtMobileNo.Text, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtCountry.Tag.ToString(),
                                txtCity.Tag.ToString(), txtTown.Tag.ToString(), clsValidation.defaultDateTime, "default", "default", "default", "default", "default", false, false, 1);
                            oDetail.Insert();

                            #region Notice Details
                            foreach (DataRow row in dt_Item.Rows)
                            {
                                string sSRRefNo = row["SRNo"].ToString();
                                string sItemName = row["GenericName"].ToString();
                                string sSpecification = row["Specification"].ToString();
                                string sStrength = row["Strength"].ToString();
                                string sShelfLife = row["ShelfLife"].ToString();
                                string sPacking = row["Packing"].ToString();
                                string sUoM = row["UoMCode"].ToString();
                                decimal dQty = decimal.Parse(row["Quantity"].ToString());
                                string sItemID = row["ItemID"].ToString();

                                if (sItemID != "")
                                    sItemIDs = sItemID;
                                else
                                    sItemIDs = "default";

                                if (sUoM != "")
                                    sUoMs = sUoM;
                                else
                                    sUoMs = "default";

                                tbl_ttsTenderNotice_Detail oDetails = new tbl_ttsTenderNotice_Detail(txtTenderID.Tag.ToString(), sSRRefNo, sItemName, sSpecification, sStrength, sShelfLife, sPacking, sUoMs, dQty, sItemIDs, false);
                                oDetails.Insert();
                            } 
                            #endregion

                            #region Delivery Details
                            int iDelevaryId = 0;
                           // tbl_ttsTenderNotice_Delivery.DeleteAllByTender_ID_SerialNo()
                            foreach (DataRow row in dt_Delevary.Rows)
                            {
                                string sSRRefNo = row["SRNo"].ToString();
                              //  string sDelID = row["DeliveryID"].ToString();
                                DateTime dtDeliveryDate = DateTime.Parse(row["DeliveryDate"].ToString());
                                decimal sQty = decimal.Parse(row["Qty"].ToString());
                                string sLocation = row["Location"].ToString();

                                tbl_ttsTenderNotice_Delivery oDetails = new tbl_ttsTenderNotice_Delivery(txtTenderID.Tag.ToString(), sSRRefNo, iDelevaryId.ToString(), dtDeliveryDate, sQty, sLocation);
                                oDetails.Insert();
                                iDelevaryId++;
                            } 
                            #endregion

                            Attachments.Insert(txtTenderID.Tag.ToString());

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Arrow;
                        sTenderID = txtTenderID.Tag.ToString();
                        ClearFields();
                        RefreshGrid();
                        FillDetails(sTenderID);
                    }
                }
            }
        }
        #endregion
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            Attachments.Clear(SEACC_Form.Function_ID);

            dt_Item.Clear();
            dt_Delevary.Clear();
            
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtTenderID, false, false, false);
           
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProjectSponsor, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderSource, true, false, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtTenderOrderListNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTenderDescription, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtTenderNo, true, false, false);

            cls_Formater.SetEnableDisable_LableTimePicker(dtpDocCloseDate, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpNoticeDate, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpSubClosingDate, true, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtAddress1, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress2, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress3, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtDesignation, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMobileNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmail, true, false, false);
            
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTown, true, false, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtItemSpecification, true, false, true);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtItemName, true, false, true);

           // cls_Formater.SetEnableDisable_LableTextbox(txtDeliveryLocation, true, false, false);
           // cls_Formater.SetEnableDisable_LableTextbox(txtDeliveryQuantity, true, true, false);

            //ClearDeliveryFields();

            txtTenderID.Tag = null;
            txtTenderer.Tag = null;
            txtProjectSponsor.Tag = null;

            txtCity.Tag = null;
            txtCountry.Tag = 94;
            txtTown.Tag = null;
            txtTenderSource.Tag = null;
            
            txtTenderDescription.Text = "";
            txtTenderer.Text = "";
            txtTenderID.Text = "<Auto generated>";
            txtTenderNo.Text = "";
            txtTenderOrderListNo.Text = "";
            //cmbTenderSource.Text = "";
            txtTenderSource.Text = "";
            txtProjectSponsor.Text = "";

            txtName.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "Sri Lanka";
            txtDesignation.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "0";           
            txtOfficeNo.Text = "0";                  
            txtTown.Text = "";

            dtpDocCloseDate.SetTime(DateTime.Now);
            dtpNoticeDate.SetTime(DateTime.Now);          
            dtpSubClosingDate.SetTime(DateTime.Now);

            //cmbTenderSource.comboBox.ItemsSource = Common.clsHelpMethods.GetEnumDescription(typeof(NoticeSource));
            //cmbTenderSource.SetSelectedIndex(0);
        }

        //private void ClearDeliveryFields()
        //{
        //    txtDeliveryQuantity.Text = "";
        //    txtDeliveryLocation.Text = "";
        //    dtpDeliveryDate.SetTime(DateTime.Now);
        //}
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_ttsTenderNotice oDetail in tbl_ttsTenderNotice.SelectAll().Where(p => !p.IsCanceled).OrderBy(p => p.NoticeDate))
                {
                    dgr_Main.dt.Rows.Add(oDetail.Tender_ID, oDetail.BidReference_No1, clsGenaralName.getName_Customer(oDetail.Customer_ID), oDetail.NoticeDate.ToString(cls_Formater.Format_Date2), oDetail.DocCollectionDate.ToString(cls_Formater.Format_Date2), oDetail.DocClosingDate.ToString(cls_Formater.Format_Date2));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sTenderID)
        {
            tbl_ttsTenderNotice oNotice = tbl_ttsTenderNotice.Select(sTenderID);
            if (oNotice != null)
            {
                ClearFields();
                SEACC_Form.IsUpdateMode = true;

                txtTenderer.Tag = oNotice.Customer_ID;
                txtTenderer.Text = clsRef_Name.get_Customer_Name(oNotice.Customer_ID);
                txtTenderID.Text = oNotice.Tender_ID;
                txtTenderID.Tag = oNotice.Tender_ID;
                txtTenderNo.Text = oNotice.BidReference_No1.ToString();
                txtTenderSource.Tag = oNotice.NoticeSource_ID;
                txtTenderSource.Text = clsRef_Name.get_Tender_Source(oNotice.NoticeSource_ID);
                txtProjectSponsor.Tag = oNotice.Sponsor_ID;
                txtProjectSponsor.Text = clsRef_Name.get_Sponsor_Name(oNotice.Sponsor_ID);
                txtTenderDescription.Text = oNotice.Description;

                dtpNoticeDate.SetTime(oNotice.NoticeDate);
                dtpDocCloseDate.SetTime(oNotice.DocClosingDate);
                dtpSubClosingDate.SetTime(oNotice.DocCollectionDate);

                txtName.Text = oNotice.Contact_Name;
                txtAddress1.Text = oNotice.Address1;
                txtAddress2.Text = oNotice.Address2;
                txtAddress3.Text = oNotice.Address3;
                txtCity.Tag = oNotice.City_ID;
                txtCity.Text = clsRef_Name.get_City_Name(oNotice.City_ID);
                txtCountry.Tag = oNotice.Country_ID;
                txtCountry.Text = clsRef_Name.get_Country_Name(oNotice.Country_ID);
                txtTown.Tag = oNotice.Town_ID;
                txtTown.Text = clsRef_Name.get_Town_Name(oNotice.Town_ID);
                txtDesignation.Text = oNotice.Contact_Designation;
                txtEmail.Text = oNotice.Email;
                txtMobileNo.Text = oNotice.Mobile.ToString();
                txtOfficeNo.Text = oNotice.Phone.ToString();

                Attachments.FillDetails(oNotice.Tender_ID);

                foreach (tbl_ttsTenderNotice_Detail oNoticeDetails in tbl_ttsTenderNotice_Detail.SelectAllByTender_ID(oNotice.Tender_ID))
                {
                    //string sDeliveryDetails = "";
                    //int iRow = dt_Item.Rows.Count + 1;

                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oNoticeDetails.Item_ID);
                    if (oItem != null)
                    {
                        //foreach (tbl_ttsTenderNotice_Delivery oDeliverDetails in tbl_ttsTenderNotice_Delivery.SelectAll().Where(p => p.Tender_ID == oNoticeDetails.Tender_ID && p.SerialNo == oNoticeDetails.SerialNo))
                        //{
                        //    sDeliveryDetails += oDeliverDetails.DeliveryDate.ToShortDateString() + " " + oNoticeDetails.TdrUoM + " - " + cls_Formater.FormatDecimal(oDeliverDetails.DeliveryQty, 2) + " - " + oDeliverDetails.Location + " // ";
                        //}
                        string spath = new Uri("pack://application:,,,/Resources/add-list-xxl.png", UriKind.Absolute).ToString();
                        dt_Item.Rows.Add(oNoticeDetails.SerialNo, oNoticeDetails.Item_ID, clsRef_Name.get_Item_Name(oNoticeDetails.Item_ID), oNoticeDetails.TdrItem_Name, oNoticeDetails.TdrItem_Specification, oNoticeDetails.TdrUoM, clsRef_Name.get_UoM_Code(oNoticeDetails.TdrUoM), cls_Formater.FormatDecimal(oNoticeDetails.Qty, 2), spath, oNoticeDetails.TdrItemStrength, oNoticeDetails.Tdrshelf_Life, oNoticeDetails.TdrPackSize);
                    }

                    foreach (tbl_ttsTenderNotice_Delivery oDeliverDetails in tbl_ttsTenderNotice_Delivery.SelectAllByTender_ID_SerialNo(oNoticeDetails.Tender_ID, oNoticeDetails.SerialNo))
                    {
                        dt_Delevary.Rows.Add(oDeliverDetails.LineNo, oDeliverDetails.SerialNo, oDeliverDetails.DeliveryDate.ToString(cls_Formater.Format_Date2), cls_Formater.FormatDecimal(oDeliverDetails.DeliveryQty, 2), oDeliverDetails.Location);
                    }
                }
            }
        }
        #endregion            

        #region Search events
        private void txtTenderID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                FillDetails(lstResult[0]);
            }
        }

        private void txtTenderer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerList);
            if (RowDataSearch.DialogResult == true)
            {
                txtTenderer.Tag = lstResult[0];
                txtTenderer.Text = lstResult[1];
            }
        }

        private void txtProjectSponsor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Ten_ProjectSponsor);
            if (RowDataSearch.DialogResult == true)
            {
                txtProjectSponsor.Tag = lstResult[0];
                txtProjectSponsor.Text = lstResult[1];
            }
        }

        private void txtCountry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Country);
            if (RowDataSearch.DialogResult == true)
            {
                txtCountry.Tag = lstResult[0];
                txtCountry.Text = lstResult[1];
            }
        }

        private void txtCity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.City);
            if (RowDataSearch.DialogResult == true)
            {
                txtCity.Tag = lstResult[0];
                txtCity.Text = lstResult[1];
                txtCountry.Tag = lstResult[6];
                txtCountry.Text = lstResult[7];
            }
        }

        private void txtTown_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtCity.Tag != null && txtCity.Text != "")
            {
                lstParameeters.Add(txtCity.Tag.ToString());
            }

            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Towns);
            if (RowDataSearch.DialogResult == true)
            {
                txtTown.Tag = lstResult[0];
                txtTown.Text = lstResult[1];
                txtCity.Tag = lstResult[2];
                txtCity.Text = lstResult[3];
                txtCountry.Tag = lstResult[8];
                txtCountry.Text = lstResult[9];
            }
        }

        private void txtTenderSource_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Ten_Source);
            if (RowDataSearch.DialogResult == true)
            {
                txtTenderSource.Tag = lstResult[0];
                txtTenderSource.Text = lstResult[1];
            }
        }

        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (CheckGridvalidity())
                {
                    if (CheckGridEmptyFields())
                    {
                        if (CheckValidity_Delivary())
                        {
                            if (CheckValidity_DuplicateKey())
                            {
                                bStatus = true;
                            }
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtTenderNo, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtTenderer, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtTenderSource, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtCountry, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtCity, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtTown, ref strMessage))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Information", "Please fill out this required field " + strMessage , MessageBoxButton.OK);

            return bStatus;
        }
        private bool CheckGridvalidity()
        {
            bool bStatus = true;
            if (dt_Item.Rows.Count <= 0)
            {
                SEACCMessageBox.Show("Information", "Please select items..", MessageBoxButton.OK);
                bStatus = false;
            }
            return bStatus;
        }

        private bool CheckGridEmptyFields()
        {
            bool bStatus = true;
            string sSRRefNo = "";
            foreach (DataRow row in dt_Item.Rows)
            {
                sSRRefNo = row["SRNo"].ToString();
            }

            if (sSRRefNo == "")
            {
                SEACCMessageBox.Show("Information", "Please fill out this required field SR No", MessageBoxButton.OK);
                bStatus = false;
            }
            return bStatus;
        }
        public bool CheckValidity_Delivary()
        {
            bool bStatus = true;
            foreach (DataRow row in dt_Delevary.Rows)
            {
                string sSRRefNo = row["SRNo"].ToString();

                if (clsValidation.Validate_DateTime(row["DeliveryDate"].ToString()) == defaultDateTime)
                {
                    SEACCMessageBox.Show("Information", "Invalid Delivery date.  SR# <" + sSRRefNo+">", MessageBoxButton.OK);
                    bStatus = false;
                    break;
                }
            }
            return bStatus;
        }
        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtTenderID.Text = SEACC_Form.getAutoGeneratedCode();

                txtTenderID.Tag = txtTenderID.Text;

                if (txtTenderID.Tag.ToString() != "")
                {
                    tbl_ttsTenderNotice detail = tbl_ttsTenderNotice.Select(txtTenderID.Tag.ToString());
                    if (detail != null)
                    {
                        bStatus = false;
                        SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    }
                }
                else
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Information", "Fields cannot be Empty Tender ID", MessageBoxButton.OK);
                }
            }
            return bStatus;
        }
        #endregion

        #region Main DataGrid Event
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oItem = dgr_Main.grdMain.SelectedItem;
                if (oItem != null)
                {
                    string sId = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(oItem) as TextBlock).Text;
                    FillDetails(sId);
                }
            }
            catch (Exception ex)
            {

                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Tender Item DataGrid Add Event
        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            string path1 = new Uri("pack://application:,,,/Resources/add-list-xxl.png", UriKind.Absolute).ToString();
            //&#xE710;
            dt_Item.Rows.Add("", "", "", "", "", "", "", 0, path1, "", "", "");

            //dgr_Tender.CurrentCell = new DataGridCellInfo(dgr_Tender.Items[0], dgr_Tender.Columns[1]);
            //dgr_Tender.BeginEdit();

            //var vDgv_Cell = dgr_Tender.CurrentCell;
            //if (vDgv_Cell.Column.Header.ToString() == "SR No")
            //{
            //    dgr_Tender.BeginEdit();
            //}
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Tender.SelectedItem;

            DataRowView dataRow = (DataRowView)selectedItem;
            string sItemSRNo = dataRow["SRNo"].ToString();

            foreach (DataRow row in dt_Delevary.Rows)
            {
                string sSRNo = row["SRNo"].ToString();
                if (sSRNo == sItemSRNo)
                {
                    dt_Delevary.Rows.Remove(row);
                }
            }

            if (selectedItem != null)
                ((DataRowView)(dgr_Tender.SelectedItem)).Row.Delete();
   
        } 
        #endregion

        #region Tender Items DataGrid Event

        private decimal GetTotalDelevaryQty(string sSRRefNo)
        {
            decimal dDelevaryQty = 0;
            try
            {
                foreach (DataRow row in dt_Delevary.Rows)
                {
                    string sDelSRNo = row["SRNo"].ToString();
                    if (sSRRefNo == sDelSRNo)
                        dDelevaryQty += decimal.Parse(row["Qty"].ToString());
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            return dDelevaryQty;
        }
        private void dgr_Tender_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDgv_Cell = dgr_Tender.CurrentCell;
                object item = dgr_Tender.SelectedItem;

                #region Item
                if (vDgv_Cell.Column.Header.ToString() == "Item Name")
                {
                    pop_ItemName.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                    pop_ItemName.IsOpen = true;

                    string GridID = (dgr_Tender.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    txtItemName.Text = GridID;
                    txtItemName.Focus();
                } 
                #endregion

                #region Spec
                if (vDgv_Cell.Column.Header.ToString() == "Specification")
                {
                    pop_Spec.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                    pop_Spec.IsOpen = true;

                    string GridID = (dgr_Tender.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    txtItemSpecification.Text = GridID;
                    txtItemSpecification.Focus();
                } 
                #endregion

                #region delivery
                if (vDgv_Cell.Column.Header.ToString() == "Delivery")
                {
                    Warning.Visibility = Visibility.Collapsed;

                    string sSRRefNo = (dgr_Tender.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string sItemGenericName = (dgr_Tender.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    string sUoM = (dgr_Tender.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                    decimal dTotalQty = decimal.Parse((dgr_Tender.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text);

                    if (sSRRefNo != "" && sItemGenericName != "" && dTotalQty != 0 && sUoM != "")
                    {
                        decimal dDelevaryQty = GetTotalDelevaryQty(sSRRefNo);

                        pop_Delivery.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                        pop_Delivery.IsOpen = true;

                        dt_Delevary.DefaultView.RowFilter = "SRNo='" + sSRRefNo + "'";

                        txtSRRefNo.Text = sSRRefNo;
                        txtGenericName.Text = sItemGenericName;
                        txtTotalQty.Text =  cls_Formater.FormatDecimal(dTotalQty, 2);
                        txtAvailableQty.Text = cls_Formater.FormatDecimal(dTotalQty - GetTotalDelevaryQty(txtSRRefNo.Text), 2);
                        txtUoM.Text = sUoM;
                    }
                    else
                    {
                        SEACCMessageBox.Show("Information", "Please Fill Required Fields", MessageBoxButton.OK);
                    }
                }
                #endregion

                #region Item
                if (vDgv_Cell.Column.Header.ToString() == "Item")
                {
                    frm_MasItem RowDataSearch = new frm_MasItem();
                    List<string> lstResult = RowDataSearch.Show();
                    if (RowDataSearch.DialogResult == true)
                    {
                        int irowID = dgr_Tender.SelectedIndex;
                        dt_Item.Rows[irowID]["ItemID"] = lstResult[0];
                        dt_Item.Rows[irowID]["ItemName"] = lstResult[2];
                    }
                } 
                #endregion

                #region UoM
                if (vDgv_Cell.Column.Header.ToString() == "UoM")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.UOM);
                    if (RowDataSearch.DialogResult == true)
                    {
                        int irowID = dgr_Tender.SelectedIndex;
                        dt_Item.Rows[irowID]["UoM"] = lstResult[1];
                        dt_Item.Rows[irowID]["UoMCode"] = lstResult[0];
                    }
                } 
                #endregion

                #region Packing
                if (vDgv_Cell.Column.Header.ToString() == "Packing")
                {
                    pop_Packing.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                    pop_Packing.IsOpen = true;

                    string GridID = (dgr_Tender.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                    txtPacking.Text = GridID;
                    txtPacking.Focusable = true;
                    txtPacking.Focus();
                } 
                #endregion
            }
            catch (Exception )
            {
                //SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Tender Items DataGrid Cell Editing Event
        private void dgr_Tender_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int irowID = dgr_Tender.SelectedIndex;
                string sColoumn = e.Column.Header.ToString();
                TextBox t = e.EditingElement as TextBox;
                decimal dQty = 0;
                string sSRRefNo = "";
                //dQty = decimal.Parse(dt_Item.Rows[irowID]["Quantity"].ToString());

                switch (sColoumn)
                {
                    case "Quantity":
                        if (t != null)
                            dQty = clsValidation.Validate_DecimalNumber(t.Text);
                            dt_Item.Rows[irowID]["Quantity"] = cls_Formater.FormatDecimal(dQty, 2);
                        break;
                    
                }

                

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Popup Events
        #region Popup Save
        //private void btn_PoPSave2_Click(object sender, RoutedEventArgs e)
        //{
        //    int irowID = dgr_Tender.SelectedIndex;
        //    object oitem = dgr_Tender.SelectedItem;

        //    string sVal = (dgr_Tender.SelectedCells[1].Column.GetCellContent(oitem) as TextBlock).Text;
        //    string sRefNo = "", sUoM = "", sQty = "", sLocation = "";
        //    DateTime sDelDate;

        //    dt_Item.Rows[irowID]["Delivery"] = "";
        //    foreach (DataRow row in dt_Delevary.Rows)
        //    {
        //        sRefNo = row["SRNo"].ToString();
        //        if (sRefNo == sVal)
        //        {
        //            sDelDate = DateTime.Parse(row["DeliveryDate"].ToString());
        //            sUoM = txtUoM.Text;
        //            sQty = row["Qty"].ToString();
        //            sLocation = row["Location"].ToString();

        //            dt_Item.Rows[irowID]["Delivery"] += sDelDate.ToShortDateString() + "- " + sUoM + "- " + sQty + "- " + sLocation + "/ ";
        //        }
        //    }
        //    pop_Delivery.IsOpen = false;
        //}
        private void btn_PoPSave_Click(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt_Item.Rows[irowID]["Specification"] = txtItemSpecification.Text;

            pop_Spec.IsOpen = false;
        }
        private void btn_PoPSave1_Click(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt_Item.Rows[irowID]["GenericName"] = txtItemName.Text;

            pop_ItemName.IsOpen = false;
        }
        private void btn_PoPSave3_Click(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt_Item.Rows[irowID]["Packing"] = txtPacking.Text;

            pop_Packing.IsOpen = false;
        }
        #endregion

        #region Popup Add & New
      

        private void btn_PoPNew2_Click(object sender, RoutedEventArgs e)
        {
            Warning.Visibility = Visibility.Collapsed;

            DataRow dr = dt_Delevary.NewRow();
            dr["SRNo"] = txtSRRefNo.Text;
            dr["Qty"] = 0;
            dt_Delevary.Rows.Add(dr);
           // txtLineNo.Text = "";
           // txtDeliveryQuantity.Text = "";
           // txtDeliveryLocation.Text = "";
           // dtpDeliveryDate.SetTime(DateTime.Now);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgv_DeliveryDetails.SelectedItem;
            if (selectedItem != null)
                ((DataRowView)(dgv_DeliveryDetails.SelectedItem)).Row.Delete();

            decimal dQty  = decimal.Parse(txtTotalQty.Text) ;

            txtAvailableQty.Text = cls_Formater.FormatDecimal(dQty - GetTotalDelevaryQty(txtSRRefNo.Text), 2);
         
        }
        #endregion

        #region Lost Focus Event
        private void pop_Spec_LostFocus(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt_Item.Rows[irowID]["Specification"] = txtItemSpecification.Text;
        }
        private void pop_ItemName_LostFocus(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt_Item.Rows[irowID]["GenericName"] = txtItemName.Text;
        }
        private void pop_Packing_LostFocus(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt_Item.Rows[irowID]["Packing"] = txtPacking.Text;
        }
        #endregion

        #region Popup close events
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            pop_Spec.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Spec.IsOpen = false;
        }

        private void btn_Close2_Click(object sender, RoutedEventArgs e)
        {
            pop_Delivery.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Delivery.IsOpen = false;
        }
        private void btn_Close1_Click(object sender, RoutedEventArgs e)
        {
            pop_ItemName.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_ItemName.IsOpen = false;
        }
        private void btn_Close3_Click(object sender, RoutedEventArgs e)
        {
            pop_Packing.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Packing.IsOpen = false;
        }
        #endregion     
        #endregion

        #region Fill Delivery Details Grid
        private void FillDeliveryDetailGrid( string sSRRefNo)
        {
            //bool flag = true;
            //string sRefNo = "";
            //string sTenderID = (txtTenderID.Tag != null) ? txtTenderID.Tag.ToString() : "";
          
            //foreach (DataRow row in dt_Delevary.Rows)
            //{
            //    sRefNo = row["SRRefNo"].ToString();
            //    if (sSRRefNo == sRefNo)
            //    {
            //        flag = false;
            //    }
            //}
            //if (flag)
            //{
            //    if (sTenderID == sTenderID && sRefNo != sSRRefNo)
            //    {
            //foreach (tbl_ttsTenderNotice_Delivery oDeliverDetails in tbl_ttsTenderNotice_Delivery.SelectAll().Where(p => p.Tender_ID == sTenderID && p.SerialNo == sSRRefNo))
            //        {
            //            string sUoM = "";
            //            foreach (tbl_ttsTenderNotice_Detail oNoticeDetails in tbl_ttsTenderNotice_Detail.SelectAll().Where(p => p.Tender_ID == oDeliverDetails.Tender_ID && p.SerialNo == oDeliverDetails.SerialNo))
            //            {
            //                foreach (tbl_zUom oUoM in tbl_zUom.SelectAll().Where(p => p.Uom_ID == oNoticeDetails.Uom_ID))
            //                {
            //                    sUoM += oUoM.UomCode;
            //                }
            //            }
            //            dt_Delevary.Rows.Add(oDeliverDetails.SerialNo, oDeliverDetails.LineNo, oDeliverDetails.DeliveryDate.ToShortDateString(), sUoM, oDeliverDetails.DeliveryQty, oDeliverDetails.DeliveryLocation);
            //        }
                //}
                //else
                //{
                //    SEACCMessageBox.Show("Error", "This Delivery Details Allready Added", MessageBoxButton.OK);
                //}
          //  }
            
            
        } 
        #endregion

        #region Expander Events
        private void expander2_Expanded(object sender, RoutedEventArgs e)
        {
            expander1.IsExpanded = false;
        }

        private void expander1_Expanded(object sender, RoutedEventArgs e)
        {
            expander2.IsExpanded = false;
        } 
        #endregion

        private void lblNext_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UC_ttsApplicationCollection UC;
            if (txtTenderID.Tag != null)
                UC = new UC_ttsApplicationCollection(txtTenderID.Tag.ToString());
            else
                UC = new UC_ttsApplicationCollection();
            frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            SW.ShowDialog();
        }

        private void txtDeliveryQuantity_MouseEnter(object sender, MouseEventArgs e)
        {
            Warning.Visibility = Visibility.Collapsed;
        }

        private void dgv_DeliveryDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Warning.Visibility = Visibility.Collapsed;

            int iColumnIndex = e.Column.DisplayIndex;
            int irowID = dgv_DeliveryDetails.SelectedIndex;

            #region 1
            if (iColumnIndex == 1)
            {
                DataRowView dataRow = (DataRowView)dgv_DeliveryDetails.SelectedItem;
                DateTime IN_Date = clsValidation.Validate_DateTime(dataRow["DeliveryDate"].ToString());

                DateTime dtTemp = defaultDateTime;
                TextBox t = e.EditingElement as TextBox;

                if (t.Text.Length == 0)
                    t.Text = "-";

                if (t.Text != "-" || t.Text.Length == 0)
                {
                    try
                    {
                        dtTemp = DateTime.Parse(t.Text);
                        IN_Date = dtTemp;
                        t.Text = dtTemp.ToString(cls_Formater.Format_Date2);
                    }
                    catch (Exception)
                    {
                        Warning.Visibility = Visibility.Visible;
                        txtError.Text = "Unsupported Date Time Format..";
                        t.Text = "-";
                    }
                }
            } 
            #endregion
            else if (iColumnIndex == 2)
            {
                TextBox t = e.EditingElement as TextBox;
                decimal dQTY=clsValidation.Validate_DecimalNumber(t.Text);
                decimal dTotalQTY = clsValidation.Validate_DecimalNumber(txtTotalQty.Text);
                if (GetTotalDelevaryQty(txtSRRefNo.Text) > dTotalQTY)
                {
                    Warning.Visibility = Visibility.Visible;
                     txtError.Text = "Delivery QTY cannot exceed total QTY..";
                    dQTY = 0;
                }
                t.Text = cls_Formater.FormatDecimal(dQTY, 2);
                txtAvailableQty.Text = cls_Formater.FormatDecimal(dTotalQTY - GetTotalDelevaryQty(txtSRRefNo.Text), 2);
            }
        }        
    }
}