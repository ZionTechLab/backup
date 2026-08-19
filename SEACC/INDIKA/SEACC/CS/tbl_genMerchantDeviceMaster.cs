using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMerchantDeviceMaster {
		#region Fields
		private int merchant_DeviceID;
		private string device_Code;
		private string device_Name;
		private string companyID;
		private string companyBranch_ID;
		private bool isActive;
		private bool isDefaultMachine;
		private bool isCanceled;
		private int companyAccount_ID;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string canceledUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string canceledTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMerchantDeviceMaster class.
		/// </summary>
		public tbl_genMerchantDeviceMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMerchantDeviceMaster class.
		/// </summary>
		public tbl_genMerchantDeviceMaster(int merchant_DeviceID, string device_Code, string device_Name, string companyID, string companyBranch_ID, bool isActive, bool isDefaultMachine, bool isCanceled, int companyAccount_ID, string createUser_ID, string modifiedUser_ID, string canceledUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string canceledTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled) {
			this.merchant_DeviceID = merchant_DeviceID;
			this.device_Code = device_Code;
			this.device_Name = device_Name;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.isActive = isActive;
			this.isDefaultMachine = isDefaultMachine;
			this.isCanceled = isCanceled;
			this.companyAccount_ID = companyAccount_ID;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.canceledUser_ID = canceledUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.canceledTerminal_ID = canceledTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateCanceled = dateCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Merchant_DeviceID value.
		/// </summary>
		public int Merchant_DeviceID {
			get { return merchant_DeviceID; }
			set { merchant_DeviceID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_Code value.
		/// </summary>
		public string Device_Code {
			get { return device_Code; }
			set { device_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_Name value.
		/// </summary>
		public string Device_Name {
			get { return device_Name; }
			set { device_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDefaultMachine value.
		/// </summary>
		public bool IsDefaultMachine {
			get { return isDefaultMachine; }
			set { isDefaultMachine = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyAccount_ID value.
		/// </summary>
		public int CompanyAccount_ID {
			get { return companyAccount_ID; }
			set { companyAccount_ID = value; }
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
		/// Gets or sets the CanceledUser_ID value.
		/// </summary>
		public string CanceledUser_ID {
			get { return canceledUser_ID; }
			set { canceledUser_ID = value; }
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
		/// Gets or sets the CanceledTerminal_ID value.
		/// </summary>
		public string CanceledTerminal_ID {
			get { return canceledTerminal_ID; }
			set { canceledTerminal_ID = value; }
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
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMerchantDeviceMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters.Add("@device_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDefaultMachine", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID;
			scom.Parameters["@device_Code"].Value = device_Code;
			scom.Parameters["@device_Name"].Value = device_Name;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isDefaultMachine"].Value = isDefaultMachine;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@canceledTerminal_ID"].Value = canceledTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMerchantDeviceMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters.Add("@device_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_Name", SqlDbType.VarChar,200);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDefaultMachine", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID;
			scom.Parameters["@device_Code"].Value = device_Code;
			scom.Parameters["@device_Name"].Value = device_Name;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isDefaultMachine"].Value = isDefaultMachine;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@canceledTerminal_ID"].Value = canceledTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMerchantDeviceMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyAccount_ID(int companyAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterDeleteAllByCompanyAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceledUser_ID(string canceledUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterDeleteAllByCanceledUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMerchantDeviceMaster table.
		/// </summary>
		public static tbl_genMerchantDeviceMaster Select(int merchant_DeviceID_Incoming){

			tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMasterins = new tbl_genMerchantDeviceMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMerchantDeviceMasterins = Maketbl_genMerchantDeviceMaster(dataReader);
				} else {
					tbl_genMerchantDeviceMasterins = null;
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table.
		/// </summary>
		public static List<tbl_genMerchantDeviceMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMerchantDeviceMaster> tbl_genMerchantDeviceMasterList = new List<tbl_genMerchantDeviceMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = Maketbl_genMerchantDeviceMaster(dataReader);
					tbl_genMerchantDeviceMasterList.Add(tbl_genMerchantDeviceMaster);
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMerchantDeviceMaster> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_genMerchantDeviceMaster> tbl_genMerchantDeviceMasterList = new List<tbl_genMerchantDeviceMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = Maketbl_genMerchantDeviceMaster(dataReader);
					tbl_genMerchantDeviceMasterList.Add(tbl_genMerchantDeviceMaster);
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMerchantDeviceMaster> SelectAllByCompanyAccount_ID(int companyAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelectAllByCompanyAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
				List<tbl_genMerchantDeviceMaster> tbl_genMerchantDeviceMasterList = new List<tbl_genMerchantDeviceMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = Maketbl_genMerchantDeviceMaster(dataReader);
					tbl_genMerchantDeviceMasterList.Add(tbl_genMerchantDeviceMaster);
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMerchantDeviceMaster> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_genMerchantDeviceMaster> tbl_genMerchantDeviceMasterList = new List<tbl_genMerchantDeviceMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = Maketbl_genMerchantDeviceMaster(dataReader);
					tbl_genMerchantDeviceMasterList.Add(tbl_genMerchantDeviceMaster);
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMerchantDeviceMaster> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_genMerchantDeviceMaster> tbl_genMerchantDeviceMasterList = new List<tbl_genMerchantDeviceMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = Maketbl_genMerchantDeviceMaster(dataReader);
					tbl_genMerchantDeviceMasterList.Add(tbl_genMerchantDeviceMaster);
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMerchantDeviceMaster> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_genMerchantDeviceMaster> tbl_genMerchantDeviceMasterList = new List<tbl_genMerchantDeviceMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = Maketbl_genMerchantDeviceMaster(dataReader);
					tbl_genMerchantDeviceMasterList.Add(tbl_genMerchantDeviceMaster);
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMerchantDeviceMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMerchantDeviceMaster> SelectAllByCanceledUser_ID(string canceledUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMerchantDeviceMasterSelectAllByCanceledUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
				List<tbl_genMerchantDeviceMaster> tbl_genMerchantDeviceMasterList = new List<tbl_genMerchantDeviceMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = Maketbl_genMerchantDeviceMaster(dataReader);
					tbl_genMerchantDeviceMasterList.Add(tbl_genMerchantDeviceMaster);
				}
			}
			scon.Close();
			return tbl_genMerchantDeviceMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMerchantDeviceMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMerchantDeviceMaster Maketbl_genMerchantDeviceMaster(SqlDataReader dataReader) {
			tbl_genMerchantDeviceMaster tbl_genMerchantDeviceMaster = new tbl_genMerchantDeviceMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMerchantDeviceMaster.Merchant_DeviceID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMerchantDeviceMaster.Device_Code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMerchantDeviceMaster.Device_Name = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMerchantDeviceMaster.CompanyID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMerchantDeviceMaster.CompanyBranch_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMerchantDeviceMaster.IsActive = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMerchantDeviceMaster.IsDefaultMachine = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMerchantDeviceMaster.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMerchantDeviceMaster.CompanyAccount_ID = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMerchantDeviceMaster.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMerchantDeviceMaster.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMerchantDeviceMaster.CanceledUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMerchantDeviceMaster.CreateTerminal_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMerchantDeviceMaster.ModifiedTerminal_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMerchantDeviceMaster.CanceledTerminal_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genMerchantDeviceMaster.DateCreate = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genMerchantDeviceMaster.DateModified = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genMerchantDeviceMaster.DateCanceled = dataReader.GetDateTime(17);
			}

			return tbl_genMerchantDeviceMaster;
		}
		/// <summary>
		/// This makes tbl_genMerchantDeviceMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMerchantDeviceMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMerchantDeviceMaster  tbl_genMerchantDeviceMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_merchant_DeviceID = new DataColumn("merchant_DeviceID" , typeof(int));
			DataColumn col_device_Code = new DataColumn("device_Code" , typeof(string));
			DataColumn col_device_Name = new DataColumn("device_Name" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_isDefaultMachine = new DataColumn("isDefaultMachine" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_canceledUser_ID = new DataColumn("canceledUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_canceledTerminal_ID = new DataColumn("canceledTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_merchant_DeviceID,col_device_Code,col_device_Name,col_companyID,col_companyBranch_ID,col_isActive,col_isDefaultMachine,col_isCanceled,col_companyAccount_ID,col_createUser_ID,col_modifiedUser_ID,col_canceledUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_canceledTerminal_ID,col_dateCreate,col_dateModified,col_dateCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMerchantDeviceMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMerchantDeviceMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMerchantDeviceMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["merchant_DeviceID"] = user.merchant_DeviceID;
			drow["device_Code"] = user.device_Code;
			drow["device_Name"] = user.device_Name;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["isActive"] = user.isActive;
			drow["isDefaultMachine"] = user.isDefaultMachine;
			drow["isCanceled"] = user.isCanceled;
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["canceledUser_ID"] = user.canceledUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["canceledTerminal_ID"] = user.canceledTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateCanceled"] = user.dateCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
