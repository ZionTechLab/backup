using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using Digiteq_Logic_POS;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SEACC_POS.Search_Forms
{
    public partial class UC_ItemSearch : UserControl
    {
        #region Class Variables
        public delegate void delegate_SelectionOK(List<string> sender);
        public event delegate_SelectionOK SelectionOK;

        string strTable = "", strFields = "", strSelection = "", strSelection2 = "", strOrderBy = "";
        protected List<string> lstReturn = new List<string>();
        Dictionary<string, string> dicFilter = new Dictionary<string, string>();
        DataTable dtResult;

        public List<string> lstItemFilterParameter = new List<string>();
        #endregion

        public UC_ItemSearch()
        {
            InitializeComponent();
        }

        private void Up(bool UP)
        {
            try
            {
                if (dgvSearch.SelectedIndex >= 0)
                {
                    if (UP)
                    {
                        if (dgvSearch.SelectedIndex == 0)
                            dgvSearch.SelectedIndex = dgvSearch.Items.Count - 1;
                        else
                            dgvSearch.SelectedIndex--;
                    }
                    else
                    {
                        if (dgvSearch.SelectedIndex == dgvSearch.Items.Count - 1)
                            dgvSearch.SelectedIndex = 0;
                        else
                            dgvSearch.SelectedIndex++;
                    }
                }
                else
                    dgvSearch.SelectedIndex = 0;

                pop_Detail.IsOpen = true;

                dgvSearch.ScrollIntoView(dgvSearch.SelectedItem);


                //Item Image Loading
                if (clsConfig_POS.bItemSearch_ImageLoadEnabled)
                {
                    object item = dgvSearch.SelectedItem;
                    if (item != null)
                    {
                        string sID = (dgvSearch.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;
                        if (sID != null)
                        {
                            tbl_genItemMaster oItemMaster = tbl_genItemMaster.Select(sID);
                            if (oItemMaster != null && oItemMaster.ImagePath.Trim() != "" &&
                                oItemMaster.ImagePath != "Default")
                            {
                                if (File.Exists(clsConfig_POS.sERP_Location + "\\Images\\" +
                                                oItemMaster.ImagePath.Trim()))
                                {
                                    string s_FileName = oItemMaster.ImagePath.Trim();

                                    ImageSource imageSource =
                                        new BitmapImage(
                                            new Uri(clsConfig_POS.sERP_Location + "\\Images\\" + s_FileName));
                                    pbxImage.Source = imageSource;
                                }
                                else
                                {
                                    pbxImage.Source = new BitmapImage(new Uri(
                                        "pack://application:,,,/SEACC_POS;component/Resources/Main_Icons/no-image-available.png",
                                        UriKind.Absolute));
                                }
                            }
                            else
                            {
                                pbxImage.Source = new BitmapImage(new Uri(
                                    "pack://application:,,,/SEACC_POS;component/Resources/Main_Icons/no-image-available.png",
                                    UriKind.Absolute));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void SelectionOk()
        {
            try
            {
                if (dgvSearch.SelectedItems.Count != 0)
                {
                    DataRowView row = (DataRowView)dgvSearch.SelectedItems[0];
                    if (row != null)
                    {
                        int iColumnIndex = 0;
                        foreach (DataGridColumn column in dgvSearch.Columns)
                        {
                            lstReturn.Add(row[iColumnIndex].ToString());
                            iColumnIndex++;
                        }

                        SelectionOK(lstReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                Clear();
            }
        }

        private void RefrechAll()
        {
            try
            {
                string sWhere = (strSelection != "" ? " WHERE " : "") + strSelection;
                string sOrderBy = (strOrderBy != "" ? " ORDER BY " : "") + strOrderBy + " " + (strOrderBy != "" ? " DESC " : "");

                if (lstItemFilterParameter.Count > 0)
                {
                    int iListIndex = 1;
                    foreach (string s in lstItemFilterParameter)
                    {
                        strSelection2 = strSelection2.Replace("[" + iListIndex + "]", s);
                        iListIndex++;
                    }
                    sWhere += (sWhere == "" ? " WHERE " : " AND ") + strSelection2;
                }

                string strScript = "SELECT " + strFields.Substring(0, strFields.Length - 2) + " FROM " + strTable + sWhere + sOrderBy;
                dtResult = DBHandling.ExecQuery(strScript).Tables[0];

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    //Item Image Load
                    /**
                    if (clsConfig_POS.bItemSearch_ImageLoadEnabled)
                    {
                        dtResult.Columns.Add("ImageSource", typeof(System.Windows.Media.Imaging.BitmapImage));
                        foreach (DataRow dr in dtResult.Rows)
                        {
                            string sItemImage = dr["item_ID"].ToString();
                            tbl_genItem_Image oItem = tbl_genItem_Image.Select(sItemImage);
                            if (oItem != null)
                                dr["ImageSource"] = clsHelpMethods_POS.ImageFromBytearray(oItem.Image);
                        }
                    }
                    **/
                    dgvSearch.ItemsSource = dtResult.DefaultView;
                    FilterChanged(Key.K);
                    
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void FilterChanged(Key k)
        {
            try
            {
                if (k == Key.F9)
                    cbxSearch.SelectedIndex = ((dicFilter.Count - 1) == cbxSearch.SelectedIndex) ? 0 : cbxSearch.SelectedIndex + 1;
                else if (k == Key.Escape)
                    Clear();
                else if (k == Key.Enter)
                {
                    if (txtFillter.Text != "" || dgvSearch.SelectedIndex >= 0)
                        SelectionOk();
                    else
                    {
                        pop_Detail.IsOpen = true;
                        dgvSearch.SelectedIndex = -1;
                    }
                }
                else if (k == Key.Up)
                    Up(true);
                else if (k == Key.Down)
                    Up(false);
                else
                    pop_Detail.IsOpen = true;


                string sFilter = dicFilter[cbxSearch.Text] + " Like '%" + clsHelpMethods.CheckValue(txtFillter.Text) + "%' ";

                dtResult.DefaultView.RowFilter = sFilter;
            }

            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Clear()
        {
            lstReturn.Clear();
            pop_Detail.IsOpen = false;
            txtFillter.Focus();
            txtFillter.Text = "";
            dgvSearch.SelectedIndex = -1;

            if (!clsConfig_POS.bItemSearch_ImageLoadEnabled)
                pbxImage.Visibility = Visibility.Collapsed;
        }

        public void Refresh_Search(Search SearcEnm)
        {
            string sSearch_ID = ((int)SearcEnm).ToString();
            txtFillter.Focus();
            try
            {

                DataTable dtResult_Table = DBHandling.ExecQuery("select * from tbl_cfgSearch Where searchId='" + sSearch_ID + "'").Tables[0];
                if (dtResult_Table != null && dtResult_Table.Rows.Count > 0)
                {
                    double iWidth = 0;
                    foreach (DataRow dtRow1 in dtResult_Table.Rows)
                    {
                        strTable += dtRow1["searchtable"].ToString();
                        lblHeader.Content = dtRow1["displayName"].ToString();
                        strSelection = dtRow1["selection1"].ToString();
                        strSelection2 = dtRow1["Selection2"].ToString();
                        strOrderBy = dtRow1["orderBy"].ToString();
                        iWidth = double.Parse(dtRow1["width"].ToString());
                    }

                    #region Filters
                    DataTable dtResult_Filters = DBHandling.ExecQuery("select fieldName,displayName from tbl_cfgSearchDetail Where SearchId='" + sSearch_ID + "'" + " and isFilter=1  order by FilterOrder").Tables[0];
                    if (dtResult_Filters != null && dtResult_Filters.Rows.Count > 0)
                    {
                        foreach (DataRow dtRow in dtResult_Filters.Rows)
                        {
                            string strDname = dtRow["displayName"].ToString();
                            string strfName = dtRow["fieldName"].ToString();

                            if (strfName.Contains(" "))
                            {
                                string[] words = strfName.Split(' ');
                                strfName = words[words.Length - 1];
                            }
                            else if (strfName.Contains("."))
                            {
                                string[] words = strfName.Split('.');
                                strfName = words[1];
                            }

                            cbxSearch.Items.Add(strDname);
                            dicFilter.Add(strDname, strfName);
                        }
                    }
                    cbxSearch.SelectedIndex = 0;

                    #endregion

                    #region fields
                    DataTable dtResult_Fields = DBHandling.ExecQuery("select * from tbl_cfgsearchDetail Where SearchId='" + sSearch_ID + "'").Tables[0];
                    if (dtResult_Fields != null && dtResult_Fields.Rows.Count > 0)
                    {
                        foreach (DataRow dtRow in dtResult_Fields.Rows)
                        {
                            strFields += dtRow["fieldName"].ToString() + " , ";

                            string strDname = dtRow["displayName"].ToString();
                            string strfName = dtRow["fieldName"].ToString();
                            string strFType = dtRow["datatype"].ToString();

                            if (strfName.Contains(" "))
                            {
                                string[] words = strfName.Split(' ');
                                strfName = words[words.Length - 1];
                            }
                            else if (strfName.Contains("."))
                            {
                                string[] words = strfName.Split('.');
                                strfName = words[1];
                            }
                            int iSize = int.Parse(dtRow["size"].ToString());


                            if (strFType == "c")
                            {
                                DataGridCheckBoxColumn checkBoxColumn = new DataGridCheckBoxColumn();
                                checkBoxColumn.Header = strDname;
                                checkBoxColumn.Binding = new Binding(strfName);
                                checkBoxColumn.Width = iSize;
                                dgvSearch.Columns.Add(checkBoxColumn);

                                if (iSize == 0)
                                    checkBoxColumn.Visibility = Visibility.Hidden;
                            }
                            else
                            {
                                DataGridTextColumn textColumn = new DataGridTextColumn();
                                textColumn.Header = strDname;
                                textColumn.Binding = new Binding(strfName);
                                textColumn.Width = iSize;

                                if (strFType == "d")
                                {
                                    textColumn.Binding.StringFormat = "yyyy/MMM/dd";
                                }

                                if (strFType == "n")
                                {
                                    textColumn.Binding.StringFormat = "{0:n2}";
                                    textColumn.CellStyle = rightCellStyle();
                                }

                                if (strFType == "t" && strfName == "itemName")
                                {
                                    Style textStyle = new Style(typeof(TextBlock));
                                    textStyle.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
                                    textColumn.ElementStyle = textStyle;
                                }

                                dgvSearch.Columns.Add(textColumn);

                                if (iSize == 0)
                                    textColumn.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            RefrechAll();
        }


        private void cbxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtFillter.Focus();
        }

        private void dgvSearch_KeyUp(object sender, KeyEventArgs e)
        {
            FilterChanged(e.Key);
        }

        private void dgvSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectionOk();
        }

        private void dgvSearch_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void txtFillter_KeyUp(object sender, KeyEventArgs e)
        {
            FilterChanged(e.Key);
        }

        private void dgvSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                Up(true);
            else if (e.Key == Key.Down)
                Up(false);
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void pop_Detail_Opened(object sender, EventArgs e)
        {
            RefrechAll();
        }


        #region Style     
        public static Style rightCellStyle()
        {
            Style style = new Style(typeof(DataGridCell));
            style.Setters.Add(new System.Windows.Setter
            {
                Property = Control.HorizontalAlignmentProperty,
                Value = HorizontalAlignment.Right
            });
            style.Setters.Add(new System.Windows.Setter
            {
                Property = Control.PaddingProperty,
                Value = new Thickness(0, 0, 5, 5)
            });
            return style;
        }

        public static Style centreCellStyle()
        {
            Style style = new Style(typeof(DataGridCell));
            style.Setters.Add(new System.Windows.Setter
            {
                Property = Control.HorizontalAlignmentProperty,
                Value = HorizontalAlignment.Center
            });
            return style;
        }

        #endregion
    }
}