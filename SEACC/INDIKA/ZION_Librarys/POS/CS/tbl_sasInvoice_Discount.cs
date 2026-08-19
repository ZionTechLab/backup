//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;

//namespace DataTire {
//	public sealed class tbl_sasInvoice_Discount1 {
//		#region Fields
//		private string invoice_ID;
//		private decimal subtotal;
//		private decimal discountPresentage1;
//		private decimal discountAmount1;
//		private decimal discountPresentage2;
//		private decimal discountAmount2;
//		private decimal discountPresentage3;
//		private decimal discountAmount3;
//		private decimal accumelatedTotalFinal;
//		#endregion
		
//		#region Constructors
//		/// <summary>
//		/// Initializes a new instance of the tbl_sasInvoice_Discount class.
//		/// </summary>
//		public tbl_sasInvoice_Discount1() {
//		}
		
//		/// <summary>
//		/// Initializes a new instance of the tbl_sasInvoice_Discount class.
//		/// </summary>
//		public tbl_sasInvoice_Discount1(string invoice_ID, decimal subtotal, decimal discountPresentage1, decimal discountAmount1, decimal discountPresentage2, decimal discountAmount2, decimal discountPresentage3, decimal discountAmount3, decimal accumelatedTotalFinal) {
//			this.invoice_ID = invoice_ID;
//			this.subtotal = subtotal;
//			this.discountPresentage1 = discountPresentage1;
//			this.discountAmount1 = discountAmount1;
//			this.discountPresentage2 = discountPresentage2;
//			this.discountAmount2 = discountAmount2;
//			this.discountPresentage3 = discountPresentage3;
//			this.discountAmount3 = discountAmount3;
//			this.accumelatedTotalFinal = accumelatedTotalFinal;
//		}
//		#endregion
		
//		#region Properties
//		/// <summary>
//		/// Gets or sets the Invoice_ID value.
//		/// </summary>
//		public string Invoice_ID {
//			get { return invoice_ID; }
//			set { invoice_ID = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the Subtotal value.
//		/// </summary>
//		public decimal Subtotal {
//			get { return subtotal; }
//			set { subtotal = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the DiscountPresentage1 value.
//		/// </summary>
//		public decimal DiscountPresentage1 {
//			get { return discountPresentage1; }
//			set { discountPresentage1 = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the DiscountAmount1 value.
//		/// </summary>
//		public decimal DiscountAmount1 {
//			get { return discountAmount1; }
//			set { discountAmount1 = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the DiscountPresentage2 value.
//		/// </summary>
//		public decimal DiscountPresentage2 {
//			get { return discountPresentage2; }
//			set { discountPresentage2 = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the DiscountAmount2 value.
//		/// </summary>
//		public decimal DiscountAmount2 {
//			get { return discountAmount2; }
//			set { discountAmount2 = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the DiscountPresentage3 value.
//		/// </summary>
//		public decimal DiscountPresentage3 {
//			get { return discountPresentage3; }
//			set { discountPresentage3 = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the DiscountAmount3 value.
//		/// </summary>
//		public decimal DiscountAmount3 {
//			get { return discountAmount3; }
//			set { discountAmount3 = value; }
//		}
		
//		/// <summary>
//		/// Gets or sets the AccumelatedTotalFinal value.
//		/// </summary>
//		public decimal AccumelatedTotalFinal {
//			get { return accumelatedTotalFinal; }
//			set { accumelatedTotalFinal = value; }
//		}
//		#endregion
		
//		#region Methods
//		/// <summary>
//		/// Saves a record to the tbl_sasInvoice_Discount table.
//		/// </summary>
//		public void Insert() {
 
//			SqlConnection scon = DBHandling.GetConnection();
//			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DiscountInsert", scon);
//			scom.CommandType = CommandType.StoredProcedure;
 
 
//			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
//			scom.Parameters.Add("@subtotal", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountPresentage1", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountAmount1", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountPresentage2", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountAmount2", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountPresentage3", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountAmount3", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@accumelatedTotalFinal", SqlDbType.Decimal,9);
 
