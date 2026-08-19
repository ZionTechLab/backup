using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLPosting {
		#region Fields
		private string glPosting_ID;
		private string batch_ID;
		private int slot_ID;
		private string transaction_ID;
		private DateTime transactionDate;
		private string customer_ID;
		private string supplier_ID;
		private string remark;
		private string createUser_ID;
		private string createTerminal_ID;
		private DateTime dateCreate;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLPosting class.
		/// </summary>
		public tbl_accGLPosting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLPosting class.
		/// </summary>
		public tbl_accGLPosting(string glPosting_ID, string batch_ID, int slot_ID, string transaction_ID, DateTime transactionDate, string customer_ID, string supplier_ID, string remark, string createUser_ID, string createTerminal_ID, DateTime dateCreate, string companyID, string companyBranch_ID) {
			this.glPosting_ID = glPosting_ID;
			this.batch_ID = batch_ID;
			this.slot_ID = slot_ID;
			this.transaction_ID = transaction_ID;
			this.transactionDate = transactionDate;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.remark = remark;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.dateCreate = dateCreate;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Batch_ID value.
		/// </summary>
		public string Batch_ID {
			get { return batch_ID; }
			set { batch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Slot_ID value.
		/// </summary>
		public int Slot_ID {
			get { return slot_ID; }
			set { slot_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLPosting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPostingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLPosting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPostingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLPosting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPostingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
 
			scom.Parameters["@batch_ID"].Value = batch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLPosting table.
		/// </summary>
        ///  /// 
        public static tbl_accGLPosting Select(string glPosting_ID_Incoming)
        {

            tbl_accGLPosting tbl_accGLPostingins = new tbl_accGLPosting();
            try
            {
                SqlConnection scon = DBHandling.GetConnection();
                SqlCommand scom = new SqlCommand("tbl_accGLPostingSelect1", scon);
                scom.CommandType = CommandType.StoredProcedure;
                scon.Open();

                scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar, 20);
                scom.Parameters["@glPosting_ID"].Value = glPosting_ID_Incoming;
                using (SqlDataReader dataReader = scom.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        tbl_accGLPostingins = Maketbl_accGLPosting(dataReader);
                    }
                    else
                    {
                        tbl_accGLPostingins = null;
                    }
                }
                scon.Close();
            }
            catch (Exception)
            {
            }
            return tbl_accGLPostingins;
        }
		public static tbl_accGLPosting Select(string glPosting_ID_Incoming, string batch_ID_Incoming){

			tbl_accGLPosting tbl_accGLPostingins = new tbl_accGLPosting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPostingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID_Incoming;
			scom.Parameters["@batch_ID"].Value = batch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLPostingins = Maketbl_accGLPosting(dataReader);
				} else {
					tbl_accGLPostingins = null;
				}
			}
			scon.Close();
			return tbl_accGLPostingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLPosting table.
		/// </summary>
		public static List<tbl_accGLPosting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLPostingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLPosting> tbl_accGLPostingList = new List<tbl_accGLPosting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLPosting tbl_accGLPosting = Maketbl_accGLPosting(dataReader);
					tbl_accGLPostingList.Add(tbl_accGLPosting);
				}
			}
			scon.Close();
			return tbl_accGLPostingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLPosting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLPosting Maketbl_accGLPosting(SqlDataReader dataReader) {
			tbl_accGLPosting tbl_accGLPosting = new tbl_accGLPosting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLPosting.GlPosting_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLPosting.Batch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLPosting.Slot_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLPosting.Transaction_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLPosting.TransactionDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accGLPosting.Customer_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accGLPosting.Supplier_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accGLPosting.Remark = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accGLPosting.CreateUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accGLPosting.CreateTerminal_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accGLPosting.DateCreate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accGLPosting.CompanyID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accGLPosting.CompanyBranch_ID = dataReader.GetString(12);
			}

			return tbl_accGLPosting;
		}
		/// <summary>
		/// This makes tbl_accGLPosting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLPosting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLPosting  tbl_accGLPosting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_batch_ID = new DataColumn("batch_ID" , typeof(string));
			DataColumn col_slot_ID = new DataColumn("slot_ID" , typeof(int));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_transactionDate = new DataColumn("transactionDate" , typeof(DateTime));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_glPosting_ID,col_batch_ID,col_slot_ID,col_transaction_ID,col_transactionDate,col_customer_ID,col_supplier_ID,col_remark,col_createUser_ID,col_createTerminal_ID,col_dateCreate,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLPosting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLPosting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLPosting user) {
		DataRow drow = dt.NewRow();
		
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["batch_ID"] = user.batch_ID;
			drow["slot_ID"] = user.slot_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["transactionDate"] = user.transactionDate;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["remark"] = user.remark;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
