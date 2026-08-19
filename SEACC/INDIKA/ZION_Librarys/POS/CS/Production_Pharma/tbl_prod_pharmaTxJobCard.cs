using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxJobCard {
		#region Fields
		private string prodJob_ID;
		private DateTime prodJobDate;
		private int prodJobStatus;
		private string salesman_ID;
		private string customer_ID;
		private string customerInquiry_ID;
		private string customerOrder_ID;
		private string remarks;
		private string remarks2;
		private string jobType_ID;
		private string prodRange_ID;
		private string prodCategory_ID;
		private string prodSize_ID;
		private string colour_ID;
		private string item_ID_Previous;
		private string item_ID_FG;
		private string uom_ID;
		private decimal item_Length;
		private string item_Length_UoM_ID;
		private decimal item_Width;
		private string item_Width_UoM_ID;
		private decimal item_Height;
		private string item_Height_UoM_ID;
		private decimal item_Diameter;
		private string item_Diameter_UoM_ID;
		private decimal item_Radius;
		private string item_Radius_UoM_ID;
		private decimal item_Thickness;
		private string item_Thickness_UoM_ID;
		private decimal item_Weight;
		private string item_Weight_UoM_ID;
		private decimal orderedQty;
		private decimal fGoodQty;
		private decimal wastePercent;
		private decimal wasteQty;
		private DateTime exfactoryDate;
		private DateTime prodStartDate;
		private decimal estProdHrs;
		private bool isChecked1;
		private bool isChecked2;
		private bool isChecked3;
		private bool isApproved1;
		private bool isApproved2;
		private bool isApproved3;
		private bool isCanceled;
		private bool isLocked;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checked1User_ID;
		private string checked2User_ID;
		private string checked3User_ID;
		private string approved1User_ID;
		private string approved2User_ID;
		private string approved3User_ID;
		private string canceldUser_ID;
		private string lockedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked1;
		private DateTime dateChecked2;
		private DateTime dateChecked3;
		private DateTime dateApproved1;
		private DateTime dateApproved2;
		private DateTime dateApproved3;
		private DateTime dateCanceled;
		private DateTime dateLocked;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string checked1UserTerminal_ID;
		private string checked2UserTerminal_ID;
		private string checked3UserTerminal_ID;
		private string approved1UserTerminal_ID;
		private string approved2UserTerminal_ID;
		private string approved3UserTerminal_ID;
		private string canceledUserTerminal_ID;
		private string lockedUserTerminal_ID;
		private string companyID;
		private string companyBranchID;
		private decimal customerOrder_Qty;
		private bool isTemporaryBoM;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard(string prodJob_ID, DateTime prodJobDate, int prodJobStatus, string salesman_ID, string customer_ID, string customerInquiry_ID, string customerOrder_ID, string remarks, string remarks2, string jobType_ID, string prodRange_ID, string prodCategory_ID, string prodSize_ID, string colour_ID, string item_ID_Previous, string item_ID_FG, string uom_ID, decimal item_Length, string item_Length_UoM_ID, decimal item_Width, string item_Width_UoM_ID, decimal item_Height, string item_Height_UoM_ID, decimal item_Diameter, string item_Diameter_UoM_ID, decimal item_Radius, string item_Radius_UoM_ID, decimal item_Thickness, string item_Thickness_UoM_ID, decimal item_Weight, string item_Weight_UoM_ID, decimal orderedQty, decimal fGoodQty, decimal wastePercent, decimal wasteQty, DateTime exfactoryDate, DateTime prodStartDate, decimal estProdHrs, bool isChecked1, bool isChecked2, bool isChecked3, bool isApproved1, bool isApproved2, bool isApproved3, bool isCanceled, bool isLocked, string createUser_ID, string modifiedUser_ID, string checked1User_ID, string checked2User_ID, string checked3User_ID, string approved1User_ID, string approved2User_ID, string approved3User_ID, string canceldUser_ID, string lockedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked1, DateTime dateChecked2, DateTime dateChecked3, DateTime dateApproved1, DateTime dateApproved2, DateTime dateApproved3, DateTime dateCanceled, DateTime dateLocked, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checked1UserTerminal_ID, string checked2UserTerminal_ID, string checked3UserTerminal_ID, string approved1UserTerminal_ID, string approved2UserTerminal_ID, string approved3UserTerminal_ID, string canceledUserTerminal_ID, string lockedUserTerminal_ID, string companyID, string companyBranchID, decimal customerOrder_Qty, bool isTemporaryBoM) {
			this.prodJob_ID = prodJob_ID;
			this.prodJobDate = prodJobDate;
			this.prodJobStatus = prodJobStatus;
			this.salesman_ID = salesman_ID;
			this.customer_ID = customer_ID;
			this.customerInquiry_ID = customerInquiry_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.remarks = remarks;
			this.remarks2 = remarks2;
			this.jobType_ID = jobType_ID;
			this.prodRange_ID = prodRange_ID;
			this.prodCategory_ID = prodCategory_ID;
			this.prodSize_ID = prodSize_ID;
			this.colour_ID = colour_ID;
			this.item_ID_Previous = item_ID_Previous;
			this.item_ID_FG = item_ID_FG;
			this.uom_ID = uom_ID;
			this.item_Length = item_Length;
			this.item_Length_UoM_ID = item_Length_UoM_ID;
			this.item_Width = item_Width;
			this.item_Width_UoM_ID = item_Width_UoM_ID;
			this.item_Height = item_Height;
			this.item_Height_UoM_ID = item_Height_UoM_ID;
			this.item_Diameter = item_Diameter;
			this.item_Diameter_UoM_ID = item_Diameter_UoM_ID;
			this.item_Radius = item_Radius;
			this.item_Radius_UoM_ID = item_Radius_UoM_ID;
			this.item_Thickness = item_Thickness;
			this.item_Thickness_UoM_ID = item_Thickness_UoM_ID;
			this.item_Weight = item_Weight;
			this.item_Weight_UoM_ID = item_Weight_UoM_ID;
			this.orderedQty = orderedQty;
			this.fGoodQty = fGoodQty;
			this.wastePercent = wastePercent;
			this.wasteQty = wasteQty;
			this.exfactoryDate = exfactoryDate;
			this.prodStartDate = prodStartDate;
			this.estProdHrs = estProdHrs;
			this.isChecked1 = isChecked1;
			this.isChecked2 = isChecked2;
			this.isChecked3 = isChecked3;
			this.isApproved1 = isApproved1;
			this.isApproved2 = isApproved2;
			this.isApproved3 = isApproved3;
			this.isCanceled = isCanceled;
			this.isLocked = isLocked;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checked1User_ID = checked1User_ID;
			this.checked2User_ID = checked2User_ID;
			this.checked3User_ID = checked3User_ID;
			this.approved1User_ID = approved1User_ID;
			this.approved2User_ID = approved2User_ID;
			this.approved3User_ID = approved3User_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.lockedUser_ID = lockedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked1 = dateChecked1;
			this.dateChecked2 = dateChecked2;
			this.dateChecked3 = dateChecked3;
			this.dateApproved1 = dateApproved1;
			this.dateApproved2 = dateApproved2;
			this.dateApproved3 = dateApproved3;
			this.dateCanceled = dateCanceled;
			this.dateLocked = dateLocked;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.checked1UserTerminal_ID = checked1UserTerminal_ID;
			this.checked2UserTerminal_ID = checked2UserTerminal_ID;
			this.checked3UserTerminal_ID = checked3UserTerminal_ID;
			this.approved1UserTerminal_ID = approved1UserTerminal_ID;
			this.approved2UserTerminal_ID = approved2UserTerminal_ID;
			this.approved3UserTerminal_ID = approved3UserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
			this.lockedUserTerminal_ID = lockedUserTerminal_ID;
			this.companyID = companyID;
			this.companyBranchID = companyBranchID;
			this.customerOrder_Qty = customerOrder_Qty;
			this.isTemporaryBoM = isTemporaryBoM;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJobDate value.
		/// </summary>
		public DateTime ProdJobDate {
			get { return prodJobDate; }
			set { prodJobDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJobStatus value.
		/// </summary>
		public int ProdJobStatus {
			get { return prodJobStatus; }
			set { prodJobStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the Salesman_ID value.
		/// </summary>
		public string Salesman_ID {
			get { return salesman_ID; }
			set { salesman_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerInquiry_ID value.
		/// </summary>
		public string CustomerInquiry_ID {
			get { return customerInquiry_ID; }
			set { customerInquiry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks2 value.
		/// </summary>
		public string Remarks2 {
			get { return remarks2; }
			set { remarks2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobType_ID value.
		/// </summary>
		public string JobType_ID {
			get { return jobType_ID; }
			set { jobType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdRange_ID value.
		/// </summary>
		public string ProdRange_ID {
			get { return prodRange_ID; }
			set { prodRange_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdCategory_ID value.
		/// </summary>
		public string ProdCategory_ID {
			get { return prodCategory_ID; }
			set { prodCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdSize_ID value.
		/// </summary>
		public string ProdSize_ID {
			get { return prodSize_ID; }
			set { prodSize_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Colour_ID value.
		/// </summary>
		public string Colour_ID {
			get { return colour_ID; }
			set { colour_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_Previous value.
		/// </summary>
		public string Item_ID_Previous {
			get { return item_ID_Previous; }
			set { item_ID_Previous = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Length value.
		/// </summary>
		public decimal Item_Length {
			get { return item_Length; }
			set { item_Length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Length_UoM_ID value.
		/// </summary>
		public string Item_Length_UoM_ID {
			get { return item_Length_UoM_ID; }
			set { item_Length_UoM_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Width value.
		/// </summary>
		public decimal Item_Width {
			get { return item_Width; }
			set { item_Width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Width_UoM_ID value.
		/// </summary>
		public string Item_Width_UoM_ID {
			get { return item_Width_UoM_ID; }
			set { item_Width_UoM_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Height value.
		/// </summary>
		public decimal Item_Height {
			get { return item_Height; }
			set { item_Height = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Height_UoM_ID value.
		/// </summary>
		public string Item_Height_UoM_ID {
			get { return item_Height_UoM_ID; }
			set { item_Height_UoM_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Diameter value.
		/// </summary>
		public decimal Item_Diameter {
			get { return item_Diameter; }
			set { item_Diameter = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Diameter_UoM_ID value.
		/// </summary>
		public string Item_Diameter_UoM_ID {
			get { return item_Diameter_UoM_ID; }
			set { item_Diameter_UoM_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Radius value.
		/// </summary>
		public decimal Item_Radius {
			get { return item_Radius; }
			set { item_Radius = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Radius_UoM_ID value.
		/// </summary>
		public string Item_Radius_UoM_ID {
			get { return item_Radius_UoM_ID; }
			set { item_Radius_UoM_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Thickness value.
		/// </summary>
		public decimal Item_Thickness {
			get { return item_Thickness; }
			set { item_Thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Thickness_UoM_ID value.
		/// </summary>
		public string Item_Thickness_UoM_ID {
			get { return item_Thickness_UoM_ID; }
			set { item_Thickness_UoM_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Weight value.
		/// </summary>
		public decimal Item_Weight {
			get { return item_Weight; }
			set { item_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Weight_UoM_ID value.
		/// </summary>
		public string Item_Weight_UoM_ID {
			get { return item_Weight_UoM_ID; }
			set { item_Weight_UoM_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderedQty value.
		/// </summary>
		public decimal OrderedQty {
			get { return orderedQty; }
			set { orderedQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the FGoodQty value.
		/// </summary>
		public decimal FGoodQty {
			get { return fGoodQty; }
			set { fGoodQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the WastePercent value.
		/// </summary>
		public decimal WastePercent {
			get { return wastePercent; }
			set { wastePercent = value; }
		}
		
		/// <summary>
		/// Gets or sets the WasteQty value.
		/// </summary>
		public decimal WasteQty {
			get { return wasteQty; }
			set { wasteQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExfactoryDate value.
		/// </summary>
		public DateTime ExfactoryDate {
			get { return exfactoryDate; }
			set { exfactoryDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdStartDate value.
		/// </summary>
		public DateTime ProdStartDate {
			get { return prodStartDate; }
			set { prodStartDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the EstProdHrs value.
		/// </summary>
		public decimal EstProdHrs {
			get { return estProdHrs; }
			set { estProdHrs = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked1 value.
		/// </summary>
		public bool IsChecked1 {
			get { return isChecked1; }
			set { isChecked1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked2 value.
		/// </summary>
		public bool IsChecked2 {
			get { return isChecked2; }
			set { isChecked2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked3 value.
		/// </summary>
		public bool IsChecked3 {
			get { return isChecked3; }
			set { isChecked3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved1 value.
		/// </summary>
		public bool IsApproved1 {
			get { return isApproved1; }
			set { isApproved1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved2 value.
		/// </summary>
		public bool IsApproved2 {
			get { return isApproved2; }
			set { isApproved2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved3 value.
		/// </summary>
		public bool IsApproved3 {
			get { return isApproved3; }
			set { isApproved3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
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
		/// Gets or sets the Checked1User_ID value.
		/// </summary>
		public string Checked1User_ID {
			get { return checked1User_ID; }
			set { checked1User_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Checked2User_ID value.
		/// </summary>
		public string Checked2User_ID {
			get { return checked2User_ID; }
			set { checked2User_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Checked3User_ID value.
		/// </summary>
		public string Checked3User_ID {
			get { return checked3User_ID; }
			set { checked3User_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Approved1User_ID value.
		/// </summary>
		public string Approved1User_ID {
			get { return approved1User_ID; }
			set { approved1User_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Approved2User_ID value.
		/// </summary>
		public string Approved2User_ID {
			get { return approved2User_ID; }
			set { approved2User_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Approved3User_ID value.
		/// </summary>
		public string Approved3User_ID {
			get { return approved3User_ID; }
			set { approved3User_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceldUser_ID value.
		/// </summary>
		public string CanceldUser_ID {
			get { return canceldUser_ID; }
			set { canceldUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LockedUser_ID value.
		/// </summary>
		public string LockedUser_ID {
			get { return lockedUser_ID; }
			set { lockedUser_ID = value; }
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
		/// Gets or sets the DateChecked1 value.
		/// </summary>
		public DateTime DateChecked1 {
			get { return dateChecked1; }
			set { dateChecked1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateChecked2 value.
		/// </summary>
		public DateTime DateChecked2 {
			get { return dateChecked2; }
			set { dateChecked2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateChecked3 value.
		/// </summary>
		public DateTime DateChecked3 {
			get { return dateChecked3; }
			set { dateChecked3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved1 value.
		/// </summary>
		public DateTime DateApproved1 {
			get { return dateApproved1; }
			set { dateApproved1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved2 value.
		/// </summary>
		public DateTime DateApproved2 {
			get { return dateApproved2; }
			set { dateApproved2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved3 value.
		/// </summary>
		public DateTime DateApproved3 {
			get { return dateApproved3; }
			set { dateApproved3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateLocked value.
		/// </summary>
		public DateTime DateLocked {
			get { return dateLocked; }
			set { dateLocked = value; }
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
		/// Gets or sets the Checked1UserTerminal_ID value.
		/// </summary>
		public string Checked1UserTerminal_ID {
			get { return checked1UserTerminal_ID; }
			set { checked1UserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Checked2UserTerminal_ID value.
		/// </summary>
		public string Checked2UserTerminal_ID {
			get { return checked2UserTerminal_ID; }
			set { checked2UserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Checked3UserTerminal_ID value.
		/// </summary>
		public string Checked3UserTerminal_ID {
			get { return checked3UserTerminal_ID; }
			set { checked3UserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Approved1UserTerminal_ID value.
		/// </summary>
		public string Approved1UserTerminal_ID {
			get { return approved1UserTerminal_ID; }
			set { approved1UserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Approved2UserTerminal_ID value.
		/// </summary>
		public string Approved2UserTerminal_ID {
			get { return approved2UserTerminal_ID; }
			set { approved2UserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Approved3UserTerminal_ID value.
		/// </summary>
		public string Approved3UserTerminal_ID {
			get { return approved3UserTerminal_ID; }
			set { approved3UserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceledUserTerminal_ID value.
		/// </summary>
		public string CanceledUserTerminal_ID {
			get { return canceledUserTerminal_ID; }
			set { canceledUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LockedUserTerminal_ID value.
		/// </summary>
		public string LockedUserTerminal_ID {
			get { return lockedUserTerminal_ID; }
			set { lockedUserTerminal_ID = value; }
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
		/// Gets or sets the CustomerOrder_Qty value.
		/// </summary>
		public decimal CustomerOrder_Qty {
			get { return customerOrder_Qty; }
			set { customerOrder_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTemporaryBoM value.
		/// </summary>
		public bool IsTemporaryBoM {
			get { return isTemporaryBoM; }
			set { isTemporaryBoM = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxJobCard table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJobDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodJobStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@salesman_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerInquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks2", SqlDbType.VarChar,200);
			scom.Parameters.Add("@jobType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prodRange_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prodCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prodSize_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID_Previous", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Length_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Width_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Height_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Diameter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Diameter_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Radius", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Radius_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Thickness_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Weight_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@orderedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fGoodQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wastePercent", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wasteQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@exfactoryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodStartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@estProdHrs", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked1", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked2", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked3", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved1", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved2", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved3", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checked1User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checked2User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checked3User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approved1User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approved2User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approved3User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lockedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked1", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked2", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked3", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved1", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved2", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved3", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateLocked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checked1UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checked2UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checked3UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approved1UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approved2UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approved3UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@lockedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isTemporaryBoM", SqlDbType.Bit,1);
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodJobDate"].Value = prodJobDate;
			scom.Parameters["@prodJobStatus"].Value = prodJobStatus;
			scom.Parameters["@salesman_ID"].Value = salesman_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerInquiry_ID"].Value = customerInquiry_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@remarks2"].Value = remarks2;
			scom.Parameters["@jobType_ID"].Value = jobType_ID;
			scom.Parameters["@prodRange_ID"].Value = prodRange_ID;
			scom.Parameters["@prodCategory_ID"].Value = prodCategory_ID;
			scom.Parameters["@prodSize_ID"].Value = prodSize_ID;
			scom.Parameters["@colour_ID"].Value = colour_ID;
			scom.Parameters["@item_ID_Previous"].Value = item_ID_Previous;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@item_Length"].Value = item_Length;
			scom.Parameters["@item_Length_UoM_ID"].Value = item_Length_UoM_ID;
			scom.Parameters["@item_Width"].Value = item_Width;
			scom.Parameters["@item_Width_UoM_ID"].Value = item_Width_UoM_ID;
			scom.Parameters["@item_Height"].Value = item_Height;
			scom.Parameters["@item_Height_UoM_ID"].Value = item_Height_UoM_ID;
			scom.Parameters["@item_Diameter"].Value = item_Diameter;
			scom.Parameters["@item_Diameter_UoM_ID"].Value = item_Diameter_UoM_ID;
			scom.Parameters["@item_Radius"].Value = item_Radius;
			scom.Parameters["@item_Radius_UoM_ID"].Value = item_Radius_UoM_ID;
			scom.Parameters["@item_Thickness"].Value = item_Thickness;
			scom.Parameters["@item_Thickness_UoM_ID"].Value = item_Thickness_UoM_ID;
			scom.Parameters["@item_Weight"].Value = item_Weight;
			scom.Parameters["@item_Weight_UoM_ID"].Value = item_Weight_UoM_ID;
			scom.Parameters["@orderedQty"].Value = orderedQty;
			scom.Parameters["@fGoodQty"].Value = fGoodQty;
			scom.Parameters["@wastePercent"].Value = wastePercent;
			scom.Parameters["@wasteQty"].Value = wasteQty;
			scom.Parameters["@exfactoryDate"].Value = exfactoryDate;
			scom.Parameters["@prodStartDate"].Value = prodStartDate;
			scom.Parameters["@estProdHrs"].Value = estProdHrs;
			scom.Parameters["@isChecked1"].Value = isChecked1;
			scom.Parameters["@isChecked2"].Value = isChecked2;
			scom.Parameters["@isChecked3"].Value = isChecked3;
			scom.Parameters["@isApproved1"].Value = isApproved1;
			scom.Parameters["@isApproved2"].Value = isApproved2;
			scom.Parameters["@isApproved3"].Value = isApproved3;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checked1User_ID"].Value = checked1User_ID;
			scom.Parameters["@checked2User_ID"].Value = checked2User_ID;
			scom.Parameters["@checked3User_ID"].Value = checked3User_ID;
			scom.Parameters["@approved1User_ID"].Value = approved1User_ID;
			scom.Parameters["@approved2User_ID"].Value = approved2User_ID;
			scom.Parameters["@approved3User_ID"].Value = approved3User_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@lockedUser_ID"].Value = lockedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked1"].Value = dateChecked1;
			scom.Parameters["@dateChecked2"].Value = dateChecked2;
			scom.Parameters["@dateChecked3"].Value = dateChecked3;
			scom.Parameters["@dateApproved1"].Value = dateApproved1;
			scom.Parameters["@dateApproved2"].Value = dateApproved2;
			scom.Parameters["@dateApproved3"].Value = dateApproved3;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@dateLocked"].Value = dateLocked;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checked1UserTerminal_ID"].Value = checked1UserTerminal_ID;
			scom.Parameters["@checked2UserTerminal_ID"].Value = checked2UserTerminal_ID;
			scom.Parameters["@checked3UserTerminal_ID"].Value = checked3UserTerminal_ID;
			scom.Parameters["@approved1UserTerminal_ID"].Value = approved1UserTerminal_ID;
			scom.Parameters["@approved2UserTerminal_ID"].Value = approved2UserTerminal_ID;
			scom.Parameters["@approved3UserTerminal_ID"].Value = approved3UserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@lockedUserTerminal_ID"].Value = lockedUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
			scom.Parameters["@customerOrder_Qty"].Value = customerOrder_Qty;
			scom.Parameters["@isTemporaryBoM"].Value = isTemporaryBoM;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxJobCard table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJobDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodJobStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@salesman_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerInquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks2", SqlDbType.VarChar,200);
			scom.Parameters.Add("@jobType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prodRange_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prodCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prodSize_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID_Previous", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Length_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Width_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Height_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Diameter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Diameter_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Radius", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Radius_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Thickness_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@item_Weight_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@orderedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fGoodQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wastePercent", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wasteQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@exfactoryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodStartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@estProdHrs", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked1", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked2", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked3", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved1", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved2", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved3", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checked1User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checked2User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checked3User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approved1User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approved2User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approved3User_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@lockedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked1", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked2", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked3", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved1", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved2", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved3", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateLocked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checked1UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checked2UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checked3UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approved1UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approved2UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approved3UserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@lockedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isTemporaryBoM", SqlDbType.Bit,1);
 
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodJobDate"].Value = prodJobDate;
			scom.Parameters["@prodJobStatus"].Value = prodJobStatus;
			scom.Parameters["@salesman_ID"].Value = salesman_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerInquiry_ID"].Value = customerInquiry_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@remarks2"].Value = remarks2;
			scom.Parameters["@jobType_ID"].Value = jobType_ID;
			scom.Parameters["@prodRange_ID"].Value = prodRange_ID;
			scom.Parameters["@prodCategory_ID"].Value = prodCategory_ID;
			scom.Parameters["@prodSize_ID"].Value = prodSize_ID;
			scom.Parameters["@colour_ID"].Value = colour_ID;
			scom.Parameters["@item_ID_Previous"].Value = item_ID_Previous;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@item_Length"].Value = item_Length;
			scom.Parameters["@item_Length_UoM_ID"].Value = item_Length_UoM_ID;
			scom.Parameters["@item_Width"].Value = item_Width;
			scom.Parameters["@item_Width_UoM_ID"].Value = item_Width_UoM_ID;
			scom.Parameters["@item_Height"].Value = item_Height;
			scom.Parameters["@item_Height_UoM_ID"].Value = item_Height_UoM_ID;
			scom.Parameters["@item_Diameter"].Value = item_Diameter;
			scom.Parameters["@item_Diameter_UoM_ID"].Value = item_Diameter_UoM_ID;
			scom.Parameters["@item_Radius"].Value = item_Radius;
			scom.Parameters["@item_Radius_UoM_ID"].Value = item_Radius_UoM_ID;
			scom.Parameters["@item_Thickness"].Value = item_Thickness;
			scom.Parameters["@item_Thickness_UoM_ID"].Value = item_Thickness_UoM_ID;
			scom.Parameters["@item_Weight"].Value = item_Weight;
			scom.Parameters["@item_Weight_UoM_ID"].Value = item_Weight_UoM_ID;
			scom.Parameters["@orderedQty"].Value = orderedQty;
			scom.Parameters["@fGoodQty"].Value = fGoodQty;
			scom.Parameters["@wastePercent"].Value = wastePercent;
			scom.Parameters["@wasteQty"].Value = wasteQty;
			scom.Parameters["@exfactoryDate"].Value = exfactoryDate;
			scom.Parameters["@prodStartDate"].Value = prodStartDate;
			scom.Parameters["@estProdHrs"].Value = estProdHrs;
			scom.Parameters["@isChecked1"].Value = isChecked1;
			scom.Parameters["@isChecked2"].Value = isChecked2;
			scom.Parameters["@isChecked3"].Value = isChecked3;
			scom.Parameters["@isApproved1"].Value = isApproved1;
			scom.Parameters["@isApproved2"].Value = isApproved2;
			scom.Parameters["@isApproved3"].Value = isApproved3;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checked1User_ID"].Value = checked1User_ID;
			scom.Parameters["@checked2User_ID"].Value = checked2User_ID;
			scom.Parameters["@checked3User_ID"].Value = checked3User_ID;
			scom.Parameters["@approved1User_ID"].Value = approved1User_ID;
			scom.Parameters["@approved2User_ID"].Value = approved2User_ID;
			scom.Parameters["@approved3User_ID"].Value = approved3User_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@lockedUser_ID"].Value = lockedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked1"].Value = dateChecked1;
			scom.Parameters["@dateChecked2"].Value = dateChecked2;
			scom.Parameters["@dateChecked3"].Value = dateChecked3;
			scom.Parameters["@dateApproved1"].Value = dateApproved1;
			scom.Parameters["@dateApproved2"].Value = dateApproved2;
			scom.Parameters["@dateApproved3"].Value = dateApproved3;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@dateLocked"].Value = dateLocked;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checked1UserTerminal_ID"].Value = checked1UserTerminal_ID;
			scom.Parameters["@checked2UserTerminal_ID"].Value = checked2UserTerminal_ID;
			scom.Parameters["@checked3UserTerminal_ID"].Value = checked3UserTerminal_ID;
			scom.Parameters["@approved1UserTerminal_ID"].Value = approved1UserTerminal_ID;
			scom.Parameters["@approved2UserTerminal_ID"].Value = approved2UserTerminal_ID;
			scom.Parameters["@approved3UserTerminal_ID"].Value = approved3UserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@lockedUserTerminal_ID"].Value = lockedUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
			scom.Parameters["@customerOrder_Qty"].Value = customerOrder_Qty;
			scom.Parameters["@isTemporaryBoM"].Value = isTemporaryBoM;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxJobCard table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByChecked3User_ID(string checked3User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByChecked3User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checked3User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checked3User_ID"].Value = checked3User_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByApproved1User_ID(string approved1User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByApproved1User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approved1User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approved1User_ID"].Value = approved1User_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_Height_UoM_ID(string item_Height_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_Height_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_Height_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Height_UoM_ID"].Value = item_Height_UoM_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdRange_ID(string prodRange_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByProdRange_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodRange_ID", SqlDbType.VarChar,10);
			scom.Parameters["@prodRange_ID"].Value = prodRange_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByColour_ID(string colour_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByColour_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByApproved3User_ID(string approved3User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByApproved3User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approved3User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approved3User_ID"].Value = approved3User_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdSize_ID(string prodSize_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByProdSize_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodSize_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodSize_ID"].Value = prodSize_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_Length_UoM_ID(string item_Length_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_Length_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_Length_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Length_UoM_ID"].Value = item_Length_UoM_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_Width_UoM_ID(string item_Width_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_Width_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_Width_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Width_UoM_ID"].Value = item_Width_UoM_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_Radius_UoM_ID(string item_Radius_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_Radius_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_Radius_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Radius_UoM_ID"].Value = item_Radius_UoM_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		//public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByProdJob_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	//scon.Open();
 
		//	scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
		//	scon.Open();
		//	scom.ExecuteNonQuery();
		//	scon.Close();
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_Diameter_UoM_ID(string item_Diameter_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_Diameter_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_Diameter_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Diameter_UoM_ID"].Value = item_Diameter_UoM_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesman_ID(string salesman_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllBySalesman_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@salesman_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesman_ID"].Value = salesman_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_Thickness_UoM_ID(string item_Thickness_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_Thickness_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_Thickness_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Thickness_UoM_ID"].Value = item_Thickness_UoM_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByJobType_ID(string jobType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByJobType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@jobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@jobType_ID"].Value = jobType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByLockedUser_ID(string lockedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByLockedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@lockedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@lockedUser_ID"].Value = lockedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByApproved2User_ID(string approved2User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByApproved2User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approved2User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approved2User_ID"].Value = approved2User_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		//public static void DeleteAllByApproved3User_ID(string approved3User_ID) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByApproved3User_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@approved3User_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@approved3User_ID"].Value = approved3User_ID;
 
		//	scon.Open();
		//	scom.ExecuteNonQuery();
		//	scon.Close();
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerInquiry_ID(string customerInquiry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByCustomerInquiry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customerInquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerInquiry_ID"].Value = customerInquiry_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_Weight_UoM_ID(string item_Weight_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByItem_Weight_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_Weight_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Weight_UoM_ID"].Value = item_Weight_UoM_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdCategory_ID(string prodCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByProdCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@prodCategory_ID"].Value = prodCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByChecked2User_ID(string checked2User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByChecked2User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checked2User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checked2User_ID"].Value = checked2User_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByChecked1User_ID(string checked1User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardDeleteAllByChecked1User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checked1User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checked1User_ID"].Value = checked1User_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxJobCard table.
		/// </summary>
		public static tbl_prod_pharmaTxJobCard Select(string prodJob_ID_Incoming){

			tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCardins = new tbl_prod_pharmaTxJobCard();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxJobCardins = Maketbl_prod_pharmaTxJobCard(dataReader);
				} else {
					tbl_prod_pharmaTxJobCardins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByChecked3User_ID(string checked3User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByChecked3User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checked3User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checked3User_ID"].Value = checked3User_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByApproved1User_ID(string approved1User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByApproved1User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approved1User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approved1User_ID"].Value = approved1User_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_Height_UoM_ID(string item_Height_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_Height_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_Height_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Height_UoM_ID"].Value = item_Height_UoM_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByProdRange_ID(string prodRange_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByProdRange_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodRange_ID", SqlDbType.VarChar,10);
			scom.Parameters["@prodRange_ID"].Value = prodRange_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByColour_ID(string colour_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByColour_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByApproved3User_ID(string approved3User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByApproved3User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approved3User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approved3User_ID"].Value = approved3User_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByProdSize_ID(string prodSize_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByProdSize_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodSize_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodSize_ID"].Value = prodSize_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_Length_UoM_ID(string item_Length_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_Length_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_Length_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Length_UoM_ID"].Value = item_Length_UoM_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_Width_UoM_ID(string item_Width_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_Width_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_Width_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Width_UoM_ID"].Value = item_Width_UoM_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_Radius_UoM_ID(string item_Radius_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_Radius_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_Radius_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Radius_UoM_ID"].Value = item_Radius_UoM_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		//public static List<tbl_prod_pharmaTxJobCard> SelectAllByProdJob_ID(string prodJob_ID) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByProdJob_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
		//		List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
		//	using (SqlDataReader dataReader = scom.ExecuteReader()){
		//		while (dataReader.Read()) {
		//			tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
		//			tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
		//		}
		//	}
		//	scon.Close();
		//	return tbl_prod_pharmaTxJobCardList;
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_Diameter_UoM_ID(string item_Diameter_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_Diameter_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_Diameter_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Diameter_UoM_ID"].Value = item_Diameter_UoM_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllBySalesman_ID(string salesman_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllBySalesman_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesman_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesman_ID"].Value = salesman_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_Thickness_UoM_ID(string item_Thickness_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_Thickness_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_Thickness_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Thickness_UoM_ID"].Value = item_Thickness_UoM_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByJobType_ID(string jobType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByJobType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@jobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@jobType_ID"].Value = jobType_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByLockedUser_ID(string lockedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByLockedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@lockedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@lockedUser_ID"].Value = lockedUser_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByApproved2User_ID(string approved2User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByApproved2User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approved2User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approved2User_ID"].Value = approved2User_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		//public static List<tbl_prod_pharmaTxJobCard> SelectAllByApproved3User_ID(string approved3User_ID) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByApproved3User_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@approved3User_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@approved3User_ID"].Value = approved3User_ID;
		//		List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
		//	using (SqlDataReader dataReader = scom.ExecuteReader()){
		//		while (dataReader.Read()) {
		//			tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
		//			tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
		//		}
		//	}
		//	scon.Close();
		//	return tbl_prod_pharmaTxJobCardList;
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByCustomerInquiry_ID(string customerInquiry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByCustomerInquiry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerInquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerInquiry_ID"].Value = customerInquiry_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByItem_Weight_UoM_ID(string item_Weight_UoM_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByItem_Weight_UoM_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_Weight_UoM_ID", SqlDbType.VarChar,10);
			scom.Parameters["@item_Weight_UoM_ID"].Value = item_Weight_UoM_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByProdCategory_ID(string prodCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByProdCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@prodCategory_ID"].Value = prodCategory_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByChecked2User_ID(string checked2User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByChecked2User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checked2User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checked2User_ID"].Value = checked2User_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard> SelectAllByChecked1User_ID(string checked1User_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCardSelectAllByChecked1User_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checked1User_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checked1User_ID"].Value = checked1User_ID;
				List<tbl_prod_pharmaTxJobCard> tbl_prod_pharmaTxJobCardList = new List<tbl_prod_pharmaTxJobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = Maketbl_prod_pharmaTxJobCard(dataReader);
					tbl_prod_pharmaTxJobCardList.Add(tbl_prod_pharmaTxJobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCardList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxJobCard class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxJobCard Maketbl_prod_pharmaTxJobCard(SqlDataReader dataReader) {
			tbl_prod_pharmaTxJobCard tbl_prod_pharmaTxJobCard = new tbl_prod_pharmaTxJobCard();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxJobCard.ProdJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxJobCard.ProdJobDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxJobCard.ProdJobStatus = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxJobCard.Salesman_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxJobCard.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxJobCard.CustomerInquiry_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxJobCard.CustomerOrder_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxJobCard.Remarks = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxJobCard.Remarks2 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxJobCard.JobType_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxJobCard.ProdRange_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_pharmaTxJobCard.ProdCategory_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_pharmaTxJobCard.ProdSize_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_pharmaTxJobCard.Colour_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_pharmaTxJobCard.Item_ID_Previous = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_pharmaTxJobCard.Item_ID_FG = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_pharmaTxJobCard.Uom_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_pharmaTxJobCard.Item_Length = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_pharmaTxJobCard.Item_Length_UoM_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_pharmaTxJobCard.Item_Width = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_pharmaTxJobCard.Item_Width_UoM_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_pharmaTxJobCard.Item_Height = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_pharmaTxJobCard.Item_Height_UoM_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_pharmaTxJobCard.Item_Diameter = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_pharmaTxJobCard.Item_Diameter_UoM_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prod_pharmaTxJobCard.Item_Radius = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prod_pharmaTxJobCard.Item_Radius_UoM_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prod_pharmaTxJobCard.Item_Thickness = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_prod_pharmaTxJobCard.Item_Thickness_UoM_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_prod_pharmaTxJobCard.Item_Weight = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_prod_pharmaTxJobCard.Item_Weight_UoM_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_prod_pharmaTxJobCard.OrderedQty = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_prod_pharmaTxJobCard.FGoodQty = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_prod_pharmaTxJobCard.WastePercent = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_prod_pharmaTxJobCard.WasteQty = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_prod_pharmaTxJobCard.ExfactoryDate = dataReader.GetDateTime(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_prod_pharmaTxJobCard.ProdStartDate = dataReader.GetDateTime(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_prod_pharmaTxJobCard.EstProdHrs = dataReader.GetDecimal(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_prod_pharmaTxJobCard.IsChecked1 = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_prod_pharmaTxJobCard.IsChecked2 = dataReader.GetBoolean(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_prod_pharmaTxJobCard.IsChecked3 = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_prod_pharmaTxJobCard.IsApproved1 = dataReader.GetBoolean(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_prod_pharmaTxJobCard.IsApproved2 = dataReader.GetBoolean(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_prod_pharmaTxJobCard.IsApproved3 = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_prod_pharmaTxJobCard.IsCanceled = dataReader.GetBoolean(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_prod_pharmaTxJobCard.IsLocked = dataReader.GetBoolean(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_prod_pharmaTxJobCard.CreateUser_ID = dataReader.GetString(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_prod_pharmaTxJobCard.ModifiedUser_ID = dataReader.GetString(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_prod_pharmaTxJobCard.Checked1User_ID = dataReader.GetString(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_prod_pharmaTxJobCard.Checked2User_ID = dataReader.GetString(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_prod_pharmaTxJobCard.Checked3User_ID = dataReader.GetString(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_prod_pharmaTxJobCard.Approved1User_ID = dataReader.GetString(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_prod_pharmaTxJobCard.Approved2User_ID = dataReader.GetString(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_prod_pharmaTxJobCard.Approved3User_ID = dataReader.GetString(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_prod_pharmaTxJobCard.CanceldUser_ID = dataReader.GetString(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_prod_pharmaTxJobCard.LockedUser_ID = dataReader.GetString(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_prod_pharmaTxJobCard.DateCreate = dataReader.GetDateTime(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_prod_pharmaTxJobCard.DateModified = dataReader.GetDateTime(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_prod_pharmaTxJobCard.DateChecked1 = dataReader.GetDateTime(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_prod_pharmaTxJobCard.DateChecked2 = dataReader.GetDateTime(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_prod_pharmaTxJobCard.DateChecked3 = dataReader.GetDateTime(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_prod_pharmaTxJobCard.DateApproved1 = dataReader.GetDateTime(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_prod_pharmaTxJobCard.DateApproved2 = dataReader.GetDateTime(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_prod_pharmaTxJobCard.DateApproved3 = dataReader.GetDateTime(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_prod_pharmaTxJobCard.DateCanceled = dataReader.GetDateTime(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_prod_pharmaTxJobCard.DateLocked = dataReader.GetDateTime(65);
			}
			if (dataReader.IsDBNull(66) == false) {
				tbl_prod_pharmaTxJobCard.CreateUserTerminal_ID = dataReader.GetString(66);
			}
			if (dataReader.IsDBNull(67) == false) {
				tbl_prod_pharmaTxJobCard.ModifiedUserTerminal_ID = dataReader.GetString(67);
			}
			if (dataReader.IsDBNull(68) == false) {
				tbl_prod_pharmaTxJobCard.Checked1UserTerminal_ID = dataReader.GetString(68);
			}
			if (dataReader.IsDBNull(69) == false) {
				tbl_prod_pharmaTxJobCard.Checked2UserTerminal_ID = dataReader.GetString(69);
			}
			if (dataReader.IsDBNull(70) == false) {
				tbl_prod_pharmaTxJobCard.Checked3UserTerminal_ID = dataReader.GetString(70);
			}
			if (dataReader.IsDBNull(71) == false) {
				tbl_prod_pharmaTxJobCard.Approved1UserTerminal_ID = dataReader.GetString(71);
			}
			if (dataReader.IsDBNull(72) == false) {
				tbl_prod_pharmaTxJobCard.Approved2UserTerminal_ID = dataReader.GetString(72);
			}
			if (dataReader.IsDBNull(73) == false) {
				tbl_prod_pharmaTxJobCard.Approved3UserTerminal_ID = dataReader.GetString(73);
			}
			if (dataReader.IsDBNull(74) == false) {
				tbl_prod_pharmaTxJobCard.CanceledUserTerminal_ID = dataReader.GetString(74);
			}
			if (dataReader.IsDBNull(75) == false) {
				tbl_prod_pharmaTxJobCard.LockedUserTerminal_ID = dataReader.GetString(75);
			}
			if (dataReader.IsDBNull(76) == false) {
				tbl_prod_pharmaTxJobCard.CompanyID = dataReader.GetString(76);
			}
			if (dataReader.IsDBNull(77) == false) {
				tbl_prod_pharmaTxJobCard.CompanyBranchID = dataReader.GetString(77);
			}
			if (dataReader.IsDBNull(78) == false) {
				tbl_prod_pharmaTxJobCard.CustomerOrder_Qty = dataReader.GetDecimal(78);
			}
			if (dataReader.IsDBNull(79) == false) {
				tbl_prod_pharmaTxJobCard.IsTemporaryBoM = dataReader.GetBoolean(79);
			}

			return tbl_prod_pharmaTxJobCard;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxJobCard datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxJobCard  tbl_prod_pharmaTxJobCard   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodJobDate = new DataColumn("prodJobDate" , typeof(DateTime));
			DataColumn col_prodJobStatus = new DataColumn("prodJobStatus" , typeof(int));
			DataColumn col_salesman_ID = new DataColumn("salesman_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_customerInquiry_ID = new DataColumn("customerInquiry_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_remarks2 = new DataColumn("remarks2" , typeof(string));
			DataColumn col_jobType_ID = new DataColumn("jobType_ID" , typeof(string));
			DataColumn col_prodRange_ID = new DataColumn("prodRange_ID" , typeof(string));
			DataColumn col_prodCategory_ID = new DataColumn("prodCategory_ID" , typeof(string));
			DataColumn col_prodSize_ID = new DataColumn("prodSize_ID" , typeof(string));
			DataColumn col_colour_ID = new DataColumn("colour_ID" , typeof(string));
			DataColumn col_item_ID_Previous = new DataColumn("item_ID_Previous" , typeof(string));
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_item_Length = new DataColumn("item_Length" , typeof(decimal));
			DataColumn col_item_Length_UoM_ID = new DataColumn("item_Length_UoM_ID" , typeof(string));
			DataColumn col_item_Width = new DataColumn("item_Width" , typeof(decimal));
			DataColumn col_item_Width_UoM_ID = new DataColumn("item_Width_UoM_ID" , typeof(string));
			DataColumn col_item_Height = new DataColumn("item_Height" , typeof(decimal));
			DataColumn col_item_Height_UoM_ID = new DataColumn("item_Height_UoM_ID" , typeof(string));
			DataColumn col_item_Diameter = new DataColumn("item_Diameter" , typeof(decimal));
			DataColumn col_item_Diameter_UoM_ID = new DataColumn("item_Diameter_UoM_ID" , typeof(string));
			DataColumn col_item_Radius = new DataColumn("item_Radius" , typeof(decimal));
			DataColumn col_item_Radius_UoM_ID = new DataColumn("item_Radius_UoM_ID" , typeof(string));
			DataColumn col_item_Thickness = new DataColumn("item_Thickness" , typeof(decimal));
			DataColumn col_item_Thickness_UoM_ID = new DataColumn("item_Thickness_UoM_ID" , typeof(string));
			DataColumn col_item_Weight = new DataColumn("item_Weight" , typeof(decimal));
			DataColumn col_item_Weight_UoM_ID = new DataColumn("item_Weight_UoM_ID" , typeof(string));
			DataColumn col_orderedQty = new DataColumn("orderedQty" , typeof(decimal));
			DataColumn col_fGoodQty = new DataColumn("fGoodQty" , typeof(decimal));
			DataColumn col_wastePercent = new DataColumn("wastePercent" , typeof(decimal));
			DataColumn col_wasteQty = new DataColumn("wasteQty" , typeof(decimal));
			DataColumn col_exfactoryDate = new DataColumn("exfactoryDate" , typeof(DateTime));
			DataColumn col_prodStartDate = new DataColumn("prodStartDate" , typeof(DateTime));
			DataColumn col_estProdHrs = new DataColumn("estProdHrs" , typeof(decimal));
			DataColumn col_isChecked1 = new DataColumn("isChecked1" , typeof(bool));
			DataColumn col_isChecked2 = new DataColumn("isChecked2" , typeof(bool));
			DataColumn col_isChecked3 = new DataColumn("isChecked3" , typeof(bool));
			DataColumn col_isApproved1 = new DataColumn("isApproved1" , typeof(bool));
			DataColumn col_isApproved2 = new DataColumn("isApproved2" , typeof(bool));
			DataColumn col_isApproved3 = new DataColumn("isApproved3" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checked1User_ID = new DataColumn("checked1User_ID" , typeof(string));
			DataColumn col_checked2User_ID = new DataColumn("checked2User_ID" , typeof(string));
			DataColumn col_checked3User_ID = new DataColumn("checked3User_ID" , typeof(string));
			DataColumn col_approved1User_ID = new DataColumn("approved1User_ID" , typeof(string));
			DataColumn col_approved2User_ID = new DataColumn("approved2User_ID" , typeof(string));
			DataColumn col_approved3User_ID = new DataColumn("approved3User_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_lockedUser_ID = new DataColumn("lockedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked1 = new DataColumn("dateChecked1" , typeof(DateTime));
			DataColumn col_dateChecked2 = new DataColumn("dateChecked2" , typeof(DateTime));
			DataColumn col_dateChecked3 = new DataColumn("dateChecked3" , typeof(DateTime));
			DataColumn col_dateApproved1 = new DataColumn("dateApproved1" , typeof(DateTime));
			DataColumn col_dateApproved2 = new DataColumn("dateApproved2" , typeof(DateTime));
			DataColumn col_dateApproved3 = new DataColumn("dateApproved3" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_dateLocked = new DataColumn("dateLocked" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_checked1UserTerminal_ID = new DataColumn("checked1UserTerminal_ID" , typeof(string));
			DataColumn col_checked2UserTerminal_ID = new DataColumn("checked2UserTerminal_ID" , typeof(string));
			DataColumn col_checked3UserTerminal_ID = new DataColumn("checked3UserTerminal_ID" , typeof(string));
			DataColumn col_approved1UserTerminal_ID = new DataColumn("approved1UserTerminal_ID" , typeof(string));
			DataColumn col_approved2UserTerminal_ID = new DataColumn("approved2UserTerminal_ID" , typeof(string));
			DataColumn col_approved3UserTerminal_ID = new DataColumn("approved3UserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
			DataColumn col_lockedUserTerminal_ID = new DataColumn("lockedUserTerminal_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranchID = new DataColumn("companyBranchID" , typeof(string));
			DataColumn col_customerOrder_Qty = new DataColumn("customerOrder_Qty" , typeof(decimal));
			DataColumn col_isTemporaryBoM = new DataColumn("isTemporaryBoM" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_prodJob_ID,col_prodJobDate,col_prodJobStatus,col_salesman_ID,col_customer_ID,col_customerInquiry_ID,col_customerOrder_ID,col_remarks,col_remarks2,col_jobType_ID,col_prodRange_ID,col_prodCategory_ID,col_prodSize_ID,col_colour_ID,col_item_ID_Previous,col_item_ID_FG,col_uom_ID,col_item_Length,col_item_Length_UoM_ID,col_item_Width,col_item_Width_UoM_ID,col_item_Height,col_item_Height_UoM_ID,col_item_Diameter,col_item_Diameter_UoM_ID,col_item_Radius,col_item_Radius_UoM_ID,col_item_Thickness,col_item_Thickness_UoM_ID,col_item_Weight,col_item_Weight_UoM_ID,col_orderedQty,col_fGoodQty,col_wastePercent,col_wasteQty,col_exfactoryDate,col_prodStartDate,col_estProdHrs,col_isChecked1,col_isChecked2,col_isChecked3,col_isApproved1,col_isApproved2,col_isApproved3,col_isCanceled,col_isLocked,col_createUser_ID,col_modifiedUser_ID,col_checked1User_ID,col_checked2User_ID,col_checked3User_ID,col_approved1User_ID,col_approved2User_ID,col_approved3User_ID,col_canceldUser_ID,col_lockedUser_ID,col_dateCreate,col_dateModified,col_dateChecked1,col_dateChecked2,col_dateChecked3,col_dateApproved1,col_dateApproved2,col_dateApproved3,col_dateCanceled,col_dateLocked,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checked1UserTerminal_ID,col_checked2UserTerminal_ID,col_checked3UserTerminal_ID,col_approved1UserTerminal_ID,col_approved2UserTerminal_ID,col_approved3UserTerminal_ID,col_canceledUserTerminal_ID,col_lockedUserTerminal_ID,col_companyID,col_companyBranchID,col_customerOrder_Qty,col_isTemporaryBoM,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxJobCard datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxJobCard user) {
		DataRow drow = dt.NewRow();
		
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodJobDate"] = user.prodJobDate;
			drow["prodJobStatus"] = user.prodJobStatus;
			drow["salesman_ID"] = user.salesman_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["customerInquiry_ID"] = user.customerInquiry_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["remarks"] = user.remarks;
			drow["remarks2"] = user.remarks2;
			drow["jobType_ID"] = user.jobType_ID;
			drow["prodRange_ID"] = user.prodRange_ID;
			drow["prodCategory_ID"] = user.prodCategory_ID;
			drow["prodSize_ID"] = user.prodSize_ID;
			drow["colour_ID"] = user.colour_ID;
			drow["item_ID_Previous"] = user.item_ID_Previous;
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["uom_ID"] = user.uom_ID;
			drow["item_Length"] = user.item_Length;
			drow["item_Length_UoM_ID"] = user.item_Length_UoM_ID;
			drow["item_Width"] = user.item_Width;
			drow["item_Width_UoM_ID"] = user.item_Width_UoM_ID;
			drow["item_Height"] = user.item_Height;
			drow["item_Height_UoM_ID"] = user.item_Height_UoM_ID;
			drow["item_Diameter"] = user.item_Diameter;
			drow["item_Diameter_UoM_ID"] = user.item_Diameter_UoM_ID;
			drow["item_Radius"] = user.item_Radius;
			drow["item_Radius_UoM_ID"] = user.item_Radius_UoM_ID;
			drow["item_Thickness"] = user.item_Thickness;
			drow["item_Thickness_UoM_ID"] = user.item_Thickness_UoM_ID;
			drow["item_Weight"] = user.item_Weight;
			drow["item_Weight_UoM_ID"] = user.item_Weight_UoM_ID;
			drow["orderedQty"] = user.orderedQty;
			drow["fGoodQty"] = user.fGoodQty;
			drow["wastePercent"] = user.wastePercent;
			drow["wasteQty"] = user.wasteQty;
			drow["exfactoryDate"] = user.exfactoryDate;
			drow["prodStartDate"] = user.prodStartDate;
			drow["estProdHrs"] = user.estProdHrs;
			drow["isChecked1"] = user.isChecked1;
			drow["isChecked2"] = user.isChecked2;
			drow["isChecked3"] = user.isChecked3;
			drow["isApproved1"] = user.isApproved1;
			drow["isApproved2"] = user.isApproved2;
			drow["isApproved3"] = user.isApproved3;
			drow["isCanceled"] = user.isCanceled;
			drow["isLocked"] = user.isLocked;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checked1User_ID"] = user.checked1User_ID;
			drow["checked2User_ID"] = user.checked2User_ID;
			drow["checked3User_ID"] = user.checked3User_ID;
			drow["approved1User_ID"] = user.approved1User_ID;
			drow["approved2User_ID"] = user.approved2User_ID;
			drow["approved3User_ID"] = user.approved3User_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["lockedUser_ID"] = user.lockedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked1"] = user.dateChecked1;
			drow["dateChecked2"] = user.dateChecked2;
			drow["dateChecked3"] = user.dateChecked3;
			drow["dateApproved1"] = user.dateApproved1;
			drow["dateApproved2"] = user.dateApproved2;
			drow["dateApproved3"] = user.dateApproved3;
			drow["dateCanceled"] = user.dateCanceled;
			drow["dateLocked"] = user.dateLocked;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["checked1UserTerminal_ID"] = user.checked1UserTerminal_ID;
			drow["checked2UserTerminal_ID"] = user.checked2UserTerminal_ID;
			drow["checked3UserTerminal_ID"] = user.checked3UserTerminal_ID;
			drow["approved1UserTerminal_ID"] = user.approved1UserTerminal_ID;
			drow["approved2UserTerminal_ID"] = user.approved2UserTerminal_ID;
			drow["approved3UserTerminal_ID"] = user.approved3UserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
			drow["lockedUserTerminal_ID"] = user.lockedUserTerminal_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranchID"] = user.companyBranchID;
			drow["customerOrder_Qty"] = user.customerOrder_Qty;
			drow["isTemporaryBoM"] = user.isTemporaryBoM;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
