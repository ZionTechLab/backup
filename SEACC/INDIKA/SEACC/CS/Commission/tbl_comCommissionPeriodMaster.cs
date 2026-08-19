using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class tbl_comCommissionPeriodMaster
    {
        #region Fields
        private Int64 periodIndex;
        private string periodName;
        private DateTime dateFrom;
        private DateTime dateTo;
        private bool isPeriodClose;
        private string closedUser_ID;
        private DateTime dateClosed;
        private string createUser_ID;
        private string createTerminal_ID;
        private string modifiedUser_ID;
        private string modifiedTerminal_ID;
        private string canceledUser_ID;
        private string canceledTerminal_ID;
        private DateTime dateCreate;
        private DateTime dateModified;
        private DateTime dateCanceled;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the tbl_comCommissionPeriodMaster class.
        /// </summary>
        public tbl_comCommissionPeriodMaster()
        {
        }

        /// <summary>
        /// Initializes a new instance of the tbl_comCommissionPeriodMaster class.
        /// </summary>
        public tbl_comCommissionPeriodMaster(Int64 periodIndex, string periodName, DateTime dateFrom, DateTime dateTo, bool isPeriodClose, string closedUser_ID, DateTime dateClosed, string createUser_ID, string createTerminal_ID, string modifiedUser_ID, string modifiedTerminal_ID, string canceledUser_ID, string canceledTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled)
        {
            this.periodIndex = periodIndex;
            this.periodName = periodName;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.isPeriodClose = isPeriodClose;
            this.closedUser_ID = closedUser_ID;
            this.dateClosed = dateClosed;
            this.createUser_ID = createUser_ID;
            this.createTerminal_ID = createTerminal_ID;
            this.modifiedUser_ID = modifiedUser_ID;
            this.modifiedTerminal_ID = modifiedTerminal_ID;
            this.canceledUser_ID = canceledUser_ID;
            this.canceledTerminal_ID = canceledTerminal_ID;
            this.dateCreate = dateCreate;
            this.dateModified = dateModified;
            this.dateCanceled = dateCanceled;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PeriodIndex value.
        /// </summary>
        public Int64 PeriodIndex
        {
            get { return periodIndex; }
            set { periodIndex = value; }
        }

        /// <summary>
        /// Gets or sets the PeriodName value.
        /// </summary>
        public string PeriodName
        {
            get { return periodName; }
            set { periodName = value; }
        }

        /// <summary>
        /// Gets or sets the DateFrom value.
        /// </summary>
        public DateTime DateFrom
        {
            get { return dateFrom; }
            set { dateFrom = value; }
        }

        /// <summary>
        /// Gets or sets the DateTo value.
        /// </summary>
        public DateTime DateTo
        {
            get { return dateTo; }
            set { dateTo = value; }
        }

        /// <summary>
        /// Gets or sets the IsPeriodClose value.
        /// </summary>
        public bool IsPeriodClose
        {
            get { return isPeriodClose; }
            set { isPeriodClose = value; }
        }

        /// <summary>
        /// Gets or sets the ClosedUser_ID value.
        /// </summary>
        public string ClosedUser_ID
        {
            get { return closedUser_ID; }
            set { closedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DateClosed value.
        /// </summary>
        public DateTime DateClosed
        {
            get { return dateClosed; }
            set { dateClosed = value; }
        }

        /// <summary>
        /// Gets or sets the CreateUser_ID value.
        /// </summary>
        public string CreateUser_ID
        {
            get { return createUser_ID; }
            set { createUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CreateTerminal_ID value.
        /// </summary>
        public string CreateTerminal_ID
        {
            get { return createTerminal_ID; }
            set { createTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedUser_ID value.
        /// </summary>
        public string ModifiedUser_ID
        {
            get { return modifiedUser_ID; }
            set { modifiedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ModifiedTerminal_ID value.
        /// </summary>
        public string ModifiedTerminal_ID
        {
            get { return modifiedTerminal_ID; }
            set { modifiedTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CanceledUser_ID value.
        /// </summary>
        public string CanceledUser_ID
        {
            get { return canceledUser_ID; }
            set { canceledUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CanceledTerminal_ID value.
        /// </summary>
        public string CanceledTerminal_ID
        {
            get { return canceledTerminal_ID; }
            set { canceledTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DateCreate value.
        /// </summary>
        public DateTime DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }

        /// <summary>
        /// Gets or sets the DateModified value.
        /// </summary>
        public DateTime DateModified
        {
            get { return dateModified; }
            set { dateModified = value; }
        }

        /// <summary>
        /// Gets or sets the DateCanceled value.
        /// </summary>
        public DateTime DateCanceled
        {
            get { return dateCanceled; }
            set { dateCanceled = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the tbl_comCommissionPeriodMaster table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_comCommissionPeriodMasterInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@periodIndex", SqlDbType.BigInt, 8);
            scom.Parameters.Add("@periodName", SqlDbType.VarChar, 200);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isPeriodClose", SqlDbType.Bit, 1);
            scom.Parameters.Add("@closedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@dateClosed", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@canceledTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCreate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime, 8);

            scom.Parameters["@periodIndex"].Value = periodIndex;
            scom.Parameters["@periodName"].Value = periodName;
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters["@dateTo"].Value = dateTo;
            scom.Parameters["@isPeriodClose"].Value = isPeriodClose;
            scom.Parameters["@closedUser_ID"].Value = closedUser_ID;
            scom.Parameters["@dateClosed"].Value = dateClosed;
            scom.Parameters["@createUser_ID"].Value = createUser_ID;
            scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
            scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
            scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
            scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
            scom.Parameters["@canceledTerminal_ID"].Value = canceledTerminal_ID;
            scom.Parameters["@dateCreate"].Value = dateCreate;
            scom.Parameters["@dateModified"].Value = dateModified;
            scom.Parameters["@dateCanceled"].Value = dateCanceled;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the tbl_comCommissionPeriodMaster table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_comCommissionPeriodMasterUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@periodIndex", SqlDbType.BigInt, 8);
            scom.Parameters.Add("@periodName", SqlDbType.VarChar, 200);
            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isPeriodClose", SqlDbType.Bit, 1);
            scom.Parameters.Add("@closedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@dateClosed", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@canceledUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@canceledTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCreate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime, 8);


            scom.Parameters["@periodIndex"].Value = periodIndex;
            scom.Parameters["@periodName"].Value = periodName;
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters["@dateTo"].Value = dateTo;
            scom.Parameters["@isPeriodClose"].Value = isPeriodClose;
            scom.Parameters["@closedUser_ID"].Value = closedUser_ID;
            scom.Parameters["@dateClosed"].Value = dateClosed;
            scom.Parameters["@createUser_ID"].Value = createUser_ID;
            scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
            scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
            scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
            scom.Parameters["@canceledUser_ID"].Value = canceledUser_ID;
            scom.Parameters["@canceledTerminal_ID"].Value = canceledTerminal_ID;
            scom.Parameters["@dateCreate"].Value = dateCreate;
            scom.Parameters["@dateModified"].Value = dateModified;
            scom.Parameters["@dateCanceled"].Value = dateCanceled;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the tbl_comCommissionPeriodMaster table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_comCommissionPeriodMasterDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@periodIndex", SqlDbType.BigInt, 8);
            scom.Parameters["@periodIndex"].Value = periodIndex;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_comCommissionPeriodMaster table.
        /// </summary>
        public static tbl_comCommissionPeriodMaster Select(Int64 periodIndex_Incoming)
        {

            tbl_comCommissionPeriodMaster tbl_comCommissionPeriodMasterins = new tbl_comCommissionPeriodMaster();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_comCommissionPeriodMasterSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@periodIndex", SqlDbType.BigInt, 8);
            scom.Parameters["@periodIndex"].Value = periodIndex_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_comCommissionPeriodMasterins = Maketbl_comCommissionPeriodMaster(dataReader);
                }
                else
                {
                    tbl_comCommissionPeriodMasterins = null;
                }
            }
            scon.Close();
            return tbl_comCommissionPeriodMasterins;
        }

        /// <summary>
        /// Selects all records from the tbl_comCommissionPeriodMaster table.
        /// </summary>
        public static List<tbl_comCommissionPeriodMaster> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_comCommissionPeriodMasterSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<tbl_comCommissionPeriodMaster> tbl_comCommissionPeriodMasterList = new List<tbl_comCommissionPeriodMaster>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_comCommissionPeriodMaster tbl_comCommissionPeriodMaster = Maketbl_comCommissionPeriodMaster(dataReader);
                    tbl_comCommissionPeriodMasterList.Add(tbl_comCommissionPeriodMaster);
                }
            }
            scon.Close();
            return tbl_comCommissionPeriodMasterList;
        }

        /// <summary>
        /// Creates a new instance of the tbl_comCommissionPeriodMaster class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_comCommissionPeriodMaster Maketbl_comCommissionPeriodMaster(SqlDataReader dataReader)
        {
            tbl_comCommissionPeriodMaster tbl_comCommissionPeriodMaster = new tbl_comCommissionPeriodMaster();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_comCommissionPeriodMaster.PeriodIndex = dataReader.GetInt64(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_comCommissionPeriodMaster.PeriodName = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_comCommissionPeriodMaster.DateFrom = dataReader.GetDateTime(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_comCommissionPeriodMaster.DateTo = dataReader.GetDateTime(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_comCommissionPeriodMaster.IsPeriodClose = dataReader.GetBoolean(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_comCommissionPeriodMaster.ClosedUser_ID = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                tbl_comCommissionPeriodMaster.DateClosed = dataReader.GetDateTime(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                tbl_comCommissionPeriodMaster.CreateUser_ID = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                tbl_comCommissionPeriodMaster.CreateTerminal_ID = dataReader.GetString(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                tbl_comCommissionPeriodMaster.ModifiedUser_ID = dataReader.GetString(9);
            }
            if (dataReader.IsDBNull(10) == false)
            {
                tbl_comCommissionPeriodMaster.ModifiedTerminal_ID = dataReader.GetString(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                tbl_comCommissionPeriodMaster.CanceledUser_ID = dataReader.GetString(11);
            }
            if (dataReader.IsDBNull(12) == false)
            {
                tbl_comCommissionPeriodMaster.CanceledTerminal_ID = dataReader.GetString(12);
            }
            if (dataReader.IsDBNull(13) == false)
            {
                tbl_comCommissionPeriodMaster.DateCreate = dataReader.GetDateTime(13);
            }
            if (dataReader.IsDBNull(14) == false)
            {
                tbl_comCommissionPeriodMaster.DateModified = dataReader.GetDateTime(14);
            }
            if (dataReader.IsDBNull(15) == false)
            {
                tbl_comCommissionPeriodMaster.DateCanceled = dataReader.GetDateTime(15);
            }

            return tbl_comCommissionPeriodMaster;
        }
        /// <summary>
        /// This makes tbl_comCommissionPeriodMaster datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new tbl_comCommissionPeriodMaster object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(tbl_comCommissionPeriodMaster tbl_comCommissionPeriodMaster)
        {
            DataTable dt = new DataTable();

            DataColumn col_periodIndex = new DataColumn("periodIndex", typeof(long));
            DataColumn col_periodName = new DataColumn("periodName", typeof(string));
            DataColumn col_dateFrom = new DataColumn("dateFrom", typeof(DateTime));
            DataColumn col_dateTo = new DataColumn("dateTo", typeof(DateTime));
            DataColumn col_isPeriodClose = new DataColumn("isPeriodClose", typeof(bool));
            DataColumn col_closedUser_ID = new DataColumn("closedUser_ID", typeof(string));
            DataColumn col_dateClosed = new DataColumn("dateClosed", typeof(DateTime));
            DataColumn col_createUser_ID = new DataColumn("createUser_ID", typeof(string));
            DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID", typeof(string));
            DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID", typeof(string));
            DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID", typeof(string));
            DataColumn col_canceledUser_ID = new DataColumn("canceledUser_ID", typeof(string));
            DataColumn col_canceledTerminal_ID = new DataColumn("canceledTerminal_ID", typeof(string));
            DataColumn col_dateCreate = new DataColumn("dateCreate", typeof(DateTime));
            DataColumn col_dateModified = new DataColumn("dateModified", typeof(DateTime));
            DataColumn col_dateCanceled = new DataColumn("dateCanceled", typeof(DateTime));
            dt.Columns.AddRange(new DataColumn[] { col_periodIndex, col_periodName, col_dateFrom, col_dateTo, col_isPeriodClose, col_closedUser_ID, col_dateClosed, col_createUser_ID, col_createTerminal_ID, col_modifiedUser_ID, col_modifiedTerminal_ID, col_canceledUser_ID, col_canceledTerminal_ID, col_dateCreate, col_dateModified, col_dateCanceled, }); return dt;
        }
        /// <summary>
        /// This fills tbl_comCommissionPeriodMaster datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new tbl_comCommissionPeriodMaster object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, tbl_comCommissionPeriodMaster user)
        {
            DataRow drow = dt.NewRow();

            drow["periodIndex"] = user.periodIndex;
            drow["periodName"] = user.periodName;
            drow["dateFrom"] = user.dateFrom;
            drow["dateTo"] = user.dateTo;
            drow["isPeriodClose"] = user.isPeriodClose;
            drow["closedUser_ID"] = user.closedUser_ID;
            drow["dateClosed"] = user.dateClosed;
            drow["createUser_ID"] = user.createUser_ID;
            drow["createTerminal_ID"] = user.createTerminal_ID;
            drow["modifiedUser_ID"] = user.modifiedUser_ID;
            drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
            drow["canceledUser_ID"] = user.canceledUser_ID;
            drow["canceledTerminal_ID"] = user.canceledTerminal_ID;
            drow["dateCreate"] = user.dateCreate;
            drow["dateModified"] = user.dateModified;
            drow["dateCanceled"] = user.dateCanceled;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
