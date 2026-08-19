using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCancelReson_DO {
		#region Fields
		private string cancelReason_ID_DO;
		private string cancelReasonName;
		private bool isPermanentCancel;
		private bool isRepeatDelivery;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCancelReson_DO class.
		/// </summary>
		public tbl_zCancelReson_DO() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCancelReson_DO class.
		/// </summary>
		public tbl_zCancelReson_DO(string cancelReason_ID_DO, string cancelReasonName, bool isPermanentCancel, bool isRepeatDelivery) {
			this.cancelReason_ID_DO = cancelReason_ID_DO;
			this.cancelReasonName = cancelReasonName;
			this.isPermanentCancel = isPermanentCancel;
			this.isRepeatDelivery = isRepeatDelivery;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CancelReason_ID_DO value.
		/// </summary>
		public string CancelReason_ID_DO {
			get { return cancelReason_ID_DO; }
			set { cancelReason_ID_DO = value; }
		}
		
		/// <summary>
		/// Gets or sets the CancelReasonName value.
		/// </summary>
		public string CancelReasonName {
			get { return cancelReasonName; }
			set { cancelReasonName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPermanentCancel value.
		/// </summary>
		public bool IsPermanentCancel {
			get { return isPermanentCancel; }
			set { isPermanentCancel = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRepeatDelivery value.
		/// </summary>
		public bool IsRepeatDelivery {
			get { return isRepeatDelivery; }
			set { isRepeatDelivery = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCancelReson_DO table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCancelReson_DOInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cancelReasonName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isPermanentCancel", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRepeatDelivery", SqlDbType.Bit,1);
 
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
			scom.Parameters["@cancelReasonName"].Value = cancelReasonName;
			scom.Parameters["@isPermanentCancel"].Value = isPermanentCancel;
			scom.Parameters["@isRepeatDelivery"].Value = isRepeatDelivery;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCancelReson_DO table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCancelReson_DOUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cancelReasonName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isPermanentCancel", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRepeatDelivery", SqlDbType.Bit,1);
 
 
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
			scom.Parameters["@cancelReasonName"].Value = cancelReasonName;
			scom.Parameters["@isPermanentCancel"].Value = isPermanentCancel;
			scom.Parameters["@isRepeatDelivery"].Value = isRepeatDelivery;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCancelReson_DO table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCancelReson_DODelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCancelReson_DO table.
		/// </summary>
		public static tbl_zCancelReson_DO Select(string cancelReason_ID_DO_Incoming){

			tbl_zCancelReson_DO tbl_zCancelReson_DOins = new tbl_zCancelReson_DO();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCancelReson_DOSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCancelReson_DOins = Maketbl_zCancelReson_DO(dataReader);
				} else {
					tbl_zCancelReson_DOins = null;
				}
			}
			scon.Close();
			return tbl_zCancelReson_DOins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCancelReson_DO table.
		/// </summary>
		public static List<tbl_zCancelReson_DO> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCancelReson_DOSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCancelReson_DO> tbl_zCancelReson_DOList = new List<tbl_zCancelReson_DO>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCancelReson_DO tbl_zCancelReson_DO = Maketbl_zCancelReson_DO(dataReader);
					tbl_zCancelReson_DOList.Add(tbl_zCancelReson_DO);
				}
			}
			scon.Close();
			return tbl_zCancelReson_DOList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCancelReson_DO class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCancelReson_DO Maketbl_zCancelReson_DO(SqlDataReader dataReader) {
			tbl_zCancelReson_DO tbl_zCancelReson_DO = new tbl_zCancelReson_DO();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCancelReson_DO.CancelReason_ID_DO = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCancelReson_DO.CancelReasonName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zCancelReson_DO.IsPermanentCancel = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zCancelReson_DO.IsRepeatDelivery = dataReader.GetBoolean(3);
			}

			return tbl_zCancelReson_DO;
		}
		/// <summary>
		/// This makes tbl_zCancelReson_DO datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCancelReson_DO object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCancelReson_DO  tbl_zCancelReson_DO   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_cancelReason_ID_DO = new DataColumn("cancelReason_ID_DO" , typeof(string));
			DataColumn col_cancelReasonName = new DataColumn("cancelReasonName" , typeof(string));
			DataColumn col_isPermanentCancel = new DataColumn("isPermanentCancel" , typeof(bool));
			DataColumn col_isRepeatDelivery = new DataColumn("isRepeatDelivery" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_cancelReason_ID_DO,col_cancelReasonName,col_isPermanentCancel,col_isRepeatDelivery,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCancelReson_DO datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCancelReson_DO object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCancelReson_DO user) {
		DataRow drow = dt.NewRow();
		
			drow["cancelReason_ID_DO"] = user.cancelReason_ID_DO;
			drow["cancelReasonName"] = user.cancelReasonName;
			drow["isPermanentCancel"] = user.isPermanentCancel;
			drow["isRepeatDelivery"] = user.isRepeatDelivery;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
