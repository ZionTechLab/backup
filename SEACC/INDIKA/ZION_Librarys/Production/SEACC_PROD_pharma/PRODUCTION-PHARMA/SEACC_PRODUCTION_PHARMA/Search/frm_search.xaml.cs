using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_PHARMA.Search
{
    /// <summary>
    /// Interaction logic for frm_search.xaml
    /// </summary>
    public partial class frm_search : Window
    {
        #region Class Variables
        string sSearch_ID = "", strTable = "", strFields = "", strSelection = "", strSelection2 = "", strOrderBy = "";
        private bool bMultipleSelections = false;
        protected List<string> lstReturn = new List<string>();
        protected List<string> lstPara = new List<string>();
        Dictionary<string, string> dicFilter = new Dictionary<string, string>();
        DataTable dtResult;

        public delegate void delegate_RowSelected(List<string> lstSelected);
        public event delegate_RowSelected RowSelected;


        #endregion

        public frm_search()
        {
            InitializeComponent();
        }

        public frm_search(List<string> lstParameeters)
        {
            InitializeComponent();
            lstPara = lstParameeters;
        }

        private void frmSearch_Loaded(object sender, RoutedEventArgs e)
        {

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
                        strSelection = dtRow1["Selection1"].ToString();
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

        public List<string> Show(Digiteq_Logic.Search SearcEnm)
        {
            sSearch_ID = ((int)SearcEnm).ToString();
            SetWidth((int)SearcEnm);
            ShowDialog();
            return lstReturn;
        }

        public void Show(Digiteq_Logic.Search SearcEnm, bool bMultipleSelect)
        {
            bMultipleSelections = bMultipleSelect;
            sSearch_ID = ((int)SearcEnm).ToString();
            SetWidth((int)SearcEnm);
            Show();
        }

        private void RefrechAll()
        {
            try
            {
                string sWhere = (strSelection != "" ? " WHERE " : "") + strSelection;
                string sOrderBy = (strOrderBy != "" ? " ORDER BY " : "") + strOrderBy + " " + (strOrderBy != "" ? " DESC " : "");

                if (lstPara.Count > 0)
                {
                    int iListIndex = 1;
                    foreach (string s in lstPara)
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
                    dgvSearch.ItemsSource = dtResult.DefaultView;
                    FilterChanged(Key.K);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
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
                DataRowView row = (DataRowView)dgvSearch.SelectedItems[0];
                if (row != null)
                {
                    int iColumnIndex = 0;
                    if (bMultipleSelections)
                    {
                        if (dgvSearch.SelectedItems.Count != 0)
                        {
                            lstReturn.Clear();
                            foreach (DataGridColumn column in dgvSearch.Columns)
                            {
                                lstReturn.Add(row[iColumnIndex].ToString());
                                iColumnIndex++;
                            }
                            RowSelected(lstReturn);
                        }
                    }
                    else
                    {
                        if (dgvSearch.SelectedItems.Count != 0)
                        {

                            foreach (DataGridColumn column in dgvSearch.Columns)
                            {
                                lstReturn.Add(row[iColumnIndex].ToString());
                                iColumnIndex++;
                            }
                            DialogResult = true;
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void FilterChanged(Key k)
        {
            try
            {
                if (k == Key.F9)
                {
                    cbxSearch.SelectedIndex = ((dicFilter.Count - 1) == cbxSearch.SelectedIndex) ? 0 : cbxSearch.SelectedIndex + 1;
                }

                else if (k == Key.Escape)
                {
                    if (bMultipleSelections)
                        Close();
                    else
                        DialogResult = false;
                }
                else if (k == Key.Up)
                    Up(true);
                else if (k == Key.Down)
                    Up(false);

                string sFilter = dicFilter[cbxSearch.Text] + " Like '%" + clsHelpMethods.CheckValue(txtFillter.Text) + "%' ";
                if (cbx_ShowAll.IsChecked != true)
                {
                    BrushConverter bc = new BrushConverter();
                    dgvSearch.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
                dtResult.DefaultView.RowFilter = sFilter;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            if (Grd_Settings.Height == 0)
                Grd_Settings.Height = 127;
            else
                Grd_Settings.Height = 0;
        }

        private void cbxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtFillter.Focus();
        }

        private void txtFillter_KeyDown(object sender, KeyEventArgs e)
        {
            FilterChanged(e.Key);
        }

        private void dgvSearch_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                BrushConverter bc = new BrushConverter();
                string g = ((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[2].ToString();
                if (g == "True")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#800000");
                }
            }
            catch (Exception)
            {
            }
        }

        private void cbx_ShowAll_Checked(object sender, RoutedEventArgs e)
        {
            FilterChanged(Key.K);
        }

        private void cbx_ShowAll_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterChanged(Key.K);
        }

        private void dgvSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SelectionOk();
            }
        }

        private void dgvSearch_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!bMultipleSelections)
                SelectionOk();
        }

        private void dgvSearch_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.F10)
            {
                txtFillter.Focus();
            }
        }

        private void dgvSearch_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (bMultipleSelections)
                SelectionOk();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            if (bMultipleSelections)
                Close();
            else
                DialogResult = false;
        }

        private void SetWidth(int iSearchID)
        {
            tbl_cfgSearch oSearch = tbl_cfgSearch.Select(iSearchID);
            if (oSearch != null && oSearch.Width != 0)
                Width = oSearch.Width;
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
