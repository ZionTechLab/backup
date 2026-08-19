//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class proc_Tasktracking
{
	#region Fields
	public int Task_ID;
	public int ActivityType;
	public DateTime DateCreate;
	public string Narration;
	#endregion

	#region Constructors
	public proc_Tasktracking() {	 }

	public proc_Tasktracking(int Task_ID,int ActivityType,DateTime DateCreate,string Narration)
	{
		this.Task_ID=Task_ID;
		this.ActivityType=ActivityType;
		this.DateCreate=DateCreate;
		this.Narration=Narration;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[proc_Tasktracking1] ([Task_ID] , [ActivityType] , [DateCreate] , [Narration]) VALUES ("+Task_ID+" , "+ActivityType+" , '"+DateCreate+"' , '"+Narration+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[proc_Tasktracking1] SET [Task_ID] = "+Task_ID+" , [ActivityType] = "+ActivityType+" , [DateCreate] = '"+DateCreate+"' , [Narration] = '"+Narration+"' WHERE [Task_ID] = "+Task_ID+" , [ActivityType] = "+ActivityType+" , [DateCreate] = '"+DateCreate+"'";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[proc_Tasktracking1] Where [Task_ID] = "+Task_ID+" , [ActivityType] = "+ActivityType+" , [DateCreate] = '"+DateCreate+"'";
		return DBConnection.Execute_Quary(sScript);
	}

	public static proc_Tasktracking Select(int PTask_ID , int PActivityType , DateTime PDateCreate)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [ActivityType] , [DateCreate] , [Narration] From [dbo].[proc_Tasktracking1] Where [Task_ID] = '"+PTask_ID+"' , [ActivityType] = '"+PActivityType+"' , [DateCreate] = '"+PDateCreate+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			proc_Tasktracking oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new proc_Tasktracking();

			oTable.Task_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Task_ID"].ToString());
			oTable.ActivityType=int.Parse(DBConnection.ResultTable.Rows[0]["ActivityType"].ToString());
			oTable.DateCreate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateCreate"].ToString());
			oTable.Narration=DBConnection.ResultTable.Rows[0]["Narration"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [ActivityType] , [DateCreate] , [Narration] From [dbo].[proc_Tasktracking1] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<proc_Tasktracking> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [ActivityType] , [DateCreate] , [Narration] From [dbo].[proc_Tasktracking1]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<proc_Tasktracking> lstTable = new List<proc_Tasktracking>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			proc_Tasktracking oTable = new proc_Tasktracking();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.ActivityType=int.Parse(row["ActivityType"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.Narration=row["Narration"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public static List<proc_Tasktracking> SelectAllByTask_ID(int PTask_ID)
	{
		dbConnection DBConnection = new dbConnection();
        string sScript = "exec proc_Tasktracking '" + PTask_ID + "'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<proc_Tasktracking> lstTable = new List<proc_Tasktracking>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			proc_Tasktracking oTable = new proc_Tasktracking();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.ActivityType=int.Parse(row["ActivityType"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.Narration=row["Narration"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableTask_ID(int PTask_ID)
	{
		dbConnection DBConnection = new dbConnection();
        string sScript = "exec proc_Tasktracking '" + PTask_ID + "'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
            return DBConnection.ResultTable;
			
		else
            return null;
	}

	#endregion
}
