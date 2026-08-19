using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZION.SFA.Domain.SCS;
using ZION.SFA.WebApiClient.SCS;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var lists = new List<StoreStock>();
                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    lists = db.Query<StoreStock>("[dbo].[sp_Get_Inventory]", para, commandType: CommandType.StoredProcedure).ToList();
                }

                var apic = new InventoryApiClient();
                var result = apic.Update_Inventory(lists);
                if (result.IsSuccess)
                    MessageBox.Show("success");
                else
                    MessageBox.Show(result.varOutMsg);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateItemMaster_Click(object sender, EventArgs e)
        {
            var lists = new List<tbl_genItemMaster>();
            using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
            {
                var para = new DynamicParameters();
                lists = db.Query<tbl_genItemMaster>("[dbo].[sp_Get_ItemMaster]", para, commandType: CommandType.StoredProcedure).ToList();
            }

            var apic = new InventoryApiClient();
            var result = apic.Update_ItemMaster(lists);
            if (result.IsSuccess)
                MessageBox.Show("success");
            else
                MessageBox.Show(result.varOutMsg);
        }
    }
}
