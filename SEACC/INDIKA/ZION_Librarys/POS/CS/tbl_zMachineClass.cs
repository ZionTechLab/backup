using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zMachineClass {
		#region Fields
		private string machineClass_ID;
		private string className;
		private string prefrix;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineClass class.
		/// </summary>
		public tbl_zMachineClass() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineClass class.
		/// </summary>
		public tbl_zMachineClass(string machineClass_ID, string className, string prefrix) {
			this.machineClass_ID = machineClass_ID;
			this.className = className;
			this.prefrix = prefrix;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MachineClass_ID value.
		/// </summary>
		public string MachineClass_ID {
			get { return machineClass_ID; }
			set { machineClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClassName value.
		/// </summary>
		public string ClassName {
			get { return className; }
			set { className = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix value.
		/// </summary>
		public string Prefrix {
			get { return prefrix; }
			set { prefrix = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zMachineClass table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineClassInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
			scom.Parameters["@className"].Value = className;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zMachineClass table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineClassUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
			scom.Parameters["@className"].Value = className;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zMachineClass table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineClassDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zMachineClass table.
		/// </summary>
		public static tbl_zMachineClass Select(string machineClass_ID_Incoming){

			tbl_zMachineClass tbl_zMachineClassins = new tbl_zMachineClass();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineClassSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zMachineClassins = Maketbl_zMachineClass(dataReader);
				} else {
					tbl_zMachineClassins = null;
				}
			}
			scon.Close();
			return tbl_zMachineClassins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineClass table.
		/// </summary>
		public static List<tbl_zMachineClass> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineClassSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zMachineClass> tbl_zMachineClassList = new List<tbl_zMachineClass>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineClass tbl_zMachineClass = Maketbl_zMachineClass(dataReader);
					tbl_zMachineClassList.Add(tbl_zMachineClass);
				}
			}
			scon.Close();
			return tbl_zMachineClassList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zMachineClass class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zMachineClass Maketbl_zMachineClass(SqlDataReader dataReader) {
			tbl_zMachineClass tbl_zMachineClass = new tbl_zMachineClass();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zMachineClass.MachineClass_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zMachineClass.ClassName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zMachineClass.Prefrix = dataReader.GetString(2);
			}

			return tbl_zMachineClass;
		}
		/// <summary>
		/// This makes tbl_zMachineClass datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zMachineClass object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zMachineClass  tbl_zMachineClass   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machineClass_ID = new DataColumn("machineClass_ID" , typeof(string));
			DataColumn col_className = new DataColumn("className" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machineClass_ID,col_className,col_prefrix,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zMachineClass datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zMachineClass object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zMachineClass user) {
		DataRow drow = dt.NewRow();
		
			drow["machineClass_ID"] = user.machineClass_ID;
			drow["className"] = user.className;
			drow["prefrix"] = user.prefrix;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
