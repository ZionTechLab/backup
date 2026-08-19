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
using DataTire;
using SEACC_WPFControls;
using System.Data;


namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_EmployeeIncedentalDiary.xaml
    /// </summary>
    public partial class UC_EmployeeIncedentalDiary : UserControl
    {
        #region Class Variable
        DataTable dt = new DataTable();
        #endregion

        #region Form Load
        public UC_EmployeeIncedentalDiary()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Employee_Incidental_Diary;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt.Columns.Add("Date");
            dt.Columns.Add("EmpNo");
            dt.Columns.Add("IncidentCategory");
            dt.Columns.Add("IncidentType");
            dt.Columns.Add("Description_HTD");
            dt.Columns.Add("Description_Mgt");
            #endregion

            #region Initialize Data Grid
            grd_Main.Add_DatagridColoumn("Date", "Date", 120);
            grd_Main.Add_DatagridColoumn("Emp No.", "EmpNo", 100);
            grd_Main.Add_DatagridColoumn("Incedent Category", "IncidentCategory", 120);
            grd_Main.Add_DatagridColoumn("Incedent Type", "IncidentType", 100);
            grd_Main.Add_DatagridColoumn("Description(HRD)", "Description_HTD", 200);
            grd_Main.Add_DatagridColoumn("Description(Mgt.)", "Description_Mgt", 200);
            #endregion

            ClearField();
        } 
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(700);
        }
        #endregion

        #region Clear Fields
        private void ClearField()
        {
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txt_IncedentID, true, false, false);
            //  clsCommon.SetEnableDisable_LabelDateSelector(dtpDate, true);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtEmpNo, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtInc_Catg, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtIncidentType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription_HRD, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription_Mgt, true, false, false);
            cls_Formater.SetEnableDisable_DatePicker(dtp_perpadDate, true);
            cls_Formater.SetEnableDisable_DatePicker(dtp_VerifiedDate, true);
            cls_Formater.SetEnableDisable_DatePicker(dtp_Approval, true);


            if (SEACC_Form.isAutoGenaratedCode)
            {
                txt_IncedentID.setReadOnlyStatus(true);
                txt_IncedentID.Text = "<Auto Generate>";
            }
            else
                txt_IncedentID.setReadOnlyStatus(false);
        } 
        #endregion
    }
}