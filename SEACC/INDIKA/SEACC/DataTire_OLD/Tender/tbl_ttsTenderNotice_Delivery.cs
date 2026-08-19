using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderNotice_Delivery {
		#region Fields
		private string tender_ID;
		private string serialNo;
		private string lineNo;
		private DateTime deliveryDate;
		private decimal deliveryQty;
		private string location;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderNotice_Delivery class.
		/// </summary>
		public tbl_ttsTenderNotice_Delivery() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderNotice_Delivery class.
		/// </summary>
		public tbl_ttsTenderNotice_Delivery(string tender_ID, string serialNo, string lineNo, DateTime deliveryDate, decimal deliveryQty, string location) {
			this.tender_ID = tender_ID;
			this.serialNo = serialNo;
			this.lineNo = lineNo;
			this.deliveryDate = deliveryDate;
			this.deliveryQty = deliveryQty;
			this.location = location;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo value.
		/// </summary>
		public string SerialNo {
			get { return serialNo; }
			set { serialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the LineNo value.
		/// </summary>
		public string LineNo {
			get { return lineNo; }
			set { lineNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryDate value.
		/// </summary>
		public DateTime DeliveryDate {
			get { return deliveryDate; }
			set { deliveryDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryQty value.
		/// </summary>
		public decimal DeliveryQty {
			get { return deliveryQty; }
			set { deliveryQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Location value.
		/// </summary>
		public string Location {
			get { return location; }
			set { location = value; }
		}
		#endregion
		

		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderNotice_Delivery table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliveryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@location", SqlDbType.VarChar,100);
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@deliveryDate"].Value = deliveryDate;
			scom.Parameters["@deliveryQty"].Value = deliveryQty;
			scom.Parameters["@location"].Value = location;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderNotice_Delivery table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliveryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@location", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@deliveryDate"].Value = deliveryDate;
			scom.Parameters["@deliveryQty"].Value = deliveryQty;
			scom.Parameters["@location"].Value = location;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderNotice_Delivery table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliveryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,100);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scom.Parameters["@serialNo"].Value = serialNo;
 
			scom.Parameters["@lineNo"].Value = lineNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Delivery table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID_SerialNo(string tender_ID, string serialNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliveryDeleteAllByTender_ID_SerialNo", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
 
			//scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
        public static void DeleteAllByTender_ID(string tender_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliveryDeleteAllByTender_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@tender_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@tender_ID"].Value = tender_ID;

           // scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderNotice_Delivery table.
		/// </summary>
		public static tbl_ttsTenderNotice_Delivery Select(string tender_ID_Incoming, string serialNo_Incoming, string lineNo_Incoming){

			tbl_ttsTenderNotice_Delivery tbl_ttsTenderNotice_Deliveryins = new tbl_ttsTenderNotice_Delivery();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliverySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,100);
			scom.Parameters["@tender_ID"].Value = tender_ID_Incoming;
			scom.Parameters["@serialNo"].Value = serialNo_Incoming;
			scom.Parameters["@lineNo"].Value = lineNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderNotice_Deliveryins = Maketbl_ttsTenderNotice_Delivery(dataReader);
				} else {
					tbl_ttsTenderNotice_Deliveryins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderNotice_Deliveryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Delivery table.
		/// </summary>
		public static List<tbl_ttsTenderNotice_Delivery> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliverySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderNotice_Delivery> tbl_ttsTenderNotice_DeliveryList = new List<tbl_ttsTenderNotice_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice_Delivery tbl_ttsTenderNotice_Delivery = Maketbl_ttsTenderNotice_Delivery(dataReader);
					tbl_ttsTenderNotice_DeliveryList.Add(tbl_ttsTenderNotice_Delivery);
				}
			}
			scon.Close();
			return tbl_ttsTenderNotice_DeliveryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Delivery table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice_Delivery> SelectAllByTender_ID_SerialNo(string tender_ID, string serialNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DeliverySelectAllByTender_ID_SerialNo", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
				List<tbl_ttsTenderNotice_Delivery> tbl_ttsTenderNotice_DeliveryList = new List<tbl_ttsTenderNotice_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice_Delivery tbl_ttsTenderNotice_Delivery = Maketbl_ttsTenderNotice_Delivery(dataReader);
					tbl_ttsTenderNotice_DeliveryList.Add(tbl_ttsTenderNotice_Delivery);
				}
			}
			scon.Close();
			return tbl_ttsTenderNotice_DeliveryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderNotice_Delivery class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderNotice_Delivery Maketbl_ttsTenderNotice_Delivery(SqlDataReader dataReader) {
			tbl_ttsTenderNotice_Delivery tbl_ttsTenderNotice_Delivery = new tbl_ttsTenderNotice_Delivery();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderNotice_Delivery.Tender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderNotice_Delivery.SerialNo = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderNotice_Delivery.LineNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderNotice_Delivery.DeliveryDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderNotice_Delivery.DeliveryQty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsTenderNotice_Delivery.Location = dataReader.GetString(5);
			}

			return tbl_ttsTenderNotice_Delivery;
		}
		/// <summary>
		/// This makes tbl_ttsTenderNotice_Delivery datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderNotice_Delivery object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderNotice_Delivery  tbl_ttsTenderNotice_Delivery   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_serialNo = new DataColumn("serialNo" , typeof(string));
			DataColumn col_lineNo = new DataColumn("lineNo" , typeof(string));
			DataColumn col_deliveryDate = new DataColumn("deliveryDate" , typeof(DateTime));
			DataColumn col_deliveryQty = new DataColumn("deliveryQty" , typeof(decimal));
			DataColumn col_location = new DataColumn("location" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_tender_ID,col_serialNo,col_lineNo,col_deliveryDate,col_deliveryQty,col_location,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderNotice_Delivery datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderNotice_Delivery object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderNotice_Delivery user) {
		DataRow drow = dt.NewRow();
		
			drow["tender_ID"] = user.tender_ID;
			drow["serialNo"] = user.serialNo;
			drow["lineNo"] = user.lineNo;
			drow["deliveryDate"] = user.deliveryDate;
			drow["deliveryQty"] = user.deliveryQty;
			drow["location"] = user.location;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
