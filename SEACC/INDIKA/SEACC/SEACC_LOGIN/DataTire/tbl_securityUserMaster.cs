using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_LOGIN.DataTire
{
	public sealed class tbl_securityUserMaster
	{
		#region Fields
		private string user_ID;
		private string userName;
		private string password;
		private string password2;
		private string employeeID;
		private string email;
		private string moible;
		private string computerName;
		private string computerIP;
		private DateTime lastLogedDateTime;
		private bool isLoged;
		private bool isBlocked;
		private bool isLocked;
		private string group_ID;
		private byte[] image;
		private DateTime lastPWChangedDateTime;
		private string lastPWChangedUser_ID;
		private string lastPWChangedTerminal_ID;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserMaster class.
		/// </summary>
		public tbl_securityUserMaster()
		{
		}

		/// <summary>
		/// Initializes a new instance of the tbl_securityUserMaster class.
		/// </summary>
		public tbl_securityUserMaster(string user_ID, string userName, string password, string password2, string employeeID, string email, string moible, string computerName, string computerIP, DateTime lastLogedDateTime, bool isLoged, bool isBlocked, bool isLocked, string group_ID, byte[] image, DateTime lastPWChangedDateTime, string lastPWChangedUser_ID, string lastPWChangedTerminal_ID)
		{
			this.user_ID = user_ID;
			this.userName = userName;
			this.password = password;
			this.password2 = password2;
			this.employeeID = employeeID;
			this.email = email;
			this.moible = moible;
			this.computerName = computerName;
			this.computerIP = computerIP;
			this.lastLogedDateTime = lastLogedDateTime;
			this.isLoged = isLoged;
			this.isBlocked = isBlocked;
			this.isLocked = isLocked;
			this.group_ID = group_ID;
			this.image = image;
			this.lastPWChangedDateTime = lastPWChangedDateTime;
			this.lastPWChangedUser_ID = lastPWChangedUser_ID;
			this.lastPWChangedTerminal_ID = lastPWChangedTerminal_ID;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID
		{
			get { return user_ID; }
			set { user_ID = value; }
		}

		/// <summary>
		/// Gets or sets the UserName value.
		/// </summary>
		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}

		/// <summary>
		/// Gets or sets the Password value.
		/// </summary>
		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		/// <summary>
		/// Gets or sets the Password2 value.
		/// </summary>
		public string Password2
		{
			get { return password2; }
			set { password2 = value; }
		}

		/// <summary>
		/// Gets or sets the EmployeeID value.
		/// </summary>
		public string EmployeeID
		{
			get { return employeeID; }
			set { employeeID = value; }
		}

		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		/// <summary>
		/// Gets or sets the Moible value.
		/// </summary>
		public string Moible
		{
			get { return moible; }
			set { moible = value; }
		}

		/// <summary>
		/// Gets or sets the ComputerName value.
		/// </summary>
		public string ComputerName
		{
			get { return computerName; }
			set { computerName = value; }
		}

		/// <summary>
		/// Gets or sets the ComputerIP value.
		/// </summary>
		public string ComputerIP
		{
			get { return computerIP; }
			set { computerIP = value; }
		}

		/// <summary>
		/// Gets or sets the LastLogedDateTime value.
		/// </summary>
		public DateTime LastLogedDateTime
		{
			get { return lastLogedDateTime; }
			set { lastLogedDateTime = value; }
		}

		/// <summary>
		/// Gets or sets the IsLoged value.
		/// </summary>
		public bool IsLoged
		{
			get { return isLoged; }
			set { isLoged = value; }
		}

		/// <summary>
		/// Gets or sets the IsBlocked value.
		/// </summary>
		public bool IsBlocked
		{
			get { return isBlocked; }
			set { isBlocked = value; }
		}

		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked
		{
			get { return isLocked; }
			set { isLocked = value; }
		}

		/// <summary>
		/// Gets or sets the Group_ID value.
		/// </summary>
		public string Group_ID
		{
			get { return group_ID; }
			set { group_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image
		{
			get { return image; }
			set { image = value; }
		}

		/// <summary>
		/// Gets or sets the LastPWChangedDateTime value.
		/// </summary>
		public DateTime LastPWChangedDateTime
		{
			get { return lastPWChangedDateTime; }
			set { lastPWChangedDateTime = value; }
		}

		/// <summary>
		/// Gets or sets the LastPWChangedUser_ID value.
		/// </summary>
		public string LastPWChangedUser_ID
		{
			get { return lastPWChangedUser_ID; }
			set { lastPWChangedUser_ID = value; }
		}

		/// <summary>
		/// Gets or sets the LastPWChangedTerminal_ID value.
		/// </summary>
		public string LastPWChangedTerminal_ID
		{
			get { return lastPWChangedTerminal_ID; }
			set { lastPWChangedTerminal_ID = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityUserMaster table.
		/// </summary>
		public void Insert()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@password", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@password2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@employeeID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@email", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@moible", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@computerName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@computerIP", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@lastLogedDateTime", SqlDbType.DateTime, 8);
			scom.Parameters.Add("@isLoged", SqlDbType.Bit, 1);
			scom.Parameters.Add("@isBlocked", SqlDbType.Bit, 1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@image", SqlDbType.Image, 2147483647);
			scom.Parameters.Add("@lastPWChangedDateTime", SqlDbType.DateTime, 8);
			scom.Parameters.Add("@lastPWChangedUser_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@lastPWChangedTerminal_ID", SqlDbType.VarChar, 50);

			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@password"].Value = password;
			scom.Parameters["@password2"].Value = password2;
			scom.Parameters["@employeeID"].Value = employeeID;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@moible"].Value = moible;
			scom.Parameters["@computerName"].Value = computerName;
			scom.Parameters["@computerIP"].Value = computerIP;
			scom.Parameters["@lastLogedDateTime"].Value = lastLogedDateTime;
			scom.Parameters["@isLoged"].Value = isLoged;
			scom.Parameters["@isBlocked"].Value = isBlocked;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@group_ID"].Value = group_ID;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@lastPWChangedDateTime"].Value = lastPWChangedDateTime;
			scom.Parameters["@lastPWChangedUser_ID"].Value = lastPWChangedUser_ID;
			scom.Parameters["@lastPWChangedTerminal_ID"].Value = lastPWChangedTerminal_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Updates a record in the tbl_securityUserMaster table.
		/// </summary>
		public void Update()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@password", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@password2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@employeeID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@email", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@moible", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@computerName", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@computerIP", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@lastLogedDateTime", SqlDbType.DateTime, 8);
			scom.Parameters.Add("@isLoged", SqlDbType.Bit, 1);
			scom.Parameters.Add("@isBlocked", SqlDbType.Bit, 1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@image", SqlDbType.Image, 2147483647);
			scom.Parameters.Add("@lastPWChangedDateTime", SqlDbType.DateTime, 8);
			scom.Parameters.Add("@lastPWChangedUser_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@lastPWChangedTerminal_ID", SqlDbType.VarChar, 50);


			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@password"].Value = password;
			scom.Parameters["@password2"].Value = password2;
			scom.Parameters["@employeeID"].Value = employeeID;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@moible"].Value = moible;
			scom.Parameters["@computerName"].Value = computerName;
			scom.Parameters["@computerIP"].Value = computerIP;
			scom.Parameters["@lastLogedDateTime"].Value = lastLogedDateTime;
			scom.Parameters["@isLoged"].Value = isLoged;
			scom.Parameters["@isBlocked"].Value = isBlocked;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@group_ID"].Value = group_ID;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@lastPWChangedDateTime"].Value = lastPWChangedDateTime;
			scom.Parameters["@lastPWChangedUser_ID"].Value = lastPWChangedUser_ID;
			scom.Parameters["@lastPWChangedTerminal_ID"].Value = lastPWChangedTerminal_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Deletes a record from the tbl_securityUserMaster table by its primary key.
		/// </summary>
		public void Delete()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@user_ID"].Value = user_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_securityUserMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByGroup_ID(string group_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterDeleteAllByGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@group_ID"].Value = group_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects a single record from the tbl_securityUserMaster table.
		/// </summary>
		public static tbl_securityUserMaster Select(string user_ID_Incoming)
		{

			tbl_securityUserMaster tbl_securityUserMasterins = new tbl_securityUserMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				if (dataReader.Read())
				{
					tbl_securityUserMasterins = Maketbl_securityUserMaster(dataReader);
				}
				else
				{
					tbl_securityUserMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityUserMasterins;
		}

		/// <summary>
		/// Selects all records from the tbl_securityUserMaster table.
		/// </summary>
		public static List<tbl_securityUserMaster> SelectAll()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			List<tbl_securityUserMaster> tbl_securityUserMasterList = new List<tbl_securityUserMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityUserMaster tbl_securityUserMaster = Maketbl_securityUserMaster(dataReader);
					tbl_securityUserMasterList.Add(tbl_securityUserMaster);
				}
			}
			scon.Close();
			return tbl_securityUserMasterList;
		}

		/// <summary>
		/// Selects all records from the tbl_securityUserMaster table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserMaster> SelectAllByGroup_ID(string group_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterSelectAllByGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@group_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@group_ID"].Value = group_ID;
			List<tbl_securityUserMaster> tbl_securityUserMasterList = new List<tbl_securityUserMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_securityUserMaster tbl_securityUserMaster = Maketbl_securityUserMaster(dataReader);
					tbl_securityUserMasterList.Add(tbl_securityUserMaster);
				}
			}
			scon.Close();
			return tbl_securityUserMasterList;
		}

		/// <summary>
		/// Creates a new instance of the tbl_securityUserMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityUserMaster Maketbl_securityUserMaster(SqlDataReader dataReader)
		{
			tbl_securityUserMaster tbl_securityUserMaster = new tbl_securityUserMaster();

			if (dataReader.IsDBNull(0) == false)
			{
				tbl_securityUserMaster.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false)
			{
				tbl_securityUserMaster.UserName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false)
			{
				tbl_securityUserMaster.Password = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false)
			{
				tbl_securityUserMaster.Password2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false)
			{
				tbl_securityUserMaster.EmployeeID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false)
			{
				tbl_securityUserMaster.Email = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false)
			{
				tbl_securityUserMaster.Moible = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false)
			{
				tbl_securityUserMaster.ComputerName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false)
			{
				tbl_securityUserMaster.ComputerIP = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false)
			{
				tbl_securityUserMaster.LastLogedDateTime = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false)
			{
				tbl_securityUserMaster.IsLoged = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false)
			{
				tbl_securityUserMaster.IsBlocked = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false)
			{
				tbl_securityUserMaster.IsLocked = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false)
			{
				tbl_securityUserMaster.Group_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false)
			{
				tbl_securityUserMaster.Image = (byte[])dataReader[14];
			}
			if (dataReader.IsDBNull(15) == false)
			{
				tbl_securityUserMaster.LastPWChangedDateTime = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false)
			{
				tbl_securityUserMaster.LastPWChangedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false)
			{
				tbl_securityUserMaster.LastPWChangedTerminal_ID = dataReader.GetString(17);
			}

			return tbl_securityUserMaster;
		}
		/// <summary>
		/// This makes tbl_securityUserMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityUserMaster object</param>
		/// <returns></returns>
		//public static DataTable CreateDataTable( tbl_securityUserMaster  tbl_securityUserMaster   )
		//{
		//DataTable dt = new DataTable();

		//    DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
		//    DataColumn col_userName = new DataColumn("userName" , typeof(string));
		//    DataColumn col_password = new DataColumn("password" , typeof(string));
		//    DataColumn col_password2 = new DataColumn("password2" , typeof(string));
		//    DataColumn col_employeeID = new DataColumn("employeeID" , typeof(string));
		//    DataColumn col_email = new DataColumn("email" , typeof(string));
		//    DataColumn col_moible = new DataColumn("moible" , typeof(string));
		//    DataColumn col_computerName = new DataColumn("computerName" , typeof(string));
		//    DataColumn col_computerIP = new DataColumn("computerIP" , typeof(string));
		//    DataColumn col_lastLogedDateTime = new DataColumn("lastLogedDateTime" , typeof(DateTime));
		//    DataColumn col_isLoged = new DataColumn("isLoged" , typeof(bool));
		//    DataColumn col_isBlocked = new DataColumn("isBlocked" , typeof(bool));
		//    DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		//    DataColumn col_group_ID = new DataColumn("group_ID" , typeof(string));
		//    DataColumn col_image = new DataColumn("image" , typeof(byte[]));
		//    DataColumn col_lastPWChangedDateTime = new DataColumn("lastPWChangedDateTime" , typeof(DateTime));
		//    DataColumn col_lastPWChangedUser_ID = new DataColumn("lastPWChangedUser_ID" , typeof(string));
		//    DataColumn col_lastPWChangedTerminal_ID = new DataColumn("lastPWChangedTerminal_ID" , typeof(string));
		//dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_userName,col_password,col_password2,col_employeeID,col_email,col_moible,col_computerName,col_computerIP,col_lastLogedDateTime,col_isLoged,col_isBlocked,col_isLocked,col_group_ID,col_image,col_lastPWChangedDateTime,col_lastPWChangedUser_ID,col_lastPWChangedTerminal_ID,});		return dt;
		//}
		/// <summary>
		/// This fills tbl_securityUserMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityUserMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityUserMaster user)
		{
			DataRow drow = dt.NewRow();

			drow["user_ID"] = user.user_ID;
			drow["userName"] = user.userName;
			drow["password"] = user.password;
			drow["password2"] = user.password2;
			drow["employeeID"] = user.employeeID;
			drow["email"] = user.email;
			drow["moible"] = user.moible;
			drow["computerName"] = user.computerName;
			drow["computerIP"] = user.computerIP;
			drow["lastLogedDateTime"] = user.lastLogedDateTime;
			drow["isLoged"] = user.isLoged;
			drow["isBlocked"] = user.isBlocked;
			drow["isLocked"] = user.isLocked;
			drow["group_ID"] = user.group_ID;
			drow["image"] = user.image;
			drow["lastPWChangedDateTime"] = user.lastPWChangedDateTime;
			drow["lastPWChangedUser_ID"] = user.lastPWChangedUser_ID;
			drow["lastPWChangedTerminal_ID"] = user.lastPWChangedTerminal_ID;
			dt.Rows.Add(drow);
		}
		#endregion
	}
}
