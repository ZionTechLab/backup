using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string sText)
        {
            InitializeComponent();
            this.seaccRichTextBox1.FormatedText = sText;
        }
    }
}
