using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_Cheque_Standard {
		#region Fields
		private string chequeRegister_ID;
		private string chequeNumber;
		private DateTime dateCheque;
		private decimal chequeAmount;
		private string statusName;
		private string receipt_ID;
		private string accountReceipt_ID;
		private string customer_ID;
		private string customerName;
		private bool isDeleted;
        private string receivedof;
        private string accReciptNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_Cheque_Standard class.
		/// </summary>
		public srh_Cheque_Standard() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_Cheque_Standard class.
		/// </summary>
        public srh_Cheque_Standard(string chequeRegister_ID, string chequeNumber, DateTime dateCheque, decimal chequeAmount, string statusName, string receipt_ID, string accountReceipt_ID, string customer_ID, string customerName, bool isDeleted, string receivedof, string accReciptNo)
        {
			this.chequeRegister_ID = chequeRegister_ID;
			this.chequeNumber = chequeNumber;
			this.dateCheque = dateCheque;
			this.chequeAmount = chequeAmount;
			this.statusName = statusName;
			this.receipt_ID = receipt_ID;
			this.accountReceipt_ID = accountReceipt_ID;
			this.customer_ID = customer_ID;
			this.customerName = customerName;
			this.isDeleted = isDeleted;
            this.receivedof = receivedof;
            this.accReciptNo = accReciptNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeNumber value.
		/// </summary>
		public string ChequeNumber {
			get { return chequeNumber; }
			set { chequeNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCheque value.
		/// </summary>
		public DateTime DateCheque {
			get { return dateCheque; }
			set { dateCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatusName value.
		/// </summary>
		public string StatusName {
			get { return statusName; }
			set { statusName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountReceipt_ID value.
		/// </summary>
		public string AccountReceipt_ID {
			get { return accountReceipt_ID; }
			set { accountReceipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}

        public string Receivedof
        {
            get { return receivedof; }
            set { receivedof = value; }
        }
       
        public string AccReciptNo
        {
            get { return accReciptNo; }
            set { accReciptNo = value; }
        }
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the srh_Cheque_Standard table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Cheque_StandardInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@statusName"].Value = statusName;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@isDeleted"].Value = isDeleted;
         
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the srh_Cheque_Standard table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Cheque_StandardUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@statusName"].Value = statusName;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the srh_Cheque_Standard table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Cheque_StandardDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the srh_Cheque_Standard table.
		/// </summary>
		public static srh_Cheque_Standard Select(string chequeRegister_ID_Incoming){

			srh_Cheque_Standard srh_Cheque_Standardins = new srh_Cheque_Standard();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Cheque_StandardSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					srh_Cheque_Standardins = Makesrh_Cheque_Standard(dataReader);
				} else {
					srh_Cheque_Standardins = null;
				}
			}
			scon.Close();
			return srh_Cheque_Standardins;
		}
		
		/// <summary>
		/// Selects all records from the srh_Cheque_Standard table.
		/// </summary>
		public static List<srh_Cheque_Standard> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Cheque_StandardSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<srh_Cheque_Standard> srh_Cheque_StandardList = new List<srh_Cheque_Standard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_Cheque_Standard srh_Cheque_Standard = Makesrh_Cheque_Standard(dataReader);
					srh_Cheque_StandardList.Add(srh_Cheque_Standard);
				}
			}
			scon.Close();
			return srh_Cheque_StandardList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_Cheque_Standard class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_Cheque_Standard Makesrh_Cheque_Standard(SqlDataReader dataReader) {
			srh_Cheque_Standard srh_Cheque_Standard = new srh_Cheque_Standard();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_Cheque_Standard.ChequeRegister_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_Cheque_Standard.ChequeNumber = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_Cheque_Standard.DateCheque = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_Cheque_Standard.ChequeAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_Cheque_Standard.StatusName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_Cheque_Standard.Receipt_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_Cheque_Standard.AccountReceipt_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_Cheque_Standard.Customer_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_Cheque_Standard.CustomerName = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_Cheque_Standard.IsDeleted = dataReader.GetBoolean(9);
			}
            if (dataReader.IsDBNull(10) == false)
            {
                srh_Cheque_Standard.Receivedof = dataReader.GetString(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                srh_Cheque_Standard.AccReciptNo = dataReader.GetString(11);
            }
			return srh_Cheque_Standard;
		}
		/// <summary>
		/// This makes srh_Cheque_Standard datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new srh_Cheque_Standard object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( srh_Cheque_Standard  srh_Cheque_Standard   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_chequeNumber = new DataColumn("chequeNumber" , typeof(string));
			DataColumn col_dateCheque = new DataColumn("dateCheque" , typeof(DateTime));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_statusName = new DataColumn("statusName" , typeof(string));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_accountReceipt_ID = new DataColumn("accountReceipt_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_chequeRegister_ID,col_chequeNumber,col_dateCheque,col_chequeAmount,col_statusName,col_receipt_ID,col_accountReceipt_ID,col_customer_ID,col_customerName,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills srh_Cheque_Standard datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new srh_Cheque_Standard object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, srh_Cheque_Standard user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["chequeNumber"] = user.chequeNumber;
			drow["dateCheque"] = user.dateCheque;
			drow["chequeAmount"] = user.chequeAmount;
			drow["statusName"] = user.statusName;
			drow["receipt_ID"] = user.receipt_ID;
			drow["accountReceipt_ID"] = user.accountReceipt_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["customerName"] = user.customerName;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
