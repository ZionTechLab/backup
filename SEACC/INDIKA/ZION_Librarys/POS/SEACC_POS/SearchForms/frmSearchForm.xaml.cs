using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace SEACC_POS.Search_Forms
{
    /// <summary>
    /// Interaction logic for frmSearchForm.xaml
    /// </summary>
    public partial class frmSearchForm : Window
    {
        #region Class Variables
        string sSearch_ID = "", strTable = "", strFields = "", strSelection = "", strSelection2 = "", strOrderBy = "", strShowAll = "'False'";
        protected List<string> lstReturn = new List<string>();
        protected List<string> lstPara = new List<string>();
        Dictionary<string, string> dicFilter = new Dictionary<string, string>();
        DataTable dtResult;
        #endregion

        public frmSearchForm()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; //set the max hight of windows to Maximum screen size without affecting to display task bar
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth - 5;
        }

        public frmSearchForm(List<string> lstParameeters)
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; //set the max hight of windows to Maximum screen size without affecting to display task bar
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth - 5;
            lstPara = lstParameeters;
        }

        public List<string> Show(Search SearcEnm)
        {
            sSearch_ID = ((int)SearcEnm).ToString();
            SetWidth((int)SearcEnm);
            ShowDialog();
            return lstReturn;
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

                dgvSearch.ScrollIntoView(dgvSearch.SelectedItem);
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
                        DialogResult = true;
                    }
                }
            }
            catch (Exception)
            {
                DialogResult = false;
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            if (Grd_Settings.Height == 0)
                Grd_Settings.Height = 80;
            else
                Grd_Settings.Height = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtFillter.Focus();
            try
            {
                DataTable dtResult_Table = DBHandling.ExecQuery("select * from tbl_cfgSearch Where searchId='" + sSearch_ID + "'").Tables[0];
                if (dtResult_Table != null && dtResult_Table.Rows.Count > 0)
                {
                    foreach (DataRow dtRow1 in dtResult_Table.Rows)
                    {
                        strTable += dtRow1["searchtable"].ToString();
                        lblHeader.Content = dtRow1["displayName"].ToString();
                        strSelection = dtRow1["Selection1"].ToString();
                        strSelection2 = dtRow1["Selection2"].ToString();
                        strOrderBy = dtRow1["orderBy"].ToString();
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
                                    textColumn.CellStyle = CentreCellStyle();
                                }
                                else if (strFType == "n")
                                {
                                    textColumn.Binding.StringFormat = "{0:n2}";
                                    textColumn.CellStyle = RightCellStyle();
                                }
                                else
                                {
                                    textColumn.CellStyle = LeftCellStyle();
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

        private void RefrechAll()
        {
            try
            {
                string sWhere = (strSelection != "" ? " WHERE " : "") + strSelection;
                string sOrderBy = (strOrderBy != "" ? " ORDER BY " : "") + strOrderBy;//+ " " + (strOrderBy != "" ? " DESC " : "")

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

        private void FilterChanged(Key k)
        {
            try
            {
                if (k == Key.F9)
                    cbxSearch.SelectedIndex = ((dicFilter.Count - 1) == cbxSearch.SelectedIndex) ? 0 : cbxSearch.SelectedIndex + 1;
                else if (k == Key.Escape)
                    DialogResult = false;
                else if (k == Key.Enter)
                    SelectionOk();
                else if (k == Key.Up)
                    Up(true);
                else if (k == Key.Down)
                    Up(false);

                string sFilter = dicFilter[cbxSearch.Text] + " Like '%" + txtFillter.Text + "%' ";
                if (cbx_ShowAll.IsChecked != true && (strFields.Contains("isDeleted") || strFields.Contains("isCanceled")))
                {
                    if (strFields.Contains("isDeleted"))
                        sFilter += " AND isDeleted=" + strShowAll;
                    else if (strFields.Contains("isCanceled"))
                        sFilter += " AND isCanceled=" + strShowAll;

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

        private void txtFillter_KeyUp(object sender, KeyEventArgs e)
        {
            FilterChanged(e.Key);
        }

        private void cbxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtFillter.Focus();
        }

        private void dgvSearch_KeyUp(object sender, KeyEventArgs e)
        {
            FilterChanged(e.Key);
        }

        private void dgvSearch_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                BrushConverter bc = new BrushConverter();
                string g = ((DataRowView)(e.Row.DataContext)).Row.ItemArray[4].ToString();
                if (g == "True")
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#800000");
                }
                else
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#000000");
                }
            }
            catch (Exception)
            { }
        }

        private void dgvSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectionOk();
        }

        private void frm_Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            { }
        }

        private void cbx_ShowAll_Checked(object sender, RoutedEventArgs e)
        {
            strShowAll = "'True'";
            RefrechAll();
        }

        private void cbx_ShowAll_Unchecked(object sender, RoutedEventArgs e)
        {
            strShowAll = "'False'";
            RefrechAll();
        }

        private void Grd_Settings_LostFocus(object sender, RoutedEventArgs e)
        {
            Grd_Settings.Height = 0;
        }

        #region Style     
        public static Style RightCellStyle()
        {
            Style style = new Style(typeof(DataGridCell));
            style.Setters.Add(new System.Windows.Setter
            {
                Property = Control.HorizontalAlignmentProperty,
                Value = HorizontalAlignment.Right
            });
            style.Setters.Add(new System.Windows.Setter
            {
                Property = VerticalAlignmentProperty,
                Value = VerticalAlignment.Center
            });
            return style;
        }

        public static Style LeftCellStyle()
        {
            Style style = new Style(typeof(DataGridCell));
            style.Setters.Add(new System.Windows.Setter
            {
                Property = Control.HorizontalAlignmentProperty,
                Value = HorizontalAlignment.Left
            });
            style.Setters.Add(new System.Windows.Setter
            {
                Property = VerticalAlignmentProperty,
                Value = VerticalAlignment.Center
            });
            return style;
        }

        public static Style CentreCellStyle()
        {
            Style style = new Style(typeof(DataGridCell));
            style.Setters.Add(new System.Windows.Setter
            {
                Property = Control.HorizontalAlignmentProperty,
                Value = HorizontalAlignment.Center
            });
            style.Setters.Add(new System.Windows.Setter
            {
                Property = TextBlock.TextAlignmentProperty,
                Value = TextAlignment.Center
            });
            style.Setters.Add(new System.Windows.Setter
            {
                Property = VerticalAlignmentProperty,
                Value = VerticalAlignment.Center
            });
            return style;
        }

        #endregion

        private void SetWidth(int iSearchID)
        {
            tbl_cfgSearch oSearch = tbl_cfgSearch.Select(iSearchID);
            if (oSearch != null && oSearch.Width != 0)
                Width = oSearch.Width;
        }
    }
}
