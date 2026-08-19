//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_refFunction
{
	#region Fields
	public int Function_ID;
	public string Function_Name;
	public string FunctionCategory_ID;
	public bool isEnable;
	#endregion

	#region Constructors
	public tbl_refFunction() {	 }

	public tbl_refFunction(int Function_ID,string Function_Name,string FunctionCategory_ID,bool isEnable)
	{
		this.Function_ID=Function_ID;
		this.Function_Name=Function_Name;
		this.FunctionCategory_ID=FunctionCategory_ID;
		this.isEnable=isEnable;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_refFunction] ([Function_ID] , [Function_Name] , [FunctionCategory_ID] , [isEnable]) VALUES ("+Function_ID+" , '"+Function_Name+"' , '"+FunctionCategory_ID+"' , '"+isEnable+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_refFunction] SET [Function_ID] = "+Function_ID+" , [Function_Name] = '"+Function_Name+"' , [FunctionCategory_ID] = '"+FunctionCategory_ID+"' , [isEnable] = '"+isEnable+"' WHERE [Function_ID] = "+Function_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_refFunction] Where [Function_ID] = "+Function_ID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_refFunction Select(int PFunction_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Function_ID] , [Function_Name] , [FunctionCategory_ID] , [isEnable] From [dbo].[tbl_refFunction] Where [Function_ID] = '"+PFunction_ID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_refFunction oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_refFunction();

			oTable.Function_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Function_ID"].ToString());
			oTable.Function_Name=DBConnection.ResultTable.Rows[0]["Function_Name"].ToString();
			oTable.FunctionCategory_ID=DBConnection.ResultTable.Rows[0]["FunctionCategory_ID"].ToString();
			oTable.isEnable=bool.Parse(DBConnection.ResultTable.Rows[0]["isEnable"].ToString());

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Function_ID] , [Function_Name] , [FunctionCategory_ID] , [isEnable] From [dbo].[tbl_refFunction] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_refFunction> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Function_ID] , [Function_Name] , [FunctionCategory_ID] , [isEnable] From [dbo].[tbl_refFunction]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_refFunction> lstTable = new List<tbl_refFunction>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_refFunction oTable = new tbl_refFunction();
			oTable.Function_ID=int.Parse(row["Function_ID"].ToString());
			oTable.Function_Name=row["Function_Name"].ToString();
			oTable.FunctionCategory_ID=row["FunctionCategory_ID"].ToString();
			oTable.isEnable=bool.Parse(row["isEnable"].ToString());

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
