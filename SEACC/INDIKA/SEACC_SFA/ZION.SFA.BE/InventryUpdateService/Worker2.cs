using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZION.SFA.Domain.SCS;
using ZION.SFA.WebApiClient.SCS;

namespace InventryUpdateService
{
    public class Worker2 : BackgroundService
    {
        private readonly ILogger<Worker2> _logger;

        public Worker2(ILogger<Worker2> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log.WriteLog("Service Started");
            //#region Hourly
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    Log.WriteLog("Worker1 running at: " + DateTimeOffset.Now.ToString());
            //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            //    try
            //    {
            //        var xx = new MasterData();

            //        using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
            //        {
            //            var para = new DynamicParameters();

            //            using (var multi = db.QueryMultiple("[dbo].[sp_get_MasterData]", para, commandTimeout: 600, commandType: CommandType.StoredProcedure))
            //            {
            //                xx.Items = multi.Read<tbl_genItemMaster>().ToList();
            //                xx.Customer = multi.Read<Customer>().ToList();
            //                xx.CustomerOutstanding = multi.Read<CustomerOutstanding>().ToList();
            //            }
            //        }

            //        var apic = new InventoryApiClient();
            //        var result = apic.Update_Masters(xx);
            //        if (result.IsSuccess)
            //        {
            //            Log.WriteLog("Worker1 success");
            //            _logger.LogInformation("Worker1 success", DateTimeOffset.Now);
            //        }
            //        else
            //        {
            //            Log.WriteLog("Worker1" + result.varOutMsg);
            //            _logger.LogInformation(result.varOutMsg, DateTimeOffset.Now);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogInformation(ex.Message, DateTimeOffset.Now);
            //        Log.WriteLog(ex.Message);
            //    }
            //    //  Thread.Sleep(60 * 10 * 1000);
            //    await Task.Delay(60 * 10 * 1000, stoppingToken);//10 minits
            //}
            //#endregion

            #region 10 minits
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker2 running at: {time}", DateTimeOffset.Now);
                Log.WriteLog("Worker running at: " + DateTimeOffset.Now.ToString());
                try
                {
                    var lists = new List<StoreStock>();
                    using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                    {
                        var para = new DynamicParameters();
                        lists = db.Query<StoreStock>("[dbo].[sp_Get_Inventory]", para, commandType: CommandType.StoredProcedure).ToList();
                    }

                    var apic = new InventoryApiClient();
                    var result = apic.Update_Inventory(lists);
                    if (result.IsSuccess)
                    {
                        _logger.LogInformation("Worker2 success", DateTimeOffset.Now);
                        Log.WriteLog("Worker2 success");
                    }
                    else
                    {
                        _logger.LogInformation(result.varOutMsg, DateTimeOffset.Now);
                        Log.WriteLog("Worker2" + result.varOutMsg);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message, DateTimeOffset.Now);
                    Log.WriteLog("Worker2" + ex.Message);
                }
                await Task.Delay(60 * 10 * 1000, stoppingToken);//10 minits
            }
            #endregion
        }
    }
}
