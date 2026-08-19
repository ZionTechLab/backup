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
    public partial class frm_scsMetfor : Form
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

        public frm_scsMetfor()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.Matfor);
            iFormID = clsSecurity.getFormID(FormName.Matfor);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_scsMetfor_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format  
            clsFormatter.setFormatForm(this, "MRP - [Material Requirement Planning]", 4, iFormID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
