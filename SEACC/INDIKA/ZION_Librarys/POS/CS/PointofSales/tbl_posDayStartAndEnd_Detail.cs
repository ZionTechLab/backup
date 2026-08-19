using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_posDayStartAndEnd_Detail {
		#region Fields
		private int dayDetail_Index;
		private int dayIndex;
		private DateTime posDate;
		private string posTerminal_ID;
		private string signInCashier_ID;
		private decimal signInFloatAmt;
		private decimal signInotherAmt;
		private bool isChecked;
		private bool isApproved;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string canceledUser_ID;
		private DateTime dateCreated;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateCanceled;
		private decimal dayEndCashAmt;
		private decimal dayEndOtherAmt;
		private decimal dayEndVarienceAmt;
		private bool isMgtSignOffCreated;
		private bool isMgtSignOffChecked;
		private bool isMgtSignOffApproved;
		private bool isMgtSignOffCanceled;
		private string mgtSignOffCreateUser_ID;
		private string mgtSignOffModifiedUser_ID;
		private string mgtSignOffCheckedUser_ID;
		private string mgtSignOffApprovedUser_ID;
		private string mgtSignOffCanceledUser_ID;
		private DateTime mgtSignOffCreateTime;
		private DateTime mgtSignOffModifiedTime;
		private DateTime mgtSignOffCheckedTime;
		private DateTime mgtSignOffApprovedTime;
		private DateTime mgtSignOffCanceledTime;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_posDayStartAndEnd_Detail class.
		/// </summary>
		public tbl_posDayStartAndEnd_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_posDayStartAndEnd_Detail class.
		/// </summary>
		public tbl_posDayStartAndEnd_Detail(int dayDetail_Index, int dayIndex, DateTime posDate, string posTerminal_ID, string signInCashier_ID, decimal signInFloatAmt, decimal signInotherAmt, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceledUser_ID, DateTime dateCreated, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, decimal dayEndCashAmt, decimal dayEndOtherAmt, decimal dayEndVarienceAmt, bool isMgtSignOffCreated, bool isMgtSignOffChecked, bool isMgtSignOffApproved, bool isMgtSignOffCanceled, string mgtSignOffCreateUser_ID, string mgtSignOffModifiedUser_ID, string mgtSignOffCheckedUser_ID, string mgtSignOffApprovedUser_ID, string mgtSignOffCanceledUser_ID, DateTime mgtSignOffCreateTime, DateTime mgtSignOffModifiedTime, DateTime mgtSignOffCheckedTime, DateTime mgtSignOffApprovedTime, DateTime mgtSignOffCanceledTime) {
			this.dayDetail_Index = dayDetail_Index;
			this.dayIndex = dayIndex;
			this.posDate = posDate;
			this.posTerminal_ID = posTerminal_ID;
			this.signInCashier_ID = signInCashier_ID;
			this.signInFloatAmt = signInFloatAmt;
			this.signInotherAmt = signInotherAmt;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.canceledUser_ID = canceledUser_ID;
			this.dateCreated = dateCreated;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateCanceled = dateCanceled;
			this.dayEndCashAmt = dayEndCashAmt;
			this.dayEndOtherAmt = dayEndOtherAmt;
			this.dayEndVarienceAmt = dayEndVarienceAmt;
			this.isMgtSignOffCreated = isMgtSignOffCreated;
			this.isMgtSignOffChecked = isMgtSignOffChecked;
			this.isMgtSignOffApproved = isMgtSignOffApproved;
			this.isMgtSignOffCanceled = isMgtSignOffCanceled;
			this.mgtSignOffCreateUser_ID = mgtSignOffCreateUser_ID;
			this.mgtSignOffModifiedUser_ID = mgtSignOffModifiedUser_ID;
			this.mgtSignOffCheckedUser_ID = mgtSignOffCheckedUser_ID;
			this.mgtSignOffApprovedUser_ID = mgtSignOffApprovedUser_ID;
			this.mgtSignOffCanceledUser_ID = mgtSignOffCanceledUser_ID;
			this.mgtSignOffCreateTime = mgtSignOffCreateTime;
			this.mgtSignOffModifiedTime = mgtSignOffModifiedTime;
			this.mgtSignOffCheckedTime = mgtSignOffCheckedTime;
			this.mgtSignOffApprovedTime = mgtSignOffApprovedTime;
			this.mgtSignOffCanceledTime = mgtSignOffCanceledTime;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DayDetail_Index value.
		/// </summary>
		public int DayDetail_Index {
			get { return dayDetail_Index; }
			set { dayDetail_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayIndex value.
		/// </summary>
		public int DayIndex {
			get { return dayIndex; }
			set { dayIndex = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosDate value.
		/// </summary>
		public DateTime PosDate {
			get { return posDate; }
			set { posDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTerminal_ID value.
		/// </summary>
		public string PosTerminal_ID {
			get { return posTerminal_ID; }
			set { posTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SignInCashier_ID value.
		/// </summary>
		public string SignInCashier_ID {
			get { return signInCashier_ID; }
			set { signInCashier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SignInFloatAmt value.
		/// </summary>
		public decimal SignInFloatAmt {
			get { return signInFloatAmt; }
			set { signInFloatAmt = value; }
		}
		
		/// <summary>
		/// Gets or sets the SignInotherAmt value.
		/// </summary>
		public decimal SignInotherAmt {
			get { return signInotherAmt; }
			set { signInotherAmt = value; }
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
		/// Gets or sets the CanceledUser_ID value.
		/// </summary>
		public string CanceledUser_ID {
			get { return canceledUser_ID; }
			set { canceledUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreated value.
		/// </summary>
		public DateTime DateCreated {
			get { return dateCreated; }
			set { dateCreated = value; }
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
		/// Gets or sets the DayEndCashAmt value.
		/// </summary>
		public decimal DayEndCashAmt {
			get { return dayEndCashAmt; }
			set { dayEndCashAmt = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayEndOtherAmt value.
		/// </summary>
		public decimal DayEndOtherAmt {
			get { return dayEndOtherAmt; }
			set { dayEndOtherAmt = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayEndVarienceAmt value.
		/// </summary>
		public decimal DayEndVarienceAmt {
			get { return dayEndVarienceAmt; }
			set { dayEndVarienceAmt = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMgtSignOffCreated value.
		/// </summary>
		public bool IsMgtSignOffCreated {
			get { return isMgtSignOffCreated; }
			set { isMgtSignOffCreated = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMgtSignOffChecked value.
		/// </summary>
		public bool IsMgtSignOffChecked {
			get { return isMgtSignOffChecked; }
			set { isMgtSignOffChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMgtSignOffApproved value.
		/// </summary>
		public bool IsMgtSignOffApproved {
			get { return isMgtSignOffApproved; }
			set { isMgtSignOffApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMgtSignOffCanceled value.
		/// </summary>
		public bool IsMgtSignOffCanceled {
			get { return isMgtSignOffCanceled; }
			set { isMgtSignOffCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffCreateUser_ID value.
		/// </summary>
		public string MgtSignOffCreateUser_ID {
			get { return mgtSignOffCreateUser_ID; }
			set { mgtSignOffCreateUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffModifiedUser_ID value.
		/// </summary>
		public string MgtSignOffModifiedUser_ID {
			get { return mgtSignOffModifiedUser_ID; }
			set { mgtSignOffModifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffCheckedUser_ID value.
		/// </summary>
		public string MgtSignOffCheckedUser_ID {
			get { return mgtSignOffCheckedUser_ID; }
			set { mgtSignOffCheckedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffApprovedUser_ID value.
		/// </summary>
		public string MgtSignOffApprovedUser_ID {
			get { return mgtSignOffApprovedUser_ID; }
			set { mgtSignOffApprovedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffCanceledUser_ID value.
		/// </summary>
		public string MgtSignOffCanceledUser_ID {
			get { return mgtSignOffCanceledUser_ID; }
			set { mgtSignOffCanceledUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffCreateTime value.
		/// </summary>
		public DateTime MgtSignOffCreateTime {
			get { return mgtSignOffCreateTime; }
			set { mgtSignOffCreateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffModifiedTime value.
		/// </summary>
		public DateTime MgtSignOffModifiedTime {
			get { return mgtSignOffModifiedTime; }
			set { mgtSignOffModifiedTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffCheckedTime value.
		/// </summary>
		public DateTime MgtSignOffCheckedTime {
			get { return mgtSignOffCheckedTime; }
			set { mgtSignOffCheckedTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffApprovedTime value.
		/// </summary>
		public DateTime MgtSignOffApprovedTime {
			get { return mgtSignOffApprovedTime; }
			set { mgtSignOffApprovedTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the MgtSignOffCanceledTime value.
		/// </summary>
		public DateTime MgtSignOffCanceledTime {
			get { return mgtSignOffCanceledTime; }
			set { mgtSignOffCanceledTime = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_posDayStartAndEnd_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =  DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@dayIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@posDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@posTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@signInCashier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@signInFloatAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@signInotherAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreated", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dayEndCashAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dayEndOtherAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dayEndVarienceAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isMgtSignOffCreated", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMgtSignOffChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMgtSignOffApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMgtSignOffCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@mgtSignOffCreateUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffModifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffCheckedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffApprovedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffCanceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffCreateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffModifiedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffCheckedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffApprovedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffCanceledTime", SqlDbType.DateTime,8);
 
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@dayIndex"].Value = dayIndex;
			scom.Parameters["@posDate"].Value = posDate;
			scom.Parameters["@posTerminal_ID"].Value = posTerminal_ID;
			scom.Parameters["@signInCashier_ID"].Value = signInCashier_ID;
			scom.Parameters["@signInFloatAmt"].Value = signInFloatAmt;
			scom.Parameters["@signInotherAmt"].Value = signInotherAmt;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
			scom.Parameters["@dateCreated"].Value = dateCreated;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@dayEndCashAmt"].Value = dayEndCashAmt;
			scom.Parameters["@dayEndOtherAmt"].Value = dayEndOtherAmt;
			scom.Parameters["@dayEndVarienceAmt"].Value = dayEndVarienceAmt;
			scom.Parameters["@isMgtSignOffCreated"].Value = isMgtSignOffCreated;
			scom.Parameters["@isMgtSignOffChecked"].Value = isMgtSignOffChecked;
			scom.Parameters["@isMgtSignOffApproved"].Value = isMgtSignOffApproved;
			scom.Parameters["@isMgtSignOffCanceled"].Value = isMgtSignOffCanceled;
			scom.Parameters["@mgtSignOffCreateUser_ID"].Value = mgtSignOffCreateUser_ID;
			scom.Parameters["@mgtSignOffModifiedUser_ID"].Value = mgtSignOffModifiedUser_ID;
			scom.Parameters["@mgtSignOffCheckedUser_ID"].Value = mgtSignOffCheckedUser_ID;
			scom.Parameters["@mgtSignOffApprovedUser_ID"].Value = mgtSignOffApprovedUser_ID;
			scom.Parameters["@mgtSignOffCanceledUser_ID"].Value = mgtSignOffCanceledUser_ID;
			scom.Parameters["@mgtSignOffCreateTime"].Value = mgtSignOffCreateTime;
			scom.Parameters["@mgtSignOffModifiedTime"].Value = mgtSignOffModifiedTime;
			scom.Parameters["@mgtSignOffCheckedTime"].Value = mgtSignOffCheckedTime;
			scom.Parameters["@mgtSignOffApprovedTime"].Value = mgtSignOffApprovedTime;
			scom.Parameters["@mgtSignOffCanceledTime"].Value = mgtSignOffCanceledTime;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_posDayStartAndEnd_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@dayIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@posDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@posTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@signInCashier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@signInFloatAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@signInotherAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreated", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dayEndCashAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dayEndOtherAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dayEndVarienceAmt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isMgtSignOffCreated", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMgtSignOffChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMgtSignOffApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMgtSignOffCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@mgtSignOffCreateUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffModifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffCheckedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffApprovedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffCanceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mgtSignOffCreateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffModifiedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffCheckedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffApprovedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@mgtSignOffCanceledTime", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@dayIndex"].Value = dayIndex;
			scom.Parameters["@posDate"].Value = posDate;
			scom.Parameters["@posTerminal_ID"].Value = posTerminal_ID;
			scom.Parameters["@signInCashier_ID"].Value = signInCashier_ID;
			scom.Parameters["@signInFloatAmt"].Value = signInFloatAmt;
			scom.Parameters["@signInotherAmt"].Value = signInotherAmt;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
			scom.Parameters["@dateCreated"].Value = dateCreated;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@dayEndCashAmt"].Value = dayEndCashAmt;
			scom.Parameters["@dayEndOtherAmt"].Value = dayEndOtherAmt;
			scom.Parameters["@dayEndVarienceAmt"].Value = dayEndVarienceAmt;
			scom.Parameters["@isMgtSignOffCreated"].Value = isMgtSignOffCreated;
			scom.Parameters["@isMgtSignOffChecked"].Value = isMgtSignOffChecked;
			scom.Parameters["@isMgtSignOffApproved"].Value = isMgtSignOffApproved;
			scom.Parameters["@isMgtSignOffCanceled"].Value = isMgtSignOffCanceled;
			scom.Parameters["@mgtSignOffCreateUser_ID"].Value = mgtSignOffCreateUser_ID;
			scom.Parameters["@mgtSignOffModifiedUser_ID"].Value = mgtSignOffModifiedUser_ID;
			scom.Parameters["@mgtSignOffCheckedUser_ID"].Value = mgtSignOffCheckedUser_ID;
			scom.Parameters["@mgtSignOffApprovedUser_ID"].Value = mgtSignOffApprovedUser_ID;
			scom.Parameters["@mgtSignOffCanceledUser_ID"].Value = mgtSignOffCanceledUser_ID;
			scom.Parameters["@mgtSignOffCreateTime"].Value = mgtSignOffCreateTime;
			scom.Parameters["@mgtSignOffModifiedTime"].Value = mgtSignOffModifiedTime;
			scom.Parameters["@mgtSignOffCheckedTime"].Value = mgtSignOffCheckedTime;
			scom.Parameters["@mgtSignOffApprovedTime"].Value = mgtSignOffApprovedTime;
			scom.Parameters["@mgtSignOffCanceledTime"].Value = mgtSignOffCanceledTime;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_posDayStartAndEnd_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMgtSignOffApprovedUser_ID(string mgtSignOffApprovedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByMgtSignOffApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mgtSignOffApprovedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffApprovedUser_ID"].Value = mgtSignOffApprovedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMgtSignOffModifiedUser_ID(string mgtSignOffModifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByMgtSignOffModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mgtSignOffModifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffModifiedUser_ID"].Value = mgtSignOffModifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByDayIndex(int dayIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByDayIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@dayIndex", SqlDbType.Int,4);
			scom.Parameters["@dayIndex"].Value = dayIndex;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySignInCashier_ID(string signInCashier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllBySignInCashier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@signInCashier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@signInCashier_ID"].Value = signInCashier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceledUser_ID(string canceledUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByCanceledUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMgtSignOffCreateUser_ID(string mgtSignOffCreateUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByMgtSignOffCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mgtSignOffCreateUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffCreateUser_ID"].Value = mgtSignOffCreateUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMgtSignOffCheckedUser_ID(string mgtSignOffCheckedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByMgtSignOffCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mgtSignOffCheckedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffCheckedUser_ID"].Value = mgtSignOffCheckedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMgtSignOffCanceledUser_ID(string mgtSignOffCanceledUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailDeleteAllByMgtSignOffCanceledUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mgtSignOffCanceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffCanceledUser_ID"].Value = mgtSignOffCanceledUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_posDayStartAndEnd_Detail table.
		/// </summary>
		public static tbl_posDayStartAndEnd_Detail Select(int dayDetail_Index_Incoming){

			tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detailins = new tbl_posDayStartAndEnd_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detailins = Maketbl_posDayStartAndEnd_Detail(dataReader);
				} else {
					tbl_posDayStartAndEnd_Detailins = null;
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByMgtSignOffApprovedUser_ID(string mgtSignOffApprovedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByMgtSignOffApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mgtSignOffApprovedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffApprovedUser_ID"].Value = mgtSignOffApprovedUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByMgtSignOffModifiedUser_ID(string mgtSignOffModifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByMgtSignOffModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mgtSignOffModifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffModifiedUser_ID"].Value = mgtSignOffModifiedUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByDayIndex(int dayIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByDayIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@dayIndex", SqlDbType.Int,4);
			scom.Parameters["@dayIndex"].Value = dayIndex;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllBySignInCashier_ID(string signInCashier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllBySignInCashier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@signInCashier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@signInCashier_ID"].Value = signInCashier_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByCanceledUser_ID(string canceledUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByCanceledUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByMgtSignOffCreateUser_ID(string mgtSignOffCreateUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByMgtSignOffCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mgtSignOffCreateUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffCreateUser_ID"].Value = mgtSignOffCreateUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByMgtSignOffCheckedUser_ID(string mgtSignOffCheckedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByMgtSignOffCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mgtSignOffCheckedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffCheckedUser_ID"].Value = mgtSignOffCheckedUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posDayStartAndEnd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posDayStartAndEnd_Detail> SelectAllByMgtSignOffCanceledUser_ID(string mgtSignOffCanceledUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posDayStartAndEnd_DetailSelectAllByMgtSignOffCanceledUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mgtSignOffCanceledUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mgtSignOffCanceledUser_ID"].Value = mgtSignOffCanceledUser_ID;
				List<tbl_posDayStartAndEnd_Detail> tbl_posDayStartAndEnd_DetailList = new List<tbl_posDayStartAndEnd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = Maketbl_posDayStartAndEnd_Detail(dataReader);
					tbl_posDayStartAndEnd_DetailList.Add(tbl_posDayStartAndEnd_Detail);
				}
			}
			scon.Close();
			return tbl_posDayStartAndEnd_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_posDayStartAndEnd_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_posDayStartAndEnd_Detail Maketbl_posDayStartAndEnd_Detail(SqlDataReader dataReader) {
			tbl_posDayStartAndEnd_Detail tbl_posDayStartAndEnd_Detail = new tbl_posDayStartAndEnd_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_posDayStartAndEnd_Detail.DayDetail_Index = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_posDayStartAndEnd_Detail.DayIndex = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_posDayStartAndEnd_Detail.PosDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_posDayStartAndEnd_Detail.PosTerminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_posDayStartAndEnd_Detail.SignInCashier_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_posDayStartAndEnd_Detail.SignInFloatAmt = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_posDayStartAndEnd_Detail.SignInotherAmt = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_posDayStartAndEnd_Detail.IsChecked = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_posDayStartAndEnd_Detail.IsApproved = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_posDayStartAndEnd_Detail.IsCanceled = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_posDayStartAndEnd_Detail.CreateUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_posDayStartAndEnd_Detail.ModifiedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_posDayStartAndEnd_Detail.CheckedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_posDayStartAndEnd_Detail.ApprovedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_posDayStartAndEnd_Detail.CanceledUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_posDayStartAndEnd_Detail.DateCreated = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_posDayStartAndEnd_Detail.DateModified = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_posDayStartAndEnd_Detail.DateChecked = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_posDayStartAndEnd_Detail.DateApproved = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_posDayStartAndEnd_Detail.DateCanceled = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_posDayStartAndEnd_Detail.DayEndCashAmt = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_posDayStartAndEnd_Detail.DayEndOtherAmt = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_posDayStartAndEnd_Detail.DayEndVarienceAmt = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_posDayStartAndEnd_Detail.IsMgtSignOffCreated = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_posDayStartAndEnd_Detail.IsMgtSignOffChecked = dataReader.GetBoolean(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_posDayStartAndEnd_Detail.IsMgtSignOffApproved = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_posDayStartAndEnd_Detail.IsMgtSignOffCanceled = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffCreateUser_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffModifiedUser_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffCheckedUser_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffApprovedUser_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffCanceledUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffCreateTime = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffModifiedTime = dataReader.GetDateTime(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffCheckedTime = dataReader.GetDateTime(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffApprovedTime = dataReader.GetDateTime(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_posDayStartAndEnd_Detail.MgtSignOffCanceledTime = dataReader.GetDateTime(36);
			}

			return tbl_posDayStartAndEnd_Detail;
		}
		/// <summary>
		/// This makes tbl_posDayStartAndEnd_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_posDayStartAndEnd_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_posDayStartAndEnd_Detail  tbl_posDayStartAndEnd_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_dayDetail_Index = new DataColumn("dayDetail_Index" , typeof(int));
			DataColumn col_dayIndex = new DataColumn("dayIndex" , typeof(int));
			DataColumn col_posDate = new DataColumn("posDate" , typeof(DateTime));
			DataColumn col_posTerminal_ID = new DataColumn("posTerminal_ID" , typeof(string));
			DataColumn col_signInCashier_ID = new DataColumn("signInCashier_ID" , typeof(string));
			DataColumn col_signInFloatAmt = new DataColumn("signInFloatAmt" , typeof(decimal));
			DataColumn col_signInotherAmt = new DataColumn("signInotherAmt" , typeof(decimal));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_canceledUser_ID = new DataColumn("canceledUser_ID" , typeof(string));
			DataColumn col_dateCreated = new DataColumn("dateCreated" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_dayEndCashAmt = new DataColumn("dayEndCashAmt" , typeof(decimal));
			DataColumn col_dayEndOtherAmt = new DataColumn("dayEndOtherAmt" , typeof(decimal));
			DataColumn col_dayEndVarienceAmt = new DataColumn("dayEndVarienceAmt" , typeof(decimal));
			DataColumn col_isMgtSignOffCreated = new DataColumn("isMgtSignOffCreated" , typeof(bool));
			DataColumn col_isMgtSignOffChecked = new DataColumn("isMgtSignOffChecked" , typeof(bool));
			DataColumn col_isMgtSignOffApproved = new DataColumn("isMgtSignOffApproved" , typeof(bool));
			DataColumn col_isMgtSignOffCanceled = new DataColumn("isMgtSignOffCanceled" , typeof(bool));
			DataColumn col_mgtSignOffCreateUser_ID = new DataColumn("mgtSignOffCreateUser_ID" , typeof(string));
			DataColumn col_mgtSignOffModifiedUser_ID = new DataColumn("mgtSignOffModifiedUser_ID" , typeof(string));
			DataColumn col_mgtSignOffCheckedUser_ID = new DataColumn("mgtSignOffCheckedUser_ID" , typeof(string));
			DataColumn col_mgtSignOffApprovedUser_ID = new DataColumn("mgtSignOffApprovedUser_ID" , typeof(string));
			DataColumn col_mgtSignOffCanceledUser_ID = new DataColumn("mgtSignOffCanceledUser_ID" , typeof(string));
			DataColumn col_mgtSignOffCreateTime = new DataColumn("mgtSignOffCreateTime" , typeof(DateTime));
			DataColumn col_mgtSignOffModifiedTime = new DataColumn("mgtSignOffModifiedTime" , typeof(DateTime));
			DataColumn col_mgtSignOffCheckedTime = new DataColumn("mgtSignOffCheckedTime" , typeof(DateTime));
			DataColumn col_mgtSignOffApprovedTime = new DataColumn("mgtSignOffApprovedTime" , typeof(DateTime));
			DataColumn col_mgtSignOffCanceledTime = new DataColumn("mgtSignOffCanceledTime" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_dayDetail_Index,col_dayIndex,col_posDate,col_posTerminal_ID,col_signInCashier_ID,col_signInFloatAmt,col_signInotherAmt,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceledUser_ID,col_dateCreated,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_dayEndCashAmt,col_dayEndOtherAmt,col_dayEndVarienceAmt,col_isMgtSignOffCreated,col_isMgtSignOffChecked,col_isMgtSignOffApproved,col_isMgtSignOffCanceled,col_mgtSignOffCreateUser_ID,col_mgtSignOffModifiedUser_ID,col_mgtSignOffCheckedUser_ID,col_mgtSignOffApprovedUser_ID,col_mgtSignOffCanceledUser_ID,col_mgtSignOffCreateTime,col_mgtSignOffModifiedTime,col_mgtSignOffCheckedTime,col_mgtSignOffApprovedTime,col_mgtSignOffCanceledTime,});		return dt;
		}
		/// <summary>
		/// This fills tbl_posDayStartAndEnd_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_posDayStartAndEnd_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_posDayStartAndEnd_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["dayDetail_Index"] = user.dayDetail_Index;
			drow["dayIndex"] = user.dayIndex;
			drow["posDate"] = user.posDate;
			drow["posTerminal_ID"] = user.posTerminal_ID;
			drow["signInCashier_ID"] = user.signInCashier_ID;
			drow["signInFloatAmt"] = user.signInFloatAmt;
			drow["signInotherAmt"] = user.signInotherAmt;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["canceledUser_ID"] = user.canceledUser_ID;
			drow["dateCreated"] = user.dateCreated;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateCanceled"] = user.dateCanceled;
			drow["dayEndCashAmt"] = user.dayEndCashAmt;
			drow["dayEndOtherAmt"] = user.dayEndOtherAmt;
			drow["dayEndVarienceAmt"] = user.dayEndVarienceAmt;
			drow["isMgtSignOffCreated"] = user.isMgtSignOffCreated;
			drow["isMgtSignOffChecked"] = user.isMgtSignOffChecked;
			drow["isMgtSignOffApproved"] = user.isMgtSignOffApproved;
			drow["isMgtSignOffCanceled"] = user.isMgtSignOffCanceled;
			drow["mgtSignOffCreateUser_ID"] = user.mgtSignOffCreateUser_ID;
			drow["mgtSignOffModifiedUser_ID"] = user.mgtSignOffModifiedUser_ID;
			drow["mgtSignOffCheckedUser_ID"] = user.mgtSignOffCheckedUser_ID;
			drow["mgtSignOffApprovedUser_ID"] = user.mgtSignOffApprovedUser_ID;
			drow["mgtSignOffCanceledUser_ID"] = user.mgtSignOffCanceledUser_ID;
			drow["mgtSignOffCreateTime"] = user.mgtSignOffCreateTime;
			drow["mgtSignOffModifiedTime"] = user.mgtSignOffModifiedTime;
			drow["mgtSignOffCheckedTime"] = user.mgtSignOffCheckedTime;
			drow["mgtSignOffApprovedTime"] = user.mgtSignOffApprovedTime;
			drow["mgtSignOffCanceledTime"] = user.mgtSignOffCanceledTime;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
