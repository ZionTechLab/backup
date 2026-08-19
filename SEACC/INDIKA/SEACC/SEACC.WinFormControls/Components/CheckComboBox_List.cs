using Newtonsoft.Json;
using SEACC.WinFormControls.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC.WinFormControls.Components
{
    public partial class CheckComboBox_List : Form
    {
        public System.Windows.Forms.DataGridView _dgv1X4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        public delegate void SelectionChangedEventHandler(bool value);

        public event SelectionChangedEventHandler CheckedChanged;
        public CheckComboBox_List()
        {
            InitializeComponent();

            _dgv1X4.AutoGenerateColumns = false;
        }

        private void InitializeComponent()
        {
            this._dgv1X4 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgv1X4)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgv1X4
            // 
            this._dgv1X4.AllowUserToAddRows = false;
            this._dgv1X4.AllowUserToResizeColumns = false;
            this._dgv1X4.AllowUserToResizeRows = false;
            this._dgv1X4.BackgroundColor = System.Drawing.Color.White;
            this._dgv1X4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this._dgv1X4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgv1X4.ColumnHeadersVisible = false;
            this._dgv1X4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgv1X4.Location = new System.Drawing.Point(0, 27);
            this._dgv1X4.MultiSelect = false;
            this._dgv1X4.Name = "_dgv1X4";
            this._dgv1X4.RowHeadersVisible = false;
            this._dgv1X4.RowTemplate.Height = 18;
            this._dgv1X4.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._dgv1X4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv1X4.Size = new System.Drawing.Size(284, 234);
            this._dgv1X4.TabIndex = 5;
            this._dgv1X4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgv1X4_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 27);
            this.panel1.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // CheckComboBox_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._dgv1X4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckComboBox_List";
            this.ShowInTaskbar = false;
            this.Text = "CheckComboBox_List";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.CheckComboBox_List_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this._dgv1X4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        public bool _SelectAll_Status
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        private void CheckComboBox_List_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void _dgv1X4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)//select
            {
                var status = DataGridValidate.GetBoolValue(_dgv1X4.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                _dgv1X4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !status;
                CheckedChanged(true);
            }
        }
        public void Check_Uncheck_All(bool value)
        {
            if (_dgv1X4.DataSource != null)
            {
                var json = JsonConvert.SerializeObject(_dgv1X4.DataSource);
                DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                if (dataTable.Rows.Count > 0)
                {
                    DataColumn dc = new DataColumn("IsChecked");
                    dc.DataType = typeof(Boolean);
                    dc.DefaultValue = value;

                    if (   dataTable.Columns.Contains("IsChecked"))
                    dataTable.Columns.Remove("IsChecked");

                    dataTable.Columns.Add(dc);
                    _dgv1X4.DataSource = dataTable;

                    DataView dv = new DataView(dataTable);
                    dv.RowFilter = "IsChecked=true";

                    CheckedChanged(true);
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Check_Uncheck_All(checkBox1.Checked);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}
