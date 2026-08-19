//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_altAlert_Shedule
{
	#region Fields
	public int Shedule_ID;
	public int alert_ID;
	public DateTime sheduledTime;
	public DateTime lastAlert_SentTime;
	public DateTime NextSheduledTime;
	public bool isDaily;
	public bool isWeekly;
	public bool isMonthly;
	public bool isYearly;
	public bool isActive;
	#endregion

	#region Constructors
	public tbl_altAlert_Shedule() {	 }

	public tbl_altAlert_Shedule(int Shedule_ID,int alert_ID,DateTime sheduledTime,DateTime lastAlert_SentTime,DateTime NextSheduledTime,bool isDaily,bool isWeekly,bool isMonthly,bool isYearly,bool isActive)
	{
		this.Shedule_ID=Shedule_ID;
		this.alert_ID=alert_ID;
		this.sheduledTime=sheduledTime;
		this.lastAlert_SentTime=lastAlert_SentTime;
		this.NextSheduledTime=NextSheduledTime;
		this.isDaily=isDaily;
		this.isWeekly=isWeekly;
		this.isMonthly=isMonthly;
		this.isYearly=isYearly;
		this.isActive=isActive;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_altAlert_Shedule] ([Shedule_ID] , [alert_ID] , [sheduledTime] , [lastAlert_SentTime] , [NextSheduledTime] , [isDaily] , [isWeekly] , [isMonthly] , [isYearly] , [isActive]) VALUES ("+Shedule_ID+" , "+alert_ID+" , '"+sheduledTime+"' , '"+lastAlert_SentTime+"' , '"+NextSheduledTime+"' , '"+isDaily+"' , '"+isWeekly+"' , '"+isMonthly+"' , '"+isYearly+"' , '"+isActive+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_altAlert_Shedule] SET [Shedule_ID] = "+Shedule_ID+" , [alert_ID] = "+alert_ID+" , [sheduledTime] = '"+sheduledTime+"' , [lastAlert_SentTime] = '"+lastAlert_SentTime+"' , [NextSheduledTime] = '"+NextSheduledTime+"' , [isDaily] = '"+isDaily+"' , [isWeekly] = '"+isWeekly+"' , [isMonthly] = '"+isMonthly+"' , [isYearly] = '"+isYearly+"' , [isActive] = '"+isActive+"' WHERE [Shedule_ID] = "+Shedule_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_altAlert_Shedule] Where [Shedule_ID] = "+Shedule_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_altAlert_Shedule Select(int PShedule_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [alert_ID] , [sheduledTime] , [lastAlert_SentTime] , [NextSheduledTime] , [isDaily] , [isWeekly] , [isMonthly] , [isYearly] , [isActive] From [dbo].[tbl_altAlert_Shedule] Where [Shedule_ID] = '"+PShedule_ID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_altAlert_Shedule oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_altAlert_Shedule();

			oTable.Shedule_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Shedule_ID"].ToString());
			oTable.alert_ID=int.Parse(DBConnection.ResultTable.Rows[0]["alert_ID"].ToString());
			oTable.sheduledTime=DateTime.Parse(DBConnection.ResultTable.Rows[0]["sheduledTime"].ToString());
			oTable.lastAlert_SentTime=DateTime.Parse(DBConnection.ResultTable.Rows[0]["lastAlert_SentTime"].ToString());
			oTable.NextSheduledTime=DateTime.Parse(DBConnection.ResultTable.Rows[0]["NextSheduledTime"].ToString());
			oTable.isDaily=bool.Parse(DBConnection.ResultTable.Rows[0]["isDaily"].ToString());
			oTable.isWeekly=bool.Parse(DBConnection.ResultTable.Rows[0]["isWeekly"].ToString());
			oTable.isMonthly=bool.Parse(DBConnection.ResultTable.Rows[0]["isMonthly"].ToString());
			oTable.isYearly=bool.Parse(DBConnection.ResultTable.Rows[0]["isYearly"].ToString());
			oTable.isActive=bool.Parse(DBConnection.ResultTable.Rows[0]["isActive"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [alert_ID] , [sheduledTime] , [lastAlert_SentTime] , [NextSheduledTime] , [isDaily] , [isWeekly] , [isMonthly] , [isYearly] , [isActive] From [dbo].[tbl_altAlert_Shedule] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_altAlert_Shedule> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Shedule_ID] , [alert_ID] , [sheduledTime] , [lastAlert_SentTime] , [NextSheduledTime] , [isDaily] , [isWeekly] , [isMonthly] , [isYearly] , [isActive] From [dbo].[tbl_altAlert_Shedule]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_altAlert_Shedule> lstTable = new List<tbl_altAlert_Shedule>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_altAlert_Shedule oTable = new tbl_altAlert_Shedule();
			oTable.Shedule_ID=int.Parse(row["Shedule_ID"].ToString());
			oTable.alert_ID=int.Parse(row["alert_ID"].ToString());
			oTable.sheduledTime=DateTime.Parse(row["sheduledTime"].ToString());
			oTable.lastAlert_SentTime=DateTime.Parse(row["lastAlert_SentTime"].ToString());
			oTable.NextSheduledTime=DateTime.Parse(row["NextSheduledTime"].ToString());
			oTable.isDaily=bool.Parse(row["isDaily"].ToString());
			oTable.isWeekly=bool.Parse(row["isWeekly"].ToString());
			oTable.isMonthly=bool.Parse(row["isMonthly"].ToString());
			oTable.isYearly=bool.Parse(row["isYearly"].ToString());
			oTable.isActive=bool.Parse(row["isActive"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
