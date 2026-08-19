using System;
using System.Collections.Generic;
using System.Data;
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

namespace SEACC_WPFControls.Controls
{
    /// <summary>
    /// Interaction logic for SEACC_LablelMultipleSelectBox.xaml
    /// </summary>
    public partial class SEACC_LablelMultipleSelectBox : UserControl
    {
        BrushConverter bc = new BrushConverter();
        DataTable dtControl = new DataTable();

        public SEACC_LablelMultipleSelectBox()
        {
            InitializeComponent();

            dtControl.Columns.Add("check", typeof(bool));
            dtControl.Columns.Add("id");
            dtControl.Columns.Add("name");

            Header_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            Grid_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");

            DetailGrid_Width = 225;
            dgControl.ItemsSource = dtControl.DefaultView;

            SetData(true, "SEALL", "Select All");
        }

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LablelMultipleSelectBox));
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

        public static DependencyProperty SEACC_TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SEACC_LablelMultipleSelectBox));
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

        public static DependencyProperty DetailGrid_Width_Property = DependencyProperty.Register("DetailGrid_Width", typeof(int), typeof(SEACC_LablelMultipleSelectBox));
        public int DetailGrid_Width
        {
            get
            {
                return (int)GetValue(DetailGrid_Width_Property);
            }
            set
            {
                SetValue(DetailGrid_Width_Property, value);
            }
        }

        public static DependencyProperty Grid_BorderBrush_Property = DependencyProperty.Register("Grid_BorderBrush", typeof(Brush), typeof(SEACC_LablelMultipleSelectBox));
        public Brush Grid_BorderBrush
        {
            get
            {
                return (Brush)GetValue(Grid_BorderBrush_Property);
            }
            set
            {
                SetValue(Grid_BorderBrush_Property, value);
            }
        }

        public static DependencyProperty Header_Background_Property = DependencyProperty.Register("Header_Background", typeof(Brush), typeof(SEACC_LablelMultipleSelectBox));
        public Brush Header_Background
        {
            get
            {
                return (Brush)GetValue(Header_Background_Property);
            }
            set
            {
                SetValue(Header_Background_Property, value);
            }
        }

        private void userControl_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 120 + 2 * DetailGrid_Width / 3)
            {
                grdDetail.Margin = new Thickness(5, 27, 5, 5);
                grdDetail.HorizontalAlignment = HorizontalAlignment.Center;
                grdDetail.Width = ActualWidth <= 10 ? 0 : ActualWidth - 10;
            }
            else
            {
                grdDetail.Margin = new Thickness(120, 2, 0, 2);
                grdDetail.HorizontalAlignment = HorizontalAlignment.Left;
                grdDetail.Width = ActualWidth - 125;
            }
        }

        private void userControl_GotFocus_1(object sender, RoutedEventArgs e)
        {
            dgControl.Focus();
        }

        private void dgControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgControl.SelectedIndex;
            var vDG_Cell = dgControl.CurrentCell;
            try
            {
                dtControl.Rows[irowID]["check"] = dtControl.Rows[irowID]["check"].ToString() == "True" ? false : true;
            }
            catch (Exception)
            { }
            finally
            {
                SelectAll(irowID);
            }

        }

        public void SetData(bool bSelect, string sID, string sName)
        {
            dtControl.Rows.Add(bSelect, sID, sName);
        }

        public void ClearData()
        {
            dtControl.Rows.Clear();
            SetData(true, "SEALL", "Select All");
        }

        public DataTable GetData()
        {
            DataTable dtResults = new DataTable();
            var vResults = dtControl.AsEnumerable().Where(r => r.Field<bool>("check") == true);

            if (vResults.Count() > 0)
                dtResults = vResults.CopyToDataTable();

            return dtResults;
        }

        public void SelectAll(int iSelectAllRowID)
        {
            if (dtControl.Rows[0]["check"].ToString() == "True" && iSelectAllRowID == 0)
                dtControl.AsEnumerable().ToList().ForEach(row => row["check"] = true);
            else if (dtControl.Rows[0]["check"].ToString() == "False" && iSelectAllRowID == 0)
                dtControl.AsEnumerable().ToList().ForEach(row => row["check"] = false);


            if (dtControl.AsEnumerable().Where(r => r.Field<string>("id") != "SEALL").Count() == dtControl.AsEnumerable().Where(r => r.Field<bool>("check") == true && r.Field<string>("id") != "SEALL").Count())
                dtControl.Rows[0]["check"] = true;
            else
                dtControl.Rows[0]["check"] = false;
        }

        public bool IsSelectAll()
        {
            bool bSelectAll = false;
            try
            {
                if (bool.Parse(dtControl.Rows[0]["check"].ToString()) == true)
                    bSelectAll = true;
            }
            catch { }
            return bSelectAll;
        }
    }
}
