using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class tbl_audBackupLog
    {
        #region Fields
        private int backup_Index;
        private DateTime backupDateTime;
        private int backupType;
        private bool isBackupSuccessfull;
        private string user_ID;
        private string terminal_ID;
        private string remarks;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the tbl_audBackupLog class.
        /// </summary>
        public tbl_audBackupLog()
        {
        }

        /// <summary>
        /// Initializes a new instance of the tbl_audBackupLog class.
        /// </summary>
        public tbl_audBackupLog(DateTime backupDateTime, int backupType, bool isBackupSuccessfull, string user_ID, string terminal_ID, string remarks)
        {
            this.backupDateTime = backupDateTime;
            this.backupType = backupType;
            this.isBackupSuccessfull = isBackupSuccessfull;
            this.user_ID = user_ID;
            this.terminal_ID = terminal_ID;
            this.remarks = remarks;
        }

        /// <summary>
        /// Initializes a new instance of the tbl_audBackupLog class.
        /// </summary>
        public tbl_audBackupLog(int backup_Index, DateTime backupDateTime, int backupType, bool isBackupSuccessfull, string user_ID, string terminal_ID, string remarks)
        {
            this.backup_Index = backup_Index;
            this.backupDateTime = backupDateTime;
            this.backupType = backupType;
            this.isBackupSuccessfull = isBackupSuccessfull;
            this.user_ID = user_ID;
            this.terminal_ID = terminal_ID;
            this.remarks = remarks;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Backup_Index value.
        /// </summary>
        public int Backup_Index
        {
            get { return backup_Index; }
            set { backup_Index = value; }
        }

        /// <summary>
        /// Gets or sets the BackupDateTime value.
        /// </summary>
        public DateTime BackupDateTime
        {
            get { return backupDateTime; }
            set { backupDateTime = value; }
        }

        /// <summary>
        /// Gets or sets the BackupType value.
        /// </summary>
        public int BackupType
        {
            get { return backupType; }
            set { backupType = value; }
        }

        /// <summary>
        /// Gets or sets the IsBackupSuccessfull value.
        /// </summary>
        public bool IsBackupSuccessfull
        {
            get { return isBackupSuccessfull; }
            set { isBackupSuccessfull = value; }
        }

        /// <summary>
        /// Gets or sets the User_ID value.
        /// </summary>
        public string User_ID
        {
            get { return user_ID; }
            set { user_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Terminal_ID value.
        /// </summary>
        public string Terminal_ID
        {
            get { return terminal_ID; }
            set { terminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Remarks value.
        /// </summary>
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the tbl_audBackupLog table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_audBackupLogInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@backupDateTime", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@backupType", SqlDbType.Int, 4);
            scom.Parameters.Add("@isBackupSuccessfull", SqlDbType.Bit, 1);
            scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@remarks", SqlDbType.VarChar, -1);

            scom.Parameters["@backupDateTime"].Value = backupDateTime;
            scom.Parameters["@backupType"].Value = backupType;
            scom.Parameters["@isBackupSuccessfull"].Value = isBackupSuccessfull;
            scom.Parameters["@user_ID"].Value = user_ID;
            scom.Parameters["@terminal_ID"].Value = terminal_ID;
            scom.Parameters["@remarks"].Value = remarks;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the tbl_audBackupLog table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_audBackupLogUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@backupDateTime", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@backupType", SqlDbType.Int, 4);
            scom.Parameters.Add("@isBackupSuccessfull", SqlDbType.Bit, 1);
            scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@remarks", SqlDbType.VarChar, -1);


            scom.Parameters["@backupDateTime"].Value = backupDateTime;
            scom.Parameters["@backupType"].Value = backupType;
            scom.Parameters["@isBackupSuccessfull"].Value = isBackupSuccessfull;
            scom.Parameters["@user_ID"].Value = user_ID;
            scom.Parameters["@terminal_ID"].Value = terminal_ID;
            scom.Parameters["@remarks"].Value = remarks;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the tbl_audBackupLog table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_audBackupLogDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@backup_Index", SqlDbType.Int, 4);
            scom.Parameters["@backup_Index"].Value = backup_Index;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_audBackupLog table.
        /// </summary>
        public static tbl_audBackupLog Select(int backup_Index_Incoming)
        {

            tbl_audBackupLog tbl_audBackupLogins = new tbl_audBackupLog();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_audBackupLogSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@backup_Index", SqlDbType.Int, 4);
            scom.Parameters["@backup_Index"].Value = backup_Index_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_audBackupLogins = Maketbl_audBackupLog(dataReader);
                }
                else
                {
                    tbl_audBackupLogins = null;
                }
            }
            scon.Close();
            return tbl_audBackupLogins;
        }

        /// <summary>
        /// Selects all records from the tbl_audBackupLog table.
        /// </summary>
        public static List<tbl_audBackupLog> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_audBackupLogSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<tbl_audBackupLog> tbl_audBackupLogList = new List<tbl_audBackupLog>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_audBackupLog tbl_audBackupLog = Maketbl_audBackupLog(dataReader);
                    tbl_audBackupLogList.Add(tbl_audBackupLog);
                }
            }
            scon.Close();
            return tbl_audBackupLogList;
        }

        public static DataTable SelectAll_DataTable()
        {
            DataTable dt_tbl_audBackupLogList=new DataTable();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("SELECT TOP(5) [backupDateTime] ,[user_ID] FROM [tbl_audBackupLog]  where [isBackupSuccessfull]=1 Order By [backupDateTime] DESC", scon);
            scom.CommandType = CommandType.Text;
            scon.Open();

            SqlDataAdapter da = new SqlDataAdapter(scom);
            da.Fill(dt_tbl_audBackupLogList);
         
            da.Dispose();
            //List<tbl_audBackupLog> tbl_audBackupLogList = new List<tbl_audBackupLog>();
            //using (SqlDataReader dataReader = scom.ExecuteReader())
            //{
            //    while (dataReader.Read())
            //    {
            //        tbl_audBackupLog tbl_audBackupLog = Maketbl_audBackupLog(dataReader);
            //        tbl_audBackupLogList.Add(tbl_audBackupLog);
            //    }
            //}
            scon.Close();
            return dt_tbl_audBackupLogList;
        }

        /// <summary>
        /// Creates a new instance of the tbl_audBackupLog class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_audBackupLog Maketbl_audBackupLog(SqlDataReader dataReader)
        {
            tbl_audBackupLog tbl_audBackupLog = new tbl_audBackupLog();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_audBackupLog.Backup_Index = dataReader.GetInt32(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_audBackupLog.BackupDateTime = dataReader.GetDateTime(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_audBackupLog.BackupType = dataReader.GetInt32(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_audBackupLog.IsBackupSuccessfull = dataReader.GetBoolean(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_audBackupLog.User_ID = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_audBackupLog.Terminal_ID = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                tbl_audBackupLog.Remarks = dataReader.GetString(6);
            }

            return tbl_audBackupLog;
        }
        /// <summary>
        /// This makes tbl_audBackupLog datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new tbl_audBackupLog object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(tbl_audBackupLog tbl_audBackupLog)
        {
            DataTable dt = new DataTable();

            DataColumn col_backup_Index = new DataColumn("backup_Index", typeof(int));
            DataColumn col_backupDateTime = new DataColumn("backupDateTime", typeof(DateTime));
            DataColumn col_backupType = new DataColumn("backupType", typeof(int));
            DataColumn col_isBackupSuccessfull = new DataColumn("isBackupSuccessfull", typeof(bool));
            DataColumn col_user_ID = new DataColumn("user_ID", typeof(string));
            DataColumn col_terminal_ID = new DataColumn("terminal_ID", typeof(string));
            DataColumn col_remarks = new DataColumn("remarks", typeof(string));
            dt.Columns.AddRange(new DataColumn[] { col_backup_Index, col_backupDateTime, col_backupType, col_isBackupSuccessfull, col_user_ID, col_terminal_ID, col_remarks, }); return dt;
        }
        /// <summary>
        /// This fills tbl_audBackupLog datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new tbl_audBackupLog object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, tbl_audBackupLog user)
        {
            DataRow drow = dt.NewRow();

            drow["backup_Index"] = user.backup_Index;
            drow["backupDateTime"] = user.backupDateTime;
            drow["backupType"] = user.backupType;
            drow["isBackupSuccessfull"] = user.isBackupSuccessfull;
            drow["user_ID"] = user.user_ID;
            drow["terminal_ID"] = user.terminal_ID;
            drow["remarks"] = user.remarks;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
