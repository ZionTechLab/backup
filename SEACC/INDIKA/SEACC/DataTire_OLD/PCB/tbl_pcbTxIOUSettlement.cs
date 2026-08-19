using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbTxIOUSettlement {
		#region Fields
		private string iouSettlementID;
		private string expenditure_ID;
		private string iou_ID;
		private string refund_ID;
		private decimal allocatedAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxIOUSettlement class.
		/// </summary>
		public tbl_pcbTxIOUSettlement() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbTxIOUSettlement class.
		/// </summary>
		public tbl_pcbTxIOUSettlement(string iouSettlementID, string expenditure_ID, string iou_ID, string refund_ID, decimal allocatedAmount) {
			this.iouSettlementID = iouSettlementID;
			this.expenditure_ID = expenditure_ID;
			this.iou_ID = iou_ID;
			this.refund_ID = refund_ID;
			this.allocatedAmount = allocatedAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the IouSettlementID value.
		/// </summary>
		public string IouSettlementID {
			get { return iouSettlementID; }
			set { iouSettlementID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Expenditure_ID value.
		/// </summary>
		public string Expenditure_ID {
			get { return expenditure_ID; }
			set { expenditure_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Iou_ID value.
		/// </summary>
		public string Iou_ID {
			get { return iou_ID; }
			set { iou_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Refund_ID value.
		/// </summary>
		public string Refund_ID {
			get { return refund_ID; }
			set { refund_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllocatedAmount value.
		/// </summary>
		public decimal AllocatedAmount {
			get { return allocatedAmount; }
			set { allocatedAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pcbTxIOUSettlement table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iouSettlementID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@AllocatedAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@iouSettlementID"].Value = iouSettlementID;
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
			scom.Parameters["@iou_ID"].Value = iou_ID;
			scom.Parameters["@refund_ID"].Value = refund_ID;
			scom.Parameters["@AllocatedAmount"].Value = allocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pcbTxIOUSettlement table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iouSettlementID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@AllocatedAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@iouSettlementID"].Value = iouSettlementID;
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
			scom.Parameters["@iou_ID"].Value = iou_ID;
			scom.Parameters["@refund_ID"].Value = refund_ID;
			scom.Parameters["@AllocatedAmount"].Value = allocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pcbTxIOUSettlement table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@iouSettlementID", SqlDbType.VarChar,10);
			scom.Parameters["@iouSettlementID"].Value = iouSettlementID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOUSettlement table by a foreign key.
		/// </summary>
		public static void DeleteAllByExpenditure_ID(string expenditure_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementDeleteAllByExpenditure_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOUSettlement table by a foreign key.
		/// </summary>
		public static void DeleteAllByRefund_ID(string refund_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementDeleteAllByRefund_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters["@refund_ID"].Value = refund_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOUSettlement table by a foreign key.
		/// </summary>
		public static void DeleteAllByIou_ID(string iou_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementDeleteAllByIou_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iou_ID"].Value = iou_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbTxIOUSettlement table.
		/// </summary>
		public static tbl_pcbTxIOUSettlement Select(string iouSettlementID_Incoming){

			tbl_pcbTxIOUSettlement tbl_pcbTxIOUSettlementins = new tbl_pcbTxIOUSettlement();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouSettlementID", SqlDbType.VarChar,10);
			scom.Parameters["@iouSettlementID"].Value = iouSettlementID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbTxIOUSettlementins = Maketbl_pcbTxIOUSettlement(dataReader);
				} else {
					tbl_pcbTxIOUSettlementins = null;
				}
			}
			scon.Close();
			return tbl_pcbTxIOUSettlementins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOUSettlement table.
		/// </summary>
		public static List<tbl_pcbTxIOUSettlement> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbTxIOUSettlement> tbl_pcbTxIOUSettlementList = new List<tbl_pcbTxIOUSettlement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOUSettlement tbl_pcbTxIOUSettlement = Maketbl_pcbTxIOUSettlement(dataReader);
					tbl_pcbTxIOUSettlementList.Add(tbl_pcbTxIOUSettlement);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUSettlementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOUSettlement table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOUSettlement> SelectAllByExpenditure_ID(string expenditure_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementSelectAllByExpenditure_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@Expenditure_ID", SqlDbType.VarChar,10);
			scom.Parameters["@Expenditure_ID"].Value = expenditure_ID;
				List<tbl_pcbTxIOUSettlement> tbl_pcbTxIOUSettlementList = new List<tbl_pcbTxIOUSettlement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOUSettlement tbl_pcbTxIOUSettlement = Maketbl_pcbTxIOUSettlement(dataReader);
					tbl_pcbTxIOUSettlementList.Add(tbl_pcbTxIOUSettlement);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUSettlementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOUSettlement table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOUSettlement> SelectAllByRefund_ID(string refund_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementSelectAllByRefund_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@refund_ID", SqlDbType.VarChar,10);
			scom.Parameters["@refund_ID"].Value = refund_ID;
				List<tbl_pcbTxIOUSettlement> tbl_pcbTxIOUSettlementList = new List<tbl_pcbTxIOUSettlement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOUSettlement tbl_pcbTxIOUSettlement = Maketbl_pcbTxIOUSettlement(dataReader);
					tbl_pcbTxIOUSettlementList.Add(tbl_pcbTxIOUSettlement);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUSettlementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbTxIOUSettlement table by a foreign key.
		/// </summary>
		public static List<tbl_pcbTxIOUSettlement> SelectAllByIou_ID(string iou_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbTxIOUSettlementSelectAllByIou_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iou_ID", SqlDbType.VarChar,10);
			scom.Parameters["@iou_ID"].Value = iou_ID;
				List<tbl_pcbTxIOUSettlement> tbl_pcbTxIOUSettlementList = new List<tbl_pcbTxIOUSettlement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbTxIOUSettlement tbl_pcbTxIOUSettlement = Maketbl_pcbTxIOUSettlement(dataReader);
					tbl_pcbTxIOUSettlementList.Add(tbl_pcbTxIOUSettlement);
				}
			}
			scon.Close();
			return tbl_pcbTxIOUSettlementList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbTxIOUSettlement class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbTxIOUSettlement Maketbl_pcbTxIOUSettlement(SqlDataReader dataReader) {
			tbl_pcbTxIOUSettlement tbl_pcbTxIOUSettlement = new tbl_pcbTxIOUSettlement();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbTxIOUSettlement.IouSettlementID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbTxIOUSettlement.Expenditure_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbTxIOUSettlement.Iou_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbTxIOUSettlement.Refund_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbTxIOUSettlement.AllocatedAmount = dataReader.GetDecimal(4);
			}

			return tbl_pcbTxIOUSettlement;
		}
		/// <summary>
		/// This makes tbl_pcbTxIOUSettlement datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOUSettlement object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbTxIOUSettlement  tbl_pcbTxIOUSettlement   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_iouSettlementID = new DataColumn("iouSettlementID" , typeof(string));
			DataColumn col_Expenditure_ID = new DataColumn("Expenditure_ID" , typeof(string));
			DataColumn col_iou_ID = new DataColumn("iou_ID" , typeof(string));
			DataColumn col_refund_ID = new DataColumn("refund_ID" , typeof(string));
			DataColumn col_AllocatedAmount = new DataColumn("AllocatedAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_iouSettlementID,col_Expenditure_ID,col_iou_ID,col_refund_ID,col_AllocatedAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbTxIOUSettlement datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbTxIOUSettlement object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbTxIOUSettlement user) {
		DataRow drow = dt.NewRow();
		
			drow["iouSettlementID"] = user.iouSettlementID;
			drow["Expenditure_ID"] = user.Expenditure_ID;
			drow["iou_ID"] = user.iou_ID;
			drow["refund_ID"] = user.refund_ID;
			drow["AllocatedAmount"] = user.AllocatedAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
