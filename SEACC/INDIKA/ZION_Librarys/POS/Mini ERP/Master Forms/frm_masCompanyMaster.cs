using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq.Master_Forms.ZMaster;

namespace Digiteq
{
    public partial class frm_masCompanyMaster : MettroForm
    {
        #region Variables
        //form manage
        public int iFormID;
        //for security handle
        public bool bNoAccess;
        string sFormConfigCode;
        #endregion

        #region Form Load
        public frm_masCompanyMaster()
        {
            iFormID = clsSecurity.getFormID(FormName.CompanyMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        } 
        private void frm_masCompanyMaster_Load(object sender, EventArgs e)
        {
            bookTree.Nodes.Clear();
            populateTree();

            btnExpandAll_Click(sender, e);
        } 
        #endregion

        #region Btn Country Master
        private void btnCountry_Click(object sender, EventArgs e)
        {
            frm_mtrCompanyCountryMaster detail = new frm_mtrCompanyCountryMaster();
            detail.ShowDialog();
        } 
        #endregion

        #region Btn Branch Master
        private void btnBranch_Click(object sender, EventArgs e)
        {
            frm_mtrCompanyBranch frm = new frm_mtrCompanyBranch(FormName.CompanyBranchMaster);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorMasters, this.MdiParent);
        } 
        #endregion

        #region Btn Division Master
        private void btnDivision_Click(object sender, EventArgs e)
        {
            frm_mtrCompanyDivision detail = new frm_mtrCompanyDivision();
            detail.ShowDialog();
        } 
        #endregion

        #region Btn Department Master
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            //frm_mtrCompanyDepartment detail = new frm_mtrCompanyDepartment();
            //detail.ShowDialog();

            //UC_mtrCompanyDepartment_New frm = new UC_mtrCompanyDepartment_New(FormName.CompanyDepartmentMaster);
            //Form mf = new Form();
            //mf.StartPosition = 0;
            //// mf.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //mf.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //mf.Width = frm.Width;
            //mf.Height = frm.Height;
            //mf.Controls.Add(frm);
            //frm.Dock = System.Windows.Forms.DockStyle.Fill;
            ////mf.MdiParent = this;
            //mf.Show();

            //UC_mtrCompanyDepartment_New frm = new UC_mtrCompanyDepartment_New(FormName.CompanyDepartmentMaster);
            //Win32API.SetParent(frm.Handle, this.Handle);
            //Win32API.ShowWindow(frm.Handle, 1);

            UC_mtrCompanyDepartment_New frm = new UC_mtrCompanyDepartment_New(FormName.CompanyDepartmentMaster);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorMasters, this.MdiParent);
        } 
        #endregion

        #region Btn Section Master
        private void btnSetion_Click(object sender, EventArgs e)
        {
            frm_mtrCompanySection detail = new frm_mtrCompanySection();
            detail.ShowDialog();
        } 
        #endregion

        #region Btn Store Master
        private void btnStore_Click(object sender, EventArgs e)
        {
            //frm_mtrCompanyStore detail = new frm_mtrCompanyStore();
            //detail.ShowDialog();

            //UC_mtrCompanyStore_New frm = new UC_mtrCompanyStore_New(FormName.CompanyStoreMaster);
            //Form mf = new Form();
            //mf.StartPosition = 0;
            //// mf.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //mf.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //mf.Width = frm.Width;
            //mf.Height = frm.Height;
            //mf.Controls.Add(frm);
            //frm.Dock = System.Windows.Forms.DockStyle.Fill;
            ////mf.MdiParent = this;
            //mf.Show();

            UC_mtrCompanyStore_New frm = new UC_mtrCompanyStore_New(FormName.CompanyStoreMaster);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorMasters, this.MdiParent);


        }
        #endregion

        #region btn Expand All
        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            bookTree.ExpandAll();
        }
        #endregion

        #region btn Collapse
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            bookTree.CollapseAll();
        }
        #endregion

        #region btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bookTree.Refresh();
        }
        #endregion

        #region Populate Tree
        private void populateTree()
        {
            #region Company Country Master
            List<tbl_genCompanyCountryMaster> mainDetails = tbl_genCompanyCountryMaster.SelectAll();

            foreach (tbl_genCompanyCountryMaster detail in mainDetails)
            {
                if (detail.CompanyCountry_ID != "default")
                {
                    TreeNode TParent = new TreeNode(detail.CountryName, 2, 2);
                    TParent.ForeColor = Color.Blue;

                    #region Company Branch Master
                    List<tbl_genCompanyBranchMaster> subDetails = tbl_genCompanyBranchMaster.SelectAllByCompanyCountry_ID(detail.CompanyCountry_ID);
                    foreach (tbl_genCompanyBranchMaster Sdetail in subDetails)
                    {
                        TreeNode Sub1Item = new TreeNode(Sdetail.BranchName, 1, 1);
                        Sub1Item.ForeColor = Color.Green;

                        #region Division Master
                        List<tbl_genDivisionMaster> subsubDetails = tbl_genDivisionMaster.SelectAllByCompanyBranch_ID(Sdetail.CompanyBranch_ID);
                        foreach (tbl_genDivisionMaster s2detail in subsubDetails)
                        {
                            TreeNode Sub2Item = new TreeNode(s2detail.DivisionName, 0, 0);
                            Sub2Item.ForeColor = Color.Red;

                            #region Department Master
                            List<tbl_genDepartmentMaster> sub3Details = tbl_genDepartmentMaster.SelectAllByDivision_ID(s2detail.Division_ID);
                            foreach (tbl_genDepartmentMaster s3Details in sub3Details)
                            {
                                TreeNode Sub3Item = new TreeNode(s3Details.DepartmentName, 3, 3);
                                Sub3Item.ForeColor = Color.Yellow;

                                #region Section Master
                                List<tbl_genSectionMaster> sub4Details = tbl_genSectionMaster.SelectAllByDepartment_ID(s3Details.Department_ID);
                                foreach (tbl_genSectionMaster s4Details in sub4Details)
                                {
                                    TreeNode Sub4Item  = new TreeNode(s4Details.SectionName, 4, 4);
                                    Sub4Item.ForeColor = Color.Black;
                                    Sub3Item.Nodes.Add(Sub4Item);
                                }
                                #endregion
                                Sub2Item.Nodes.Add(Sub3Item);
                            }
                            #endregion
                            Sub1Item.Nodes.Add(Sub2Item);
                        }                      
                        #endregion
                        TParent.Nodes.Add(Sub1Item);
                    }
                    #endregion
                    bookTree.Nodes.Add(TParent);
                }
            } 
            #endregion
        }
        #endregion
        
    }
}