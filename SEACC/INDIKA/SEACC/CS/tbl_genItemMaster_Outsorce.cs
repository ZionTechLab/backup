using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_Outsorce {
		#region Fields
		private string item_ID;
		private string supplier_ID;
		private decimal outsource_Rate;
		private DateTime lastUpdate_Date;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Outsorce class.
		/// </summary>
		public tbl_genItemMaster_Outsorce() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Outsorce class.
		/// </summary>
		public tbl_genItemMaster_Outsorce(string item_ID, string supplier_ID, decimal outsource_Rate, DateTime lastUpdate_Date) {
			this.item_ID = item_ID;
			this.supplier_ID = supplier_ID;
			this.outsource_Rate = outsource_Rate;
			this.lastUpdate_Date = lastUpdate_Date;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Outsource_Rate value.
		/// </summary>
		public decimal Outsource_Rate {
			get { return outsource_Rate; }
			set { outsource_Rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastUpdate_Date value.
		/// </summary>
		public DateTime LastUpdate_Date {
			get { return lastUpdate_Date; }
			set { lastUpdate_Date = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Outsorce table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@outsource_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lastUpdate_Date", SqlDbType.DateTime,8);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@outsource_Rate"].Value = outsource_Rate;
			scom.Parameters["@lastUpdate_Date"].Value = lastUpdate_Date;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Outsorce table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@outsource_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lastUpdate_Date", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@outsource_Rate"].Value = outsource_Rate;
			scom.Parameters["@lastUpdate_Date"].Value = lastUpdate_Date;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Outsorce table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Outsorce table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Outsorce table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Outsorce table.
		/// </summary>
		public static tbl_genItemMaster_Outsorce Select(string item_ID_Incoming, string supplier_ID_Incoming){

			tbl_genItemMaster_Outsorce tbl_genItemMaster_Outsorceins = new tbl_genItemMaster_Outsorce();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@supplier_ID"].Value = supplier_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Outsorceins = Maketbl_genItemMaster_Outsorce(dataReader);
				} else {
					tbl_genItemMaster_Outsorceins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Outsorceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Outsorce table.
		/// </summary>
		public static List<tbl_genItemMaster_Outsorce> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Outsorce> tbl_genItemMaster_OutsorceList = new List<tbl_genItemMaster_Outsorce>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Outsorce tbl_genItemMaster_Outsorce = Maketbl_genItemMaster_Outsorce(dataReader);
					tbl_genItemMaster_OutsorceList.Add(tbl_genItemMaster_Outsorce);
				}
			}
			scon.Close();
			return tbl_genItemMaster_OutsorceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Outsorce table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Outsorce> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_genItemMaster_Outsorce> tbl_genItemMaster_OutsorceList = new List<tbl_genItemMaster_Outsorce>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Outsorce tbl_genItemMaster_Outsorce = Maketbl_genItemMaster_Outsorce(dataReader);
					tbl_genItemMaster_OutsorceList.Add(tbl_genItemMaster_Outsorce);
				}
			}
			scon.Close();
			return tbl_genItemMaster_OutsorceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Outsorce table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Outsorce> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_OutsorceSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_Outsorce> tbl_genItemMaster_OutsorceList = new List<tbl_genItemMaster_Outsorce>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Outsorce tbl_genItemMaster_Outsorce = Maketbl_genItemMaster_Outsorce(dataReader);
					tbl_genItemMaster_OutsorceList.Add(tbl_genItemMaster_Outsorce);
				}
			}
			scon.Close();
			return tbl_genItemMaster_OutsorceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Outsorce class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Outsorce Maketbl_genItemMaster_Outsorce(SqlDataReader dataReader) {
			tbl_genItemMaster_Outsorce tbl_genItemMaster_Outsorce = new tbl_genItemMaster_Outsorce();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Outsorce.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Outsorce.Supplier_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Outsorce.Outsource_Rate = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_Outsorce.LastUpdate_Date = dataReader.GetDateTime(3);
			}

			return tbl_genItemMaster_Outsorce;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Outsorce datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Outsorce object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Outsorce  tbl_genItemMaster_Outsorce   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_outsource_Rate = new DataColumn("outsource_Rate" , typeof(decimal));
			DataColumn col_lastUpdate_Date = new DataColumn("lastUpdate_Date" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_supplier_ID,col_outsource_Rate,col_lastUpdate_Date,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Outsorce datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Outsorce object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Outsorce user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["outsource_Rate"] = user.outsource_Rate;
			drow["lastUpdate_Date"] = user.lastUpdate_Date;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
