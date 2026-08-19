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
    /// Interaction logic for SEACC_MenuButton.xaml
    /// </summary>
    public partial class SEACC_MenuButton : UserControl
    {
        public SEACC_MenuButton()
        {
            InitializeComponent();
        }

        public void set(string Text)
        {
            label1.Content = Text;
        }

        public void setRightText(string Text)
        {
            label2.Content = Text;
        }
    }
}
