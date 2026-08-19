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
    /// <summary>
    /// Interaction logic for UC_UserIndicator.xaml
    /// </summary>
    public partial class UC_UserIndicator : UserControl
    {
        public UC_UserIndicator()
        {
            InitializeComponent();
        }

        private void userControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var location = this.PointToScreen(new Point(0, 0));

            base.OnMouseDown(e);
            Point p = e.GetPosition(this);
            frm_UserMenu fUser = new frm_UserMenu();

            fUser.Left = location.X - 5;
            fUser.Top = location.Y + this.Height;

            fUser.Show();
            fUser.Activate();
        }

        public void SetUser(string UserNane, string Designation, BitmapImage UserImage, bool dockPanel)
        {
            TxtUserName.Text = UserNane;
            TxtDesignation.Text = Designation;
            PbxUser.Source = UserImage;
            if (dockPanel)
            {
                frm_UserMenu fUser = new frm_UserMenu();
                fUser.Hide();

            }
        }
    }
}