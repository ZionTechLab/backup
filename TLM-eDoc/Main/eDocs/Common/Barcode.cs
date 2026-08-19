using BusinessRefinery.Barcode;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace eDocs.Common
{
    public class Barcode
    {

        public static byte[] CreateEANBarcode(string data)
        {

            BusinessRefinery.Barcode.Linear barcode = new BusinessRefinery.Barcode.Linear();
            barcode.Symbology = BusinessRefinery.Barcode.Symbology.EAN128;
            barcode.Code = data;
            barcode.DisplayStartStopChar = true;
            barcode.DisplayText = false;
            barcode.Resolution = 104;
            barcode.Rotate = BusinessRefinery.Barcode.Rotate.Rotate0;
            barcode.Format = ImageFormat.Jpeg;
            Bitmap bmp = barcode.drawBarcodeOnBitmap();

            Bitmap crop = bmp.Clone(new Rectangle(3, 35, bmp.Width - 3, bmp.Height - 35), bmp.PixelFormat);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            crop.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //  pictureBox1.Image = crop;
            //  imoge = crop;
            //Rectangle cloneRect = new Rectangle(0, 0, 1000, 1000);
            //System.Drawing.Imaging.PixelFormat format = bmp.PixelFormat;
            //Bitmap cloneBitmap = bmp.Clone(cloneRect, format);

            //pictureBox1.Image = crop;

            return ms.ToArray();

        }

        public byte[] GenBarcode(string data)
        {

            Linear barcode = new Linear();

            barcode.DisplayStartStopChar = true;
            barcode.DisplayText = false;
            barcode.BarcodeUnit = BarcodeUnit.PIXEL;
            barcode.Code = data;
            barcode.BottomMargin = 7;
            barcode.TopMargin = 7;
            barcode.LeftMargin = 5;
            barcode.RightMargin = 5;
            barcode.Rotate = Rotate.Rotate180;
            barcode.Format = ImageFormat.Png;

            Bitmap bmp = barcode.drawBarcodeOnBitmap();

            Bitmap crop = bmp.Clone(new Rectangle(3, 35, bmp.Width - 3, bmp.Height - 35), bmp.PixelFormat);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            crop.Save(ms, System.Drawing.Imaging.ImageFormat.Png);


            return ms.ToArray();

        }


        public static byte[] CreateSupermarketBarcode(string data)
        {
            try
            {
                data = data.Remove(12);
            }
            catch { }
            BusinessRefinery.Barcode.Linear barcode = new BusinessRefinery.Barcode.Linear();
            barcode.Symbology = BusinessRefinery.Barcode.Symbology.EAN13;
            barcode.Code = data;
            barcode.DisplayStartStopChar = true;
            barcode.DisplayText = false;
            //barcode.TextFont = new Font("Arial", 5.0f, FontStyle.Bold);
            barcode.Resolution = 104;
            //barcode.Resolution = 180;
            //barcode.BarcodeHeight = 50;
            //barcode.BarcodeUnit = BusinessRefinery.Barcode.BarcodeUnit.CM;
            barcode.Rotate = BusinessRefinery.Barcode.Rotate.Rotate0;
            barcode.Format = ImageFormat.Png;
            Bitmap bmp = barcode.drawBarcodeOnBitmap();

            Bitmap crop = bmp.Clone(new Rectangle(3, 35, bmp.Width - 3, bmp.Height - 35), bmp.PixelFormat);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            crop.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            // pictureBox1.Image = crop;
            //  imoge = crop;
            //Rectangle cloneRect = new Rectangle(0, 0, 1000, 1000);
            //System.Drawing.Imaging.PixelFormat format = bmp.PixelFormat;
            //Bitmap cloneBitmap = bmp.Clone(cloneRect, format);

            //pictureBox1.Image = crop;

            return ms.ToArray();
        }


        public static byte[] QRCode(string qrcodestring)
        {
            //generate qrcode
            //string qrcodedata = qrcodestring;
            QRCodeEncoder encoder = new QRCodeEncoder();
            //encoder.QRCodeVersion = 13;
            Bitmap qrcodeimage = encoder.Encode(qrcodestring);

            //get image to stream
            MemoryStream ms = new MemoryStream();
            qrcodeimage.Save(ms, ImageFormat.Png);
            ms.Close();
            return ms.ToArray();
        }

    }
}