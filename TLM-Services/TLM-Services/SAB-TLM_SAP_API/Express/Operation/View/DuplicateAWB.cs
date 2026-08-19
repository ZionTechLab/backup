using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Operation.View
{
    public partial class DuplicateAWB : Form
    {
        public DuplicateAWB()
        {
            InitializeComponent();
        }
        public DuplicateAWB(List<OpsConsAWBDomainView> DuplicateList)
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = DuplicateList;

        }
        private void DuplicateAWB_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
