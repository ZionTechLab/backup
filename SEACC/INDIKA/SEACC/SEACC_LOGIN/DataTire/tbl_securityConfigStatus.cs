using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_LOGIN.DataTire
{
	public sealed class tbl_securityConfigStatus
	{
		#region Fields
		private int valueID;
		private string valueName;
		private bool configValue;
		private string configTypeStatus_ID;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigStatus class.
		/// </summary>
		public tbl_securityConfigStatus()
		{
		}

		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigStatus class.
		/// </summary>
		public tbl_securityConfigStatus(int valueID, string valueName, bool configValue, string configTypeStatus_ID)
		{
			this.valueID = valueID;
			this.valueName = valueName;
			this.configValue = configValue;
			this.configTypeStatus_ID = configTypeStatus_ID;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ValueID value.
		/// </summary>
		public int ValueID
		{
			get { return valueID; }
			set { valueID = value; }
		}

		/// <summary>
		/// Gets or sets the ValueName value.
		/// </summary>
		public string ValueName
		{
			get { return valueName; }
			set { valueName = value; }
		}

		/// <summary>
		/// Gets or sets the ConfigValue value.
		/// </summary>
		public bool ConfigValue
		{
			get { return configValue; }
			set { configValue = value; }
		}

		/// <summary>
		/// Gets or sets the ConfigTypeStatus_ID value.
		/// </summary>
		public string ConfigTypeStatus_ID
		{
			get { return configTypeStatus_ID; }
			set { configTypeStatus_ID = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityConfigStatus table.
		/// </summary>
		public void Insert()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigStatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@valueID", SqlDbType.Int, 4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@configValue", SqlDbType.Bit, 1);
			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar, 10);

			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@configValue"].Value = configValue;
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Updates a record in the tbl_securityConfigStatus table.
		/// </summary>
		public void Update()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigStatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@valueID", SqlDbType.Int, 4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@configValue", SqlDbType.Bit, 1);
			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar, 10);


			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@configValue"].Value = configValue;
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Deletes a record from the tbl_securityConfigStatus table by its primary key.
		/// </summary>
		public void Delete()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigStatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@valueID", SqlDbType.Int, 4);
			scom.Parameters["@valueID"].Value = valueID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_securityConfigStatus table by a foreign key.
		/// </summary>
		public static void DeleteAllByConfigTypeStatus_ID(string configTypeStatus_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigStatusDeleteAllByConfigTypeStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects a single record from the tbl_securityConfigStatus table.
		/// </summary>
		public static tbl_securityConfigStatus Select(int valueID_Incoming)
		{

			tbl_securityConfigStatus tbl_securityConfigStatusins = new tbl_securityConfigStatus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigStatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@valueID", SqlDbType.Int, 4);
			scom.Parameters["@valueID"].Value = valueID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				if (dataReader.Read())
				{
					tbl_securityConfigStatusins = Maketbl_securityConfigStatus(dataReader);
				}
				else
				{
					tbl_securityConfigStatusins = null;
				}
			}
			scon.Close();
			return tbl_securityConfigStatusins;
		}

		/// <summary>
		/// Selects all records from the tbl_securityConfigStatus table.
		/// </summary>
		public static List<tbl_securityConfigStatus> SelectAll()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigStatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			List<tbl_securityConfigStatus> tbl_securityConfigStatusList = new List<tbl_securityConfigStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityConfigStatus tbl_securityConfigStatus = Maketbl_securityConfigStatus(dataReader);
					tbl_securityConfigStatusList.Add(tbl_securityConfigStatus);
				}
			}
			scon.Close();
			return tbl_securityConfigStatusList;
		}

		/// <summary>
		/// Selects all records from the tbl_securityConfigStatus table by a foreign key.
		/// </summary>
		public static List<tbl_securityConfigStatus> SelectAllByConfigTypeStatus_ID(string configTypeStatus_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigStatusSelectAllByConfigTypeStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@configTypeStatus_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@configTypeStatus_ID"].Value = configTypeStatus_ID;
			List<tbl_securityConfigStatus> tbl_securityConfigStatusList = new List<tbl_securityConfigStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityConfigStatus tbl_securityConfigStatus = Maketbl_securityConfigStatus(dataReader);
					tbl_securityConfigStatusList.Add(tbl_securityConfigStatus);
				}
			}
			scon.Close();
			return tbl_securityConfigStatusList;
		}

		/// <summary>
		/// Creates a new instance of the tbl_securityConfigStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityConfigStatus Maketbl_securityConfigStatus(SqlDataReader dataReader)
		{
			tbl_securityConfigStatus tbl_securityConfigStatus = new tbl_securityConfigStatus();

			if (dataReader.IsDBNull(0) == false)
			{
				tbl_securityConfigStatus.ValueID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false)
			{
				tbl_securityConfigStatus.ValueName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false)
			{
				tbl_securityConfigStatus.ConfigValue = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false)
			{
				tbl_securityConfigStatus.ConfigTypeStatus_ID = dataReader.GetString(3);
			}

			return tbl_securityConfigStatus;
		}
		/// <summary>
		/// This makes tbl_securityConfigStatus datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityConfigStatus object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable(tbl_securityConfigStatus tbl_securityConfigStatus)
		{
			DataTable dt = new DataTable();

			DataColumn col_valueID = new DataColumn("valueID", typeof(int));
			DataColumn col_valueName = new DataColumn("valueName", typeof(string));
			DataColumn col_configValue = new DataColumn("configValue", typeof(bool));
			DataColumn col_configTypeStatus_ID = new DataColumn("configTypeStatus_ID", typeof(string));
			dt.Columns.AddRange(new DataColumn[] { col_valueID, col_valueName, col_configValue, col_configTypeStatus_ID, }); return dt;
		}
		/// <summary>
		/// This fills tbl_securityConfigStatus datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityConfigStatus object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityConfigStatus user)
		{
			DataRow drow = dt.NewRow();

			drow["valueID"] = user.valueID;
			drow["valueName"] = user.valueName;
			drow["configValue"] = user.configValue;
			drow["configTypeStatus_ID"] = user.configTypeStatus_ID;
			dt.Rows.Add(drow);
		}
		#endregion
	}
}
