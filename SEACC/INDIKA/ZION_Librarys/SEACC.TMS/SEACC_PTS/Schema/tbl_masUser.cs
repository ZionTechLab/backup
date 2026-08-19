//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_masUser
{
	#region Fields
	public int User_ID;
	public int Organization_Code;
	public int UserGroup_ID;
	public string User_Name;
	public string Display_Name;
	public string Full_Name;
	public string EmailAddress;
	public string ProfilePicture;
	#endregion

	#region Constructors
	public tbl_masUser() {	 }

	public tbl_masUser(int User_ID,int Organization_Code,int UserGroup_ID,string User_Name,string Display_Name,string Full_Name,string EmailAddress,string ProfilePicture)
	{
		this.User_ID=User_ID;
		this.Organization_Code=Organization_Code;
		this.UserGroup_ID=UserGroup_ID;
		this.User_Name=User_Name;
		this.Display_Name=Display_Name;
		this.Full_Name=Full_Name;
		this.EmailAddress=EmailAddress;
		this.ProfilePicture=ProfilePicture;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_masUser] ([User_ID] , [Organization_Code] , [UserGroup_ID] , [User_Name] , [Display_Name] , [Full_Name] , [EmailAddress] , [ProfilePicture]) VALUES ("+User_ID+" , "+Organization_Code+" , "+UserGroup_ID+" , '"+User_Name+"' , '"+Display_Name+"' , '"+Full_Name+"' , '"+EmailAddress+"' , '"+ProfilePicture+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_masUser] SET [User_ID] = "+User_ID+" , [Organization_Code] = "+Organization_Code+" , [UserGroup_ID] = "+UserGroup_ID+" , [User_Name] = '"+User_Name+"' , [Display_Name] = '"+Display_Name+"' , [Full_Name] = '"+Full_Name+"' , [EmailAddress] = '"+EmailAddress+"' , [ProfilePicture] = '"+ProfilePicture+"' WHERE [User_ID] = "+User_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_masUser] Where [User_ID] = "+User_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}
    public static tbl_masUser Select(string PUser_Name)
    {
        dbConnection DBConnection = new dbConnection();
        string sScript = "Select [User_ID] , [Organization_Code] , [UserGroup_ID] , [User_Name] , [Display_Name] , [Full_Name] , [EmailAddress] , [ProfilePicture] From [dbo].[tbl_masUser] Where [User_Name] = '" + PUser_Name + "'";
        bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
        tbl_masUser oTable = null;

        if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)
        {
            oTable = new tbl_masUser();

            oTable.User_ID = int.Parse(DBConnection.ResultTable.Rows[0]["User_ID"].ToString());
            oTable.Organization_Code = int.Parse(DBConnection.ResultTable.Rows[0]["Organization_Code"].ToString());
            oTable.UserGroup_ID = int.Parse(DBConnection.ResultTable.Rows[0]["UserGroup_ID"].ToString());
            oTable.User_Name = DBConnection.ResultTable.Rows[0]["User_Name"].ToString();
            oTable.Display_Name = DBConnection.ResultTable.Rows[0]["Display_Name"].ToString();
            oTable.Full_Name = DBConnection.ResultTable.Rows[0]["Full_Name"].ToString();
            oTable.EmailAddress = DBConnection.ResultTable.Rows[0]["EmailAddress"].ToString();
            oTable.ProfilePicture = DBConnection.ResultTable.Rows[0]["ProfilePicture"].ToString();
        }
        return oTable;
    }
	public static tbl_masUser Select(int PUser_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserGroup_ID] , [User_Name] , [Display_Name] , [Full_Name] , [EmailAddress] , [ProfilePicture] From [dbo].[tbl_masUser] Where [User_ID] = '"+PUser_ID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_masUser oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_masUser();

			oTable.User_ID=int.Parse(DBConnection.ResultTable.Rows[0]["User_ID"].ToString());
			oTable.Organization_Code=int.Parse(DBConnection.ResultTable.Rows[0]["Organization_Code"].ToString());
			oTable.UserGroup_ID=int.Parse(DBConnection.ResultTable.Rows[0]["UserGroup_ID"].ToString());
			oTable.User_Name=DBConnection.ResultTable.Rows[0]["User_Name"].ToString();
			oTable.Display_Name=DBConnection.ResultTable.Rows[0]["Display_Name"].ToString();
			oTable.Full_Name=DBConnection.ResultTable.Rows[0]["Full_Name"].ToString();
			oTable.EmailAddress=DBConnection.ResultTable.Rows[0]["EmailAddress"].ToString();
			oTable.ProfilePicture=DBConnection.ResultTable.Rows[0]["ProfilePicture"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserGroup_ID] , [User_Name] , [Display_Name] , [Full_Name] , [EmailAddress] , [ProfilePicture] From [dbo].[tbl_masUser] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_masUser> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserGroup_ID] , [User_Name] , [Display_Name] , [Full_Name] , [EmailAddress] , [ProfilePicture] From [dbo].[tbl_masUser]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_masUser> lstTable = new List<tbl_masUser>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_masUser oTable = new tbl_masUser();
			oTable.User_ID=int.Parse(row["User_ID"].ToString());
			oTable.Organization_Code=int.Parse(row["Organization_Code"].ToString());
			oTable.UserGroup_ID=int.Parse(row["UserGroup_ID"].ToString());
			oTable.User_Name=row["User_Name"].ToString();
			oTable.Display_Name=row["Display_Name"].ToString();
			oTable.Full_Name=row["Full_Name"].ToString();
			oTable.EmailAddress=row["EmailAddress"].ToString();
			oTable.ProfilePicture=row["ProfilePicture"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public static List<tbl_masUser> SelectAllByUserGroup_ID(int PUserGroup_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserGroup_ID] , [User_Name] , [Display_Name] , [Full_Name] , [EmailAddress] , [ProfilePicture] From [dbo].[tbl_masUser] Where [UserGroup_ID] = '"+PUserGroup_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_masUser> lstTable = new List<tbl_masUser>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_masUser oTable = new tbl_masUser();
			oTable.User_ID=int.Parse(row["User_ID"].ToString());
			oTable.Organization_Code=int.Parse(row["Organization_Code"].ToString());
			oTable.UserGroup_ID=int.Parse(row["UserGroup_ID"].ToString());
			oTable.User_Name=row["User_Name"].ToString();
			oTable.Display_Name=row["Display_Name"].ToString();
			oTable.Full_Name=row["Full_Name"].ToString();
			oTable.EmailAddress=row["EmailAddress"].ToString();
			oTable.ProfilePicture=row["ProfilePicture"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableUserGroup_ID(int PUserGroup_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserGroup_ID] , [User_Name] , [Display_Name] , [Full_Name] , [EmailAddress] , [ProfilePicture] From [dbo].[tbl_masUser] Where [UserGroup_ID] = '"+PUserGroup_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	#endregion
}
