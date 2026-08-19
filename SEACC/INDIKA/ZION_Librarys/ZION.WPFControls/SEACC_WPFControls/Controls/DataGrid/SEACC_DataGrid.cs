using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Data;
using SEACC_WPFControls.Logic;

namespace SEACC_WPFControls
{
    public class SEACC_DataGrid : DataGrid
    {
        ContextMenu cm = new ContextMenu();
        clsExport Exp = null;

        static BrushConverter bc = new BrushConverter();

        public SEACC_DataGrid()
        {
            Style style = this.FindResource("SEACC_DataGridStyle_Standerd") as Style;
            Style = style;

            this.MouseRightButtonDown += SEACC_DataGrid_MouseRightButtonDown;

            MenuItem mi1 = new MenuItem();
            mi1.Header = "Export To Excel";
            mi1.Click += mi1_Click;

            MenuItem mi2 = new MenuItem();
            mi2.Header = "Export To Word";
            mi2.Click += mi2_Click;

            MenuItem mi3 = new MenuItem();
            mi3.Header = "Export To Text";
            mi3.Click += mi3_Click;

            MenuItem mi4 = new MenuItem();
            mi4.Header = "Export To HTML";
            mi4.Click += mi4_Click;

            MenuItem mi5 = new MenuItem();
            mi5.Header = "Export To CSV";
            mi5.Click +=mi5_Click;

            cm.Items.Add(mi1);
            cm.Items.Add(mi2);
            cm.Items.Add(mi3);
            cm.Items.Add(mi4);
            cm.Items.Add(mi5);

            HeaderColor = (Brush)bc.ConvertFrom("#FF0091EA");
            Headerforeground = (Brush)bc.ConvertFrom("White");
            this.Loaded += SEACC_DataGrid_Loaded;
        }

        void SEACC_DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Style style1 = new Style(typeof(System.Windows.Controls.Primitives.DataGridColumnHeader));
            style1.Setters.Add(new Setter { Property = BackgroundProperty, Value = HeaderColor });
            style1.Setters.Add(new Setter { Property = ForegroundProperty, Value = Headerforeground });
            style1.Setters.Add(new Setter { Property = PaddingProperty, Value = new Thickness(5) });
            style1.Setters.Add(new Setter { Property = BorderThicknessProperty, Value = new Thickness(0.5) });
            style1.Setters.Add(new Setter { Property = BorderBrushProperty, Value = (Brush)bc.ConvertFrom("#FFFFFF") });

            this.ColumnHeaderStyle = style1;
        }

        public static DependencyProperty HideContextMenu_Property = DependencyProperty.Register("HideContextMenu", typeof(bool), typeof(SEACC_DataGrid));
        public bool HideContextMenu
        {
            get
            {
                return (bool)GetValue(HideContextMenu_Property);
            }
            set
            {
                SetValue(HideContextMenu_Property, value);
            }
        }

        public static DependencyProperty HeaderColor_Property = DependencyProperty.Register("HeaderColor", typeof(Brush), typeof(SEACC_DataGrid));
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

        public static DependencyProperty Headerforeground_Property = DependencyProperty.Register("Headerforeground", typeof(Brush), typeof(SEACC_DataGrid));
        public Brush Headerforeground
        {
            get
            {
                return (Brush)GetValue(Headerforeground_Property);
            }
            set
            {
                SetValue(Headerforeground_Property, value);
            }

        }

        private void mi5_Click(object sender, RoutedEventArgs e)
        {
            if (Exp == null)
                Exp = new clsExport();
            Exp.ExportToCSV(((DataView)this.ItemsSource).ToTable());
        }

        private void mi4_Click(object sender, RoutedEventArgs e)
        {
            if (Exp == null)
                Exp = new clsExport();
            Exp.ExportToHtml(((DataView)this.ItemsSource).ToTable());
        }

        private void mi3_Click(object sender, RoutedEventArgs e)
        {
            if (Exp == null)
                Exp = new clsExport();
            Exp.ExportToText(((DataView)this.ItemsSource).ToTable());
        }

        private void mi2_Click(object sender, RoutedEventArgs e)
        {
            if (Exp == null)
                Exp = new clsExport();
            Exp.ExportToWord(((DataView)this.ItemsSource).ToTable());
        }

        private void mi1_Click(object sender, RoutedEventArgs e)
        {
            clsExport_EP ex = new clsExport_EP();
            ex.Export_To_Excel("",((DataView)this.ItemsSource).ToTable());
            //if (Exp == null)
            //    Exp = new clsExport();
            //Exp.ExportToExcel(((DataView)this.ItemsSource).ToTable());
        }

        void SEACC_DataGrid_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!HideContextMenu)
            {
                cm.IsOpen = true;
                cm.PlacementTarget = this as SEACC_DataGrid;
            }
            else
                cm.IsOpen = false;
        }
    }
}
