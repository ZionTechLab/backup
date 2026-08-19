using System;
using System.Data;
using System.Collections.Generic;

public class tbl_masProject
{
	#region Fields
	public int Proj_ID;
	public int Organization_ID;
	public int Client_ID;
	public string Proj_Code;
	public string Proj_Name;
	public string Proj_Remarks;
	public string Proj_Approval_Doc;
	public string Proj_Tracking_Doc;
	public DateTime Proj_Start_Date;
	public DateTime Proj_End_Date;
	public int CreatedUser_ID;
	public DateTime CreatedDate;
	#endregion

	#region Constructors
	public tbl_masProject() {	 }

	public tbl_masProject(int Proj_ID,int Organization_ID,int Client_ID,string Proj_Code,string Proj_Name,string Proj_Remarks,string Proj_Approval_Doc,string Proj_Tracking_Doc,DateTime Proj_Start_Date,DateTime Proj_End_Date,int CreatedUser_ID,DateTime CreatedDate)
	{
		this.Proj_ID=Proj_ID;
		this.Organization_ID=Organization_ID;
		this.Client_ID=Client_ID;
		this.Proj_Code=Proj_Code;
		this.Proj_Name=Proj_Name;
		this.Proj_Remarks=Proj_Remarks;
		this.Proj_Approval_Doc=Proj_Approval_Doc;
		this.Proj_Tracking_Doc=Proj_Tracking_Doc;
		this.Proj_Start_Date=Proj_Start_Date;
		this.Proj_End_Date=Proj_End_Date;
		this.CreatedUser_ID=CreatedUser_ID;
		this.CreatedDate=CreatedDate;
	}
	#endregion

	#region Methods
	public static tbl_masProject Select(int PProj_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Proj_ID] , [Organization_ID] , [Client_ID] , [Proj_Code] , [Proj_Name] , [Proj_Remarks] , [Proj_Approval_Doc] , [Proj_Tracking_Doc] , [Proj_Start_Date] , [Proj_End_Date] , [CreatedUser_ID] , [CreatedDate] From [dbo].[tbl_masProject] Where [Proj_ID] = '"+PProj_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		tbl_masProject oTable = new tbl_masProject();
		if (bQuaryStatus2)
		{
			oTable.Proj_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Proj_ID"].ToString());
			oTable.Organization_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Organization_ID"].ToString());
			oTable.Client_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Client_ID"].ToString());
			oTable.Proj_Code=DBConnection.ResultTable.Rows[0]["Proj_Code"].ToString();
			oTable.Proj_Name=DBConnection.ResultTable.Rows[0]["Proj_Name"].ToString();
			oTable.Proj_Remarks=DBConnection.ResultTable.Rows[0]["Proj_Remarks"].ToString();
			oTable.Proj_Approval_Doc=DBConnection.ResultTable.Rows[0]["Proj_Approval_Doc"].ToString();
			oTable.Proj_Tracking_Doc=DBConnection.ResultTable.Rows[0]["Proj_Tracking_Doc"].ToString();
			oTable.Proj_Start_Date=DateTime.Parse(DBConnection.ResultTable.Rows[0]["Proj_Start_Date"].ToString());
			oTable.Proj_End_Date=DateTime.Parse(DBConnection.ResultTable.Rows[0]["Proj_End_Date"].ToString());
			oTable.CreatedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["CreatedUser_ID"].ToString());
			oTable.CreatedDate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["CreatedDate"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Proj_ID] , [Organization_ID] , [Client_ID] , [Proj_Code] , [Proj_Name] , [Proj_Remarks] , [Proj_Approval_Doc] , [Proj_Tracking_Doc] , [Proj_Start_Date] , [Proj_End_Date] , [CreatedUser_ID] , [CreatedDate] From [dbo].[tbl_masProject] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

	#endregion
}
