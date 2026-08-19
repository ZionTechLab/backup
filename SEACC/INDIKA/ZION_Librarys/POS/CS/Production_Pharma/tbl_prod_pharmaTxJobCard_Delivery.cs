using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxJobCard_Delivery {
		#region Fields
		private int line_No;
		private string prodJob_ID;
		private DateTime deliverDateTime;
		private int customerBranch_Line_No;
		private string deliverAddress;
		private decimal deliverQty;
		private string deliverUoM;
		private string deliverTerms;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_Delivery class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_Delivery() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_Delivery class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_Delivery(int line_No, string prodJob_ID, DateTime deliverDateTime, int customerBranch_Line_No, string deliverAddress, decimal deliverQty, string deliverUoM, string deliverTerms, string remarks) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.deliverDateTime = deliverDateTime;
			this.customerBranch_Line_No = customerBranch_Line_No;
			this.deliverAddress = deliverAddress;
			this.deliverQty = deliverQty;
			this.deliverUoM = deliverUoM;
			this.deliverTerms = deliverTerms;
			this.remarks = remarks;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverDateTime value.
		/// </summary>
		public DateTime DeliverDateTime {
			get { return deliverDateTime; }
			set { deliverDateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerBranch_Line_No value.
		/// </summary>
		public int CustomerBranch_Line_No {
			get { return customerBranch_Line_No; }
			set { customerBranch_Line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverAddress value.
		/// </summary>
		public string DeliverAddress {
			get { return deliverAddress; }
			set { deliverAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverQty value.
		/// </summary>
		public decimal DeliverQty {
			get { return deliverQty; }
			set { deliverQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverUoM value.
		/// </summary>
		public string DeliverUoM {
			get { return deliverUoM; }
			set { deliverUoM = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverTerms value.
		/// </summary>
		public string DeliverTerms {
			get { return deliverTerms; }
			set { deliverTerms = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxJobCard_Delivery table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliveryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliverDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerBranch_Line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliverAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliverQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliverUoM", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deliverTerms", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@deliverDateTime"].Value = deliverDateTime;
			scom.Parameters["@customerBranch_Line_No"].Value = customerBranch_Line_No;
			scom.Parameters["@deliverAddress"].Value = deliverAddress;
			scom.Parameters["@deliverQty"].Value = deliverQty;
			scom.Parameters["@deliverUoM"].Value = deliverUoM;
			scom.Parameters["@deliverTerms"].Value = deliverTerms;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxJobCard_Delivery table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliveryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliverDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerBranch_Line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliverAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliverQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliverUoM", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deliverTerms", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@deliverDateTime"].Value = deliverDateTime;
			scom.Parameters["@customerBranch_Line_No"].Value = customerBranch_Line_No;
			scom.Parameters["@deliverAddress"].Value = deliverAddress;
			scom.Parameters["@deliverQty"].Value = deliverQty;
			scom.Parameters["@deliverUoM"].Value = deliverUoM;
			scom.Parameters["@deliverTerms"].Value = deliverTerms;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxJobCard_Delivery table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliveryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliverUoM(string deliverUoM) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliveryDeleteAllByDeliverUoM", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@deliverUoM", SqlDbType.VarChar,10);
			scom.Parameters["@deliverUoM"].Value = deliverUoM;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliveryDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxJobCard_Delivery table.
		/// </summary>
		public static tbl_prod_pharmaTxJobCard_Delivery Select(int line_No_Incoming, string prodJob_ID_Incoming){

			tbl_prod_pharmaTxJobCard_Delivery tbl_prod_pharmaTxJobCard_Deliveryins = new tbl_prod_pharmaTxJobCard_Delivery();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliverySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_Deliveryins = Maketbl_prod_pharmaTxJobCard_Delivery(dataReader);
				} else {
					tbl_prod_pharmaTxJobCard_Deliveryins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_Deliveryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_Delivery table.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_Delivery> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliverySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxJobCard_Delivery> tbl_prod_pharmaTxJobCard_DeliveryList = new List<tbl_prod_pharmaTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_Delivery tbl_prod_pharmaTxJobCard_Delivery = Maketbl_prod_pharmaTxJobCard_Delivery(dataReader);
					tbl_prod_pharmaTxJobCard_DeliveryList.Add(tbl_prod_pharmaTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_Delivery> SelectAllByDeliverUoM(string deliverUoM) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliverySelectAllByDeliverUoM", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliverUoM", SqlDbType.VarChar,10);
			scom.Parameters["@deliverUoM"].Value = deliverUoM;
				List<tbl_prod_pharmaTxJobCard_Delivery> tbl_prod_pharmaTxJobCard_DeliveryList = new List<tbl_prod_pharmaTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_Delivery tbl_prod_pharmaTxJobCard_Delivery = Maketbl_prod_pharmaTxJobCard_Delivery(dataReader);
					tbl_prod_pharmaTxJobCard_DeliveryList.Add(tbl_prod_pharmaTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_Delivery> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_DeliverySelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxJobCard_Delivery> tbl_prod_pharmaTxJobCard_DeliveryList = new List<tbl_prod_pharmaTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_Delivery tbl_prod_pharmaTxJobCard_Delivery = Maketbl_prod_pharmaTxJobCard_Delivery(dataReader);
					tbl_prod_pharmaTxJobCard_DeliveryList.Add(tbl_prod_pharmaTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxJobCard_Delivery class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxJobCard_Delivery Maketbl_prod_pharmaTxJobCard_Delivery(SqlDataReader dataReader) {
			tbl_prod_pharmaTxJobCard_Delivery tbl_prod_pharmaTxJobCard_Delivery = new tbl_prod_pharmaTxJobCard_Delivery();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.DeliverDateTime = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.CustomerBranch_Line_No = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.DeliverAddress = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.DeliverQty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.DeliverUoM = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.DeliverTerms = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxJobCard_Delivery.Remarks = dataReader.GetString(8);
			}

			return tbl_prod_pharmaTxJobCard_Delivery;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxJobCard_Delivery datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_Delivery object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxJobCard_Delivery  tbl_prod_pharmaTxJobCard_Delivery   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_deliverDateTime = new DataColumn("deliverDateTime" , typeof(DateTime));
			DataColumn col_customerBranch_Line_No = new DataColumn("customerBranch_Line_No" , typeof(int));
			DataColumn col_deliverAddress = new DataColumn("deliverAddress" , typeof(string));
			DataColumn col_deliverQty = new DataColumn("deliverQty" , typeof(decimal));
			DataColumn col_deliverUoM = new DataColumn("deliverUoM" , typeof(string));
			DataColumn col_deliverTerms = new DataColumn("deliverTerms" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prodJob_ID,col_deliverDateTime,col_customerBranch_Line_No,col_deliverAddress,col_deliverQty,col_deliverUoM,col_deliverTerms,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxJobCard_Delivery datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_Delivery object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxJobCard_Delivery user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["deliverDateTime"] = user.deliverDateTime;
			drow["customerBranch_Line_No"] = user.customerBranch_Line_No;
			drow["deliverAddress"] = user.deliverAddress;
			drow["deliverQty"] = user.deliverQty;
			drow["deliverUoM"] = user.deliverUoM;
			drow["deliverTerms"] = user.deliverTerms;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
