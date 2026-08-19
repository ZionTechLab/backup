using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using Express.View.Domain.Report.Invoice;

namespace Express.Data.FedexExpressEF
{
    public class ExpressContext : DbContext
    {
        public ExpressContext()
            : base("name=FedexExpressEntityFramwork")
        {

        }

        public virtual DbSet<RefCity> RefCity { get; set; }
        public virtual DbSet<RefCountry> RefCountry { get; set; }
        public virtual DbSet<RefStateRegion> RefStateRegion { get; set; }
        public virtual DbSet<RefWorldRegion> RefWorldRegion { get; set; }
        public virtual DbSet<RefZipCode> RefZipCode { get; set; }
        public virtual DbSet<cfgHorizontalMenuItem> cfgHorizontalMenuItem { get; set; }
        public virtual DbSet<ConSystemMenu> cfgMenuItem { get; set; }
        public virtual DbSet<cfgCityType> cfgCityType { get; set; }
        public virtual DbSet<ConCompany> ConCompanies { get; set; }
        public virtual DbSet<ConUserDetail> ConUserDetailes { get; set; }
        public virtual DbSet<RefTransTimeDomHed> RefTransTimeDomHeds { get; set; }
        public virtual DbSet<RefTransTimeDom> RefTransTimeDoms { get; set; }
        public virtual DbSet<RefTransTimeDomLT> RefTransTimeDomLTs { get; set; }
        public virtual DbSet<vw_TransTimeDom> vw_TransTimeDom { get; set; }
        public virtual DbSet<RefHolidays> RefHolidays { get; set; }
        public virtual DbSet<RefIndustryType> RefIndustryTypes { get; set; }
        public virtual DbSet<CfgFuelChartType> CfgFuelChartType { get; set; }
        public virtual DbSet<RatesFuelShg> RatesFuelShg { get; set; }
        public virtual DbSet<CfgProductsMain> CfgProductsMains { get; set; }
        public virtual DbSet<CfgProductsMap> CfgProductsMaps { get; set; }
        public virtual DbSet<CfgProductsSub> CfgProductsSubs { get; set; }
        public virtual DbSet<CfgShipmentType> CfgShipmentTypes { get; set; }
        public virtual DbSet<CfgSvcType> CfgSvcType { get; set; }
        public virtual DbSet<RefZone> RefZones { get; set; }
        public virtual DbSet<RefZonesHed> RefZonesHeds { get; set; }
   
