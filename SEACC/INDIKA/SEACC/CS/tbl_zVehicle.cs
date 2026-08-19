using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zVehicle {
		#region Fields
		private string vehicle_ID;
		private string vehicleName;
		private string vehicleNumber;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zVehicle class.
		/// </summary>
		public tbl_zVehicle() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zVehicle class.
		/// </summary>
		public tbl_zVehicle(string vehicle_ID, string vehicleName, string vehicleNumber) {
			this.vehicle_ID = vehicle_ID;
			this.vehicleName = vehicleName;
			this.vehicleNumber = vehicleNumber;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Vehicle_ID value.
		/// </summary>
		public string Vehicle_ID {
			get { return vehicle_ID; }
			set { vehicle_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VehicleName value.
		/// </summary>
		public string VehicleName {
			get { return vehicleName; }
			set { vehicleName = value; }
		}
		
		/// <summary>
		/// Gets or sets the VehicleNumber value.
		/// </summary>
		public string VehicleNumber {
			get { return vehicleNumber; }
			set { vehicleNumber = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zVehicle table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zVehicleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicleName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vehicleNumber", SqlDbType.VarChar,50);
 
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
			scom.Parameters["@vehicleName"].Value = vehicleName;
			scom.Parameters["@vehicleNumber"].Value = vehicleNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zVehicle table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zVehicleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicleName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vehicleNumber", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
			scom.Parameters["@vehicleName"].Value = vehicleName;
			scom.Parameters["@vehicleNumber"].Value = vehicleNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zVehicle table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zVehicleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zVehicle table.
		/// </summary>
		public static tbl_zVehicle Select(string vehicle_ID_Incoming){

			tbl_zVehicle tbl_zVehicleins = new tbl_zVehicle();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zVehicleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zVehicleins = Maketbl_zVehicle(dataReader);
				} else {
					tbl_zVehicleins = null;
				}
			}
			scon.Close();
			return tbl_zVehicleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zVehicle table.
		/// </summary>
		public static List<tbl_zVehicle> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zVehicleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zVehicle> tbl_zVehicleList = new List<tbl_zVehicle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zVehicle tbl_zVehicle = Maketbl_zVehicle(dataReader);
					tbl_zVehicleList.Add(tbl_zVehicle);
				}
			}
			scon.Close();
			return tbl_zVehicleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zVehicle class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zVehicle Maketbl_zVehicle(SqlDataReader dataReader) {
			tbl_zVehicle tbl_zVehicle = new tbl_zVehicle();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zVehicle.Vehicle_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zVehicle.VehicleName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zVehicle.VehicleNumber = dataReader.GetString(2);
			}

			return tbl_zVehicle;
		}
		/// <summary>
		/// This fills tbl_zVehicle datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zVehicle object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zVehicle user) {
		DataRow drow = dt.NewRow();
		
			drow["vehicle_ID"] = user.vehicle_ID;
			drow["vehicleName"] = user.vehicleName;
			drow["vehicleNumber"] = user.vehicleNumber;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
