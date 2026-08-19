using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class tbl_tasEmployeeShift
    {
        #region Fields
        private int employeeShift_ID;
        private string company_ID;
        private string companyBranch_ID;
        private string employee_ID;
        private string shift_ID;
        private DateTime effective_Date;
        private bool isDeleted;
        private string createUser_ID;
        private string modifiedUser_ID;
        private string deletedUser_ID;
        private string createTerminal_ID;
        private string modifiedTerminal_ID;
        private string deletedTerminal_ID;
        private DateTime dateCreate;
        private DateTime dateModified;
        private DateTime dateDeleted;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the tbl_tasEmployeeShift class.
        /// </summary>
        public tbl_tasEmployeeShift()
        {
        }

        /// <summary>
        /// Initializes a new instance of the tbl_tasEmployeeShift class.
        /// </summary>
        public tbl_tasEmployeeShift(int employeeShift_ID, string company_ID, string companyBranch_ID, string employee_ID, string shift_ID, DateTime effective_Date, bool isDeleted, string createUser_ID, string modifiedUser_ID, string deletedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted)
        {
            this.employeeShift_ID = employeeShift_ID;
            this.company_ID = company_ID;
            this.companyBranch_ID = companyBranch_ID;
            this.employee_ID = employee_ID;
            this.shift_ID = shift_ID;
            this.effective_Date = effective_Date;
            this.isDeleted = isDeleted;
            this.createUser_ID = createUser_ID;
            this.modifiedUser_ID = modifiedUser_ID;
            this.deletedUser_ID = deletedUser_ID;
            this.createTerminal_ID = createTerminal_ID;
            this.modifiedTerminal_ID = modifiedTerminal_ID;
            this.deletedTerminal_ID = deletedTerminal_ID;
            this.dateCreate = dateCreate;
            this.dateModified = dateModified;
            this.dateDeleted = dateDeleted;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the EmployeeShift_ID value.
        /// </summary>
        public int EmployeeShift_ID
        {
            get { return employeeShift_ID; }
            set { employeeShift_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Company_ID value.
        /// </summary>
        public string Company_ID
        {
            get { return company_ID; }
            set { company_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CompanyBranch_ID value.
        /// </summary>
        public string CompanyBranch_ID
        {
            get { return companyBranch_ID; }
            set { companyBranch_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_ID value.
        /// </summary>
        public string Employee_ID
        {
            get { return employee_ID; }
            set { employee_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Shift_ID value.
        /// </summary>
        public string Shift_ID
        {
            get { return shift_ID; }
            set { shift_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Effective_Date value.
        /// </summary>
        public DateTime Effective_Date
        {
            get { return effective_Date; }
            set { effective_Date = value; }
        }

        /// <summary>
        /// Gets or sets the IsDeleted value.
        /// </summary>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
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
        /// Gets or sets the ModifiedUser_ID value.
        /// </summary>
        public string ModifiedUser_ID
        {
            get { return modifiedUser_ID; }
            set { modifiedUser_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DeletedUser_ID value.
        /// </summary>
        public string DeletedUser_ID
        {
            get { return deletedUser_ID; }
            set { deletedUser_ID = value; }
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
        /// Gets or sets the ModifiedTerminal_ID value.
        /// </summary>
        public string ModifiedTerminal_ID
        {
            get { return modifiedTerminal_ID; }
            set { modifiedTerminal_ID = value; }
        }

        /// <summary>
        /// Gets or sets the DeletedTerminal_ID value.
        /// </summary>
        public string DeletedTerminal_ID
        {
            get { return deletedTerminal_ID; }
            set { deletedTerminal_ID = value; }
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
        /// Gets or sets the DateDeleted value.
        /// </summary>
        public DateTime DateDeleted
        {
            get { return dateDeleted; }
            set { dateDeleted = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the tbl_tasEmployeeShift table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@employeeShift_ID", SqlDbType.Int, 4);
            scom.Parameters.Add("@company_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@shift_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@effective_Date", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isDeleted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCreate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime, 8);

            scom.Parameters["@employeeShift_ID"].Value = employeeShift_ID;
            scom.Parameters["@company_ID"].Value = company_ID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@employee_ID"].Value = employee_ID;
            scom.Parameters["@shift_ID"].Value = shift_ID;
            scom.Parameters["@effective_Date"].Value = effective_Date;
            scom.Parameters["@isDeleted"].Value = isDeleted;
            scom.Parameters["@createUser_ID"].Value = createUser_ID;
            scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
            scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
            scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
            scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
            scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
            scom.Parameters["@dateCreate"].Value = dateCreate;
            scom.Parameters["@dateModified"].Value = dateModified;
            scom.Parameters["@dateDeleted"].Value = dateDeleted;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the tbl_tasEmployeeShift table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@employeeShift_ID", SqlDbType.Int, 4);
            scom.Parameters.Add("@company_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@shift_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@effective_Date", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@isDeleted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCreate", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime, 8);


            scom.Parameters["@employeeShift_ID"].Value = employeeShift_ID;
            scom.Parameters["@company_ID"].Value = company_ID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@employee_ID"].Value = employee_ID;
            scom.Parameters["@shift_ID"].Value = shift_ID;
            scom.Parameters["@effective_Date"].Value = effective_Date;
            scom.Parameters["@isDeleted"].Value = isDeleted;
            scom.Parameters["@createUser_ID"].Value = createUser_ID;
            scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
            scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
            scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
            scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
            scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
            scom.Parameters["@dateCreate"].Value = dateCreate;
            scom.Parameters["@dateModified"].Value = dateModified;
            scom.Parameters["@dateDeleted"].Value = dateDeleted;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the tbl_tasEmployeeShift table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@employeeShift_ID", SqlDbType.Int, 4);
            scom.Parameters["@employeeShift_ID"].Value = employeeShift_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_tasEmployeeShift table by a foreign key.
        /// </summary>
        public static void DeleteAllByEmployee_ID(string employee_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftDeleteAllByEmployee_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@employee_ID"].Value = employee_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_tasEmployeeShift table by a foreign key.
        /// </summary>
        public static void DeleteAllByShift_ID(string shift_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftDeleteAllByShift_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@shift_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@shift_ID"].Value = shift_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the tbl_tasEmployeeShift table.
        /// </summary>
        public static tbl_tasEmployeeShift Select(int employeeShift_ID_Incoming)
        {

            tbl_tasEmployeeShift tbl_tasEmployeeShiftins = new tbl_tasEmployeeShift();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@employeeShift_ID", SqlDbType.Int, 4);
            scom.Parameters["@employeeShift_ID"].Value = employeeShift_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_tasEmployeeShiftins = Maketbl_tasEmployeeShift(dataReader);
                }
                else
                {
                    tbl_tasEmployeeShiftins = null;
                }
            }
            scon.Close();
            return tbl_tasEmployeeShiftins;
        }

        /// <summary>
        /// Selects all records from the tbl_tasEmployeeShift table.
        /// </summary>
        public static List<tbl_tasEmployeeShift> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<tbl_tasEmployeeShift> tbl_tasEmployeeShiftList = new List<tbl_tasEmployeeShift>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasEmployeeShift tbl_tasEmployeeShift = Maketbl_tasEmployeeShift(dataReader);
                    tbl_tasEmployeeShiftList.Add(tbl_tasEmployeeShift);
                }
            }
            scon.Close();
            return tbl_tasEmployeeShiftList;
        }
        //Lasantha----------------------------------------------------------------------------------------

        public static tbl_tasEmployeeShift Select_Manual(string shift_ID_Incoming)
        {

            tbl_tasEmployeeShift tbl_tasShiftMasterins = new tbl_tasEmployeeShift();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasShiftMasterSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);

            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_tasShiftMasterins = Maketbl_tasShiftMaster(dataReader);
                }
                else
                {
                    tbl_tasShiftMasterins = null;
                }
            }
            scon.Close();
            return tbl_tasShiftMasterins;
        }
        //-------------------------------------------------------------------------------------------------
        private static tbl_tasEmployeeShift Maketbl_tasShiftMaster(SqlDataReader dataReader)
        {
            tbl_tasEmployeeShift tbl_tasShiftMaster = new tbl_tasEmployeeShift();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_tasShiftMaster.EmployeeShift_ID = int.Parse(dataReader.GetString(0));
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_tasShiftMaster.Company_ID = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_tasShiftMaster.CompanyBranch_ID = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_tasShiftMaster.Employee_ID = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_tasShiftMaster.Shift_ID = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_tasShiftMaster.Effective_Date = dataReader.GetDateTime(5);
            }
            if (dataReader.IsDBNull(25) == false)

                if (dataReader.IsDBNull(29) == false)
                {
                    tbl_tasShiftMaster.IsDeleted = dataReader.GetBoolean(6);
                }
            if (dataReader.IsDBNull(30) == false)
            {
                tbl_tasShiftMaster.CreateUser_ID = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(31) == false)
            {
                tbl_tasShiftMaster.ModifiedUser_ID = dataReader.GetString(8);
            }
            if (dataReader.IsDBNull(32) == false)
            {
                tbl_tasShiftMaster.DeletedUser_ID = dataReader.GetString(9);
            }
            if (dataReader.IsDBNull(33) == false)
            {
                tbl_tasShiftMaster.CreateTerminal_ID = dataReader.GetString(10);
            }
            if (dataReader.IsDBNull(34) == false)
            {
                tbl_tasShiftMaster.ModifiedTerminal_ID = dataReader.GetString(11);
            }
            if (dataReader.IsDBNull(35) == false)
            {
                tbl_tasShiftMaster.DeletedTerminal_ID = dataReader.GetString(12);
            }
            if (dataReader.IsDBNull(36) == false)
            {
                tbl_tasShiftMaster.DateCreate = dataReader.GetDateTime(13);
            }
            if (dataReader.IsDBNull(37) == false)
            {
                tbl_tasShiftMaster.DateModified = dataReader.GetDateTime(14);
            }
            if (dataReader.IsDBNull(38) == false)
            {
                tbl_tasShiftMaster.DateDeleted = dataReader.GetDateTime(15);
            }

            return tbl_tasShiftMaster;
        }
        //----------------------------------------------------------------------------------



        /// <summary>
        /// Selects all records from the tbl_tasEmployeeShift table by a foreign key.
        /// </summary>
        public static List<tbl_tasEmployeeShift> SelectAllByEmployee_ID(string employee_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftSelectAllByEmployee_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@employee_ID"].Value = employee_ID;
            List<tbl_tasEmployeeShift> tbl_tasEmployeeShiftList = new List<tbl_tasEmployeeShift>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasEmployeeShift tbl_tasEmployeeShift = Maketbl_tasEmployeeShift(dataReader);
                    tbl_tasEmployeeShiftList.Add(tbl_tasEmployeeShift);
                }
            }
            scon.Close();
            return tbl_tasEmployeeShiftList;
        }

        /// <summary>
        /// Selects all records from the tbl_tasEmployeeShift table by a foreign key.
        /// </summary>
        public static List<tbl_tasEmployeeShift> SelectAllByShift_ID(string shift_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeShiftSelectAllByShift_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@shift_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@shift_ID"].Value = shift_ID;
            List<tbl_tasEmployeeShift> tbl_tasEmployeeShiftList = new List<tbl_tasEmployeeShift>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasEmployeeShift tbl_tasEmployeeShift = Maketbl_tasEmployeeShift(dataReader);
                    tbl_tasEmployeeShiftList.Add(tbl_tasEmployeeShift);
                }
            }
            scon.Close();
            return tbl_tasEmployeeShiftList;
        }

        /// <summary>
        /// Creates a new instance of the tbl_tasEmployeeShift class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_tasEmployeeShift Maketbl_tasEmployeeShift(SqlDataReader dataReader)
        {
            tbl_tasEmployeeShift tbl_tasEmployeeShift = new tbl_tasEmployeeShift();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_tasEmployeeShift.EmployeeShift_ID = dataReader.GetInt32(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_tasEmployeeShift.Company_ID = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_tasEmployeeShift.CompanyBranch_ID = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_tasEmployeeShift.Employee_ID = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_tasEmployeeShift.Shift_ID = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_tasEmployeeShift.Effective_Date = dataReader.GetDateTime(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                tbl_tasEmployeeShift.IsDeleted = dataReader.GetBoolean(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                tbl_tasEmployeeShift.CreateUser_ID = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                tbl_tasEmployeeShift.ModifiedUser_ID = dataReader.GetString(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                tbl_tasEmployeeShift.DeletedUser_ID = dataReader.GetString(9);
            }
            if (dataReader.IsDBNull(10) == false)
            {
                tbl_tasEmployeeShift.CreateTerminal_ID = dataReader.GetString(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                tbl_tasEmployeeShift.ModifiedTerminal_ID = dataReader.GetString(11);
            }
            if (dataReader.IsDBNull(12) == false)
            {
                tbl_tasEmployeeShift.DeletedTerminal_ID = dataReader.GetString(12);
            }
            if (dataReader.IsDBNull(13) == false)
            {
                tbl_tasEmployeeShift.DateCreate = dataReader.GetDateTime(13);
            }
            if (dataReader.IsDBNull(14) == false)
            {
                tbl_tasEmployeeShift.DateModified = dataReader.GetDateTime(14);
            }
            if (dataReader.IsDBNull(15) == false)
            {
                tbl_tasEmployeeShift.DateDeleted = dataReader.GetDateTime(15);
            }

            return tbl_tasEmployeeShift;
        }
        /// <summary>
        /// This makes tbl_tasEmployeeShift datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new tbl_tasEmployeeShift object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(tbl_tasEmployeeShift tbl_tasEmployeeShift)
        {
            DataTable dt = new DataTable();

            DataColumn col_employeeShift_ID = new DataColumn("employeeShift_ID", typeof(int));
            DataColumn col_company_ID = new DataColumn("company_ID", typeof(string));
            DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID", typeof(string));
            DataColumn col_employee_ID = new DataColumn("employee_ID", typeof(string));
            DataColumn col_shift_ID = new DataColumn("shift_ID", typeof(string));
            DataColumn col_effective_Date = new DataColumn("effective_Date", typeof(DateTime));
            DataColumn col_isDeleted = new DataColumn("isDeleted", typeof(bool));
            DataColumn col_createUser_ID = new DataColumn("createUser_ID", typeof(string));
            DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID", typeof(string));
            DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID", typeof(string));
            DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID", typeof(string));
            DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID", typeof(string));
            DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID", typeof(string));
            DataColumn col_dateCreate = new DataColumn("dateCreate", typeof(DateTime));
            DataColumn col_dateModified = new DataColumn("dateModified", typeof(DateTime));
            DataColumn col_dateDeleted = new DataColumn("dateDeleted", typeof(DateTime));
            dt.Columns.AddRange(new DataColumn[] { col_employeeShift_ID, col_company_ID, col_companyBranch_ID, col_employee_ID, col_shift_ID, col_effective_Date, col_isDeleted, col_createUser_ID, col_modifiedUser_ID, col_deletedUser_ID, col_createTerminal_ID, col_modifiedTerminal_ID, col_deletedTerminal_ID, col_dateCreate, col_dateModified, col_dateDeleted, }); return dt;
        }
        /// <summary>
        /// This fills tbl_tasEmployeeShift datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new tbl_tasEmployeeShift object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, tbl_tasEmployeeShift user)
        {
            DataRow drow = dt.NewRow();

            drow["employeeShift_ID"] = user.employeeShift_ID;
            drow["company_ID"] = user.company_ID;
            drow["companyBranch_ID"] = user.companyBranch_ID;
            drow["employee_ID"] = user.employee_ID;
            drow["shift_ID"] = user.shift_ID;
            drow["effective_Date"] = user.effective_Date;
            drow["isDeleted"] = user.isDeleted;
            drow["createUser_ID"] = user.createUser_ID;
            drow["modifiedUser_ID"] = user.modifiedUser_ID;
            drow["deletedUser_ID"] = user.deletedUser_ID;
            drow["createTerminal_ID"] = user.createTerminal_ID;
            drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
            drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
            drow["dateCreate"] = user.dateCreate;
            drow["dateModified"] = user.dateModified;
            drow["dateDeleted"] = user.dateDeleted;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
