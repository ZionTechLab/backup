//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_altAlert_Shedule_Users
{
	#region Fields
	public int Shedule_ID;
	public int UserGroup_Id;
	#endregion

	#region Constructors
	public tbl_altAlert_Shedule_Users() {	 }

	public tbl_altAlert_Shedule_Users(int Shedule_ID,int UserGroup_Id)
	{
		this.Shedule_ID=Shedule_ID;
		this.UserGroup_Id=UserGroup_Id;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_altAlert_Shedule_Users] ([Shedule_ID] , [UserGroup_Id]) VALUES ("+Shedule_ID+" , "+UserGroup_Id+")";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_altAlert_Shedule_Users] SET [Shedule_ID] = "+Shedule_ID+" , [UserGroup_Id] = "+UserGroup_Id+" WHERE [Shedule_ID] = "+Shedule_ID+" , [UserGroup_Id] = "+UserGroup_Id+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_altAlert_Shedule_Users] Where [Shedule_ID] = "+Shedule_ID+" , [UserGroup_Id] = "+UserGroup_Id+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_altAlert_Shedule_Users Select(int PShedule_ID , int PUserGroup_Id)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [UserGroup_Id] From [dbo].[tbl_altAlert_Shedule_Users] Where [Shedule_ID] = '"+PShedule_ID+"' , [UserGroup_Id] = '"+PUserGroup_Id+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_altAlert_Shedule_Users oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_altAlert_Shedule_Users();

			oTable.Shedule_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Shedule_ID"].ToString());
			oTable.UserGroup_Id=int.Parse(DBConnection.ResultTable.Rows[0]["UserGroup_Id"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [UserGroup_Id] From [dbo].[tbl_altAlert_Shedule_Users] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_altAlert_Shedule_Users> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [UserGroup_Id] From [dbo].[tbl_altAlert_Shedule_Users]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_altAlert_Shedule_Users> lstTable = new List<tbl_altAlert_Shedule_Users>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_altAlert_Shedule_Users oTable = new tbl_altAlert_Shedule_Users();
			oTable.Shedule_ID=int.Parse(row["Shedule_ID"].ToString());
			oTable.UserGroup_Id=int.Parse(row["UserGroup_Id"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public static List<tbl_altAlert_Shedule_Users> SelectAllByShedule_ID(int PShedule_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [UserGroup_Id] From [dbo].[tbl_altAlert_Shedule_Users] Where [Shedule_ID] = '"+PShedule_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_altAlert_Shedule_Users> lstTable = new List<tbl_altAlert_Shedule_Users>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_altAlert_Shedule_Users oTable = new tbl_altAlert_Shedule_Users();
			oTable.Shedule_ID=int.Parse(row["Shedule_ID"].ToString());
			oTable.UserGroup_Id=int.Parse(row["UserGroup_Id"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableShedule_ID(int PShedule_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [UserGroup_Id] From [dbo].[tbl_altAlert_Shedule_Users] Where [Shedule_ID] = '"+PShedule_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	#endregion
}
