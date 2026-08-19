using Dapper;
using MHE_Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MHE_Api.DAL
{
    public class MobileBackendData
    {
        public List<OutstandingResultView> Get_Outstanding(outstanding_Parameters _Para)
        {
            List<OutstandingResultView> result;
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Invoice_No", _Para.Invoice_No, null, null, null, null, null);
                    dynamicParameters.Add("@AWB_No", _Para.AWB_No, null, null, null, null, null);
                    dynamicParameters.Add("@RPI_No", _Para.RPI_No, null, null, null, null, null);
                    result = SqlMapper.Query<OutstandingResultView>(dbConnection, "[Finance].[TLMV2_Get_Outstanding]", dynamicParameters, null, true, null, new CommandType?(CommandType.StoredProcedure)).ToList<OutstandingResultView>();
                }
            }
            catch (Exception ex)
            {
                List<OutstandingResultView> arg_127_0 = new List<OutstandingResultView>();
                Log.LogError(ex);
                result = arg_127_0;
            }
            return result;
        }
        public DataTable ToDataTables<T>(IList<T> data)
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
        }
        internal ReceiptResponseView Post_ApprovedCollections(List<ReceiptsDomainView> obj)
        {
            ReceiptResponseView Results = new ReceiptResponseView();
            BatchUpload collection = new BatchUpload();
            List<CollectionBatchHedDomainView> BatchData = new List<CollectionBatchHedDomainView>();
            List<BatchAttributes> Attributes = new List<BatchAttributes>();
            try
            {
                foreach (var item in obj)
                {
                CollectionBatchHedDomainView x = new CollectionBatchHedDomainView
                {
                    id = item.id,
                    type = item.type,
                    total_amount = item.total_amount,
                    courier_remarks = item.courier_remarks,
                    courier_name = item.courier_name,
                    route_no = item.route_no,
                    customer_code = item.customer_code,
                    customer_name = item.customer_name,
                    invoice = item.invoice,
                    paid_amount = item.paid_amount,
                    supervisor_name = item.supervisor_name,
                    batch_id = item.batch_id,
                    awb_number = item.awb_number,
                    credit = item.credit,
                    cash_amount = item.cash_amount,
                    cheque_amount = item.cheque_amount,
                    cheque_number = item.cheque_number,
                    cheque_bank = item.cheque_bank,
                    momo_amount = item.momo_amount,
                    momo_referance = item.momo_referance,
                    cashire_name = item.cashire_name,
                    status = item.status,
                    collected_date = item.collected_date
                };
                BatchAttributes y = new BatchAttributes
                {
                    id = item.id,
                    freight = item.attributes.freight,
                    handling = item.attributes.handling,
                    insurance = item.attributes.insurance,
                    others = item.attributes.others
                };

                BatchData.Add(x);
                Attributes.Add(y);
            }
            collection.BatchData = BatchData;
            collection.Attributes = Attributes;
            
           
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {

                    using (var multi = connection.QueryMultiple("[Finance].[TLMV2_AddPaymentCollections] @ApprovedCollections, @CollectionAttributes", new
                    {
                        ApprovedCollections = ToDataTables(collection.BatchData).AsTableValuedParameter("[Finance].TEMPCollectionBatch"),
                        CollectionAttributes = ToDataTables(collection.Attributes).AsTableValuedParameter("[Finance].TEMPCollectionAttributes")
                    }))
                    {
                        Results.batch = multi.Read<BatchResponse>().FirstOrDefault();
                        Results.data = multi.Read<ReceiptLog>().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                BatchResponse x = new BatchResponse
                {
                    batch_id = obj.FirstOrDefault().batch_id,
                    status = "Error",
                    message = ex.Message
                };
                Results.batch = x;
            }
            return Results;
        }

        public List<InvSummaryResult> Get_InvSummary(invsummary_Parameters obj)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var para = new DynamicParameters();

                    para.Add("@ICPC_No", obj.icpcNo);
                    para.Add("@DateFrom", obj.dateFrom);
                    para.Add("@DateTo", obj.dateTo);
                    para.Add("@ShipType", obj.shippingType);
                    para.Add("@PayStatus", obj.paymentStatus);

                    var output = connection.Query<InvSummaryResult>("[Finance].[TLMV2_CustInvOustandingAPI]", para, commandType: CommandType.StoredProcedure).ToList();
                    return output;
                }
            }
            catch (Exception Ex)
            {
                //var Rates = new CreditInfoResultView();
                //  Rates.Error = Ex.Message;
                return null;
                Log.LogError(Ex);
                // throw;
            }
        }

        public List<InvListResult> Get_InvList(invlist_Parameters obj)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var para = new DynamicParameters();

                    para.Add("@FromDT", obj.dateFrom);
                    para.Add("@ToDT", obj.dateTo);

                    var output = connection.Query<InvListResult>("[Finance].[TLMV2_GetInvoiceListDailyAPI]", para, commandType: CommandType.StoredProcedure).ToList();
                    return output;
                }
            }
            catch (Exception Ex)
            {
                //var Rates = new CreditInfoResultView();
                //  Rates.Error = Ex.Message;
                return null;
                Log.LogError(Ex);
                // throw;
            }
        }
    }
}
