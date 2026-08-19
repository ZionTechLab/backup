using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accDoubleEntrySlotDetails {
		#region Fields
		private int line_No;
		private int slot_ID;
		private string gl_ID;
		private bool isCredit;
		private bool isDebit;
		private bool isVatAccount;
		private bool isNBTAccount;
		private bool isSVATAccount;
		private bool isDiscountAccount;
		private bool isSalseAmountAfteerDiscount;
		private bool isSubTotal;
		private bool isGrandTotal;
		private bool isSalseAmountWithNBT;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accDoubleEntrySlotDetails class.
		/// </summary>
		public tbl_accDoubleEntrySlotDetails() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accDoubleEntrySlotDetails class.
		/// </summary>
		public tbl_accDoubleEntrySlotDetails(int line_No, int slot_ID, string gl_ID, bool isCredit, bool isDebit, bool isVatAccount, bool isNBTAccount, bool isSVATAccount, bool isDiscountAccount, bool isSalseAmountAfteerDiscount, bool isSubTotal, bool isGrandTotal, bool isSalseAmountWithNBT) {
			this.line_No = line_No;
			this.slot_ID = slot_ID;
			this.gl_ID = gl_ID;
			this.isCredit = isCredit;
			this.isDebit = isDebit;
			this.isVatAccount = isVatAccount;
			this.isNBTAccount = isNBTAccount;
			this.isSVATAccount = isSVATAccount;
			this.isDiscountAccount = isDiscountAccount;
			this.isSalseAmountAfteerDiscount = isSalseAmountAfteerDiscount;
			this.isSubTotal = isSubTotal;
			this.isGrandTotal = isGrandTotal;
			this.isSalseAmountWithNBT = isSalseAmountWithNBT;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Slot_ID value.
		/// </summary>
		public int Slot_ID {
			get { return slot_ID; }
			set { slot_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCredit value.
		/// </summary>
		public bool IsCredit {
			get { return isCredit; }
			set { isCredit = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDebit value.
		/// </summary>
		public bool IsDebit {
			get { return isDebit; }
			set { isDebit = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVatAccount value.
		/// </summary>
		public bool IsVatAccount {
			get { return isVatAccount; }
			set { isVatAccount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNBTAccount value.
		/// </summary>
		public bool IsNBTAccount {
			get { return isNBTAccount; }
			set { isNBTAccount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSVATAccount value.
		/// </summary>
		public bool IsSVATAccount {
			get { return isSVATAccount; }
			set { isSVATAccount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDiscountAccount value.
		/// </summary>
		public bool IsDiscountAccount {
			get { return isDiscountAccount; }
			set { isDiscountAccount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalseAmountAfteerDiscount value.
		/// </summary>
		public bool IsSalseAmountAfteerDiscount {
			get { return isSalseAmountAfteerDiscount; }
			set { isSalseAmountAfteerDiscount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSubTotal value.
		/// </summary>
		public bool IsSubTotal {
			get { return isSubTotal; }
			set { isSubTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsGrandTotal value.
		/// </summary>
		public bool IsGrandTotal {
			get { return isGrandTotal; }
			set { isGrandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalseAmountWithNBT value.
		/// </summary>
		public bool IsSalseAmountWithNBT {
			get { return isSalseAmountWithNBT; }
			set { isSalseAmountWithNBT = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accDoubleEntrySlotDetails table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDebit", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVatAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVATAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDiscountAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalseAmountAfteerDiscount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSubTotal", SqlDbType.Bit,1);
			scom.Parameters.Add("@isGrandTotal", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalseAmountWithNBT", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isCredit"].Value = isCredit;
			scom.Parameters["@isDebit"].Value = isDebit;
			scom.Parameters["@isVatAccount"].Value = isVatAccount;
			scom.Parameters["@isNBTAccount"].Value = isNBTAccount;
			scom.Parameters["@isSVATAccount"].Value = isSVATAccount;
			scom.Parameters["@isDiscountAccount"].Value = isDiscountAccount;
			scom.Parameters["@isSalseAmountAfteerDiscount"].Value = isSalseAmountAfteerDiscount;
			scom.Parameters["@isSubTotal"].Value = isSubTotal;
			scom.Parameters["@isGrandTotal"].Value = isGrandTotal;
			scom.Parameters["@isSalseAmountWithNBT"].Value = isSalseAmountWithNBT;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accDoubleEntrySlotDetails table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDebit", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVatAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVATAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDiscountAccount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalseAmountAfteerDiscount", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSubTotal", SqlDbType.Bit,1);
			scom.Parameters.Add("@isGrandTotal", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalseAmountWithNBT", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isCredit"].Value = isCredit;
			scom.Parameters["@isDebit"].Value = isDebit;
			scom.Parameters["@isVatAccount"].Value = isVatAccount;
			scom.Parameters["@isNBTAccount"].Value = isNBTAccount;
			scom.Parameters["@isSVATAccount"].Value = isSVATAccount;
			scom.Parameters["@isDiscountAccount"].Value = isDiscountAccount;
			scom.Parameters["@isSalseAmountAfteerDiscount"].Value = isSalseAmountAfteerDiscount;
			scom.Parameters["@isSubTotal"].Value = isSubTotal;
			scom.Parameters["@isGrandTotal"].Value = isGrandTotal;
			scom.Parameters["@isSalseAmountWithNBT"].Value = isSalseAmountWithNBT;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accDoubleEntrySlotDetails table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@slot_ID"].Value = slot_ID;
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDoubleEntrySlotDetails table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        /// <summary>
        /// Selects all records from the tbl_accDoubleEntrySlotDetails table by a foreign key.
        /// </summary>
        public static void DeleteAllBySlot_ID(int slot_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsDeleteAllBySlot_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            //	scon.Open();

            scom.Parameters.Add("@slot_ID", SqlDbType.Int, 4);
            scom.Parameters["@slot_ID"].Value = slot_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_accDoubleEntrySlotDetails table by a foreign key.
        /// </summary>
        //public static void DeleteAllByGlAccountType_ID(string glAccountType_ID)
        //{

        //    SqlConnection scon = DBHandling.GetConnection();
        //    SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsDeleteAllByGlAccountType_ID", scon);
        //    scom.CommandType = CommandType.StoredProcedure;
        //    scon.Open();

        //    scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar, 20);
        //    scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;

        //    scon.Open();
        //    scom.ExecuteNonQuery();
        //    scon.Close();
        //}
		
		/// <summary>
		/// Selects a single record from the tbl_accDoubleEntrySlotDetails table.
		/// </summary>
		public static tbl_accDoubleEntrySlotDetails Select(int slot_ID_Incoming, string gl_ID_Incoming){

			tbl_accDoubleEntrySlotDetails tbl_accDoubleEntrySlotDetailsins = new tbl_accDoubleEntrySlotDetails();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@slot_ID"].Value = slot_ID_Incoming;
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accDoubleEntrySlotDetailsins = Maketbl_accDoubleEntrySlotDetails(dataReader);
				} else {
					tbl_accDoubleEntrySlotDetailsins = null;
				}
			}
			scon.Close();
			return tbl_accDoubleEntrySlotDetailsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDoubleEntrySlotDetails table.
		/// </summary>
		public static List<tbl_accDoubleEntrySlotDetails> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accDoubleEntrySlotDetails> tbl_accDoubleEntrySlotDetailsList = new List<tbl_accDoubleEntrySlotDetails>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDoubleEntrySlotDetails tbl_accDoubleEntrySlotDetails = Maketbl_accDoubleEntrySlotDetails(dataReader);
					tbl_accDoubleEntrySlotDetailsList.Add(tbl_accDoubleEntrySlotDetails);
				}
			}
			scon.Close();
			return tbl_accDoubleEntrySlotDetailsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDoubleEntrySlotDetails table by a foreign key.
		/// </summary>
		public static List<tbl_accDoubleEntrySlotDetails> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accDoubleEntrySlotDetails> tbl_accDoubleEntrySlotDetailsList = new List<tbl_accDoubleEntrySlotDetails>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDoubleEntrySlotDetails tbl_accDoubleEntrySlotDetails = Maketbl_accDoubleEntrySlotDetails(dataReader);
					tbl_accDoubleEntrySlotDetailsList.Add(tbl_accDoubleEntrySlotDetails);
				}
			}
			scon.Close();
			return tbl_accDoubleEntrySlotDetailsList;
		}

        /// <summary>
        /// Selects all records from the tbl_accDoubleEntrySlotDetails table by a foreign key.
        /// </summary>
        public static List<tbl_accDoubleEntrySlotDetails> SelectAllBySlot_ID(int slot_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsSelectAllBySlot_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@slot_ID", SqlDbType.Int, 4);
            scom.Parameters["@slot_ID"].Value = slot_ID;
            List<tbl_accDoubleEntrySlotDetails> tbl_accDoubleEntrySlotDetailsList = new List<tbl_accDoubleEntrySlotDetails>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_accDoubleEntrySlotDetails tbl_accDoubleEntrySlotDetails = Maketbl_accDoubleEntrySlotDetails(dataReader);
                    tbl_accDoubleEntrySlotDetailsList.Add(tbl_accDoubleEntrySlotDetails);
                }
            }
            scon.Close();
            return tbl_accDoubleEntrySlotDetailsList;
        }

        /// <summary>
        /// Selects all records from the tbl_accDoubleEntrySlotDetails table by a foreign key.
        /// </summary>
        public static List<tbl_accDoubleEntrySlotDetails> SelectAllByGlAccountType_ID(string glAccountType_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotDetailsSelectAllByGlAccountType_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;
            List<tbl_accDoubleEntrySlotDetails> tbl_accDoubleEntrySlotDetailsList = new List<tbl_accDoubleEntrySlotDetails>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_accDoubleEntrySlotDetails tbl_accDoubleEntrySlotDetails = Maketbl_accDoubleEntrySlotDetails(dataReader);
                    tbl_accDoubleEntrySlotDetailsList.Add(tbl_accDoubleEntrySlotDetails);
                }
            }
            scon.Close();
            return tbl_accDoubleEntrySlotDetailsList;
        }
		
		
		/// <summary>
		/// Creates a new instance of the tbl_accDoubleEntrySlotDetails class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accDoubleEntrySlotDetails Maketbl_accDoubleEntrySlotDetails(SqlDataReader dataReader) {
			tbl_accDoubleEntrySlotDetails tbl_accDoubleEntrySlotDetails = new tbl_accDoubleEntrySlotDetails();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accDoubleEntrySlotDetails.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accDoubleEntrySlotDetails.Slot_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accDoubleEntrySlotDetails.Gl_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accDoubleEntrySlotDetails.IsCredit = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accDoubleEntrySlotDetails.IsDebit = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accDoubleEntrySlotDetails.IsVatAccount = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accDoubleEntrySlotDetails.IsNBTAccount = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accDoubleEntrySlotDetails.IsSVATAccount = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accDoubleEntrySlotDetails.IsDiscountAccount = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accDoubleEntrySlotDetails.IsSalseAmountAfteerDiscount = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accDoubleEntrySlotDetails.IsSubTotal = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accDoubleEntrySlotDetails.IsGrandTotal = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accDoubleEntrySlotDetails.IsSalseAmountWithNBT = dataReader.GetBoolean(12);
			}

			return tbl_accDoubleEntrySlotDetails;
		}
		/// <summary>
		/// This makes tbl_accDoubleEntrySlotDetails datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accDoubleEntrySlotDetails object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accDoubleEntrySlotDetails  tbl_accDoubleEntrySlotDetails   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_slot_ID = new DataColumn("slot_ID" , typeof(int));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_isCredit = new DataColumn("isCredit" , typeof(bool));
			DataColumn col_isDebit = new DataColumn("isDebit" , typeof(bool));
			DataColumn col_isVatAccount = new DataColumn("isVatAccount" , typeof(bool));
			DataColumn col_isNBTAccount = new DataColumn("isNBTAccount" , typeof(bool));
			DataColumn col_isSVATAccount = new DataColumn("isSVATAccount" , typeof(bool));
			DataColumn col_isDiscountAccount = new DataColumn("isDiscountAccount" , typeof(bool));
			DataColumn col_isSalseAmountAfteerDiscount = new DataColumn("isSalseAmountAfteerDiscount" , typeof(bool));
			DataColumn col_isSubTotal = new DataColumn("isSubTotal" , typeof(bool));
			DataColumn col_isGrandTotal = new DataColumn("isGrandTotal" , typeof(bool));
			DataColumn col_isSalseAmountWithNBT = new DataColumn("isSalseAmountWithNBT" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_slot_ID,col_gl_ID,col_isCredit,col_isDebit,col_isVatAccount,col_isNBTAccount,col_isSVATAccount,col_isDiscountAccount,col_isSalseAmountAfteerDiscount,col_isSubTotal,col_isGrandTotal,col_isSalseAmountWithNBT,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accDoubleEntrySlotDetails datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accDoubleEntrySlotDetails object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accDoubleEntrySlotDetails user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["slot_ID"] = user.slot_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["isCredit"] = user.isCredit;
			drow["isDebit"] = user.isDebit;
			drow["isVatAccount"] = user.isVatAccount;
			drow["isNBTAccount"] = user.isNBTAccount;
			drow["isSVATAccount"] = user.isSVATAccount;
			drow["isDiscountAccount"] = user.isDiscountAccount;
			drow["isSalseAmountAfteerDiscount"] = user.isSalseAmountAfteerDiscount;
			drow["isSubTotal"] = user.isSubTotal;
			drow["isGrandTotal"] = user.isGrandTotal;
			drow["isSalseAmountWithNBT"] = user.isSalseAmountWithNBT;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
