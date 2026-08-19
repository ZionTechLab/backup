using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHE_Api.Report.Domain
{
    public class QRHelper
    {
        public Bitmap GenerateQR(List<QRCodeDomainView> para)
        {
            //IDictionary<int, string> Specification = new Dictionary<int, string>();
            //Specification.Add(1, "Company Name" );
            //Specification.Add(2, "VAT No");
            //Specification.Add(3, "Date");
            //Specification.Add(4, "Amount with VAT");
            //Specification.Add(5, "VAT Amount");

            var SB = new StringBuilder();

            foreach (QRCodeDomainView Line in para)
            {
                // SB.Append(Specification[Line.Tag] + ":" + Line.Value+"\n");
                SB.Append(ByteToUTF8(Line.Tag));
                SB.Append(ByteToUTF8(Line.Value.Length));
                SB.Append(Line.Value);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(SB.ToString());
            string base64 = Convert.ToBase64String(bytes);
            //    MessageBox.Show(base64);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(base64, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
            //    pictureBox1.Image = qrCodeImage;
        }
        private string ByteToUTF8(int Number)
        {
            Encoding enc = Encoding.GetEncoding("UTF-8");
            System.Byte[] ch = { (Byte)Number };

            return enc.GetString(ch);
        }
    }
}