        public virtual DbSet<CfgParam1> CfgParams { get; set; }
        public virtual DbSet<RatesSellZoneMasterHed> RatesSellZoneMasterHeads { get; set; }
        public virtual DbSet<RatesSellZoneMaster> RatesSellZoneMasters { get; set; }
        public virtual DbSet<CfgExgRatTarifType> CfgExgRatTarifTypes { get; set; }
        public virtual DbSet<RefLocation> RefLocation { get; set; }
        public virtual DbSet<CfgLocationType> CfgLocationType { get; set; }
        public virtual DbSet<OrgGroup> OrgGroupes { get; set; }
        public virtual DbSet<RefSalesPerson> RefSalesPerson { get; set; }
        public virtual DbSet<RatesSellZoneCustTariff> RatesSellZoneCustTariffs { get; set; }
        public virtual DbSet<RatesSellZoneCustTariffDisc> RatesSellZoneCustTariffDiscs { get; set; }
        public virtual DbSet<RatesSellCountryMasterHed> RatesSellCountryMasterHeds { get; set; }
        public virtual DbSet<RatesSellCountryMaster> RatesSellCountryMasters { get; set; }
        public virtual DbSet<RatesSellCountryCustTariffDisc> RatesSellCountryCustTariffDiscs { get; set; }
        public virtual DbSet<RatesSellCountryCustTariff> RatesSellCountryCustTariffs { get; set; }
        public virtual DbSet<RatesExchange> RatesExchange { get; set; }
        public virtual DbSet<CfgFamilyLife> CfgFamilyLife { get; set; }
        public virtual DbSet<RefDesignation> CfgDesignation { get; set; }
        public virtual DbSet<CfgMaritalStatus> CfgMaritalStatus { get; set; }
        public virtual DbSet<CfgTransportMethod> CfgTransportMethod { get; set; }
        public virtual DbSet<OrgContactsFamily> RefContactFamilyDetail { get; set; }
        public virtual DbSet<OrgContacts> RefContact { get; set; }
        public virtual DbSet<CfgeDocType> CfgeDocType { get; set; }
        public virtual DbSet<RefeDoc> RefeDoc { get; set; }
        public virtual DbSet<ConSystemMenuOption> ConSystemMenuOptions { get; set; }
        public virtual DbSet<RefOrgNote> RefOrgNote { get; set; }
        public virtual DbSet<cfgTitle> cfgTitle { get; set; }
        public virtual DbSet<RefOrgDepartment> RefOrgDepartment { get; set; }
        public virtual DbSet<CfgInvoiceMode> CfgInvoiceMode { get; set; }
        public virtual DbSet<CfgOrgStatus> CfgOrgStatus { get; set; }
        public virtual DbSet<CfgCreditRating> CfgCreditRating { get; set; }
        public virtual DbSet<OrgCreditLimit> OrgCreditLimit { get; set; }
        public virtual DbSet<RefSalesArea> RefSalesArea { get; set; }
        public virtual DbSet<RefSvcRoot> RefSvcRoot { get; set; }
        public virtual DbSet<RefCompany> RefCompany { get; set; }
        public virtual DbSet<ConAgency> ConAgency { get; set; }
        public virtual DbSet<RefOrganization> RefOrganization { get; set; }
        public virtual DbSet<RefHub> RefHub { get; set; }
        public virtual DbSet<RefVisaRoot> RefVisaRoot { get; set; }
        public virtual DbSet<RefAirLine> RefAirLine { get; set; }
        public virtual DbSet<OpsConsMaster> OpsConsMaster { get; set; }
        public virtual DbSet<OpsConsAWB> OpsConsAWB { get; set; }
        public virtual DbSet<RatesCostAgnZoneMasterHed> RatesCostAgnZoneMasterHeds { get;set;}
        public virtual DbSet<RatesCostAgnZoneMaster> RatesCostAgnZoneMasters { get; set; }
        public virtual DbSet<RatesCostAgnCountryMasterHed> RatesCostAgnCountryMasterHeds { get; set; }
        public virtual DbSet<RatesCostAgnCountryMaster> RatesCostAgnCountryMasters { get; set; }
        public virtual DbSet<RatesCostAgnCountryCustTariff > RatesCostAgnCountryCustTariffs { get; set; }
        public virtual DbSet<RatesCostAgnCountryCustTariffDisc> RatesCostAgnCountryCustTariffDiscs { get; set; }
        public virtual DbSet<RatesCostAgnZoneCustTariff > RatesCostAgnZoneCustTariffs { get; set; }
        public virtual DbSet<RatesCostAgnZoneCustTariffDisc> RatesCostAgnZoneCustTariffDiscs { get; set; }
        public virtual DbSet<CfgPackType> CfgPackType { get; set; }
        public virtual DbSet<FinanceRefOrganization> FinanceRefOrganization { get; set; }
        public virtual DbSet<SharedMainRefOrganization> SharedMainRefOrganization { get; set; }
        public virtual DbSet<CfgDoctypes> CfgDoctypeses { get; set; }
        public virtual DbSet<RefChargeCodesInvoice> RefChargeCodesInvoices { get; set; }
        public virtual DbSet<RefChargeCode> RefChargeCodes { get; set; }
        public virtual DbSet<RefChartAcGrpMain> RefChartAcGrpMains { get; set; }
        public virtual DbSet<CfgAccountTypes> CfgAccountType { get; set; }
        public  virtual DbSet<RefChartAcGrpSub> RefChartAcGrpSubs { get; set; }
        public virtual DbSet<RefChartAcActMain> RefChartAcActMains { get; set; }
        public virtual DbSet<RefChartAcActSub> RefChartAcActSubs { get; set; }
        public virtual DbSet<RefChartAcActSub2> RefChartAcActSub2 { get; set; }
        public virtual DbSet<CfgCurrencyLF> CfgCurrencyLFs { get; set; }
        public virtual DbSet<RefCountryExpress> RefCountryExpress { get; set; }
        public virtual DbSet<RefDocType> RefDocTypes { get; set; }
        public virtual DbSet<RefBranch> RefBranch { get; set; }
        public virtual DbSet<RatesSellZoneCustSpecHed> RatesSellZoneCustSpecHeds { get; set; }
        public virtual DbSet<RatesSellZoneCustSpec> RatesSellZoneCustSpecs { get; set; }

        public virtual DbSet<MapScanType> MapScanType  { get; set; }
        public virtual DbSet<RefSalesAreaGroup> RefSalesAreaGroup { get; set; }
        public virtual DbSet<CfgUploadFormatType> CfgUploadFormatType { get; set; }
        public virtual DbSet<AudOpsConsAWB> AudOpsConsAWB { get; set; }

        public virtual DbSet<MapCustomsChargeCode> MapCustomsChargeCode { get; set; }
        public virtual DbSet<TrCusdecDet> TrCusdecDet { get; set; }
        public virtual DbSet<TrCusdecHed> TrCusdecHed { get; set; }
        public virtual DbSet<RefTaxOrg> RefTaxOrg { get; set; }
        public virtual DbSet<AudEmail> AudEmail { get; set; }

        public virtual DbSet<CfgCurrencies> CfgCurrency { get; set; }
        public virtual DbSet<CfgCountry> CfgCountry { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ExpressContext>(null);
          
        }

        
    }
}
