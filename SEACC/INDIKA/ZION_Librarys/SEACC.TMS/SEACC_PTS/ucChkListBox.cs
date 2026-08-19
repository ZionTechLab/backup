using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    public partial class ucChkListBox : UserControl
    {
        #region Variables
        public delegate void CheckedHandler(string Quary);
        public event CheckedHandler aStatusChnged;

        int itemCount = 0;
        int hight = 0;
        bool bIsExpanded = false;
        string sFieldName = "";
        bool isSelectionActive = false;
        #endregion

        #region Properties
        public string FieldName
        {
            get
            {
                return sFieldName;
            }
            set
            {
                sFieldName = value;
            }
        }
        public string DisplayName
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        } 
        #endregion 
        

        #region Form Intial
        public ucChkListBox()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(this.Width, 26);
        } 
        #endregion

        #region Add Item
        public void AddItem(int Index, string Name, bool CheckedStatus)
        {
            CheckBox chk = new CheckBox();
            chk.Tag = Index;
            chk.Text = Name;
            chk.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular);
            chk.BackColor = Color.White;
            chk.ForeColor = Color.FromArgb(44, 62, 80);
            chk.Checked = CheckedStatus;
            chk.Margin = new Padding(3, 1, 0, 0);
            chk.Size = new Size(80, 15);
            flowLayoutPanel1.Controls.Add(chk);
            itemCount++;
            chk.CheckedChanged += chk_CheckedChanged;
        } 
        #endregion

        #region Check Changed
        void chk_CheckedChanged(object sender, EventArgs e)
        {
            string s = GetFilterScript();
            if (s != "")
                aStatusChnged(s);
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                foreach (CheckBox X in flowLayoutPanel1.Controls)
                {
                    X.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox X in flowLayoutPanel1.Controls)
                {
                    X.Checked = false;
                }
            }
        } 
        #endregion

        #region Filter
        public string GetFilterScript()
        {
            int i = 0;
            string s = "";
            foreach (CheckBox X in flowLayoutPanel1.Controls)
            {
                if (X.Checked)
                    s += (s != "" ? "," : "") + X.Tag.ToString();
                else
                    isSelectionActive = true;

                i++;
            }
            return s == "" ? "" : this.FieldName + " in(" + s + ")";
        } 
        #endregion

        #region Click Event
        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (bIsExpanded)
            {
                bIsExpanded = false;
                this.Size = new System.Drawing.Size(this.Width, 26);
            }
            else
            {
                bIsExpanded = true;
                hight = itemCount > 20 ? (16 * 20) + 50 : (16 * itemCount) + 50;
                this.Size = new System.Drawing.Size(this.Width, hight);

                if (itemCount > 20)
                    flowLayoutPanel1.AutoScroll = true;
            }
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            btnExpand_Click(null, null);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            btnExpand_Click(null, null);
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            btnExpand_Click(null, null);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            btnExpand_Click(null, null);
        }
        #endregion

        #region Leave Events
        private void flowLayoutPanel1_Leave(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(this.Width, 26);
        }
        private void ucChkListBox_Leave(object sender, EventArgs e)
        {
            flowLayoutPanel1_Leave(null, null);
        }
        private void ucChkListBox_MouseLeave(object sender, EventArgs e)
        {
            flowLayoutPanel1_Leave(null, null);
        }
        #endregion

        
    }
}
