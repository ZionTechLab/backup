using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class tbl_DataBaseBackup
    {
        #region Fields
        //  private string sDBPath;
        // private string sFileName;
        #endregion

        #region BackupMethods
        public void Backup(string sDatabase, string sBackupType, string sPath)
        {
            SqlConnection scon = DBHandling.GetConnection();
            // SqlCommand command = new SqlCommand("trc_DatabaseBackup", scon);
            SqlCommand command = new SqlCommand(@"BACKUP DATABASE SEACC_Chemical TO  DISK = N'J:\Program Files\Microsoft SQL Server\MSSQL10_50.DTQPUB\MSSQL\Backup\SEACC_AKT.bak' WITH NOFORMAT, NOINIT,    NOREWIND, NOUNLOAD,  STATS = 5", scon);
            command.CommandType = CommandType.Text;

            command.CommandTimeout = 600;

            command.Parameters.Add("@name", SqlDbType.VarChar).Value = sDatabase;
            command.Parameters.Add("@path", SqlDbType.VarChar).Value = sPath;
            scon.Open();

            scon.InfoMessage += delegate(object sender, SqlInfoMessageEventArgs e)
   {
       

   }
       ;




            command.ExecuteNonQuery();
            scon.Close();
        }
        #endregion

    }
}


