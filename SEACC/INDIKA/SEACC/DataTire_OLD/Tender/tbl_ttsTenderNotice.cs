using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderNotice {
		#region Fields
		private string tender_ID;
		private string bidReference_No1;
		private string bidReference_No2;
		private string sponsor_ID;
		private string noticeSource_ID;
		private string description;
		private DateTime noticeDate;
		private DateTime docCollectionDate;
		private DateTime docClosingDate;
		private string customer_ID;
		private string contact_Name;
		private string contact_Designation;
		private string email;
		private string phone;
		private string mobile;
		private string address1;
		private string address2;
		private string address3;
		private string country_ID;
		private string city_ID;
		private string town_ID;
		private DateTime preBidMeetingDate;
		private string preBidMeetingAddress1;
		private string preBidMeetingAddress2;
		private string preBidMeetingCountry_ID;
		private string preBidMeetingCity_ID;
		private string preBidMeetingTown_ID;
		private bool isCanceled;
		private bool isApplicationCollected;
		private int documentListStatus;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderNotice class.
		/// </summary>
		public tbl_ttsTenderNotice() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderNotice class.
		/// </summary>
		public tbl_ttsTenderNotice(string tender_ID, string bidReference_No1, string bidReference_No2, string sponsor_ID, string noticeSource_ID, string description, DateTime noticeDate, DateTime docCollectionDate, DateTime docClosingDate, string customer_ID, string contact_Name, string contact_Designation, string email, string phone, string mobile, string address1, string address2, string address3, string country_ID, string city_ID, string town_ID, DateTime preBidMeetingDate, string preBidMeetingAddress1, string preBidMeetingAddress2, string preBidMeetingCountry_ID, string preBidMeetingCity_ID, string preBidMeetingTown_ID, bool isCanceled, bool isApplicationCollected, int documentListStatus) {
			this.tender_ID = tender_ID;
			this.bidReference_No1 = bidReference_No1;
			this.bidReference_No2 = bidReference_No2;
			this.sponsor_ID = sponsor_ID;
			this.noticeSource_ID = noticeSource_ID;
			this.description = description;
			this.noticeDate = noticeDate;
			this.docCollectionDate = docCollectionDate;
			this.docClosingDate = docClosingDate;
			this.customer_ID = customer_ID;
			this.contact_Name = contact_Name;
			this.contact_Designation = contact_Designation;
			this.email = email;
			this.phone = phone;
			this.mobile = mobile;
			this.address1 = address1;
			this.address2 = address2;
			this.address3 = address3;
			this.country_ID = country_ID;
			this.city_ID = city_ID;
			this.town_ID = town_ID;
			this.preBidMeetingDate = preBidMeetingDate;
			this.preBidMeetingAddress1 = preBidMeetingAddress1;
			this.preBidMeetingAddress2 = preBidMeetingAddress2;
			this.preBidMeetingCountry_ID = preBidMeetingCountry_ID;
			this.preBidMeetingCity_ID = preBidMeetingCity_ID;
			this.preBidMeetingTown_ID = preBidMeetingTown_ID;
			this.isCanceled = isCanceled;
			this.isApplicationCollected = isApplicationCollected;
			this.documentListStatus = documentListStatus;
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
		/// Gets or sets the BidReference_No1 value.
		/// </summary>
		public string BidReference_No1 {
			get { return bidReference_No1; }
			set { bidReference_No1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the BidReference_No2 value.
		/// </summary>
		public string BidReference_No2 {
			get { return bidReference_No2; }
			set { bidReference_No2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Sponsor_ID value.
		/// </summary>
		public string Sponsor_ID {
			get { return sponsor_ID; }
			set { sponsor_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoticeSource_ID value.
		/// </summary>
		public string NoticeSource_ID {
			get { return noticeSource_ID; }
			set { noticeSource_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoticeDate value.
		/// </summary>
		public DateTime NoticeDate {
			get { return noticeDate; }
			set { noticeDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DocCollectionDate value.
		/// </summary>
		public DateTime DocCollectionDate {
			get { return docCollectionDate; }
			set { docCollectionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DocClosingDate value.
		/// </summary>
		public DateTime DocClosingDate {
			get { return docClosingDate; }
			set { docClosingDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Contact_Name value.
		/// </summary>
		public string Contact_Name {
			get { return contact_Name; }
			set { contact_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Contact_Designation value.
		/// </summary>
		public string Contact_Designation {
			get { return contact_Designation; }
			set { contact_Designation = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email {
			get { return email; }
			set { email = value; }
		}
		
		/// <summary>
		/// Gets or sets the Phone value.
		/// </summary>
		public string Phone {
			get { return phone; }
			set { phone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mobile value.
		/// </summary>
		public string Mobile {
			get { return mobile; }
			set { mobile = value; }
		}
		
		/// <summary>
		/// Gets or sets the Address1 value.
		/// </summary>
		public string Address1 {
			get { return address1; }
			set { address1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Address2 value.
		/// </summary>
		public string Address2 {
			get { return address2; }
			set { address2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Address3 value.
		/// </summary>
		public string Address3 {
			get { return address3; }
			set { address3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the City_ID value.
		/// </summary>
		public string City_ID {
			get { return city_ID; }
			set { city_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Town_ID value.
		/// </summary>
		public string Town_ID {
			get { return town_ID; }
			set { town_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeetingDate value.
		/// </summary>
		public DateTime PreBidMeetingDate {
			get { return preBidMeetingDate; }
			set { preBidMeetingDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeetingAddress1 value.
		/// </summary>
		public string PreBidMeetingAddress1 {
			get { return preBidMeetingAddress1; }
			set { preBidMeetingAddress1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeetingAddress2 value.
		/// </summary>
		public string PreBidMeetingAddress2 {
			get { return preBidMeetingAddress2; }
			set { preBidMeetingAddress2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeetingCountry_ID value.
		/// </summary>
		public string PreBidMeetingCountry_ID {
			get { return preBidMeetingCountry_ID; }
			set { preBidMeetingCountry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeetingCity_ID value.
		/// </summary>
		public string PreBidMeetingCity_ID {
			get { return preBidMeetingCity_ID; }
			set { preBidMeetingCity_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeetingTown_ID value.
		/// </summary>
		public string PreBidMeetingTown_ID {
			get { return preBidMeetingTown_ID; }
			set { preBidMeetingTown_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApplicationCollected value.
		/// </summary>
		public bool IsApplicationCollected {
			get { return isApplicationCollected; }
			set { isApplicationCollected = value; }
		}
		
		/// <summary>
		/// Gets or sets the DocumentListStatus value.
		/// </summary>
		public int DocumentListStatus {
			get { return documentListStatus; }
			set { documentListStatus = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderNotice table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bidReference_No1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bidReference_No2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@noticeSource_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
			scom.Parameters.Add("@noticeDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@docCollectionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@docClosingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@contact_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contact_Designation", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@phone", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,20);
			scom.Parameters.Add("@address1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeetingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@preBidMeetingAddress1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeetingAddress2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeetingCountry_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeetingCity_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeetingTown_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApplicationCollected", SqlDbType.Bit,1);
			scom.Parameters.Add("@documentListStatus", SqlDbType.Int,4);
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@bidReference_No1"].Value = bidReference_No1;
			scom.Parameters["@bidReference_No2"].Value = bidReference_No2;
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID;
			scom.Parameters["@noticeSource_ID"].Value = noticeSource_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@noticeDate"].Value = noticeDate;
			scom.Parameters["@docCollectionDate"].Value = docCollectionDate;
			scom.Parameters["@docClosingDate"].Value = docClosingDate;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@contact_Name"].Value = contact_Name;
			scom.Parameters["@contact_Designation"].Value = contact_Designation;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@phone"].Value = phone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@address1"].Value = address1;
			scom.Parameters["@address2"].Value = address2;
			scom.Parameters["@address3"].Value = address3;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@preBidMeetingDate"].Value = preBidMeetingDate;
			scom.Parameters["@preBidMeetingAddress1"].Value = preBidMeetingAddress1;
			scom.Parameters["@preBidMeetingAddress2"].Value = preBidMeetingAddress2;
			scom.Parameters["@preBidMeetingCountry_ID"].Value = preBidMeetingCountry_ID;
			scom.Parameters["@preBidMeetingCity_ID"].Value = preBidMeetingCity_ID;
			scom.Parameters["@preBidMeetingTown_ID"].Value = preBidMeetingTown_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isApplicationCollected"].Value = isApplicationCollected;
			scom.Parameters["@documentListStatus"].Value = documentListStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderNotice table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bidReference_No1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@bidReference_No2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@noticeSource_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
			scom.Parameters.Add("@noticeDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@docCollectionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@docClosingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@contact_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contact_Designation", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@phone", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,20);
			scom.Parameters.Add("@address1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeetingDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@preBidMeetingAddress1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeetingAddress2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeetingCountry_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeetingCity_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeetingTown_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApplicationCollected", SqlDbType.Bit,1);
			scom.Parameters.Add("@documentListStatus", SqlDbType.Int,4);
 
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@bidReference_No1"].Value = bidReference_No1;
			scom.Parameters["@bidReference_No2"].Value = bidReference_No2;
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID;
			scom.Parameters["@noticeSource_ID"].Value = noticeSource_ID;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@noticeDate"].Value = noticeDate;
			scom.Parameters["@docCollectionDate"].Value = docCollectionDate;
			scom.Parameters["@docClosingDate"].Value = docClosingDate;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@contact_Name"].Value = contact_Name;
			scom.Parameters["@contact_Designation"].Value = contact_Designation;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@phone"].Value = phone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@address1"].Value = address1;
			scom.Parameters["@address2"].Value = address2;
			scom.Parameters["@address3"].Value = address3;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@preBidMeetingDate"].Value = preBidMeetingDate;
			scom.Parameters["@preBidMeetingAddress1"].Value = preBidMeetingAddress1;
			scom.Parameters["@preBidMeetingAddress2"].Value = preBidMeetingAddress2;
			scom.Parameters["@preBidMeetingCountry_ID"].Value = preBidMeetingCountry_ID;
			scom.Parameters["@preBidMeetingCity_ID"].Value = preBidMeetingCity_ID;
			scom.Parameters["@preBidMeetingTown_ID"].Value = preBidMeetingTown_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isApplicationCollected"].Value = isApplicationCollected;
			scom.Parameters["@documentListStatus"].Value = documentListStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderNotice table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllByPreBidMeetingTown_ID(string preBidMeetingTown_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllByPreBidMeetingTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeetingTown_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeetingTown_ID"].Value = preBidMeetingTown_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllByPreBidMeetingCountry_ID(string preBidMeetingCountry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllByPreBidMeetingCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeetingCountry_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeetingCountry_ID"].Value = preBidMeetingCountry_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllBySponsor_ID(string sponsor_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllBySponsor_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,8);
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllByPreBidMeetingCity_ID(string preBidMeetingCity_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllByPreBidMeetingCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeetingCity_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeetingCity_ID"].Value = preBidMeetingCity_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static void DeleteAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeDeleteAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderNotice table.
		/// </summary>
		public static tbl_ttsTenderNotice Select(string tender_ID_Incoming){

			tbl_ttsTenderNotice tbl_ttsTenderNoticeins = new tbl_ttsTenderNotice();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderNoticeins = Maketbl_ttsTenderNotice(dataReader);
				} else {
					tbl_ttsTenderNoticeins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllByPreBidMeetingTown_ID(string preBidMeetingTown_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllByPreBidMeetingTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeetingTown_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeetingTown_ID"].Value = preBidMeetingTown_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllByPreBidMeetingCountry_ID(string preBidMeetingCountry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllByPreBidMeetingCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeetingCountry_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeetingCountry_ID"].Value = preBidMeetingCountry_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllBySponsor_ID(string sponsor_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllBySponsor_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sponsor_ID", SqlDbType.VarChar,8);
			scom.Parameters["@sponsor_ID"].Value = sponsor_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllByPreBidMeetingCity_ID(string preBidMeetingCity_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllByPreBidMeetingCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeetingCity_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeetingCity_ID"].Value = preBidMeetingCity_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderNotice table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderNotice> SelectAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderNoticeSelectAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
				List<tbl_ttsTenderNotice> tbl_ttsTenderNoticeList = new List<tbl_ttsTenderNotice>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderNotice tbl_ttsTenderNotice = Maketbl_ttsTenderNotice(dataReader);
					tbl_ttsTenderNoticeList.Add(tbl_ttsTenderNotice);
				}
			}
			scon.Close();
			return tbl_ttsTenderNoticeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderNotice class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderNotice Maketbl_ttsTenderNotice(SqlDataReader dataReader) {
			tbl_ttsTenderNotice tbl_ttsTenderNotice = new tbl_ttsTenderNotice();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderNotice.Tender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderNotice.BidReference_No1 = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderNotice.BidReference_No2 = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderNotice.Sponsor_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderNotice.NoticeSource_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsTenderNotice.Description = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsTenderNotice.NoticeDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ttsTenderNotice.DocCollectionDate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ttsTenderNotice.DocClosingDate = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ttsTenderNotice.Customer_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ttsTenderNotice.Contact_Name = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_ttsTenderNotice.Contact_Designation = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_ttsTenderNotice.Email = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_ttsTenderNotice.Phone = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_ttsTenderNotice.Mobile = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_ttsTenderNotice.Address1 = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_ttsTenderNotice.Address2 = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_ttsTenderNotice.Address3 = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_ttsTenderNotice.Country_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_ttsTenderNotice.City_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_ttsTenderNotice.Town_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_ttsTenderNotice.PreBidMeetingDate = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_ttsTenderNotice.PreBidMeetingAddress1 = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_ttsTenderNotice.PreBidMeetingAddress2 = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_ttsTenderNotice.PreBidMeetingCountry_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_ttsTenderNotice.PreBidMeetingCity_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_ttsTenderNotice.PreBidMeetingTown_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_ttsTenderNotice.IsCanceled = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_ttsTenderNotice.IsApplicationCollected = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_ttsTenderNotice.DocumentListStatus = dataReader.GetInt32(29);
			}

			return tbl_ttsTenderNotice;
		}
		/// <summary>
		/// This makes tbl_ttsTenderNotice datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderNotice object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderNotice  tbl_ttsTenderNotice   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_bidReference_No1 = new DataColumn("bidReference_No1" , typeof(string));
			DataColumn col_bidReference_No2 = new DataColumn("bidReference_No2" , typeof(string));
			DataColumn col_sponsor_ID = new DataColumn("sponsor_ID" , typeof(string));
			DataColumn col_noticeSource_ID = new DataColumn("noticeSource_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_noticeDate = new DataColumn("noticeDate" , typeof(DateTime));
			DataColumn col_docCollectionDate = new DataColumn("docCollectionDate" , typeof(DateTime));
			DataColumn col_docClosingDate = new DataColumn("docClosingDate" , typeof(DateTime));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_contact_Name = new DataColumn("contact_Name" , typeof(string));
			DataColumn col_contact_Designation = new DataColumn("contact_Designation" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_phone = new DataColumn("phone" , typeof(string));
			DataColumn col_mobile = new DataColumn("mobile" , typeof(string));
			DataColumn col_address1 = new DataColumn("address1" , typeof(string));
			DataColumn col_address2 = new DataColumn("address2" , typeof(string));
			DataColumn col_address3 = new DataColumn("address3" , typeof(string));
			DataColumn col_country_ID = new DataColumn("country_ID" , typeof(string));
			DataColumn col_city_ID = new DataColumn("city_ID" , typeof(string));
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
			DataColumn col_preBidMeetingDate = new DataColumn("preBidMeetingDate" , typeof(DateTime));
			DataColumn col_preBidMeetingAddress1 = new DataColumn("preBidMeetingAddress1" , typeof(string));
			DataColumn col_preBidMeetingAddress2 = new DataColumn("preBidMeetingAddress2" , typeof(string));
			DataColumn col_preBidMeetingCountry_ID = new DataColumn("preBidMeetingCountry_ID" , typeof(string));
			DataColumn col_preBidMeetingCity_ID = new DataColumn("preBidMeetingCity_ID" , typeof(string));
			DataColumn col_preBidMeetingTown_ID = new DataColumn("preBidMeetingTown_ID" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_isApplicationCollected = new DataColumn("isApplicationCollected" , typeof(bool));
			DataColumn col_documentListStatus = new DataColumn("documentListStatus" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_tender_ID,col_bidReference_No1,col_bidReference_No2,col_sponsor_ID,col_noticeSource_ID,col_description,col_noticeDate,col_docCollectionDate,col_docClosingDate,col_customer_ID,col_contact_Name,col_contact_Designation,col_email,col_phone,col_mobile,col_address1,col_address2,col_address3,col_country_ID,col_city_ID,col_town_ID,col_preBidMeetingDate,col_preBidMeetingAddress1,col_preBidMeetingAddress2,col_preBidMeetingCountry_ID,col_preBidMeetingCity_ID,col_preBidMeetingTown_ID,col_isCanceled,col_isApplicationCollected,col_documentListStatus,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderNotice datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderNotice object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderNotice user) {
		DataRow drow = dt.NewRow();
		
			drow["tender_ID"] = user.tender_ID;
			drow["bidReference_No1"] = user.bidReference_No1;
			drow["bidReference_No2"] = user.bidReference_No2;
			drow["sponsor_ID"] = user.sponsor_ID;
			drow["noticeSource_ID"] = user.noticeSource_ID;
			drow["description"] = user.description;
			drow["noticeDate"] = user.noticeDate;
			drow["docCollectionDate"] = user.docCollectionDate;
			drow["docClosingDate"] = user.docClosingDate;
			drow["customer_ID"] = user.customer_ID;
			drow["contact_Name"] = user.contact_Name;
			drow["contact_Designation"] = user.contact_Designation;
			drow["email"] = user.email;
			drow["phone"] = user.phone;
			drow["mobile"] = user.mobile;
			drow["address1"] = user.address1;
			drow["address2"] = user.address2;
			drow["address3"] = user.address3;
			drow["country_ID"] = user.country_ID;
			drow["city_ID"] = user.city_ID;
			drow["town_ID"] = user.town_ID;
			drow["preBidMeetingDate"] = user.preBidMeetingDate;
			drow["preBidMeetingAddress1"] = user.preBidMeetingAddress1;
			drow["preBidMeetingAddress2"] = user.preBidMeetingAddress2;
			drow["preBidMeetingCountry_ID"] = user.preBidMeetingCountry_ID;
			drow["preBidMeetingCity_ID"] = user.preBidMeetingCity_ID;
			drow["preBidMeetingTown_ID"] = user.preBidMeetingTown_ID;
			drow["isCanceled"] = user.isCanceled;
			drow["isApplicationCollected"] = user.isApplicationCollected;
			drow["documentListStatus"] = user.documentListStatus;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
