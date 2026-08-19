using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accDoubleEntrySlotMaster {
		#region Fields
		private int slot_ID;
		private string slotName;
		private string slotCategory_ID;
		private bool isDelete;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accDoubleEntrySlotMaster class.
		/// </summary>
		public tbl_accDoubleEntrySlotMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accDoubleEntrySlotMaster class.
		/// </summary>
		public tbl_accDoubleEntrySlotMaster(int slot_ID, string slotName, string slotCategory_ID, bool isDelete) {
			this.slot_ID = slot_ID;
			this.slotName = slotName;
			this.slotCategory_ID = slotCategory_ID;
			this.isDelete = isDelete;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Slot_ID value.
		/// </summary>
		public int Slot_ID {
			get { return slot_ID; }
			set { slot_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlotName value.
		/// </summary>
		public string SlotName {
			get { return slotName; }
			set { slotName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlotCategory_ID value.
		/// </summary>
		public string SlotCategory_ID {
			get { return slotCategory_ID; }
			set { slotCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelete value.
		/// </summary>
		public bool IsDelete {
			get { return isDelete; }
			set { isDelete = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accDoubleEntrySlotMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@slotName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@IsDelete", SqlDbType.Bit,1);
 
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@slotName"].Value = slotName;
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID;
			scom.Parameters["@IsDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accDoubleEntrySlotMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@slotName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@IsDelete", SqlDbType.Bit,1);
 
 
			scom.Parameters["@slot_ID"].Value = slot_ID;
			scom.Parameters["@slotName"].Value = slotName;
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID;
			scom.Parameters["@IsDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accDoubleEntrySlotMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters["@slot_ID"].Value = slot_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDoubleEntrySlotMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllBySlotCategory_ID(string slotCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotMasterDeleteAllBySlotCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accDoubleEntrySlotMaster table.
		/// </summary>
		public static tbl_accDoubleEntrySlotMaster Select(int slot_ID_Incoming){

			tbl_accDoubleEntrySlotMaster tbl_accDoubleEntrySlotMasterins = new tbl_accDoubleEntrySlotMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slot_ID", SqlDbType.Int,4);
			scom.Parameters["@slot_ID"].Value = slot_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accDoubleEntrySlotMasterins = Maketbl_accDoubleEntrySlotMaster(dataReader);
				} else {
					tbl_accDoubleEntrySlotMasterins = null;
				}
			}
			scon.Close();
			return tbl_accDoubleEntrySlotMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDoubleEntrySlotMaster table.
		/// </summary>
		public static List<tbl_accDoubleEntrySlotMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accDoubleEntrySlotMaster> tbl_accDoubleEntrySlotMasterList = new List<tbl_accDoubleEntrySlotMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDoubleEntrySlotMaster tbl_accDoubleEntrySlotMaster = Maketbl_accDoubleEntrySlotMaster(dataReader);
					tbl_accDoubleEntrySlotMasterList.Add(tbl_accDoubleEntrySlotMaster);
				}
			}
			scon.Close();
			return tbl_accDoubleEntrySlotMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDoubleEntrySlotMaster table by a foreign key.
		/// </summary>
		public static List<tbl_accDoubleEntrySlotMaster> SelectAllBySlotCategory_ID(string slotCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDoubleEntrySlotMasterSelectAllBySlotCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID;
				List<tbl_accDoubleEntrySlotMaster> tbl_accDoubleEntrySlotMasterList = new List<tbl_accDoubleEntrySlotMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDoubleEntrySlotMaster tbl_accDoubleEntrySlotMaster = Maketbl_accDoubleEntrySlotMaster(dataReader);
					tbl_accDoubleEntrySlotMasterList.Add(tbl_accDoubleEntrySlotMaster);
				}
			}
			scon.Close();
			return tbl_accDoubleEntrySlotMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accDoubleEntrySlotMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accDoubleEntrySlotMaster Maketbl_accDoubleEntrySlotMaster(SqlDataReader dataReader) {
			tbl_accDoubleEntrySlotMaster tbl_accDoubleEntrySlotMaster = new tbl_accDoubleEntrySlotMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accDoubleEntrySlotMaster.Slot_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accDoubleEntrySlotMaster.SlotName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accDoubleEntrySlotMaster.SlotCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accDoubleEntrySlotMaster.IsDelete = dataReader.GetBoolean(3);
			}

			return tbl_accDoubleEntrySlotMaster;
		}
		/// <summary>
		/// This makes tbl_accDoubleEntrySlotMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accDoubleEntrySlotMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accDoubleEntrySlotMaster  tbl_accDoubleEntrySlotMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_slot_ID = new DataColumn("slot_ID" , typeof(int));
			DataColumn col_slotName = new DataColumn("slotName" , typeof(string));
			DataColumn col_slotCategory_ID = new DataColumn("slotCategory_ID" , typeof(string));
			DataColumn col_IsDelete = new DataColumn("IsDelete" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_slot_ID,col_slotName,col_slotCategory_ID,col_IsDelete,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accDoubleEntrySlotMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accDoubleEntrySlotMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accDoubleEntrySlotMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["slot_ID"] = user.slot_ID;
			drow["slotName"] = user.slotName;
			drow["slotCategory_ID"] = user.slotCategory_ID;
			drow["IsDelete"] = user.IsDelete;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
