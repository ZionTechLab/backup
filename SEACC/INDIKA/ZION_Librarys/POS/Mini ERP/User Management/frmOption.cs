using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;


namespace Digiteq
{
    public partial class frmOption : Form
    {

        #region Variables
        
        //for security handle
        public bool bNoAccess;

        //form manage
        string sFormConfigCode;
           public int iFormID;
        
        //For Buttons
        public static bool bEMail = false;
        public static bool bSMS = false;
        public static bool bCancel = false;
        public static bool bPrint = false;
        public static bool bExport = false;

        #endregion 

        #region Form Loder
        public frmOption()
        {
            clsFormatter.setFormatForm(this, "Option ", 2, iFormID);
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.FinanceMaster);
            iFormID = clsSecurity.getFormID(FormName.FinanceMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();


        } 
        #endregion              

        #region Btn Email
        private void btnEmail_Click(object sender, EventArgs e)
        {
            ClearOtherBooleanValues();
            bEMail = true;
            Close();
        }
        #endregion

        #region Btn SMS
        private void btnSMS_Click(object sender, EventArgs e)
        {
            ClearOtherBooleanValues();
            bSMS = true;
            Close();
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearOtherBooleanValues();
            bCancel = true;
            Close();
        }  
        #endregion   

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClearOtherBooleanValues();
            bPrint = true;
            Close();
        }
        #endregion

        #region Btn Export
        private void btnExport_Click(object sender, EventArgs e)
        {
            ClearOtherBooleanValues();
            bExport = true;
            Close();
        }
        #endregion

        #region Clear Other Boolean Values
        private void ClearOtherBooleanValues()
        {
            bEMail = false;
            bSMS = false;
            bCancel = false;
            bPrint = false;
            bExport = false;

        }
        #endregion
        
    }
}
