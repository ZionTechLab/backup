using Express.Business.Pricing;
using Express.Data.Pricing;
using Express.Interfaces.Pricing;
using Express.Interfaces.Report.Pricing;
using Express.Report.Pricing.ReportProxy;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;


namespace Express.UI.Factory
{
   public  sealed class PricingUIFactory
    {

        private  static Dictionary<object, object> servicecontainer = null;
        public PricingUIFactory()
        {
            
        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                //servicecontainer.Add(typeof(IInvoiceDutyDataProvider <InvoiceDutyDomainView>), new InvoiceDutyBusiness(new InvoiceDutyData()));
                // servicecontainer.Add(typeof(IInvoicePickupDataProvider<InvoicePickupDomainView>), new InvoicePickupBusiness(new InvoicePickupData()));             
                // servicecontainer.Add(typeof(IInvoiceBulkPrintDataProvider<InvoiceBulkPrintDomainView>), new InvoiceBulkPrintBusiness(new InvoiceBulkPrintData()));              
                servicecontainer.Add(typeof(IExchangeRatesDataProvider<ExchangeRatesView>), new ExchangeRatesBusiness(new ExchangeRatesDate()));
                servicecontainer.Add(typeof(IOrgCharges<OrgChargesView>), new OrgChargesBusiness(new OrgChargesData()));
                servicecontainer.Add(typeof(ISpotRates<SpotRatesDomainView>), new SpotRatesBusiness(new SpotRatesData()));
                servicecontainer.Add(typeof(IAWBCreditNote<AWBCreditView>), new AWBCreditNoteBusiness(new AWBCreditNoteData()));
                servicecontainer.Add(typeof(IPricingReport), new PricingReports());
            }

