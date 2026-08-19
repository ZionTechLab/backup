using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;


namespace Digiteq
{
    public partial class mtrJobMarkupPrecentage : Form
    {

        #region Variables
        //to manage update and insert

        //to keep form detail       
           public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public mtrJobMarkupPrecentage()
        {
            iFormID = clsSecurity.getFormID(FormName.JobMarckupPrecentage);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void mtrJobMarkupPrecentage_Load(object sender, EventArgs e)
        {
            Filldetail();
        }
        #endregion

        #region Fill detail
        public void Filldetail()
        {
            //tbl_securityConfigValue JobMdetail = tbl_securityConfigValue.Select((int)JobPercentage.JobMarckup);
            //if (JobMdetail != null)
            //{
            //    txtMarckUp.Text = JobMdetail.ConfigValue;
            //}
            //tbl_securityConfigValue JobGdetail = tbl_securityConfigValue.Select((int)JobPercentage.JobGenaralOverhead);
            //if (JobGdetail != null)
            //{
            //    txtJobGenaralOverhead.Text = JobGdetail.ConfigValue;
            //}
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bsave = false;

          //  tbl_securityConfigValue JobMdetail = tbl_securityConfigValue.Select((int)JobPercentage.JobMarckup);
         //   if (JobMdetail != null)
          //  {
            //    tbl_securityConfigValue detail = new tbl_securityConfigValue((int)JobPercentage.JobMarckup, "Job Marc kup", txtMarckUp.Text.Trim(), "default",0);
              //  detail.Update();
             //   bsave = true;
         //   }
         //   tbl_securityConfigValue JobGdetail = tbl_securityConfigValue.Select((int)JobPercentage.JobGenaralOverhead);
         //   if (JobGdetail != null)
          //  {
             //   tbl_securityConfigValue detail = new tbl_securityConfigValue((int)JobPercentage.JobGenaralOverhead, "Job Genaral Over head", txtJobGenaralOverhead.Text.Trim(), "default", JobGdetail.Form_ID);
            //    detail.Update();
             //   bsave = true;
          //  }
            if (bsave)
            {
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Filldetail();
            }
        } 
        #endregion

        #region Key Press
        private void txtMarckUp_KeyPress(object sender, KeyPressEventArgs e)
        {
              clsValidate.AllowDecimalWithLength((TextBox)sender, e, 2, 0);
        }
        private void txtJobGenaralOverhead_KeyPress(object sender, KeyPressEventArgs e)
        {
              clsValidate.AllowDecimalWithLength((TextBox)sender, e, 2, 0);
        }
        #endregion
    }
}
