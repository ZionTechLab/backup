using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCustomerMaster_Consignee {
		#region Fields
		private int linNo;
		private string customer_ID;
		private string consigneeName;
		private string consigneeAddress;
		private string vatRegistrationNo;
		private string svatRegistrationNo;
		private bool isMainConsignee;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Consignee class.
		/// </summary>
		public tbl_genCustomerMaster_Consignee() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Consignee class.
		/// </summary>
		public tbl_genCustomerMaster_Consignee(int linNo, string customer_ID, string consigneeName, string consigneeAddress, string vatRegistrationNo, string svatRegistrationNo, bool isMainConsignee) {
			this.linNo = linNo;
			this.customer_ID = customer_ID;
			this.consigneeName = consigneeName;
			this.consigneeAddress = consigneeAddress;
			this.vatRegistrationNo = vatRegistrationNo;
			this.svatRegistrationNo = svatRegistrationNo;
			this.isMainConsignee = isMainConsignee;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the LinNo value.
		/// </summary>
		public int LinNo {
			get { return linNo; }
			set { linNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConsigneeName value.
		/// </summary>
		public string ConsigneeName {
			get { return consigneeName; }
			set { consigneeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConsigneeAddress value.
		/// </summary>
		public string ConsigneeAddress {
			get { return consigneeAddress; }
			set { consigneeAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatRegistrationNo value.
		/// </summary>
		public string VatRegistrationNo {
			get { return vatRegistrationNo; }
			set { vatRegistrationNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the SvatRegistrationNo value.
		/// </summary>
		public string SvatRegistrationNo {
			get { return svatRegistrationNo; }
			set { svatRegistrationNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMainConsignee value.
		/// </summary>
		public bool IsMainConsignee {
			get { return isMainConsignee; }
			set { isMainConsignee = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCustomerMaster_Consignee table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ConsigneeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@linNo", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@consigneeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@consigneeAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@vatRegistrationNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@svatRegistrationNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isMainConsignee", SqlDbType.Bit,1);
 
			scom.Parameters["@linNo"].Value = linNo;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@consigneeName"].Value = consigneeName;
			scom.Parameters["@consigneeAddress"].Value = consigneeAddress;
			scom.Parameters["@vatRegistrationNo"].Value = vatRegistrationNo;
			scom.Parameters["@svatRegistrationNo"].Value = svatRegistrationNo;
			scom.Parameters["@isMainConsignee"].Value = isMainConsignee;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerMaster_Consignee table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ConsigneeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@linNo", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@consigneeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@consigneeAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@vatRegistrationNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@svatRegistrationNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isMainConsignee", SqlDbType.Bit,1);
 
 
			scom.Parameters["@linNo"].Value = linNo;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@consigneeName"].Value = consigneeName;
			scom.Parameters["@consigneeAddress"].Value = consigneeAddress;
			scom.Parameters["@vatRegistrationNo"].Value = vatRegistrationNo;
			scom.Parameters["@svatRegistrationNo"].Value = svatRegistrationNo;
			scom.Parameters["@isMainConsignee"].Value = isMainConsignee;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerMaster_Consignee table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ConsigneeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@linNo", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@linNo"].Value = linNo;
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Consignee table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ConsigneeDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerMaster_Consignee table.
		/// </summary>
		public static tbl_genCustomerMaster_Consignee Select(int linNo_Incoming, string customer_ID_Incoming){

			tbl_genCustomerMaster_Consignee tbl_genCustomerMaster_Consigneeins = new tbl_genCustomerMaster_Consignee();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ConsigneeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@linNo", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@linNo"].Value = linNo_Incoming;
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerMaster_Consigneeins = Maketbl_genCustomerMaster_Consignee(dataReader);
				} else {
					tbl_genCustomerMaster_Consigneeins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_Consigneeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Consignee table.
		/// </summary>
		public static List<tbl_genCustomerMaster_Consignee> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ConsigneeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerMaster_Consignee> tbl_genCustomerMaster_ConsigneeList = new List<tbl_genCustomerMaster_Consignee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Consignee tbl_genCustomerMaster_Consignee = Maketbl_genCustomerMaster_Consignee(dataReader);
					tbl_genCustomerMaster_ConsigneeList.Add(tbl_genCustomerMaster_Consignee);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_ConsigneeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Consignee table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerMaster_Consignee> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_ConsigneeSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genCustomerMaster_Consignee> tbl_genCustomerMaster_ConsigneeList = new List<tbl_genCustomerMaster_Consignee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Consignee tbl_genCustomerMaster_Consignee = Maketbl_genCustomerMaster_Consignee(dataReader);
					tbl_genCustomerMaster_ConsigneeList.Add(tbl_genCustomerMaster_Consignee);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_ConsigneeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerMaster_Consignee class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerMaster_Consignee Maketbl_genCustomerMaster_Consignee(SqlDataReader dataReader) {
			tbl_genCustomerMaster_Consignee tbl_genCustomerMaster_Consignee = new tbl_genCustomerMaster_Consignee();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerMaster_Consignee.LinNo = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerMaster_Consignee.Customer_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCustomerMaster_Consignee.ConsigneeName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCustomerMaster_Consignee.ConsigneeAddress = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCustomerMaster_Consignee.VatRegistrationNo = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCustomerMaster_Consignee.SvatRegistrationNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCustomerMaster_Consignee.IsMainConsignee = dataReader.GetBoolean(6);
			}

			return tbl_genCustomerMaster_Consignee;
		}
		/// <summary>
		/// This makes tbl_genCustomerMaster_Consignee datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Consignee object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerMaster_Consignee  tbl_genCustomerMaster_Consignee   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_linNo = new DataColumn("linNo" , typeof(int));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_consigneeName = new DataColumn("consigneeName" , typeof(string));
			DataColumn col_consigneeAddress = new DataColumn("consigneeAddress" , typeof(string));
			DataColumn col_vatRegistrationNo = new DataColumn("vatRegistrationNo" , typeof(string));
			DataColumn col_svatRegistrationNo = new DataColumn("svatRegistrationNo" , typeof(string));
			DataColumn col_isMainConsignee = new DataColumn("isMainConsignee" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_linNo,col_customer_ID,col_consigneeName,col_consigneeAddress,col_vatRegistrationNo,col_svatRegistrationNo,col_isMainConsignee,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerMaster_Consignee datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Consignee object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerMaster_Consignee user) {
		DataRow drow = dt.NewRow();
		
			drow["linNo"] = user.linNo;
			drow["customer_ID"] = user.customer_ID;
			drow["consigneeName"] = user.consigneeName;
			drow["consigneeAddress"] = user.consigneeAddress;
			drow["vatRegistrationNo"] = user.vatRegistrationNo;
			drow["svatRegistrationNo"] = user.svatRegistrationNo;
			drow["isMainConsignee"] = user.isMainConsignee;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
