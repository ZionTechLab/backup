using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesCommission_Reimbursment {
		#region Fields
		private string commission_ID;
		private string invoice_ID;
		private decimal deductedAmount;
		private decimal reimburseAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Reimbursment class.
		/// </summary>
		public tbl_sasSalesCommission_Reimbursment() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesCommission_Reimbursment class.
		/// </summary>
		public tbl_sasSalesCommission_Reimbursment(string commission_ID, string invoice_ID, decimal deductedAmount, decimal reimburseAmount) {
			this.commission_ID = commission_ID;
			this.invoice_ID = invoice_ID;
			this.deductedAmount = deductedAmount;
			this.reimburseAmount = reimburseAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Commission_ID value.
		/// </summary>
		public string Commission_ID {
			get { return commission_ID; }
			set { commission_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeductedAmount value.
		/// </summary>
		public decimal DeductedAmount {
			get { return deductedAmount; }
			set { deductedAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReimburseAmount value.
		/// </summary>
		public decimal ReimburseAmount {
			get { return reimburseAmount; }
			set { reimburseAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesCommission_Reimbursment table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_ReimbursmentInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deductedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reimburseAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@deductedAmount"].Value = deductedAmount;
			scom.Parameters["@reimburseAmount"].Value = reimburseAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesCommission_Reimbursment table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_ReimbursmentUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deductedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reimburseAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@commission_ID"].Value = commission_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@deductedAmount"].Value = deductedAmount;
			scom.Parameters["@reimburseAmount"].Value = reimburseAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesCommission_Reimbursment table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_ReimbursmentDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Reimbursment table by a foreign key.
		/// </summary>
		public static void DeleteAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_ReimbursmentDeleteAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesCommission_Reimbursment table.
		/// </summary>
		public static tbl_sasSalesCommission_Reimbursment Select(string commission_ID_Incoming, string invoice_ID_Incoming){

			tbl_sasSalesCommission_Reimbursment tbl_sasSalesCommission_Reimbursmentins = new tbl_sasSalesCommission_Reimbursment();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_ReimbursmentSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesCommission_Reimbursmentins = Maketbl_sasSalesCommission_Reimbursment(dataReader);
				} else {
					tbl_sasSalesCommission_Reimbursmentins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_Reimbursmentins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Reimbursment table.
		/// </summary>
		public static List<tbl_sasSalesCommission_Reimbursment> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_ReimbursmentSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesCommission_Reimbursment> tbl_sasSalesCommission_ReimbursmentList = new List<tbl_sasSalesCommission_Reimbursment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Reimbursment tbl_sasSalesCommission_Reimbursment = Maketbl_sasSalesCommission_Reimbursment(dataReader);
					tbl_sasSalesCommission_ReimbursmentList.Add(tbl_sasSalesCommission_Reimbursment);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_ReimbursmentList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesCommission_Reimbursment table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesCommission_Reimbursment> SelectAllByCommission_ID(string commission_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesCommission_ReimbursmentSelectAllByCommission_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@commission_ID", SqlDbType.VarChar,20);
			scom.Parameters["@commission_ID"].Value = commission_ID;
				List<tbl_sasSalesCommission_Reimbursment> tbl_sasSalesCommission_ReimbursmentList = new List<tbl_sasSalesCommission_Reimbursment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesCommission_Reimbursment tbl_sasSalesCommission_Reimbursment = Maketbl_sasSalesCommission_Reimbursment(dataReader);
					tbl_sasSalesCommission_ReimbursmentList.Add(tbl_sasSalesCommission_Reimbursment);
				}
			}
			scon.Close();
			return tbl_sasSalesCommission_ReimbursmentList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesCommission_Reimbursment class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesCommission_Reimbursment Maketbl_sasSalesCommission_Reimbursment(SqlDataReader dataReader) {
			tbl_sasSalesCommission_Reimbursment tbl_sasSalesCommission_Reimbursment = new tbl_sasSalesCommission_Reimbursment();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesCommission_Reimbursment.Commission_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesCommission_Reimbursment.Invoice_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesCommission_Reimbursment.DeductedAmount = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesCommission_Reimbursment.ReimburseAmount = dataReader.GetDecimal(3);
			}

			return tbl_sasSalesCommission_Reimbursment;
		}
		/// <summary>
		/// This makes tbl_sasSalesCommission_Reimbursment datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Reimbursment object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesCommission_Reimbursment  tbl_sasSalesCommission_Reimbursment   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_commission_ID = new DataColumn("commission_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_deductedAmount = new DataColumn("deductedAmount" , typeof(decimal));
			DataColumn col_reimburseAmount = new DataColumn("reimburseAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_commission_ID,col_invoice_ID,col_deductedAmount,col_reimburseAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesCommission_Reimbursment datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesCommission_Reimbursment object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesCommission_Reimbursment user) {
		DataRow drow = dt.NewRow();
		
			drow["commission_ID"] = user.commission_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["deductedAmount"] = user.deductedAmount;
			drow["reimburseAmount"] = user.reimburseAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
