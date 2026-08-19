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
    public partial class frm_scsMetfor_Home : Form
    {
        #region Variables
        //to manage update and insert
       // static bool IsUpdate = false;
      //  static bool bIsWeightCalculation = false;

        //for security handle
        public bool bNoAccess;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        #endregion 

        public frm_scsMetfor_Home()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.Matfor);
            iFormID = clsSecurity.getFormID(FormName.Matfor);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void btnCusOrderEdit_Click(object sender, EventArgs e)
        {
            DisplayMatfor_Forecast();
        }

        private void btnDoManualSettle_Click(object sender, EventArgs e)
        {
            DisplayMatfor_DataEntry();
        }

        #region Display Form
        private void DisplayMatfor_DataEntry()
        {
            frm_scsMetfor_DataEntry frm = new frm_scsMetfor_DataEntry();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayMatfor_Forecast()
        {
            frm_scsMetfor_Forecast frm = new frm_scsMetfor_Forecast();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void DisplayMatfor()
        {
            frm_scsMetfor frm = new frm_scsMetfor();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
               MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        private void btnSubAgentPaymentAdvice_Click(object sender, EventArgs e)
        {
            DisplayMatfor();
        }
        #endregion

        private void frm_sasTools_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "MRP Home [Material Requirement Planning]", 4, iFormID);
        }

        
       
    }
}
