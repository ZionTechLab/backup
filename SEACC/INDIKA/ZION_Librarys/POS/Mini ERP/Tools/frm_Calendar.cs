using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SEACC_WPFControls;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_Calendar : Form
    {
        private const int CS_DROPSHADOW = 0x20000;
        #region Initialize
        DateTime rDateTime = DateTime.Now;

        public frm_Calendar()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public DateTime Show()
        {
            try
            {
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
            }
            return rDateTime;
        }
        

        public DateTime dtDateValue
        {
            set { calDate.SetDate(value); }
        }

        #endregion

        #region Date Events
        private void calDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                rDateTime = e.End.Date;                
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                this.DialogResult = DialogResult.No;
            }
        }
        #endregion

        #region Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        } 
        #endregion
    }
}