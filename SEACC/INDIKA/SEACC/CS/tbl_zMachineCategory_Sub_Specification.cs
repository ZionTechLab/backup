using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zMachineCategory_Sub_Specification {
		#region Fields
		private string machineCategorySub_ID;
		private string machineSepcification_ID;
		private string specificationValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineCategory_Sub_Specification class.
		/// </summary>
		public tbl_zMachineCategory_Sub_Specification() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineCategory_Sub_Specification class.
		/// </summary>
		public tbl_zMachineCategory_Sub_Specification(string machineCategorySub_ID, string machineSepcification_ID, string specificationValue) {
			this.machineCategorySub_ID = machineCategorySub_ID;
			this.machineSepcification_ID = machineSepcification_ID;
			this.specificationValue = specificationValue;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MachineCategorySub_ID value.
		/// </summary>
		public string MachineCategorySub_ID {
			get { return machineCategorySub_ID; }
			set { machineCategorySub_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineSepcification_ID value.
		/// </summary>
		public string MachineSepcification_ID {
			get { return machineSepcification_ID; }
			set { machineSepcification_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpecificationValue value.
		/// </summary>
		public string SpecificationValue {
			get { return specificationValue; }
			set { specificationValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zMachineCategory_Sub_Specification table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@specificationValue", SqlDbType.VarChar,50);
 
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
			scom.Parameters["@specificationValue"].Value = specificationValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zMachineCategory_Sub_Specification table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@specificationValue", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
			scom.Parameters["@specificationValue"].Value = specificationValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zMachineCategory_Sub_Specification table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
 
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineCategorySub_ID(string machineCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationDeleteAllByMachineCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineSepcification_ID(string machineSepcification_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationDeleteAllByMachineSepcification_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zMachineCategory_Sub_Specification table.
		/// </summary>
		public static tbl_zMachineCategory_Sub_Specification Select(string machineCategorySub_ID_Incoming, string machineSepcification_ID_Incoming){

			tbl_zMachineCategory_Sub_Specification tbl_zMachineCategory_Sub_Specificationins = new tbl_zMachineCategory_Sub_Specification();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID_Incoming;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zMachineCategory_Sub_Specificationins = Maketbl_zMachineCategory_Sub_Specification(dataReader);
				} else {
					tbl_zMachineCategory_Sub_Specificationins = null;
				}
			}
			scon.Close();
			return tbl_zMachineCategory_Sub_Specificationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub_Specification table.
		/// </summary>
		public static List<tbl_zMachineCategory_Sub_Specification> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zMachineCategory_Sub_Specification> tbl_zMachineCategory_Sub_SpecificationList = new List<tbl_zMachineCategory_Sub_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineCategory_Sub_Specification tbl_zMachineCategory_Sub_Specification = Maketbl_zMachineCategory_Sub_Specification(dataReader);
					tbl_zMachineCategory_Sub_SpecificationList.Add(tbl_zMachineCategory_Sub_Specification);
				}
			}
			scon.Close();
			return tbl_zMachineCategory_Sub_SpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static List<tbl_zMachineCategory_Sub_Specification> SelectAllByMachineCategorySub_ID(string machineCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationSelectAllByMachineCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
				List<tbl_zMachineCategory_Sub_Specification> tbl_zMachineCategory_Sub_SpecificationList = new List<tbl_zMachineCategory_Sub_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineCategory_Sub_Specification tbl_zMachineCategory_Sub_Specification = Maketbl_zMachineCategory_Sub_Specification(dataReader);
					tbl_zMachineCategory_Sub_SpecificationList.Add(tbl_zMachineCategory_Sub_Specification);
				}
			}
			scon.Close();
			return tbl_zMachineCategory_Sub_SpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static List<tbl_zMachineCategory_Sub_Specification> SelectAllByMachineSepcification_ID(string machineSepcification_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_Sub_SpecificationSelectAllByMachineSepcification_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
				List<tbl_zMachineCategory_Sub_Specification> tbl_zMachineCategory_Sub_SpecificationList = new List<tbl_zMachineCategory_Sub_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineCategory_Sub_Specification tbl_zMachineCategory_Sub_Specification = Maketbl_zMachineCategory_Sub_Specification(dataReader);
					tbl_zMachineCategory_Sub_SpecificationList.Add(tbl_zMachineCategory_Sub_Specification);
				}
			}
			scon.Close();
			return tbl_zMachineCategory_Sub_SpecificationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zMachineCategory_Sub_Specification class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zMachineCategory_Sub_Specification Maketbl_zMachineCategory_Sub_Specification(SqlDataReader dataReader) {
			tbl_zMachineCategory_Sub_Specification tbl_zMachineCategory_Sub_Specification = new tbl_zMachineCategory_Sub_Specification();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zMachineCategory_Sub_Specification.MachineCategorySub_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zMachineCategory_Sub_Specification.MachineSepcification_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zMachineCategory_Sub_Specification.SpecificationValue = dataReader.GetString(2);
			}

			return tbl_zMachineCategory_Sub_Specification;
		}
		/// <summary>
		/// This makes tbl_zMachineCategory_Sub_Specification datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zMachineCategory_Sub_Specification object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zMachineCategory_Sub_Specification  tbl_zMachineCategory_Sub_Specification   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machineCategorySub_ID = new DataColumn("machineCategorySub_ID" , typeof(string));
			DataColumn col_machineSepcification_ID = new DataColumn("machineSepcification_ID" , typeof(string));
			DataColumn col_specificationValue = new DataColumn("specificationValue" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machineCategorySub_ID,col_machineSepcification_ID,col_specificationValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zMachineCategory_Sub_Specification datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zMachineCategory_Sub_Specification object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zMachineCategory_Sub_Specification user) {
		DataRow drow = dt.NewRow();
		
			drow["machineCategorySub_ID"] = user.machineCategorySub_ID;
			drow["machineSepcification_ID"] = user.machineSepcification_ID;
			drow["specificationValue"] = user.specificationValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
