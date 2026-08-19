using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genDepartmentStock {
		#region Fields
		private string department_ID;
		private string item_ID;
		private decimal actualQty;
		private decimal availableQty;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genDepartmentStock class.
		/// </summary>
		public tbl_genDepartmentStock() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genDepartmentStock class.
		/// </summary>
		public tbl_genDepartmentStock(string department_ID, string item_ID, decimal actualQty, decimal availableQty) {
			this.department_ID = department_ID;
			this.item_ID = item_ID;
			this.actualQty = actualQty;
			this.availableQty = availableQty;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ActualQty value.
		/// </summary>
		public decimal ActualQty {
			get { return actualQty; }
			set { actualQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the AvailableQty value.
		/// </summary>
		public decimal AvailableQty {
			get { return availableQty; }
			set { availableQty = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genDepartmentStock table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentStockInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@actualQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@availableQty", SqlDbType.Decimal,9);
 
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@actualQty"].Value = actualQty;
			scom.Parameters["@availableQty"].Value = availableQty;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genDepartmentStock table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentStockUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@actualQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@availableQty", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@actualQty"].Value = actualQty;
			scom.Parameters["@availableQty"].Value = availableQty;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genDepartmentStock table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentStockDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genDepartmentStock table.
		/// </summary>
		public static tbl_genDepartmentStock Select(string department_ID_Incoming, string item_ID_Incoming){

			tbl_genDepartmentStock tbl_genDepartmentStockins = new tbl_genDepartmentStock();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentStockSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genDepartmentStockins = Maketbl_genDepartmentStock(dataReader);
				} else {
					tbl_genDepartmentStockins = null;
				}
			}
			scon.Close();
			return tbl_genDepartmentStockins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartmentStock table.
		/// </summary>
		public static List<tbl_genDepartmentStock> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentStockSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genDepartmentStock> tbl_genDepartmentStockList = new List<tbl_genDepartmentStock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartmentStock tbl_genDepartmentStock = Maketbl_genDepartmentStock(dataReader);
					tbl_genDepartmentStockList.Add(tbl_genDepartmentStock);
				}
			}
			scon.Close();
			return tbl_genDepartmentStockList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genDepartmentStock class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genDepartmentStock Maketbl_genDepartmentStock(SqlDataReader dataReader) {
			tbl_genDepartmentStock tbl_genDepartmentStock = new tbl_genDepartmentStock();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genDepartmentStock.Department_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genDepartmentStock.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genDepartmentStock.ActualQty = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genDepartmentStock.AvailableQty = dataReader.GetDecimal(3);
			}

			return tbl_genDepartmentStock;
		}
		/// <summary>
		/// This makes tbl_genDepartmentStock datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genDepartmentStock object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genDepartmentStock  tbl_genDepartmentStock   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_actualQty = new DataColumn("actualQty" , typeof(decimal));
			DataColumn col_availableQty = new DataColumn("availableQty" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_department_ID,col_item_ID,col_actualQty,col_availableQty,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genDepartmentStock datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genDepartmentStock object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genDepartmentStock user) {
		DataRow drow = dt.NewRow();
		
			drow["department_ID"] = user.department_ID;
			drow["item_ID"] = user.item_ID;
			drow["actualQty"] = user.actualQty;
			drow["availableQty"] = user.availableQty;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
