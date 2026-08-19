using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_VersionInfo : Form
    {
        public frm_VersionInfo()
        {
            InitializeComponent();
        }
        public frm_VersionInfo(DataTable dt)
        {
            InitializeComponent();
            seacC_DataGrid1.DataSource = dt;
        }

    }
}
