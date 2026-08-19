using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsChequeReturnToSender {
		#region Fields
		private string returnedToSender_ID;
		private string remark;
		private DateTime dateReturned;
		private string createUser_ID;
		private string modifiedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private bool isFinished;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReturnToSender class.
		/// </summary>
		public tbl_bpsChequeReturnToSender() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReturnToSender class.
		/// </summary>
		public tbl_bpsChequeReturnToSender(string returnedToSender_ID, string remark, DateTime dateReturned, string createUser_ID, string modifiedUser_ID, DateTime dateCreate, DateTime dateModified, bool isFinished, bool isDeleted) {
			this.returnedToSender_ID = returnedToSender_ID;
			this.remark = remark;
			this.dateReturned = dateReturned;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReturnedToSender_ID value.
		/// </summary>
		public string ReturnedToSender_ID {
			get { return returnedToSender_ID; }
			set { returnedToSender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReturned value.
		/// </summary>
		public DateTime DateReturned {
			get { return dateReturned; }
			set { dateReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFinished value.
		/// </summary>
		public bool IsFinished {
			get { return isFinished; }
			set { isFinished = value; }
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
		/// Saves a record to the tbl_bpsChequeReturnToSender table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSenderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateReturned", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateReturned"].Value = dateReturned;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsChequeReturnToSender table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSenderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateReturned", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateReturned"].Value = dateReturned;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsChequeReturnToSender table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSenderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsChequeReturnToSender table.
		/// </summary>
		public static tbl_bpsChequeReturnToSender Select(string returnedToSender_ID_Incoming){

			tbl_bpsChequeReturnToSender tbl_bpsChequeReturnToSenderins = new tbl_bpsChequeReturnToSender();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSenderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@returnedToSender_ID", SqlDbType.VarChar,20);
			scom.Parameters["@returnedToSender_ID"].Value = returnedToSender_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsChequeReturnToSenderins = Maketbl_bpsChequeReturnToSender(dataReader);
				} else {
					tbl_bpsChequeReturnToSenderins = null;
				}
			}
			scon.Close();
			return tbl_bpsChequeReturnToSenderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReturnToSender table.
		/// </summary>
		public static List<tbl_bpsChequeReturnToSender> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReturnToSenderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsChequeReturnToSender> tbl_bpsChequeReturnToSenderList = new List<tbl_bpsChequeReturnToSender>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReturnToSender tbl_bpsChequeReturnToSender = Maketbl_bpsChequeReturnToSender(dataReader);
					tbl_bpsChequeReturnToSenderList.Add(tbl_bpsChequeReturnToSender);
				}
			}
			scon.Close();
			return tbl_bpsChequeReturnToSenderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsChequeReturnToSender class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsChequeReturnToSender Maketbl_bpsChequeReturnToSender(SqlDataReader dataReader) {
			tbl_bpsChequeReturnToSender tbl_bpsChequeReturnToSender = new tbl_bpsChequeReturnToSender();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsChequeReturnToSender.ReturnedToSender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsChequeReturnToSender.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsChequeReturnToSender.DateReturned = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsChequeReturnToSender.CreateUser_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsChequeReturnToSender.ModifiedUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsChequeReturnToSender.DateCreate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsChequeReturnToSender.DateModified = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsChequeReturnToSender.IsFinished = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsChequeReturnToSender.IsDeleted = dataReader.GetBoolean(8);
			}

			return tbl_bpsChequeReturnToSender;
		}
		/// <summary>
		/// This makes tbl_bpsChequeReturnToSender datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsChequeReturnToSender object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsChequeReturnToSender  tbl_bpsChequeReturnToSender   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_returnedToSender_ID = new DataColumn("returnedToSender_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_dateReturned = new DataColumn("dateReturned" , typeof(DateTime));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_returnedToSender_ID,col_remark,col_dateReturned,col_createUser_ID,col_modifiedUser_ID,col_dateCreate,col_dateModified,col_isFinished,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsChequeReturnToSender datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsChequeReturnToSender object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsChequeReturnToSender user) {
		DataRow drow = dt.NewRow();
		
			drow["returnedToSender_ID"] = user.returnedToSender_ID;
			drow["remark"] = user.remark;
			drow["dateReturned"] = user.dateReturned;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
