using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frmImageViewer : Form
    {
        public frmImageViewer()
        {
            InitializeComponent();
        }
        public frmImageViewer(string sImagePath):this()
        {
            FillDetailsImage(sImagePath);
        }                    

        private void FillDetailsImage(string sImagePath)
        {
            if (sImagePath != "" || sImagePath != "Default")
            {
                if (File.Exists("Images\\" + sImagePath))
                {
                    pbxImage.Image = System.Drawing.Image.FromFile("Images\\" + sImagePath);
                }
            }
        }
    }
}
