using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasPreCosting_Other {
		#region Fields
		private string preCosting_ID;
		private string costingType_ID;
		private decimal unitRate;
		private decimal quantity;
		private decimal costValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Other class.
		/// </summary>
		public tbl_sasPreCosting_Other() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Other class.
		/// </summary>
		public tbl_sasPreCosting_Other(string preCosting_ID, string costingType_ID, decimal unitRate, decimal quantity, decimal costValue) {
			this.preCosting_ID = preCosting_ID;
			this.costingType_ID = costingType_ID;
			this.unitRate = unitRate;
			this.quantity = quantity;
			this.costValue = costValue;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PreCosting_ID value.
		/// </summary>
		public string PreCosting_ID {
			get { return preCosting_ID; }
			set { preCosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostingType_ID value.
		/// </summary>
		public string CostingType_ID {
			get { return costingType_ID; }
			set { costingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitRate value.
		/// </summary>
		public decimal UnitRate {
			get { return unitRate; }
			set { unitRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Quantity value.
		/// </summary>
		public decimal Quantity {
			get { return quantity; }
			set { quantity = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostValue value.
		/// </summary>
		public decimal CostValue {
			get { return costValue; }
			set { costValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasPreCosting_Other table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@unitRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@quantity", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costValue", SqlDbType.Decimal,9);
 
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
			scom.Parameters["@unitRate"].Value = unitRate;
			scom.Parameters["@quantity"].Value = quantity;
			scom.Parameters["@costValue"].Value = costValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasPreCosting_Other table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@unitRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@quantity", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costValue", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
			scom.Parameters["@unitRate"].Value = unitRate;
			scom.Parameters["@quantity"].Value = quantity;
			scom.Parameters["@costValue"].Value = costValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasPreCosting_Other table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
 
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Other table by a foreign key.
		/// </summary>
		public static void DeleteAllByPreCosting_ID(string preCosting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherDeleteAllByPreCosting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Other table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostingType_ID(string costingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherDeleteAllByCostingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasPreCosting_Other table.
		/// </summary>
		public static tbl_sasPreCosting_Other Select(string preCosting_ID_Incoming, string costingType_ID_Incoming){

			tbl_sasPreCosting_Other tbl_sasPreCosting_Otherins = new tbl_sasPreCosting_Other();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID_Incoming;
			scom.Parameters["@costingType_ID"].Value = costingType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasPreCosting_Otherins = Maketbl_sasPreCosting_Other(dataReader);
				} else {
					tbl_sasPreCosting_Otherins = null;
				}
			}
			scon.Close();
			return tbl_sasPreCosting_Otherins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Other table.
		/// </summary>
		public static List<tbl_sasPreCosting_Other> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasPreCosting_Other> tbl_sasPreCosting_OtherList = new List<tbl_sasPreCosting_Other>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Other tbl_sasPreCosting_Other = Maketbl_sasPreCosting_Other(dataReader);
					tbl_sasPreCosting_OtherList.Add(tbl_sasPreCosting_Other);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_OtherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Other table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Other> SelectAllByPreCosting_ID(string preCosting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherSelectAllByPreCosting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
				List<tbl_sasPreCosting_Other> tbl_sasPreCosting_OtherList = new List<tbl_sasPreCosting_Other>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Other tbl_sasPreCosting_Other = Maketbl_sasPreCosting_Other(dataReader);
					tbl_sasPreCosting_OtherList.Add(tbl_sasPreCosting_Other);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_OtherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Other table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Other> SelectAllByCostingType_ID(string costingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_OtherSelectAllByCostingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
				List<tbl_sasPreCosting_Other> tbl_sasPreCosting_OtherList = new List<tbl_sasPreCosting_Other>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Other tbl_sasPreCosting_Other = Maketbl_sasPreCosting_Other(dataReader);
					tbl_sasPreCosting_OtherList.Add(tbl_sasPreCosting_Other);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_OtherList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasPreCosting_Other class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasPreCosting_Other Maketbl_sasPreCosting_Other(SqlDataReader dataReader) {
			tbl_sasPreCosting_Other tbl_sasPreCosting_Other = new tbl_sasPreCosting_Other();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasPreCosting_Other.PreCosting_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasPreCosting_Other.CostingType_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasPreCosting_Other.UnitRate = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasPreCosting_Other.Quantity = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasPreCosting_Other.CostValue = dataReader.GetDecimal(4);
			}

			return tbl_sasPreCosting_Other;
		}
		/// <summary>
		/// This makes tbl_sasPreCosting_Other datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Other object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasPreCosting_Other  tbl_sasPreCosting_Other   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_preCosting_ID = new DataColumn("preCosting_ID" , typeof(string));
			DataColumn col_costingType_ID = new DataColumn("costingType_ID" , typeof(string));
			DataColumn col_unitRate = new DataColumn("unitRate" , typeof(decimal));
			DataColumn col_quantity = new DataColumn("quantity" , typeof(decimal));
			DataColumn col_costValue = new DataColumn("costValue" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_preCosting_ID,col_costingType_ID,col_unitRate,col_quantity,col_costValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasPreCosting_Other datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Other object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasPreCosting_Other user) {
		DataRow drow = dt.NewRow();
		
			drow["preCosting_ID"] = user.preCosting_ID;
			drow["costingType_ID"] = user.costingType_ID;
			drow["unitRate"] = user.unitRate;
			drow["quantity"] = user.quantity;
			drow["costValue"] = user.costValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
