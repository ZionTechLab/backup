using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zStockNoteType {
		#region Fields
		private string stockNoteType_ID;
		private string stockNoteName;
		private string prPrefix;
		private int prCounter;
		private int prLength;
		private string poPrefix;
		private int poCounter;
		private int poLength;
		private string grnPrefix;
		private int grnCounter;
		private int grnLength;
		private string prnPrefix;
		private int prnCounter;
		private int prnLength;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zStockNoteType class.
		/// </summary>
		public tbl_zStockNoteType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zStockNoteType class.
		/// </summary>
		public tbl_zStockNoteType(string stockNoteType_ID, string stockNoteName, string prPrefix, int prCounter, int prLength, string poPrefix, int poCounter, int poLength, string grnPrefix, int grnCounter, int grnLength, string prnPrefix, int prnCounter, int prnLength) {
			this.stockNoteType_ID = stockNoteType_ID;
			this.stockNoteName = stockNoteName;
			this.prPrefix = prPrefix;
			this.prCounter = prCounter;
			this.prLength = prLength;
			this.poPrefix = poPrefix;
			this.poCounter = poCounter;
			this.poLength = poLength;
			this.grnPrefix = grnPrefix;
			this.grnCounter = grnCounter;
			this.grnLength = grnLength;
			this.prnPrefix = prnPrefix;
			this.prnCounter = prnCounter;
			this.prnLength = prnLength;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StockNoteType_ID value.
		/// </summary>
		public string StockNoteType_ID {
			get { return stockNoteType_ID; }
			set { stockNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockNoteName value.
		/// </summary>
		public string StockNoteName {
			get { return stockNoteName; }
			set { stockNoteName = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrPrefix value.
		/// </summary>
		public string PrPrefix {
			get { return prPrefix; }
			set { prPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrCounter value.
		/// </summary>
		public int PrCounter {
			get { return prCounter; }
			set { prCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrLength value.
		/// </summary>
		public int PrLength {
			get { return prLength; }
			set { prLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the PoPrefix value.
		/// </summary>
		public string PoPrefix {
			get { return poPrefix; }
			set { poPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the PoCounter value.
		/// </summary>
		public int PoCounter {
			get { return poCounter; }
			set { poCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the PoLength value.
		/// </summary>
		public int PoLength {
			get { return poLength; }
			set { poLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrnPrefix value.
		/// </summary>
		public string GrnPrefix {
			get { return grnPrefix; }
			set { grnPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrnCounter value.
		/// </summary>
		public int GrnCounter {
			get { return grnCounter; }
			set { grnCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrnLength value.
		/// </summary>
		public int GrnLength {
			get { return grnLength; }
			set { grnLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrnPrefix value.
		/// </summary>
		public string PrnPrefix {
			get { return prnPrefix; }
			set { prnPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrnCounter value.
		/// </summary>
		public int PrnCounter {
			get { return prnCounter; }
			set { prnCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrnLength value.
		/// </summary>
		public int PrnLength {
			get { return prnLength; }
			set { prnLength = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zStockNoteType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStockNoteTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@stockNoteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@prLength", SqlDbType.Int,4);
			scom.Parameters.Add("@poPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@poCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@poLength", SqlDbType.Int,4);
			scom.Parameters.Add("@grnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@grnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@grnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@prnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@prnLength", SqlDbType.Int,4);
 
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@stockNoteName"].Value = stockNoteName;
			scom.Parameters["@prPrefix"].Value = prPrefix;
			scom.Parameters["@prCounter"].Value = prCounter;
			scom.Parameters["@prLength"].Value = prLength;
			scom.Parameters["@poPrefix"].Value = poPrefix;
			scom.Parameters["@poCounter"].Value = poCounter;
			scom.Parameters["@poLength"].Value = poLength;
			scom.Parameters["@grnPrefix"].Value = grnPrefix;
			scom.Parameters["@grnCounter"].Value = grnCounter;
			scom.Parameters["@grnLength"].Value = grnLength;
			scom.Parameters["@prnPrefix"].Value = prnPrefix;
			scom.Parameters["@prnCounter"].Value = prnCounter;
			scom.Parameters["@prnLength"].Value = prnLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zStockNoteType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStockNoteTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@stockNoteName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@prLength", SqlDbType.Int,4);
			scom.Parameters.Add("@poPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@poCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@poLength", SqlDbType.Int,4);
			scom.Parameters.Add("@grnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@grnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@grnLength", SqlDbType.Int,4);
			scom.Parameters.Add("@prnPrefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prnCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@prnLength", SqlDbType.Int,4);
 
 
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@stockNoteName"].Value = stockNoteName;
			scom.Parameters["@prPrefix"].Value = prPrefix;
			scom.Parameters["@prCounter"].Value = prCounter;
			scom.Parameters["@prLength"].Value = prLength;
			scom.Parameters["@poPrefix"].Value = poPrefix;
			scom.Parameters["@poCounter"].Value = poCounter;
			scom.Parameters["@poLength"].Value = poLength;
			scom.Parameters["@grnPrefix"].Value = grnPrefix;
			scom.Parameters["@grnCounter"].Value = grnCounter;
			scom.Parameters["@grnLength"].Value = grnLength;
			scom.Parameters["@prnPrefix"].Value = prnPrefix;
			scom.Parameters["@prnCounter"].Value = prnCounter;
			scom.Parameters["@prnLength"].Value = prnLength;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zStockNoteType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStockNoteTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zStockNoteType table.
		/// </summary>
		public static tbl_zStockNoteType Select(string stockNoteType_ID_Incoming){

			tbl_zStockNoteType tbl_zStockNoteTypeins = new tbl_zStockNoteType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStockNoteTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zStockNoteTypeins = Maketbl_zStockNoteType(dataReader);
				} else {
					tbl_zStockNoteTypeins = null;
				}
			}
			scon.Close();
			return tbl_zStockNoteTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zStockNoteType table.
		/// </summary>
		public static List<tbl_zStockNoteType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStockNoteTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zStockNoteType> tbl_zStockNoteTypeList = new List<tbl_zStockNoteType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zStockNoteType tbl_zStockNoteType = Maketbl_zStockNoteType(dataReader);
					tbl_zStockNoteTypeList.Add(tbl_zStockNoteType);
				}
			}
			scon.Close();
			return tbl_zStockNoteTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zStockNoteType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zStockNoteType Maketbl_zStockNoteType(SqlDataReader dataReader) {
			tbl_zStockNoteType tbl_zStockNoteType = new tbl_zStockNoteType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zStockNoteType.StockNoteType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zStockNoteType.StockNoteName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zStockNoteType.PrPrefix = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zStockNoteType.PrCounter = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zStockNoteType.PrLength = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zStockNoteType.PoPrefix = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zStockNoteType.PoCounter = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zStockNoteType.PoLength = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zStockNoteType.GrnPrefix = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zStockNoteType.GrnCounter = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zStockNoteType.GrnLength = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_zStockNoteType.PrnPrefix = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_zStockNoteType.PrnCounter = dataReader.GetInt32(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_zStockNoteType.PrnLength = dataReader.GetInt32(13);
			}

			return tbl_zStockNoteType;
		}
		/// <summary>
		/// This makes tbl_zStockNoteType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zStockNoteType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zStockNoteType  tbl_zStockNoteType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_stockNoteType_ID = new DataColumn("stockNoteType_ID" , typeof(string));
			DataColumn col_stockNoteName = new DataColumn("stockNoteName" , typeof(string));
			DataColumn col_prPrefix = new DataColumn("prPrefix" , typeof(string));
			DataColumn col_prCounter = new DataColumn("prCounter" , typeof(int));
			DataColumn col_prLength = new DataColumn("prLength" , typeof(int));
			DataColumn col_poPrefix = new DataColumn("poPrefix" , typeof(string));
			DataColumn col_poCounter = new DataColumn("poCounter" , typeof(int));
			DataColumn col_poLength = new DataColumn("poLength" , typeof(int));
			DataColumn col_grnPrefix = new DataColumn("grnPrefix" , typeof(string));
			DataColumn col_grnCounter = new DataColumn("grnCounter" , typeof(int));
			DataColumn col_grnLength = new DataColumn("grnLength" , typeof(int));
			DataColumn col_prnPrefix = new DataColumn("prnPrefix" , typeof(string));
			DataColumn col_prnCounter = new DataColumn("prnCounter" , typeof(int));
			DataColumn col_prnLength = new DataColumn("prnLength" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_stockNoteType_ID,col_stockNoteName,col_prPrefix,col_prCounter,col_prLength,col_poPrefix,col_poCounter,col_poLength,col_grnPrefix,col_grnCounter,col_grnLength,col_prnPrefix,col_prnCounter,col_prnLength,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zStockNoteType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zStockNoteType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zStockNoteType user) {
		DataRow drow = dt.NewRow();
		
			drow["stockNoteType_ID"] = user.stockNoteType_ID;
			drow["stockNoteName"] = user.stockNoteName;
			drow["prPrefix"] = user.prPrefix;
			drow["prCounter"] = user.prCounter;
			drow["prLength"] = user.prLength;
			drow["poPrefix"] = user.poPrefix;
			drow["poCounter"] = user.poCounter;
			drow["poLength"] = user.poLength;
			drow["grnPrefix"] = user.grnPrefix;
			drow["grnCounter"] = user.grnCounter;
			drow["grnLength"] = user.grnLength;
			drow["prnPrefix"] = user.prnPrefix;
			drow["prnCounter"] = user.prnCounter;
			drow["prnLength"] = user.prnLength;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
