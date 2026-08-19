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
    public partial class frm_masEmployeeMaster : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;
        //for security handle
        public bool bNoAccess;
        string sFormConfigCode;
        #endregion

        #region Form Load
        public frm_masEmployeeMaster()
        {
            iFormID = clsSecurity.getFormID(FormName.EmployeeMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_masCompanyMaster_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorMasters;
        }
        #endregion
        



        #region Btn Sales Manager
        private void btnSalesManager_Click(object sender, EventArgs e)
        {
            //frm_mtrEmpSalesManager detail = new frm_mtrEmpSalesManager();
            //detail.ShowDialog();
            frm_mtrEmpSalesManager frm = new frm_mtrEmpSalesManager();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        } 
        #endregion

        #region Btn Area Manager
        private void btnAreaManager_Click(object sender, EventArgs e)
        {
            //frm_mtrEmpAreaManager detail = new frm_mtrEmpAreaManager();
            //detail.ShowDialog();
            frm_mtrEmpAreaManager frm = new frm_mtrEmpAreaManager();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        } 
        #endregion

        #region Btn  Sales Executivecs
        private void btnSalesExecutivecs_Click(object sender, EventArgs e)
        {
            //frm_mtrEmpSalesExecutivecs detail = new frm_mtrEmpSalesExecutivecs();
            //detail.ShowDialog();
            frm_mtrEmpSalesExecutivecs frm = new frm_mtrEmpSalesExecutivecs();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        } 
        #endregion

        #region Btn Salese Rep
        private void btnSaleseRep_Click(object sender, EventArgs e)
        {
            //frm_mtrEmpSaleseRep detail = new frm_mtrEmpSaleseRep();
            //detail.ShowDialog();
            frm_mtrEmpSaleseRep frm = new frm_mtrEmpSaleseRep();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        } 
        #endregion




        #region Btn Driver
        private void btnDriver_Click(object sender, EventArgs e)
        {
            //frm_mtrDriver detail = new frm_mtrDriver();
            //detail.ShowDialog();
            frm_mtrDriver frm = new frm_mtrDriver();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion




        #region Btn Supervisor
        private void btnSupervisor_Click(object sender, EventArgs e)
        {
            //frm_mtrEmpSupervisor detail = new frm_mtrEmpSupervisor();
            //detail.ShowDialog();
            frm_mtrEmpSupervisor frm = new frm_mtrEmpSupervisor();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }
        #endregion

        #region Btn Operator
        private void btnOperator_Click(object sender, EventArgs e)
        {
            //frm_mtrEmpOperator detail = new frm_mtrEmpOperator ();
            //detail.ShowDialog();
            frm_mtrEmpOperator frm = new frm_mtrEmpOperator();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        } 
        #endregion

        #region Btn Assistan
        private void btnAssistan_Click(object sender, EventArgs e)
        {
            //frm_mtrEmpAssistan detail = new frm_mtrEmpAssistan();
            //detail.ShowDialog();
            frm_mtrEmpAssistan frm = new frm_mtrEmpAssistan();
            frm.MdiParent = this.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        } 
        #endregion

    }
}
