using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlertMailBox_Receiver {
		#region Fields
		private int eMail_ID;
		private int receiver_index;
		private int type;
		private string name;
		private string emailAddress;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Receiver class.
		/// </summary>
		public tbl_utlAlertMailBox_Receiver() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Receiver class.
		/// </summary>
		public tbl_utlAlertMailBox_Receiver(int eMail_ID, int receiver_index, int type, string name, string emailAddress) {
			this.eMail_ID = eMail_ID;
			this.receiver_index = receiver_index;
			this.type = type;
			this.name = name;
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
		/// Gets or sets the Name value.
		/// </summary>
		public string Name {
			get { return name; }
			set { name = value; }
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
		/// Saves a record to the tbl_utlAlertMailBox_Receiver table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ReceiverInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@receiver_index", SqlDbType.Int,4);
			scom.Parameters.Add("@type", SqlDbType.Int,4);
			scom.Parameters.Add("@name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,100);
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@receiver_index"].Value = receiver_index;
			scom.Parameters["@type"].Value = type;
			scom.Parameters["@name"].Value = name;
			scom.Parameters["@emailAddress"].Value = emailAddress;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlertMailBox_Receiver table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ReceiverUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@receiver_index", SqlDbType.Int,4);
			scom.Parameters.Add("@type", SqlDbType.Int,4);
			scom.Parameters.Add("@name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@receiver_index"].Value = receiver_index;
			scom.Parameters["@type"].Value = type;
			scom.Parameters["@name"].Value = name;
			scom.Parameters["@emailAddress"].Value = emailAddress;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlertMailBox_Receiver table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ReceiverDelete", scon);
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
		/// Selects a single record from the tbl_utlAlertMailBox_Receiver table.
		/// </summary>
		public static tbl_utlAlertMailBox_Receiver Select(int eMail_ID_Incoming, int receiver_index_Incoming){

			tbl_utlAlertMailBox_Receiver tbl_utlAlertMailBox_Receiverins = new tbl_utlAlertMailBox_Receiver();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ReceiverSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@receiver_index", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID_Incoming;
			scom.Parameters["@receiver_index"].Value = receiver_index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertMailBox_Receiverins = Maketbl_utlAlertMailBox_Receiver(dataReader);
				} else {
					tbl_utlAlertMailBox_Receiverins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_Receiverins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertMailBox_Receiver table.
		/// </summary>
		public static List<tbl_utlAlertMailBox_Receiver> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ReceiverSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlertMailBox_Receiver> tbl_utlAlertMailBox_ReceiverList = new List<tbl_utlAlertMailBox_Receiver>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertMailBox_Receiver tbl_utlAlertMailBox_Receiver = Maketbl_utlAlertMailBox_Receiver(dataReader);
					tbl_utlAlertMailBox_ReceiverList.Add(tbl_utlAlertMailBox_Receiver);
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_ReceiverList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlertMailBox_Receiver class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlertMailBox_Receiver Maketbl_utlAlertMailBox_Receiver(SqlDataReader dataReader) {
			tbl_utlAlertMailBox_Receiver tbl_utlAlertMailBox_Receiver = new tbl_utlAlertMailBox_Receiver();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlertMailBox_Receiver.EMail_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlertMailBox_Receiver.Receiver_index = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlertMailBox_Receiver.Type = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlertMailBox_Receiver.Name = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlertMailBox_Receiver.EmailAddress = dataReader.GetString(4);
			}

			return tbl_utlAlertMailBox_Receiver;
		}
		/// <summary>
		/// This makes tbl_utlAlertMailBox_Receiver datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Receiver object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlertMailBox_Receiver  tbl_utlAlertMailBox_Receiver   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(int));
			DataColumn col_receiver_index = new DataColumn("receiver_index" , typeof(int));
			DataColumn col_type = new DataColumn("type" , typeof(int));
			DataColumn col_name = new DataColumn("name" , typeof(string));
			DataColumn col_emailAddress = new DataColumn("emailAddress" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_eMail_ID,col_receiver_index,col_type,col_name,col_emailAddress,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlertMailBox_Receiver datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Receiver object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlertMailBox_Receiver user) {
		DataRow drow = dt.NewRow();
		
			drow["eMail_ID"] = user.eMail_ID;
			drow["receiver_index"] = user.receiver_index;
			drow["type"] = user.type;
			drow["name"] = user.name;
			drow["emailAddress"] = user.emailAddress;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
