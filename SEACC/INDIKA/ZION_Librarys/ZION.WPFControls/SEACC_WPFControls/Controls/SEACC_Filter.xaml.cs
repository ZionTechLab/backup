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

namespace SEACC_WPFControls
{
    public partial class SEACC_Filter : UserControl
    {
        #region Class Variables
        public event EventHandler Checked;
        public event EventHandler Unchecked;
        public event EventHandler TextChanged;
        public event EventHandler SortOrderChanged;
        public string sFilter = "";
        public int RowIndex;
        public int sortIndex = 0;
        public string BindingPath; 

        #endregion

        public SEACC_Filter()
        {
            InitializeComponent();
            IsFilterEnabled = true;
        }

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_Filter));
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

        public static DependencyProperty SEACC_isChecked_property = DependencyProperty.Register("IsChecked", typeof(bool), typeof(SEACC_Filter));
        public bool IsChecked
        {
            get
            {
                return (bool)GetValue(SEACC_isChecked_property);
            }
            set
            {
                SetValue(SEACC_isChecked_property, value);
            }
        }

        public static DependencyProperty SEACC_isFilterEnabled_property = DependencyProperty.Register("IsFilterEnabled", typeof(bool), typeof(SEACC_Filter));
        public bool IsFilterEnabled
        {
            get
            {
                return (bool)GetValue(SEACC_isFilterEnabled_property);
            }
            set
            {
                SetValue(SEACC_isFilterEnabled_property, value);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Checked(this, e);
            }
            catch (Exception)
            {
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Unchecked(this, e);
            }
            catch (Exception)
            {
            }
        }

        private void txt_Filter_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                sFilter = BindingPath + " Like '%" + txt_Filter.Text + "%' ";
                TextChanged(sFilter, e);
            }
            catch (Exception)
            {
            }
        }

        private void txt_SortOrder_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                sortIndex = int.Parse(txt_SortOrder.Text == "" ? "0" : txt_SortOrder.Text);
                SortOrderChanged(BindingPath, e);
                
            }
            catch (Exception)
            {
            }
        }
    }
}