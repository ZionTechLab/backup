using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasJobRegister_ProductDetail {
		#region Fields
		private string job_ID;
		private bool artWork;
		private bool slHandle;
		private bool handleCut;
		private string polytheneType_ID;
		private string sealingType_ID;
		private string sealingMethod_ID;
		private string pouchType_ID;
		private string printingType_ID;
		private string printingMethod_ID;
		private string laminationType_ID;
		private string slittingType_ID;
		private string measureType_ID;
		private string treatnmentStatus_ID;
		private string handleType_ID;
		private string gussestType_ID;
		private decimal sealSize;
		private decimal gussestSize;
		private int noOfBlock;
		private int noOfColour;
		private string colours;
		private string remark;
		private byte[] image;
		private string instructionDetail;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasJobRegister_ProductDetail class.
		/// </summary>
		public tbl_sasJobRegister_ProductDetail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasJobRegister_ProductDetail class.
		/// </summary>
		public tbl_sasJobRegister_ProductDetail(string job_ID, bool artWork, bool slHandle, bool handleCut, string polytheneType_ID, string sealingType_ID, string sealingMethod_ID, string pouchType_ID, string printingType_ID, string printingMethod_ID, string laminationType_ID, string slittingType_ID, string measureType_ID, string treatnmentStatus_ID, string handleType_ID, string gussestType_ID, decimal sealSize, decimal gussestSize, int noOfBlock, int noOfColour, string colours, string remark, byte[] image, string instructionDetail) {
			this.job_ID = job_ID;
			this.artWork = artWork;
			this.slHandle = slHandle;
			this.handleCut = handleCut;
			this.polytheneType_ID = polytheneType_ID;
			this.sealingType_ID = sealingType_ID;
			this.sealingMethod_ID = sealingMethod_ID;
			this.pouchType_ID = pouchType_ID;
			this.printingType_ID = printingType_ID;
			this.printingMethod_ID = printingMethod_ID;
			this.laminationType_ID = laminationType_ID;
			this.slittingType_ID = slittingType_ID;
			this.measureType_ID = measureType_ID;
			this.treatnmentStatus_ID = treatnmentStatus_ID;
			this.handleType_ID = handleType_ID;
			this.gussestType_ID = gussestType_ID;
			this.sealSize = sealSize;
			this.gussestSize = gussestSize;
			this.noOfBlock = noOfBlock;
			this.noOfColour = noOfColour;
			this.colours = colours;
			this.remark = remark;
			this.image = image;
			this.instructionDetail = instructionDetail;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ArtWork value.
		/// </summary>
		public bool ArtWork {
			get { return artWork; }
			set { artWork = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlHandle value.
		/// </summary>
		public bool SlHandle {
			get { return slHandle; }
			set { slHandle = value; }
		}
		
		/// <summary>
		/// Gets or sets the HandleCut value.
		/// </summary>
		public bool HandleCut {
			get { return handleCut; }
			set { handleCut = value; }
		}
		
		/// <summary>
		/// Gets or sets the PolytheneType_ID value.
		/// </summary>
		public string PolytheneType_ID {
			get { return polytheneType_ID; }
			set { polytheneType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SealingType_ID value.
		/// </summary>
		public string SealingType_ID {
			get { return sealingType_ID; }
			set { sealingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SealingMethod_ID value.
		/// </summary>
		public string SealingMethod_ID {
			get { return sealingMethod_ID; }
			set { sealingMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PouchType_ID value.
		/// </summary>
		public string PouchType_ID {
			get { return pouchType_ID; }
			set { pouchType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintingType_ID value.
		/// </summary>
		public string PrintingType_ID {
			get { return printingType_ID; }
			set { printingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintingMethod_ID value.
		/// </summary>
		public string PrintingMethod_ID {
			get { return printingMethod_ID; }
			set { printingMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LaminationType_ID value.
		/// </summary>
		public string LaminationType_ID {
			get { return laminationType_ID; }
			set { laminationType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlittingType_ID value.
		/// </summary>
		public string SlittingType_ID {
			get { return slittingType_ID; }
			set { slittingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MeasureType_ID value.
		/// </summary>
		public string MeasureType_ID {
			get { return measureType_ID; }
			set { measureType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TreatnmentStatus_ID value.
		/// </summary>
		public string TreatnmentStatus_ID {
			get { return treatnmentStatus_ID; }
			set { treatnmentStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the HandleType_ID value.
		/// </summary>
		public string HandleType_ID {
			get { return handleType_ID; }
			set { handleType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GussestType_ID value.
		/// </summary>
		public string GussestType_ID {
			get { return gussestType_ID; }
			set { gussestType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SealSize value.
		/// </summary>
		public decimal SealSize {
			get { return sealSize; }
			set { sealSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the GussestSize value.
		/// </summary>
		public decimal GussestSize {
			get { return gussestSize; }
			set { gussestSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoOfBlock value.
		/// </summary>
		public int NoOfBlock {
			get { return noOfBlock; }
			set { noOfBlock = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoOfColour value.
		/// </summary>
		public int NoOfColour {
			get { return noOfColour; }
			set { noOfColour = value; }
		}
		
		/// <summary>
		/// Gets or sets the Colours value.
		/// </summary>
		public string Colours {
			get { return colours; }
			set { colours = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>
		/// Gets or sets the InstructionDetail value.
		/// </summary>
		public string InstructionDetail {
			get { return instructionDetail; }
			set { instructionDetail = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasJobRegister_ProductDetail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@artWork", SqlDbType.Bit,1);
			scom.Parameters.Add("@slHandle", SqlDbType.Bit,1);
			scom.Parameters.Add("@handleCut", SqlDbType.Bit,1);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gussestSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfBlock", SqlDbType.Int,4);
			scom.Parameters.Add("@noOfColour", SqlDbType.Int,4);
			scom.Parameters.Add("@colours", SqlDbType.VarChar,500);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@instructionDetail", SqlDbType.VarChar,200);
 
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@artWork"].Value = artWork;
			scom.Parameters["@slHandle"].Value = slHandle;
			scom.Parameters["@handleCut"].Value = handleCut;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID;
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID;
			scom.Parameters["@printingType_ID"].Value = printingType_ID;
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID;
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID;
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID;
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID;
			scom.Parameters["@handleType_ID"].Value = handleType_ID;
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID;
			scom.Parameters["@sealSize"].Value = sealSize;
			scom.Parameters["@gussestSize"].Value = gussestSize;
			scom.Parameters["@noOfBlock"].Value = noOfBlock;
			scom.Parameters["@noOfColour"].Value = noOfColour;
			scom.Parameters["@colours"].Value = colours;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@instructionDetail"].Value = instructionDetail;
 

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasJobRegister_ProductDetail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@artWork", SqlDbType.Bit,1);
			scom.Parameters.Add("@slHandle", SqlDbType.Bit,1);
			scom.Parameters.Add("@handleCut", SqlDbType.Bit,1);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gussestSize", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfBlock", SqlDbType.Int,4);
			scom.Parameters.Add("@noOfColour", SqlDbType.Int,4);
			scom.Parameters.Add("@colours", SqlDbType.VarChar,500);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@instructionDetail", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@artWork"].Value = artWork;
			scom.Parameters["@slHandle"].Value = slHandle;
			scom.Parameters["@handleCut"].Value = handleCut;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID;
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID;
			scom.Parameters["@printingType_ID"].Value = printingType_ID;
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID;
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID;
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID;
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID;
			scom.Parameters["@handleType_ID"].Value = handleType_ID;
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID;
			scom.Parameters["@sealSize"].Value = sealSize;
			scom.Parameters["@gussestSize"].Value = gussestSize;
			scom.Parameters["@noOfBlock"].Value = noOfBlock;
			scom.Parameters["@noOfColour"].Value = noOfColour;
			scom.Parameters["@colours"].Value = colours;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@instructionDetail"].Value = instructionDetail;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasJobRegister_ProductDetail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByLaminationType_ID(string laminationType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByLaminationType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByHandleType_ID(string handleType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByHandleType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@handleType_ID"].Value = handleType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPolytheneType_ID(string polytheneType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByPolytheneType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMeasureType_ID(string measureType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByMeasureType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySealingType_ID(string sealingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllBySealingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySealingMethod_ID(string sealingMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllBySealingMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrintingMethod_ID(string printingMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByPrintingMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByTreatnmentStatus_ID(string treatnmentStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByTreatnmentStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySlittingType_ID(string slittingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllBySlittingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGussestType_ID(string gussestType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByGussestType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPouchType_ID(string pouchType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByPouchType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrintingType_ID(string printingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByPrintingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingType_ID"].Value = printingType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasJobRegister_ProductDetail table.
		/// </summary>
		public static tbl_sasJobRegister_ProductDetail Select(string job_ID_Incoming){

			tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetailins = new tbl_sasJobRegister_ProductDetail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetailins = Maketbl_sasJobRegister_ProductDetail(dataReader);
				} else {
					tbl_sasJobRegister_ProductDetailins = null;
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByLaminationType_ID(string laminationType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByLaminationType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@laminationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationType_ID"].Value = laminationType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByHandleType_ID(string handleType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByHandleType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@handleType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@handleType_ID"].Value = handleType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByPolytheneType_ID(string polytheneType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByPolytheneType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByMeasureType_ID(string measureType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByMeasureType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllBySealingType_ID(string sealingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllBySealingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllBySealingMethod_ID(string sealingMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllBySealingMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingMethod_ID"].Value = sealingMethod_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByPrintingMethod_ID(string printingMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByPrintingMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printingMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingMethod_ID"].Value = printingMethod_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByTreatnmentStatus_ID(string treatnmentStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByTreatnmentStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllBySlittingType_ID(string slittingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllBySlittingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slittingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slittingType_ID"].Value = slittingType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByGussestType_ID(string gussestType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByGussestType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gussestType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gussestType_ID"].Value = gussestType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByPouchType_ID(string pouchType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByPouchType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pouchType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pouchType_ID"].Value = pouchType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByPrintingType_ID(string printingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByPrintingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printingType_ID"].Value = printingType_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_ProductDetail table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_ProductDetail> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_ProductDetailSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_sasJobRegister_ProductDetail> tbl_sasJobRegister_ProductDetailList = new List<tbl_sasJobRegister_ProductDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = Maketbl_sasJobRegister_ProductDetail(dataReader);
					tbl_sasJobRegister_ProductDetailList.Add(tbl_sasJobRegister_ProductDetail);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_ProductDetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasJobRegister_ProductDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasJobRegister_ProductDetail Maketbl_sasJobRegister_ProductDetail(SqlDataReader dataReader) {
			tbl_sasJobRegister_ProductDetail tbl_sasJobRegister_ProductDetail = new tbl_sasJobRegister_ProductDetail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasJobRegister_ProductDetail.Job_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasJobRegister_ProductDetail.ArtWork = dataReader.GetBoolean(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasJobRegister_ProductDetail.SlHandle = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasJobRegister_ProductDetail.HandleCut = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasJobRegister_ProductDetail.PolytheneType_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasJobRegister_ProductDetail.SealingType_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasJobRegister_ProductDetail.SealingMethod_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasJobRegister_ProductDetail.PouchType_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasJobRegister_ProductDetail.PrintingType_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasJobRegister_ProductDetail.PrintingMethod_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasJobRegister_ProductDetail.LaminationType_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasJobRegister_ProductDetail.SlittingType_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasJobRegister_ProductDetail.MeasureType_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasJobRegister_ProductDetail.TreatnmentStatus_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasJobRegister_ProductDetail.HandleType_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasJobRegister_ProductDetail.GussestType_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasJobRegister_ProductDetail.SealSize = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasJobRegister_ProductDetail.GussestSize = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasJobRegister_ProductDetail.NoOfBlock = dataReader.GetInt32(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasJobRegister_ProductDetail.NoOfColour = dataReader.GetInt32(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasJobRegister_ProductDetail.Colours = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasJobRegister_ProductDetail.Remark = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
                tbl_sasJobRegister_ProductDetail.Image = (byte[])dataReader[22]; 
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasJobRegister_ProductDetail.InstructionDetail = dataReader.GetString(23);
			}

			return tbl_sasJobRegister_ProductDetail;
		}
		/// <summary>
		/// This makes tbl_sasJobRegister_ProductDetail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasJobRegister_ProductDetail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasJobRegister_ProductDetail  tbl_sasJobRegister_ProductDetail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_artWork = new DataColumn("artWork" , typeof(bool));
			DataColumn col_slHandle = new DataColumn("slHandle" , typeof(bool));
			DataColumn col_handleCut = new DataColumn("handleCut" , typeof(bool));
			DataColumn col_polytheneType_ID = new DataColumn("polytheneType_ID" , typeof(string));
			DataColumn col_sealingType_ID = new DataColumn("sealingType_ID" , typeof(string));
			DataColumn col_sealingMethod_ID = new DataColumn("sealingMethod_ID" , typeof(string));
			DataColumn col_pouchType_ID = new DataColumn("pouchType_ID" , typeof(string));
			DataColumn col_printingType_ID = new DataColumn("printingType_ID" , typeof(string));
			DataColumn col_printingMethod_ID = new DataColumn("printingMethod_ID" , typeof(string));
			DataColumn col_laminationType_ID = new DataColumn("laminationType_ID" , typeof(string));
			DataColumn col_slittingType_ID = new DataColumn("slittingType_ID" , typeof(string));
			DataColumn col_measureType_ID = new DataColumn("measureType_ID" , typeof(string));
			DataColumn col_treatnmentStatus_ID = new DataColumn("treatnmentStatus_ID" , typeof(string));
			DataColumn col_handleType_ID = new DataColumn("handleType_ID" , typeof(string));
			DataColumn col_gussestType_ID = new DataColumn("gussestType_ID" , typeof(string));
			DataColumn col_sealSize = new DataColumn("sealSize" , typeof(decimal));
			DataColumn col_gussestSize = new DataColumn("gussestSize" , typeof(decimal));
			DataColumn col_noOfBlock = new DataColumn("noOfBlock" , typeof(int));
			DataColumn col_noOfColour = new DataColumn("noOfColour" , typeof(int));
			DataColumn col_colours = new DataColumn("colours" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
			DataColumn col_instructionDetail = new DataColumn("instructionDetail" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_job_ID,col_artWork,col_slHandle,col_handleCut,col_polytheneType_ID,col_sealingType_ID,col_sealingMethod_ID,col_pouchType_ID,col_printingType_ID,col_printingMethod_ID,col_laminationType_ID,col_slittingType_ID,col_measureType_ID,col_treatnmentStatus_ID,col_handleType_ID,col_gussestType_ID,col_sealSize,col_gussestSize,col_noOfBlock,col_noOfColour,col_colours,col_remark,col_image,col_instructionDetail,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasJobRegister_ProductDetail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasJobRegister_ProductDetail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasJobRegister_ProductDetail user) {
		DataRow drow = dt.NewRow();
		
			drow["job_ID"] = user.job_ID;
			drow["artWork"] = user.artWork;
			drow["slHandle"] = user.slHandle;
			drow["handleCut"] = user.handleCut;
			drow["polytheneType_ID"] = user.polytheneType_ID;
			drow["sealingType_ID"] = user.sealingType_ID;
			drow["sealingMethod_ID"] = user.sealingMethod_ID;
			drow["pouchType_ID"] = user.pouchType_ID;
			drow["printingType_ID"] = user.printingType_ID;
			drow["printingMethod_ID"] = user.printingMethod_ID;
			drow["laminationType_ID"] = user.laminationType_ID;
			drow["slittingType_ID"] = user.slittingType_ID;
			drow["measureType_ID"] = user.measureType_ID;
			drow["treatnmentStatus_ID"] = user.treatnmentStatus_ID;
			drow["handleType_ID"] = user.handleType_ID;
			drow["gussestType_ID"] = user.gussestType_ID;
			drow["sealSize"] = user.sealSize;
			drow["gussestSize"] = user.gussestSize;
			drow["noOfBlock"] = user.noOfBlock;
			drow["noOfColour"] = user.noOfColour;
			drow["colours"] = user.colours;
			drow["remark"] = user.remark;
			drow["image"] = user.image;
			drow["instructionDetail"] = user.instructionDetail;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
