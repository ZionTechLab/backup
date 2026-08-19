using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_Slab {
		#region Fields
		private string commission_ID;
		private string employee_ID;
		private int slabID;
		private decimal fromAmount;
		private decimal toAmount;
		private decimal commissionPercentage;
		private decimal commissionAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Slab class.
		/// </summary>
		public tbl_sasSalesCommission_Slab() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Slab class.
		/// </summary>
		public tbl_sasSalesCommission_Slab(string commission_ID, string employee_ID, int slabID, decimal fromAmount, decimal toAmount, decimal commissionPercentage, decimal commissionAmount) {
			this.commission_ID = commission_ID;
			this.employee_ID = employee_ID;
			this.slabID = slabID;
			this.fromAmount = fromAmount;
			this.toAmount = toAmount;
			this.commissionPercentage = commissionPercentage;
			this.commissionAmount = commissionAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Commission_ID value.
		/// </summary>
		public string Commission_ID {
			get { return commission_ID; }
			set { commission_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlabID value.
		/// </summary>
		public int SlabID {
			get { return slabID; }
			set { slabID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromAmount value.
		/// </summary>
		public decimal FromAmount {
			get { return fromAmount; }
			set { fromAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToAmount value.
		/// </summary>
		public decimal ToAmount {
			get { return toAmount; }
			set { toAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommissionPercentage value.
		/// </summary>
		public decimal CommissionPercentage {
			get { return commissionPercentage; }
			set { commissionPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommissionAmount value.
		/// </summary>
		public decimal CommissionAmount {
			get { return commissionAmount; }
			set { commissionAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_Slab table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_SlabInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters.Add("@fromAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@toAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@slabID"].Value = slabID;
			scom.Parameters["@fromAmount"].Value = fromAmount;
			scom.Parameters["@toAmount"].Value = toAmount;
			scom.Parameters["@commissionPercentage"].Value = commissionPercentage;
			scom.Parameters["@commissionAmount"].Value = commissionAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_Slab table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_SlabUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters.Add("@fromAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@toAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@slabID"].Value = slabID;
			scom.Parameters["@fromAmount"].Value = fromAmount;
			scom.Parameters["@toAmount"].Value = toAmount;
			scom.Parameters["@commissionPercentage"].Value = commissionPercentage;
			scom.Parameters["@commissionAmount"].Value = commissionAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_Slab table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_SlabDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scom.Parameters["@slabID"].Value = slabID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Slab table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_SlabDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_Slab table.
		/// </summary>
		public static tbl_sasSalesCommission_Slab Select(string commission_ID_Incoming, string employee_ID_Incoming, int slabID_Incoming){

			tbl_sasSalesCommission_Slab tbl_sasSalesCommission_Slabins = new tbl_sasSalesCommission_Slab();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_SlabSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			scom.Parameters["@slabID"].Value = slabID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_Slabins = Maketbl_sasSalesCommission_Slab(dataReader);
				} else {
					tbl_sasSalesCommission_Slabins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_Slabins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Slab table.
		/// </summary>
		public static List<tbl_sasSalesCommission_Slab> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_SlabSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_Slab> tbl_sasSalesCommission_SlabList = new List<tbl_sasSalesCommission_Slab>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Slab tbl_sasSalesCommission_Slab = Maketbl_sasSalesCommission_Slab(dataReader);
					tbl_sasSalesCommission_SlabList.Add(tbl_sasSalesCommission_Slab);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_SlabList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Slab table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_Slab> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_SlabSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_Slab> tbl_sasSalesCommission_SlabList = new List<tbl_sasSalesCommission_Slab>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Slab tbl_sasSalesCommission_Slab = Maketbl_sasSalesCommission_Slab(dataReader);
					tbl_sasSalesCommission_SlabList.Add(tbl_sasSalesCommission_Slab);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_SlabList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_Slab class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_Slab Maketbl_sasSalesCommission_Slab(SqlDataReader dataReader) {
			tbl_sasSalesCommission_Slab tbl_sasSalesCommission_Slab = new tbl_sasSalesCommission_Slab();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_Slab.Commission_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_Slab.Employee_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_Slab.SlabID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_Slab.FromAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesCommission_Slab.ToAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesCommission_Slab.CommissionPercentage = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesCommission_Slab.CommissionAmount = dataReader.GetDecimal(6);
			}

			return tbl_sasSalesCommission_Slab;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_Slab datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Slab object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_Slab  tbl_sasSalesCommission_Slab   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_slabID = new DataColumn("slabID" , typeof(int));
			DataColumn col_fromAmount = new DataColumn("fromAmount" , typeof(decimal));
			DataColumn col_toAmount = new DataColumn("toAmount" , typeof(decimal));
			DataColumn col_commissionPercentage = new DataColumn("commissionPercentage" , typeof(decimal));
			DataColumn col_commissionAmount = new DataColumn("commissionAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_commission_ID,col_employee_ID,col_slabID,col_fromAmount,col_toAmount,col_commissionPercentage,col_commissionAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_Slab datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Slab object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_Slab user) {
		DataRow drow = dt.NewRow();
		
			drow["commission_ID"] = user.commission_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["slabID"] = user.slabID;
			drow["fromAmount"] = user.fromAmount;
			drow["toAmount"] = user.toAmount;
			drow["commissionPercentage"] = user.commissionPercentage;
			drow["commissionAmount"] = user.commissionAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
