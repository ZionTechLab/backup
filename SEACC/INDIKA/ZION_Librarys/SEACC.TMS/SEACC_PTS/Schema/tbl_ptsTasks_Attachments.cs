//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_ptsTasks_Attachments
{
	#region Fields
	public int Task_ID;
	public int Attachment_Index;
	public string Attachment;
	public string DipsplayName;
	#endregion

	#region Constructors
	public tbl_ptsTasks_Attachments() {	 }

	public tbl_ptsTasks_Attachments(int Task_ID,int Attachment_Index,string Attachment,string DipsplayName)
	{
		this.Task_ID=Task_ID;
		this.Attachment_Index=Attachment_Index;
		this.Attachment=Attachment;
		this.DipsplayName=DipsplayName;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_ptsTasks_Attachments] ([Task_ID] , [Attachment_Index] , [Attachment] , [DipsplayName]) VALUES ("+Task_ID+" , "+Attachment_Index+" , '"+Attachment+"' , '"+DipsplayName+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_ptsTasks_Attachments] SET [Task_ID] = "+Task_ID+" , [Attachment_Index] = "+Attachment_Index+" , [Attachment] = '"+Attachment+"' , [DipsplayName] = '"+DipsplayName+"' WHERE [Task_ID] = "+Task_ID+" , [Attachment_Index] = "+Attachment_Index+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_ptsTasks_Attachments] Where [Task_ID] = "+Task_ID+" AND [Attachment_Index] = "+Attachment_Index+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_ptsTasks_Attachments Select(int PTask_ID , int PAttachment_Index)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Attachment_Index] , [Attachment] , [DipsplayName] From [dbo].[tbl_ptsTasks_Attachments] Where [Task_ID] = '"+PTask_ID+"' , [Attachment_Index] = '"+PAttachment_Index+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_ptsTasks_Attachments oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_ptsTasks_Attachments();

			oTable.Task_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Task_ID"].ToString());
			oTable.Attachment_Index=int.Parse(DBConnection.ResultTable.Rows[0]["Attachment_Index"].ToString());
			oTable.Attachment=DBConnection.ResultTable.Rows[0]["Attachment"].ToString();
			oTable.DipsplayName=DBConnection.ResultTable.Rows[0]["DipsplayName"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Attachment_Index] , [Attachment] , [DipsplayName] From [dbo].[tbl_ptsTasks_Attachments] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_ptsTasks_Attachments> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Attachment_Index] , [Attachment] , [DipsplayName] From [dbo].[tbl_ptsTasks_Attachments]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTasks_Attachments> lstTable = new List<tbl_ptsTasks_Attachments>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTasks_Attachments oTable = new tbl_ptsTasks_Attachments();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Attachment_Index=int.Parse(row["Attachment_Index"].ToString());
			oTable.Attachment=row["Attachment"].ToString();
			oTable.DipsplayName=row["DipsplayName"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public static List<tbl_ptsTasks_Attachments> SelectAllByTask_ID(int PTask_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Attachment_Index] , [Attachment] , [DipsplayName] From [dbo].[tbl_ptsTasks_Attachments] Where [Task_ID] = '"+PTask_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_ptsTasks_Attachments> lstTable = new List<tbl_ptsTasks_Attachments>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_ptsTasks_Attachments oTable = new tbl_ptsTasks_Attachments();
			oTable.Task_ID=int.Parse(row["Task_ID"].ToString());
			oTable.Attachment_Index=int.Parse(row["Attachment_Index"].ToString());
			oTable.Attachment=row["Attachment"].ToString();
			oTable.DipsplayName=row["DipsplayName"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	public DataTable SelectAllBy_TableTask_ID(int PTask_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Task_ID] , [Attachment_Index] , [Attachment] , [DipsplayName] From [dbo].[tbl_ptsTasks_Attachments] Where [Task_ID] = '"+PTask_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	#endregion
}
