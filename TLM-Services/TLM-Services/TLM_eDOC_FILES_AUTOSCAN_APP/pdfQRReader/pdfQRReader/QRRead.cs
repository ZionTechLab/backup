
using QRCodeDecoderLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Drawing.Imaging;
using System.IO;

using System.Threading.Tasks;
using ZXing.ZKWeb;
using System.DrawingCore;

namespace pdfQRReader
{
    public class QRRead
    {
     
        public Result decode(string uri)
        {
            Bitmap image;
            try
            {
                image = (Bitmap)Bitmap.FromFile(uri);
            }
            catch (Exception)
            {
                throw new FileNotFoundException("Resource not found: " + uri);
            }

            using (image)
            {
                LuminanceSource source;
                //var bitMap = (System.DrawingCore.Bitmap)System.DrawingCore.Bitmap.FromStream(stream);
                //var source = new ZXing.ZKWeb.BitmapLuminanceSource(bitMap);
                //var binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));

                source = new BitmapLuminanceSource(image);
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                Result result = new MultiFormatReader().decode(bitmap);
                if (result != null)
                {
                    //... code found
                }
                else
                {
                    //... no code found
                }
                return result;
            }
        }
       
        public string ScanQR(string pdfPath)
        {
            List<string> QRvals = new List<string>();
            pdfToImage pdf = new pdfToImage();
            string qrdata = "";
           
            
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string outputpath = ConfigurationManager.AppSettings["pdftoImagespath"];
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #pragma warning disable CS8604 // Possible null reference argument.
            pdf.makepdfimages(pdfPath, outputpath);
            #pragma warning restore CS8604 // Possible null reference argument.
            string? outputpath1 = outputpath;
            
            foreach (var item in Directory.GetFiles(outputpath1))
            {
                if (Path.GetExtension(item).ToLower() == ".png")
                {
                   
                    var result = decode(item);
                    
                    if(result != null)
                    {
                        QRvals.Add(result.Text);
                    }
                    
                }
            }          

            qrdata = QRvals.FirstOrDefault();
            #pragma warning disable CS8603 // Possible null reference return.
            return qrdata;
            #pragma warning restore CS8603 // Possible null reference return.
        }

        //        public string ScanQR(string pdfPath)
        //        {
        //            List<string> QRvals = new List<string>();
        //            string qrdata = "";
        //#pragma warning disable CS0618 // Type or member is obsolete
        //            BarcodeResult[] PagedResults = (BarcodeResult[])BarcodeReader.ReadBarcodesFromPdf(pdfPath);
        //#pragma warning restore CS0618 // Type or member is obsolete
        //            // Work with the results
        //#pragma warning disable CS0618 // Type or member is obsolete
        //            foreach (BarcodeResult PageRes in PagedResults)
        //            {
        //                int pagenumber = PageRes.PageNumber;
        //                string Value = PageRes.Value;
        //                Bitmap Img = PageRes.BarcodeImage;
        //                BarcodeEncoding BarcodeType = PageRes.BarcodeType;
        //                byte[] Binary = PageRes.BinaryValue;
        //                Console.WriteLine(PageRes.Value);
        //                QRvals.Add(PageRes.Value);
        //            }

        //#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        //            qrdata = QRvals.FirstOrDefault();
        //#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        //            return qrdata;
        //#pragma warning restore CS0618 // Type or member is obsolete
        //        }
    }

    
}
