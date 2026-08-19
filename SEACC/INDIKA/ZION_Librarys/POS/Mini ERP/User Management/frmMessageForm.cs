using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frmMessageForm : Form
    {
        public string sHeader= "";
        public string sMessage = "";

        public frmMessageForm()
        {              
            InitializeComponent();
        }

        #region Form Load
        private void frmQuickLogin_Load(object sender, EventArgs e)
        {
            lblHeader.Text = sHeader;
            lblMessage.Text = sMessage;
        }
        #endregion

        #region Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {
                    
            this.Close();
        } 
        #endregion
        
    }
}
