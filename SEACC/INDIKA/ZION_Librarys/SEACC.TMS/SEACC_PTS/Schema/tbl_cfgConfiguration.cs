//This Cliss is genarated by Schema genarator
//Please contact anoj.thilina@hotmail.com  for more details

using System;
using System.Data;
using System.Collections.Generic;

public class tbl_cfgConfiguration
{
	#region Fields
	public int ConfigID;
	public string ConfigDesc;
	public string ConfigValue;
	#endregion

	#region Constructors
	public tbl_cfgConfiguration() {	 }

	public tbl_cfgConfiguration(int ConfigID,string ConfigDesc,string ConfigValue)
	{
		this.ConfigID=ConfigID;
		this.ConfigDesc=ConfigDesc;
		this.ConfigValue=ConfigValue;
	}
	#endregion

	#region Methods
	public bool Insert()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="INSERT INTO [dbo].[tbl_cfgConfiguration] ([ConfigID] , [ConfigDesc] , [ConfigValue]) VALUES ("+ConfigID+" , '"+ConfigDesc+"' , '"+ConfigValue+"')";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Update()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="UPDATE [dbo].[tbl_cfgConfiguration] SET [ConfigID] = "+ConfigID+" , [ConfigDesc] = '"+ConfigDesc+"' , [ConfigValue] = '"+ConfigValue+"' WHERE [ConfigID] = "+ConfigID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public bool Delete()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Delete From [dbo].[tbl_cfgConfiguration] Where [ConfigID] = "+ConfigID+"";
		return DBConnection.Execute_Quary(sScript);
	}

	public static tbl_cfgConfiguration Select(int PConfigID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [ConfigID] , [ConfigDesc] , [ConfigValue] From [dbo].[tbl_cfgConfiguration] Where [ConfigID] = '"+PConfigID+"'";
		bool bQuaryStatus = DBConnection.SelectToDataTable(sScript);
			tbl_cfgConfiguration oTable = null;
		if (bQuaryStatus && DBConnection.ResultTable.Rows.Count > 0)

		{
		oTable = new tbl_cfgConfiguration();

			oTable.ConfigID=int.Parse(DBConnection.ResultTable.Rows[0]["ConfigID"].ToString());
			oTable.ConfigDesc=DBConnection.ResultTable.Rows[0]["ConfigDesc"].ToString();
			oTable.ConfigValue=DBConnection.ResultTable.Rows[0]["ConfigValue"].ToString();

		}
		return oTable;
	}

	public DataTable SelectAll_Table()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [ConfigID] , [ConfigDesc] , [ConfigValue] From [dbo].[tbl_cfgConfiguration] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return DBConnection.ResultTable;
		else
			return null;
	}

	public static List<tbl_cfgConfiguration> SelectAll()
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [ConfigID] , [ConfigDesc] , [ConfigValue] From [dbo].[tbl_cfgConfiguration]";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		List<tbl_cfgConfiguration> lstTable = new List<tbl_cfgConfiguration>();
		if (bQuaryStatus2)
		{
			foreach (DataRow row in DBConnection.ResultTable.Rows)
			{
			tbl_cfgConfiguration oTable = new tbl_cfgConfiguration();
			oTable.ConfigID=int.Parse(row["ConfigID"].ToString());
			oTable.ConfigDesc=row["ConfigDesc"].ToString();
			oTable.ConfigValue=row["ConfigValue"].ToString();

				lstTable.Add(oTable);
			}
		}
		return lstTable;
	}

	#endregion
}
