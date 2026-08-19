using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_Bank {
		#region Fields
		private string gl_ID;
		private string accountNumber;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Bank class.
		/// </summary>
		public tbl_accGLMaster_Bank() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Bank class.
		/// </summary>
		public tbl_accGLMaster_Bank(string gl_ID, string accountNumber, bool isActive) {
			this.gl_ID = gl_ID;
			this.accountNumber = accountNumber;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber value.
		/// </summary>
		public string AccountNumber {
			get { return accountNumber; }
			set { accountNumber = value; }
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
		/// Saves a record to the tbl_accGLMaster_Bank table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_BankInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_Bank table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_BankUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_Bank table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_BankDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters["@accountNumber"].Value = accountNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Bank table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_BankDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			//scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        /// <summary>
        /// Selects a single record from the tbl_accGLMaster_Bank table.
        /// </summary>
        public static tbl_accGLMaster_Bank Select(string accountNumber_Incoming)
        {

            tbl_accGLMaster_Bank tbl_accGLMaster_Bankins = new tbl_accGLMaster_Bank();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accGLMaster_BankSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@accountNumber", SqlDbType.VarChar, 20);
            scom.Parameters["@accountNumber"].Value = accountNumber_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_accGLMaster_Bankins = Maketbl_accGLMaster_Bank(dataReader);
                }
                else
                {
                    tbl_accGLMaster_Bankins = null;
                }
            }
            scon.Close();
            return tbl_accGLMaster_Bankins;
        }
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Bank table.
		/// </summary>
		public static List<tbl_accGLMaster_Bank> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_BankSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_Bank> tbl_accGLMaster_BankList = new List<tbl_accGLMaster_Bank>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Bank tbl_accGLMaster_Bank = Maketbl_accGLMaster_Bank(dataReader);
					tbl_accGLMaster_BankList.Add(tbl_accGLMaster_Bank);
				}
			}
			scon.Close();
			return tbl_accGLMaster_BankList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Bank table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Bank> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_BankSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accGLMaster_Bank> tbl_accGLMaster_BankList = new List<tbl_accGLMaster_Bank>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Bank tbl_accGLMaster_Bank = Maketbl_accGLMaster_Bank(dataReader);
					tbl_accGLMaster_BankList.Add(tbl_accGLMaster_Bank);
				}
			}
			scon.Close();
			return tbl_accGLMaster_BankList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_Bank class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_Bank Maketbl_accGLMaster_Bank(SqlDataReader dataReader) {
			tbl_accGLMaster_Bank tbl_accGLMaster_Bank = new tbl_accGLMaster_Bank();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_Bank.Gl_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_Bank.AccountNumber = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_Bank.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_accGLMaster_Bank;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_Bank datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Bank object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_Bank  tbl_accGLMaster_Bank   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_gl_ID,col_accountNumber,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_Bank datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Bank object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_Bank user) {
		DataRow drow = dt.NewRow();
		
			drow["gl_ID"] = user.gl_ID;
			drow["accountNumber"] = user.accountNumber;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
