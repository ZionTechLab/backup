using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasJobRegister_Material {
		#region Fields
		private int line_No;
		private string job_ID;
		private string laminationMaterailType_ID;
		private string polytheneMaterailType_ID;
		private bool isLamination;
		private bool isPolythine;
		private decimal width;
		private decimal thickness;
		private decimal filmWidth;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasJobRegister_Material class.
		/// </summary>
		public tbl_sasJobRegister_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasJobRegister_Material class.
		/// </summary>
		public tbl_sasJobRegister_Material(int line_No, string job_ID, string laminationMaterailType_ID, string polytheneMaterailType_ID, bool isLamination, bool isPolythine, decimal width, decimal thickness, decimal filmWidth) {
			this.line_No = line_No;
			this.job_ID = job_ID;
			this.laminationMaterailType_ID = laminationMaterailType_ID;
			this.polytheneMaterailType_ID = polytheneMaterailType_ID;
			this.isLamination = isLamination;
			this.isPolythine = isPolythine;
			this.width = width;
			this.thickness = thickness;
			this.filmWidth = filmWidth;
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
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LaminationMaterailType_ID value.
		/// </summary>
		public string LaminationMaterailType_ID {
			get { return laminationMaterailType_ID; }
			set { laminationMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PolytheneMaterailType_ID value.
		/// </summary>
		public string PolytheneMaterailType_ID {
			get { return polytheneMaterailType_ID; }
			set { polytheneMaterailType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLamination value.
		/// </summary>
		public bool IsLamination {
			get { return isLamination; }
			set { isLamination = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPolythine value.
		/// </summary>
		public bool IsPolythine {
			get { return isPolythine; }
			set { isPolythine = value; }
		}
		
		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public decimal Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Thickness value.
		/// </summary>
		public decimal Thickness {
			get { return thickness; }
			set { thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the FilmWidth value.
		/// </summary>
		public decimal FilmWidth {
			get { return filmWidth; }
			set { filmWidth = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasJobRegister_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isLamination", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPolythine", SqlDbType.Bit,1);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@filmWidth", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
			scom.Parameters["@isLamination"].Value = isLamination;
			scom.Parameters["@isPolythine"].Value = isPolythine;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@filmWidth"].Value = filmWidth;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasJobRegister_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isLamination", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPolythine", SqlDbType.Bit,1);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@filmWidth", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
			scom.Parameters["@isLamination"].Value = isLamination;
			scom.Parameters["@isPolythine"].Value = isPolythine;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@filmWidth"].Value = filmWidth;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasJobRegister_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
 
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByPolytheneMaterailType_ID(string polytheneMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialDeleteAllByPolytheneMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByLaminationMaterailType_ID(string laminationMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialDeleteAllByLaminationMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasJobRegister_Material table.
		/// </summary>
		public static tbl_sasJobRegister_Material Select(int line_No_Incoming, string job_ID_Incoming, string laminationMaterailType_ID_Incoming, string polytheneMaterailType_ID_Incoming){

			tbl_sasJobRegister_Material tbl_sasJobRegister_Materialins = new tbl_sasJobRegister_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID_Incoming;
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasJobRegister_Materialins = Maketbl_sasJobRegister_Material(dataReader);
				} else {
					tbl_sasJobRegister_Materialins = null;
				}
			}
			scon.Close();
			return tbl_sasJobRegister_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_Material table.
		/// </summary>
		public static List<tbl_sasJobRegister_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasJobRegister_Material> tbl_sasJobRegister_MaterialList = new List<tbl_sasJobRegister_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_Material tbl_sasJobRegister_Material = Maketbl_sasJobRegister_Material(dataReader);
					tbl_sasJobRegister_MaterialList.Add(tbl_sasJobRegister_Material);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_Material table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_Material> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_sasJobRegister_Material> tbl_sasJobRegister_MaterialList = new List<tbl_sasJobRegister_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_Material tbl_sasJobRegister_Material = Maketbl_sasJobRegister_Material(dataReader);
					tbl_sasJobRegister_MaterialList.Add(tbl_sasJobRegister_Material);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_Material table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_Material> SelectAllByPolytheneMaterailType_ID(string polytheneMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialSelectAllByPolytheneMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneMaterailType_ID"].Value = polytheneMaterailType_ID;
				List<tbl_sasJobRegister_Material> tbl_sasJobRegister_MaterialList = new List<tbl_sasJobRegister_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_Material tbl_sasJobRegister_Material = Maketbl_sasJobRegister_Material(dataReader);
					tbl_sasJobRegister_MaterialList.Add(tbl_sasJobRegister_Material);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister_Material table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister_Material> SelectAllByLaminationMaterailType_ID(string laminationMaterailType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegister_MaterialSelectAllByLaminationMaterailType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@laminationMaterailType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@laminationMaterailType_ID"].Value = laminationMaterailType_ID;
				List<tbl_sasJobRegister_Material> tbl_sasJobRegister_MaterialList = new List<tbl_sasJobRegister_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister_Material tbl_sasJobRegister_Material = Maketbl_sasJobRegister_Material(dataReader);
					tbl_sasJobRegister_MaterialList.Add(tbl_sasJobRegister_Material);
				}
			}
			scon.Close();
			return tbl_sasJobRegister_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasJobRegister_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasJobRegister_Material Maketbl_sasJobRegister_Material(SqlDataReader dataReader) {
			tbl_sasJobRegister_Material tbl_sasJobRegister_Material = new tbl_sasJobRegister_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasJobRegister_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasJobRegister_Material.Job_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasJobRegister_Material.LaminationMaterailType_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasJobRegister_Material.PolytheneMaterailType_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasJobRegister_Material.IsLamination = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasJobRegister_Material.IsPolythine = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasJobRegister_Material.Width = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasJobRegister_Material.Thickness = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasJobRegister_Material.FilmWidth = dataReader.GetDecimal(8);
			}

			return tbl_sasJobRegister_Material;
		}
		/// <summary>
		/// This makes tbl_sasJobRegister_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasJobRegister_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasJobRegister_Material  tbl_sasJobRegister_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_laminationMaterailType_ID = new DataColumn("laminationMaterailType_ID" , typeof(string));
			DataColumn col_polytheneMaterailType_ID = new DataColumn("polytheneMaterailType_ID" , typeof(string));
			DataColumn col_isLamination = new DataColumn("isLamination" , typeof(bool));
			DataColumn col_isPolythine = new DataColumn("isPolythine" , typeof(bool));
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_thickness = new DataColumn("thickness" , typeof(decimal));
			DataColumn col_filmWidth = new DataColumn("filmWidth" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_job_ID,col_laminationMaterailType_ID,col_polytheneMaterailType_ID,col_isLamination,col_isPolythine,col_width,col_thickness,col_filmWidth,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasJobRegister_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasJobRegister_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasJobRegister_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["job_ID"] = user.job_ID;
			drow["laminationMaterailType_ID"] = user.laminationMaterailType_ID;
			drow["polytheneMaterailType_ID"] = user.polytheneMaterailType_ID;
			drow["isLamination"] = user.isLamination;
			drow["isPolythine"] = user.isPolythine;
			drow["width"] = user.width;
			drow["thickness"] = user.thickness;
			drow["filmWidth"] = user.filmWidth;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
