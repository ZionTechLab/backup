using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using System.Data.SqlClient;
using Express.Custom.ExcepHandle.DataHadling;
using System.Data;
using Dapper;
using Express.Data.FedexExpressEF;
using System.Data.Entity.Infrastructure;
using System.Configuration;

namespace Express.Data.Operations.Manifest
{
    public class FreightProductMappingData : IFreightProductMapping<FreightProductMappingDomainView>
    {
        public bool CheckAlreadExist(string SvcType, string PackType, string DocNDoc, int AgencyCode, string ProductM, string ProductS)
        {
            bool output = false;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                output = connection.Query<bool>(@"SELECT CASE WHEN EXISTS (SELECT * FROM Express.RefMapBillProducts 
                WHERE SvcType = @SvcType and PackType = @PackType and DocNDoc = @DocNDoc and AgncyCode = '" + AgencyCode + "' AND ProductM = '" + ProductM + "' AND ProductS = '"+ ProductS + "')THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", new { SvcType = SvcType, PackType = PackType, DocNDoc = DocNDoc }).Single();
                return output;
            }
        }
                
        public ResponseMessage DeleteDetail(FreightProductMappingDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<FreightProductMappingDomainView> EditData(string Current_SvcType, string Current_PackType, string Current_DocNDoc,
            string NewSvcType, string NewPackType, string NewDocNDoc, decimal WgtFrom, decimal WgtTo, string Remarks)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var output = connection.Query<FreightProductMappingDomainView>(@"UPDATE Express.RefMapBillProducts 
                          SET SvcType =@SvcType,PackType = @PackType,DocNDoc = @DocNDoc,WgtFrom = @WgtFrom,WgtTo = @WgtTo,Remarks = @Remarks
                          WHERE SvcType = '" + Current_SvcType + "' AND PackType = '"+Current_PackType+"' AND DocNDoc = '"+Current_DocNDoc+"'",
                new { SvcType = NewSvcType, PackType = NewPackType, DocNDoc = NewDocNDoc,  WgtFrom = WgtFrom, WgtTo = WgtTo, Remarks = Remarks }).ToList();
                return output;
            }
        }               

        public ResponseMessage EditDetails(FreightProductMappingDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    //para.Add("@tarrifNo", tarrifNo);
                    //para.Add("@cvtCurr", cCurrency);
                    para.Add("@UserID", UserId);
                    para.Add("@@ModuleID", ModuleId);
                    para.Add("@MenuID", MenueId);
                    
                    return (List<AgencyDomainViewcs>)conn.Query<AgencyDomainViewcs>("[Project].[TLM_GetUserAgencyList]", para,
                        commandType: CommandType.StoredProcedure).ToList();
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
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var output = connection.Query<FreightProductMappingDomainView>(@"SELECT svcType.SvcTypeN,packType.PackTypeN,DocNDoc,WgtFrom,WgtTo,Remarks,refMapbillProduct.AgncyCode,refMapbillProduct.SvcType,refMapbillProduct.PackType,ProductM,ProductS 
                FROM Express.RefMapBillProducts as refMapbillProduct 
                INNER JOIN Express.CfgSvcTypes as svcType ON refMapbillProduct.SvcType = svcType.SvcType
                INNER JOIN Express.CfgPackTypes as packType ON refMapbillProduct.PackType = packType.PackType
                WHERE (refMapbillProduct.AgncyCode = @AgncyCode) AND (ProductM = @ProductM) AND ProductS LIKE @ProductS",
                new { AgncyCode = AgencyCode, ProductM = ProductM, ProductS = "%"+ProductS+"%" }).ToList();
                return output;
            }
        }

        public IList<ExpressCfgProductsMainDomainView> GetInvoiceType(int AgencyCode)
        {

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var output = connection.Query<ExpressCfgProductsMainDomainView>(@"SELECT ProductM,ProductMN,Doctype 
                FROM Express.CfgProductsMain 
                WHERE ProductCata = @ProductCata and AgncyCode = @AgncyCode  ", new { ProductCata = "FRT", AgncyCode = AgencyCode }).ToList();
                return output;
            }
        }

        public IList<ExpressCfgPackTypes> GetPackType(int AgencyCode)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var output = connection.Query<ExpressCfgPackTypes>(@"SELECT PackType,PackTypeN FROM Express.CfgPackTypes WHERE AgncyCode = @AgncyCode", new {AgncyCode = AgencyCode }).ToList();
                return output;
            }
        }

        public IList<ExpressCfgProductsSubDomainView> GetProduct(string ProductM, int AgencyCode)
        {

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var output = connection.Query<ExpressCfgProductsSubDomainView>(@"SELECT ProductS,ProductSN 
                FROM Express.CfgProductsSub 
                WHERE ProductM = @ProductM AND AgncyCode = @AgncyCode AND Active = 'Y' ", new { ProductM = ProductM, AgncyCode = AgencyCode}).ToList();
                return output;
            }
          }

        public IList<ExpressCfgSvcTypes> GetSvcType(int AgencyCode)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var output = connection.Query<ExpressCfgSvcTypes>(@"SELECT SvcType,SvcTypeN FROM Express.CfgSvcTypes WHERE AgncyCode = @AgncyCode", new {AgncyCode = AgencyCode}).ToList();
                return output;
            }
        }

        public bool SaveData(FreightProductMappingDomainView typePara)
        {                  
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute(@"INSERT INTO Express.RefMapBillProducts (AgncyCode,Doctype,ProductM,ProductS,SvcType,PackType,DocNDoc,WgtFrom,WgtTo,Remarks) 
                        VALUES (@AgncyCode,@Doctype,@ProductM,@ProductS,@SvcType,@PackType,@DocNDoc,@WgtFrom,@WgtTo,@Remarks) ", typePara, transaction: transaction);
                        transaction.Commit();
                        return true;                                              
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;                      
                    }
                }
            }          
        }

        public ResponseMessage SaveDetails(FreightProductMappingDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
