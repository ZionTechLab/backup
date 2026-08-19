using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityPaymentControlPermission {
		#region Fields
		private string user_ID;
		private string paymentControlMethod_ID;
		private decimal totalAmount;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityPaymentControlPermission class.
		/// </summary>
		public tbl_securityPaymentControlPermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityPaymentControlPermission class.
		/// </summary>
		public tbl_securityPaymentControlPermission(string user_ID, string paymentControlMethod_ID, decimal totalAmount, bool isActive) {
			this.user_ID = user_ID;
			this.paymentControlMethod_ID = paymentControlMethod_ID;
			this.totalAmount = totalAmount;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentControlMethod_ID value.
		/// </summary>
		public string PaymentControlMethod_ID {
			get { return paymentControlMethod_ID; }
			set { paymentControlMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityPaymentControlPermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityPaymentControlPermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityPaymentControlPermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPaymentControlPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentControlMethod_ID(string paymentControlMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionDeleteAllByPaymentControlMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPaymentControlPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityPaymentControlPermission table.
		/// </summary>
		public static tbl_securityPaymentControlPermission Select(string user_ID_Incoming, string paymentControlMethod_ID_Incoming){

			tbl_securityPaymentControlPermission tbl_securityPaymentControlPermissionins = new tbl_securityPaymentControlPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityPaymentControlPermissionins = Maketbl_securityPaymentControlPermission(dataReader);
				} else {
					tbl_securityPaymentControlPermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityPaymentControlPermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPaymentControlPermission table.
		/// </summary>
		public static List<tbl_securityPaymentControlPermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityPaymentControlPermission> tbl_securityPaymentControlPermissionList = new List<tbl_securityPaymentControlPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPaymentControlPermission tbl_securityPaymentControlPermission = Maketbl_securityPaymentControlPermission(dataReader);
					tbl_securityPaymentControlPermissionList.Add(tbl_securityPaymentControlPermission);
				}
			}
			scon.Close();
			return tbl_securityPaymentControlPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPaymentControlPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityPaymentControlPermission> SelectAllByPaymentControlMethod_ID(string paymentControlMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionSelectAllByPaymentControlMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
				List<tbl_securityPaymentControlPermission> tbl_securityPaymentControlPermissionList = new List<tbl_securityPaymentControlPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPaymentControlPermission tbl_securityPaymentControlPermission = Maketbl_securityPaymentControlPermission(dataReader);
					tbl_securityPaymentControlPermissionList.Add(tbl_securityPaymentControlPermission);
				}
			}
			scon.Close();
			return tbl_securityPaymentControlPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityPaymentControlPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityPaymentControlPermission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityPaymentControlPermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityPaymentControlPermission> tbl_securityPaymentControlPermissionList = new List<tbl_securityPaymentControlPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityPaymentControlPermission tbl_securityPaymentControlPermission = Maketbl_securityPaymentControlPermission(dataReader);
					tbl_securityPaymentControlPermissionList.Add(tbl_securityPaymentControlPermission);
				}
			}
			scon.Close();
			return tbl_securityPaymentControlPermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityPaymentControlPermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityPaymentControlPermission Maketbl_securityPaymentControlPermission(SqlDataReader dataReader) {
			tbl_securityPaymentControlPermission tbl_securityPaymentControlPermission = new tbl_securityPaymentControlPermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityPaymentControlPermission.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityPaymentControlPermission.PaymentControlMethod_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityPaymentControlPermission.TotalAmount = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityPaymentControlPermission.IsActive = dataReader.GetBoolean(3);
			}

			return tbl_securityPaymentControlPermission;
		}
		/// <summary>
		/// This makes tbl_securityPaymentControlPermission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityPaymentControlPermission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityPaymentControlPermission  tbl_securityPaymentControlPermission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_paymentControlMethod_ID = new DataColumn("paymentControlMethod_ID" , typeof(string));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_paymentControlMethod_ID,col_totalAmount,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityPaymentControlPermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityPaymentControlPermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityPaymentControlPermission user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["paymentControlMethod_ID"] = user.paymentControlMethod_ID;
			drow["totalAmount"] = user.totalAmount;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
