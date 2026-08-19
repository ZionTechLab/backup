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

namespace SEACC_WPFControls
{
    public enum ColoumnType
    {
        Text,
        Numaric,
        CheckBox
    }

    public partial class SEACC_DataGrid_Advanced : UserControl
    {
        #region Class Variables

        public DataTable dt = new DataTable();

        public event EventHandler MouseLeftButtonUp1;

        public delegate void delegate_KeyEventArgs(object sender, KeyEventArgs e);
        public event delegate_KeyEventArgs DG_KeyDown;
        public event delegate_KeyEventArgs DG_PreviewKeyDown;

        public delegate void delegate_DataGridCellEditEndingEventArgs(object sender, DataGridCellEditEndingEventArgs e);
        public event delegate_DataGridCellEditEndingEventArgs CellEditEnding;

        public delegate void delegate_DataGridCellEditBeginingEventArgs(object sender, DataGridBeginningEditEventArgs e);
        public event delegate_DataGridCellEditBeginingEventArgs CellEditBegining;

        public delegate void delegate_DatagridCellChangeingEventArgs(object sender, EventArgs e);
        public event delegate_DatagridCellChangeingEventArgs CellChanging;

        public delegate void delegate_MouseButtonEventArgs(object sender, MouseButtonEventArgs e);
        public event delegate_MouseButtonEventArgs DG_MouseDoubleClick;
        public event delegate_MouseButtonEventArgs DG_MouseRightClick;

        public delegate void delegate_DataGridRowEventArgs(object sender, DataGridRowEventArgs e);
        public event delegate_DataGridRowEventArgs LoadingRow;

        int iColumnCount = 0;

        static BrushConverter bc = new BrushConverter();
        #endregion

        public DataGridCellInfo GetCurrentCell()
        {
            return grdMain.CurrentCell;
        }

