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
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_CarderCount.xaml
    /// </summary>
    public partial class UC_CarderCount : UserControl
    {
        #region Form Load
        public UC_CarderCount()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Carder_Count;
            SEACC_Form.Initialize();
            #endregion

            ClearFields();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtDivisionID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDepartmentID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSectionID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShiftID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmpCount, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);
        } 
        #endregion
    }
}
