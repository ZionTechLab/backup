//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_ptsTimeSheet
{
	#region Fields
	public int TS_ID;
	public DateTime TS_Date;
	public int Task_ID;
	public int User_ID;
	public int Organization_ID;
	public int Branch_ID;
	public string Remarks;
	public int Activity_ID;
	public int TS_Activity_Minutes;
	public int TS_Utilized_Mts;
	public int TS_Accum_Mts;
	public int CreateUser_ID;
	public int ModifiedUser_ID;
	public int CheckedUser_ID;
	public int ApprovedUser_ID;
	public int DeletedUser_ID;
	public DateTime DateCreate;
	public DateTime DateModified;
	public DateTime DateChecked;
	public DateTime DateApproved;
	public DateTime DateDeleted;
	public bool IsChecked;
	public bool IsApproved;
	public bool IsDeleted;
	public string CreateTerminal_ID;
	public string ModifiedTerminal_ID;
	public string DeletedTerminal_ID;
	public string CheckedTerminal_ID;
	public string ApprovedTerminal_ID;
	#endregion

	#region Constructors
	public tbl_ptsTimeSheet() {	 }

	public tbl_ptsTimeSheet(int TS_ID,DateTime TS_Date,int Task_ID,int User_ID,int Organization_ID,int Branch_ID,string Remarks,int Activity_ID,int TS_Activity_Minutes,int TS_Utilized_Mts,int TS_Accum_Mts,int CreateUser_ID,int ModifiedUser_ID,int CheckedUser_ID,int ApprovedUser_ID,int DeletedUser_ID,DateTime DateCreate,DateTime DateModified,DateTime DateChecked,DateTime DateApproved,DateTime DateDeleted,bool IsChecked,bool IsApproved,bool IsDeleted,string CreateTerminal_ID,string ModifiedTerminal_ID,string DeletedTerminal_ID,string CheckedTerminal_ID,string ApprovedTerminal_ID)
	{
		this.TS_ID=TS_ID;
		this.TS_Date=TS_Date;
		this.Task_ID=Task_ID;
		this.User_ID=User_ID;
		this.Organization_ID=Organization_ID;
		this.Branch_ID=Branch_ID;
		this.Remarks=Remarks;
		this.Activity_ID=Activity_ID;
		this.TS_Activity_Minutes=TS_Activity_Minutes;
		this.TS_Utilized_Mts=TS_Utilized_Mts;
		this.TS_Accum_Mts=TS_Accum_Mts;
		this.CreateUser_ID=CreateUser_ID;
		this.ModifiedUser_ID=ModifiedUser_ID;
		this.CheckedUser_ID=CheckedUser_ID;
		this.ApprovedUser_ID=ApprovedUser_ID;
		this.DeletedUser_ID=DeletedUser_ID;
		this.DateCreate=DateCreate;
		this.DateModified=DateModified;
		this.DateChecked=DateChecked;
		this.DateApproved=DateApproved;
		this.DateDeleted=DateDeleted;
		this.IsChecked=IsChecked;
		this.IsApproved=IsApproved;
		this.IsDeleted=IsDeleted;
		this.CreateTerminal_ID=CreateTerminal_ID;
		this.ModifiedTerminal_ID=ModifiedTerminal_ID;
		this.DeletedTerminal_ID=DeletedTerminal_ID;
		this.CheckedTerminal_ID=CheckedTerminal_ID;
		this.ApprovedTerminal_ID=ApprovedTerminal_ID;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_ptsTimeSheet] ([TS_Date] , [Task_ID] , [User_ID] , [Organization_ID] , [Branch_ID] , [Remarks] , [Activity_ID] , [TS_Activity_Minutes] , [TS_Utilized_Mts] , [TS_Accum_Mts] , [CreateUser_ID] , [ModifiedUser_ID] , [CheckedUser_ID] , [ApprovedUser_ID] , [DeletedUser_ID] , [DateCreate] , [DateModified] , [DateChecked] , [DateApproved] , [DateDeleted] , [IsChecked] , [IsApproved] , [IsDeleted] , [CreateTerminal_ID] , [ModifiedTerminal_ID] , [DeletedTerminal_ID] , [CheckedTerminal_ID] , [ApprovedTerminal_ID]) VALUES ('"+TS_Date+"' , "+Task_ID+" , "+User_ID+" , "+Organization_ID+" , "+Branch_ID+" , '"+Remarks+"' , "+Activity_ID+" , "+TS_Activity_Minutes+" , "+TS_Utilized_Mts+" , "+TS_Accum_Mts+" , "+CreateUser_ID+" , "+ModifiedUser_ID+" , "+CheckedUser_ID+" , "+ApprovedUser_ID+" , "+DeletedUser_ID+" , '"+DateCreate+"' , '"+DateModified+"' , '"+DateChecked+"' , '"+DateApproved+"' , '"+DateDeleted+"' , '"+IsChecked+"' , '"+IsApproved+"' , '"+IsDeleted+"' , '"+CreateTerminal_ID+"' , '"+ModifiedTerminal_ID+"' , '"+DeletedTerminal_ID+"' , '"+CheckedTerminal_ID+"' , '"+ApprovedTerminal_ID+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_ptsTimeSheet] SET [TS_Date] = '"+TS_Date+"' , [Task_ID] = "+Task_ID+" , [User_ID] = "+User_ID+" , [Organization_ID] = "+Organization_ID+" , [Branch_ID] = "+Branch_ID+" , [Remarks] = '"+Remarks+"' , [Activity_ID] = "+Activity_ID+" , [TS_Activity_Minutes] = "+TS_Activity_Minutes+" , [TS_Utilized_Mts] = "+TS_Utilized_Mts+" , [TS_Accum_Mts] = "+TS_Accum_Mts+" , [CreateUser_ID] = "+CreateUser_ID+" , [ModifiedUser_ID] = "+ModifiedUser_ID+" , [CheckedUser_ID] = "+CheckedUser_ID+" , [ApprovedUser_ID] = "+ApprovedUser_ID+" , [DeletedUser_ID] = "+DeletedUser_ID+" , [DateCreate] = '"+DateCreate+"' , [DateModified] = '"+DateModified+"' , [DateChecked] = '"+DateChecked+"' , [DateApproved] = '"+DateApproved+"' , [DateDeleted] = '"+DateDeleted+"' , [IsChecked] = '"+IsChecked+"' , [IsApproved] = '"+IsApproved+"' , [IsDeleted] = '"+IsDeleted+"' , [CreateTerminal_ID] = '"+CreateTerminal_ID+"' , [ModifiedTerminal_ID] = '"+ModifiedTerminal_ID+"' , [DeletedTerminal_ID] = '"+DeletedTerminal_ID+"' , [CheckedTerminal_ID] = '"+CheckedTerminal_ID+"' , [ApprovedTerminal_ID] = '"+ApprovedTerminal_ID+"' WHERE [TS_ID] = "+TS_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_ptsTimeSheet] Where [TS_ID] = "+TS_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_ptsTimeSheet Select(int PTS_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [TS_ID] , [TS_Date] , [Task_ID] , [User_ID] , [Organization_ID] , [Branch_ID] , [Remarks] , [Activity_ID] , [TS_Activity_Minutes] , [TS_Utilized_Mts] , [TS_Accum_Mts] , [CreateUser_ID] , [ModifiedUser_ID] , [CheckedUser_ID] , [ApprovedUser_ID] , [DeletedUser_ID] , [DateCreate] , [DateModified] , [DateChecked] , [DateApproved] , [DateDeleted] , [IsChecked] , [IsApproved] , [IsDeleted] , [CreateTerminal_ID] , [ModifiedTerminal_ID] , [DeletedTerminal_ID] , [CheckedTerminal_ID] , [ApprovedTerminal_ID] From [dbo].[tbl_ptsTimeSheet] Where [TS_ID] = '"+PTS_ID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_ptsTimeSheet oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_ptsTimeSheet();

			oTable.TS_ID=int.Parse(DBConnection.ResultTable.Rows[0]["TS_ID"].ToString());
			oTable.TS_Date=DateTime.Parse(DBConnection.ResultTable.Rows[0]["TS_Date"].ToString());
			oTable.Task_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Task_ID"].ToString());
			oTable.User_ID=int.Parse(DBConnection.ResultTable.Rows[0]["User_ID"].ToString());
			oTable.Organization_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Branch_ID"].ToString());
			oTable.Remarks=DBConnection.ResultTable.Rows[0]["Remarks"].ToString();
			oTable.Activity_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Activity_ID"].ToString());
			oTable.TS_Activity_Minutes=int.Parse(DBConnection.ResultTable.Rows[0]["TS_Activity_Minutes"].ToString());
			oTable.TS_Utilized_Mts=int.Parse(DBConnection.ResultTable.Rows[0]["TS_Utilized_Mts"].ToString());
			oTable.TS_Accum_Mts=int.Parse(DBConnection.ResultTable.Rows[0]["TS_Accum_Mts"].ToString());
			oTable.CreateUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["ModifiedUser_ID"].ToString());
			oTable.CheckedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["CheckedUser_ID"].ToString());
			oTable.ApprovedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["ApprovedUser_ID"].ToString());
			oTable.DeletedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["DeletedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateModified"].ToString());
			oTable.DateChecked=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateChecked"].ToString());
			oTable.DateApproved=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateApproved"].ToString());
			oTable.DateDeleted=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateDeleted"].ToString());
			oTable.IsChecked=bool.Parse(DBConnection.ResultTable.Rows[0]["IsChecked"].ToString());
			oTable.IsApproved=bool.Parse(DBConnection.ResultTable.Rows[0]["IsApproved"].ToString());
			oTable.IsDeleted=bool.Parse(DBConnection.ResultTable.Rows[0]["IsDeleted"].ToString());
			oTable.CreateTerminal_ID=DBConnection.ResultTable.Rows[0]["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=DBConnection.ResultTable.Rows[0]["ModifiedTerminal_ID"].ToString();
			oTable.DeletedTerminal_ID=DBConnection.ResultTable.Rows[0]["DeletedTerminal_ID"].ToString();
			oTable.CheckedTerminal_ID=DBConnection.ResultTable.Rows[0]["CheckedTerminal_ID"].ToString();
			oTable.ApprovedTerminal_ID=DBConnection.ResultTable.Rows[0]["ApprovedTerminal_ID"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [TS_Date] , [Task_ID] , [User_ID] , [Organization_ID] , [Branch_ID] , [Remarks] , [Activity_ID] , [TS_Activity_Minutes] , [TS_Utilized_Mts] , [TS_Accum_Mts] , [CreateUser_ID] , [ModifiedUser_ID] , [CheckedUser_ID] , [ApprovedUser_ID] , [DeletedUser_ID] , [DateCreate] , [DateModified] , [DateChecked] , [DateApproved] , [DateDeleted] , [IsChecked] , [IsApproved] , [IsDeleted] , [CreateTerminal_ID] , [ModifiedTerminal_ID] , [DeletedTerminal_ID] , [CheckedTerminal_ID] , [ApprovedTerminal_ID] From [dbo].[tbl_ptsTimeSheet] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_ptsTimeSheet> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [TS_ID] , [TS_Date] , [Task_ID] , [User_ID] , [Organization_ID] , [Branch_ID] , [Remarks] , [Activity_ID] , [TS_Activity_Minutes] , [TS_Utilized_Mts] , [TS_Accum_Mts] , [CreateUser_ID] , [ModifiedUser_ID] , [CheckedUser_ID] , [ApprovedUser_ID] , [DeletedUser_ID] , [DateCreate] , [DateModified] , [DateChecked] , [DateApproved] , [DateDeleted] , [IsChecked] , [IsApproved] , [IsDeleted] , [CreateTerminal_ID] , [ModifiedTerminal_ID] , [DeletedTerminal_ID] , [CheckedTerminal_ID] , [ApprovedTerminal_ID] From [dbo].[tbl_ptsTimeSheet]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTimeSheet> lstTable = new List<tbl_ptsTimeSheet>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTimeSheet oTable = new tbl_ptsTimeSheet();
			oTable.TS_ID=int.Parse(row["TS_ID"].ToString());
			oTable.TS_Date=DateTime.Parse(row["TS_Date"].ToString());
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.User_ID=int.Parse(row["User_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(row["Branch_ID"].ToString());
			oTable.Remarks=row["Remarks"].ToString();
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.TS_Activity_Minutes=int.Parse(row["TS_Activity_Minutes"].ToString());
			oTable.TS_Utilized_Mts=int.Parse(row["TS_Utilized_Mts"].ToString());
			oTable.TS_Accum_Mts=int.Parse(row["TS_Accum_Mts"].ToString());
			oTable.CreateUser_ID=int.Parse(row["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(row["ModifiedUser_ID"].ToString());
			oTable.CheckedUser_ID=int.Parse(row["CheckedUser_ID"].ToString());
			oTable.ApprovedUser_ID=int.Parse(row["ApprovedUser_ID"].ToString());
			oTable.DeletedUser_ID=int.Parse(row["DeletedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(row["DateModified"].ToString());
			oTable.DateChecked=DateTime.Parse(row["DateChecked"].ToString());
			oTable.DateApproved=DateTime.Parse(row["DateApproved"].ToString());
			oTable.DateDeleted=DateTime.Parse(row["DateDeleted"].ToString());
			oTable.IsChecked=bool.Parse(row["IsChecked"].ToString());
			oTable.IsApproved=bool.Parse(row["IsApproved"].ToString());
			oTable.IsDeleted=bool.Parse(row["IsDeleted"].ToString());
			oTable.CreateTerminal_ID=row["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=row["ModifiedTerminal_ID"].ToString();
			oTable.DeletedTerminal_ID=row["DeletedTerminal_ID"].ToString();
			oTable.CheckedTerminal_ID=row["CheckedTerminal_ID"].ToString();
			oTable.ApprovedTerminal_ID=row["ApprovedTerminal_ID"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public static List<tbl_ptsTimeSheet> SelectAllByTask_ID(int PTask_ID)
	{
		dbConnection DBConnection = new dbConnection();
        string sScript = "Select TS_ID,[TS_Date] , [Task_ID] , [User_ID] , [Organization_ID] , [Branch_ID] , [Remarks] , [Activity_ID] , [TS_Activity_Minutes] , [TS_Utilized_Mts] , [TS_Accum_Mts] , [CreateUser_ID] , [ModifiedUser_ID] , [CheckedUser_ID] , [ApprovedUser_ID] , [DeletedUser_ID] , [DateCreate] , [DateModified] , [DateChecked] , [DateApproved] , [DateDeleted] , [IsChecked] , [IsApproved] , [IsDeleted] , [CreateTerminal_ID] , [ModifiedTerminal_ID] , [DeletedTerminal_ID] , [CheckedTerminal_ID] , [ApprovedTerminal_ID] From [dbo].[tbl_ptsTimeSheet] Where [Task_ID] = '" + PTask_ID + "'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTimeSheet> lstTable = new List<tbl_ptsTimeSheet>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTimeSheet oTable = new tbl_ptsTimeSheet();
			oTable.TS_ID=int.Parse(row["TS_ID"].ToString());
			oTable.TS_Date=DateTime.Parse(row["TS_Date"].ToString());
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.User_ID=int.Parse(row["User_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(row["Branch_ID"].ToString());
			oTable.Remarks=row["Remarks"].ToString();
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.TS_Activity_Minutes=int.Parse(row["TS_Activity_Minutes"].ToString());
			oTable.TS_Utilized_Mts=int.Parse(row["TS_Utilized_Mts"].ToString());
			oTable.TS_Accum_Mts=int.Parse(row["TS_Accum_Mts"].ToString());
			oTable.CreateUser_ID=int.Parse(row["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(row["ModifiedUser_ID"].ToString());
			oTable.CheckedUser_ID=int.Parse(row["CheckedUser_ID"].ToString());
			oTable.ApprovedUser_ID=int.Parse(row["ApprovedUser_ID"].ToString());
			oTable.DeletedUser_ID=int.Parse(row["DeletedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(row["DateModified"].ToString());
			oTable.DateChecked=DateTime.Parse(row["DateChecked"].ToString());
			oTable.DateApproved=DateTime.Parse(row["DateApproved"].ToString());
			oTable.DateDeleted=DateTime.Parse(row["DateDeleted"].ToString());
			oTable.IsChecked=bool.Parse(row["IsChecked"].ToString());
			oTable.IsApproved=bool.Parse(row["IsApproved"].ToString());
			oTable.IsDeleted=bool.Parse(row["IsDeleted"].ToString());
			oTable.CreateTerminal_ID=row["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=row["ModifiedTerminal_ID"].ToString();
			oTable.DeletedTerminal_ID=row["DeletedTerminal_ID"].ToString();
			oTable.CheckedTerminal_ID=row["CheckedTerminal_ID"].ToString();
			oTable.ApprovedTerminal_ID=row["ApprovedTerminal_ID"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

    public DataTable SelectAll_Table2()
    {
        dbConnection DBConnection = new dbConnection(); 
        //string sScript = "SELECT PTS.TS_ID,cast(cast(PTS.TS_Date as date)as datetime) TS_Date, PTS.Task_ID, PTS.[CreateUser_ID],  TASK.Task,PTS.Remarks,PTS.TS_Activity_Minutes FROM tbl_ptsTimeSheet AS PTS LEFT OUTER JOIN tbl_ptsTasks AS TASK ON PTS.Task_ID = TASK.Task_ID";

        string sScript = "SELECT        PTS.TS_ID, CAST(CAST(PTS.TS_Date AS date) AS datetime) AS TS_Date, PTS.Task_ID, PTS.CreateUser_ID, TASK.Task, PTS.Remarks, PTS.TS_Activity_Minutes, dbo.ConvertToTimeFormat(PTS.TS_Activity_Minutes) TS_Activity_Hours,                         TASK.Estimate_Minutes,dbo.ConvertToTimeFormat(TASK.Estimate_Minutes) Estimate_Hours, dbo.GetAccumulatedMinits(PTS.Task_ID,PTS.TS_ID,PTS.TS_Date) Accumulated_Minits, dbo.ConvertToTimeFormat(dbo.GetAccumulatedMinits(PTS.Task_ID,PTS.TS_ID,PTS.TS_Date)) Accumulated_Hours FROM            tbl_ptsTimeSheet AS PTS LEFT OUTER JOIN                         tbl_ptsTasks AS TASK ON PTS.Task_ID = TASK.Task_ID";
        bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
        if (bQuaryStatus2)
            return DBConnection.ResultTable;
        else
            return null;
    }

	public DataTable SelectAllBy_TableTask_ID(int PTask_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [TS_Date] , [Task_ID] , [User_ID] , [Organization_ID] , [Branch_ID] , [Remarks] , [Activity_ID] , [TS_Activity_Minutes] , [TS_Utilized_Mts] , [TS_Accum_Mts] , [CreateUser_ID] , [ModifiedUser_ID] , [CheckedUser_ID] , [ApprovedUser_ID] , [DeletedUser_ID] , [DateCreate] , [DateModified] , [DateChecked] , [DateApproved] , [DateDeleted] , [IsChecked] , [IsApproved] , [IsDeleted] , [CreateTerminal_ID] , [ModifiedTerminal_ID] , [DeletedTerminal_ID] , [CheckedTerminal_ID] , [ApprovedTerminal_ID] From [dbo].[tbl_ptsTimeSheet] Where [Task_ID] = '"+PTask_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	#endregion
}
