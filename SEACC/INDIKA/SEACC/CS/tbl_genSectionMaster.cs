using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genSectionMaster {
		#region Fields
		private int line_No;
		private string section_ID;
		private string sectionName;
		private string department_ID;
		private string adress;
		private string telephone;
		private string fax;
		private string contactPerson;
		private decimal sectionCost;
		private decimal overheadRate;
		private decimal sectioncapacity;
		private string remark;
		private bool isExtrusion;
		private bool isBinSection;
		private bool isDeleted;
		private string store_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genSectionMaster class.
		/// </summary>
		public tbl_genSectionMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genSectionMaster class.
		/// </summary>
		public tbl_genSectionMaster(int line_No, string section_ID, string sectionName, string department_ID, string adress, string telephone, string fax, string contactPerson, decimal sectionCost, decimal overheadRate, decimal sectioncapacity, string remark, bool isExtrusion, bool isBinSection, bool isDeleted, string store_ID) {
			this.line_No = line_No;
			this.section_ID = section_ID;
			this.sectionName = sectionName;
			this.department_ID = department_ID;
			this.adress = adress;
			this.telephone = telephone;
			this.fax = fax;
			this.contactPerson = contactPerson;
			this.sectionCost = sectionCost;
			this.overheadRate = overheadRate;
			this.sectioncapacity = sectioncapacity;
			this.remark = remark;
			this.isExtrusion = isExtrusion;
			this.isBinSection = isBinSection;
			this.isDeleted = isDeleted;
			this.store_ID = store_ID;
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
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionName value.
		/// </summary>
		public string SectionName {
			get { return sectionName; }
			set { sectionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Adress value.
		/// </summary>
		public string Adress {
			get { return adress; }
			set { adress = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactPerson value.
		/// </summary>
		public string ContactPerson {
			get { return contactPerson; }
			set { contactPerson = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionCost value.
		/// </summary>
		public decimal SectionCost {
			get { return sectionCost; }
			set { sectionCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the OverheadRate value.
		/// </summary>
		public decimal OverheadRate {
			get { return overheadRate; }
			set { overheadRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Sectioncapacity value.
		/// </summary>
		public decimal Sectioncapacity {
			get { return sectioncapacity; }
			set { sectioncapacity = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsExtrusion value.
		/// </summary>
		public bool IsExtrusion {
			get { return isExtrusion; }
			set { isExtrusion = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBinSection value.
		/// </summary>
		public bool IsBinSection {
			get { return isBinSection; }
			set { isBinSection = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genSectionMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sectionCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@overheadRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Sectioncapacity", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isExtrusion", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBinSection", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionName"].Value = sectionName;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
			scom.Parameters["@sectionCost"].Value = sectionCost;
			scom.Parameters["@overheadRate"].Value = overheadRate;
			scom.Parameters["@Sectioncapacity"].Value = sectioncapacity;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isExtrusion"].Value = isExtrusion;
			scom.Parameters["@isBinSection"].Value = isBinSection;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genSectionMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sectionCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@overheadRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@Sectioncapacity", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isExtrusion", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBinSection", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionName"].Value = sectionName;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
			scom.Parameters["@sectionCost"].Value = sectionCost;
			scom.Parameters["@overheadRate"].Value = overheadRate;
			scom.Parameters["@Sectioncapacity"].Value = sectioncapacity;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isExtrusion"].Value = isExtrusion;
			scom.Parameters["@isBinSection"].Value = isBinSection;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genSectionMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSectionMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterDeleteAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSectionMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genSectionMaster table.
		/// </summary>
		public static tbl_genSectionMaster Select(string section_ID_Incoming){

			tbl_genSectionMaster tbl_genSectionMasterins = new tbl_genSectionMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genSectionMasterins = Maketbl_genSectionMaster(dataReader);
				} else {
					tbl_genSectionMasterins = null;
				}
			}
			scon.Close();
			return tbl_genSectionMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSectionMaster table.
		/// </summary>
		public static List<tbl_genSectionMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genSectionMaster> tbl_genSectionMasterList = new List<tbl_genSectionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSectionMaster tbl_genSectionMaster = Maketbl_genSectionMaster(dataReader);
					tbl_genSectionMasterList.Add(tbl_genSectionMaster);
				}
			}
			scon.Close();
			return tbl_genSectionMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSectionMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSectionMaster> SelectAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterSelectAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
				List<tbl_genSectionMaster> tbl_genSectionMasterList = new List<tbl_genSectionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSectionMaster tbl_genSectionMaster = Maketbl_genSectionMaster(dataReader);
					tbl_genSectionMasterList.Add(tbl_genSectionMaster);
				}
			}
			scon.Close();
			return tbl_genSectionMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSectionMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSectionMaster> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSectionMasterSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_genSectionMaster> tbl_genSectionMasterList = new List<tbl_genSectionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSectionMaster tbl_genSectionMaster = Maketbl_genSectionMaster(dataReader);
					tbl_genSectionMasterList.Add(tbl_genSectionMaster);
				}
			}
			scon.Close();
			return tbl_genSectionMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genSectionMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genSectionMaster Maketbl_genSectionMaster(SqlDataReader dataReader) {
			tbl_genSectionMaster tbl_genSectionMaster = new tbl_genSectionMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genSectionMaster.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genSectionMaster.Section_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genSectionMaster.SectionName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genSectionMaster.Department_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genSectionMaster.Adress = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genSectionMaster.Telephone = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genSectionMaster.Fax = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genSectionMaster.ContactPerson = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genSectionMaster.SectionCost = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genSectionMaster.OverheadRate = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genSectionMaster.Sectioncapacity = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genSectionMaster.Remark = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genSectionMaster.IsExtrusion = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genSectionMaster.IsBinSection = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genSectionMaster.IsDeleted = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genSectionMaster.Store_ID = dataReader.GetString(15);
			}

			return tbl_genSectionMaster;
		}
		/// <summary>
		/// This makes tbl_genSectionMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genSectionMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genSectionMaster  tbl_genSectionMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_sectionName = new DataColumn("sectionName" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_adress = new DataColumn("adress" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_contactPerson = new DataColumn("contactPerson" , typeof(string));
			DataColumn col_sectionCost = new DataColumn("sectionCost" , typeof(decimal));
			DataColumn col_overheadRate = new DataColumn("overheadRate" , typeof(decimal));
			DataColumn col_Sectioncapacity = new DataColumn("Sectioncapacity" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isExtrusion = new DataColumn("isExtrusion" , typeof(bool));
			DataColumn col_isBinSection = new DataColumn("isBinSection" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_section_ID,col_sectionName,col_department_ID,col_adress,col_telephone,col_fax,col_contactPerson,col_sectionCost,col_overheadRate,col_Sectioncapacity,col_remark,col_isExtrusion,col_isBinSection,col_isDeleted,col_store_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genSectionMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genSectionMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genSectionMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["section_ID"] = user.section_ID;
			drow["sectionName"] = user.sectionName;
			drow["department_ID"] = user.department_ID;
			drow["adress"] = user.adress;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["contactPerson"] = user.contactPerson;
			drow["sectionCost"] = user.sectionCost;
			drow["overheadRate"] = user.overheadRate;
			drow["Sectioncapacity"] = user.Sectioncapacity;
			drow["remark"] = user.remark;
			drow["isExtrusion"] = user.isExtrusion;
			drow["isBinSection"] = user.isBinSection;
			drow["isDeleted"] = user.isDeleted;
			drow["store_ID"] = user.store_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
