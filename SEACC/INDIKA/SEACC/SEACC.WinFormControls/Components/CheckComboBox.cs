using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SEACC.WinFormControls.Components
{

    public partial class CheckComboBox : UserControl
    {
        public delegate void SelectionChangedEventHandler(DataView value);

        public event SelectionChangedEventHandler SelectionChanged;

        DataGridViewCheckBoxColumn Checked;
        DataGridViewTextBoxColumn ValueMember;
        DataGridViewTextBoxColumn DisplayMember;

        CheckComboBox_List Drop = new CheckComboBox_List();
        public CheckComboBox()
        {
            InitializeComponent();

            Checked = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Checked",
                Name = "Checked",
                DataPropertyName = "IsChecked",
                ReadOnly = true,
                Width = 20,
            };
            ValueMember = new DataGridViewTextBoxColumn
            {
                HeaderText = "ValueMember",
                Name = "ValueMember",
                DataPropertyName = "ID",
                Visible = false,
                ReadOnly = true,
            };
            DisplayMember = new DataGridViewTextBoxColumn
            {
                HeaderText = "DisplayMember",
                Name = "DisplayMember",
                DataPropertyName = "Name",

                ReadOnly = true,
            };
            Drop._dgv1X4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Checked, ValueMember, DisplayMember });
            Drop.CheckedChanged += Drop_CheckedChanged;

        }

        private void Drop_CheckedChanged(bool value)
        {
            var json = JsonConvert.SerializeObject(Drop._dgv1X4.DataSource);
            DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            DataView dv = new DataView(dataTable);
            dv.RowFilter = "IsChecked=true";

            SelectionChanged(dv);
        }

        public void Check_Uncheck_All(bool value)
        {
            Drop.Check_Uncheck_All(value);
            Drop._SelectAll_Status = false;
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {

            var v = this.Parent.PointToScreen(this.Location);
            v.Y += 20;
            Drop.Width = this.Width;
            DisplayMember.Width = this.Width - 35;
            Drop.Show(); Drop.Location = v;
            Drop.Focus();

        }
        public string _DisplayMember
        {
            get { return DisplayMember.DataPropertyName; }
            set { DisplayMember.DataPropertyName = value; }
        }

        public string _ValueMember
        {
            get { return ValueMember.DataPropertyName; }
            set { ValueMember.DataPropertyName = value; }
        }
        public object DataSource
        {
            get { return Drop._dgv1X4.DataSource; }
            set { Drop._dgv1X4.DataSource = value; }
        }
        public string Text_
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
}
