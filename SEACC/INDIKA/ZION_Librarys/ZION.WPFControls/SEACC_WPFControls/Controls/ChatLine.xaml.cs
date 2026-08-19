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
    /// Interaction logic for ChatLine.xaml
    /// </summary>
    public partial class ChatLine : UserControl
    {
        public ChatLine()
        {
            InitializeComponent();
        }
        public ChatLine(string text)
        {
            InitializeComponent();
            txt_1.Text = text;
        }

        public static DependencyProperty Text_Property = DependencyProperty.Register("text", typeof(string), typeof(ChatLine));
        public string text
        {
            get
            {
                return (string)GetValue(Text_Property);
            }
            set
            {
                SetValue(Text_Property, value);
            }
        }

        public static DependencyProperty Image_Property = DependencyProperty.Register("sticker", typeof(ImageSource), typeof(ChatLine));
        public ImageSource sticker
        {
            get
            {
                return (ImageSource)GetValue(Image_Property);
            }
            set
            {
                SetValue(Image_Property, value);
            }
        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (text == "")
                Grd_Messege.Visibility = Visibility.Collapsed;
        }
    }
}
