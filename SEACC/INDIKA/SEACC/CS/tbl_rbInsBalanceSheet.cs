using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbInsBalanceSheet {
		#region Fields
		private int node_ID;
		private string displayName;
		private int nodeOrder;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsBalanceSheet class.
		/// </summary>
		public tbl_rbInsBalanceSheet() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsBalanceSheet class.
		/// </summary>
		public tbl_rbInsBalanceSheet(int node_ID, string displayName, int nodeOrder) {
			this.node_ID = node_ID;
			this.displayName = displayName;
			this.nodeOrder = nodeOrder;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Node_ID value.
		/// </summary>
		public int Node_ID {
			get { return node_ID; }
			set { node_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName value.
		/// </summary>
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the NodeOrder value.
		/// </summary>
		public int NodeOrder {
			get { return nodeOrder; }
			set { nodeOrder = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rbInsBalanceSheet table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsBalanceSheetInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@node_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@nodeOrder", SqlDbType.Int,4);
 
			scom.Parameters["@node_ID"].Value = node_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@nodeOrder"].Value = nodeOrder;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsBalanceSheet table.
		/// </summary>
		public static List<tbl_rbInsBalanceSheet> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsBalanceSheetSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbInsBalanceSheet> tbl_rbInsBalanceSheetList = new List<tbl_rbInsBalanceSheet>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbInsBalanceSheet tbl_rbInsBalanceSheet = Maketbl_rbInsBalanceSheet(dataReader);
					tbl_rbInsBalanceSheetList.Add(tbl_rbInsBalanceSheet);
				}
			}
			scon.Close();
			return tbl_rbInsBalanceSheetList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbInsBalanceSheet class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbInsBalanceSheet Maketbl_rbInsBalanceSheet(SqlDataReader dataReader) {
			tbl_rbInsBalanceSheet tbl_rbInsBalanceSheet = new tbl_rbInsBalanceSheet();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbInsBalanceSheet.Node_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbInsBalanceSheet.DisplayName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbInsBalanceSheet.NodeOrder = dataReader.GetInt32(2);
			}

			return tbl_rbInsBalanceSheet;
		}
		/// <summary>
		/// This makes tbl_rbInsBalanceSheet datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbInsBalanceSheet object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbInsBalanceSheet  tbl_rbInsBalanceSheet   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_node_ID = new DataColumn("node_ID" , typeof(int));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_nodeOrder = new DataColumn("nodeOrder" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_node_ID,col_displayName,col_nodeOrder,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbInsBalanceSheet datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbInsBalanceSheet object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbInsBalanceSheet user) {
		DataRow drow = dt.NewRow();
		
			drow["node_ID"] = user.node_ID;
			drow["displayName"] = user.displayName;
			drow["nodeOrder"] = user.nodeOrder;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