            #endregion
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Service not available.");
            }
        }





        ////public static ISellingZoneRateMaster<SellingZoneRateMasterView> CreateSellingZoneRateMasterAccess()
        ////{
        ////    ISellingZoneRateMaster<SellingZoneRateMasterView> sellingZoneRateMaster = new SellingZoneRateMasterApiClient();
        ////    return sellingZoneRateMaster;
            
        ////}

        ////public static IZoneMasterCostAgnRate<ZoneMasterCostAgnRateDomainView> CreateCostZoneRateMasterAccess()
        ////{
        ////    IZoneMasterCostAgnRate<ZoneMasterCostAgnRateDomainView> costZoneRateMaster = new ZoneMasterCostAgnRateApiClient();
        ////    return costZoneRateMaster;

        ////}


        ////public static IExchangeRatesDataProvider<ExchangeRatesView> CreateExchangeRateMasterAccess()
        ////{
        ////    IExchangeRatesDataProvider<ExchangeRatesView> ExchangeRateMaster = new ExchangeRateApiClient();
        ////    return ExchangeRateMaster;
        ////}

        ////public static IFuelChartTypesDataProvider<RatesFuelShgView> FuelChartTypesAccess()
        ////{
        ////    IFuelChartTypesDataProvider<RatesFuelShgView> objFuelChartTypesObj = new FuelChartTypesApiClient();
        ////    return objFuelChartTypesObj;
        ////}


        ////public static ICustomerZoneRateDataProvider<CustomerZoneRateView> CreateCustomerZoneRateAccess()
        ////{
        ////    ICustomerZoneRateDataProvider<CustomerZoneRateView> customerZoneRate = new CustomerZoneRateApiClient();
        ////    return customerZoneRate;

        ////}
        
        ////public static ICountryRateDataProvider<CountryRateView> CreateCountryRateAccess()
        ////{
        ////    ICountryRateDataProvider<CountryRateView> countryRate = new CountrySellRateApiClient();
        ////    return countryRate;
        ////}

        ////public static ICostCountryRateDataProvider<CostCountryRateDomainView> CreateCostCountryRateAccess()
        ////{
        ////    ICostCountryRateDataProvider<CostCountryRateDomainView> costCountryRate = new CostCountryRateApiClient();
        ////    return costCountryRate;
        ////}


        ////public static ICountryCustomerSellRateTariffDataProvider<CountryCustomerSellRateTariffView> CreateCountryCustomerRateAccess()
        ////{
        ////    ICountryCustomerSellRateTariffDataProvider <CountryCustomerSellRateTariffView > countCustRate = new CountryCustomerSellRateTariffApiClient();
        ////    return countCustRate;
        ////}

        ////public static IRateSellCountryCustomerSpecDataProvider<RateSellCountryCustomerSpecView> CreateSpecCustomerCountryAccess()
        ////{
        ////    IRateSellCountryCustomerSpecDataProvider<RateSellCountryCustomerSpecView> specCustRate = new RateSellCountryCustomerSpecApiClient();
        ////    return specCustRate;
        ////}


        ////public static ICostCountryCustTarrifDataProvider <CostCountryCustTarrifDomainView> CreateCostCountryTariffAccess()
        ////{
        ////    ICostCountryCustTarrifDataProvider<CostCountryCustTarrifDomainView> costCountryTarrif = new CostCountryCustTarrifApiClient();
        ////    return costCountryTarrif;
        ////}

        ////public static ICostZoneCustTariffDataProvider<CostZoneCustTariffDomainView> CreateCostZoneCustomerTariffAccess()
        ////{
        ////    ICostZoneCustTariffDataProvider<CostZoneCustTariffDomainView> costCustTariff = new CostZoneCustTariffApiClient();
        ////    return costCustTariff;
        ////}

        ////public static IInvoiceDutyDataProvider<InvoiceDutyDomainView> CreateInvDutyInvAccess()
        ////{
        ////    IInvoiceDutyDataProvider<InvoiceDutyDomainView> invDuty = new InvoiceDutyApiClient();
        ////    return invDuty;
        ////}

        ////public static IInvoiceFreightDataProvider<InvoiceFrtDomainView> CreateInvFrtAccess()
        ////{
        ////    IInvoiceFreightDataProvider<InvoiceFrtDomainView> invFrt = new InvoiceFreightApiClient();
        ////    return invFrt;
        ////}

        ////public static ISellZoneSpecialRate<SellZoneSpecialRateDomainView> ZoneSpecRateAccess()
        ////{
        ////    ISellZoneSpecialRate<SellZoneSpecialRateDomainView> zoneSpecRate = new SellZoneSpecialApiClient();
        ////    return zoneSpecRate;
        ////}

        ////public static IRateInqueryDataProvider<RateInqueryDomainView> CreateRateInqueryAccess()
        ////{
        ////    IRateInqueryDataProvider<RateInqueryDomainView> rateIquery = new RateInqueryApiClient();
        ////    return rateIquery;
        ////}

        ////public static IInvoiceFrtBulkProDataProvider<InvoiceFrtBulkProDomainView> CreateInvFrtBullkAccess()
        ////{
        ////    IInvoiceFrtBulkProDataProvider<InvoiceFrtBulkProDomainView> bulkPro = new InvoiceFrtBulkProApiClient();
        ////    return bulkPro;
        ////}

        ////public static IInvoiceBulkPrintDataProvider<InvoiceBulkPrintDomainView> CreateInvBulkPrintAccess()
        ////{
        ////    IInvoiceBulkPrintDataProvider<InvoiceBulkPrintDomainView> bulkInvPrint = new InvoiceBulkPrintApiClient();
        ////    return bulkInvPrint;
        ////}

        ////public static IPrincipleReconDataProvider<PrincipleReconDomainView> CreatePrincipleReconAccess()
        ////{
        ////    IPrincipleReconDataProvider<PrincipleReconDomainView> princRecounProvider = new PrincipleReconApiClient();
        ////    return princRecounProvider;
        ////}

        ////public static IRateManualDataProvider<RateManualDomainView> CreateRateManualAccess()
        ////{
        ////    IRateManualDataProvider<RateManualDomainView> rateManual = new RateManualApiClient();
        ////    return rateManual;
        ////}

        ////public static IInvoicePickupDataProvider<InvoicePickupDomainView> CreatePickupInvoiceAccess()
        ////{
        ////    IInvoicePickupDataProvider<InvoicePickupDomainView> pickupInvoice = new InvoicePickupApiClient();
        ////    return pickupInvoice;
        ////}


        ////public static IPrincipleReconFedexDataProvider<PrincipleReconDomainView> CreatePrincipleReconFedexAccess()
        ////{
        ////    IPrincipleReconFedexDataProvider<PrincipleReconDomainView> princRecounProvider = new PrincipleReconFedexApiClient();
        ////    return princRecounProvider;
        ////}

        ////public static IInvoiceDeliveryDataProvider<InvoiceDeliveryDomainView> CreateDeliveryInvoiceAccess()
        ////{
        ////    IInvoiceDeliveryDataProvider<InvoiceDeliveryDomainView> _delivery = new InvoiceDeliveryApiClient();
        ////    return _delivery;
        ////}

        ////public static IInvoiceOutboudDutyDataProvider<InvoiceDutyDomainView> CreateInvOutDutyInvAccess()
        ////{
        ////    IInvoiceOutboudDutyDataProvider<InvoiceDutyDomainView> invDuty = new InvoiceOutboundDutyApiClient();
        ////    return invDuty;
        ////}

        ////public static IInvoiceOutDutyDataProvider<InvoiceDutyDomainView> CreateInvOutTpartyDutyInvAccess()
        ////{
        ////    IInvoiceOutDutyDataProvider<InvoiceDutyDomainView> invDuty = new InvoiceOutDutyApiClient();
        ////    return invDuty;
        ////}

        ////public static ICreditAWBRebillingDataProvider<CreditAWBRebillingDomainView> CreateCreditAwbRebillingAccess()
        ////{
        ////    ICreditAWBRebillingDataProvider<CreditAWBRebillingDomainView> creditAwbRebilling = new CreditAWBRebillingApiClient();
        ////    return creditAwbRebilling;
        ////}

    }
}
