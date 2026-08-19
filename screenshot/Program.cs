using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenshotApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // Get the bounds of the primary screen
                Rectangle bounds = Screen.PrimaryScreen.Bounds;

                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }

                    string filename = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    // Save to the current execution directory
                    bitmap.Save(filename, ImageFormat.Png);
                }
            }
            catch
            {
                // Silently ignore errors or log to file if needed
            }
        }
    }
}
