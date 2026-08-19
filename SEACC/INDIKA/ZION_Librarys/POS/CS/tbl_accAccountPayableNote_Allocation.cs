using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accAccountPayableNote_Allocation {
		#region Fields
		private string accountPayableNote_ID;
		private string externalGoodReceivedNote_ID;
		private string item_ID;
		private decimal allocatedAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountPayableNote_Allocation class.
		/// </summary>
		public tbl_accAccountPayableNote_Allocation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountPayableNote_Allocation class.
		/// </summary>
		public tbl_accAccountPayableNote_Allocation(string accountPayableNote_ID, string externalGoodReceivedNote_ID, string item_ID, decimal allocatedAmount) {
			this.accountPayableNote_ID = accountPayableNote_ID;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.item_ID = item_ID;
			this.allocatedAmount = allocatedAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AccountPayableNote_ID value.
		/// </summary>
		public string AccountPayableNote_ID {
			get { return accountPayableNote_ID; }
			set { accountPayableNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocatedAmount value.
		/// </summary>
		public decimal AllocatedAmount {
			get { return allocatedAmount; }
			set { allocatedAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accAccountPayableNote_Allocation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_AllocationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allocatedAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@allocatedAmount"].Value = allocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accAccountPayableNote_Allocation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_AllocationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allocatedAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@allocatedAmount"].Value = allocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accAccountPayableNote_Allocation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_AllocationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accAccountPayableNote_Allocation table.
		/// </summary>
		public static tbl_accAccountPayableNote_Allocation Select(string accountPayableNote_ID_Incoming, string externalGoodReceivedNote_ID_Incoming, string item_ID_Incoming){

			tbl_accAccountPayableNote_Allocation tbl_accAccountPayableNote_Allocationins = new tbl_accAccountPayableNote_Allocation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_AllocationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID_Incoming;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accAccountPayableNote_Allocationins = Maketbl_accAccountPayableNote_Allocation(dataReader);
				} else {
					tbl_accAccountPayableNote_Allocationins = null;
				}
			}
			scon.Close();
			return tbl_accAccountPayableNote_Allocationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote_Allocation table.
		/// </summary>
		public static List<tbl_accAccountPayableNote_Allocation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNote_AllocationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accAccountPayableNote_Allocation> tbl_accAccountPayableNote_AllocationList = new List<tbl_accAccountPayableNote_Allocation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote_Allocation tbl_accAccountPayableNote_Allocation = Maketbl_accAccountPayableNote_Allocation(dataReader);
					tbl_accAccountPayableNote_AllocationList.Add(tbl_accAccountPayableNote_Allocation);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNote_AllocationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accAccountPayableNote_Allocation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accAccountPayableNote_Allocation Maketbl_accAccountPayableNote_Allocation(SqlDataReader dataReader) {
			tbl_accAccountPayableNote_Allocation tbl_accAccountPayableNote_Allocation = new tbl_accAccountPayableNote_Allocation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accAccountPayableNote_Allocation.AccountPayableNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accAccountPayableNote_Allocation.ExternalGoodReceivedNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accAccountPayableNote_Allocation.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accAccountPayableNote_Allocation.AllocatedAmount = dataReader.GetDecimal(3);
			}

			return tbl_accAccountPayableNote_Allocation;
		}
		/// <summary>
		/// This makes tbl_accAccountPayableNote_Allocation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accAccountPayableNote_Allocation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accAccountPayableNote_Allocation  tbl_accAccountPayableNote_Allocation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_accountPayableNote_ID = new DataColumn("accountPayableNote_ID" , typeof(string));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_allocatedAmount = new DataColumn("allocatedAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_accountPayableNote_ID,col_externalGoodReceivedNote_ID,col_item_ID,col_allocatedAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accAccountPayableNote_Allocation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accAccountPayableNote_Allocation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accAccountPayableNote_Allocation user) {
		DataRow drow = dt.NewRow();
		
			drow["accountPayableNote_ID"] = user.accountPayableNote_ID;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["allocatedAmount"] = user.allocatedAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
