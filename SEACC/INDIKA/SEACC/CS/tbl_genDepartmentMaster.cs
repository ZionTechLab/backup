using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genDepartmentMaster {
		#region Fields
		private string department_ID;
		private string departmentName;
		private string division_ID;
		private string store_ID;
		private string adress;
		private string telephone;
		private string fax;
		private string contactPerson;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genDepartmentMaster class.
		/// </summary>
		public tbl_genDepartmentMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genDepartmentMaster class.
		/// </summary>
		public tbl_genDepartmentMaster(string department_ID, string departmentName, string division_ID, string store_ID, string adress, string telephone, string fax, string contactPerson) {
			this.department_ID = department_ID;
			this.departmentName = departmentName;
			this.division_ID = division_ID;
			this.store_ID = store_ID;
			this.adress = adress;
			this.telephone = telephone;
			this.fax = fax;
			this.contactPerson = contactPerson;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepartmentName value.
		/// </summary>
		public string DepartmentName {
			get { return departmentName; }
			set { departmentName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Division_ID value.
		/// </summary>
		public string Division_ID {
			get { return division_ID; }
			set { division_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
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
		/// Saves a record to the tbl_genDepartmentMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
 
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@departmentName"].Value = departmentName;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genDepartmentMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@departmentName"].Value = departmentName;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genDepartmentMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartmentMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartmentMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByDivision_ID(string division_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterDeleteAllByDivision_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters["@division_ID"].Value = division_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genDepartmentMaster table.
		/// </summary>
		public static tbl_genDepartmentMaster Select(string department_ID_Incoming){

			tbl_genDepartmentMaster tbl_genDepartmentMasterins = new tbl_genDepartmentMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genDepartmentMasterins = Maketbl_genDepartmentMaster(dataReader);
				} else {
					tbl_genDepartmentMasterins = null;
				}
			}
			scon.Close();
			return tbl_genDepartmentMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartmentMaster table.
		/// </summary>
		public static List<tbl_genDepartmentMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genDepartmentMaster> tbl_genDepartmentMasterList = new List<tbl_genDepartmentMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartmentMaster tbl_genDepartmentMaster = Maketbl_genDepartmentMaster(dataReader);
					tbl_genDepartmentMasterList.Add(tbl_genDepartmentMaster);
				}
			}
			scon.Close();
			return tbl_genDepartmentMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartmentMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genDepartmentMaster> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_genDepartmentMaster> tbl_genDepartmentMasterList = new List<tbl_genDepartmentMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartmentMaster tbl_genDepartmentMaster = Maketbl_genDepartmentMaster(dataReader);
					tbl_genDepartmentMasterList.Add(tbl_genDepartmentMaster);
				}
			}
			scon.Close();
			return tbl_genDepartmentMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genDepartmentMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genDepartmentMaster> SelectAllByDivision_ID(string division_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genDepartmentMasterSelectAllByDivision_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters["@division_ID"].Value = division_ID;
				List<tbl_genDepartmentMaster> tbl_genDepartmentMasterList = new List<tbl_genDepartmentMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genDepartmentMaster tbl_genDepartmentMaster = Maketbl_genDepartmentMaster(dataReader);
					tbl_genDepartmentMasterList.Add(tbl_genDepartmentMaster);
				}
			}
			scon.Close();
			return tbl_genDepartmentMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genDepartmentMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genDepartmentMaster Maketbl_genDepartmentMaster(SqlDataReader dataReader) {
			tbl_genDepartmentMaster tbl_genDepartmentMaster = new tbl_genDepartmentMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genDepartmentMaster.Department_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genDepartmentMaster.DepartmentName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genDepartmentMaster.Division_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genDepartmentMaster.Store_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genDepartmentMaster.Adress = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genDepartmentMaster.Telephone = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genDepartmentMaster.Fax = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genDepartmentMaster.ContactPerson = dataReader.GetString(7);
			}

			return tbl_genDepartmentMaster;
		}
		/// <summary>
		/// This makes tbl_genDepartmentMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genDepartmentMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genDepartmentMaster  tbl_genDepartmentMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_departmentName = new DataColumn("departmentName" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_adress = new DataColumn("adress" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_contactPerson = new DataColumn("contactPerson" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_department_ID,col_departmentName,col_division_ID,col_store_ID,col_adress,col_telephone,col_fax,col_contactPerson,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genDepartmentMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genDepartmentMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genDepartmentMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["department_ID"] = user.department_ID;
			drow["departmentName"] = user.departmentName;
			drow["division_ID"] = user.division_ID;
			drow["store_ID"] = user.store_ID;
			drow["adress"] = user.adress;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["contactPerson"] = user.contactPerson;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
