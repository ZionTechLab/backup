using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsFactoringSchedule_detail {
		#region Fields
		private string factoringSehedule_ID;
		private string chequeRegister_ID;
		private int line_No;
		private string invoiceNos;
		private string remarks;
		private decimal chequeAmount;
		private decimal factoringRate;
		private decimal factoringAmount;
		private decimal serviceCharges;
		private decimal interestAmount;
		private int nofDays;
		private bool isApproved;
		private decimal factoringAmount_Approved;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringSchedule_detail class.
		/// </summary>
		public tbl_bpsFactoringSchedule_detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringSchedule_detail class.
		/// </summary>
		public tbl_bpsFactoringSchedule_detail(string factoringSehedule_ID, string chequeRegister_ID, int line_No, string invoiceNos, string remarks, decimal chequeAmount, decimal factoringRate, decimal factoringAmount, decimal serviceCharges, decimal interestAmount, int nofDays, bool isApproved, decimal factoringAmount_Approved) {
			this.factoringSehedule_ID = factoringSehedule_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.line_No = line_No;
			this.invoiceNos = invoiceNos;
			this.remarks = remarks;
			this.chequeAmount = chequeAmount;
			this.factoringRate = factoringRate;
			this.factoringAmount = factoringAmount;
			this.serviceCharges = serviceCharges;
			this.interestAmount = interestAmount;
			this.nofDays = nofDays;
			this.isApproved = isApproved;
			this.factoringAmount_Approved = factoringAmount_Approved;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FactoringSehedule_ID value.
		/// </summary>
		public string FactoringSehedule_ID {
			get { return factoringSehedule_ID; }
			set { factoringSehedule_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceNos value.
		/// </summary>
		public string InvoiceNos {
			get { return invoiceNos; }
			set { invoiceNos = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringRate value.
		/// </summary>
		public decimal FactoringRate {
			get { return factoringRate; }
			set { factoringRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringAmount value.
		/// </summary>
		public decimal FactoringAmount {
			get { return factoringAmount; }
			set { factoringAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ServiceCharges value.
		/// </summary>
		public decimal ServiceCharges {
			get { return serviceCharges; }
			set { serviceCharges = value; }
		}
		
		/// <summary>
		/// Gets or sets the InterestAmount value.
		/// </summary>
		public decimal InterestAmount {
			get { return interestAmount; }
			set { interestAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the NofDays value.
		/// </summary>
		public int NofDays {
			get { return nofDays; }
			set { nofDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringAmount_Approved value.
		/// </summary>
		public decimal FactoringAmount_Approved {
			get { return factoringAmount_Approved; }
			set { factoringAmount_Approved = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsFactoringSchedule_detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@invoiceNos", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serviceCharges", SqlDbType.Decimal,9);
			scom.Parameters.Add("@interestAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nofDays", SqlDbType.Int,4);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@factoringAmount_Approved", SqlDbType.Decimal,9);
 
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoiceNos"].Value = invoiceNos;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@factoringRate"].Value = factoringRate;
			scom.Parameters["@factoringAmount"].Value = factoringAmount;
			scom.Parameters["@serviceCharges"].Value = serviceCharges;
			scom.Parameters["@interestAmount"].Value = interestAmount;
			scom.Parameters["@nofDays"].Value = nofDays;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@factoringAmount_Approved"].Value = factoringAmount_Approved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsFactoringSchedule_detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@invoiceNos", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serviceCharges", SqlDbType.Decimal,9);
			scom.Parameters.Add("@interestAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nofDays", SqlDbType.Int,4);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@factoringAmount_Approved", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoiceNos"].Value = invoiceNos;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@factoringRate"].Value = factoringRate;
			scom.Parameters["@factoringAmount"].Value = factoringAmount;
			scom.Parameters["@serviceCharges"].Value = serviceCharges;
			scom.Parameters["@interestAmount"].Value = interestAmount;
			scom.Parameters["@nofDays"].Value = nofDays;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@factoringAmount_Approved"].Value = factoringAmount_Approved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsFactoringSchedule_detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule_detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFactoringSehedule_ID(string factoringSehedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailDeleteAllByFactoringSehedule_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule_detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsFactoringSchedule_detail table.
		/// </summary>
		public static tbl_bpsFactoringSchedule_detail Select(string factoringSehedule_ID_Incoming, string chequeRegister_ID_Incoming){

			tbl_bpsFactoringSchedule_detail tbl_bpsFactoringSchedule_detailins = new tbl_bpsFactoringSchedule_detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID_Incoming;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsFactoringSchedule_detailins = Maketbl_bpsFactoringSchedule_detail(dataReader);
				} else {
					tbl_bpsFactoringSchedule_detailins = null;
				}
			}
			scon.Close();
			return tbl_bpsFactoringSchedule_detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule_detail table.
		/// </summary>
		public static List<tbl_bpsFactoringSchedule_detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsFactoringSchedule_detail> tbl_bpsFactoringSchedule_detailList = new List<tbl_bpsFactoringSchedule_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringSchedule_detail tbl_bpsFactoringSchedule_detail = Maketbl_bpsFactoringSchedule_detail(dataReader);
					tbl_bpsFactoringSchedule_detailList.Add(tbl_bpsFactoringSchedule_detail);
				}
			}
			scon.Close();
			return tbl_bpsFactoringSchedule_detailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule_detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsFactoringSchedule_detail> SelectAllByFactoringSehedule_ID(string factoringSehedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailSelectAllByFactoringSehedule_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
				List<tbl_bpsFactoringSchedule_detail> tbl_bpsFactoringSchedule_detailList = new List<tbl_bpsFactoringSchedule_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringSchedule_detail tbl_bpsFactoringSchedule_detail = Maketbl_bpsFactoringSchedule_detail(dataReader);
					tbl_bpsFactoringSchedule_detailList.Add(tbl_bpsFactoringSchedule_detail);
				}
			}
			scon.Close();
			return tbl_bpsFactoringSchedule_detailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule_detail table by a foreign key.
		/// </summary>
		public static List<tbl_bpsFactoringSchedule_detail> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringSchedule_detailSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_bpsFactoringSchedule_detail> tbl_bpsFactoringSchedule_detailList = new List<tbl_bpsFactoringSchedule_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringSchedule_detail tbl_bpsFactoringSchedule_detail = Maketbl_bpsFactoringSchedule_detail(dataReader);
					tbl_bpsFactoringSchedule_detailList.Add(tbl_bpsFactoringSchedule_detail);
				}
			}
			scon.Close();
			return tbl_bpsFactoringSchedule_detailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsFactoringSchedule_detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsFactoringSchedule_detail Maketbl_bpsFactoringSchedule_detail(SqlDataReader dataReader) {
			tbl_bpsFactoringSchedule_detail tbl_bpsFactoringSchedule_detail = new tbl_bpsFactoringSchedule_detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsFactoringSchedule_detail.FactoringSehedule_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsFactoringSchedule_detail.ChequeRegister_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsFactoringSchedule_detail.Line_No = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsFactoringSchedule_detail.InvoiceNos = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsFactoringSchedule_detail.Remarks = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsFactoringSchedule_detail.ChequeAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsFactoringSchedule_detail.FactoringRate = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsFactoringSchedule_detail.FactoringAmount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsFactoringSchedule_detail.ServiceCharges = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsFactoringSchedule_detail.InterestAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsFactoringSchedule_detail.NofDays = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsFactoringSchedule_detail.IsApproved = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsFactoringSchedule_detail.FactoringAmount_Approved = dataReader.GetDecimal(12);
			}

			return tbl_bpsFactoringSchedule_detail;
		}
		/// <summary>
		/// This makes tbl_bpsFactoringSchedule_detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringSchedule_detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsFactoringSchedule_detail  tbl_bpsFactoringSchedule_detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_factoringSehedule_ID = new DataColumn("factoringSehedule_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_invoiceNos = new DataColumn("invoiceNos" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_factoringRate = new DataColumn("factoringRate" , typeof(decimal));
			DataColumn col_factoringAmount = new DataColumn("factoringAmount" , typeof(decimal));
			DataColumn col_serviceCharges = new DataColumn("serviceCharges" , typeof(decimal));
			DataColumn col_interestAmount = new DataColumn("interestAmount" , typeof(decimal));
			DataColumn col_nofDays = new DataColumn("nofDays" , typeof(int));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_factoringAmount_Approved = new DataColumn("factoringAmount_Approved" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_factoringSehedule_ID,col_chequeRegister_ID,col_line_No,col_invoiceNos,col_remarks,col_chequeAmount,col_factoringRate,col_factoringAmount,col_serviceCharges,col_interestAmount,col_nofDays,col_isApproved,col_factoringAmount_Approved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsFactoringSchedule_detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringSchedule_detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsFactoringSchedule_detail user) {
		DataRow drow = dt.NewRow();
		
			drow["factoringSehedule_ID"] = user.factoringSehedule_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["line_No"] = user.line_No;
			drow["invoiceNos"] = user.invoiceNos;
			drow["remarks"] = user.remarks;
			drow["chequeAmount"] = user.chequeAmount;
			drow["factoringRate"] = user.factoringRate;
			drow["factoringAmount"] = user.factoringAmount;
			drow["serviceCharges"] = user.serviceCharges;
			drow["interestAmount"] = user.interestAmount;
			drow["nofDays"] = user.nofDays;
			drow["isApproved"] = user.isApproved;
			drow["factoringAmount_Approved"] = user.factoringAmount_Approved;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
