using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;

namespace Express.Business.Operations.Manifest
{
   public class FreightProductMappingBusiness : IFreightProductMapping<FreightProductMappingDomainView>
    {

        private IFreightProductMapping<FreightProductMappingDomainView> freightProductMappingDataProvider;

        public FreightProductMappingBusiness(IFreightProductMapping<FreightProductMappingDomainView> freightProductMapping)
        {
            this.freightProductMappingDataProvider = freightProductMapping;
        }

        public bool CheckAlreadExist(string SvcType, string PackType, string DocNDoc, int AgencyCode, string ProductM, string ProductS)
        {
            return freightProductMappingDataProvider.CheckAlreadExist(SvcType, PackType, DocNDoc, AgencyCode, ProductM, ProductS);
        }

        public ResponseMessage DeleteDetail(FreightProductMappingDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<FreightProductMappingDomainView> EditData(string Current_SvcType, string Current_PackType, string Current_DocNDoc, string NewSvcType, string NewPackType, string NewDocNDoc, decimal WgtFrom, decimal WgtTo, string Remarks)
        {
            return freightProductMappingDataProvider.EditData(Current_SvcType, Current_PackType, Current_DocNDoc, NewSvcType, NewPackType, NewDocNDoc, WgtFrom, WgtTo, Remarks);
        }
               
        public ResponseMessage EditDetails(FreightProductMappingDomainView typePara)
        {
            throw new NotImplementedException();
        }
               
        //public IList<AgencyDomainViewcs> GetAgenciesA()
        //{
        //    return freightProductMappingDataProvider.GetAgenciesA();
        //}

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return freightProductMappingDataProvider.GetAgencyDetail(UserId, ModuleId, MenueId);
        }
        
        public List<FreightProductMappingDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<FreightProductMappingDomainView> GetDetails(FreightProductMappingDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<FreightProductMappingDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<FreightProductMappingDomainView> GetGridView(int AgencyCode, string ProductM, string ProductS)
        {
            return freightProductMappingDataProvider.GetGridView(AgencyCode, ProductM, ProductS);
        }

        public IList<ExpressCfgProductsMainDomainView> GetInvoiceType(int AgencyCode)
        {
            return freightProductMappingDataProvider.GetInvoiceType(AgencyCode);
        }

        public IList<ExpressCfgPackTypes> GetPackType(int AgencyCode)
        {
            return freightProductMappingDataProvider.GetPackType(AgencyCode);
        }

        public IList<ExpressCfgProductsSubDomainView> GetProduct(string ProductM, int AgencyCode)
        {
            return freightProductMappingDataProvider.GetProduct(ProductM,AgencyCode);
        }

        public IList<ExpressCfgSvcTypes> GetSvcType(int AgencyCode)
        {
            return freightProductMappingDataProvider.GetSvcType(AgencyCode);
        }

        public bool SaveData(FreightProductMappingDomainView typePara)
        {
            return freightProductMappingDataProvider.SaveData(typePara);
        }

        public ResponseMessage SaveDetails(FreightProductMappingDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
