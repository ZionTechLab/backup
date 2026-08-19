using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsFixedAsset {
		#region Fields
		private int barcode_ID;
		private string fixedAsset_Code;
		private string assetTransferNote_ID;
		private string store_ID;
		private DateTime acquisition_date;
		private decimal lifeTime;
		private decimal depreciationRate;
		private decimal cost;
		private decimal totalAccumulatedDepreciation;
		private decimal writeDownValue;
		private bool isDepreciated;
		private bool isDeleted;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string deletedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateDeleted;
		private string lastFinancialYear_ID;
		private string lastMonth_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsFixedAsset class.
		/// </summary>
		public tbl_scsFixedAsset() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsFixedAsset class.
		/// </summary>
		public tbl_scsFixedAsset(int barcode_ID, string fixedAsset_Code, string assetTransferNote_ID, string store_ID, DateTime acquisition_date, decimal lifeTime, decimal depreciationRate, decimal cost, decimal totalAccumulatedDepreciation, decimal writeDownValue, bool isDepreciated, bool isDeleted, string createUser_ID, string modifiedUser_ID, string deletedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted, string lastFinancialYear_ID, string lastMonth_ID) {
			this.barcode_ID = barcode_ID;
			this.fixedAsset_Code = fixedAsset_Code;
			this.assetTransferNote_ID = assetTransferNote_ID;
			this.store_ID = store_ID;
			this.acquisition_date = acquisition_date;
			this.lifeTime = lifeTime;
			this.depreciationRate = depreciationRate;
			this.cost = cost;
			this.totalAccumulatedDepreciation = totalAccumulatedDepreciation;
			this.writeDownValue = writeDownValue;
			this.isDepreciated = isDepreciated;
			this.isDeleted = isDeleted;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDeleted = dateDeleted;
			this.lastFinancialYear_ID = lastFinancialYear_ID;
			this.lastMonth_ID = lastMonth_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Barcode_ID value.
		/// </summary>
		public int Barcode_ID {
			get { return barcode_ID; }
			set { barcode_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FixedAsset_Code value.
		/// </summary>
		public string FixedAsset_Code {
			get { return fixedAsset_Code; }
			set { fixedAsset_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the AssetTransferNote_ID value.
		/// </summary>
		public string AssetTransferNote_ID {
			get { return assetTransferNote_ID; }
			set { assetTransferNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Acquisition_date value.
		/// </summary>
		public DateTime Acquisition_date {
			get { return acquisition_date; }
			set { acquisition_date = value; }
		}
		
		/// <summary>
		/// Gets or sets the LifeTime value.
		/// </summary>
		public decimal LifeTime {
			get { return lifeTime; }
			set { lifeTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepreciationRate value.
		/// </summary>
		public decimal DepreciationRate {
			get { return depreciationRate; }
			set { depreciationRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost value.
		/// </summary>
		public decimal Cost {
			get { return cost; }
			set { cost = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAccumulatedDepreciation value.
		/// </summary>
		public decimal TotalAccumulatedDepreciation {
			get { return totalAccumulatedDepreciation; }
			set { totalAccumulatedDepreciation = value; }
		}
		
		/// <summary>
		/// Gets or sets the WriteDownValue value.
		/// </summary>
		public decimal WriteDownValue {
			get { return writeDownValue; }
			set { writeDownValue = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDepreciated value.
		/// </summary>
		public bool IsDepreciated {
			get { return isDepreciated; }
			set { isDepreciated = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastFinancialYear_ID value.
		/// </summary>
		public string LastFinancialYear_ID {
			get { return lastFinancialYear_ID; }
			set { lastFinancialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastMonth_ID value.
		/// </summary>
		public string LastMonth_ID {
			get { return lastMonth_ID; }
			set { lastMonth_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsFixedAsset table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@fixedAsset_Code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@assetTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@acquisition_date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lifeTime", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAccumulatedDepreciation", SqlDbType.Decimal,9);
			scom.Parameters.Add("@writeDownValue", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDepreciated", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lastFinancialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lastMonth_ID", SqlDbType.VarChar,100);
 
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
			scom.Parameters["@fixedAsset_Code"].Value = fixedAsset_Code;
			scom.Parameters["@assetTransferNote_ID"].Value = assetTransferNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@acquisition_date"].Value = acquisition_date;
			scom.Parameters["@lifeTime"].Value = lifeTime;
			scom.Parameters["@depreciationRate"].Value = depreciationRate;
			scom.Parameters["@cost"].Value = cost;
			scom.Parameters["@totalAccumulatedDepreciation"].Value = totalAccumulatedDepreciation;
			scom.Parameters["@writeDownValue"].Value = writeDownValue;
			scom.Parameters["@isDepreciated"].Value = isDepreciated;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@lastFinancialYear_ID"].Value = lastFinancialYear_ID;
			scom.Parameters["@lastMonth_ID"].Value = lastMonth_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsFixedAsset table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@fixedAsset_Code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@assetTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@acquisition_date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lifeTime", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAccumulatedDepreciation", SqlDbType.Decimal,9);
			scom.Parameters.Add("@writeDownValue", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDepreciated", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lastFinancialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lastMonth_ID", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
			scom.Parameters["@fixedAsset_Code"].Value = fixedAsset_Code;
			scom.Parameters["@assetTransferNote_ID"].Value = assetTransferNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@acquisition_date"].Value = acquisition_date;
			scom.Parameters["@lifeTime"].Value = lifeTime;
			scom.Parameters["@depreciationRate"].Value = depreciationRate;
			scom.Parameters["@cost"].Value = cost;
			scom.Parameters["@totalAccumulatedDepreciation"].Value = totalAccumulatedDepreciation;
			scom.Parameters["@writeDownValue"].Value = writeDownValue;
			scom.Parameters["@isDepreciated"].Value = isDepreciated;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@lastFinancialYear_ID"].Value = lastFinancialYear_ID;
			scom.Parameters["@lastMonth_ID"].Value = lastMonth_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsFixedAsset table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAsset table by a foreign key.
		/// </summary>
		public static void DeleteAllByBarcode_ID(int barcode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetDeleteAllByBarcode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsFixedAsset table.
		/// </summary>
		public static tbl_scsFixedAsset Select(int barcode_ID_Incoming){

			tbl_scsFixedAsset tbl_scsFixedAssetins = new tbl_scsFixedAsset();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsFixedAssetins = Maketbl_scsFixedAsset(dataReader);
				} else {
					tbl_scsFixedAssetins = null;
				}
			}
			scon.Close();
			return tbl_scsFixedAssetins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAsset table.
		/// </summary>
		public static List<tbl_scsFixedAsset> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsFixedAsset> tbl_scsFixedAssetList = new List<tbl_scsFixedAsset>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsFixedAsset tbl_scsFixedAsset = Maketbl_scsFixedAsset(dataReader);
					tbl_scsFixedAssetList.Add(tbl_scsFixedAsset);
				}
			}
			scon.Close();
			return tbl_scsFixedAssetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsFixedAsset table by a foreign key.
		/// </summary>
		public static List<tbl_scsFixedAsset> SelectAllByBarcode_ID(int barcode_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsFixedAssetSelectAllByBarcode_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@barcode_ID", SqlDbType.Int,4);
			scom.Parameters["@barcode_ID"].Value = barcode_ID;
				List<tbl_scsFixedAsset> tbl_scsFixedAssetList = new List<tbl_scsFixedAsset>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsFixedAsset tbl_scsFixedAsset = Maketbl_scsFixedAsset(dataReader);
					tbl_scsFixedAssetList.Add(tbl_scsFixedAsset);
				}
			}
			scon.Close();
			return tbl_scsFixedAssetList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsFixedAsset class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsFixedAsset Maketbl_scsFixedAsset(SqlDataReader dataReader) {
			tbl_scsFixedAsset tbl_scsFixedAsset = new tbl_scsFixedAsset();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsFixedAsset.Barcode_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsFixedAsset.FixedAsset_Code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsFixedAsset.AssetTransferNote_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsFixedAsset.Store_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsFixedAsset.Acquisition_date = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsFixedAsset.LifeTime = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsFixedAsset.DepreciationRate = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsFixedAsset.Cost = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsFixedAsset.TotalAccumulatedDepreciation = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsFixedAsset.WriteDownValue = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsFixedAsset.IsDepreciated = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsFixedAsset.IsDeleted = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsFixedAsset.CreateUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsFixedAsset.ModifiedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsFixedAsset.DeletedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsFixedAsset.CreateTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsFixedAsset.ModifiedTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsFixedAsset.DeletedTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsFixedAsset.DateCreate = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsFixedAsset.DateModified = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsFixedAsset.DateDeleted = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsFixedAsset.LastFinancialYear_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsFixedAsset.LastMonth_ID = dataReader.GetString(22);
			}

			return tbl_scsFixedAsset;
		}
		/// <summary>
		/// This makes tbl_scsFixedAsset datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsFixedAsset object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsFixedAsset  tbl_scsFixedAsset   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_barcode_ID = new DataColumn("barcode_ID" , typeof(int));
			DataColumn col_fixedAsset_Code = new DataColumn("fixedAsset_Code" , typeof(string));
			DataColumn col_assetTransferNote_ID = new DataColumn("assetTransferNote_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_acquisition_date = new DataColumn("acquisition_date" , typeof(DateTime));
			DataColumn col_lifeTime = new DataColumn("lifeTime" , typeof(decimal));
			DataColumn col_depreciationRate = new DataColumn("depreciationRate" , typeof(decimal));
			DataColumn col_cost = new DataColumn("cost" , typeof(decimal));
			DataColumn col_totalAccumulatedDepreciation = new DataColumn("totalAccumulatedDepreciation" , typeof(decimal));
			DataColumn col_writeDownValue = new DataColumn("writeDownValue" , typeof(decimal));
			DataColumn col_isDepreciated = new DataColumn("isDepreciated" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_lastFinancialYear_ID = new DataColumn("lastFinancialYear_ID" , typeof(string));
			DataColumn col_lastMonth_ID = new DataColumn("lastMonth_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_barcode_ID,col_fixedAsset_Code,col_assetTransferNote_ID,col_store_ID,col_acquisition_date,col_lifeTime,col_depreciationRate,col_cost,col_totalAccumulatedDepreciation,col_writeDownValue,col_isDepreciated,col_isDeleted,col_createUser_ID,col_modifiedUser_ID,col_deletedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_dateCreate,col_dateModified,col_dateDeleted,col_lastFinancialYear_ID,col_lastMonth_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsFixedAsset datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsFixedAsset object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsFixedAsset user) {
		DataRow drow = dt.NewRow();
		
			drow["barcode_ID"] = user.barcode_ID;
			drow["fixedAsset_Code"] = user.fixedAsset_Code;
			drow["assetTransferNote_ID"] = user.assetTransferNote_ID;
			drow["store_ID"] = user.store_ID;
			drow["acquisition_date"] = user.acquisition_date;
			drow["lifeTime"] = user.lifeTime;
			drow["depreciationRate"] = user.depreciationRate;
			drow["cost"] = user.cost;
			drow["totalAccumulatedDepreciation"] = user.totalAccumulatedDepreciation;
			drow["writeDownValue"] = user.writeDownValue;
			drow["isDepreciated"] = user.isDepreciated;
			drow["isDeleted"] = user.isDeleted;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateDeleted"] = user.dateDeleted;
			drow["lastFinancialYear_ID"] = user.lastFinancialYear_ID;
			drow["lastMonth_ID"] = user.lastMonth_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
