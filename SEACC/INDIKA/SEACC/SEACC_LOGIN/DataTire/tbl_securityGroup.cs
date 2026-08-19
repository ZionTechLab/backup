using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_LOGIN.DataTire
{
	public sealed class tbl_securityGroup
	{
		#region Fields
		private string group_ID;
		private string groupName;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityGroup class.
		/// </summary>
		public tbl_securityGroup()
		{
		}

		/// <summary>
		/// Initializes a new instance of the tbl_securityGroup class.
		/// </summary>
		public tbl_securityGroup(string group_ID, string groupName)
		{
			this.group_ID = group_ID;
			this.groupName = groupName;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Group_ID value.
		/// </summary>
		public string Group_ID
		{
			get { return group_ID; }
			set { group_ID = value; }
		}

		/// <summary>
		/// Gets or sets the GroupName value.
		/// </summary>
		public string GroupName
		{
			get { return groupName; }
			set { groupName = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityGroup table.
		/// </summary>
		public void Insert()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@groupName", SqlDbType.VarChar, 50);

			scom.Parameters["@group_ID"].Value = group_ID;
			scom.Parameters["@groupName"].Value = groupName;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Updates a record in the tbl_securityGroup table.
		/// </summary>
		public void Update()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@groupName", SqlDbType.VarChar, 50);


			scom.Parameters["@group_ID"].Value = group_ID;
			scom.Parameters["@groupName"].Value = groupName;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Deletes a record from the tbl_securityGroup table by its primary key.
		/// </summary>
		public void Delete()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@group_ID"].Value = group_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects a single record from the tbl_securityGroup table.
		/// </summary>
		public static tbl_securityGroup Select(string group_ID_Incoming)
		{

			tbl_securityGroup tbl_securityGroupins = new tbl_securityGroup();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@group_ID"].Value = group_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				if (dataReader.Read())
				{
					tbl_securityGroupins = Maketbl_securityGroup(dataReader);
				}
				else
				{
					tbl_securityGroupins = null;
				}
			}
			scon.Close();
			return tbl_securityGroupins;
		}

		/// <summary>
		/// Selects all records from the tbl_securityGroup table.
		/// </summary>
		public static List<tbl_securityGroup> SelectAll()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityGroupSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			List<tbl_securityGroup> tbl_securityGroupList = new List<tbl_securityGroup>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityGroup tbl_securityGroup = Maketbl_securityGroup(dataReader);
					tbl_securityGroupList.Add(tbl_securityGroup);
				}
			}
			scon.Close();
			return tbl_securityGroupList;
		}

		/// <summary>
		/// Creates a new instance of the tbl_securityGroup class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityGroup Maketbl_securityGroup(SqlDataReader dataReader)
		{
			tbl_securityGroup tbl_securityGroup = new tbl_securityGroup();

			if (dataReader.IsDBNull(0) == false)
			{
				tbl_securityGroup.Group_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false)
			{
				tbl_securityGroup.GroupName = dataReader.GetString(1);
			}

			return tbl_securityGroup;
		}
		/// <summary>
		/// This fills tbl_securityGroup datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityGroup object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityGroup user)
		{
			DataRow drow = dt.NewRow();

			drow["group_ID"] = user.group_ID;
			drow["groupName"] = user.groupName;
			dt.Rows.Add(drow);
		}
		#endregion
	}
}
