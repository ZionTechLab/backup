using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Data;

namespace SEACC_WPFControls
{
    public class SEACC_Button : Button
    {
        public SEACC_Button()
        {
            Style style = this.FindResource("iButton") as Style;
            Style = style;
        }
    }

    public class DataGrid_CheckBox : CheckBox
    {
        public DataGrid_CheckBox()
        {
            Style style = this.FindResource("DataGrid_CheckBoxStyle") as Style;
            Style = style;
        }
    }

    public class SEACC_ScrollViewer : ScrollViewer
    {
        public SEACC_ScrollViewer()
        {
            Style style = this.FindResource("SEACC_ScrollViewer_Style") as Style;
            Style = style;
        }
    }

    public class SEACC_Button_Close : Button
    {
        public SEACC_Button_Close()
        {
            Style style = this.FindResource("iButton_Close") as Style;
            Style = style;
        }
    }

    public class SEACC_DataGridTextColumn : DataGridTextColumn
    {
        ToolTip toolTip = new ToolTip();
        public static DependencyProperty ToolTip_Text_Property = DependencyProperty.Register("ToolTip_Text", typeof(string), typeof(SEACC_DataGridTextColumn));
        public string ToolTip_Text
        {
            get
            {
                return (string)GetValue(ToolTip_Text_Property);
            }
            set
            {
                SetValue(ToolTip_Text_Property, value);
            }
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement element = base.GenerateElement(cell, dataItem);
            ToolTip toolTip = new ToolTip();
            toolTip.Content = ToolTip_Text;
            toolTip.DataContext = element;
            ToolTipService.SetToolTip(element, toolTip);
            return element;
        }
    }

    public class SEACC_CheckBox : CheckBox
    {
        public SEACC_CheckBox()
        {
            Style style = this.FindResource("CheckBoxStyle1") as Style;
            Style = style;
        }
    }

    public class SEACC_Window : Window
    {
        public SEACC_Window()
        {
            Style style = this.FindResource("WindowStyle3") as Style;
            Style = style;
        }
        private void PART_CLOSE_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window h = (Window)sender;
            h.Close();
        }
    }

    public static class About_US
    {
        public static void Show()
        {
            frm_AboutUS frm = new frm_AboutUS();
            frm.ShowDialog();
        }
    }

    public static class Help
    {
        public static void Show()
        {
            frm_Help frm = new frm_Help();
            frm.ShowDialog();
        }
    }
}