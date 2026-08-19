//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_ptsTasksTracker
{
	#region Fields
	public int ActivitySerialNo;
	public int Task_ID;
	public DateTime DateTime;
	public int Activity;
	public int User_ID;
	public int Terminal_ID;
	#endregion

	#region Constructors
	public tbl_ptsTasksTracker() {	 }

	public tbl_ptsTasksTracker(int ActivitySerialNo,int Task_ID,DateTime DateTime,int Activity,int User_ID,int Terminal_ID)
	{
		this.ActivitySerialNo=ActivitySerialNo;
		this.Task_ID=Task_ID;
		this.DateTime=DateTime;
		this.Activity=Activity;
		this.User_ID=User_ID;
		this.Terminal_ID=Terminal_ID;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_ptsTasksTracker] ([Task_ID] , [DateTime] , [Activity] , [User_ID] , [Terminal_ID]) VALUES ("+Task_ID+" , '"+DateTime+"' , "+Activity+" , "+User_ID+" , "+Terminal_ID+")";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_ptsTasksTracker] SET [Task_ID] = "+Task_ID+" , [DateTime] = '"+DateTime+"' , [Activity] = "+Activity+" , [User_ID] = "+User_ID+" , [Terminal_ID] = "+Terminal_ID+" WHERE [ActivitySerialNo] = "+ActivitySerialNo+" , [Task_ID] = "+Task_ID+" , [DateTime] = '"+DateTime+"'";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_ptsTasksTracker] Where [ActivitySerialNo] = "+ActivitySerialNo+" , [Task_ID] = "+Task_ID+" , [DateTime] = '"+DateTime+"'";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_ptsTasksTracker Select(int PActivitySerialNo , int PTask_ID , DateTime PDateTime)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [ActivitySerialNo] , [Task_ID] , [DateTime] , [Activity] , [User_ID] , [Terminal_ID] From [dbo].[tbl_ptsTasksTracker] Where [ActivitySerialNo] = '"+PActivitySerialNo+"' , [Task_ID] = '"+PTask_ID+"' , [DateTime] = '"+PDateTime+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_ptsTasksTracker oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_ptsTasksTracker();

			oTable.ActivitySerialNo=int.Parse(DBConnection.ResultTable.Rows[0]["ActivitySerialNo"].ToString());
			oTable.Task_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Task_ID"].ToString());
			oTable.DateTime=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateTime"].ToString());
			oTable.Activity=int.Parse(DBConnection.ResultTable.Rows[0]["Activity"].ToString());
			oTable.User_ID=int.Parse(DBConnection.ResultTable.Rows[0]["User_ID"].ToString());
			oTable.Terminal_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Terminal_ID"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [DateTime] , [Activity] , [User_ID] , [Terminal_ID] From [dbo].[tbl_ptsTasksTracker] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_ptsTasksTracker> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [ActivitySerialNo] , [Task_ID] , [DateTime] , [Activity] , [User_ID] , [Terminal_ID] From [dbo].[tbl_ptsTasksTracker]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTasksTracker> lstTable = new List<tbl_ptsTasksTracker>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTasksTracker oTable = new tbl_ptsTasksTracker();
			oTable.ActivitySerialNo=int.Parse(row["ActivitySerialNo"].ToString());
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.DateTime=DateTime.Parse(row["DateTime"].ToString());
			oTable.Activity=int.Parse(row["Activity"].ToString());
			oTable.User_ID=int.Parse(row["User_ID"].ToString());
			oTable.Terminal_ID=int.Parse(row["Terminal_ID"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
