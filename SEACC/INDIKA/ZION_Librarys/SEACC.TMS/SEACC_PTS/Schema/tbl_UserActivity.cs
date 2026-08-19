//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_UserActivity
{
	#region Fields
	public int User_ID;
	public int Organization_Code;
	public int UserActivityType;
	public DateTime Time;
	#endregion

	#region Constructors
	public tbl_UserActivity() {	 }

	public tbl_UserActivity(int User_ID,int Organization_Code,int UserActivityType,DateTime Time)
	{
		this.User_ID=User_ID;
		this.Organization_Code=Organization_Code;
		this.UserActivityType=UserActivityType;
		this.Time=Time;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_UserActivity] ([User_ID] , [Organization_Code] , [UserActivityType] , [Time]) VALUES ("+User_ID+" , "+Organization_Code+" , "+UserActivityType+" , '"+Time+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_UserActivity] SET [User_ID] = "+User_ID+" , [Organization_Code] = "+Organization_Code+" , [UserActivityType] = "+UserActivityType+" , [Time] = '"+Time+"' WHERE ";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_UserActivity] Where ";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_UserActivity Select()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserActivityType] , [Time] From [dbo].[tbl_UserActivity] Where ";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_UserActivity oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_UserActivity();

			oTable.User_ID=int.Parse(DBConnection.ResultTable.Rows[0]["User_ID"].ToString());
			oTable.Organization_Code=int.Parse(DBConnection.ResultTable.Rows[0]["Organization_Code"].ToString());
			oTable.UserActivityType=int.Parse(DBConnection.ResultTable.Rows[0]["UserActivityType"].ToString());
			oTable.Time=DateTime.Parse(DBConnection.ResultTable.Rows[0]["Time"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserActivityType] , [Time] From [dbo].[tbl_UserActivity] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_UserActivity> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [User_ID] , [Organization_Code] , [UserActivityType] , [Time] From [dbo].[tbl_UserActivity]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_UserActivity> lstTable = new List<tbl_UserActivity>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_UserActivity oTable = new tbl_UserActivity();
			oTable.User_ID=int.Parse(row["User_ID"].ToString());
			oTable.Organization_Code=int.Parse(row["Organization_Code"].ToString());
			oTable.UserActivityType=int.Parse(row["UserActivityType"].ToString());
			oTable.Time=DateTime.Parse(row["Time"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