//			scom.Parameters["@invoice_ID"].Value = invoice_ID;
//			scom.Parameters["@subtotal"].Value = subtotal;
//			scom.Parameters["@discountPresentage1"].Value = discountPresentage1;
//			scom.Parameters["@discountAmount1"].Value = discountAmount1;
//			scom.Parameters["@discountPresentage2"].Value = discountPresentage2;
//			scom.Parameters["@discountAmount2"].Value = discountAmount2;
//			scom.Parameters["@discountPresentage3"].Value = discountPresentage3;
//			scom.Parameters["@discountAmount3"].Value = discountAmount3;
//			scom.Parameters["@accumelatedTotalFinal"].Value = accumelatedTotalFinal;
 
 
//			scon.Open();
//			scom.ExecuteNonQuery();
//			scon.Close();
//		}
		
//		/// <summary>
//		/// Updates a record in the tbl_sasInvoice_Discount table.
//		/// </summary>
//		public void Update() {
 
//			SqlConnection scon = DBHandling.GetConnection();
//			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DiscountUpdate", scon);
//			scom.CommandType = CommandType.StoredProcedure;
 
 
//			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
//			scom.Parameters.Add("@subtotal", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountPresentage1", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountAmount1", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountPresentage2", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountAmount2", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountPresentage3", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@discountAmount3", SqlDbType.Decimal,9);
//			scom.Parameters.Add("@accumelatedTotalFinal", SqlDbType.Decimal,9);
 
 
//			scom.Parameters["@invoice_ID"].Value = invoice_ID;
//			scom.Parameters["@subtotal"].Value = subtotal;
//			scom.Parameters["@discountPresentage1"].Value = discountPresentage1;
//			scom.Parameters["@discountAmount1"].Value = discountAmount1;
//			scom.Parameters["@discountPresentage2"].Value = discountPresentage2;
//			scom.Parameters["@discountAmount2"].Value = discountAmount2;
//			scom.Parameters["@discountPresentage3"].Value = discountPresentage3;
//			scom.Parameters["@discountAmount3"].Value = discountAmount3;
//			scom.Parameters["@accumelatedTotalFinal"].Value = accumelatedTotalFinal;
 
 
//			scon.Open();
//			scom.ExecuteNonQuery();
//			scon.Close();
//		}
		
//		/// <summary>
//		/// Deletes a record from the tbl_sasInvoice_Discount table by its primary key.
//		/// </summary>
//		public void Delete() {
 
//			SqlConnection scon = DBHandling.GetConnection();
//			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DiscountDelete", scon);
//			scom.CommandType = CommandType.StoredProcedure;
 
//			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
//			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
//			scon.Open();
//			scom.ExecuteNonQuery();
//			scon.Close();
//		}
		
//		/// <summary>
//		/// Selects a single record from the tbl_sasInvoice_Discount table.
//		/// </summary>
//		public static tbl_sasInvoice_Discount1 Select(string invoice_ID_Incoming){

//			tbl_sasInvoice_Discount1 tbl_sasInvoice_Discountins = new tbl_sasInvoice_Discount();
//			SqlConnection scon = DBHandling.GetConnection();
//			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DiscountSelect", scon);
//			scom.CommandType = CommandType.StoredProcedure;
//			scon.Open();
 
//			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
//			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
//			using (SqlDataReader dataReader = scom.ExecuteReader()){
//				if (dataReader.Read()) {
//					tbl_sasInvoice_Discountins = Maketbl_sasInvoice_Discount(dataReader);
//				} else {
//					tbl_sasInvoice_Discountins = null;
//				}
//			}
//			scon.Close();
//			return tbl_sasInvoice_Discountins;
//		}
		
//		/// <summary>
//		/// Selects all records from the tbl_sasInvoice_Discount table.
//		/// </summary>
//		public static List<tbl_sasInvoice_Discount> SelectAll() {
 
//			SqlConnection scon = DBHandling.GetConnection();
//			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DiscountSelectAll", scon);
//			scom.CommandType = CommandType.StoredProcedure;
//			scon.Open();
 
//				List<tbl_sasInvoice_Discount> tbl_sasInvoice_DiscountList = new List<tbl_sasInvoice_Discount>();
//			using (SqlDataReader dataReader = scom.ExecuteReader()){
//				while (dataReader.Read()) {
//					tbl_sasInvoice_Discount tbl_sasInvoice_Discount = Maketbl_sasInvoice_Discount(dataReader);
//					tbl_sasInvoice_DiscountList.Add(tbl_sasInvoice_Discount);
//				}
//			}
//			scon.Close();
//			return tbl_sasInvoice_DiscountList;
//		}
		
