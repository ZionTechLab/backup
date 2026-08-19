using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FedexExpress.View.Domain.AdminConfiguration;
using System.Data;
using Express.Data.FedexExpressEF;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Dapper;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Login;
using Express.Domain.Message;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using FedexExpress.View.Domain.Operations;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using Dapper.Bulk;

namespace Express.Data.Operations.Manifest
{
    public class PodScanData : IPodScansProvider
    {
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@UserID", UserId);
                    para.Add("@ModuleID", ModuleId);
                    para.Add("@MenuID", MenueId);
                
                    return (List<AgencyDomainViewcs>)conn.Query<AgencyDomainViewcs>("[Project].[TLM_ErpGetUserAgencyList]", para, commandType: CommandType.StoredProcedure).ToList();
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

        public IList<CourrierDomainView> GetCourrier(string CountryID)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@Country", CountryID);
                    return (List<CourrierDomainView>)conn.Query<CourrierDomainView>("[Express].[TLM_GetAllCourrier]", para, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<PodScanRptDomainView> GetPodScanReport(PodScanUploadParaDomainView para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var _para = new DynamicParameters();
                    _para.Add("@angencyID", para.AgencyID );
                    _para.Add("@cmpyID", para.CompanyID );
                    _para.Add("@dateFrom", para.DateFrom );
                    _para.Add("@dateTo", para.DateTo );
                    _para.Add("@ConsNo", "");
                    _para.Add("@custCode", "");
                    _para.Add("@ShipType", "I");                  

                    return (List<PodScanRptDomainView>)conn.Query<PodScanRptDomainView>("[Express].[TLM_GetPodReportScan]", _para, commandType: CommandType.StoredProcedure).ToList();
                }
              
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY)
        {
            try
            {
                

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@CMPY", CMPY);                   
                    return (List<RefSvcRootsDomainView>)conn.Query<RefSvcRootsDomainView>("[Express].[TLM_GetRefSvcRoots]", para, commandType: CommandType.StoredProcedure).ToList();
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

        public MapScanTypeDomainView GetScanTypes(int CompanyId, int AgencyId, string ScanTypeS)
        {
            try
            {
                using (IDbConnection db =new SqlConnection( DapperConnetion.GetConnetion()))
                {
                    string query = @"SELECT       
                                      [ScanTypeS]
                                      ,[ScanTypeP]
                                      ,[RemarkS]
                                      ,[RemarkP]
                                      ,[PODScan]      
                                  FROM [Express].[MapScanType]
                                  WHERE CMPY = @CompanyId  AND AgncyCode = @AgencyId AND ScanTypeS =@ScanTypeS AND   Active = 'Y' ";
                    return (MapScanTypeDomainView)db.Query<MapScanTypeDomainView>(query, new { CompanyId = CompanyId , AgencyId = AgencyId  , ScanTypeS  = ScanTypeS }).FirstOrDefault();

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

        public ResponseMessage ReprocessPods(PodScanUploadParaDomainView _para)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
                {

                    //////string xmlString = "<ROOT>";

                   

                    //////for(int i = 0; i < _para.PodList.Count; i++ )
                    //////{
                    //////    var item = _para.PodList[i];
                    //////    if (item.ScanProcessErr.Trim() == "" || item.ScanProcessErr.Trim() == "Invalid AWB")
                    //////    {
                    //////        xmlString = xmlString + "<ROW>"
                    //////          + "<CMPY>" + _para.CompanyID + "</CMPY>"
                    //////          + "<AgncyCode>" + _para.AgencyID + "</AgncyCode>"
                    //////          + "<TrackNoScan>" + item.Trackno + "</TrackNoScan>"
                    //////          + "<ScanDateTime>" + item.ScanDateTimeObj + "</ScanDateTime>"
                    //////          + "<EmployeeID>" + item.EmployeeID + "</EmployeeID>"
                    //////          + "<ScanTypeS>" + item.ScanTypeS + "</ScanTypeS>"
                    //////          + "<ScanTypeP>" + item.ScanTypeP + "</ScanTypeP>"
                    //////          + "<ScanDescS>" + item.ScanDescS + "</ScanDescS>"
                    //////          + "<ScanDescP>" + item.ScanDescP + "</ScanDescP>"
                    //////          + "<ScanCapture>" + item.ScanCapture + "</ScanCapture>"
                    //////          + "<ScanRoute>" + item.RoutID + "</ScanRoute>"
                    //////          + "<ScanProcess>" + item.ScanProcess + "</ScanProcess>"
                    //////          + "<StatusCode>" + item.StatusCode + "</StatusCode>"
                    //////          + "<ScanProcessErr>" + item.ScanProcessErr + "</ScanProcessErr>"
                    //////          + "<USM_ID>" + _para.UserID + "</USM_ID>"
                    //////          + "<USM_DATE>" + _para.UDate + "</USM_DATE>"
                    //////          + "</ROW>";
                    //////    }
                    //////}
                    //////xmlString = xmlString + "</ROOT>";


                    var para = new DynamicParameters();
                    para.Add("@CompanyID", _para.CompanyID );
                    para.Add("@AgencyCode", _para.AgencyID );
                    para.Add("@IsFromSave", 0);
                    para.Add("@dFrom", _para.DateFrom );
                    para.Add("@dTo", _para.DateTo);
                    para.Add("@IsUnprocess", _para.UnprocessScan);
                    para.Add("@IsAllCourier", _para.AllCurrier );
                    para.Add("@IsAllRoute", _para.AllRoute);
                    para.Add("@Courier", _para.CurrierID);
                    para.Add("@RouteID", _para.RoutID);                    
                    para.Add("@responce", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    var responce = db.Query<int>("[Express].[TLM_PodProcess]", para, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (para.Get<string>("@responce") == "Successfull")
                    {
                        mMessage.StrMessage = AppMessage.SaveSuccess;
                        mMessage.IsSuccess = true;
                    }
                    else
                    {
                        mMessage.StrMessage = para.Get<string>("@responce");
                        mMessage.IsSuccess = false;
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = sqlEx.GetBaseException() as SqlException;
                throw new DataUpdateException("0", mMessage.StrMessage, "Express", sqlEx);
            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;

            }
            return mMessage;

        }

        public IList<PodScanUploadDomainView> RetrivePods(PodScanUploadParaDomainView _para)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    string query = @"SELECT 
                                    [CMPY]CompanyID ,
                                    [AgncyCode]AgencyID ,
                                    LTRIM(RTRIM([TrackNoScan]))  Trackno,
                                    [ScanDateTime] ScanDateTimeObj ,
                                    LTRIM(RTRIM([EmployeeID])) EmployeeID,
                                    LTRIM(RTRIM([ScanTypeS])) ScanTypeS ,
                                    LTRIM(RTRIM([ScanTypeP])) ScanTypeP ,
                                    LTRIM(RTRIM([ScanCapture]))ScanCapture,
                                    LTRIM(RTRIM([ScanRoute])) RoutID ,
                                    LTRIM(RTRIM([ScanProcess]))ScanProcess,
                                    LTRIM(RTRIM([StatusCode]))ScanDescS ,
                                    LTRIM(RTRIM([ScanProcessErr]))ScanProcessErr ,
                                    [USM_ID] ,
                                    (SELECT [PrefereedName] FROM [Project].[AdminUserDetails] WHERE UserID = [USM_ID] AND Active='Y') UserN,
                                    CONVERT(varchar(5),cast( USM_DATE  as time))UploadTime
                                    FROM
                                    Express.TrScans 
                                    WHERE CMPY =@CmpID AND AgncyCode =@AgencyCode 
                                    AND CONVERT(date,  ScanDateTime ,102) BETWEEN (CONVERT(date , @dFrom ,102)) and (CONVERT(date ,@dTo ,102))
                                    AND ((@IsUnprocess =0) OR (ScanProcessErr = 'Invalid AWB'))
                                    AND ((@IsAllCourier =1) OR (EmployeeID = @Courier ))
                                    AND ((@IsAllRoute=1 ) OR (ScanRoute =@RouteID ))";
                    return (List<PodScanUploadDomainView>)db.Query<PodScanUploadDomainView>(query, new { CmpID = _para.CompanyID, AgencyCode = _para.AgencyID 
                                          ,dFrom =_para.DateFrom , dTo=_para.DateTo ,IsUnprocess=_para.UnprocessScan ,IsAllCourier=_para.AllCurrier 
                                          ,IsAllRoute=_para.AllRoute , Courier =_para.CurrierID ,RouteID=_para.RoutID }).ToList();

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

        public ResponseMessage SavePods(IList<PodScanUploadDomainView> PodL)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    ///////////Test 2 /////////////////////////////////////////////////

                    #region Reference Type Table Bulk insert

                    //DataTable dataTable = new DataTable("tbTrScans");
                    //dataTable.Columns.Add("CMPY");
                    //dataTable.Columns.Add("AgncyCode");
                    //dataTable.Columns.Add("TrackNoScan");
                    //dataTable.Columns.Add("ScanDateTime");
                    //dataTable.Columns.Add("EmployeeID");
                    //dataTable.Columns.Add("ScanTypeS");
                    //dataTable.Columns.Add("ScanTypeP");
                    //dataTable.Columns.Add("ScanDescS");
                    //dataTable.Columns.Add("ScanDescP");
                    //dataTable.Columns.Add("ScanCapture");
                    //dataTable.Columns.Add("ScanRoute");
                    //dataTable.Columns.Add("ScanProcess");
                    //dataTable.Columns.Add("StatusCode");
                    //dataTable.Columns.Add("ScanProcessErr");
                    //dataTable.Columns.Add("USM_ID");
                    //dataTable.Columns.Add("USM_DATE");

                    //var podinsertList = PodL.Where(items => items.ScanProcessErr.Trim() == "" || items.ScanProcessErr.Trim() == "Invalid AWB").ToList();

                    //for (int i = 0; i < podinsertList.Count; i++)
                    //{
                    //    var item = podinsertList[i];
                    //    dataTable.Rows.Add(item.CompanyID,
                    //                        item.AgencyID,
                    //                        item.Trackno,
                    //                        item.ScanDateTimeObj,
                    //                        item.EmployeeID,
                    //                        item.ScanTypeS,
                    //                        item.ScanTypeP,
                    //                        item.ScanDescS,
                    //                        item.ScanDescP,
                    //                        item.ScanCapture,
                    //                        item.RoutID,
                    //                        item.ScanProcess,
                    //                        item.StatusCode,
                    //                        item.ScanProcessErr,
                    //                        item.USM_ID,
                    //                        item.UserDate
                    //          );

                    //}
                    //var a = dataTable.AsTableValuedParameter();

                    //var para = new DynamicParameters();
                    //para.Add("@Mode", "I");
                    //para.Add("@CompanyId", PodL.FirstOrDefault().CompanyID);
                    //para.Add("@AgencyCode", PodL.FirstOrDefault().AgencyID);
                    //para.Add("@tbTrScans", dataTable.AsTableValuedParameter());
                    //para.Add("@responce", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    ///////////////////////var responce = db.Query<int>("[Express].[TLM_AddEditScanTypes]", para, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    //var responce = db.Execute("[Express].[TLM_AddEditScanTypes]", para, commandTimeout: 6000, commandType: CommandType.StoredProcedure);


                    //if (para.Get<string>("@responce") == "Successfull")
                    //{
                    //    mMessage.StrMessage = AppMessage.SaveSuccess;
                    //    mMessage.IsSuccess = true;
                    //}
                    //else
                    //{
                    //    mMessage.StrMessage = para.Get<string>("@responce");
                    //    mMessage.IsSuccess = false;
                    //}

                    #endregion


                    ////////End Test 2///////////////////////////////////////////                 


                    #region dapper.bulk 
                    var podinsertList = PodL.Where(items => items.ScanProcessErr.Trim() == "" || items.ScanProcessErr.Trim() == "Invalid AWB").ToList();
                    TrScan _trscan = null;
                    List<TrScan> _trscanlist = new List<FedexExpressEF.DBDomain.EntityTypes.TrScan>();
                    for (int i = 0; i < podinsertList.Count; i++)
                    {
                        var item = podinsertList[i];
                        _trscan = new FedexExpressEF.DBDomain.EntityTypes.TrScan();

                        _trscan.Deleted = false;
                        _trscan.CMPY = item.CompanyID;
                        _trscan.AgncyCode = item.AgencyID;
                        _trscan.TrackNoScan = item.Trackno;
                        _trscan.ScanDateTime = Convert.ToDateTime(item.ScanDateTimeObj);
                        _trscan.EmployeeID = item.EmployeeID;
                        _trscan.ScanTypeS = item.ScanTypeS;
                        _trscan.ScanTypeP = item.ScanTypeP;
                        _trscan.ScanDescS = item.ScanDescS;
                        _trscan.ScanDescP = item.ScanDescP;
                        _trscan.ScanCapture = item.ScanCapture;
                        _trscan.ScanRoute = item.RoutID;
                        _trscan.ScanProcess = item.ScanProcess; ;
                        _trscan.StatusCode = item.StatusCode;
                        _trscan.ScanProcessErr = item.ScanProcessErr;
                        _trscan.USM_ID = item.USM_ID;
                        _trscan.USM_DATE = Convert.ToDateTime(item.UserDate);
                        _trscanlist.Add(_trscan);
                    }


                    db.Open();
                    using (IDbTransaction transaction = db.BeginTransaction())
                    {
                        try
                        {
                            ((SqlConnection)db).BulkInsert(_trscanlist, (SqlTransaction)transaction, 1000, 300);                            
                            transaction.Commit();
                        }
                        catch(Exception  ex)
                        {                            
                            transaction.Rollback();
                        }                      
                    }

                    var _para = podinsertList.FirstOrDefault();
                    var para = new DynamicParameters();
                    para.Add("@CompanyID", _para.CompanyID);
                    para.Add("@AgencyCode", _para.AgencyID);
                    para.Add("@IsFromSave", 1);
                    para.Add("@dFrom", DateTime.Now);
                    para.Add("@dTo", DateTime.Now);
                    para.Add("@IsUnprocess", 0);
                    para.Add("@IsAllCourier", 1);
                    para.Add("@IsAllRoute", 1);
                    para.Add("@Courier", "");
                    para.Add("@RouteID", "");
                    para.Add("@responce", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    ////var responce = db.Query<int>("[Express].[TLM_PodProcess]", para, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    var responce = db.Execute("[Express].[TLM_PodProcess]", para, commandTimeout: 6000, commandType: CommandType.StoredProcedure);

                    if (para.Get<string>("@responce") == "Successfull")
                    {
                        mMessage.StrMessage = AppMessage.SaveSuccess;
                        mMessage.IsSuccess = true;
                    }
                    else
                    {
                        mMessage.StrMessage = para.Get<string>("@responce");
                        mMessage.IsSuccess = false;
                    }


                    #endregion

                }

            }
            catch (SqlException sqlEx)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = sqlEx.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", sqlEx);
            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;

            }
            return mMessage;

        }
    }
}
