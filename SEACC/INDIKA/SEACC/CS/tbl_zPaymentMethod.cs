using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zPaymentMethod {
		#region Fields
		private string paymentMethod_ID;
		private string paymentMethodName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zPaymentMethod class.
		/// </summary>
		public tbl_zPaymentMethod() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zPaymentMethod class.
		/// </summary>
		public tbl_zPaymentMethod(string paymentMethod_ID, string paymentMethodName) {
			this.paymentMethod_ID = paymentMethod_ID;
			this.paymentMethodName = paymentMethodName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethodName value.
		/// </summary>
		public string PaymentMethodName {
			get { return paymentMethodName; }
			set { paymentMethodName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zPaymentMethod table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentMethodInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethodName", SqlDbType.VarChar,50);
 
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentMethodName"].Value = paymentMethodName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zPaymentMethod table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentMethodUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethodName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentMethodName"].Value = paymentMethodName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zPaymentMethod table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentMethodDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zPaymentMethod table.
		/// </summary>
		public static tbl_zPaymentMethod Select(string paymentMethod_ID_Incoming){

			tbl_zPaymentMethod tbl_zPaymentMethodins = new tbl_zPaymentMethod();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentMethodSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zPaymentMethodins = Maketbl_zPaymentMethod(dataReader);
				} else {
					tbl_zPaymentMethodins = null;
				}
			}
			scon.Close();
			return tbl_zPaymentMethodins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zPaymentMethod table.
		/// </summary>
		public static List<tbl_zPaymentMethod> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zPaymentMethodSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zPaymentMethod> tbl_zPaymentMethodList = new List<tbl_zPaymentMethod>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zPaymentMethod tbl_zPaymentMethod = Maketbl_zPaymentMethod(dataReader);
					tbl_zPaymentMethodList.Add(tbl_zPaymentMethod);
				}
			}
			scon.Close();
			return tbl_zPaymentMethodList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zPaymentMethod class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zPaymentMethod Maketbl_zPaymentMethod(SqlDataReader dataReader) {
			tbl_zPaymentMethod tbl_zPaymentMethod = new tbl_zPaymentMethod();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zPaymentMethod.PaymentMethod_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zPaymentMethod.PaymentMethodName = dataReader.GetString(1);
			}

			return tbl_zPaymentMethod;
		}
		/// <summary>
		/// This makes tbl_zPaymentMethod datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zPaymentMethod object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zPaymentMethod  tbl_zPaymentMethod   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_paymentMethodName = new DataColumn("paymentMethodName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_paymentMethod_ID,col_paymentMethodName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zPaymentMethod datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zPaymentMethod object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zPaymentMethod user) {
		DataRow drow = dt.NewRow();
		
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["paymentMethodName"] = user.paymentMethodName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
