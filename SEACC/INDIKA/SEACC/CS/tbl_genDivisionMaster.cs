using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genDivisionMaster {
		#region Fields
		private string division_ID;
		private string divisionName;
		private string companyBranch_ID;
		private string adress;
		private string telephone;
		private string fax;
		private string contactPerson;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genDivisionMaster class.
		/// </summary>
		public tbl_genDivisionMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genDivisionMaster class.
		/// </summary>
		public tbl_genDivisionMaster(string division_ID, string divisionName, string companyBranch_ID, string adress, string telephone, string fax, string contactPerson) {
			this.division_ID = division_ID;
			this.divisionName = divisionName;
			this.companyBranch_ID = companyBranch_ID;
			this.adress = adress;
			this.telephone = telephone;
			this.fax = fax;
			this.contactPerson = contactPerson;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Division_ID value.
		/// </summary>
		public string Division_ID {
			get { return division_ID; }
			set { division_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivisionName value.
		/// </summary>
		public string DivisionName {
			get { return divisionName; }
			set { divisionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genDivisionMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDivisionMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@divisionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
 
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@divisionName"].Value = divisionName;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genDivisionMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDivisionMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@divisionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@divisionName"].Value = divisionName;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genDivisionMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDivisionMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters["@division_ID"].Value = division_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDivisionMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDivisionMasterDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genDivisionMaster table.
		/// </summary>
		public static tbl_genDivisionMaster Select(string division_ID_Incoming){

			tbl_genDivisionMaster tbl_genDivisionMasterins = new tbl_genDivisionMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDivisionMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters["@division_ID"].Value = division_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genDivisionMasterins = Maketbl_genDivisionMaster(dataReader);
				} else {
					tbl_genDivisionMasterins = null;
				}
			}
			scon.Close();
			return tbl_genDivisionMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDivisionMaster table.
		/// </summary>
		public static List<tbl_genDivisionMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDivisionMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genDivisionMaster> tbl_genDivisionMasterList = new List<tbl_genDivisionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDivisionMaster tbl_genDivisionMaster = Maketbl_genDivisionMaster(dataReader);
					tbl_genDivisionMasterList.Add(tbl_genDivisionMaster);
				}
			}
			scon.Close();
			return tbl_genDivisionMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDivisionMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genDivisionMaster> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDivisionMasterSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_genDivisionMaster> tbl_genDivisionMasterList = new List<tbl_genDivisionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDivisionMaster tbl_genDivisionMaster = Maketbl_genDivisionMaster(dataReader);
					tbl_genDivisionMasterList.Add(tbl_genDivisionMaster);
				}
			}
			scon.Close();
			return tbl_genDivisionMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genDivisionMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genDivisionMaster Maketbl_genDivisionMaster(SqlDataReader dataReader) {
			tbl_genDivisionMaster tbl_genDivisionMaster = new tbl_genDivisionMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genDivisionMaster.Division_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genDivisionMaster.DivisionName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genDivisionMaster.CompanyBranch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genDivisionMaster.Adress = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genDivisionMaster.Telephone = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genDivisionMaster.Fax = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genDivisionMaster.ContactPerson = dataReader.GetString(6);
			}

			return tbl_genDivisionMaster;
		}
		/// <summary>
		/// This makes tbl_genDivisionMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genDivisionMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genDivisionMaster  tbl_genDivisionMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_divisionName = new DataColumn("divisionName" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_adress = new DataColumn("adress" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_contactPerson = new DataColumn("contactPerson" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_division_ID,col_divisionName,col_companyBranch_ID,col_adress,col_telephone,col_fax,col_contactPerson,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genDivisionMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genDivisionMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genDivisionMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["division_ID"] = user.division_ID;
			drow["divisionName"] = user.divisionName;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["adress"] = user.adress;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["contactPerson"] = user.contactPerson;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
