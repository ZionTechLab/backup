using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_LOGIN
{
    public partial class SEACC_Exception : Form
    {
        string sStackTrace = "";
        #region Form Load
        public SEACC_Exception()
        {
            InitializeComponent();
        }
        public SEACC_Exception(System.Exception ex)
        {
            InitializeComponent();

            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);

            lblLineNo.Text = trace.GetFrame(0).GetFileLineNumber().ToString();
            lblMethod.Text = trace.GetFrame(0).GetMethod().ToString();
            try
            {
                lblFile.Text = trace.GetFrame(0).GetFileName().ToString();
            }
            catch (Exception)
            {

            }
            lblMessage.Text = ex.Message;
            sStackTrace = ex.StackTrace;
        } 
        #endregion

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region Button More
        private void btnMore_Click(object sender, EventArgs e)
        {
            if (this.Height == 120)
            {
                tableLayoutPanel1.Height = lblLineNo.Height + lblMethod.Height + lblFile.Height + lblMessage.Height + 16;
                this.Height = 120 + tableLayoutPanel1.Height;
                btn_StackTrace.Visible = true;
            }
            else
            {
                this.Height = 120;
                btn_StackTrace.Visible = false;
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_StackTrace_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sStackTrace);
        }
    }

    #region Class Exception
    public static class SEACCException
    {
        public static DialogResult Show(Exception ex)
        {
            SEACC_Exception oError = new SEACC_Exception(ex);
            oError.ShowDialog();
            return oError.DialogResult;
        }
    }
    #endregion
}