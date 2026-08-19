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
    /// Interaction logic for SEACC_UserIndicator_Small.xaml
    /// </summary>
    public partial class SEACC_UserIndicator_Small : UserControl
    {
        public event EventHandler MouseClickOnUsername;

        public string User_ID = "";
        
        public SEACC_UserIndicator_Small()
        {
            InitializeComponent();
        }

        public static DependencyProperty SEACC_ErrorTextProperty = DependencyProperty.Register("ErrorText", typeof(string), typeof(SEACC_UserIndicator_Small));
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

        public  void Set(string _User_ID, string SUserName, BitmapImage image)
        {
            try
            {
                User_ID = _User_ID;
                UserName.Text = SUserName;
                UserImage.Source = image;
            }
            catch (Exception)
            {
            }
        }

        public  string  GetEmpID()
        {
            return User_ID;
        }

        public void Clear()
        {
            User_ID = "";
            UserName.Text = "";
            UserImage.Source = null;
        }

        private void UserName_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MouseClickOnUsername(sender, e);
            }
            catch { }
        }
    }
}