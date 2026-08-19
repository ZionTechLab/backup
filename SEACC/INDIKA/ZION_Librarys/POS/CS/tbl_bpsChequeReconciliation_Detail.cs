using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class tbl_bpsChequeReconciliation_Detail
    {
        #region Fields
        private string reconciliation_ID;
        private string chequeRegister_ID;
        private decimal penaltyAmount;
        private string chequeStatus_ID;
        private string glPosting_ID;
        private string postingStatus_ID;
        private DateTime dateReconciliation;
        private int companyAccount_ID;
        private int recSerialNo;
        private string chequeDeposit_ID;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the tbl_bpsChequeReconciliation_Detail class.
        /// </summary>
        public tbl_bpsChequeReconciliation_Detail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the tbl_bpsChequeReconciliation_Detail class.
        /// </summary>
        public tbl_bpsChequeReconciliation_Detail(string reconciliation_ID, string chequeRegister_ID, decimal penaltyAmount, string chequeStatus_ID, string glPosting_ID, string postingStatus_ID, DateTime dateReconciliation, int companyAccount_ID, int recSerialNo, string chequeDeposit_ID)
        {
            this.reconciliation_ID = reconciliation_ID;
            this.chequeRegister_ID = chequeRegister_ID;
            this.penaltyAmount = penaltyAmount;
            this.chequeStatus_ID = chequeStatus_ID;
            this.glPosting_ID = glPosting_ID;
            this.postingStatus_ID = postingStatus_ID;
            this.dateReconciliation = dateReconciliation;
            this.companyAccount_ID = companyAccount_ID;
            this.recSerialNo = recSerialNo;
            this.chequeDeposit_ID = chequeDeposit_ID;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Reconciliation_ID value.
        /// </summary>
        public string Reconciliation_ID
        {
            get { return reconciliation_ID; }
            set { reconciliation_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ChequeRegister_ID value.
        /// </summary>
        public string ChequeRegister_ID
        {
            get { return chequeRegister_ID; }
            set { chequeRegister_ID = value; }
        }

        /// <summary>
        /// Gets or sets the PenaltyAmount value.
        /// </summary>
        public decimal PenaltyAmount
        {
            get { return penaltyAmount; }
            set { penaltyAmount = value; }
        }

        /// <summary>
        /// Gets or sets the ChequeStatus_ID value.
        /// </summary>
        public string ChequeStatus_ID
        {
            get { return chequeStatus_ID; }
            set { chequeStatus_ID = value; }
        }

        /// <summary>
        /// Gets or sets the GlPosting_ID value.
        /// </summary>
        public string GlPosting_ID
        {
            get { return glPosting_ID; }
            set { glPosting_ID = value; }
        }

        /// <summary>
        /// Gets or sets the PostingStatus_ID value.
        /// </summary>
        public string PostingStatus_ID
        {
            get { return postingStatus_ID; }
            set { postingStatus_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DateReconciliation value.
        /// </summary>
        public DateTime DateReconciliation
        {
            get { return dateReconciliation; }
            set { dateReconciliation = value; }
        }

        /// <summary>
        /// Gets or sets the CompanyAccount_ID value.
        /// </summary>
        public int CompanyAccount_ID
        {
            get { return companyAccount_ID; }
            set { companyAccount_ID = value; }
        }

        /// <summary>
        /// Gets or sets the RecSerialNo value.
        /// </summary>
        public int RecSerialNo
        {
            get { return recSerialNo; }
            set { recSerialNo = value; }
        }

        /// <summary>
        /// Gets or sets the ChequeDeposit_ID value.
        /// </summary>
        public string ChequeDeposit_ID
        {
            get { return chequeDeposit_ID; }
            set { chequeDeposit_ID = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the tbl_bpsChequeReconciliation_Detail table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@penaltyAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int, 4);
            scom.Parameters.Add("@recSerialNo", SqlDbType.Int, 4);
            scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar, 20);

            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@penaltyAmount"].Value = penaltyAmount;
            scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
            scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
            scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
            scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
            scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
            scom.Parameters["@recSerialNo"].Value = recSerialNo;
            scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the tbl_bpsChequeReconciliation_Detail table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@penaltyAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int, 4);
            scom.Parameters.Add("@recSerialNo", SqlDbType.Int, 4);
            scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar, 20);


            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@penaltyAmount"].Value = penaltyAmount;
            scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
            scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
            scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
            scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
            scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
            scom.Parameters["@recSerialNo"].Value = recSerialNo;
            scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the tbl_bpsChequeReconciliation_Detail table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;

            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static void DeleteAllByChequeStatus_ID(string chequeStatus_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailDeleteAllByChequeStatus_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static void DeleteAllByReconciliation_ID_ChequeRegister_ID(string reconciliation_ID, string chequeRegister_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailDeleteAllByReconciliation_ID_ChequeRegister_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static void DeleteAllByReconciliation_ID(string reconciliation_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailDeleteAllByReconciliation_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailDeleteAllByChequeRegister_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_bpsChequeReconciliation_Detail table.
        /// </summary>
        public static tbl_bpsChequeReconciliation_Detail Select(string reconciliation_ID_Incoming, string chequeRegister_ID_Incoming)
        {

            tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detailins = new tbl_bpsChequeReconciliation_Detail();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID_Incoming;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_bpsChequeReconciliation_Detailins = Maketbl_bpsChequeReconciliation_Detail(dataReader);
                }
                else
                {
                    tbl_bpsChequeReconciliation_Detailins = null;
                }
            }
            scon.Close();
            return tbl_bpsChequeReconciliation_Detailins;
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table.
        /// </summary>
        public static List<tbl_bpsChequeReconciliation_Detail> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<tbl_bpsChequeReconciliation_Detail> tbl_bpsChequeReconciliation_DetailList = new List<tbl_bpsChequeReconciliation_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detail = Maketbl_bpsChequeReconciliation_Detail(dataReader);
                    tbl_bpsChequeReconciliation_DetailList.Add(tbl_bpsChequeReconciliation_Detail);
                }
            }
            scon.Close();
            return tbl_bpsChequeReconciliation_DetailList;
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static List<tbl_bpsChequeReconciliation_Detail> SelectAllByChequeStatus_ID(string chequeStatus_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailSelectAllByChequeStatus_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
            List<tbl_bpsChequeReconciliation_Detail> tbl_bpsChequeReconciliation_DetailList = new List<tbl_bpsChequeReconciliation_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detail = Maketbl_bpsChequeReconciliation_Detail(dataReader);
                    tbl_bpsChequeReconciliation_DetailList.Add(tbl_bpsChequeReconciliation_Detail);
                }
            }
            scon.Close();
            return tbl_bpsChequeReconciliation_DetailList;
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static List<tbl_bpsChequeReconciliation_Detail> SelectAllByReconciliation_ID_ChequeRegister_ID(string reconciliation_ID, string chequeRegister_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailSelectAllByReconciliation_ID_ChequeRegister_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            List<tbl_bpsChequeReconciliation_Detail> tbl_bpsChequeReconciliation_DetailList = new List<tbl_bpsChequeReconciliation_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detail = Maketbl_bpsChequeReconciliation_Detail(dataReader);
                    tbl_bpsChequeReconciliation_DetailList.Add(tbl_bpsChequeReconciliation_Detail);
                }
            }
            scon.Close();
            return tbl_bpsChequeReconciliation_DetailList;
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static List<tbl_bpsChequeReconciliation_Detail> SelectAllByReconciliation_ID(string reconciliation_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailSelectAllByReconciliation_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
            List<tbl_bpsChequeReconciliation_Detail> tbl_bpsChequeReconciliation_DetailList = new List<tbl_bpsChequeReconciliation_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detail = Maketbl_bpsChequeReconciliation_Detail(dataReader);
                    tbl_bpsChequeReconciliation_DetailList.Add(tbl_bpsChequeReconciliation_Detail);
                }
            }
            scon.Close();
            return tbl_bpsChequeReconciliation_DetailList;
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeReconciliation_Detail table by a foreign key.
        /// </summary>
        public static List<tbl_bpsChequeReconciliation_Detail> SelectAllByChequeRegister_ID(string chequeRegister_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliation_DetailSelectAllByChequeRegister_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            List<tbl_bpsChequeReconciliation_Detail> tbl_bpsChequeReconciliation_DetailList = new List<tbl_bpsChequeReconciliation_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detail = Maketbl_bpsChequeReconciliation_Detail(dataReader);
                    tbl_bpsChequeReconciliation_DetailList.Add(tbl_bpsChequeReconciliation_Detail);
                }
            }
            scon.Close();
            return tbl_bpsChequeReconciliation_DetailList;
        }

        /// <summary>
        /// Creates a new instance of the tbl_bpsChequeReconciliation_Detail class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_bpsChequeReconciliation_Detail Maketbl_bpsChequeReconciliation_Detail(SqlDataReader dataReader)
        {
            tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detail = new tbl_bpsChequeReconciliation_Detail();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_bpsChequeReconciliation_Detail.Reconciliation_ID = dataReader.GetString(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_bpsChequeReconciliation_Detail.ChequeRegister_ID = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_bpsChequeReconciliation_Detail.PenaltyAmount = dataReader.GetDecimal(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_bpsChequeReconciliation_Detail.ChequeStatus_ID = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_bpsChequeReconciliation_Detail.GlPosting_ID = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_bpsChequeReconciliation_Detail.PostingStatus_ID = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                tbl_bpsChequeReconciliation_Detail.DateReconciliation = dataReader.GetDateTime(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                tbl_bpsChequeReconciliation_Detail.CompanyAccount_ID = dataReader.GetInt32(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                tbl_bpsChequeReconciliation_Detail.RecSerialNo = dataReader.GetInt32(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                tbl_bpsChequeReconciliation_Detail.ChequeDeposit_ID = dataReader.GetString(9);
            }

            return tbl_bpsChequeReconciliation_Detail;
        }
        /// <summary>
        /// This makes tbl_bpsChequeReconciliation_Detail datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new tbl_bpsChequeReconciliation_Detail object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(tbl_bpsChequeReconciliation_Detail tbl_bpsChequeReconciliation_Detail)
        {
            DataTable dt = new DataTable();

            DataColumn col_reconciliation_ID = new DataColumn("reconciliation_ID", typeof(string));
            DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID", typeof(string));
            DataColumn col_penaltyAmount = new DataColumn("penaltyAmount", typeof(decimal));
            DataColumn col_chequeStatus_ID = new DataColumn("chequeStatus_ID", typeof(string));
            DataColumn col_glPosting_ID = new DataColumn("glPosting_ID", typeof(string));
            DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID", typeof(string));
            DataColumn col_dateReconciliation = new DataColumn("dateReconciliation", typeof(DateTime));
            DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID", typeof(int));
            DataColumn col_recSerialNo = new DataColumn("recSerialNo", typeof(int));
            DataColumn col_chequeDeposit_ID = new DataColumn("chequeDeposit_ID", typeof(string));
            dt.Columns.AddRange(new DataColumn[] { col_reconciliation_ID, col_chequeRegister_ID, col_penaltyAmount, col_chequeStatus_ID, col_glPosting_ID, col_postingStatus_ID, col_dateReconciliation, col_companyAccount_ID, col_recSerialNo, col_chequeDeposit_ID, }); return dt;
        }
        /// <summary>
        /// This fills tbl_bpsChequeReconciliation_Detail datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new tbl_bpsChequeReconciliation_Detail object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, tbl_bpsChequeReconciliation_Detail user)
        {
            DataRow drow = dt.NewRow();

            drow["reconciliation_ID"] = user.reconciliation_ID;
            drow["chequeRegister_ID"] = user.chequeRegister_ID;
            drow["penaltyAmount"] = user.penaltyAmount;
            drow["chequeStatus_ID"] = user.chequeStatus_ID;
            drow["glPosting_ID"] = user.glPosting_ID;
            drow["postingStatus_ID"] = user.postingStatus_ID;
            drow["dateReconciliation"] = user.dateReconciliation;
            drow["companyAccount_ID"] = user.companyAccount_ID;
            drow["recSerialNo"] = user.recSerialNo;
            drow["chequeDeposit_ID"] = user.chequeDeposit_ID;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
