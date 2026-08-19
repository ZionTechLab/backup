using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMachineMaster {
		#region Fields
		private int line_No;
		private string machine_ID;
		private string machineName;
		private string description;
		private string machineClass_ID;
		private string machineType_ID;
		private string machineCategory_ID;
		private string machineCategorySub_ID;
		private string brand_ID;
		private string model_ID;
		private string section_ID;
		private string serialNumber;
		private string partNumber;
		private decimal machineCostPerHour;
		private decimal electricityCostPerHour;
		private decimal depreciationCostPerHour;
		private decimal labourCostPerHour;
		private decimal electricityBudgetedCost;
		private decimal depreciationBudgetedCost;
		private decimal labourBudgetedCost;
		private byte[] image;
		private bool isSuspended;
		private bool isOutOfDate;
		private bool isSoldOut;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMachineMaster class.
		/// </summary>
		public tbl_genMachineMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMachineMaster class.
		/// </summary>
		public tbl_genMachineMaster(int line_No, string machine_ID, string machineName, string description, string machineClass_ID, string machineType_ID, string machineCategory_ID, string machineCategorySub_ID, string brand_ID, string model_ID, string section_ID, string serialNumber, string partNumber, decimal machineCostPerHour, decimal electricityCostPerHour, decimal depreciationCostPerHour, decimal labourCostPerHour, decimal electricityBudgetedCost, decimal depreciationBudgetedCost, decimal labourBudgetedCost, byte[] image, bool isSuspended, bool isOutOfDate, bool isSoldOut, bool isDeleted) {
			this.line_No = line_No;
			this.machine_ID = machine_ID;
			this.machineName = machineName;
			this.description = description;
			this.machineClass_ID = machineClass_ID;
			this.machineType_ID = machineType_ID;
			this.machineCategory_ID = machineCategory_ID;
			this.machineCategorySub_ID = machineCategorySub_ID;
			this.brand_ID = brand_ID;
			this.model_ID = model_ID;
			this.section_ID = section_ID;
			this.serialNumber = serialNumber;
			this.partNumber = partNumber;
			this.machineCostPerHour = machineCostPerHour;
			this.electricityCostPerHour = electricityCostPerHour;
			this.depreciationCostPerHour = depreciationCostPerHour;
			this.labourCostPerHour = labourCostPerHour;
			this.electricityBudgetedCost = electricityBudgetedCost;
			this.depreciationBudgetedCost = depreciationBudgetedCost;
			this.labourBudgetedCost = labourBudgetedCost;
			this.image = image;
			this.isSuspended = isSuspended;
			this.isOutOfDate = isOutOfDate;
			this.isSoldOut = isSoldOut;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineName value.
		/// </summary>
		public string MachineName {
			get { return machineName; }
			set { machineName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineClass_ID value.
		/// </summary>
		public string MachineClass_ID {
			get { return machineClass_ID; }
			set { machineClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineType_ID value.
		/// </summary>
		public string MachineType_ID {
			get { return machineType_ID; }
			set { machineType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineCategory_ID value.
		/// </summary>
		public string MachineCategory_ID {
			get { return machineCategory_ID; }
			set { machineCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineCategorySub_ID value.
		/// </summary>
		public string MachineCategorySub_ID {
			get { return machineCategorySub_ID; }
			set { machineCategorySub_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Brand_ID value.
		/// </summary>
		public string Brand_ID {
			get { return brand_ID; }
			set { brand_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Model_ID value.
		/// </summary>
		public string Model_ID {
			get { return model_ID; }
			set { model_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNumber value.
		/// </summary>
		public string SerialNumber {
			get { return serialNumber; }
			set { serialNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the PartNumber value.
		/// </summary>
		public string PartNumber {
			get { return partNumber; }
			set { partNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineCostPerHour value.
		/// </summary>
		public decimal MachineCostPerHour {
			get { return machineCostPerHour; }
			set { machineCostPerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the ElectricityCostPerHour value.
		/// </summary>
		public decimal ElectricityCostPerHour {
			get { return electricityCostPerHour; }
			set { electricityCostPerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepreciationCostPerHour value.
		/// </summary>
		public decimal DepreciationCostPerHour {
			get { return depreciationCostPerHour; }
			set { depreciationCostPerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the LabourCostPerHour value.
		/// </summary>
		public decimal LabourCostPerHour {
			get { return labourCostPerHour; }
			set { labourCostPerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the ElectricityBudgetedCost value.
		/// </summary>
		public decimal ElectricityBudgetedCost {
			get { return electricityBudgetedCost; }
			set { electricityBudgetedCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepreciationBudgetedCost value.
		/// </summary>
		public decimal DepreciationBudgetedCost {
			get { return depreciationBudgetedCost; }
			set { depreciationBudgetedCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the LabourBudgetedCost value.
		/// </summary>
		public decimal LabourBudgetedCost {
			get { return labourBudgetedCost; }
			set { labourBudgetedCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSuspended value.
		/// </summary>
		public bool IsSuspended {
			get { return isSuspended; }
			set { isSuspended = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOutOfDate value.
		/// </summary>
		public bool IsOutOfDate {
			get { return isOutOfDate; }
			set { isOutOfDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSoldOut value.
		/// </summary>
		public bool IsSoldOut {
			get { return isSoldOut; }
			set { isSoldOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMachineMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@serialNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@partNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machineCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@electricityCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@electricityBudgetedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationBudgetedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourBudgetedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@isSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOutOfDate", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSoldOut", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineName"].Value = machineName;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@model_ID"].Value = model_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@serialNumber"].Value = serialNumber;
			scom.Parameters["@partNumber"].Value = partNumber;
			scom.Parameters["@machineCostPerHour"].Value = machineCostPerHour;
			scom.Parameters["@electricityCostPerHour"].Value = electricityCostPerHour;
			scom.Parameters["@depreciationCostPerHour"].Value = depreciationCostPerHour;
			scom.Parameters["@labourCostPerHour"].Value = labourCostPerHour;
			scom.Parameters["@electricityBudgetedCost"].Value = electricityBudgetedCost;
			scom.Parameters["@depreciationBudgetedCost"].Value = depreciationBudgetedCost;
			scom.Parameters["@labourBudgetedCost"].Value = labourBudgetedCost;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@isSuspended"].Value = isSuspended;
			scom.Parameters["@isOutOfDate"].Value = isOutOfDate;
			scom.Parameters["@isSoldOut"].Value = isSoldOut;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMachineMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@serialNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@partNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machineCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@electricityCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@electricityBudgetedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depreciationBudgetedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@labourBudgetedCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@isSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOutOfDate", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSoldOut", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineName"].Value = machineName;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@model_ID"].Value = model_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@serialNumber"].Value = serialNumber;
			scom.Parameters["@partNumber"].Value = partNumber;
			scom.Parameters["@machineCostPerHour"].Value = machineCostPerHour;
			scom.Parameters["@electricityCostPerHour"].Value = electricityCostPerHour;
			scom.Parameters["@depreciationCostPerHour"].Value = depreciationCostPerHour;
			scom.Parameters["@labourCostPerHour"].Value = labourCostPerHour;
			scom.Parameters["@electricityBudgetedCost"].Value = electricityBudgetedCost;
			scom.Parameters["@depreciationBudgetedCost"].Value = depreciationBudgetedCost;
			scom.Parameters["@labourBudgetedCost"].Value = labourBudgetedCost;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@isSuspended"].Value = isSuspended;
			scom.Parameters["@isOutOfDate"].Value = isOutOfDate;
			scom.Parameters["@isSoldOut"].Value = isSoldOut;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMachineMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachineMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterDeleteAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachineMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByModel_ID(string model_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterDeleteAllByModel_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters["@model_ID"].Value = model_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachineMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineCategorySub_ID(string machineCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterDeleteAllByMachineCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMachineMaster table.
		/// </summary>
		public static tbl_genMachineMaster Select(string machine_ID_Incoming){

			tbl_genMachineMaster tbl_genMachineMasterins = new tbl_genMachineMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMachineMasterins = Maketbl_genMachineMaster(dataReader);
				} else {
					tbl_genMachineMasterins = null;
				}
			}
			scon.Close();
			return tbl_genMachineMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachineMaster table.
		/// </summary>
		public static List<tbl_genMachineMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMachineMaster> tbl_genMachineMasterList = new List<tbl_genMachineMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachineMaster tbl_genMachineMaster = Maketbl_genMachineMaster(dataReader);
					tbl_genMachineMasterList.Add(tbl_genMachineMaster);
				}
			}
			scon.Close();
			return tbl_genMachineMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachineMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMachineMaster> SelectAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterSelectAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
				List<tbl_genMachineMaster> tbl_genMachineMasterList = new List<tbl_genMachineMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachineMaster tbl_genMachineMaster = Maketbl_genMachineMaster(dataReader);
					tbl_genMachineMasterList.Add(tbl_genMachineMaster);
				}
			}
			scon.Close();
			return tbl_genMachineMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachineMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMachineMaster> SelectAllByModel_ID(string model_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterSelectAllByModel_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters["@model_ID"].Value = model_ID;
				List<tbl_genMachineMaster> tbl_genMachineMasterList = new List<tbl_genMachineMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachineMaster tbl_genMachineMaster = Maketbl_genMachineMaster(dataReader);
					tbl_genMachineMasterList.Add(tbl_genMachineMaster);
				}
			}
			scon.Close();
			return tbl_genMachineMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachineMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genMachineMaster> SelectAllByMachineCategorySub_ID(string machineCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachineMasterSelectAllByMachineCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
				List<tbl_genMachineMaster> tbl_genMachineMasterList = new List<tbl_genMachineMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachineMaster tbl_genMachineMaster = Maketbl_genMachineMaster(dataReader);
					tbl_genMachineMasterList.Add(tbl_genMachineMaster);
				}
			}
			scon.Close();
			return tbl_genMachineMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMachineMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMachineMaster Maketbl_genMachineMaster(SqlDataReader dataReader) {
			tbl_genMachineMaster tbl_genMachineMaster = new tbl_genMachineMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMachineMaster.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMachineMaster.Machine_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMachineMaster.MachineName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMachineMaster.Description = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMachineMaster.MachineClass_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMachineMaster.MachineType_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMachineMaster.MachineCategory_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMachineMaster.MachineCategorySub_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMachineMaster.Brand_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMachineMaster.Model_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMachineMaster.Section_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMachineMaster.SerialNumber = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMachineMaster.PartNumber = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMachineMaster.MachineCostPerHour = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMachineMaster.ElectricityCostPerHour = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genMachineMaster.DepreciationCostPerHour = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genMachineMaster.LabourCostPerHour = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genMachineMaster.ElectricityBudgetedCost = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genMachineMaster.DepreciationBudgetedCost = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genMachineMaster.LabourBudgetedCost = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genMachineMaster.Image = (byte[]) dataReader[20];
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genMachineMaster.IsSuspended = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genMachineMaster.IsOutOfDate = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genMachineMaster.IsSoldOut = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genMachineMaster.IsDeleted = dataReader.GetBoolean(24);
			}

			return tbl_genMachineMaster;
		}
		/// <summary>
		/// This makes tbl_genMachineMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMachineMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMachineMaster  tbl_genMachineMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_machineName = new DataColumn("machineName" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_machineClass_ID = new DataColumn("machineClass_ID" , typeof(string));
			DataColumn col_machineType_ID = new DataColumn("machineType_ID" , typeof(string));
			DataColumn col_machineCategory_ID = new DataColumn("machineCategory_ID" , typeof(string));
			DataColumn col_machineCategorySub_ID = new DataColumn("machineCategorySub_ID" , typeof(string));
			DataColumn col_brand_ID = new DataColumn("brand_ID" , typeof(string));
			DataColumn col_model_ID = new DataColumn("model_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_serialNumber = new DataColumn("serialNumber" , typeof(string));
			DataColumn col_partNumber = new DataColumn("partNumber" , typeof(string));
			DataColumn col_machineCostPerHour = new DataColumn("machineCostPerHour" , typeof(decimal));
			DataColumn col_electricityCostPerHour = new DataColumn("electricityCostPerHour" , typeof(decimal));
			DataColumn col_depreciationCostPerHour = new DataColumn("depreciationCostPerHour" , typeof(decimal));
			DataColumn col_labourCostPerHour = new DataColumn("labourCostPerHour" , typeof(decimal));
			DataColumn col_electricityBudgetedCost = new DataColumn("electricityBudgetedCost" , typeof(decimal));
			DataColumn col_depreciationBudgetedCost = new DataColumn("depreciationBudgetedCost" , typeof(decimal));
			DataColumn col_labourBudgetedCost = new DataColumn("labourBudgetedCost" , typeof(decimal));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
			DataColumn col_isSuspended = new DataColumn("isSuspended" , typeof(bool));
			DataColumn col_isOutOfDate = new DataColumn("isOutOfDate" , typeof(bool));
			DataColumn col_isSoldOut = new DataColumn("isSoldOut" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_machine_ID,col_machineName,col_description,col_machineClass_ID,col_machineType_ID,col_machineCategory_ID,col_machineCategorySub_ID,col_brand_ID,col_model_ID,col_section_ID,col_serialNumber,col_partNumber,col_machineCostPerHour,col_electricityCostPerHour,col_depreciationCostPerHour,col_labourCostPerHour,col_electricityBudgetedCost,col_depreciationBudgetedCost,col_labourBudgetedCost,col_image,col_isSuspended,col_isOutOfDate,col_isSoldOut,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMachineMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMachineMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMachineMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["machine_ID"] = user.machine_ID;
			drow["machineName"] = user.machineName;
			drow["description"] = user.description;
			drow["machineClass_ID"] = user.machineClass_ID;
			drow["machineType_ID"] = user.machineType_ID;
			drow["machineCategory_ID"] = user.machineCategory_ID;
			drow["machineCategorySub_ID"] = user.machineCategorySub_ID;
			drow["brand_ID"] = user.brand_ID;
			drow["model_ID"] = user.model_ID;
			drow["section_ID"] = user.section_ID;
			drow["serialNumber"] = user.serialNumber;
			drow["partNumber"] = user.partNumber;
			drow["machineCostPerHour"] = user.machineCostPerHour;
			drow["electricityCostPerHour"] = user.electricityCostPerHour;
			drow["depreciationCostPerHour"] = user.depreciationCostPerHour;
			drow["labourCostPerHour"] = user.labourCostPerHour;
			drow["electricityBudgetedCost"] = user.electricityBudgetedCost;
			drow["depreciationBudgetedCost"] = user.depreciationBudgetedCost;
			drow["labourBudgetedCost"] = user.labourBudgetedCost;
			drow["image"] = user.image;
			drow["isSuspended"] = user.isSuspended;
			drow["isOutOfDate"] = user.isOutOfDate;
			drow["isSoldOut"] = user.isSoldOut;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
