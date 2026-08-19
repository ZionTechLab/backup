using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHE_Api.Report.Domain
{
    public class Cast
    {
        public static Byte[] ImageToByteArray(Bitmap Image)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(Image, typeof(byte[]));
        }

    }
}
