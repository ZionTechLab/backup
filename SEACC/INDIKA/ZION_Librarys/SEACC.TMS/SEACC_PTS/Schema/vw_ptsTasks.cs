//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class vw_ptsTasks
{
	#region Fields
	public int Task_ID;
	public string Task;
	public string Reference_1;
	public string Task_Desc;
	public int Client_ID;
	public string Client_Code;
	public int Prod_ID;
	public string Product_Code;
	public DateTime ReportedDate;
	public string ReportedBy;
	public int Activity_ID;
	public int Status_ID;
	public string Status;
	public int Type_ID;
	public string Type;
	public int Assign_To_User_ID;
	public string Assign_To_User_Name;
	#endregion

	#region Constructors
	public vw_ptsTasks() {	 }

	public vw_ptsTasks(int Task_ID,string Task,string Reference_1,string Task_Desc,int Client_ID,string Client_Code,int Prod_ID,string Product_Code,DateTime ReportedDate,string ReportedBy,int Activity_ID,int Status_ID,string Status,int Type_ID,string Type,int Assign_To_User_ID,string Assign_To_User_Name)
	{
		this.Task_ID=Task_ID;
		this.Task=Task;
		this.Reference_1=Reference_1;
		this.Task_Desc=Task_Desc;
		this.Client_ID=Client_ID;
		this.Client_Code=Client_Code;
		this.Prod_ID=Prod_ID;
		this.Product_Code=Product_Code;
		this.ReportedDate=ReportedDate;
		this.ReportedBy=ReportedBy;
		this.Activity_ID=Activity_ID;
		this.Status_ID=Status_ID;
		this.Status=Status;
		this.Type_ID=Type_ID;
		this.Type=Type;
		this.Assign_To_User_ID=Assign_To_User_ID;
		this.Assign_To_User_Name=Assign_To_User_Name;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[vw_ptsTasks] ([Task_ID] , [Task] , [Reference_1] , [Task_Desc] , [Client_ID] , [Client_Code] , [Prod_ID] , [Product_Code] , [ReportedDate] , [ReportedBy] , [Activity_ID] , [Status_ID] , [Status] , [Type_ID] , [Type] , [Assign_To_User_ID] , [Assign_To_User_Name]) VALUES ("+Task_ID+" , '"+Task+"' , '"+Reference_1+"' , '"+Task_Desc+"' , "+Client_ID+" , '"+Client_Code+"' , "+Prod_ID+" , '"+Product_Code+"' , '"+ReportedDate+"' , '"+ReportedBy+"' , "+Activity_ID+" , "+Status_ID+" , '"+Status+"' , "+Type_ID+" , '"+Type+"' , "+Assign_To_User_ID+" , '"+Assign_To_User_Name+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[vw_ptsTasks] SET [Task_ID] = "+Task_ID+" , [Task] = '"+Task+"' , [Reference_1] = '"+Reference_1+"' , [Task_Desc] = '"+Task_Desc+"' , [Client_ID] = "+Client_ID+" , [Client_Code] = '"+Client_Code+"' , [Prod_ID] = "+Prod_ID+" , [Product_Code] = '"+Product_Code+"' , [ReportedDate] = '"+ReportedDate+"' , [ReportedBy] = '"+ReportedBy+"' , [Activity_ID] = "+Activity_ID+" , [Status_ID] = "+Status_ID+" , [Status] = '"+Status+"' , [Type_ID] = "+Type_ID+" , [Type] = '"+Type+"' , [Assign_To_User_ID] = "+Assign_To_User_ID+" , [Assign_To_User_Name] = '"+Assign_To_User_Name+"' WHERE ";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[vw_ptsTasks] Where ";
		return DBConnection.Execute_Quary(sScript);
	}

	public static vw_ptsTasks Select()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Task] , [Reference_1] , [Task_Desc] , [Client_ID] , [Client_Code] , [Prod_ID] , [Product_Code] , [ReportedDate] , [ReportedBy] , [Activity_ID] , [Status_ID] , [Status] , [Type_ID] , [Type] , [Assign_To_User_ID] , [Assign_To_User_Name] From [dbo].[vw_ptsTasks] Where ";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			vw_ptsTasks oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new vw_ptsTasks();

			oTable.Task_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Task_ID"].ToString());
			oTable.Task=DBConnection.ResultTable.Rows[0]["Task"].ToString();
			oTable.Reference_1=DBConnection.ResultTable.Rows[0]["Reference_1"].ToString();
			oTable.Task_Desc=DBConnection.ResultTable.Rows[0]["Task_Desc"].ToString();
			oTable.Client_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Client_ID"].ToString());
			oTable.Client_Code=DBConnection.ResultTable.Rows[0]["Client_Code"].ToString();
			oTable.Prod_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Prod_ID"].ToString());
			oTable.Product_Code=DBConnection.ResultTable.Rows[0]["Product_Code"].ToString();
			oTable.ReportedDate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["ReportedDate"].ToString());
			oTable.ReportedBy=DBConnection.ResultTable.Rows[0]["ReportedBy"].ToString();
			oTable.Activity_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Activity_ID"].ToString());
			oTable.Status_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Status_ID"].ToString());
			oTable.Status=DBConnection.ResultTable.Rows[0]["Status"].ToString();
			oTable.Type_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Type_ID"].ToString());
			oTable.Type=DBConnection.ResultTable.Rows[0]["Type"].ToString();
			oTable.Assign_To_User_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Assign_To_User_ID"].ToString());
			oTable.Assign_To_User_Name=DBConnection.ResultTable.Rows[0]["Assign_To_User_Name"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Task] , [Reference_1] , [Task_Desc] , [Client_ID] , [Client_Code] , [Prod_ID] , [Product_Code] , [ReportedDate] , [ReportedBy] , [Activity_ID] , [Status_ID] , [Status] , [Type_ID] , [Type] , [Assign_To_User_ID] , [Assign_To_User_Name] From [dbo].[vw_ptsTasks] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<vw_ptsTasks> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Task] , [Reference_1] , [Task_Desc] , [Client_ID] , [Client_Code] , [Prod_ID] , [Product_Code] , [ReportedDate] , [ReportedBy] , [Activity_ID] , [Status_ID] , [Status] , [Type_ID] , [Type] , [Assign_To_User_ID] , [Assign_To_User_Name] From [dbo].[vw_ptsTasks]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<vw_ptsTasks> lstTable = new List<vw_ptsTasks>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			vw_ptsTasks oTable = new vw_ptsTasks();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Task=row["Task"].ToString();
			oTable.Reference_1=row["Reference_1"].ToString();
			oTable.Task_Desc=row["Task_Desc"].ToString();
			oTable.Client_ID=int.Parse(row["Client_ID"].ToString());
			oTable.Client_Code=row["Client_Code"].ToString();
			oTable.Prod_ID=int.Parse(row["Prod_ID"].ToString());
			oTable.Product_Code=row["Product_Code"].ToString();
			oTable.ReportedDate=DateTime.Parse(row["ReportedDate"].ToString());
			oTable.ReportedBy=row["ReportedBy"].ToString();
			oTable.Activity_ID=int.Parse(row["Activity_ID"].ToString());
			oTable.Status_ID=int.Parse(row["Status_ID"].ToString());
			oTable.Status=row["Status"].ToString();
			oTable.Type_ID=int.Parse(row["Type_ID"].ToString());
			oTable.Type=row["Type"].ToString();
			oTable.Assign_To_User_ID=int.Parse(row["Assign_To_User_ID"].ToString());
			oTable.Assign_To_User_Name=row["Assign_To_User_Name"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
