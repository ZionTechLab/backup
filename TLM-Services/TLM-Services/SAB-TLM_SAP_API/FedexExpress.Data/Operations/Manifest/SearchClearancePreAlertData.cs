using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

namespace Express.Data.Operations.Manifest
{
    public class SearchClearancePreAlertData : ISearchClearancePreAlert<ClearancePreAlertDomainView>
    {
        public ResponseMessage DeleteDetail(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<ClearancePreAlertDomainView> GetSerchResult(int GroupId, int CMPY, int AgencyId, string Console, string MAWB, string ConsoleNo)
        {
            try
            {
                using (IExpressUnitOfWork<ClearancePreAlertResult> uof = new ExpressUnitOfWork<ClearancePreAlertResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@GroupId", GroupId) ,new SqlParameter("@CMPY", CMPY) ,new SqlParameter("@AgncyCode",AgencyId),
                          new SqlParameter("@Console", Console) ,new SqlParameter("@MawbNo", MAWB) ,new SqlParameter("@ConsID",ConsoleNo)};
                    var OrgRegistryList = (from OC in uof.Reposotery.GetDataBySp("[Express].[TLM_SerchClearancePreAlertDataDetail]", paraList)
                                           select new ClearancePreAlertDomainView
                                           {
                                               CMPY = OC.CMPY,
                                               GroupID = OC.GroupID,
                                               AgncyCode = OC.AgncyCode,
                                               ConsId = OC.ConsId,
                                               MAWBNo = OC.MAWBNo,
                                               TransDate = OC.TransDate.Value,
                                               VisaRootID = OC.VisaRootID,
                                               FlightNo = OC.FlightNo,
                                               AriDate = OC.AriDate.Value,
                                               AriTime = OC.AriTime.Value,
                                               ShipType = OC.ShipType,
                                               DepDate = OC.DepDate.Value,
                                               DepTime = OC.DepTime.Value,
                                               Remarks = OC.Remarks,
                                               Deleted = OC.Deleted.Value,
                                               OrgHubID = OC.OrgHubID,
                                               DesHubID = OC.DesHubID,
                                               Currency = OC.Currency,
                                               AlNumCode = OC.AlNumCode,
                                               HighValueY = OC.HighValueY == "" ? true : false,
                                               TransMode = OC.TransMode,
                                               AgncyID = OC.AgncyID,
                                               ExpressCons = OC.ExpressCons,
                                               //ALActWgt=OC.ALActWgt,
                                               //ALChgWgt=OC.ALChgWgt,
                                               //AlFreightChg=OC.AlFreightChg.Value
                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseMessage SaveDetails(ClearancePreAlertDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
