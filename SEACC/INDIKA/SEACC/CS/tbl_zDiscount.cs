using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zDiscount {
		#region Fields
		private string discount_Id;
		private string discountName;
		private decimal discountPresentage;
		private string discountGL_ID;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zDiscount class.
		/// </summary>
		public tbl_zDiscount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zDiscount class.
		/// </summary>
		public tbl_zDiscount(string discount_Id, string discountName, decimal discountPresentage, string discountGL_ID, bool isDeleted) {
			this.discount_Id = discount_Id;
			this.discountName = discountName;
			this.discountPresentage = discountPresentage;
			this.discountGL_ID = discountGL_ID;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Discount_Id value.
		/// </summary>
		public string Discount_Id {
			get { return discount_Id; }
			set { discount_Id = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountName value.
		/// </summary>
		public string DiscountName {
			get { return discountName; }
			set { discountName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPresentage value.
		/// </summary>
		public decimal DiscountPresentage {
			get { return discountPresentage; }
			set { discountPresentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountGL_ID value.
		/// </summary>
		public string DiscountGL_ID {
			get { return discountGL_ID; }
			set { discountGL_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zDiscount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDiscountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters.Add("@discountName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountGL_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@discount_Id"].Value = discount_Id;
			scom.Parameters["@discountName"].Value = discountName;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountGL_ID"].Value = discountGL_ID;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zDiscount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDiscountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters.Add("@discountName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountGL_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@discount_Id"].Value = discount_Id;
			scom.Parameters["@discountName"].Value = discountName;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountGL_ID"].Value = discountGL_ID;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zDiscount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDiscountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters["@discount_Id"].Value = discount_Id;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zDiscount table.
		/// </summary>
		public static tbl_zDiscount Select(string discount_Id_Incoming){

			tbl_zDiscount tbl_zDiscountins = new tbl_zDiscount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDiscountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@discount_Id", SqlDbType.VarChar,10);
			scom.Parameters["@discount_Id"].Value = discount_Id_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zDiscountins = Maketbl_zDiscount(dataReader);
				} else {
					tbl_zDiscountins = null;
				}
			}
			scon.Close();
			return tbl_zDiscountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDiscount table.
		/// </summary>
		public static List<tbl_zDiscount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDiscountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zDiscount> tbl_zDiscountList = new List<tbl_zDiscount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zDiscount tbl_zDiscount = Maketbl_zDiscount(dataReader);
					tbl_zDiscountList.Add(tbl_zDiscount);
				}
			}
			scon.Close();
			return tbl_zDiscountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zDiscount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zDiscount Maketbl_zDiscount(SqlDataReader dataReader) {
			tbl_zDiscount tbl_zDiscount = new tbl_zDiscount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zDiscount.Discount_Id = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zDiscount.DiscountName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zDiscount.DiscountPresentage = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zDiscount.DiscountGL_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zDiscount.IsDeleted = dataReader.GetBoolean(4);
			}

			return tbl_zDiscount;
		}
		/// <summary>
		/// This makes tbl_zDiscount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zDiscount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zDiscount  tbl_zDiscount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_discount_Id = new DataColumn("discount_Id" , typeof(string));
			DataColumn col_discountName = new DataColumn("discountName" , typeof(string));
			DataColumn col_discountPresentage = new DataColumn("discountPresentage" , typeof(decimal));
			DataColumn col_discountGL_ID = new DataColumn("discountGL_ID" , typeof(string));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_discount_Id,col_discountName,col_discountPresentage,col_discountGL_ID,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zDiscount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zDiscount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zDiscount user) {
		DataRow drow = dt.NewRow();
		
			drow["discount_Id"] = user.discount_Id;
			drow["discountName"] = user.discountName;
			drow["discountPresentage"] = user.discountPresentage;
			drow["discountGL_ID"] = user.discountGL_ID;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
