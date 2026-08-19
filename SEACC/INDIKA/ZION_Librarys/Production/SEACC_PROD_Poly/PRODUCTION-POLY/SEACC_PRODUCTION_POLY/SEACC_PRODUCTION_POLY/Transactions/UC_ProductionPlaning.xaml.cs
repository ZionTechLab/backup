using Digiteq_Logic;
using GANTT_CHART.GanttChart;
using GANTT_CHART.PeriodSplitter;
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

namespace SEACC_PRODUCTION_POLY
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


            GantLenght = 50;
            dtpPlanDate.SelectedDate = DateTime.Parse("2012-02-01");
            DateTime minDate = dtpPlanDate.SelectedDate.Value;
            DateTime maxDate = minDate.AddDays(GantLenght);

            // Set selection -mode
            gc_productionSchedular.TaskSelectionMode = GANTT_CHART.GanttControl.SelectionMode.Single;
            // Enable GanttTasks to be selected
            gc_productionSchedular.AllowUserSelection = true;

            // listen to the GanttRowAreaSelected event
            gc_productionSchedular.GanttRowAreaSelected += new EventHandler<PeriodEventArgs>(ganttControl1_GanttRowAreaSelected);

            // define ganttTask context menu and action when each item is clicked
            ganttTaskContextMenuItems.Add(new ContextMenuItem(ViewClicked, "View..."));
            ganttTaskContextMenuItems.Add(new ContextMenuItem(EditClicked, "Edit..."));
            ganttTaskContextMenuItems.Add(new ContextMenuItem(DeleteClicked, "Delete..."));
            gc_productionSchedular.GanttTaskContextMenuItems = ganttTaskContextMenuItems;

            // define selection context menu and action when each item is clicked
            selectionContextMenuItems.Add(new SelectionContextMenuItem(NewClicked, "New..."));
            gc_productionSchedular.SelectionContextMenuItems = selectionContextMenuItems;

            ClearFields();
        }

        private void NewClicked(Period selectionPeriod)
        {
            MessageBox.Show("New clicked for task " + selectionPeriod.Start.ToString() + " -> " + selectionPeriod.End.ToString());
        }

        private void ViewClicked(GanttTask ganttTask)
        {
            MessageBox.Show("New clicked for task " + ganttTask.Name);
        }

        private void EditClicked(GanttTask ganttTask)
        {
            MessageBox.Show("Edit clicked for task " + ganttTask.Name);
        }

        private void DeleteClicked(GanttTask ganttTask)
        {
            MessageBox.Show("Delete clicked for task " + ganttTask.Name);
        }

        void ganttControl1_GanttRowAreaSelected(object sender, PeriodEventArgs e)
        {
            MessageBox.Show(e.SelectionStart.ToString() + " -> " + e.SelectionEnd.ToString());
        }

        private System.Windows.Media.Brush DetermineBackground(TimeLineItem timeLineItem)
        {
            if (timeLineItem.End.Date.DayOfWeek == DayOfWeek.Saturday || timeLineItem.End.Date.DayOfWeek == DayOfWeek.Sunday)
                return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightBlue);
            else
                return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent);
        }

        private void CreateData(DateTime minDate, DateTime maxDate)
        {
            // Set max and min dates
            gc_productionSchedular.Initialize(minDate, maxDate);

            // Create timelines and define how they should be presented
            gc_productionSchedular.CreateTimeLine(new PeriodYearSplitter(minDate, maxDate), FormatYear);
            gc_productionSchedular.CreateTimeLine(new PeriodMonthSplitter(minDate, maxDate), FormatMonth);
            var gridLineTimeLine = gc_productionSchedular.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), FormatDay);
            gc_productionSchedular.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), FormatDayName);

            // Set the timeline to atatch gridlines to
            gc_productionSchedular.SetGridLinesTimeline(gridLineTimeLine, DetermineBackground);

            // Create and data
            var rowgroup1 = gc_productionSchedular.CreateGanttRowGroup("Production Job 01");
            var row1 = gc_productionSchedular.CreateGanttRow(rowgroup1, "GanttRow 1");
            gc_productionSchedular.AddGanttTask(row1, new GanttTask() { Start = DateTime.Parse("2012-02-01"), End = DateTime.Parse("2012-03-01"), Name = "GanttRow 1:GanttTask 1", TaskProgressVisibility = System.Windows.Visibility.Hidden });
            gc_productionSchedular.AddGanttTask(row1, new GanttTask() { Start = DateTime.Parse("2012-03-05"), End = DateTime.Parse("2012-05-01"), Name = "GanttRow 1:GanttTask 2" });
            gc_productionSchedular.AddGanttTask(row1, new GanttTask() { Start = DateTime.Parse("2012-06-01"), End = DateTime.Parse("2012-06-15"), Name = "GanttRow 1:GanttTask 3" });

            var rowgroup2 = gc_productionSchedular.CreateGanttRowGroup("Production Job 02", true);
            var row2 = gc_productionSchedular.CreateGanttRow(rowgroup2, "GanttRow 2");
            var row3 = gc_productionSchedular.CreateGanttRow(rowgroup2, "GanttRow 3");
            gc_productionSchedular.AddGanttTask(row2, new GanttTask() { Start = DateTime.Parse("2012-02-10"), End = DateTime.Parse("2012-03-10"), Name = "GanttRow 2:GanttTask 1" });
            gc_productionSchedular.AddGanttTask(row2, new GanttTask() { Start = DateTime.Parse("2012-03-25"), End = DateTime.Parse("2012-05-10"), Name = "GanttRow 2:GanttTask 2" });
            gc_productionSchedular.AddGanttTask(row2, new GanttTask() { Start = DateTime.Parse("2012-06-10"), End = DateTime.Parse("2012-09-15"), Name = "GanttRow 2:GanttTask 3", PercentageCompleted = 0.375 });
            gc_productionSchedular.AddGanttTask(row3, new GanttTask() { Start = DateTime.Parse("2012-01-07"), End = DateTime.Parse("2012-09-15"), Name = "GanttRow 3:GanttTask 1", PercentageCompleted = 0.5 });

            var rowgroup3 = gc_productionSchedular.CreateGanttRowGroup();
            var row4 = gc_productionSchedular.CreateGanttRow(rowgroup3, "GanttRow 4");
            gc_productionSchedular.AddGanttTask(row4, new GanttTask() { Start = DateTime.Parse("2012-02-14"), End = DateTime.Parse("2012-02-27"), Name = "GanttRow 4:GanttTask 1", PercentageCompleted = 1 });
            gc_productionSchedular.AddGanttTask(row4, new GanttTask() { Start = DateTime.Parse("2012-04-8"), End = DateTime.Parse("2012-09-19"), Name = "GanttRow 4:GanttTask 2" });
        }

        private string FormatYear(Period period)
        {
            return period.Start.Year.ToString();
        }

        private string FormatMonth(Period period)
        {
            return period.Start.Month.ToString();
        }

        private string FormatDay(Period period)
        {
            return period.Start.Day.ToString();
        }

        private string FormatDayName(Period period)
        {
            return period.Start.DayOfWeek.ToString();
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
            cls_Formater.SetEnableDisable_LableTextbox(txtFG_Qty, true, true, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_UoM2, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtFG_Qty2, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

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

        private void dtpPlanDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime minDate = dtpPlanDate.SelectedDate.Value.Date;
            DateTime maxDate = minDate.AddDays(GantLenght);
            gc_productionSchedular.ClearGantt();
            CreateData(minDate, maxDate);
        }
    }
}
