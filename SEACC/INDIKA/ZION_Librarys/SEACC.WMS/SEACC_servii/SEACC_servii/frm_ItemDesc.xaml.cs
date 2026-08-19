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
using System.Windows.Shapes;

namespace SEACC_servii
{
    /// <summary>
    /// Interaction logic for frm_ItemDesc.xaml
    /// </summary>
    public partial class frm_ItemDesc : Window
    {
        public frm_ItemDesc()
        {
            InitializeComponent();
        }

        public frm_ItemDesc(string sDisc)
        {
            InitializeComponent();
            txtFillter.Text = sDisc;
          //  txtFillter.Focusable = true;
            // Keyboard.Focus(txtCompanyID);


            txtFillter.Focus();

            txtFillter.SelectionStart = txtFillter.Text.Length ;// add some logic if length is 0
            txtFillter.SelectionLength = 0;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
