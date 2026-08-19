using DataTire;
using Digiteq;
using Digiteq_Logic;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SEACC_Commission
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                DBHandling.ConnectionString = clsSecurity.decryptPassword(args[0]);
                clsSecurity.TerminalID = clsSecurity.decryptPassword(args[1]);
                clsSecurity.UserIDLoged = clsSecurity.decryptPassword(args[2]);
                clsSecurity.iLoginSession_Index = int.Parse(clsSecurity.decryptPassword(args[3]));
                clsSecurity.CompanyID = clsSecurity.decryptPassword(args[4]);
                clsSecurity.BranchID = clsSecurity.decryptPassword(args[5]);
                clsSecurity.Server = clsSecurity.decryptPassword(args[6]);
                clsSecurity.Domain = clsSecurity.decryptPassword(args[7]);

                SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
                connBuilder.ConnectionString = DBHandling.ConnectionString;
                clsSecurity.Database = connBuilder.InitialCatalog;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               // Application.Run(new frm_CommisionPeriod());
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
    }
}
