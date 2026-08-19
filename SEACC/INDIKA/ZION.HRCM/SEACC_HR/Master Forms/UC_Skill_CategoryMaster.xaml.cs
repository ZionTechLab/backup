using System;
using System.Collections.Generic;
using System.Data;
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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_Skill_CategoryMaster.xaml
    /// </summary>
    public partial class UC_Skill_CategoryMaster : UserControl
    {
        public UC_Skill_CategoryMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Skill_Category;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            drg_Main.dt.Columns.Add("Skill_Catg_ID");
            drg_Main.dt.Columns.Add("Skill_Catg");
            #endregion

            #region Initialize DataGrid
            drg_Main.Add_DatagridColoumn("Code", "Skill_Catg_ID", 70);
            drg_Main.Add_DatagridColoumn("Skill Catg.", "Skill_Catg", 200); 
            #endregion

            ClearFields();
            MiniTest.setEmployeeDetail("000001");
        }

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
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSkillCatdID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSkillCatgname, true, false, false);

            txtSkillCatdID.Tag = null;
            txtSkillCatdID.Text = "";
            txtSkillCatgname.Text = "";

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtSkillCatdID.setReadOnlyStatus(true);
                txtSkillCatdID.Text = "<Auto Generate>";
            }
            else
                txtSkillCatdID.setReadOnlyStatus(false);
            #endregion
        } 
        #endregion
    }
}