//		/// <summary>
//		/// Creates a new instance of the tbl_sasInvoice_Discount class and populates it with data from the specified SqlDataReader.
//		/// </summary>
//		private static tbl_sasInvoice_Discount Maketbl_sasInvoice_Discount(SqlDataReader dataReader) {
//			tbl_sasInvoice_Discount tbl_sasInvoice_Discount = new tbl_sasInvoice_Discount();
			
//			if (dataReader.IsDBNull(0) == false) {
//				tbl_sasInvoice_Discount.Invoice_ID = dataReader.GetString(0);
//			}
//			if (dataReader.IsDBNull(1) == false) {
//				tbl_sasInvoice_Discount.Subtotal = dataReader.GetDecimal(1);
//			}
//			if (dataReader.IsDBNull(2) == false) {
//				tbl_sasInvoice_Discount.DiscountPresentage1 = dataReader.GetDecimal(2);
//			}
//			if (dataReader.IsDBNull(3) == false) {
//				tbl_sasInvoice_Discount.DiscountAmount1 = dataReader.GetDecimal(3);
//			}
//			if (dataReader.IsDBNull(4) == false) {
//				tbl_sasInvoice_Discount.DiscountPresentage2 = dataReader.GetDecimal(4);
//			}
//			if (dataReader.IsDBNull(5) == false) {
//				tbl_sasInvoice_Discount.DiscountAmount2 = dataReader.GetDecimal(5);
//			}
//			if (dataReader.IsDBNull(6) == false) {
//				tbl_sasInvoice_Discount.DiscountPresentage3 = dataReader.GetDecimal(6);
//			}
//			if (dataReader.IsDBNull(7) == false) {
//				tbl_sasInvoice_Discount.DiscountAmount3 = dataReader.GetDecimal(7);
//			}
//			if (dataReader.IsDBNull(8) == false) {
//				tbl_sasInvoice_Discount.AccumelatedTotalFinal = dataReader.GetDecimal(8);
//			}

//			return tbl_sasInvoice_Discount;
//		}
//		/// <summary>
//		/// This makes tbl_sasInvoice_Discount datatable according to the datatable.
//		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
//		///            We are still humans
//		/// </summary>
//		/// <param name="user">new tbl_sasInvoice_Discount object</param>
//		/// <returns></returns>
//		public static DataTable CreateDataTable( tbl_sasInvoice_Discount  tbl_sasInvoice_Discount   )
//		{
//		DataTable dt = new DataTable();
		
//			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
//			DataColumn col_subtotal = new DataColumn("subtotal" , typeof(decimal));
//			DataColumn col_discountPresentage1 = new DataColumn("discountPresentage1" , typeof(decimal));
//			DataColumn col_discountAmount1 = new DataColumn("discountAmount1" , typeof(decimal));
//			DataColumn col_discountPresentage2 = new DataColumn("discountPresentage2" , typeof(decimal));
//			DataColumn col_discountAmount2 = new DataColumn("discountAmount2" , typeof(decimal));
//			DataColumn col_discountPresentage3 = new DataColumn("discountPresentage3" , typeof(decimal));
//			DataColumn col_discountAmount3 = new DataColumn("discountAmount3" , typeof(decimal));
//			DataColumn col_accumelatedTotalFinal = new DataColumn("accumelatedTotalFinal" , typeof(decimal));
//		dt.Columns.AddRange(new DataColumn[] { col_invoice_ID,col_subtotal,col_discountPresentage1,col_discountAmount1,col_discountPresentage2,col_discountAmount2,col_discountPresentage3,col_discountAmount3,col_accumelatedTotalFinal,});		return dt;
//		}
//		/// <summary>
//		/// This fills tbl_sasInvoice_Discount datatable according to the Given user list.
//		/// </summary>
//		/// <param name="user">new tbl_sasInvoice_Discount object</param>
//		/// <returns></returns>
//		public static void FillData(DataTable dt, tbl_sasInvoice_Discount user) {
//		DataRow drow = dt.NewRow();
		
//			drow["invoice_ID"] = user.invoice_ID;
//			drow["subtotal"] = user.subtotal;
//			drow["discountPresentage1"] = user.discountPresentage1;
//			drow["discountAmount1"] = user.discountAmount1;
//			drow["discountPresentage2"] = user.discountPresentage2;
//			drow["discountAmount2"] = user.discountAmount2;
//			drow["discountPresentage3"] = user.discountPresentage3;
//			drow["discountAmount3"] = user.discountAmount3;
//			drow["accumelatedTotalFinal"] = user.accumelatedTotalFinal;
//		dt.Rows.Add(drow);
//		}
//		#endregion
//	}
//}
