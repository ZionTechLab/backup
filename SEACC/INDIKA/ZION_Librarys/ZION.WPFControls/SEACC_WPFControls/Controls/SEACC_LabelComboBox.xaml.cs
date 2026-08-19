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
    /// Interaction logic for SEACC_LabelComboBox.xaml
    /// </summary>
    public partial class SEACC_LabelComboBox : UserControl
    {

        BrushConverter bc = new BrushConverter();

        public SEACC_LabelComboBox()
        {
            InitializeComponent();

            ComboBox_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            ComboBox_BorderBrush = (Brush)bc.ConvertFrom("#33adff");
            DetailBox_Width = 225;
        }

        public void SetValues(List<string> list)
        {
            comboBox.ItemsSource = list;
        }

        public void SetValues(Type list)
        {
            comboBox.ItemsSource = Enum.GetValues(list);
        }

        public string GetSelectedValue()
        {
            try
            {
                return comboBox.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
                return "";
            }
        }

        public int GetSelectedIndex()
        {
            return comboBox.SelectedIndex;
        }

        public void SetSelectedIndex(int index)
        {
            comboBox.SelectedIndex = index;
        }

        public void SetSelectedValue(string value)
        {
            comboBox.SelectedItem = value;
        }

        public void setReadOnlyStatus(bool isReadOnly)
        {
            this.comboBox.IsReadOnly = isReadOnly;
        }

        public void SetDisplayMenberPath(string path)
        {
            comboBox.DisplayMemberPath = path;
        }

        public void SetSelectedValuePath(string path)
        {
            comboBox.SelectedValuePath = path;
            
        }


        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SEACC_LabelComboBox));
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

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LabelComboBox));
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

        public static DependencyProperty SEACC_ErrorTextProperty = DependencyProperty.Register("ErrorText", typeof(string), typeof(SEACC_LabelComboBox));
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

        public static DependencyProperty ComboBox_BorderBrush_Property = DependencyProperty.Register("ComboBox_BorderBrush", typeof(Brush), typeof(SEACC_LabelComboBox));
        public Brush ComboBox_BorderBrush
        {
            get
            {
                return (Brush)GetValue(ComboBox_BorderBrush_Property);
            }
            set
            {
                SetValue(ComboBox_BorderBrush_Property, value);
            }
        }

        public static DependencyProperty DetailBox_Width_Property = DependencyProperty.Register("DetailBox_Width", typeof(int), typeof(SEACC_LabelComboBox));
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

        public static DependencyProperty ComboBox_Background_Property = DependencyProperty.Register("ComboBox_Background", typeof(Brush), typeof(SEACC_LabelComboBox));
        public Brush ComboBox_Background
        {
            get
            {
                return (Brush)GetValue(ComboBox_Background_Property);
            }
            set
            {
                SetValue(ComboBox_Background_Property, value);
            }
        }

        private void userControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 120 + 2 * DetailBox_Width / 3)
            {
                comboBox.Margin = new Thickness(5, 27, 5, 5);
                comboBox.HorizontalAlignment = HorizontalAlignment.Center;
                comboBox.Width = ActualWidth <= 10 ? 0 : ActualWidth - 10;
            }
            else
            {
                comboBox.Margin = new Thickness(120, 2, 0, 2);
                comboBox.HorizontalAlignment = HorizontalAlignment.Left;
                comboBox.Width = ActualWidth - 125;
            }
        }

        //New Event for selection change
        public event EventHandler CmbSelectionChanged;
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CmbSelectionChanged(sender, e);
            }
            catch (Exception) { }
        }
    }
}
