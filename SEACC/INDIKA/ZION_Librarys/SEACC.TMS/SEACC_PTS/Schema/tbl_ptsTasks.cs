//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_ptsTasks
{
	#region Fields
	public int Task_ID;
	public int Organization_ID;
	public int Branch_ID;
	public int Main_Task_ID;
	public string Task;
	public string Task_Desc;
	public string TestCases;
	public string DevComments;
	public string Reference_1;
	public int Client_ID;
	public DateTime ReportedDate;
	public string ReportedBy;
	public int Prod_ID;
	public int Function_ID;
	public int Activity_ID;
	public int Type_ID;
	public int Status_ID;
	public int Progress;
	public int Assign_To;
	public int Estimate_Minutes;
	public int Priority;
	public DateTime Deadline;
	public decimal ActualHours;
	public int CreateUser_ID;
	public int ModifiedUser_ID;
	public DateTime DateCreate;
	public DateTime DateModified;
	public string CreateTerminal_ID;
	public string ModifiedTerminal_ID;
	#endregion

	#region Constructors
	public tbl_ptsTasks() {	 }

	public tbl_ptsTasks(int Task_ID,int Organization_ID,int Branch_ID,int Main_Task_ID,string Task,string Task_Desc,string TestCases,string DevComments,string Reference_1,int Client_ID,DateTime ReportedDate,string ReportedBy,int Prod_ID,int Function_ID,int Activity_ID,int Type_ID,int Status_ID,int Progress,int Assign_To,int Estimate_Minutes,int Priority,DateTime Deadline,decimal ActualHours,int CreateUser_ID,int ModifiedUser_ID,DateTime DateCreate,DateTime DateModified,string CreateTerminal_ID,string ModifiedTerminal_ID)
	{
		this.Task_ID=Task_ID;
		this.Organization_ID=Organization_ID;
		this.Branch_ID=Branch_ID;
		this.Main_Task_ID=Main_Task_ID;
		this.Task=Task;
		this.Task_Desc=Task_Desc;
		this.TestCases=TestCases;
		this.DevComments=DevComments;
		this.Reference_1=Reference_1;
		this.Client_ID=Client_ID;
		this.ReportedDate=ReportedDate;
		this.ReportedBy=ReportedBy;
		this.Prod_ID=Prod_ID;
		this.Function_ID=Function_ID;
		this.Activity_ID=Activity_ID;
		this.Type_ID=Type_ID;
		this.Status_ID=Status_ID;
		this.Progress=Progress;
		this.Assign_To=Assign_To;
		this.Estimate_Minutes=Estimate_Minutes;
		this.Priority=Priority;
		this.Deadline=Deadline;
		this.ActualHours=ActualHours;
		this.CreateUser_ID=CreateUser_ID;
		this.ModifiedUser_ID=ModifiedUser_ID;
		this.DateCreate=DateCreate;
		this.DateModified=DateModified;
		this.CreateTerminal_ID=CreateTerminal_ID;
		this.ModifiedTerminal_ID=ModifiedTerminal_ID;
	}
	#endregion

	#region Methods
    public string Insert()
    {
        bool status = false;
        dbConnection DBConnection = new dbConnection();
        string sScript = "INSERT INTO [dbo].[tbl_ptsTasks] ([Organization_ID] , [Branch_ID] ,Main_Task_ID, [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID]) VALUES (" + Organization_ID + " , " + Branch_ID + " , " + Main_Task_ID + " , '" + Task + "' , '" + Task_Desc + "' , '" + TestCases + "' , '" + DevComments + "' , '" + Reference_1 + "' , " + Client_ID + " , '" + ReportedDate + "' , '" + ReportedBy + "' , " + Prod_ID + " , " + Function_ID + " , " + Activity_ID + " , " + Type_ID + " , " + Status_ID + " , " + Progress + " , " + Assign_To + " , " + Estimate_Minutes + " , " + Priority + " , '" + Deadline + "' , " + ActualHours + " , " + CreateUser_ID + " , " + ModifiedUser_ID + " , '" + DateCreate + "' , '" + DateModified + "' , '" + CreateTerminal_ID + "' , '" + ModifiedTerminal_ID + " ') select scope_identity()";
        return DBConnection.Execute_Quary(sScript, ref status);
    }

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_ptsTasks] SET [Organization_ID] = "+Organization_ID+" , [Branch_ID] = "+Branch_ID+" , [Main_Task_ID] = "+Main_Task_ID+" , [Task] = '"+Task+"' , [Task_Desc] = '"+Task_Desc+"' , [TestCases] = '"+TestCases+"' , [DevComments] = '"+DevComments+"' , [Reference_1] = '"+Reference_1+"' , [Client_ID] = "+Client_ID+" , [ReportedDate] = '"+ReportedDate+"' , [ReportedBy] = '"+ReportedBy+"' , [Prod_ID] = "+Prod_ID+" , [Function_ID] = "+Function_ID+" , [Activity_ID] = "+Activity_ID+" , [Type_ID] = "+Type_ID+" , [Status_ID] = "+Status_ID+" , [Progress] = "+Progress+" , [Assign_To] = "+Assign_To+" , [Estimate_Minutes] = "+Estimate_Minutes+" , [Priority] = "+Priority+" , [Deadline] = '"+Deadline+"' , [ActualHours] = "+ActualHours+" , [CreateUser_ID] = "+CreateUser_ID+" , [ModifiedUser_ID] = "+ModifiedUser_ID+" , [DateCreate] = '"+DateCreate+"' , [DateModified] = '"+DateModified+"' , [CreateTerminal_ID] = '"+CreateTerminal_ID+"' , [ModifiedTerminal_ID] = '"+ModifiedTerminal_ID+"' WHERE [Task_ID] = "+Task_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_ptsTasks] Where [Task_ID] = "+Task_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_ptsTasks Select(int PTask_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Task_ID] = '"+PTask_ID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_ptsTasks oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_ptsTasks();

			oTable.Task_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Task_ID"].ToString());
			oTable.Organization_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Branch_ID"].ToString());
			oTable.Main_Task_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Main_Task_ID"].ToString());
			oTable.Task=DBConnection.ResultTable.Rows[0]["Task"].ToString();
			oTable.Task_Desc=DBConnection.ResultTable.Rows[0]["Task_Desc"].ToString();
			oTable.TestCases=DBConnection.ResultTable.Rows[0]["TestCases"].ToString();
			oTable.DevComments=DBConnection.ResultTable.Rows[0]["DevComments"].ToString();
			oTable.Reference_1=DBConnection.ResultTable.Rows[0]["Reference_1"].ToString();
			oTable.Client_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Client_ID"].ToString());
			oTable.ReportedDate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["ReportedDate"].ToString());
			oTable.ReportedBy=DBConnection.ResultTable.Rows[0]["ReportedBy"].ToString();
			oTable.Prod_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Prod_ID"].ToString());
			oTable.Function_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Function_ID"].ToString());
			oTable.Activity_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Activity_ID"].ToString());
			oTable.Type_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Type_ID"].ToString());
			oTable.Status_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Status_ID"].ToString());
			oTable.Progress=int.Parse(DBConnection.ResultTable.Rows[0]["Progress"].ToString());
			oTable.Assign_To=int.Parse(DBConnection.ResultTable.Rows[0]["Assign_To"].ToString());
			oTable.Estimate_Minutes=int.Parse(DBConnection.ResultTable.Rows[0]["Estimate_Minutes"].ToString());
			oTable.Priority=int.Parse(DBConnection.ResultTable.Rows[0]["Priority"].ToString());
			oTable.Deadline=DateTime.Parse(DBConnection.ResultTable.Rows[0]["Deadline"].ToString());
			oTable.ActualHours=decimal.Parse(DBConnection.ResultTable.Rows[0]["ActualHours"].ToString());
			oTable.CreateUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["ModifiedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(DBConnection.ResultTable.Rows[0]["DateModified"].ToString());
			oTable.CreateTerminal_ID=DBConnection.ResultTable.Rows[0]["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=DBConnection.ResultTable.Rows[0]["ModifiedTerminal_ID"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

    public static List<tbl_ptsTasks> SelectAll()
    {
        dbConnection DBConnection = new dbConnection();
        string sScript = "Select [Task_ID] , [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks]";
        bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
        List<tbl_ptsTasks> lstTable = new List<tbl_ptsTasks>();
        if (bQuaryStatus2)
        {
            foreach (DataRow row in DBConnection.ResultTable.Rows)
            {
                tbl_ptsTasks oTable = new tbl_ptsTasks();
                oTable.Task_ID = int.Parse(row["Task_ID"].ToString());
                oTable.Organization_ID = int.Parse(row["Organization_ID"].ToString());
                oTable.Branch_ID = int.Parse(row["Branch_ID"].ToString());
                oTable.Main_Task_ID = int.Parse(row["Main_Task_ID"].ToString());
                oTable.Task = row["Task"].ToString();
                oTable.Task_Desc = row["Task_Desc"].ToString();
                oTable.TestCases = row["TestCases"].ToString();
                oTable.DevComments = row["DevComments"].ToString();
                oTable.Reference_1 = row["Reference_1"].ToString();
                oTable.Client_ID = int.Parse(row["Client_ID"].ToString());
                oTable.ReportedDate = DateTime.Parse(row["ReportedDate"].ToString());
                oTable.ReportedBy = row["ReportedBy"].ToString();
                oTable.Prod_ID = int.Parse(row["Prod_ID"].ToString());
                oTable.Function_ID = int.Parse(row["Function_ID"].ToString());
                oTable.Activity_ID = int.Parse(row["Activity_ID"].ToString());
                oTable.Type_ID = int.Parse(row["Type_ID"].ToString());
                oTable.Status_ID = int.Parse(row["Status_ID"].ToString());
                oTable.Progress = int.Parse(row["Progress"].ToString());
                oTable.Assign_To = int.Parse(row["Assign_To"].ToString());
                oTable.Estimate_Minutes = int.Parse(row["Estimate_Minutes"].ToString());
                oTable.Priority = int.Parse(row["Priority"].ToString());
                oTable.Deadline = DateTime.Parse(row["Deadline"].ToString());
                oTable.ActualHours = decimal.Parse(row["ActualHours"].ToString());
                oTable.CreateUser_ID = int.Parse(row["CreateUser_ID"].ToString());
                oTable.ModifiedUser_ID = int.Parse(row["ModifiedUser_ID"].ToString());
                oTable.DateCreate = DateTime.Parse(row["DateCreate"].ToString());
                oTable.DateModified = DateTime.Parse(row["DateModified"].ToString());
                oTable.CreateTerminal_ID = row["CreateTerminal_ID"].ToString();
                oTable.ModifiedTerminal_ID = row["ModifiedTerminal_ID"].ToString();

                lstTable.Add(oTable);
            }
        }
        return lstTable;
    }
    public static tbl_ptsTasks SelectAll2()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
        //List<tbl_ptsTasks> lstTable = new List<tbl_ptsTasks>();
        tbl_ptsTasks oTable = new tbl_ptsTasks();
        if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			//tbl_ptsTasks oTable = new tbl_ptsTasks();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(row["Branch_ID"].ToString());
			oTable.Main_Task_ID=int.Parse(row["Main_Task_ID"].ToString());
			oTable.Task=row["Task"].ToString();
			oTable.Task_Desc=row["Task_Desc"].ToString();
			oTable.TestCases=row["TestCases"].ToString();
			oTable.DevComments=row["DevComments"].ToString();
			oTable.Reference_1=row["Reference_1"].ToString();
			oTable.Client_ID=int.Parse(row["Client_ID"].ToString());
			oTable.ReportedDate=DateTime.Parse(row["ReportedDate"].ToString());
			oTable.ReportedBy=row["ReportedBy"].ToString();
			oTable.Prod_ID=int.Parse(row["Prod_ID"].ToString());
			oTable.Function_ID=int.Parse(row["Function_ID"].ToString());
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.Type_ID=int.Parse(row["Type_ID"].ToString());
			oTable.Status_ID=int.Parse(row["Status_ID"].ToString());
			oTable.Progress=int.Parse(row["Progress"].ToString());
			oTable.Assign_To=int.Parse(row["Assign_To"].ToString());
			oTable.Estimate_Minutes=int.Parse(row["Estimate_Minutes"].ToString());
			oTable.Priority=int.Parse(row["Priority"].ToString());
			oTable.Deadline=DateTime.Parse(row["Deadline"].ToString());
			oTable.ActualHours=decimal.Parse(row["ActualHours"].ToString());
			oTable.CreateUser_ID=int.Parse(row["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(row["ModifiedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(row["DateModified"].ToString());
			oTable.CreateTerminal_ID=row["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=row["ModifiedTerminal_ID"].ToString();

				//lstTable.add(oTable);
			}
		}
        //return lstTable;
        return oTable;
	}

	public static List<tbl_ptsTasks> SelectAllByStatus_ID(int PStatus_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Status_ID] = '"+PStatus_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTasks> lstTable = new List<tbl_ptsTasks>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTasks oTable = new tbl_ptsTasks();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(row["Branch_ID"].ToString());
			oTable.Main_Task_ID=int.Parse(row["Main_Task_ID"].ToString());
			oTable.Task=row["Task"].ToString();
			oTable.Task_Desc=row["Task_Desc"].ToString();
			oTable.TestCases=row["TestCases"].ToString();
			oTable.DevComments=row["DevComments"].ToString();
			oTable.Reference_1=row["Reference_1"].ToString();
			oTable.Client_ID=int.Parse(row["Client_ID"].ToString());
			oTable.ReportedDate=DateTime.Parse(row["ReportedDate"].ToString());
			oTable.ReportedBy=row["ReportedBy"].ToString();
			oTable.Prod_ID=int.Parse(row["Prod_ID"].ToString());
			oTable.Function_ID=int.Parse(row["Function_ID"].ToString());
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.Type_ID=int.Parse(row["Type_ID"].ToString());
			oTable.Status_ID=int.Parse(row["Status_ID"].ToString());
			oTable.Progress=int.Parse(row["Progress"].ToString());
			oTable.Assign_To=int.Parse(row["Assign_To"].ToString());
			oTable.Estimate_Minutes=int.Parse(row["Estimate_Minutes"].ToString());
			oTable.Priority=int.Parse(row["Priority"].ToString());
			oTable.Deadline=DateTime.Parse(row["Deadline"].ToString());
			oTable.ActualHours=decimal.Parse(row["ActualHours"].ToString());
			oTable.CreateUser_ID=int.Parse(row["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(row["ModifiedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(row["DateModified"].ToString());
			oTable.CreateTerminal_ID=row["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=row["ModifiedTerminal_ID"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableStatus_ID(int PStatus_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Status_ID] = '"+PStatus_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	public static List<tbl_ptsTasks> SelectAllByClient_ID(int PClient_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Client_ID] = '"+PClient_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTasks> lstTable = new List<tbl_ptsTasks>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTasks oTable = new tbl_ptsTasks();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(row["Branch_ID"].ToString());
			oTable.Main_Task_ID=int.Parse(row["Main_Task_ID"].ToString());
			oTable.Task=row["Task"].ToString();
			oTable.Task_Desc=row["Task_Desc"].ToString();
			oTable.TestCases=row["TestCases"].ToString();
			oTable.DevComments=row["DevComments"].ToString();
			oTable.Reference_1=row["Reference_1"].ToString();
			oTable.Client_ID=int.Parse(row["Client_ID"].ToString());
			oTable.ReportedDate=DateTime.Parse(row["ReportedDate"].ToString());
			oTable.ReportedBy=row["ReportedBy"].ToString();
			oTable.Prod_ID=int.Parse(row["Prod_ID"].ToString());
			oTable.Function_ID=int.Parse(row["Function_ID"].ToString());
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.Type_ID=int.Parse(row["Type_ID"].ToString());
			oTable.Status_ID=int.Parse(row["Status_ID"].ToString());
			oTable.Progress=int.Parse(row["Progress"].ToString());
			oTable.Assign_To=int.Parse(row["Assign_To"].ToString());
			oTable.Estimate_Minutes=int.Parse(row["Estimate_Minutes"].ToString());
			oTable.Priority=int.Parse(row["Priority"].ToString());
			oTable.Deadline=DateTime.Parse(row["Deadline"].ToString());
			oTable.ActualHours=decimal.Parse(row["ActualHours"].ToString());
			oTable.CreateUser_ID=int.Parse(row["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(row["ModifiedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(row["DateModified"].ToString());
			oTable.CreateTerminal_ID=row["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=row["ModifiedTerminal_ID"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableClient_ID(int PClient_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Client_ID] = '"+PClient_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	public static List<tbl_ptsTasks> SelectAllByProd_ID(int PProd_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Prod_ID] = '"+PProd_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTasks> lstTable = new List<tbl_ptsTasks>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTasks oTable = new tbl_ptsTasks();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(row["Branch_ID"].ToString());
			oTable.Main_Task_ID=int.Parse(row["Main_Task_ID"].ToString());
			oTable.Task=row["Task"].ToString();
			oTable.Task_Desc=row["Task_Desc"].ToString();
			oTable.TestCases=row["TestCases"].ToString();
			oTable.DevComments=row["DevComments"].ToString();
			oTable.Reference_1=row["Reference_1"].ToString();
			oTable.Client_ID=int.Parse(row["Client_ID"].ToString());
			oTable.ReportedDate=DateTime.Parse(row["ReportedDate"].ToString());
			oTable.ReportedBy=row["ReportedBy"].ToString();
			oTable.Prod_ID=int.Parse(row["Prod_ID"].ToString());
			oTable.Function_ID=int.Parse(row["Function_ID"].ToString());
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.Type_ID=int.Parse(row["Type_ID"].ToString());
			oTable.Status_ID=int.Parse(row["Status_ID"].ToString());
			oTable.Progress=int.Parse(row["Progress"].ToString());
			oTable.Assign_To=int.Parse(row["Assign_To"].ToString());
			oTable.Estimate_Minutes=int.Parse(row["Estimate_Minutes"].ToString());
			oTable.Priority=int.Parse(row["Priority"].ToString());
			oTable.Deadline=DateTime.Parse(row["Deadline"].ToString());
			oTable.ActualHours=decimal.Parse(row["ActualHours"].ToString());
			oTable.CreateUser_ID=int.Parse(row["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(row["ModifiedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(row["DateModified"].ToString());
			oTable.CreateTerminal_ID=row["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=row["ModifiedTerminal_ID"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableProd_ID(int PProd_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Prod_ID] = '"+PProd_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	public static List<tbl_ptsTasks> SelectAllByAssign_To(int PAssign_To)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID]  , [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Assign_To] = '"+PAssign_To+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTasks> lstTable = new List<tbl_ptsTasks>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTasks oTable = new tbl_ptsTasks();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Branch_ID=int.Parse(row["Branch_ID"].ToString());
			oTable.Main_Task_ID=int.Parse(row["Main_Task_ID"].ToString());
			oTable.Task=row["Task"].ToString();
			oTable.Task_Desc=row["Task_Desc"].ToString();
			oTable.TestCases=row["TestCases"].ToString();
			oTable.DevComments=row["DevComments"].ToString();
			oTable.Reference_1=row["Reference_1"].ToString();
			oTable.Client_ID=int.Parse(row["Client_ID"].ToString());
			oTable.ReportedDate=DateTime.Parse(row["ReportedDate"].ToString());
			oTable.ReportedBy=row["ReportedBy"].ToString();
			oTable.Prod_ID=int.Parse(row["Prod_ID"].ToString());
			oTable.Function_ID=int.Parse(row["Function_ID"].ToString());
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.Type_ID=int.Parse(row["Type_ID"].ToString());
			oTable.Status_ID=int.Parse(row["Status_ID"].ToString());
			oTable.Progress=int.Parse(row["Progress"].ToString());
			oTable.Assign_To=int.Parse(row["Assign_To"].ToString());
			oTable.Estimate_Minutes=int.Parse(row["Estimate_Minutes"].ToString());
			oTable.Priority=int.Parse(row["Priority"].ToString());
			oTable.Deadline=DateTime.Parse(row["Deadline"].ToString());
			oTable.ActualHours=decimal.Parse(row["ActualHours"].ToString());
			oTable.CreateUser_ID=int.Parse(row["CreateUser_ID"].ToString());
			oTable.ModifiedUser_ID=int.Parse(row["ModifiedUser_ID"].ToString());
			oTable.DateCreate=DateTime.Parse(row["DateCreate"].ToString());
			oTable.DateModified=DateTime.Parse(row["DateModified"].ToString());
			oTable.CreateTerminal_ID=row["CreateTerminal_ID"].ToString();
			oTable.ModifiedTerminal_ID=row["ModifiedTerminal_ID"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableAssign_To(int PAssign_To)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Branch_ID] , [Main_Task_ID] , [Task] , [Task_Desc] , [TestCases] , [DevComments] , [Reference_1] , [Client_ID] , [ReportedDate] , [ReportedBy] , [Prod_ID] , [Function_ID] , [Activity_ID] , [Type_ID] , [Status_ID] , [Progress] , [Assign_To] , [Estimate_Minutes] , [Priority] , [Deadline] , [ActualHours] , [CreateUser_ID] , [ModifiedUser_ID] , [DateCreate] , [DateModified] , [CreateTerminal_ID] , [ModifiedTerminal_ID] From [dbo].[tbl_ptsTasks] Where [Assign_To] = '"+PAssign_To+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

    public DataTable SelectAll_TableWithRefference()
    {
        dbConnection DBConnection = new dbConnection();
        string sScript = "select * from vw_ptsTasks ORDER BY Task_ID DESC";
        bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
        if (bQuaryStatus2)
            return DBConnection.ResultTable;
        else
            return null;
    }
    //public DataTable SelectAll_TableWithRefference2(int cus, int prod, int type, int pri, int st, int ass)
    public DataTable SelectAll_TableWithRefference2(string cus, string prod, string type, string pri, string st, string ass, DateTime from, DateTime to)
    {
        dbConnection DBConnection = new dbConnection();
        string sScript = "sp_task_All'" + cus + "','" + prod + "','" + type + "','" + pri + "','" + st + "','" + ass + "','" +from+ "','" +to+ "'";
        bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
        
        if (bQuaryStatus2)
            return DBConnection.ResultTable;
        else
            return null;
    }

    #endregion
}