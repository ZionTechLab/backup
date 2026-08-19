//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_masClient
{
	#region Fields
	public int Client_ID;
	public int Organization_ID;
	public string Client_Code;
	public string Client_Name;
	public int CreatedUser_ID;
	public DateTime CreatedDate;
	public bool Blacklisted;
	public int BlacklistedUser_ID;
	public DateTime BlacklistedDate;
	public bool Suspended;
	public int SuspendedUser_ID;
	public DateTime SuspendedDate;
	#endregion

	#region Constructors
	public tbl_masClient() {	 }

	public tbl_masClient(int Client_ID,int Organization_ID,string Client_Code,string Client_Name,int CreatedUser_ID,DateTime CreatedDate,bool Blacklisted,int BlacklistedUser_ID,DateTime BlacklistedDate,bool Suspended,int SuspendedUser_ID,DateTime SuspendedDate)
	{
		this.Client_ID=Client_ID;
		this.Organization_ID=Organization_ID;
		this.Client_Code=Client_Code;
		this.Client_Name=Client_Name;
		this.CreatedUser_ID=CreatedUser_ID;
		this.CreatedDate=CreatedDate;
		this.Blacklisted=Blacklisted;
		this.BlacklistedUser_ID=BlacklistedUser_ID;
		this.BlacklistedDate=BlacklistedDate;
		this.Suspended=Suspended;
		this.SuspendedUser_ID=SuspendedUser_ID;
		this.SuspendedDate=SuspendedDate;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_masClient] ([Organization_ID] , [Client_Code] , [Client_Name] , [CreatedUser_ID] , [CreatedDate] , [Blacklisted] , [BlacklistedUser_ID] , [BlacklistedDate] , [Suspended] , [SuspendedUser_ID] , [SuspendedDate]) VALUES ("+Organization_ID+" , '"+Client_Code+"' , '"+Client_Name+"' , "+CreatedUser_ID+" , '"+CreatedDate+"' , '"+Blacklisted+"' , "+BlacklistedUser_ID+" , '"+BlacklistedDate+"' , '"+Suspended+"' , "+SuspendedUser_ID+" , '"+SuspendedDate+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_masClient] SET [Organization_ID] = "+Organization_ID+" , [Client_Code] = '"+Client_Code+"' , [Client_Name] = '"+Client_Name+"' , [CreatedUser_ID] = "+CreatedUser_ID+" , [CreatedDate] = '"+CreatedDate+"' , [Blacklisted] = '"+Blacklisted+"' , [BlacklistedUser_ID] = "+BlacklistedUser_ID+" , [BlacklistedDate] = '"+BlacklistedDate+"' , [Suspended] = '"+Suspended+"' , [SuspendedUser_ID] = "+SuspendedUser_ID+" , [SuspendedDate] = '"+SuspendedDate+"' WHERE [Client_ID] = "+Client_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_masClient] Where [Client_ID] = "+Client_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_masClient Select(int PClient_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Client_ID] , [Organization_ID] , [Client_Code] , [Client_Name] , [CreatedUser_ID] , [CreatedDate] , [Blacklisted] , [BlacklistedUser_ID] , [BlacklistedDate] , [Suspended] , [SuspendedUser_ID] , [SuspendedDate] From [dbo].[tbl_masClient] Where [Client_ID] = '"+PClient_ID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_masClient oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_masClient();

			oTable.Client_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Client_ID"].ToString());
			oTable.Organization_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Organization_ID"].ToString());
			oTable.Client_Code=DBConnection.ResultTable.Rows[0]["Client_Code"].ToString();
			oTable.Client_Name=DBConnection.ResultTable.Rows[0]["Client_Name"].ToString();
			oTable.CreatedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["CreatedUser_ID"].ToString());
			oTable.CreatedDate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["CreatedDate"].ToString());
			oTable.Blacklisted=bool.Parse(DBConnection.ResultTable.Rows[0]["Blacklisted"].ToString());
			oTable.BlacklistedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["BlacklistedUser_ID"].ToString());
			oTable.BlacklistedDate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["BlacklistedDate"].ToString());
			oTable.Suspended=bool.Parse(DBConnection.ResultTable.Rows[0]["Suspended"].ToString());
			oTable.SuspendedUser_ID=int.Parse(DBConnection.ResultTable.Rows[0]["SuspendedUser_ID"].ToString());
			oTable.SuspendedDate=DateTime.Parse(DBConnection.ResultTable.Rows[0]["SuspendedDate"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Organization_ID] , [Client_Code] , [Client_Name] , [CreatedUser_ID] , [CreatedDate] , [Blacklisted] , [BlacklistedUser_ID] , [BlacklistedDate] , [Suspended] , [SuspendedUser_ID] , [SuspendedDate] From [dbo].[tbl_masClient] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_masClient> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Client_ID] , [Organization_ID] , [Client_Code] , [Client_Name] , [CreatedUser_ID] , [CreatedDate] , [Blacklisted] , [BlacklistedUser_ID] , [BlacklistedDate] , [Suspended] , [SuspendedUser_ID] , [SuspendedDate] From [dbo].[tbl_masClient]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_masClient> lstTable = new List<tbl_masClient>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_masClient oTable = new tbl_masClient();
			oTable.Client_ID=int.Parse(row["Client_ID"].ToString());
			oTable.Organization_ID=int.Parse(row["Organization_ID"].ToString());
			oTable.Client_Code=row["Client_Code"].ToString();
			oTable.Client_Name=row["Client_Name"].ToString();
			oTable.CreatedUser_ID=int.Parse(row["CreatedUser_ID"].ToString());
			oTable.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
			oTable.Blacklisted=bool.Parse(row["Blacklisted"].ToString());
			oTable.BlacklistedUser_ID=int.Parse(row["BlacklistedUser_ID"].ToString());
			oTable.BlacklistedDate=DateTime.Parse(row["BlacklistedDate"].ToString());
			oTable.Suspended=bool.Parse(row["Suspended"].ToString());
			oTable.SuspendedUser_ID=int.Parse(row["SuspendedUser_ID"].ToString());
			oTable.SuspendedDate=DateTime.Parse(row["SuspendedDate"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
