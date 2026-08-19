using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Express.Domain.Message;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Pricing;

using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

using System.Data.Entity;


namespace Express.Data.Common
{
    public class CommonCommboMaterData
    {      

        #region Product Main  

        internal static List<ProductMainView> GetProductMainCombo(string productMain, int companyID, int agencyID)
        {
            try
            {

                using (IExpressUnitOfWork<CfgProductsMain> uof = new ExpressUnitOfWork<CfgProductsMain>())
                {
                    if ( productMain != "ALL")
                    {
                        return (from ST in uof.Reposotery.GetDetails().AsNoTracking()
                                where ST.ProductM == productMain &&  ST.CMPY == companyID && ST.AgncyCode == agencyID
                                && ST.PaidByLF =="L"
                                select new ProductMainView
                                {
                                    CompanyID = ST.CMPY,
                                    ShipmentType = ST.ShipType,
                                    ProductMain = ST.ProductM,
                                    ProductMainName =ST.ProductMN

                                }).ToList();                   
                   
                    }
                    else
                    {
                        return (from ST in uof.Reposotery.GetDetails().AsNoTracking()
                                where ST.CMPY == companyID && ST.AgncyCode == agencyID
                                 && ST.PaidByLF == "L"
                                select new ProductMainView
                                {
                                    CompanyID = ST.CMPY,
                                    ShipmentType = ST.ShipType,
                                    ProductMain = ST.ProductM,
                                    ProductMainName = ST.ProductMN
                                }).ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Product Sub  
        internal static List<ProductSubView> GetProductSubCombo(string productSub,  string productMain, int companyID, int agencyID)
        {
            try
            {

                using (IExpressUnitOfWork<CfgProductsSub> uof = new ExpressUnitOfWork<CfgProductsSub>())
                {
                    if (productSub != "ALL"  && productMain != "ALL" )
                    {
                        return (from ST in uof.Reposotery.GetDetails().AsNoTracking()
                                where ST.ProductS == productSub && ST.ProductM == productMain  
                                && ST.CMPY == companyID && ST.AgncyCode == agencyID
                                select new ProductSubView
                                {
                                    CompanyID = ST.CMPY,
                                    ShipmentType = ST.ShipType,
                                    ServiceType = ST.ShipType,
                                    ProductMain = ST.ProductM,
                                    ProductSub = ST.ProductS,
                                    ProductSubName = ST.ProductSN,
                                    Active = ST.Active
                                }).ToList();
                    }
                    else if (productSub == "ALL" &&   productMain != "ALL" )
                    {
                        return (from ST in uof.Reposotery.GetDetails().AsNoTracking()
                                where ST.ProductM == productMain  
                                  && ST.CMPY == companyID && ST.AgncyCode == agencyID
                                select new ProductSubView
                                {
                                    CompanyID = ST.CMPY,
                                    ShipmentType = ST.ShipType,
                                    ServiceType = ST.ShipType,
                                    ProductMain = ST.ProductM,
                                    ProductSub = ST.ProductS,
                                    ProductSubName = ST.ProductSN,
                                    Active = ST.Active
                                }).ToList();
                    }
                    else
                    {
                        return (from ST in uof.Reposotery.GetDetails().AsNoTracking()
                                where ST.CMPY == companyID && ST.AgncyCode == agencyID
                                select new ProductSubView
                                {
                                    CompanyID = ST.CMPY,
                                    ShipmentType = ST.ShipType,
                                    ServiceType = ST.ShipType,
                                    ProductMain = ST.ProductM,
                                    ProductSub = ST.ProductS,
                                    ProductSubName = ST.ProductSN,
                                    Active = ST.Active
                                }).ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }



        }
        //internal static List<ProductSubView> GetProductSubCombo(string productSub, string shipmentType, string serviceType, string productMain , int companyID)
        //{
        //    try
        //    {

        //        using (IExpressUnitOfWork<CfgProductsSub> uof = new ExpressUnitOfWork<CfgProductsSub>())
        //        {
        //            if (productSub !="ALL" && shipmentType != "ALL" && productMain != "ALL" && serviceType != "ALL")
        //            {
        //                return (from ST in uof.Reposotery.GetDetails()
        //                        where ST.ProductS == productSub &&  ST.ProductM == productMain && ST.ShipType == shipmentType && ST.SvcType == serviceType
        //                        && ST.CMPY ==companyID
        //                        select new ProductSubView
        //                        {
        //                            CompanyID = ST.CMPY,
        //                            ShipmentType = ST.ShipType,
        //                            ServiceType = ST.ShipType,
        //                            ProductMain = ST.ProductM,
        //                            ProductSub = ST.ProductS,
        //                            ProductSubName = ST.ProductSN,
        //                            Active = ST.Active
        //                        }).ToList();
        //            }
        //            else if (productSub == "ALL" && shipmentType != "ALL" && productMain != "ALL" && serviceType != "ALL")
        //            {
        //                return (from ST in uof.Reposotery.GetDetails()
        //                        where ST.ProductM == productMain && ST.ShipType == shipmentType && ST.SvcType == serviceType
        //                          && ST.CMPY == companyID
        //                        select new ProductSubView
        //                        {
        //                            CompanyID = ST.CMPY,
        //                            ShipmentType = ST.ShipType,
        //                            ServiceType = ST.ShipType,
        //                            ProductMain = ST.ProductM,
        //                            ProductSub = ST.ProductS,
        //                            ProductSubName = ST.ProductSN,
        //                            Active = ST.Active
        //                        }).ToList();
        //            }
        //            else
        //            {
        //                return (from ST in uof.Reposotery.GetDetails()
        //                        where   ST.CMPY == companyID
        //                        select new ProductSubView
        //                        {
        //                            CompanyID = ST.CMPY,
        //                            ShipmentType = ST.ShipType,
        //                            ServiceType = ST.ShipType,
        //                            ProductMain = ST.ProductM,
        //                            ProductSub = ST.ProductS,
        //                            ProductSubName = ST.ProductSN,
        //                            Active = ST.Active
        //                        }).ToList();
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }



        //}

        #endregion

        #region Currency 
        internal static List<CurrencyView> GetCurrencyType(string currency, int companyID , int agencyID)
        {
            try
            {

                using (IExpressUnitOfWork<CfgCurrencyLF> uof = new ExpressUnitOfWork<CfgCurrencyLF>())
                {
                    if (currency != "ALL")
                    {
                        return (from CURR in uof.Reposotery.GetDetails()
                                where CURR.LocCurrency ==currency
                                && CURR.CMPY == companyID && CURR.AgncyCode ==agencyID
                                select new CurrencyView
                                {
                                   
                                    ForCurrency = CURR.ForCurrency,
                                    LocCurrency = CURR.LocCurrency,                                    
                                    CMPY = CURR.CMPY
                                }).ToList();
                    }
                    else
                    {
                        return (from CURR in uof.Reposotery.GetDetails()
                                where   CURR.CMPY == companyID && CURR.AgncyCode == agencyID
                                select new CurrencyView
                                {
                                    ForCurrency = CURR.ForCurrency,
                                    LocCurrency = CURR.LocCurrency,
                                    CMPY = CURR.CMPY
                                }).ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Exchange Rate Type
        internal static List<ExchaneRateTarifTypeView> GetExchangeRateType(string objModel)
        {
            try
            {
                using (IExpressUnitOfWork<ExtRatesTypesResult> uof = new ExpressUnitOfWork<ExtRatesTypesResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {
                           new SqlParameter("@ExgRatTarif" ,"0"  ),

                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Finance].[USP_GetExtRateypes]", paraList)
                                        select new
                                        {
                                            SR.ExgRatTarif,
                                            SR.ExgRatTarifN,
                                            SR.BaseCurrency,
                                            SR.DefCurrency,
                                            SR.CurrencyN
                                        }).ToList().Select(SR => new ExchaneRateTarifTypeView
                                        {
                                            ExgRatTarif = SR.ExgRatTarif,
                                            ExgRatTarifN = SR.ExgRatTarifN,
                                            BaseCurrency = SR.BaseCurrency,
                                            DefCurrency = SR.DefCurrency,
                                            CurrencyN = SR.CurrencyN

                                        }).ToList();

                    return customerHead;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion
        

        

        #region Charge Code
        //GetChargeCode
        //////internal static List<InvoiceChargeCodeDomainView> GetChargeCode(int companyID, string invDocType)
        //////{


        //////    try
        //////    {
        //////        using (IExpressUnitOfWork<RefChargeCodesInvoice> uof = new ExpressUnitOfWork<RefChargeCodesInvoice>())
        //////        {

        //////            return (from ST in uof.Reposotery.GetDetails().AsNoTracking()
        //////                    where ST.CMPY == companyID && ST.DocType == invDocType && ST.Active == "Y"

        //////                    select new InvoiceChargeCodeDomainView
        //////                    {
        //////                        ChargeCode = ST.ChargeCode,
        //////                        ChargeDesc = ST.RefChargeCode.ChargeDesc,
        //////                        DocType = ST.DocType,
        //////                        Seqno = ST.Seqno,
        //////                        SellFC = 0,
        //////                        SellLC = 0,
        //////                        GlRevAc =ST.GlRevAc

        //////                    }).OrderBy(ex => ex.Seqno).ToList();

        //////        }
        //////    }
        //////    catch (DbUpdateException updateException)
        //////    {
        //////        var updateBaseException = updateException.GetBaseException() as SqlException;
        //////        throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "", updateException);
        //////    }
        //////    catch (Exception)
        //////    {
        //////        throw;
        //////    }

        //////}

        #endregion

        #region Currency Detail

        internal static List<CurrencyDetailDomainView> GetCurrencyDetail(string objModel)
        {
            try
            {
                using (IExpressUnitOfWork<CfgCurrencies> uof = new ExpressUnitOfWork<CfgCurrencies>())
                {

                    return (from CD in uof.Reposotery.GetDetails().OrderBy(ex=>ex.CurrencyN)
                            where CD.Active == "Y"
                            select new CurrencyDetailDomainView
                            {
                                Currency = CD.Currency,
                                CurrencyN = CD.CurrencyN,
                                Active = CD.Active

                            }).ToList();
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Common", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }


        }
        #endregion


     



        
  
   
        internal static string GetLocalCurrencyCode(int CompanyCode)
        {
            using (IExpressUnitOfWork<CfgCurrencyLF> uof = new ExpressUnitOfWork<CfgCurrencyLF>())
            {
                var localCurrency = (from CD in uof.Reposotery.GetDetails()
                                     where CD.CMPY == CompanyCode
                                     select CD.LocCurrency);
                return localCurrency.First();

            }
        }
        internal static string GetLocalCurrency(int CompanyCode)
        {
            using (IExpressUnitOfWork<RefCompany> uof = new ExpressUnitOfWork<RefCompany>())
            {
                var localCurrency = (from CD in uof.Reposotery.GetDetails()
                                     where CD.CMPY == CompanyCode
                                     select CD.LocalCurrency);
                return localCurrency.First();

            }
        }
        #region Hub Detail 

     
        #endregion
    }
}