        public static DependencyProperty SelectedIndex_Property = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(SEACC_DataGrid_Advanced));
        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndex_Property);
            }
            set
            {
                SetValue(SelectedIndex_Property, value);
            }
        }

        public static DependencyProperty HeaderColor_Property = DependencyProperty.Register("HeaderColor", typeof(Brush), typeof(SEACC_DataGrid_Advanced));
        public Brush HeaderColor
        {
            get
            {
                return (Brush)GetValue(HeaderColor_Property);
            }
            set
            {
                SetValue(HeaderColor_Property, value);
            }
        }

        public SEACC_DataGrid_Advanced()
        {
            InitializeComponent();
            this.Loaded += SEACC_DataGrid_Advanced_Loaded;
            HeaderColor = (Brush)bc.ConvertFrom("#FF0091EA");
        }

        void SEACC_DataGrid_Advanced_Loaded(object sender, RoutedEventArgs e)
        {
            this.grdMain.HeaderColor = HeaderColor;
        }

        public void setDatagrid_HeaderVisibility(bool isVisible_Gridheader)
        {
            if (isVisible_Gridheader)
                grdMain.HeadersVisibility = DataGridHeadersVisibility.Column;
            else
                grdMain.HeadersVisibility = DataGridHeadersVisibility.None;
        }

        #region Add new column
        public void Add_DatagridColoumn(ColoumnType DatagridColoumnType, string Header, string Binding, int width, bool isVisible, bool isReadOnly)
        {
           // dt.Columns.Add(Binding);

            Style sNumerics = new Style();
            sNumerics.Setters.Add(new Setter(TextBox.TextAlignmentProperty, TextAlignment.Right));

            switch (DatagridColoumnType)
            {
                case ColoumnType.Text:
                case ColoumnType.Numaric:
                    {
                        #region Text
                        DataGridTextColumn textColumn1 = new DataGridTextColumn();
                        textColumn1.Header = Header;

                        textColumn1.Binding = new Binding(Binding);

                        textColumn1.Width = width;
                        textColumn1.IsReadOnly = isReadOnly;

                        if (isVisible)
                            textColumn1.Width = double.Parse(textColumn1.Width.ToString());
                        else
                            textColumn1.MaxWidth = 0;

                        grdMain.Columns.Add(textColumn1);
                        #endregion

                        if (DatagridColoumnType == ColoumnType.Numaric)
                            textColumn1.CellStyle = sNumerics;
                    }
                    break;
                case ColoumnType.CheckBox:
                    {
                        DataGridTemplateColumn checkBoxColumn = new DataGridTemplateColumn();
                   
                        checkBoxColumn.Header = Header;

                        Binding bind = new Binding(Binding);
                        bind.Mode = BindingMode.TwoWay;
                        bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                        checkBoxColumn.SortMemberPath = Binding;

                      
                        FrameworkElementFactory checkboxFactory = new FrameworkElementFactory(typeof(DataGrid_CheckBox));
                        checkboxFactory.SetBinding(DataGrid_CheckBox.IsCheckedProperty, bind);
                        DataTemplate dataTemplate = new DataTemplate();
                        dataTemplate.VisualTree = checkboxFactory;

                   


                        checkBoxColumn.CellTemplate = dataTemplate;
 // checkBoxColumn.IsReadOnly = isReadOnly;

                        if (isVisible)
                            checkBoxColumn.Width = width;
                        else
                            checkBoxColumn.MaxWidth = 0;

                        Style sChks = new Style();
                        sChks.Setters.Add(new Setter(DataGridCell.HorizontalAlignmentProperty, HorizontalAlignment.Center));
                        sChks.Setters.Add(new Setter(DataGridCell.VerticalAlignmentProperty, VerticalAlignment.Center));
                     //   sChks.Setters.Add(new Setter(DataGridCell., VerticalAlignment.Center));
                        //  sChks.Triggers.Remove(DataGridCell.IsEnabledProperty);
                         sChks.Setters.Add(new Setter(DataGridCell.IsEnabledProperty, false));
                       // Style style = this.FindResource("CheckBoxStyle2") as Style;
                     //  checkBoxColumn.CellStyle = sChks;

                        grdMain.Columns.Add(checkBoxColumn);
                      
                    }
                    break;
                default:
                    break;
            }
        }

        public void Add_DatagridColoumn(string Header, string Binding, int width, bool isVisible)
        {
            Add_DatagridColoumn(ColoumnType.Text, Header, Binding, width, isVisible, true);
        }

        public void Add_DatagridColoumn(string Header, string Binding, int width)
        {
            Add_DatagridColoumn(ColoumnType.Text, Header, Binding, width, true, true);
        }
        #endregion

        public void RefreshGrid()
        {
            #region Clear Filters
            for (int i = dds.Children.Count - 1; i >= 0; i--)
            {
                dds.Children.RemoveAt(i);
            }
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            #endregion

            grdMain.ItemsSource = dt.DefaultView;

            //This is edited by Gayan 2016.07.22
            iColumnCount = 0; 
            foreach (DataGridColumn dd in grdMain.Columns)
            {
                SEACC_Filter c = new SEACC_Filter();
                if (dd.MaxWidth == 0)
                {
                    c.IsChecked = false;
                    dd.MaxWidth = 0;
                }
                else
                    c.IsChecked = true;

                c.Caption = dd.Header.ToString();
                c.RowIndex = iColumnCount;
                c.IsFilterEnabled = false;
                c.Checked += c_Checked;
                c.Unchecked += c_Unchecked;
                
                DataGridTemplateColumn checkBoxColumn = (dd as DataGridTemplateColumn);
                if (checkBoxColumn != null)
                {
                    c.BindingPath = null;
                }
                else
                {
                    var binding = (dd as DataGridBoundColumn).Binding as Binding;
                    c.BindingPath = binding.Path.Path;
                    c.IsFilterEnabled = true;
                    c.TextChanged += c_TextChanged;
                    c.SortOrderChanged += c_SortOrderChanged;
                }
                dds.Children.Add(c);
                iColumnCount++;
            }
        }

        public void SetFilterValue(string columnName_of_DataGrid, string columnName_of_DataTable, string value)
        {
            foreach (object child in dds.Children)
            {
                if (child is SEACC_Filter)
                {
                    SEACC_Filter element = (child as SEACC_Filter);

                    if (columnName_of_DataGrid == element.Caption)
                    {
                        element.txt_Filter.Text = value;
                        element.sFilter = value;
                        try
                        {
                            if (value != null && value != "")
                                dt.DefaultView.RowFilter = columnName_of_DataTable + "='" + value + "'";
                            else
                                dt.DefaultView.RowFilter = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            SEACCExeption.Show(ex);
                        }
                    }
                }
            }

        }

        void c_SortOrderChanged(object sender, EventArgs e)
        {
            List<SEACC_Filter> lst = new List<SEACC_Filter>();
            string sort = "";
            foreach (SEACC_Filter element in dds.Children)
            {
                if (element.sortIndex != 0)
                    lst.Add(element);
            }

            foreach (SEACC_Filter ee in lst.OrderBy(p => p.sortIndex))
            {
                if (sort == "")
                {
                    sort = ee.BindingPath;
                }
                else
                {
                    sort += " , " + ee.BindingPath;
                }
            }

            if (sort != "")
                sort += " ASC";

            dt.DefaultView.Sort = sort;
        }

        void c_TextChanged(object sender, EventArgs e)
        {
            string s = "";
            foreach (SEACC_Filter element in dds.Children)
            {
                if (element.sFilter != "")
                {
                    if (s == "")
                        s += element.sFilter;
                    else
                        s += " And " + element.sFilter;
                }
            }
            dt.DefaultView.RowFilter = s.ToString();
        }

        void c_Unchecked(object sender, EventArgs e)
        {
            SEACC_Filter hh = sender as SEACC_Filter;
            int i = 0;
            foreach (DataGridColumn dd in grdMain.Columns)
            {
                if (i == int.Parse(hh.RowIndex.ToString()))
                {
                    dd.MaxWidth = 0;
                    break;
                }
                i++;
            }
        }

        void c_Checked(object sender, EventArgs e)
        {
            SEACC_Filter hh = sender as SEACC_Filter;
            int i = 0;
            foreach (DataGridColumn dd in grdMain.Columns)
            {
                if (i == int.Parse(hh.RowIndex.ToString()))
                {
                    dd.MaxWidth = double.Parse(dd.Width.ToString());
                    break;
                }
                i++;
            }
        }

        #region Events
        private void grdMain_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                LoadingRow(sender, e);
            }
            catch (Exception)
            { }
        }

        private void grdMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MouseLeftButtonUp1(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void grdMain_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                CellEditEnding(sender, e);
            }
            catch (Exception)
            {
            }
        }


        private void grdMain_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            try
            {
                CellEditBegining(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void grdMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DG_MouseDoubleClick(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void grdMain_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DG_MouseRightClick(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void grdMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DG_KeyDown(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void grdMain_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DG_PreviewKeyDown(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void grdMain_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                CellChanging(sender, e);
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}