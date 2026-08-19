using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_toolDemo : Form
    {
        public frm_toolDemo()
        {
            InitializeComponent();
        }

        private void frm_Demo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            List<tbl_genCustomerMaster> collection = tbl_genCustomerMaster.SelectAll();
            foreach (var item in collection)
            {
                if (item.Customer_ID != "default")
                {
                    item.CustomerName = "Customer " + i;
                    item.Update();
                    i++;
                }
            }
            MessageBox.Show("Save Details");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 1;
            List<tbl_genSupplierMaster> collection = tbl_genSupplierMaster.SelectAll();
            foreach (var item in collection)
            {
                if (item.Supplier_ID != "default")
                {
                    item.SupplierName = "Supplier " + i;
                    item.Update();
                    i++;
                }
            }
            MessageBox.Show("Save Details");
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 1;
            List<tbl_genItemMaster> collection = tbl_genItemMaster.SelectAll();
            foreach (var item in collection)
            {
                if (item.Item_ID != "default")
                {
                    item.ItemName = "ItemName " + i;
                    item.Update();
                    i++;
                }
            }
            int ia = 1;
            List<tbl_zItemSubCategory> collectionc = tbl_zItemSubCategory.SelectAll();
            foreach (var item in collectionc)
            {
                if (item.ItemSubCategory_ID != "default")
                {

                    item.ItemSubCategoryName = "Brand Name " + ia;
                    item.Update();
                    ia++;
                }
            }
            int ib = 1;
            List<tbl_zItemSubCategory2> collectionc2 = tbl_zItemSubCategory2.SelectAll();
            foreach (var item in collectionc2)
            {
                if (item.ItemSubCategory2_ID != "default")
                {

                    item.ItemSubCategory2Name = "Model Name " + ib;
                    item.Update();
                    ib++;
                }
            }
            MessageBox.Show("Save Details");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 1;
            List<tbl_securityUserMaster> collection = tbl_securityUserMaster.SelectAll();
            foreach (var item in collection)
            {
                if (item.User_ID != "default")
                {
                    item.UserName = "User " + i;
                    item.Update();
                    i++;
                }
            }
            MessageBox.Show("Save Details");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 1;
            List<tbl_genStoreMaster> collection = tbl_genStoreMaster.SelectAll();
            foreach (var item in collection)
            {
                if (item.Store_ID != "default")
                {
                    item.StoreName = "User " + i;
                    item.Update();
                    i++;
                }
            }
            MessageBox.Show("Save Details");
        }
    }
}
