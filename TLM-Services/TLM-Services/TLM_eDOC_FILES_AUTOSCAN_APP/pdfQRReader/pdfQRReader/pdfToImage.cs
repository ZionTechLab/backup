
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfQRReader
{
    public class pdfToImage
    {

        public void makepdfimages(string path, string output)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(output);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            Thread.Sleep(1000);

            Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
            doc.LoadFromFile(path);
            string fn = Path.GetFileNameWithoutExtension(path);
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                Image img = doc.SaveAsImage(i);
                string fn1 = String.Format("{0}_{1:0000}.png", fn, i + 1);
                string of = Path.Combine(output, fn1);
#pragma warning disable CA1416 // Validate platform compatibility
                img.Save(of, System.Drawing.Imaging.ImageFormat.Png);
#pragma warning restore CA1416 // Validate platform compatibility
            }
        }
    }
}
