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

namespace Digiteq
{
    public partial class UC_UserIndicator : UserControl
    {
        public UC_UserIndicator()
        {
            InitializeComponent();
        }

        public static DependencyProperty UserName_Property = DependencyProperty.Register("UserName", typeof(string), typeof(UC_UserIndicator));
        public string UserName
        {
            get
            {
                return (string)GetValue(UserName_Property);
            }
            set
            {
                SetValue(UserName_Property, value);
            }
        }

        public static DependencyProperty Designation_Property = DependencyProperty.Register("Designation", typeof(string), typeof(UC_UserIndicator));
        public string Designation
        {
            get
            {
                return (string)GetValue(Designation_Property);
            }
            set
            {
                SetValue(Designation_Property, value);
            }
        }

        public static DependencyProperty Image_Property = DependencyProperty.Register("UserImage", typeof(Image), typeof(UC_UserIndicator));
        public Image UserImage
        {
            get
            {
                return (Image)GetValue(Image_Property);
            }
            set
            {
                SetValue(Image_Property, value);
            }
        }

        //private void userControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    var location = this.PointToScreen(new Point(0, 0));

        //    base.OnMouseDown(e);
        //    Point p = e.GetPosition(this);
        // //   frm_UserMenu fUser = new frm_UserMenu();

        //   // fUser.Left = location.X - 5;
        //  //  fUser.Top = location.Y + this.Height;

        //  //  fUser.Show();
        //  //  fUser.Activate();
        //}

        public void SetUser(string UserNane, string Designation, BitmapImage UserImage, bool dockPanel)
        {
            TxtUserName.Text = UserNane;
            TxtDesignation.Text = Designation;
            PbxUser.Source = UserImage;
            if (dockPanel)
            {
                //frm_UserMenu fUser = new frm_UserMenu();
              //  fUser.Hide();

            }
        }
    }
}