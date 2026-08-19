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
using SixLabors.ImageSharp;
using ZION.SFA.Domain.Message;
using System.IO;

namespace InventryUpdateService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log.WriteLog("Service Started");
            #region Hourly
            while (!stoppingToken.IsCancellationRequested)
            {
                Log.WriteLog("Worker - init running at: "+ DateTimeOffset.Now.ToString());
                _logger.LogInformation("Worker - init  running at: {time}", DateTimeOffset.Now);
               
                var apic = new InventoryApiClient();

                try
                {
                    var xx = new MasterData();

                    using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                    {
                        var para = new DynamicParameters();

                        using (var multi = db.QueryMultiple("[dbo].[sp_get_MasterData]", para, commandTimeout: 600, commandType: CommandType.StoredProcedure))
                        {
                            xx.Items = multi.Read<tbl_genItemMaster>().ToList();
                            xx.Customer = multi.Read<Customer>().ToList();
                            xx.CustomerOutstanding = multi.Read<CustomerOutstanding>().ToList();
                            xx.ItemPricing = multi.Read<ItemPricing>().ToList();
                        }
                    }

                    var result = apic.Update_Masters(xx);
                    if (result.IsSuccess)
                    {
                        Log.WriteLog("Worker - init  success");
                        _logger.LogInformation("Worker - init  success", DateTimeOffset.Now);
                    }
                    else
                    {
                        Log.WriteLog("Worker - init " + result.varOutMsg);
                        _logger.LogInformation(result.varOutMsg, DateTimeOffset.Now);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message, DateTimeOffset.Now);
                    Log.WriteLog(ex.Message);
                }

                try
                {
                    var xx = new List<ItemImage>();

                    using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                    {
                        var para = new DynamicParameters();
                        para.Add("@OutType", 1);
                        using (var multi = db.QueryMultiple("[dbo].[sp_get_MasterData]", para, commandTimeout: 600, commandType: CommandType.StoredProcedure))
                        {
                            xx = multi.Read<ItemImage>().ToList();
                        }
                    }
                    Log.WriteLog("Image Upload Started");
                    foreach (ItemImage item in xx)
                    {
                        Log.WriteLog("Worker - init  success");


                        var fs = System.IO.File.ReadAllBytes("D:\\Production\\Zion\\SEACC-LOGIN-LIVE\\Images\\" + item.imagePath);
                        //    using (Image image = Image.Load("C:\\Data\\Source\\Zion15\\INDIKA\\SEACC\\Mini ERP\\bin\\Debug\\Images\\"+item.imagePath))
                        //    {
                        //byte[] imageBytes;
                        //using (MemoryStream ms = new MemoryStream())
                        //{
                        //    image.Save(ms, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder());
                        //    imageBytes = ms.ToArray();
                        //}

                        string serializedString = Convert.ToBase64String(fs);

                        Log.WriteLog(item.imagePath);
                            item.image = serializedString;

                            var result = apic.Update_Image(item);
                            if (result.IsSuccess)
                            {
                                ResponseMessage y;
                                using (IDbConnection db = new SqlConnection(DapperConnection.GetConnetion()))
                                {
                                    var para = new DynamicParameters();
                                    para.Add("@item_ID", item.item_ID);
                                    using (var multi = db.QueryMultiple("[dbo].[Update_ImageStatus]", para, commandTimeout: 600, commandType: CommandType.StoredProcedure))
                                    {
                                        y = multi.Read<ResponseMessage>().FirstOrDefault();
                                    }
                                }
                                if (y.IsSuccess)
                                {
                                    Log.WriteLog("  success");
                                    _logger.LogInformation(" success", DateTimeOffset.Now);
                                }
                                else
                                {
                                    Log.WriteLog(y.varOutMsg);
                                }
                            }
                            else
                            {
                                Log.WriteLog( result.varOutMsg);
                                _logger.LogInformation(result.varOutMsg, DateTimeOffset.Now);
                            }
                       // }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message, DateTimeOffset.Now);
                    Log.WriteLog(ex.Message);
                }


                //  Thread.Sleep(60 * 10 * 1000);
                await Task.Delay(60 *60* 5 * 1000, stoppingToken);//5 hours
            } 
            #endregion

          
        }
    }
}
