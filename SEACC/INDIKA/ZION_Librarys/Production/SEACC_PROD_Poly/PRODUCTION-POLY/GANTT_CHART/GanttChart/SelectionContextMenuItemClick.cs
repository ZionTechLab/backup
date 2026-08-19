using System.Windows.Input;
using GANTT_CHART.PeriodSplitter;

namespace GANTT_CHART.GanttChart
{
    public delegate void SelectionContextMenuItemClick(Period selectedPeriod);

    public class SelectionContextMenuItem
    {
        public SelectionContextMenuItem(SelectionContextMenuItemClick contextMenuItemClick, string name)
        {
            ContextMenuItemClickCommand = new DelegateCommand<Period>(x => contextMenuItemClick(x));
            this.Name = name;
        }

        public string Name { get; set; }

        public ICommand ContextMenuItemClickCommand { get; private set; }
    }
}
