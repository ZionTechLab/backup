using System;
using System.Collections.Generic;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Data.SqlClient;
using DataTire;
using System.Data;

namespace Digiteq_Logic
{
    public class clsDB
    {
        public static SqlConnection gSqlCon;
        public static SqlTransaction gSqlTran;
        public static string gs_Search;       

        #region Update Customer Depositted Cheques
        //public static void update_CustomerDeposittedCheques(string sCustomerID, decimal dAmount, string sAccountNo)
        //{
        //    try
        //    {
        //        tbl_genCustomerFinance detail = tbl_genCustomerFinance.Select(sCustomerID);
        //        if (detail != null)
        //        {
        //            detail.DeposittedChequeAmount += dAmount;
        //            detail.DeposittedChequeCount += 1;
        //            detail.Update();
        //        }
        //        tbl_genCustomerAccount account = tbl_genCustomerAccount.Select(sCustomerID, sAccountNo);
        //        if (account != null)
        //        {                    
        //            account.DeposittedCount += 1;
        //            account.Update();
        //        }
        //    }
        //    catch (Exception )
        //    {
        //        //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //clsValidate.WriteErrorLog("", iFormID,ex);
        //    }
        //}
        //public static void update_CustomerDeposittedChequesFromReturns(string sCustomerID, decimal dAmount, string sAccountNo)
        //{
        //    try
        //    {
        //        tbl_genCustomerFinance detail = tbl_genCustomerFinance.Select(sCustomerID);
        //        if (detail != null)
        //        {
        //            detail.DeposittedChequeAmount -= dAmount;
        //            detail.DeposittedChequeCount -= 1;
        //            detail.Update();
        //        }               
        //    }
        //    catch (Exception)
        //    {
        //    }
        //} 
        #endregion

        #region Update Customer Returned Cheques
        //public static void update_CustomerReturnedCheques(string sCustomerID, decimal dAmount, string sAccountNo)
        //{
        //    try
        //    {
        //        tbl_genCustomerFinance detail = tbl_genCustomerFinance.Select(sCustomerID);
        //        if (detail != null)
        //        {
        //            detail.ReturnedChequeAmount += dAmount;
        //            detail.ReturnedChequeCount += 1;
        //            detail.Update();
        //        }
        //        tbl_genCustomerAccount account = tbl_genCustomerAccount.Select(sCustomerID, sAccountNo);
        //        if (account != null)
        //        {
        //            account.ReturnedCount += 1;
        //            account.Update();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        #endregion

        #region Update Customer Realized Cheques
        //public static void update_CustomerRealizedCheques(string sCustomerID, decimal dAmount, string sAccountNo)
        //{
        //    try
        //    {
        //        tbl_genCustomerFinance detail = tbl_genCustomerFinance.Select(sCustomerID);
        //        if (detail != null)
        //        {
        //            detail.RealizedChequeAmount += dAmount;
        //            detail.RealizedChequeCount += 1;
        //            detail.Update();
        //        }
        //        tbl_genCustomerAccount account = tbl_genCustomerAccount.Select(sCustomerID, sAccountNo);
        //        if (account != null)
        //        {
        //            account.RealizedCount += 1;
        //            account.Update();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region global Sqlconnection with transaction

        public static DataSet ExecQuery(string sQuery, string sTableName)
        {
            SqlConnection Sqlcon = new SqlConnection(DBHandling.ConnectionString);
            SqlCommand Sqlcmd = new SqlCommand();
            SqlDataAdapter Sqlda;
            DataSet ds = new DataSet();

            Sqlcon.Open();
            Sqlcmd.CommandText = sQuery;
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.Connection = Sqlcon;
            Sqlda = new SqlDataAdapter(Sqlcmd);
            Sqlda.Fill(ds, sTableName);
            Sqlcon.Close();
            return (ds);
        }
        #endregion

    }
}