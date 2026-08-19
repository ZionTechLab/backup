//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_refStatus
{
	#region Fields
	public int Status_ID;
	public string Status;
	public bool isEnable_Task;
	public int Presentage;
	public bool isPresentageFixed;
	#endregion

	#region Constructors
	public tbl_refStatus() {	 }

	public tbl_refStatus(int Status_ID,string Status,bool isEnable_Task,int Presentage,bool isPresentageFixed)
	{
		this.Status_ID=Status_ID;
		this.Status=Status;
		this.isEnable_Task=isEnable_Task;
		this.Presentage=Presentage;
		this.isPresentageFixed=isPresentageFixed;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_refStatus] ([Status_ID] , [Status] , [isEnable_Task] , [Presentage] , [isPresentageFixed]) VALUES ("+Status_ID+" , '"+Status+"' , '"+isEnable_Task+"' , "+Presentage+" , '"+isPresentageFixed+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_refStatus] SET [Status_ID] = "+Status_ID+" , [Status] = '"+Status+"' , [isEnable_Task] = '"+isEnable_Task+"' , [Presentage] = "+Presentage+" , [isPresentageFixed] = '"+isPresentageFixed+"' WHERE [Status_ID] = "+Status_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_refStatus] Where [Status_ID] = "+Status_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_refStatus Select(int PStatus_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Status_ID] , [Status] , [isEnable_Task] , [Presentage] , [isPresentageFixed] From [dbo].[tbl_refStatus] Where [Status_ID] = '"+PStatus_ID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_refStatus oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_refStatus();

			oTable.Status_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Status_ID"].ToString());
			oTable.Status=DBConnection.ResultTable.Rows[0]["Status"].ToString();
			oTable.isEnable_Task=bool.Parse(DBConnection.ResultTable.Rows[0]["isEnable_Task"].ToString());
			oTable.Presentage=int.Parse(DBConnection.ResultTable.Rows[0]["Presentage"].ToString());
			oTable.isPresentageFixed=bool.Parse(DBConnection.ResultTable.Rows[0]["isPresentageFixed"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Status_ID] , [Status] , [isEnable_Task] , [Presentage] , [isPresentageFixed] From [dbo].[tbl_refStatus] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_refStatus> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Status_ID] , [Status] , [isEnable_Task] , [Presentage] , [isPresentageFixed] From [dbo].[tbl_refStatus]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_refStatus> lstTable = new List<tbl_refStatus>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_refStatus oTable = new tbl_refStatus();
			oTable.Status_ID=int.Parse(row["Status_ID"].ToString());
			oTable.Status=row["Status"].ToString();
			oTable.isEnable_Task=bool.Parse(row["isEnable_Task"].ToString());
			oTable.Presentage=int.Parse(row["Presentage"].ToString());
			oTable.isPresentageFixed=bool.Parse(row["isPresentageFixed"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
