using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genGoodsLenderMaster {
		#region Fields
		private string goodsLender_ID;
		private string goodsLenderName;
		private string adress;
		private string telephone;
		private string fax;
		private string contactPerson;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genGoodsLenderMaster class.
		/// </summary>
		public tbl_genGoodsLenderMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genGoodsLenderMaster class.
		/// </summary>
		public tbl_genGoodsLenderMaster(string goodsLender_ID, string goodsLenderName, string adress, string telephone, string fax, string contactPerson) {
			this.goodsLender_ID = goodsLender_ID;
			this.goodsLenderName = goodsLenderName;
			this.adress = adress;
			this.telephone = telephone;
			this.fax = fax;
			this.contactPerson = contactPerson;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GoodsLender_ID value.
		/// </summary>
		public string GoodsLender_ID {
			get { return goodsLender_ID; }
			set { goodsLender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GoodsLenderName value.
		/// </summary>
		public string GoodsLenderName {
			get { return goodsLenderName; }
			set { goodsLenderName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Adress value.
		/// </summary>
		public string Adress {
			get { return adress; }
			set { adress = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactPerson value.
		/// </summary>
		public string ContactPerson {
			get { return contactPerson; }
			set { contactPerson = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genGoodsLenderMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genGoodsLenderMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@goodsLender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@goodsLenderName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
 
			scom.Parameters["@goodsLender_ID"].Value = goodsLender_ID;
			scom.Parameters["@goodsLenderName"].Value = goodsLenderName;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genGoodsLenderMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genGoodsLenderMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@goodsLender_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@goodsLenderName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@goodsLender_ID"].Value = goodsLender_ID;
			scom.Parameters["@goodsLenderName"].Value = goodsLenderName;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genGoodsLenderMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genGoodsLenderMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@goodsLender_ID", SqlDbType.VarChar,20);
			scom.Parameters["@goodsLender_ID"].Value = goodsLender_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genGoodsLenderMaster table.
		/// </summary>
		public static tbl_genGoodsLenderMaster Select(string goodsLender_ID_Incoming){

			tbl_genGoodsLenderMaster tbl_genGoodsLenderMasterins = new tbl_genGoodsLenderMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genGoodsLenderMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@goodsLender_ID", SqlDbType.VarChar,20);
			scom.Parameters["@goodsLender_ID"].Value = goodsLender_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genGoodsLenderMasterins = Maketbl_genGoodsLenderMaster(dataReader);
				} else {
					tbl_genGoodsLenderMasterins = null;
				}
			}
			scon.Close();
			return tbl_genGoodsLenderMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genGoodsLenderMaster table.
		/// </summary>
		public static List<tbl_genGoodsLenderMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genGoodsLenderMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genGoodsLenderMaster> tbl_genGoodsLenderMasterList = new List<tbl_genGoodsLenderMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genGoodsLenderMaster tbl_genGoodsLenderMaster = Maketbl_genGoodsLenderMaster(dataReader);
					tbl_genGoodsLenderMasterList.Add(tbl_genGoodsLenderMaster);
				}
			}
			scon.Close();
			return tbl_genGoodsLenderMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genGoodsLenderMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genGoodsLenderMaster Maketbl_genGoodsLenderMaster(SqlDataReader dataReader) {
			tbl_genGoodsLenderMaster tbl_genGoodsLenderMaster = new tbl_genGoodsLenderMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genGoodsLenderMaster.GoodsLender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genGoodsLenderMaster.GoodsLenderName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genGoodsLenderMaster.Adress = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genGoodsLenderMaster.Telephone = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genGoodsLenderMaster.Fax = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genGoodsLenderMaster.ContactPerson = dataReader.GetString(5);
			}

			return tbl_genGoodsLenderMaster;
		}
		/// <summary>
		/// This fills tbl_genGoodsLenderMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genGoodsLenderMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genGoodsLenderMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["goodsLender_ID"] = user.goodsLender_ID;
			drow["goodsLenderName"] = user.goodsLenderName;
			drow["adress"] = user.adress;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["contactPerson"] = user.contactPerson;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
