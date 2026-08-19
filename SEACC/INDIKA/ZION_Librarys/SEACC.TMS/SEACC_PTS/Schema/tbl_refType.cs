using System;
using System.Data;
using System.Collections.Generic;

public class tbl_refType
{
	#region Fields
	public int Type_ID;
	public string Type;
	#endregion

	#region Constructors
	public tbl_refType() {	 }

	public tbl_refType(int Type_ID,string Type)
	{
		this.Type_ID=Type_ID;
		this.Type=Type;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_refType] ([Type_ID] , [Type]) VALUES ("+Type_ID+" , '"+Type+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_refType] SET [Type_ID] = "+Type_ID+" , [Type] = '"+Type+"' WHERE [Type_ID] = "+Type_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_refType] Where [Type_ID] = "+Type_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_refType Select(int PType_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Type_ID] , [Type] From [dbo].[tbl_refType] Where [Type_ID] = '"+PType_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		tbl_refType oTable = new tbl_refType();
		if (bQuaryStatus2)
		{
			oTable.Type_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Type_ID"].ToString());
			oTable.Type=DBConnection.ResultTable.Rows[0]["Type"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Type_ID] , [Type] From [dbo].[tbl_refType] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_refType> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Type_ID] , [Type] From [dbo].[tbl_refType]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_refType> lstTable = new List<tbl_refType>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_refType oTable = new tbl_refType();
			oTable.Type_ID=int.Parse(row["Type_ID"].ToString());
			oTable.Type=row["Type"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
