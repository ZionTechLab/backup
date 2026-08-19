using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCustomerDiscount {
		#region Fields
		private string customer_ID;
		private string discount_Id;
		private decimal discountPresentage;
		private bool isRateLocked;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerDiscount class.
		/// </summary>
		public tbl_genCustomerDiscount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerDiscount class.
		/// </summary>
		public tbl_genCustomerDiscount(string customer_ID, string discount_Id, decimal discountPresentage, bool isRateLocked, bool isActive) {
			this.customer_ID = customer_ID;
			this.discount_Id = discount_Id;
			this.discountPresentage = discountPresentage;
			this.isRateLocked = isRateLocked;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Discount_Id value.
		/// </summary>
		public string Discount_Id {
			get { return discount_Id; }
			set { discount_Id = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPresentage value.
		/// </summary>
		public decimal DiscountPresentage {
			get { return discountPresentage; }
			set { discountPresentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRateLocked value.
		/// </summary>
		public bool IsRateLocked {
			get { return isRateLocked; }
			set { isRateLocked = value; }
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
		/// Saves a record to the tbl_genCustomerDiscount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isRateLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@discount_Id"].Value = discount_Id;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@isRateLocked"].Value = isRateLocked;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerDiscount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isRateLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@discount_Id"].Value = discount_Id;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@isRateLocked"].Value = isRateLocked;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerDiscount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.Parameters["@discount_Id"].Value = discount_Id;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerDiscount table by a foreign key.
		/// </summary>
		public static void DeleteAllByDiscount_Id(string discount_Id) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountDeleteAllByDiscount_Id", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters["@discount_Id"].Value = discount_Id;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerDiscount table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			//scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerDiscount table.
		/// </summary>
		public static tbl_genCustomerDiscount Select(string customer_ID_Incoming, string discount_Id_Incoming){

			tbl_genCustomerDiscount tbl_genCustomerDiscountins = new tbl_genCustomerDiscount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			scom.Parameters["@discount_Id"].Value = discount_Id_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerDiscountins = Maketbl_genCustomerDiscount(dataReader);
				} else {
					tbl_genCustomerDiscountins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerDiscountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerDiscount table.
		/// </summary>
		public static List<tbl_genCustomerDiscount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerDiscount> tbl_genCustomerDiscountList = new List<tbl_genCustomerDiscount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerDiscount tbl_genCustomerDiscount = Maketbl_genCustomerDiscount(dataReader);
					tbl_genCustomerDiscountList.Add(tbl_genCustomerDiscount);
				}
			}
			scon.Close();
			return tbl_genCustomerDiscountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerDiscount table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerDiscount> SelectAllByDiscount_Id(string discount_Id) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountSelectAllByDiscount_Id", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters["@discount_Id"].Value = discount_Id;
				List<tbl_genCustomerDiscount> tbl_genCustomerDiscountList = new List<tbl_genCustomerDiscount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerDiscount tbl_genCustomerDiscount = Maketbl_genCustomerDiscount(dataReader);
					tbl_genCustomerDiscountList.Add(tbl_genCustomerDiscount);
				}
			}
			scon.Close();
			return tbl_genCustomerDiscountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerDiscount table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerDiscount> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerDiscountSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genCustomerDiscount> tbl_genCustomerDiscountList = new List<tbl_genCustomerDiscount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerDiscount tbl_genCustomerDiscount = Maketbl_genCustomerDiscount(dataReader);
					tbl_genCustomerDiscountList.Add(tbl_genCustomerDiscount);
				}
			}
			scon.Close();
			return tbl_genCustomerDiscountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerDiscount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerDiscount Maketbl_genCustomerDiscount(SqlDataReader dataReader) {
			tbl_genCustomerDiscount tbl_genCustomerDiscount = new tbl_genCustomerDiscount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerDiscount.Customer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerDiscount.Discount_Id = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCustomerDiscount.DiscountPresentage = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCustomerDiscount.IsRateLocked = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCustomerDiscount.IsActive = dataReader.GetBoolean(4);
			}

			return tbl_genCustomerDiscount;
		}
		/// <summary>
		/// This makes tbl_genCustomerDiscount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerDiscount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerDiscount  tbl_genCustomerDiscount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_discount_Id = new DataColumn("discount_Id" , typeof(string));
			DataColumn col_discountPresentage = new DataColumn("discountPresentage" , typeof(decimal));
			DataColumn col_isRateLocked = new DataColumn("isRateLocked" , typeof(bool));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_customer_ID,col_discount_Id,col_discountPresentage,col_isRateLocked,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerDiscount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerDiscount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerDiscount user) {
		DataRow drow = dt.NewRow();
		
			drow["customer_ID"] = user.customer_ID;
			drow["discount_Id"] = user.discount_Id;
			drow["discountPresentage"] = user.discountPresentage;
			drow["isRateLocked"] = user.isRateLocked;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
