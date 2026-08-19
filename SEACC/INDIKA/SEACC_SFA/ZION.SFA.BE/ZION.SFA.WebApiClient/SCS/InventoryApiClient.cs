using System;
using System.Collections.Generic;
using ZION.SFA.Domain.Message;
using ZION.SFA.Domain.SCS;

namespace ZION.SFA.WebApiClient.SCS
{
    public class InventoryApiClient
    {
        public ResponseMessage Update_Inventory(List<StoreStock> Para)
        {
            try
            {
                RestClient<ResponseMessage> restClient = new RestClient<ResponseMessage>();
                var result = restClient.Post("Inventory/Update_Inventory", Para).Result;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ResponseMessage Update_ItemMaster(List<tbl_genItemMaster> Para)
        {
            try
            {
                RestClient<ResponseMessage> restClient = new RestClient<ResponseMessage>();
                var result = restClient.Post("Inventory/Update_ItemMaster", Para).Result;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseMessage Update_Masters(MasterData Para)
        {
            try
            {
                RestClient<ResponseMessage> restClient = new RestClient<ResponseMessage>();
                var result = restClient.Post("Inventory/Update_Masters", Para).Result;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseMessage Update_Image(ItemImage Para)
        {
            try
            {
                RestClient<ResponseMessage> restClient = new RestClient<ResponseMessage>();
                var result = restClient.Post("Inventory/Update_Image", Para).Result;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
