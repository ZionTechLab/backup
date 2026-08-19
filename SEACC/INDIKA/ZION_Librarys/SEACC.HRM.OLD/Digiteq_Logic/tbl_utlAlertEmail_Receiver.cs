using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlertEmail_Receiver {
		#region Fields
		private int eMail_ID;
		private int receiver_index;
		private int type;
		private string emailAddress;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertEmail_Receiver class.
		/// </summary>
		public tbl_utlAlertEmail_Receiver() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertEmail_Receiver class.
		/// </summary>
		public tbl_utlAlertEmail_Receiver(int eMail_ID, int receiver_index, int type, string emailAddress) {
			this.eMail_ID = eMail_ID;
			this.receiver_index = receiver_index;
			this.type = type;
			this.emailAddress = emailAddress;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the EMail_ID value.
		/// </summary>
		public int EMail_ID {
			get { return eMail_ID; }
			set { eMail_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receiver_index value.
		/// </summary>
		public int Receiver_index {
			get { return receiver_index; }
			set { receiver_index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Type value.
		/// </summary>
		public int Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailAddress value.
		/// </summary>
		public string EmailAddress {
			get { return emailAddress; }
			set { emailAddress = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlertEmail_Receiver table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmail_ReceiverInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@receiver_index", SqlDbType.Int,4);
			scom.Parameters.Add("@type", SqlDbType.Int,4);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,500);
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@receiver_index"].Value = receiver_index;
			scom.Parameters["@type"].Value = type;
			scom.Parameters["@emailAddress"].Value = emailAddress;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlertEmail_Receiver table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmail_ReceiverUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@receiver_index", SqlDbType.Int,4);
			scom.Parameters.Add("@type", SqlDbType.Int,4);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@receiver_index"].Value = receiver_index;
			scom.Parameters["@type"].Value = type;
			scom.Parameters["@emailAddress"].Value = emailAddress;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlertEmail_Receiver table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmail_ReceiverDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@receiver_index", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
			scom.Parameters["@receiver_index"].Value = receiver_index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertEmail_Receiver table by a foreign key.
		/// </summary>
		public static void DeleteAllByEMail_ID(int eMail_ID) {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmail_ReceiverDeleteAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlertEmail_Receiver table.
		/// </summary>
		public static tbl_utlAlertEmail_Receiver Select(int eMail_ID_Incoming){, int receiver_index_Incoming){

			tbl_utlAlertEmail_Receiver tbl_utlAlertEmail_Receiverins = new tbl_utlAlertEmail_Receiver();
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmail_ReceiverSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@receiver_index", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID_Incoming;
			scom.Parameters["@receiver_index"].Value = receiver_index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertEmail_Receiverins = Maketbl_utlAlertEmail_Receiver(dataReader);
				} else {
					tbl_utlAlertEmail_Receiverins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertEmail_Receiverins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertEmail_Receiver table.
		/// </summary>
		public static List<tbl_utlAlertEmail_Receiver> SelectAll() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmail_ReceiverSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlertEmail_Receiver> tbl_utlAlertEmail_ReceiverList = new List<tbl_utlAlertEmail_Receiver>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertEmail_Receiver tbl_utlAlertEmail_Receiver = Maketbl_utlAlertEmail_Receiver(dataReader);
					tbl_utlAlertEmail_ReceiverList.Add(tbl_utlAlertEmail_Receiver);
				}
			}
			scon.Close();
			return tbl_utlAlertEmail_ReceiverList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertEmail_Receiver table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlertEmail_Receiver> SelectAllByEMail_ID(int eMail_ID) {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmail_ReceiverSelectAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
				List<tbl_utlAlertEmail_Receiver> tbl_utlAlertEmail_ReceiverList = new List<tbl_utlAlertEmail_Receiver>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertEmail_Receiver tbl_utlAlertEmail_Receiver = Maketbl_utlAlertEmail_Receiver(dataReader);
					tbl_utlAlertEmail_ReceiverList.Add(tbl_utlAlertEmail_Receiver);
				}
			}
			scon.Close();
			return tbl_utlAlertEmail_ReceiverList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlertEmail_Receiver class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlertEmail_Receiver Maketbl_utlAlertEmail_Receiver(SqlDataReader dataReader) {
			tbl_utlAlertEmail_Receiver tbl_utlAlertEmail_Receiver = new tbl_utlAlertEmail_Receiver();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlertEmail_Receiver.EMail_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlertEmail_Receiver.Receiver_index = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlertEmail_Receiver.Type = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlertEmail_Receiver.EmailAddress = dataReader.GetString(3);
			}

			return tbl_utlAlertEmail_Receiver;
		}
		/// <summary>
		/// This makes tbl_utlAlertEmail_Receiver datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlertEmail_Receiver object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlertEmail_Receiver  tbl_utlAlertEmail_Receiver   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(int));
			DataColumn col_receiver_index = new DataColumn("receiver_index" , typeof(int));
			DataColumn col_type = new DataColumn("type" , typeof(int));
			DataColumn col_emailAddress = new DataColumn("emailAddress" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_eMail_ID,col_receiver_index,col_type,col_emailAddress,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlertEmail_Receiver datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlertEmail_Receiver object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlertEmail_Receiver user) {
		DataRow drow = dt.NewRow();
		
			drow["eMail_ID"] = user.eMail_ID;
			drow["receiver_index"] = user.receiver_index;
			drow["type"] = user.type;
			drow["emailAddress"] = user.emailAddress;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
