using Digiteq_Logic;
using nGantt.GanttChart;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SEACC_PRODUCTION
{
    /// <summary>
    /// Interaction logic for UC_ProductionPlaning.xaml
    /// </summary>
    public partial class UC_ProductionPlaning : UserControl
    {
        private int GantLenght { get; set; }
        private ObservableCollection<ContextMenuItem> ganttTaskContextMenuItems = new ObservableCollection<ContextMenuItem>();
        private ObservableCollection<SelectionContextMenuItem> selectionContextMenuItems = new ObservableCollection<SelectionContextMenuItem>();

        public UC_ProductionPlaning()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_ProductonPlaning;
            SEACC_Form.Initialize();


            //GantLenght = 50;
            //dtpPlanDate.SelectedDate = DateTime.Parse("2012-02-01");
            //DateTime minDate = dtpPlanDate.SelectedDate.Value;
            //DateTime maxDate = minDate.AddDays(GantLenght);

            //// Set selection -mode
            //gc_productionSchedular.TaskSelectionMode = nGantt.GanttControl.SelectionMode.Single;
            //// Enable GanttTasks to be selected
            //gc_productionSchedular.AllowUserSelection = true;

            //// listen to the GanttRowAreaSelected event
            //gc_productionSchedular.GanttRowAreaSelected += new EventHandler<PeriodEventArgs>(ganttControl1_GanttRowAreaSelected);

            //// define ganttTask context menu and action when each item is clicked
            //ganttTaskContextMenuItems.Add(new ContextMenuItem(ViewClicked, "View..."));
            //ganttTaskContextMenuItems.Add(new ContextMenuItem(EditClicked, "Edit..."));
            //ganttTaskContextMenuItems.Add(new ContextMenuItem(DeleteClicked, "Delete..."));
            //gc_productionSchedular.GanttTaskContextMenuItems = ganttTaskContextMenuItems;

            //// define selection context menu and action when each item is clicked
            //selectionContextMenuItems.Add(new SelectionContextMenuItem(NewClicked, "New..."));
            //gc_productionSchedular.SelectionContextMenuItems = selectionContextMenuItems;

            ClearFields();
        }

        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPlan_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtJobType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Item, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_SalesCode, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_SalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Brand, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_GrnericName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_UoM, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Qty, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRemark, true, false, true);

            txtPlan_ID.Tag = null;
            txtFG_Item.Tag = null;
            txtFG_UoM.Tag = null;

            txtPlan_ID.Text = "";
            txtJobType.Text = "";
            txtFG_Item.Text = "";
            txtFG_SalesCode.Text = "";
            txtFG_SalesName.Text = "";
            txtFG_Brand.Text = "";
            txtFG_GrnericName.Text = "";
            txtFG_UoM.Text = "";
            txtFG_Qty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtRemark.Text = "";

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtPlan_ID.setReadOnlyStatus(true);
                txtPlan_ID.Text = "<Auto Generate>";
            }
            else
                txtPlan_ID.setReadOnlyStatus(false);
            #endregion

        }


        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
