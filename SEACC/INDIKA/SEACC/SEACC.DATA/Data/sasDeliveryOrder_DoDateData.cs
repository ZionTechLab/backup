using Dapper;
using SEACC.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data
{
   public  class sasDeliveryOrder_DoDateData
    {
        public sasDeliveryOrderDomain GetDetails(string _deliveryOrder_ID)
        {
            sasDeliveryOrderDomain lists = new sasDeliveryOrderDomain();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@deliveryOrder_ID", _deliveryOrder_ID);
                lists = db.Query<sasDeliveryOrderDomain>("[dbo].[sp_Get_sasDeliveryOrder_DoDate]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return lists;
        }

        public ResponseMessage SaveDetails(sasDeliveryOrderDomain param)
        {
            ResponseMessage lists = new ResponseMessage();
            using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@deliveryOrder_ID", param.deliveryOrder_ID);
                para.Add("@customerDeliveryDate", param.customerDeliveryDate);
                para.Add("@driver_ID", param.driver_ID);
                para.Add("@deliveryRemarks", param.deliveryRemarks);
                para.Add("@VehicleNo", param.VehicleNo);
                para.Add("@DeliveryOfficer_ID", param.DeliveryOfficer_ID);
                lists = db.Query<ResponseMessage>("[dbo].[sp_Save_sasDeliveryOrder_DoDate]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return lists;
        }
    }
}
