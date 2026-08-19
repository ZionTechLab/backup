using DataTire;
using Digiteq_Logic;
using Microsoft.Win32;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Digiteq.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_SecurityFormMaster.xaml
    /// </summary>
    public partial class UC_SecurityFormMaster : UserControl
    {
        #region Form Load
        public UC_SecurityFormMaster()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Security_Form;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("FormID");
            dgr_Main.dt.Columns.Add("FormName");
            dgr_Main.dt.Columns.Add("FormCategoryID");
            dgr_Main.dt.Columns.Add("DisplayName"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("#", "FormID", 40);
            dgr_Main.Add_DatagridColoumn("Form Name", "FormName", 200);
            dgr_Main.Add_DatagridColoumn("Form Categoty ID", "FormCategoryID", 120);
            dgr_Main.Add_DatagridColoumn("Display Name", "DisplayName", 150); 
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(620);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Variables
                    bool bEnable = false;
                    bool bVisible = false;
                    bool bViewer = false;
                    bool bAutoGen = false;

                    if (chk_isEnable.IsChecked == true)
                    {
                        bEnable = true;
                    }
                    if (chk_isViewer.IsChecked == true)
                    {
                        bViewer = true;
                    }
                    if (chk_isVisible.IsChecked == true)
                    {
                        bVisible = true;
                    }
                    if (chk_isAutoGenerate.IsChecked == true)
                    {
                        bAutoGen = true;
                    }
                    #endregion

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            //tbl_securityFormMaster oldRecord = tbl_securityFormMaster.Select(int.Parse(txtFormID.Text.Trim()));
                            //if (oldRecord != null)
                            //{
                            //    tbl_securityFormMaster OFormMaster = new tbl_securityFormMaster(int.Parse(txtFormID.Text), int.Parse(txtSortOrder.Text), txtFormName.Text, cls_Formater.Convert_BitMapToByteArray(pbxImage.Source as BitmapImage), txtFormCategoryID.Text, txtDisplayName.Text, bEnable, bVisible, bViewer, int.Parse(txtCounter.Text), int.Parse(txtLength.Text), txtPrefix.Text, bAutoGen);
                            //    OFormMaster.Update();
                            //    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            //}
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        //tbl_securityFormMaster OFormMaster = new tbl_securityFormMaster(int.Parse(txtFormID.Text), int.Parse(txtSortOrder.Text), txtFormName.Text, cls_Formater.Convert_BitMapToByteArray(pbxImage.Source as BitmapImage), txtFormCategoryID.Text, txtDisplayName.Text, bEnable, bVisible, bViewer, int.Parse(txtCounter.Text), int.Parse(txtLength.Text), txtPrefix.Text, bAutoGen);
                        //OFormMaster.Insert();
                        //SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                }
            }
        }
        
        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            pbxImage.Source = null;
            Thread.Sleep(2000);
            if (openFileDialog1.FileName != "")
            {
                ImageSource imageSource = new BitmapImage(new Uri(openFileDialog1.FileName));

                pbxImage.Source = imageSource;
            }
            else
            {
                pbxImage.Source = new BitmapImage(new Uri("/Resources/user.png", UriKind.Relative));
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtFormID, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFormName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFormCategoryID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDisplayName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSortOrder, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCounter, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLength, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrefix, true, false, false);

            txtFormID.Text = "";
            txtFormName.Text = "";
            txtFormCategoryID.Text = "";
            txtDisplayName.Text = "";
            txtCounter.Text = "";
            txtLength.Text = "";
            txtPrefix.Text = "";
            txtSortOrder.Text ="";
            pbxImage.Source = new BitmapImage(new Uri("/Resources/user.png", UriKind.Relative));

            chk_isEnable.IsChecked = false;
            chk_isViewer.IsChecked = false;
            chk_isVisible.IsChecked = false;
            chk_isAutoGenerate.IsChecked = false;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                //foreach (tbl_securityFormMaster oUser in tbl_securityFormMaster.SelectAll())
                //{
                //    dgr_Main.dt.Rows.Add(oUser.Form_ID, oUser.FormName, oUser.FormCategory_ID, oUser.DisplayName);
                //}
                //dgr_Main.RefreshGrid();
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
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateRecords())
                {
                    if (CheckValidity_DuplicateFormName())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtFormID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFormName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFormCategoryID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDisplayName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSortOrder))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCounter))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtLength))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPrefix))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateRecords()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                //tbl_securityFormMaster oDetail = tbl_securityFormMaster.Select(int.Parse(txtFormID.Text));
                //if (oDetail != null)
                //{
                //    bStatus = false;
                //    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                //}
            }
            return bStatus;
        }

        public bool CheckValidity_DuplicateFormName()
        {
            bool bStatus = true;
            //foreach (tbl_securityFormMaster detail in tbl_securityFormMaster.SelectAll().Where(p => p.FormName == txtFormName.Text && p.Form_ID != int.Parse(txtFormID.Text)))
            //{
            //    bStatus = false;
            //    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist, "Form Name");
            //    break;
            //}
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(int sID)
        {
            try
            {
                if (sID != null)
                {
                    //tbl_securityFormMaster Ouser = tbl_securityFormMaster.Select(sID);
                    //if (Ouser != null)
                    //{
                    //    SEACC_Form.IsUpdateMode = true;
                    //    txtFormID.IsEnabled = false;
                    //    txtFormID.Text = Ouser.Form_ID.ToString();
                    //    txtFormName.Text = Ouser.FormName;
                    //    txtFormCategoryID.Text = Ouser.FormCategory_ID;
                    //    txtDisplayName.Text = Ouser.DisplayName;
                    //    txtSortOrder.Text = Ouser.SortOrder.ToString();
                    //    txtCounter.Text = Ouser.Counter.ToString();
                    //    txtLength.Text = Ouser.Length.ToString();
                    //    txtPrefix.Text = Ouser.Prefix1;

                    //    if (Ouser.IsViewer == true)
                    //    {
                    //        chk_isViewer.IsChecked = true;
                    //    }
                    //    else
                    //    {
                    //        chk_isViewer.IsChecked = false;
                    //    }
                    //    if (Ouser.IsVisible == true)
                    //    {
                    //        chk_isVisible.IsChecked = true;
                    //    }
                    //    else
                    //    {
                    //        chk_isVisible.IsChecked = false;
                    //    }
                    //    if (Ouser.IsEnable == true)
                    //    {
                    //        chk_isEnable.IsChecked = true;
                    //    }
                    //    else
                    //    {
                    //        chk_isEnable.IsChecked = false;
                    //    }
                    //    if (Ouser.IsAutoGenerate == true)
                    //    {
                    //        chk_isAutoGenerate.IsChecked = true;
                    //    }
                    //    else
                    //    {
                    //        chk_isAutoGenerate.IsChecked = false;
                    //    }

                //        if (Ouser.Image.Length > 0)
                //        {
                //            using (var stream = new MemoryStream(Ouser.Image))
                //            {
                //                var bitmap = new BitmapImage();
                //                bitmap.BeginInit();
                //                bitmap.StreamSource = stream;
                //                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                //                bitmap.EndInit();
                //                bitmap.Freeze();
                //                if (bitmap != null)
                //                {
                //                    pbxImage.Source = bitmap;
                //                }
                //                else
                //                {
                //                    pbxImage.Source = null;
                //                }
                //            }
                //        }
                //        else
                //            pbxImage.Source = null;
                //    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
}
            #endregion

            #region Grid Events
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(int.Parse(GridID));
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtFormID_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
           // List<string> lstResult = RowDataSearch.Show(Search.SecurityForms);
            if (RowDataSearch.DialogResult == true)
            {
            //    txtFormID.Text = lstResult[0];
           //     fillDetails(int.Parse(lstResult[0]));
            }
        }
        #endregion
    }
}
