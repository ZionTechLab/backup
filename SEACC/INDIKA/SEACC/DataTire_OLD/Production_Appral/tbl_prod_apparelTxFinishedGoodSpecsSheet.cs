using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_apparelTxFinishedGoodSpecsSheet {
		#region Fields
		private string item_ID_FG;
		private string item_ID_Template;
		private int industry_ID;
		private string customer_ID;
		private string instruction_Sales;
		private string instruction_Prod;
		private string instruction_Accounts;
		private string instruction_Stores;
		private string instruction_Supplier;
		private string uom_ID;
		private string uom_ID_Weight;
		private string tag3_ID;
		private string tag4_ID;
		private string colour_ID;
		private string meltingPoint;
		private string chemFormula;
		private string density;
		private bool isChecked;
		private bool isApproved;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string canceldUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateCanceled;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string checkedUserTerminal_ID;
		private string approvedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		private string companyID;
		private string companyBranchID;
		private string prefix;
		private string suffix;
		private string layer1;
		private string layer2;
		private string layer3;
		private string layer4;
		private string layer5;
		private string layer6;
		private string filling1;
		private string filling2;
		private string filling3;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_apparelTxFinishedGoodSpecsSheet class.
		/// </summary>
		public tbl_prod_apparelTxFinishedGoodSpecsSheet() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_apparelTxFinishedGoodSpecsSheet class.
		/// </summary>
		public tbl_prod_apparelTxFinishedGoodSpecsSheet(string item_ID_FG, string item_ID_Template, int industry_ID, string customer_ID, string instruction_Sales, string instruction_Prod, string instruction_Accounts, string instruction_Stores, string instruction_Supplier, string uom_ID, string uom_ID_Weight, string tag3_ID, string tag4_ID, string colour_ID, string meltingPoint, string chemFormula, string density, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID, string prefix, string suffix, string layer1, string layer2, string layer3, string layer4, string layer5, string layer6, string filling1, string filling2, string filling3) {
			this.item_ID_FG = item_ID_FG;
			this.item_ID_Template = item_ID_Template;
			this.industry_ID = industry_ID;
			this.customer_ID = customer_ID;
			this.instruction_Sales = instruction_Sales;
			this.instruction_Prod = instruction_Prod;
			this.instruction_Accounts = instruction_Accounts;
			this.instruction_Stores = instruction_Stores;
			this.instruction_Supplier = instruction_Supplier;
			this.uom_ID = uom_ID;
			this.uom_ID_Weight = uom_ID_Weight;
			this.tag3_ID = tag3_ID;
			this.tag4_ID = tag4_ID;
			this.colour_ID = colour_ID;
			this.meltingPoint = meltingPoint;
			this.chemFormula = chemFormula;
			this.density = density;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateCanceled = dateCanceled;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.checkedUserTerminal_ID = checkedUserTerminal_ID;
			this.approvedUserTerminal_ID = approvedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
			this.companyID = companyID;
			this.companyBranchID = companyBranchID;
			this.prefix = prefix;
			this.suffix = suffix;
			this.layer1 = layer1;
			this.layer2 = layer2;
			this.layer3 = layer3;
			this.layer4 = layer4;
			this.layer5 = layer5;
			this.layer6 = layer6;
			this.filling1 = filling1;
			this.filling2 = filling2;
			this.filling3 = filling3;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_Template value.
		/// </summary>
		public string Item_ID_Template {
			get { return item_ID_Template; }
			set { item_ID_Template = value; }
		}
		
		/// <summary>
		/// Gets or sets the Industry_ID value.
		/// </summary>
		public int Industry_ID {
			get { return industry_ID; }
			set { industry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Instruction_Sales value.
		/// </summary>
		public string Instruction_Sales {
			get { return instruction_Sales; }
			set { instruction_Sales = value; }
		}
		
		/// <summary>
		/// Gets or sets the Instruction_Prod value.
		/// </summary>
		public string Instruction_Prod {
			get { return instruction_Prod; }
			set { instruction_Prod = value; }
		}
		
		/// <summary>
		/// Gets or sets the Instruction_Accounts value.
		/// </summary>
		public string Instruction_Accounts {
			get { return instruction_Accounts; }
			set { instruction_Accounts = value; }
		}
		
		/// <summary>
		/// Gets or sets the Instruction_Stores value.
		/// </summary>
		public string Instruction_Stores {
			get { return instruction_Stores; }
			set { instruction_Stores = value; }
		}
		
		/// <summary>
		/// Gets or sets the Instruction_Supplier value.
		/// </summary>
		public string Instruction_Supplier {
			get { return instruction_Supplier; }
			set { instruction_Supplier = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_Weight value.
		/// </summary>
		public string Uom_ID_Weight {
			get { return uom_ID_Weight; }
			set { uom_ID_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tag3_ID value.
		/// </summary>
		public string Tag3_ID {
			get { return tag3_ID; }
			set { tag3_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tag4_ID value.
		/// </summary>
		public string Tag4_ID {
			get { return tag4_ID; }
			set { tag4_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Colour_ID value.
		/// </summary>
		public string Colour_ID {
			get { return colour_ID; }
			set { colour_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MeltingPoint value.
		/// </summary>
		public string MeltingPoint {
			get { return meltingPoint; }
			set { meltingPoint = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChemFormula value.
		/// </summary>
		public string ChemFormula {
			get { return chemFormula; }
			set { chemFormula = value; }
		}
		
		/// <summary>
		/// Gets or sets the Density value.
		/// </summary>
		public string Density {
			get { return density; }
			set { density = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked value.
		/// </summary>
		public bool IsChecked {
			get { return isChecked; }
			set { isChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
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
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceldUser_ID value.
		/// </summary>
		public string CanceldUser_ID {
			get { return canceldUser_ID; }
			set { canceldUser_ID = value; }
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
		/// Gets or sets the DateChecked value.
		/// </summary>
		public DateTime DateChecked {
			get { return dateChecked; }
			set { dateChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUserTerminal_ID value.
		/// </summary>
		public string CreateUserTerminal_ID {
			get { return createUserTerminal_ID; }
			set { createUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUserTerminal_ID value.
		/// </summary>
		public string ModifiedUserTerminal_ID {
			get { return modifiedUserTerminal_ID; }
			set { modifiedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUserTerminal_ID value.
		/// </summary>
		public string CheckedUserTerminal_ID {
			get { return checkedUserTerminal_ID; }
			set { checkedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUserTerminal_ID value.
		/// </summary>
		public string ApprovedUserTerminal_ID {
			get { return approvedUserTerminal_ID; }
			set { approvedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceledUserTerminal_ID value.
		/// </summary>
		public string CanceledUserTerminal_ID {
			get { return canceledUserTerminal_ID; }
			set { canceledUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranchID value.
		/// </summary>
		public string CompanyBranchID {
			get { return companyBranchID; }
			set { companyBranchID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Suffix value.
		/// </summary>
		public string Suffix {
			get { return suffix; }
			set { suffix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Layer1 value.
		/// </summary>
		public string Layer1 {
			get { return layer1; }
			set { layer1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Layer2 value.
		/// </summary>
		public string Layer2 {
			get { return layer2; }
			set { layer2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Layer3 value.
		/// </summary>
		public string Layer3 {
			get { return layer3; }
			set { layer3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Layer4 value.
		/// </summary>
		public string Layer4 {
			get { return layer4; }
			set { layer4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Layer5 value.
		/// </summary>
		public string Layer5 {
			get { return layer5; }
			set { layer5 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Layer6 value.
		/// </summary>
		public string Layer6 {
			get { return layer6; }
			set { layer6 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Filling1 value.
		/// </summary>
		public string Filling1 {
			get { return filling1; }
			set { filling1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Filling2 value.
		/// </summary>
		public string Filling2 {
			get { return filling2; }
			set { filling2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Filling3 value.
		/// </summary>
		public string Filling3 {
			get { return filling3; }
			set { filling3 = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_apparelTxFinishedGoodSpecsSheet table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_Template", SqlDbType.VarChar,20);
			scom.Parameters.Add("@industry_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@instruction_Sales", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Prod", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Accounts", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Stores", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Supplier", SqlDbType.VarChar,200);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@meltingPoint", SqlDbType.VarChar,100);
			scom.Parameters.Add("@chemFormula", SqlDbType.VarChar,100);
			scom.Parameters.Add("@density", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@suffix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@layer1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer3", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer4", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer5", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer6", SqlDbType.VarChar,20);
			scom.Parameters.Add("@filling1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@filling2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@filling3", SqlDbType.VarChar,20);
 
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@item_ID_Template"].Value = item_ID_Template;
			scom.Parameters["@industry_ID"].Value = industry_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@instruction_Sales"].Value = instruction_Sales;
			scom.Parameters["@instruction_Prod"].Value = instruction_Prod;
			scom.Parameters["@instruction_Accounts"].Value = instruction_Accounts;
			scom.Parameters["@instruction_Stores"].Value = instruction_Stores;
			scom.Parameters["@instruction_Supplier"].Value = instruction_Supplier;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uom_ID_Weight"].Value = uom_ID_Weight;
			scom.Parameters["@tag3_ID"].Value = tag3_ID;
			scom.Parameters["@tag4_ID"].Value = tag4_ID;
			scom.Parameters["@colour_ID"].Value = colour_ID;
			scom.Parameters["@meltingPoint"].Value = meltingPoint;
			scom.Parameters["@chemFormula"].Value = chemFormula;
			scom.Parameters["@density"].Value = density;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@suffix"].Value = suffix;
			scom.Parameters["@layer1"].Value = layer1;
			scom.Parameters["@layer2"].Value = layer2;
			scom.Parameters["@layer3"].Value = layer3;
			scom.Parameters["@layer4"].Value = layer4;
			scom.Parameters["@layer5"].Value = layer5;
			scom.Parameters["@layer6"].Value = layer6;
			scom.Parameters["@filling1"].Value = filling1;
			scom.Parameters["@filling2"].Value = filling2;
			scom.Parameters["@filling3"].Value = filling3;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_apparelTxFinishedGoodSpecsSheet table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_Template", SqlDbType.VarChar,20);
			scom.Parameters.Add("@industry_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@instruction_Sales", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Prod", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Accounts", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Stores", SqlDbType.VarChar,200);
			scom.Parameters.Add("@instruction_Supplier", SqlDbType.VarChar,200);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@meltingPoint", SqlDbType.VarChar,100);
			scom.Parameters.Add("@chemFormula", SqlDbType.VarChar,100);
			scom.Parameters.Add("@density", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@suffix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@layer1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer3", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer4", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer5", SqlDbType.VarChar,20);
			scom.Parameters.Add("@layer6", SqlDbType.VarChar,20);
			scom.Parameters.Add("@filling1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@filling2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@filling3", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@item_ID_Template"].Value = item_ID_Template;
			scom.Parameters["@industry_ID"].Value = industry_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@instruction_Sales"].Value = instruction_Sales;
			scom.Parameters["@instruction_Prod"].Value = instruction_Prod;
			scom.Parameters["@instruction_Accounts"].Value = instruction_Accounts;
			scom.Parameters["@instruction_Stores"].Value = instruction_Stores;
			scom.Parameters["@instruction_Supplier"].Value = instruction_Supplier;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uom_ID_Weight"].Value = uom_ID_Weight;
			scom.Parameters["@tag3_ID"].Value = tag3_ID;
			scom.Parameters["@tag4_ID"].Value = tag4_ID;
			scom.Parameters["@colour_ID"].Value = colour_ID;
			scom.Parameters["@meltingPoint"].Value = meltingPoint;
			scom.Parameters["@chemFormula"].Value = chemFormula;
			scom.Parameters["@density"].Value = density;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@suffix"].Value = suffix;
			scom.Parameters["@layer1"].Value = layer1;
			scom.Parameters["@layer2"].Value = layer2;
			scom.Parameters["@layer3"].Value = layer3;
			scom.Parameters["@layer4"].Value = layer4;
			scom.Parameters["@layer5"].Value = layer5;
			scom.Parameters["@layer6"].Value = layer6;
			scom.Parameters["@filling1"].Value = filling1;
			scom.Parameters["@filling2"].Value = filling2;
			scom.Parameters["@filling3"].Value = filling3;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByTag4_ID(string tag4_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByTag4_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag4_ID"].Value = tag4_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		//public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByItem_ID_FG", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	//scon.Open();
 
		//	scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
		//	scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
		//	scon.Open();
		//	scom.ExecuteNonQuery();
		//	scon.Close();
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByTag3_ID(string tag3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByTag3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag3_ID"].Value = tag3_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByColour_ID(string colour_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByColour_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_Template(string item_ID_Template) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetDeleteAllByItem_ID_Template", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_Template", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_Template"].Value = item_ID_Template;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_apparelTxFinishedGoodSpecsSheet table.
		/// </summary>
		public static tbl_prod_apparelTxFinishedGoodSpecsSheet Select(string item_ID_FG_Incoming){

			tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheetins = new tbl_prod_apparelTxFinishedGoodSpecsSheet();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheetins = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
				} else {
					tbl_prod_apparelTxFinishedGoodSpecsSheetins = null;
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByTag4_ID(string tag4_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByTag4_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tag4_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag4_ID"].Value = tag4_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		//public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByItem_ID_FG(string item_ID_FG) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByItem_ID_FG", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
		//	scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
		//		List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
		//	using (SqlDataReader dataReader = scom.ExecuteReader()){
		//		while (dataReader.Read()) {
		//			tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
		//			tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
		//		}
		//	}
		//	scon.Close();
		//	return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByTag3_ID(string tag3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByTag3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tag3_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tag3_ID"].Value = tag3_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByColour_ID(string colour_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByColour_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_apparelTxFinishedGoodSpecsSheet table by a foreign key.
		/// </summary>
		public static List<tbl_prod_apparelTxFinishedGoodSpecsSheet> SelectAllByItem_ID_Template(string item_ID_Template) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_apparelTxFinishedGoodSpecsSheetSelectAllByItem_ID_Template", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_Template", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_Template"].Value = item_ID_Template;
				List<tbl_prod_apparelTxFinishedGoodSpecsSheet> tbl_prod_apparelTxFinishedGoodSpecsSheetList = new List<tbl_prod_apparelTxFinishedGoodSpecsSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = Maketbl_prod_apparelTxFinishedGoodSpecsSheet(dataReader);
					tbl_prod_apparelTxFinishedGoodSpecsSheetList.Add(tbl_prod_apparelTxFinishedGoodSpecsSheet);
				}
			}
			scon.Close();
			return tbl_prod_apparelTxFinishedGoodSpecsSheetList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_apparelTxFinishedGoodSpecsSheet class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_apparelTxFinishedGoodSpecsSheet Maketbl_prod_apparelTxFinishedGoodSpecsSheet(SqlDataReader dataReader) {
			tbl_prod_apparelTxFinishedGoodSpecsSheet tbl_prod_apparelTxFinishedGoodSpecsSheet = new tbl_prod_apparelTxFinishedGoodSpecsSheet();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Item_ID_FG = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Item_ID_Template = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Industry_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Customer_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Instruction_Sales = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Instruction_Prod = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Instruction_Accounts = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Instruction_Stores = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Instruction_Supplier = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Uom_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Uom_ID_Weight = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Tag3_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Tag4_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Colour_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.MeltingPoint = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.ChemFormula = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Density = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.IsChecked = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.IsApproved = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.IsCanceled = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CreateUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.ModifiedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CheckedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.ApprovedUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CanceldUser_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.DateCreate = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.DateModified = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.DateChecked = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.DateApproved = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.DateCanceled = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CreateUserTerminal_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.ModifiedUserTerminal_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CheckedUserTerminal_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.ApprovedUserTerminal_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CanceledUserTerminal_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CompanyID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.CompanyBranchID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Prefix = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Suffix = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Layer1 = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Layer2 = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Layer3 = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Layer4 = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Layer5 = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Layer6 = dataReader.GetString(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Filling1 = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Filling2 = dataReader.GetString(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_prod_apparelTxFinishedGoodSpecsSheet.Filling3 = dataReader.GetString(47);
			}

			return tbl_prod_apparelTxFinishedGoodSpecsSheet;
		}
		/// <summary>
		/// This makes tbl_prod_apparelTxFinishedGoodSpecsSheet datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_apparelTxFinishedGoodSpecsSheet object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_apparelTxFinishedGoodSpecsSheet  tbl_prod_apparelTxFinishedGoodSpecsSheet   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_item_ID_Template = new DataColumn("item_ID_Template" , typeof(string));
			DataColumn col_industry_ID = new DataColumn("industry_ID" , typeof(int));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_instruction_Sales = new DataColumn("instruction_Sales" , typeof(string));
			DataColumn col_instruction_Prod = new DataColumn("instruction_Prod" , typeof(string));
			DataColumn col_instruction_Accounts = new DataColumn("instruction_Accounts" , typeof(string));
			DataColumn col_instruction_Stores = new DataColumn("instruction_Stores" , typeof(string));
			DataColumn col_instruction_Supplier = new DataColumn("instruction_Supplier" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_uom_ID_Weight = new DataColumn("uom_ID_Weight" , typeof(string));
			DataColumn col_tag3_ID = new DataColumn("tag3_ID" , typeof(string));
			DataColumn col_tag4_ID = new DataColumn("tag4_ID" , typeof(string));
			DataColumn col_colour_ID = new DataColumn("colour_ID" , typeof(string));
			DataColumn col_meltingPoint = new DataColumn("meltingPoint" , typeof(string));
			DataColumn col_chemFormula = new DataColumn("chemFormula" , typeof(string));
			DataColumn col_density = new DataColumn("density" , typeof(string));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_checkedUserTerminal_ID = new DataColumn("checkedUserTerminal_ID" , typeof(string));
			DataColumn col_approvedUserTerminal_ID = new DataColumn("approvedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranchID = new DataColumn("companyBranchID" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_suffix = new DataColumn("suffix" , typeof(string));
			DataColumn col_layer1 = new DataColumn("layer1" , typeof(string));
			DataColumn col_layer2 = new DataColumn("layer2" , typeof(string));
			DataColumn col_layer3 = new DataColumn("layer3" , typeof(string));
			DataColumn col_layer4 = new DataColumn("layer4" , typeof(string));
			DataColumn col_layer5 = new DataColumn("layer5" , typeof(string));
			DataColumn col_layer6 = new DataColumn("layer6" , typeof(string));
			DataColumn col_filling1 = new DataColumn("filling1" , typeof(string));
			DataColumn col_filling2 = new DataColumn("filling2" , typeof(string));
			DataColumn col_filling3 = new DataColumn("filling3" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID_FG,col_item_ID_Template,col_industry_ID,col_customer_ID,col_instruction_Sales,col_instruction_Prod,col_instruction_Accounts,col_instruction_Stores,col_instruction_Supplier,col_uom_ID,col_uom_ID_Weight,col_tag3_ID,col_tag4_ID,col_colour_ID,col_meltingPoint,col_chemFormula,col_density,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,col_prefix,col_suffix,col_layer1,col_layer2,col_layer3,col_layer4,col_layer5,col_layer6,col_filling1,col_filling2,col_filling3,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_apparelTxFinishedGoodSpecsSheet datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_apparelTxFinishedGoodSpecsSheet object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_apparelTxFinishedGoodSpecsSheet user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["item_ID_Template"] = user.item_ID_Template;
			drow["industry_ID"] = user.industry_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["instruction_Sales"] = user.instruction_Sales;
			drow["instruction_Prod"] = user.instruction_Prod;
			drow["instruction_Accounts"] = user.instruction_Accounts;
			drow["instruction_Stores"] = user.instruction_Stores;
			drow["instruction_Supplier"] = user.instruction_Supplier;
			drow["uom_ID"] = user.uom_ID;
			drow["uom_ID_Weight"] = user.uom_ID_Weight;
			drow["tag3_ID"] = user.tag3_ID;
			drow["tag4_ID"] = user.tag4_ID;
			drow["colour_ID"] = user.colour_ID;
			drow["meltingPoint"] = user.meltingPoint;
			drow["chemFormula"] = user.chemFormula;
			drow["density"] = user.density;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateCanceled"] = user.dateCanceled;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["checkedUserTerminal_ID"] = user.checkedUserTerminal_ID;
			drow["approvedUserTerminal_ID"] = user.approvedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranchID"] = user.companyBranchID;
			drow["prefix"] = user.prefix;
			drow["suffix"] = user.suffix;
			drow["layer1"] = user.layer1;
			drow["layer2"] = user.layer2;
			drow["layer3"] = user.layer3;
			drow["layer4"] = user.layer4;
			drow["layer5"] = user.layer5;
			drow["layer6"] = user.layer6;
			drow["filling1"] = user.filling1;
			drow["filling2"] = user.filling2;
			drow["filling3"] = user.filling3;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
