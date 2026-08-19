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
    /// Interaction logic for SEACC_LabelImageBox.xaml
    /// </summary>
    public partial class SEACC_LabelImageBox : UserControl
    {
        BrushConverter bc = new BrushConverter();
        public SEACC_LabelImageBox()
        {
            InitializeComponent();

            LabelImageBox_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            LabelImageBox_BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");
            DetailBox_Width = 250;
        }

        public void setImage(BitmapImage img)
        {
            imageBox.Source = img;
        }

        public BitmapImage getImage()
        {
            return (BitmapImage)imageBox.Source;
        }

        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SEACC_LabelImageBox));
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LabelImageBox));
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

        public static DependencyProperty SEACC_ErrorTextProperty = DependencyProperty.Register("ErrorText", typeof(string), typeof(SEACC_LabelImageBox));
        public string ErrorText
        {
            get
            {
                return (string)GetValue(SEACC_ErrorTextProperty);
            }
            set
            {
                SetValue(SEACC_ErrorTextProperty, value);
            }
        }

        public static DependencyProperty LabelImageBox_BorderBrush_Property = DependencyProperty.Register("LabelImageBox_BorderBrush", typeof(Brush), typeof(SEACC_LabelImageBox));
        public Brush LabelImageBox_BorderBrush
        {
            get
            {
                return (Brush)GetValue(LabelImageBox_BorderBrush_Property);
            }
            set
            {
                SetValue(LabelImageBox_BorderBrush_Property, value);
            }
        }

        public static DependencyProperty DetailBox_Width_Property = DependencyProperty.Register("DetailBox_Width", typeof(int), typeof(SEACC_LabelImageBox));
        public int DetailBox_Width
        {
            get
            {
                return (int)GetValue(DetailBox_Width_Property);
            }
            set
            {
                SetValue(DetailBox_Width_Property, value);
            }
        }

        public static DependencyProperty LabelImageBox_Background_Property = DependencyProperty.Register("LabelImageBox_Background", typeof(Brush), typeof(SEACC_LabelImageBox));
        public Brush LabelImageBox_Background
        {
            get
            {
                return (Brush)GetValue(LabelImageBox_Background_Property);
            }
            set
            {
                SetValue(LabelImageBox_Background_Property, value);
            }
        }

        private void userControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 298)
            {
                grd_image.Margin = new Thickness(5, 35, 5, 5);
                grd_image.HorizontalAlignment = HorizontalAlignment.Center;
                label.VerticalAlignment = VerticalAlignment.Top;
                grd_image.Width = ActualWidth <= 10 ? 0 : ActualWidth - 10;
            }
            else
            {
                grd_image.Margin = new Thickness(120, 2, 0, 2);
                grd_image.HorizontalAlignment = HorizontalAlignment.Left;
                label.VerticalAlignment = VerticalAlignment.Center;
                grd_image.Width = ActualWidth - 125;
            }
        }

        private void btn_addImage_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                imageBox.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.Absolute));
            }
        }
    }
}
