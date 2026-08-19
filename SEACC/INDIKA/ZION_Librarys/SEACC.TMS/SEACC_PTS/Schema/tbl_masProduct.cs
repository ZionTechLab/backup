using System;
using System.Data;
using System.Collections.Generic;

public class tbl_masProduct
{
	#region Fields
	public int Product_ID;
	public int Organization_ID;
	public string Product_Code;
	public string Product_Name;
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
	public tbl_masProduct() {	 }

	public tbl_masProduct(int Product_ID,int Organization_ID,string Product_Code,string Product_Name,int CreatedUser_ID,DateTime CreatedDate,bool Blacklisted,int BlacklistedUser_ID,DateTime BlacklistedDate,bool Suspended,int SuspendedUser_ID,DateTime SuspendedDate)
	{
		this.Product_ID=Product_ID;
		this.Organization_ID=Organization_ID;
		this.Product_Code=Product_Code;
		this.Product_Name=Product_Name;
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
	public static tbl_masProduct Select(int PProduct_ID)
	{
		dbConnection DBConnection = new dbConnection();
		string sScript="Select [Product_ID] , [Organization_ID] , [Product_Code] , [Product_Name] , [CreatedUser_ID] , [CreatedDate] , [Blacklisted] , [BlacklistedUser_ID] , [BlacklistedDate] , [Suspended] , [SuspendedUser_ID] , [SuspendedDate] From [dbo].[tbl_masProduct] Where [Product_ID] = '"+PProduct_ID+"'";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		tbl_masProduct oTable = new tbl_masProduct();
		if (bQuaryStatus2)
		{
			oTable.Product_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Product_ID"].ToString());
			oTable.Organization_ID=int.Parse(DBConnection.ResultTable.Rows[0]["Organization_ID"].ToString());
			oTable.Product_Code=DBConnection.ResultTable.Rows[0]["Product_Code"].ToString();
			oTable.Product_Name=DBConnection.ResultTable.Rows[0]["Product_Name"].ToString();
			
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
		string sScript="Select [Product_ID] , [Organization_ID] , [Product_Code] , [Product_Name] , [CreatedUser_ID] , [CreatedDate] , [Blacklisted] , [BlacklistedUser_ID] , [BlacklistedDate] , [Suspended] , [SuspendedUser_ID] , [SuspendedDate] From [dbo].[tbl_masProduct] ";
		bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
		if (bQuaryStatus2)
			return null;
		else
			return DBConnection.ResultTable;
	}

    public static List<tbl_masProduct> SelectAll()
    {
        dbConnection DBConnection = new dbConnection();
        string sScript = "Select [Product_ID] , [Organization_ID] , [Product_Code] , [Product_Name] , [CreatedUser_ID] , [CreatedDate] , [Blacklisted] , [BlacklistedUser_ID] , [BlacklistedDate] , [Suspended] , [SuspendedUser_ID] , [SuspendedDate] From [dbo].[tbl_masProduct] ";
        bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
        List<tbl_masProduct> lstTable = new List<tbl_masProduct>();
        if (bQuaryStatus2)
        {
            foreach (DataRow row in DBConnection.ResultTable.Rows)
            {
                tbl_masProduct oTable = new tbl_masProduct();
                oTable.Product_ID = int.Parse(row["Product_ID"].ToString());
                oTable.Organization_ID = int.Parse(row["Organization_ID"].ToString());
                oTable.Product_Code = row["Product_Code"].ToString();
                oTable.Product_Name = row["Product_Name"].ToString();
                oTable.CreatedUser_ID = int.Parse(row["CreatedUser_ID"].ToString());
                oTable.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                oTable.Blacklisted = bool.Parse(row["Blacklisted"].ToString());
                oTable.BlacklistedUser_ID = int.Parse(row["BlacklistedUser_ID"].ToString());
                oTable.BlacklistedDate = DateTime.Parse(row["BlacklistedDate"].ToString());
                oTable.Suspended = bool.Parse(row["Suspended"].ToString());
                oTable.SuspendedUser_ID = int.Parse(row["SuspendedUser_ID"].ToString());
                oTable.SuspendedDate = DateTime.Parse(row["SuspendedDate"].ToString());

                lstTable.Add(oTable);
            }
        }
        return lstTable;
    }

    #endregion
}
