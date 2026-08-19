using System;
using System.Data;
using System.Collections.Generic;

public class tbl_masPriority
{
	#region Fields
	public int priorityID;
	public string priorityType;
	#endregion

	#region Constructors
	public tbl_masPriority() {	 }

	public tbl_masPriority(int priorityID,string priorityType)
	{
		this.priorityID=priorityID;
		this.priorityType=priorityType;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_masPriority] ([priorityID] , [priorityType]) VALUES ("+priorityID+" , '"+priorityType+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_masPriority] SET [priorityID] = "+priorityID+" , [priorityType] = '"+priorityType+"' WHERE ";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_masPriority] Where ";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_masPriority Select()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [priorityID] , [priorityType] From [dbo].[tbl_masPriority] Where ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		tbl_masPriority oTable = new tbl_masPriority();
		if (bQuaryStatus2)
		{
			oTable.priorityID=int.Parse(DBConnection.ResultTable.Rows[0]["priorityID"].ToString());
			oTable.priorityType=DBConnection.ResultTable.Rows[0]["priorityType"].ToString();

		}
		return oTable;
	}

    public static tbl_masPriority Select(int Priority_ID)
    {
        dbConnection DBConnection = new dbConnection();
        string sScript = "Select [priorityID] , [priorityType] From [dbo].[tbl_masPriority] Where [priorityID] = '" + Priority_ID + "'";
        bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
        tbl_masPriority oTable = null;
        if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)
        {
            oTable = new tbl_masPriority();
            oTable.priorityID = int.Parse(DBConnection.ResultTable.Rows[0]["priorityID"].ToString());
            oTable.priorityType = DBConnection.ResultTable.Rows[0]["priorityType"].ToString();          
        }
        return oTable;
    }







	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [priorityID] , [priorityType] From [dbo].[tbl_masPriority] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_masPriority> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [priorityID] , [priorityType] From [dbo].[tbl_masPriority]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_masPriority> lstTable = new List<tbl_masPriority>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_masPriority oTable = new tbl_masPriority();
			oTable.priorityID=int.Parse(row["priorityID"].ToString());
			oTable.priorityType=row["priorityType"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
