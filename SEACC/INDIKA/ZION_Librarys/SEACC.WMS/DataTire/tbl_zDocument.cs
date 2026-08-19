using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTire
{
    public sealed class tbl_zDocument
    {
        #region Fields
        private string docType_ID;
        private string docName;
        private bool isCanceled;
        private string userID_Created;
        private string userID_Modified;
        private string userID_Canceled;
        private string terminalID_Created;
        private string terminalID_Modified;
        private string terminalID_Canceled;
        private DateTime date_Created;
        private DateTime date_Modified;
        private DateTime date_Canceled;
        #endregion

        #region Constructors
        public tbl_zDocument()
        {
        }

        public tbl_zDocument(string docType_ID, string docName, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled)
        {
            this.docType_ID = docType_ID;
            this.docName = docName;
            this.isCanceled = isCanceled;
            this.userID_Created = userID_Created;
            this.userID_Modified = userID_Modified;
            this.userID_Canceled = userID_Canceled;
            this.terminalID_Created = terminalID_Created;
            this.terminalID_Modified = terminalID_Modified;
            this.terminalID_Canceled = terminalID_Canceled;
            this.date_Created = date_Created;
            this.date_Modified = date_Modified;
            this.date_Canceled = date_Canceled;
        } 
        #endregion

        #region Properties
        public string DocType_ID
        {
            get { return docType_ID; }
            set { docType_ID = value; }
        }
        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }
        public bool IsCanceled
        {
            get { return isCanceled; }
            set { isCanceled = value; }
        }

        public string UserID_Created
        {
            get { return userID_Created; }
            set { userID_Created = value; }
        }

        public string UserID_Modified
        {
            get { return userID_Modified; }
            set { userID_Modified = value; }
        }

        public string UserID_Canceled
        {
            get { return userID_Canceled; }
            set { userID_Canceled = value; }
        }

        public string TerminalID_Created
        {
            get { return terminalID_Created; }
            set { terminalID_Created = value; }
        }

        public string TerminalID_Modified
        {
            get { return terminalID_Modified; }
            set { terminalID_Modified = value; }
        }

        public string TerminalID_Canceled
        {
            get { return terminalID_Canceled; }
            set { terminalID_Canceled = value; }
        }

        public DateTime Date_Created
        {
            get { return date_Created; }
            set { date_Created = value; }
        }

        public DateTime Date_Modified
        {
            get { return date_Modified; }
            set { date_Modified = value; }
        }

        public DateTime Date_Canceled
        {
            get { return date_Canceled; }
            set { date_Canceled = value; }
        } 
        #endregion

        #region Methods
        public static tbl_zDocument Select(string docType_ID_Incoming)
        {

            tbl_zDocument tbl_documents = new tbl_zDocument();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_zDocumentSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@document_typeID", SqlDbType.VarChar, 8);
            scom.Parameters["@document_typeID"].Value = docType_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_documents = Maketbl_zDoc(dataReader);
                }
                else
                {
                    tbl_documents = null;
                }
            }
            scon.Close();
            return tbl_documents;
        }

        private static tbl_zDocument Maketbl_zDoc(SqlDataReader dataReader)
        {
            tbl_zDocument tbl_zDocument = new tbl_zDocument();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_zDocument.DocType_ID = dataReader.GetString(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_zDocument.DocName = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_zDocument.IsCanceled = dataReader.GetBoolean(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_zDocument.UserID_Created = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                tbl_zDocument.UserID_Modified = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                tbl_zDocument.UserID_Canceled = dataReader.GetString(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                tbl_zDocument.TerminalID_Created = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                tbl_zDocument.TerminalID_Modified = dataReader.GetString(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                tbl_zDocument.TerminalID_Canceled = dataReader.GetString(9);
            }
            if (dataReader.IsDBNull(10) == false)
            {
                tbl_zDocument.Date_Created = dataReader.GetDateTime(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                tbl_zDocument.Date_Modified = dataReader.GetDateTime(11);
            }
            if (dataReader.IsDBNull(12) == false)
            {
                tbl_zDocument.Date_Canceled = dataReader.GetDateTime(12);
            }
            return tbl_zDocument;
        }

        #endregion
    }
}
