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

namespace SEACC_POS
{
    /// <summary>
    /// Interaction logic for Pos_DataGridLine.xaml
    /// </summary>
    public partial class Pos_DataGridLine : UserControl
    {
        #region Propertis column Width
        public static DependencyProperty Width_GridColumn0_pro = DependencyProperty.Register("Width_GridColumn0", typeof(double), typeof(Pos_DataGridLine));
        public double Width_GridColumn0
        {
            get
            {
                return (double)GetValue(Width_GridColumn0_pro);
            }
            set
            {
                SetValue(Width_GridColumn0_pro, value);
            }
        }

        public static DependencyProperty Width_GridColumn1_pro = DependencyProperty.Register("Width_GridColumn1", typeof(double), typeof(Pos_DataGridLine));
        public double Width_GridColumn1
        {
            get
            {
                return (double)GetValue(Width_GridColumn1_pro);
            }
            set
            {
                SetValue(Width_GridColumn1_pro, value);
            }
        }

        public static DependencyProperty Width_GridColumn2_pro = DependencyProperty.Register("Width_GridColumn2", typeof(double), typeof(Pos_DataGridLine));
        public double Width_GridColumn2
        {
            get
            {
                return (double)GetValue(Width_GridColumn2_pro);
            }
            set
            {
                SetValue(Width_GridColumn2_pro, value);
            }
        }

        public static DependencyProperty Width_GridColumn3_pro = DependencyProperty.Register("Width_GridColumn3", typeof(double), typeof(Pos_DataGridLine));
        public double Width_GridColumn3
        {
            get
            {
                return (double)GetValue(Width_GridColumn3_pro);
            }
            set
            {
                SetValue(Width_GridColumn3_pro, value);
            }
        }

        public static DependencyProperty Width_GridColumn4_pro = DependencyProperty.Register("Width_GridColumn4", typeof(double), typeof(Pos_DataGridLine));
        public double Width_GridColumn4
        {
            get
            {
                return (double)GetValue(Width_GridColumn4_pro);
            }
            set
            {
                SetValue(Width_GridColumn4_pro, value);
            }
        }

        public static DependencyProperty Width_GridColumn5_pro = DependencyProperty.Register("Width_GridColumn5", typeof(double), typeof(Pos_DataGridLine));
        public double Width_GridColumn5
        {
            get
            {
                return (double)GetValue(Width_GridColumn5_pro);
            }
            set
            {
                SetValue(Width_GridColumn5_pro, value);
            }
        } 
        #endregion

        #region Propertis dgl
        public static DependencyProperty ItemCode_pro = DependencyProperty.Register("ItemCode", typeof(string), typeof(Pos_DataGridLine));
        public string ItemCode
        {
            get
            {
                return (string)GetValue(ItemCode_pro);
            }
            set
            {
                SetValue(ItemCode_pro, value);
            }
        }

        public static DependencyProperty ItemName_pro = DependencyProperty.Register("ItemName", typeof(string), typeof(Pos_DataGridLine));
        public string ItemName
        {
            get
            {
                return (string)GetValue(ItemName_pro);
            }
            set
            {
                SetValue(ItemName_pro, value);
            }
        }

        public static DependencyProperty UOM_pro = DependencyProperty.Register("UOM", typeof(string), typeof(Pos_DataGridLine));
        public string UOM
        {
            get
            {
                return (string)GetValue(UOM_pro);
            }
            set
            {
                SetValue(UOM_pro, value);
            }
        }

        public static DependencyProperty QTY_pro = DependencyProperty.Register("QTY", typeof(string), typeof(Pos_DataGridLine));
        public string QTY
        {
            get
            {
                return (string)GetValue(QTY_pro);
            }
            set
            {
                SetValue(QTY_pro, value);
            }
        }

        public static DependencyProperty UnitPrice_pro = DependencyProperty.Register("UnitPrice", typeof(decimal), typeof(Pos_DataGridLine));
        public decimal UnitPrice
        {
            get
            {
                return (decimal)GetValue(UnitPrice_pro);
            }
            set
            {
                SetValue(UnitPrice_pro, value);
            }
        }

        public static DependencyProperty Amount_pro = DependencyProperty.Register("Amount", typeof(decimal), typeof(Pos_DataGridLine));
        public decimal Amount
        {
            get
            {
                return (decimal)GetValue(Amount_pro);
            }
            set
            {
                SetValue(Amount_pro, value);
            }
        } 
        #endregion

        public Pos_DataGridLine()
        {
            InitializeComponent();
            this.Height = 40; 
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("get");
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txt_ItemCode.IsFocused && !txt_Desc.IsFocused && !txt_UOM.IsFocused && !txt_QTY.IsFocused && !txt_UnitPrice.IsFocused && !txt_Amount.IsFocused)
                this.Height = 40; 
            else
                this.Height = 80; 
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt_ItemCode.Focus();
            this.Height = 80;
        }

        private void GridCell_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txt_ItemCode.IsFocused && !txt_Desc.IsFocused && !txt_UOM.IsFocused && !txt_QTY.IsFocused && !txt_UnitPrice.IsFocused && !txt_Amount.IsFocused)
                this.Height = 40;
            else
                this.Height = 80; 
        }
    }
}
