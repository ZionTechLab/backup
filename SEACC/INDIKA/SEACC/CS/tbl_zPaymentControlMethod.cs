using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPaymentControlMethod {
		#region Fields
		private string paymentControlMethod_ID;
		private string paymentControlMethod;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPaymentControlMethod class.
		/// </summary>
		public tbl_zPaymentControlMethod() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPaymentControlMethod class.
		/// </summary>
		public tbl_zPaymentControlMethod(string paymentControlMethod_ID, string paymentControlMethod) {
			this.paymentControlMethod_ID = paymentControlMethod_ID;
			this.paymentControlMethod = paymentControlMethod;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PaymentControlMethod_ID value.
		/// </summary>
		public string PaymentControlMethod_ID {
			get { return paymentControlMethod_ID; }
			set { paymentControlMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentControlMethod value.
		/// </summary>
		public string PaymentControlMethod {
			get { return paymentControlMethod; }
			set { paymentControlMethod = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPaymentControlMethod table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentControlMethodInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentControlMethod", SqlDbType.VarChar,50);
 
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
			scom.Parameters["@paymentControlMethod"].Value = paymentControlMethod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPaymentControlMethod table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentControlMethodUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentControlMethod", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
			scom.Parameters["@paymentControlMethod"].Value = paymentControlMethod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPaymentControlMethod table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentControlMethodDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPaymentControlMethod table.
		/// </summary>
		public static tbl_zPaymentControlMethod Select(string paymentControlMethod_ID_Incoming){

			tbl_zPaymentControlMethod tbl_zPaymentControlMethodins = new tbl_zPaymentControlMethod();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentControlMethodSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentControlMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentControlMethod_ID"].Value = paymentControlMethod_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPaymentControlMethodins = Maketbl_zPaymentControlMethod(dataReader);
				} else {
					tbl_zPaymentControlMethodins = null;
				}
			}
			scon.Close();
			return tbl_zPaymentControlMethodins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPaymentControlMethod table.
		/// </summary>
		public static List<tbl_zPaymentControlMethod> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentControlMethodSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPaymentControlMethod> tbl_zPaymentControlMethodList = new List<tbl_zPaymentControlMethod>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPaymentControlMethod tbl_zPaymentControlMethod = Maketbl_zPaymentControlMethod(dataReader);
					tbl_zPaymentControlMethodList.Add(tbl_zPaymentControlMethod);
				}
			}
			scon.Close();
			return tbl_zPaymentControlMethodList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPaymentControlMethod class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPaymentControlMethod Maketbl_zPaymentControlMethod(SqlDataReader dataReader) {
			tbl_zPaymentControlMethod tbl_zPaymentControlMethod = new tbl_zPaymentControlMethod();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPaymentControlMethod.PaymentControlMethod_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPaymentControlMethod.PaymentControlMethod = dataReader.GetString(1);
			}

			return tbl_zPaymentControlMethod;
		}
		/// <summary>
		/// This makes tbl_zPaymentControlMethod datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPaymentControlMethod object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPaymentControlMethod  tbl_zPaymentControlMethod   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_paymentControlMethod_ID = new DataColumn("paymentControlMethod_ID" , typeof(string));
			DataColumn col_paymentControlMethod = new DataColumn("paymentControlMethod" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_paymentControlMethod_ID,col_paymentControlMethod,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPaymentControlMethod datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPaymentControlMethod object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPaymentControlMethod user) {
		DataRow drow = dt.NewRow();
		
			drow["paymentControlMethod_ID"] = user.paymentControlMethod_ID;
			drow["paymentControlMethod"] = user.paymentControlMethod;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
