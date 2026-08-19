using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZION.SFA.BE.WebApi.Domain;
using ZION.SFA.Data.SCS;
using ZION.SFA.Domain.Message;
using ZION.SFA.Domain.SCS;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using ZION.SFA.Data.Helpers;
using System.IO;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ZION.SFA.BE.WebApi.Controllers.SCS
{
    [ApiController]
    // [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        InventoryData data = new InventoryData();

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }
       
        [Route("Inventory/test")]
        [HttpGet]
        public string test()
        {
            this._logger.LogInformation(101, "Inoke executing");
            return "Service Running";
        }

        [Route("Inventory/Get_Inventory")]
        [HttpGet]
        public List<StoreStock> Get()
        {
            try
            {
                this._logger.LogInformation(101, "Inoke executing");

                var x = data.Get_Inventory();
                //throw new DomainException("Product could not be found");
                return x;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("Inventory/initialize")]
        [HttpPost]
        public initializeResultView initialize([FromBody] InitPara para)
        {
            this._logger.LogInformation(101, "Inoke executing");

            var x = data.initialize(para);
            return x;


        }

        [Route("Inventory/Login")]
        [HttpPost]
        public ResponseMessage Login([FromBody]login_para para)
        {
               var status = data.Login(para);
            return status;
        }

        [Route("Inventory/Update_Inventory")]
        [HttpPost]
        public ResponseMessage Update_Inventory(List<StoreStock> para)
        {
            var status = data.Update_Inventory(para);
            return status;
        }

        [Route("Inventory/Update_ItemMaster")]
        [HttpPost]
        public ResponseMessage Update_ItemMaster(List<tbl_genItemMaster> para)
        {
            var status = data.Update_ItemMaster(para);
            return status;
        }

        [Route("Inventory/Update_Masters")]
        [HttpPost]
        public ResponseMessage Update_Masters(MasterData para)
        {
            var status = data.Update_Masters(para);
            return status;
        }

        [Route("Inventory/Update_Image")]
        [HttpPost]
        public ResponseMessage Update_Image(ItemImage para)
        {

            try
            {
                byte[] deserializedData = Convert.FromBase64String(para.image);
                System.IO.File.WriteAllBytes("/var/www/iepbe001/itemImage/" + para.imagePath, deserializedData);


                var status = data.Update_Image(para);
                return status;
            }
            catch (Exception ex)
            {
                return new ResponseMessage { StrMessage = ex.Message };
            }
        }
        private static int CalculateNewHeight(int originalWidth, int originalHeight, int newWidth)
        {
            float aspectRatio = (float)originalWidth / originalHeight;
            return (int)(newWidth / aspectRatio);
        }

        [Route("Inventory/getImage/{Item_ID}")]
        [HttpGet]
        public IActionResult getImage(string Item_ID)
        {
            var imagePath = data.get_Imagepath(Item_ID);
            imagePath = "/var/www/iepbe001/itemImage/" + imagePath;

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            // Read the image file and return it as a FileResult
            var imageBytes = System.IO.File.ReadAllBytes(imagePath);

            using (Image image = Image.Load(imagePath))
            {
                int newWidth = 250; // New width in pixels
                int newHeight = CalculateNewHeight(image.Width, image.Height, newWidth);

                image.Mutate(x => x.Resize(newWidth, newHeight));

                byte[] compressedImageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create a new JpegEncoder with reduced quality
                    var jpegEncoder = new JpegEncoder { Quality = 50 }; // Adjust quality value as desired

                    // Save the image with the JpegEncoder
                    image.Save(ms, jpegEncoder);
                    compressedImageBytes = ms.ToArray();
                }

                return File(compressedImageBytes, "image/jpeg");
            }




            return File(imageBytes, "image/jpeg"); // Adjust the content type as per your image type
        }

        [HttpGet("api/images/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            // Logic to retrieve the image file

            // Assuming you have a folder called "Images" in your project root
            var imagePath = "C:\\Data\\a.jpg"; //Path.Combine(Directory.GetCurrentDirectory(), "Images", imageName);

            if (!System.IO.File.Exists(imagePath))
            {
                // Return 404 Not Found if the image doesn't exist
                return NotFound();
            }

            // Read the image file and return it as a FileResult
            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/jpeg"); // Adjust the content type as per your image type
        }




        [Route("Inventory/testex")]
        [HttpGet("throw-domain-exception")]
        public IActionResult ThrowDomainError()
        {
            throw new DomainException("Product could not be found");
        }
    }
}