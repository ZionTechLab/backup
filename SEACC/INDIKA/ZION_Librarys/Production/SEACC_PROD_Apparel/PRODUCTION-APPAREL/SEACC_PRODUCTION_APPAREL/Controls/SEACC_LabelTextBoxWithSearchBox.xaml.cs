using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_WPFControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Data;

namespace SEACC_PRODUCTION_APPAREL.Controls
{
    /// <summary>
    /// Interaction logic for SEACC_LabelTextBoxWithSearchBox.xaml
    /// </summary>
    public partial class SEACC_LabelTextBoxWithSearchBox : UserControl
    {
        public delegate void SearchBoxClose_Delegate();
        public event SearchBoxClose_Delegate SearchBoxClose;

        public List<string> lstSearchParam = new List<string>();

        public SEACC_LabelTextBoxWithSearchBox()
        {
            InitializeComponent();
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtLabelTextBox, true, false, true);
        }


        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LabelTextBoxWithSearchBox));
        public string Caption
        {
            get
            {
                return (string)GetValue(SEACC_CaptionProperty);
            }
            set
            {
                SetValue(SEACC_CaptionProperty, value);
            }
        }

        public static DependencyProperty SEACC_TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SEACC_LabelTextBoxWithSearchBox));
        public string Text
        {
            get
            {
                return (string)GetValue(SEACC_TextProperty);
            }
            set
            {
                SetValue(SEACC_TextProperty, value);
            }
        }


        public static DependencyProperty SearchEmunId_Property = DependencyProperty.Register("SearchEmunId", typeof(int), typeof(SEACC_LabelTextBoxWithSearchBox));
        public int SearchEmunId
        {
            get
            {
                return (int)GetValue(SearchEmunId_Property);
            }
            set
            {
                SetValue(SearchEmunId_Property, value);
            }
        }

        public static DependencyProperty SelectedList_Property = DependencyProperty.Register("SelectedList", typeof(DataRow[]), typeof(SEACC_LabelTextBoxWithSearchBox));
        public DataRow[] SelectedList
        {
            get
            {
                return (DataRow[])GetValue(SelectedList_Property);
            }
            set
            {
                SetValue(SelectedList_Property, value);
            }
        }

        private void txtLabelTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SearchEmunId > 0)
            {
                frm_search_multipleSelect RowDataSearch = new frm_search_multipleSelect(SelectedList);
                RowDataSearch.lstPara = lstSearchParam;
                RowDataSearch.Show((Digiteq_Logic.Search)SearchEmunId, true);
                RowDataSearch.SearchClosed += RowDataSearch_SearchClosed;
            }
        }

        private void RowDataSearch_SearchClosed(DataRow[] drSelected)
        {
            SelectedList = drSelected;
            SearchBoxClose();
        }

        private void userControl_GotFocus(object sender, RoutedEventArgs e)
        {
            txtLabelTextBox.TextBox1.Focus();
        }
    }
}
