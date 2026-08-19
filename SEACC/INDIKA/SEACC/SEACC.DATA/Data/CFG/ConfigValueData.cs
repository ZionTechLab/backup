using SEACC.DATA.Domain.CFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Data.CFG
{
   public  class ConfigValueData
    {
        //public ConfigValue Save(int[] Parm)
        //{
        //    var x = new ResponseMessage();
        //    try
        //    {
        //        using (IDbConnection db = new SqlConnection(DBHandling.ConnectionString))
        //        {
        //            var para = new DynamicParameters();
        //            para.Add("@Header", cast.ToDataTables(new List<tbl_sasDeliveryOrder>() { Parm.Header }).AsTableValuedParameter("dbo.Tmptbl_sasDeliveryOrder"));
        //            para.Add("@Detail", cast.ToDataTables(Parm.Detail).AsTableValuedParameter("dbo.Tmptbl_sasDeliveryOrder_Detail"));
        //            para.Add("@User_ID", Parm.User_ID);
        //            para.Add("@Terminal_ID", Parm.Terminal_ID);
        //            para.Add("@IsUpdate", Parm.IsUpdate);
        //            para.Add("@configForm_ID", Parm.configForm_ID);

        //            x = db.Query<ResponseMessage>("[dbo].[sp_save_sasDeliveryOrder]", para, commandType: CommandType.StoredProcedure).SingleOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        x.OutMsg = ex.Message;
        //    }
        //    return x;
        //}
    }
}
