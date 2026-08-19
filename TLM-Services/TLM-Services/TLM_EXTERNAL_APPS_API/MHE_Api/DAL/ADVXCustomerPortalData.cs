using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MHE_Api.Models;
using System.ComponentModel;
using System.Xml.Linq;

namespace MHE_Api.DAL
{
    public class ADVXCustomerPortalData : IADVXCustomerPortal
    {
        public List<object> AccountSummary(object request)
        {
            try
            {
                dynamic data = request;
                string icpc = data["icpc"];
                
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[GetICPCAccountSummaryAPI] @ICPC",
                         new
                         {
                             ICPC = icpc.Trim()
                         }, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                Log.LogError(Ex);
                return null;                
                // throw;
            }
        }

        public List<object> AccountSummaryAging(object request)
        {
            try
            {
                dynamic data = request;
                string icpc = data["icpc"];              

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[GetICPCAccountSummaryAgingAPI] @ICPC",
                         new
                         {
                             ICPC = icpc.Trim()
                           
                         }, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                Log.LogError(Ex);
                return null;                
                // throw;
            }
        }

        public List<object> GetInvoiceListByStatus(string ICPC, string InvoiceType, DateTime fromDate, DateTime toDate, string IsPaid)
        {
            try
            {
                //DateTime fromdate = DateTime.Parse(fromDate); 
                //DateTime todate = DateTime.Parse(toDate); 

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[GetICPCInvoiceListAPIByStatus] @ICPC, @DocType,@FromDT,@ToDT,@IsPaid",
                         new
                         {
                             ICPC = ICPC,
                             DocType = InvoiceType,
                             FromDT =fromDate.ToString("yyyy-MM-dd"),
                             ToDT = toDate.ToString("yyyy-MM-dd"),
                             IsPaid = IsPaid
                         }, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                Log.LogError(Ex);
                return null;

                // throw;
            }
        }

        public List<object> GetInboundInvoiceData(object request)
        {
            try
            {
                dynamic data = request;
                
                DateTime fromdate = data["FromDate"];
                DateTime todate = data["ToDate"];

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[GetInboundInvoiceDataAPI] @FromDT, @ToDT",
                         new
                         {
                             FromDT = fromdate,
                             ToDT= todate
                         }, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                Log.LogError(Ex);
                return null;
                
                // throw;
            }
        }



        public List<object> GetInvoiceList(object request)
        {
            try
            {
                dynamic data = request;
                string icpc = data["icpc"];
                string doctype = data["InvoiceType"];
                DateTime fromdate = data["FromDate"];
                DateTime todate = data["ToDate"];
                string IsPaid = data["IsPaid"]??"";
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[GetICPCInvoiceListAPI] @ICPC,@DocType,@FromDT,@ToDT,@IsPaid",
                         new
                         {
                             ICPC = icpc.Trim(),
                             doctype = doctype.Trim(),
                             FromDT = fromdate,
                             ToDT = todate,
                             IsPaid = IsPaid
                         }, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                Log.LogError(Ex);
                return null;
                
                // throw;
            }
        }

        public InvoiceDetailsDomainView InvoiceDetailsView(object request)
        {            
            try
            {
                dynamic data = request;
                string icpc = data["icpc"];
                long InvoiceNo = data["InvoiceNo"];
                InvoiceDetailsDomainView result = new InvoiceDetailsDomainView();
                InvoiceOutstanding outs = new InvoiceOutstanding();
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    using (var ret = connection.QueryMultiple(@"[Express].[GetInvoiceDetailsViewAPI] @ICPC, @InvoiceNo",
                          new
                          {
                              ICPC = icpc.Trim(),
                              InvoiceNo = InvoiceNo,
                          }, commandTimeout: 2000))
                    {
                        outs = ret.Read<InvoiceOutstanding>().FirstOrDefault();                        
                        result.BillingInformation = ret.Read<dynamic>().FirstOrDefault();
                        result.ChargeSummary = ret.Read<dynamic>().ToList();

                        result.TotalBalanceDueUSD = outs.TotalBalanceDueUSD;
                        result.TotalBalanceDueLKR = outs.TotalBalanceDueLKR;
                        result.TotalPaymentsUSD = outs.TotalPaymentsUSD;
                        result.TotalPaymentsLKR = outs.TotalPaymentsLKR;
                    };
                    return result;
                }
            }
            catch (Exception Ex)
            {
                Log.LogError(Ex);
                return null;                
                // throw;
            }
        }
    }
}