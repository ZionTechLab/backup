using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderNotice_Detail {
		#region Fields
		private string tender_ID;
		private string serialNo;
		private string tdrItem_Name;
		private string tdrItem_Specification;
		private string tdrItemStrength;
		private string tdrshelf_Life;
		private string tdrPackSize;
		private string tdrUoM;
		private decimal qty;
		private string item_ID;
		private bool isBidding;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderNotice_Detail class.
		/// </summary>
		public tbl_ttsTenderNotice_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderNotice_Detail class.
		/// </summary>
		public tbl_ttsTenderNotice_Detail(string tender_ID, string serialNo, string tdrItem_Name, string tdrItem_Specification, string tdrItemStrength, string tdrshelf_Life, string tdrPackSize, string tdrUoM, decimal qty, string item_ID, bool isBidding) {
			this.tender_ID = tender_ID;
			this.serialNo = serialNo;
			this.tdrItem_Name = tdrItem_Name;
			this.tdrItem_Specification = tdrItem_Specification;
			this.tdrItemStrength = tdrItemStrength;
			this.tdrshelf_Life = tdrshelf_Life;
			this.tdrPackSize = tdrPackSize;
			this.tdrUoM = tdrUoM;
			this.qty = qty;
			this.item_ID = item_ID;
			this.isBidding = isBidding;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo value.
		/// </summary>
		public string SerialNo {
			get { return serialNo; }
			set { serialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the TdrItem_Name value.
		/// </summary>
		public string TdrItem_Name {
			get { return tdrItem_Name; }
			set { tdrItem_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the TdrItem_Specification value.
		/// </summary>
		public string TdrItem_Specification {
			get { return tdrItem_Specification; }
			set { tdrItem_Specification = value; }
		}
		
		/// <summary>
		/// Gets or sets the TdrItemStrength value.
		/// </summary>
		public string TdrItemStrength {
			get { return tdrItemStrength; }
			set { tdrItemStrength = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tdrshelf_Life value.
		/// </summary>
		public string Tdrshelf_Life {
			get { return tdrshelf_Life; }
			set { tdrshelf_Life = value; }
		}
		
		/// <summary>
		/// Gets or sets the TdrPackSize value.
		/// </summary>
		public string TdrPackSize {
			get { return tdrPackSize; }
			set { tdrPackSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the TdrUoM value.
		/// </summary>
		public string TdrUoM {
			get { return tdrUoM; }
			set { tdrUoM = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBidding value.
		/// </summary>
		public bool IsBidding {
			get { return isBidding; }
			set { isBidding = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderNotice_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tdrItem_Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@tdrItem_Specification", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@tdrItemStrength", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tdrshelf_Life", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tdrPackSize", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tdrUoM", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isBidding", SqlDbType.Bit,1);
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@tdrItem_Name"].Value = tdrItem_Name;
			scom.Parameters["@tdrItem_Specification"].Value = tdrItem_Specification;
			scom.Parameters["@tdrItemStrength"].Value = tdrItemStrength;
			scom.Parameters["@tdrshelf_Life"].Value = tdrshelf_Life;
			scom.Parameters["@tdrPackSize"].Value = tdrPackSize;
			scom.Parameters["@tdrUoM"].Value = tdrUoM;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@isBidding"].Value = isBidding;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderNotice_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tdrItem_Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@tdrItem_Specification", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@tdrItemStrength", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tdrshelf_Life", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tdrPackSize", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tdrUoM", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isBidding", SqlDbType.Bit,1);
 
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@tdrItem_Name"].Value = tdrItem_Name;
			scom.Parameters["@tdrItem_Specification"].Value = tdrItem_Specification;
			scom.Parameters["@tdrItemStrength"].Value = tdrItemStrength;
			scom.Parameters["@tdrshelf_Life"].Value = tdrshelf_Life;
			scom.Parameters["@tdrPackSize"].Value = tdrPackSize;
			scom.Parameters["@tdrUoM"].Value = tdrUoM;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@isBidding"].Value = isBidding;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderNotice_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scom.Parameters["@serialNo"].Value = serialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			//scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			//scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderNotice_Detail table.
		/// </summary>
		public static tbl_ttsTenderNotice_Detail Select(string tender_ID_Incoming, string serialNo_Incoming){

			tbl_ttsTenderNotice_Detail tbl_ttsTenderNotice_Detailins = new tbl_ttsTenderNotice_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID_Incoming;
			scom.Parameters["@serialNo"].Value = serialNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderNotice_Detailins = Maketbl_ttsTenderNotice_Detail(dataReader);
				} else {
					tbl_ttsTenderNotice_Detailins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderNotice_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Detail table.
		/// </summary>
		public static List<tbl_ttsTenderNotice_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderNotice_Detail> tbl_ttsTenderNotice_DetailList = new List<tbl_ttsTenderNotice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice_Detail tbl_ttsTenderNotice_Detail = Maketbl_ttsTenderNotice_Detail(dataReader);
					tbl_ttsTenderNotice_DetailList.Add(tbl_ttsTenderNotice_Detail);
				}
			}
			scon.Close();
			return tbl_ttsTenderNotice_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_ttsTenderNotice_Detail> tbl_ttsTenderNotice_DetailList = new List<tbl_ttsTenderNotice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice_Detail tbl_ttsTenderNotice_Detail = Maketbl_ttsTenderNotice_Detail(dataReader);
					tbl_ttsTenderNotice_DetailList.Add(tbl_ttsTenderNotice_Detail);
				}
			}
			scon.Close();
			return tbl_ttsTenderNotice_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice_Detail> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNotice_DetailSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsTenderNotice_Detail> tbl_ttsTenderNotice_DetailList = new List<tbl_ttsTenderNotice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice_Detail tbl_ttsTenderNotice_Detail = Maketbl_ttsTenderNotice_Detail(dataReader);
					tbl_ttsTenderNotice_DetailList.Add(tbl_ttsTenderNotice_Detail);
				}
			}
			scon.Close();
			return tbl_ttsTenderNotice_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderNotice_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderNotice_Detail Maketbl_ttsTenderNotice_Detail(SqlDataReader dataReader) {
			tbl_ttsTenderNotice_Detail tbl_ttsTenderNotice_Detail = new tbl_ttsTenderNotice_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderNotice_Detail.Tender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderNotice_Detail.SerialNo = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderNotice_Detail.TdrItem_Name = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderNotice_Detail.TdrItem_Specification = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderNotice_Detail.TdrItemStrength = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsTenderNotice_Detail.Tdrshelf_Life = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsTenderNotice_Detail.TdrPackSize = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ttsTenderNotice_Detail.TdrUoM = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ttsTenderNotice_Detail.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ttsTenderNotice_Detail.Item_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ttsTenderNotice_Detail.IsBidding = dataReader.GetBoolean(10);
			}

			return tbl_ttsTenderNotice_Detail;
		}
		/// <summary>
		/// This makes tbl_ttsTenderNotice_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderNotice_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderNotice_Detail  tbl_ttsTenderNotice_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_serialNo = new DataColumn("serialNo" , typeof(string));
			DataColumn col_tdrItem_Name = new DataColumn("tdrItem_Name" , typeof(string));
			DataColumn col_tdrItem_Specification = new DataColumn("tdrItem_Specification" , typeof(string));
			DataColumn col_tdrItemStrength = new DataColumn("tdrItemStrength" , typeof(string));
			DataColumn col_tdrshelf_Life = new DataColumn("tdrshelf_Life" , typeof(string));
			DataColumn col_tdrPackSize = new DataColumn("tdrPackSize" , typeof(string));
			DataColumn col_tdrUoM = new DataColumn("tdrUoM" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_isBidding = new DataColumn("isBidding" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_tender_ID,col_serialNo,col_tdrItem_Name,col_tdrItem_Specification,col_tdrItemStrength,col_tdrshelf_Life,col_tdrPackSize,col_tdrUoM,col_qty,col_item_ID,col_isBidding,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderNotice_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderNotice_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderNotice_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["tender_ID"] = user.tender_ID;
			drow["serialNo"] = user.serialNo;
			drow["tdrItem_Name"] = user.tdrItem_Name;
			drow["tdrItem_Specification"] = user.tdrItem_Specification;
			drow["tdrItemStrength"] = user.tdrItemStrength;
			drow["tdrshelf_Life"] = user.tdrshelf_Life;
			drow["tdrPackSize"] = user.tdrPackSize;
			drow["tdrUoM"] = user.tdrUoM;
			drow["qty"] = user.qty;
			drow["item_ID"] = user.item_ID;
			drow["isBidding"] = user.isBidding;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
