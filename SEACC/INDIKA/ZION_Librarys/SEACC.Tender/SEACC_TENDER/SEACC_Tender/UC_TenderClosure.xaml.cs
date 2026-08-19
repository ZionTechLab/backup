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
using Digiteq_Logic;

namespace SEACC_Tender
{
    /// <summary>
    /// Interaction logic for UC_TenderClosure.xaml
    /// </summary>
    public partial class UC_TenderClosure : UserControl
    {
        public UC_TenderClosure()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = Digiteq_Logic.FormName.TenderClosure;
            SEACC_Form.Initialize();
            
        }

        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
