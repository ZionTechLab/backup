using Express.Interfaces.Common;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface IFreightProductMapping<T> : IDataAccess<T> where T : class
    {        
       // IList<AgencyDomainViewcs> GetAgenciesA();
        IList<ExpressCfgProductsMainDomainView> GetInvoiceType(int AgencyCode);
        IList<ExpressCfgProductsSubDomainView> GetProduct(string ProductM, int AgencyCode);

        IList<FreightProductMappingDomainView> GetGridView(int AgencyCode,string ProductM,string ProductS);

        IList<FreightProductMappingDomainView> EditData(string Current_SvcType, string Current_PackType, string Current_DocNDoc,string NewSvcType, string NewPackType, string NewDocNDoc, decimal WgtFrom, decimal WgtTo,string Remarks);

        bool SaveData(FreightProductMappingDomainView typePara);

        bool CheckAlreadExist(string SvcType, string PackType, string DocNDoc,int AgencyCode,string ProductM, string ProductS);

        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);

        IList<ExpressCfgSvcTypes> GetSvcType(int AgencyCode);
        IList<ExpressCfgPackTypes> GetPackType(int AgencyCode);



    }
}
