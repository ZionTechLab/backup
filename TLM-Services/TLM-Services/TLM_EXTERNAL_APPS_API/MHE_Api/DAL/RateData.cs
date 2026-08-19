using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MHE_Api.Models;
using System.ComponentModel;

namespace MHE_Api.DAL
{
    public class RateData : IRateData
    {
        public CreditInfoResultView GetCreditInfo(int Mount_Code)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var para = new DynamicParameters();

                    para.Add("@Mount_Code", Mount_Code);

                    var output = connection.Query<CreditInfoResultView>("[Finance].[TLMV1_FindCreditInfoForAPI]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return output;
                }
            }
            catch (Exception Ex)
            {
                  var Rates = new CreditInfoResultView();
              //  Rates.Error = Ex.Message;
                  return Rates;
                  Log.LogError(Ex);
                // throw;
            }
        }
        public DataTable ToDataTables<T>(IList<T> data)
        {
            try
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prp = props[i];
                    table.Columns.Add(prp.Name, Nullable.GetUnderlyingType(prp.PropertyType) ?? prp.PropertyType);
                }
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(values);
                }
                return table;
            }catch (Exception ex)
            { return null; }
        }

        public List<dynamic> GetESMRevWgt(IList<ESMRevWGTReqTypeDomainView> _data)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[GetCustomerLastMonthRevWgtAPI] @Request",
                         new
                         {
                             Request = ToDataTables(_data).AsTableValuedParameter("[Express].[ESMRevWGTReqType]")
                         }, commandTimeout: 2000 ).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {               
                return null;
                Log.LogError(Ex);
                // throw;
            }
        }

        public RatesFindResultView GetRates(RatesFind_Parameters _Para)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var para = new DynamicParameters();

                    para.Add("@CustomerICPC", _Para.CustomerICPC);
                    para.Add("@ServiceType", _Para.ServiceType);
                    para.Add("@FromCountry", _Para.FromCountry);
                    para.Add("@ToCountry", _Para.ToCountry);
                    para.Add("@PackingMaterial", _Para.PackingMaterial);
                    para.Add("@Weight", _Para.Weight);
                    para.Add("@DocNDoc", _Para.DocNDoc);

                    var output = connection.Query<RatesFindResultView>("[Express].[TLMV1_FindRatesForAPI]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return output;
                }
            }
            catch (Exception Ex)
            {
                RatesFindResultView Rates = new RatesFindResultView();
             //   Rates.Error = Ex.Message;
                return Rates;
                  Log.LogError(Ex);
               // throw;
            }
        }

        public List<dynamic> get_customer_list(UpdatedOnly upd)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[TLMV2_GetCustomerListForAPI] @UpdatedDT", new { UpdatedDT = upd?.last_updated_at??null }, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                return null;
                Log.LogError(Ex);
                // throw;
            }
        }

        public List<CustCredRateInfo> get_customer_credit(CustPara Org)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<CustCredRateInfo>(@"[Express].[TLMV2_GetCustomerCreditInfoAPI] @Customer_Code" , new { Customer_Code = Org .Customer_Code}, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                return null;
                Log.LogError(Ex);
                // throw;
            }
        }

        public List<dynamic> get_customer_rates(CustPara Org)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    var ret = connection.Query<dynamic>(@"[Express].[TLMV2_GetCustomerRateCardsAPI] @Customer_Code", new { Customer_Code = Org.Customer_Code }, commandTimeout: 2000).ToList();
                    return ret;
                }
            }
            catch (Exception Ex)
            {
                return null;
                Log.LogError(Ex);
                // throw;
            }
        }
    }
}