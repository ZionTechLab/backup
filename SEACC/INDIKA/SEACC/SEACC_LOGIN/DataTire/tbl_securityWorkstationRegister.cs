using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_LOGIN.DataTire
{
	public sealed class tbl_securityWorkstationRegister
	{
		#region Fields
		private int workstation_ID;
		private string terminal_ID;
		private string companyID;
		private string companyBranch_ID;
		private bool isApproved;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityWorkstationRegister class.
		/// </summary>
		public tbl_securityWorkstationRegister()
		{
		}

		/// <summary>
		/// Initializes a new instance of the tbl_securityWorkstationRegister class.
		/// </summary>
		public tbl_securityWorkstationRegister(string terminal_ID, string companyID, string companyBranch_ID, bool isApproved)
		{
			this.terminal_ID = terminal_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.isApproved = isApproved;
		}

		/// <summary>
		/// Initializes a new instance of the tbl_securityWorkstationRegister class.
		/// </summary>
		public tbl_securityWorkstationRegister(int workstation_ID, string terminal_ID, string companyID, string companyBranch_ID, bool isApproved)
		{
			this.workstation_ID = workstation_ID;
			this.terminal_ID = terminal_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.isApproved = isApproved;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Workstation_ID value.
		/// </summary>
		public int Workstation_ID
		{
			get { return workstation_ID; }
			set { workstation_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID
		{
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}

		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID
		{
			get { return companyID; }
			set { companyID = value; }
		}

		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID
		{
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}

		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved
		{
			get { return isApproved; }
			set { isApproved = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityWorkstationRegister table.
		/// </summary>
		public void Insert()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar, 100);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit, 1);

			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isApproved"].Value = isApproved;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Updates a record in the tbl_securityWorkstationRegister table.
		/// </summary>
		public void Update()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@workstation_ID", SqlDbType.Int, 4);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar, 100);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit, 1);

			scom.Parameters["@workstation_ID"].Value = workstation_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isApproved"].Value = isApproved;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Deletes a record from the tbl_securityWorkstationRegister table by its primary key.
		/// </summary>
		public void Delete()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@workstation_ID", SqlDbType.Int, 4);
			scom.Parameters["@workstation_ID"].Value = workstation_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_securityWorkstationRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_securityWorkstationRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
			scom.Parameters["@companyID"].Value = companyID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects a single record from the tbl_securityWorkstationRegister table.
		/// </summary>
		public static tbl_securityWorkstationRegister Select(int workstation_ID_Incoming)
		{

			tbl_securityWorkstationRegister tbl_securityWorkstationRegisterins = new tbl_securityWorkstationRegister();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@workstation_ID", SqlDbType.Int, 4);
			scom.Parameters["@workstation_ID"].Value = workstation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				if (dataReader.Read())
				{
					tbl_securityWorkstationRegisterins = Maketbl_securityWorkstationRegister(dataReader);
				}
				else
				{
					tbl_securityWorkstationRegisterins = null;
				}
			}
			scon.Close();
			return tbl_securityWorkstationRegisterins;
		}

		/// <summary>
		/// Selects all records from the tbl_securityWorkstationRegister table.
		/// </summary>
		public static List<tbl_securityWorkstationRegister> SelectAll()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			List<tbl_securityWorkstationRegister> tbl_securityWorkstationRegisterList = new List<tbl_securityWorkstationRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityWorkstationRegister tbl_securityWorkstationRegister = Maketbl_securityWorkstationRegister(dataReader);
					tbl_securityWorkstationRegisterList.Add(tbl_securityWorkstationRegister);
				}
			}
			scon.Close();
			return tbl_securityWorkstationRegisterList;
		}

		/// <summary>
		/// Selects all records from the tbl_securityWorkstationRegister table by a foreign key.
		/// </summary>
		public static List<tbl_securityWorkstationRegister> SelectAllByCompanyBranch_ID(string companyBranch_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			List<tbl_securityWorkstationRegister> tbl_securityWorkstationRegisterList = new List<tbl_securityWorkstationRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityWorkstationRegister tbl_securityWorkstationRegister = Maketbl_securityWorkstationRegister(dataReader);
					tbl_securityWorkstationRegisterList.Add(tbl_securityWorkstationRegister);
				}
			}
			scon.Close();
			return tbl_securityWorkstationRegisterList;
		}

		/// <summary>
		/// Selects all records from the tbl_securityWorkstationRegister table by a foreign key.
		/// </summary>
		public static List<tbl_securityWorkstationRegister> SelectAllByCompanyID(string companyID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityWorkstationRegisterSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
			scom.Parameters["@companyID"].Value = companyID;
			List<tbl_securityWorkstationRegister> tbl_securityWorkstationRegisterList = new List<tbl_securityWorkstationRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityWorkstationRegister tbl_securityWorkstationRegister = Maketbl_securityWorkstationRegister(dataReader);
					tbl_securityWorkstationRegisterList.Add(tbl_securityWorkstationRegister);
				}
			}
			scon.Close();
			return tbl_securityWorkstationRegisterList;
		}

		/// <summary>
		/// Creates a new instance of the tbl_securityWorkstationRegister class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityWorkstationRegister Maketbl_securityWorkstationRegister(SqlDataReader dataReader)
		{
			tbl_securityWorkstationRegister tbl_securityWorkstationRegister = new tbl_securityWorkstationRegister();

			if (dataReader.IsDBNull(0) == false)
			{
				tbl_securityWorkstationRegister.Workstation_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false)
			{
				tbl_securityWorkstationRegister.Terminal_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false)
			{
				tbl_securityWorkstationRegister.CompanyID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false)
			{
				tbl_securityWorkstationRegister.CompanyBranch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false)
			{
				tbl_securityWorkstationRegister.IsApproved = dataReader.GetBoolean(4);
			}

			return tbl_securityWorkstationRegister;
		}
		/// <summary>
		/// This makes tbl_securityWorkstationRegister datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityWorkstationRegister object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable(tbl_securityWorkstationRegister tbl_securityWorkstationRegister)
		{
			DataTable dt = new DataTable();

			DataColumn col_workstation_ID = new DataColumn("workstation_ID", typeof(int));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID", typeof(string));
			DataColumn col_companyID = new DataColumn("companyID", typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID", typeof(string));
			DataColumn col_isApproved = new DataColumn("isApproved", typeof(bool));
			dt.Columns.AddRange(new DataColumn[] { col_workstation_ID, col_terminal_ID, col_companyID, col_companyBranch_ID, col_isApproved, }); return dt;
		}
		/// <summary>
		/// This fills tbl_securityWorkstationRegister datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityWorkstationRegister object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityWorkstationRegister user)
		{
			DataRow drow = dt.NewRow();

			drow["workstation_ID"] = user.workstation_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["isApproved"] = user.isApproved;
			dt.Rows.Add(drow);
		}
		#endregion
	}
}
