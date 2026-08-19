using System;
using System.Collections.Generic;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Windows.Forms;
using DataTire;
using System.Data.SqlClient;

namespace Digiteq
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                SEACC.DATA.DBHandling.ConnectionString= clsSecurity.decryptPassword(args[0]);
                DBHandling.ConnectionString = clsSecurity.decryptPassword(args[0]);
                clsSecurity.TerminalID = clsSecurity.decryptPassword(args[1]);
                clsSecurity.UserIDLoged = clsSecurity.decryptPassword(args[2]);
                clsSecurity.iLoginSession_Index = int.Parse(clsSecurity.decryptPassword(args[3]));
                clsSecurity.CompanyID = clsSecurity.decryptPassword(args[4]);
                clsSecurity.BranchID = clsSecurity.decryptPassword(args[5]);
                clsSecurity.Server = clsSecurity.decryptPassword(args[6]);
                clsSecurity.Domain = clsSecurity.decryptPassword(args[7]);
                clsSecurity.color = (args.Length==9) ?System.Drawing.Color.FromName(args[8]):System.Drawing.Color.FromArgb(44, 62, 80);
                SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
                connBuilder.ConnectionString = DBHandling.ConnectionString;
                clsSecurity.Database = connBuilder.InitialCatalog;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMainNew());
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
    }
}