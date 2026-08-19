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
    /// <summary>
    /// Interaction logic for SEACC_ItemControllerBox.xaml
    /// </summary>
    public partial class SEACC_ItemControllerBox : UserControl
    {
        BrushConverter bc = new BrushConverter();
        public SEACC_ItemControllerBox()
        {
            InitializeComponent();

            BackgroundBrush = (Brush)bc.ConvertFrom("#000000");
            Foreground = (Brush)bc.ConvertFrom("#FFFFFFFF");

            ItemCodeFontSize = 9;
            ItemNameFontSize = 12;
            ItemDescFontSize = 9;

            ItemCodeText = "Item Code";
            ItemNameText = "Item Name";
            ItemDescText = "Item Description";

            ShowCodeAndDescription = Visibility.Collapsed;
        }

        public static DependencyProperty SEACC_ShowCodeAndDescriptionProperty = DependencyProperty.Register("ShowCodeAndDescription", typeof(Visibility), typeof(SEACC_ItemControllerBox));
        public Visibility ShowCodeAndDescription
        {
            get
            {
                return (Visibility)GetValue(SEACC_ShowCodeAndDescriptionProperty);
            }
            set
            {
                SetValue(SEACC_ShowCodeAndDescriptionProperty, value);
            }
        }

        //Text
        public static DependencyProperty SEACC_ItemCodeTextProperty = DependencyProperty.Register("ItemCodeText", typeof(string), typeof(SEACC_ItemControllerBox));
        public string ItemCodeText
        {
            get
            {
                return (string)GetValue(SEACC_ItemCodeTextProperty);
            }
            set
            {
                SetValue(SEACC_ItemCodeTextProperty, value);
            }
        }

        public static DependencyProperty SEACC_ItemNameTextProperty = DependencyProperty.Register("ItemNameText", typeof(string), typeof(SEACC_ItemControllerBox));
        public string ItemNameText
        {
            get
            {
                return (string)GetValue(SEACC_ItemNameTextProperty);
            }
            set
            {
                SetValue(SEACC_ItemNameTextProperty, value);
            }
        }

        public static DependencyProperty SEACC_ItemDescTextProperty = DependencyProperty.Register("ItemDescText", typeof(string), typeof(SEACC_ItemControllerBox));
        public string ItemDescText
        {
            get
            {
                return (string)GetValue(SEACC_ItemDescTextProperty);
            }
            set
            {
                SetValue(SEACC_ItemDescTextProperty, value);
            }
        }

        //Font Sizes
        public static DependencyProperty SEACC_ItemCodeFontSizeProperty = DependencyProperty.Register("ItemCodeFontSize", typeof(int), typeof(SEACC_ItemControllerBox));
        public int ItemCodeFontSize
        {
            get
            {
                return (int)GetValue(SEACC_ItemCodeFontSizeProperty);
            }
            set
            {
                SetValue(SEACC_ItemCodeFontSizeProperty, value);
            }
        }

        public static DependencyProperty SEACC_ItemNameFontSizeProperty = DependencyProperty.Register("ItemNameFontSize", typeof(int), typeof(SEACC_ItemControllerBox));
        public int ItemNameFontSize
        {
            get
            {
                return (int)GetValue(SEACC_ItemNameFontSizeProperty);
            }
            set
            {
                SetValue(SEACC_ItemNameFontSizeProperty, value);
            }
        }

        public static DependencyProperty SEACC_ItemDescFontSizeProperty = DependencyProperty.Register("ItemDescFontSize", typeof(int), typeof(SEACC_ItemControllerBox));
        public int ItemDescFontSize
        {
            get
            {
                return (int)GetValue(SEACC_ItemDescFontSizeProperty);
            }
            set
            {
                SetValue(SEACC_ItemDescFontSizeProperty, value);
            }
        }

        //Brushes
        public static DependencyProperty SEACC_ItemBackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(SEACC_ItemControllerBox));
        public Brush BackgroundBrush
        {
            get
            {
                return (Brush)GetValue(SEACC_ItemBackgroundBrushProperty);
            }
            set
            {
                SetValue(SEACC_ItemBackgroundBrushProperty, value);
            }
        }

        //public static DependencyProperty SEACC_ItemControllerForeground = DependencyProperty.Register("Foreground", typeof(Brush), typeof(SEACC_ItemControllerBox));
        //public Brush Foreground
        //{
        //    get
        //    {
        //        return (Brush)GetValue(SEACC_ItemControllerForeground);
        //    }
        //    set
        //    {
        //        SetValue(SEACC_ItemControllerForeground, value);
        //    }
        //}
    }
}
