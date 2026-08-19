using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            if (com != null)
            {
                com.CompanyName = clsCript.Encrypt(textBox1.Text.Trim());
                com.Address = clsCript.Encrypt(textBox2.Text.Trim());
                com.Update();
            }


            // textBox1.Text



            //  label1.Text = dateTimePicker1.Value.TimeOfDay.ToString("HH:mm");
            /*
            label3.Text = dateTimePicker1.Value.Hour + "." +dateTimePicker1.Value.Minute;
            TimeSpan tTimeSpan = TimeSpan.FromHours(Decimal.ToDouble(decimal.Parse((dateTimePicker1.Value.Hour + "." +dateTimePicker1.Value.Minute).ToString())));
            label1.Text ="HH:"+ tTimeSpan.TotalHours.ToString();
            label2.Text = "MM:" + tTimeSpan.Minutes.ToString();
            label3.Text = "SS:" + tTimeSpan.Seconds.ToString();
            */
            //TimeSpan tTimeSpan =TimeSpan.FromHours(Decimal.ToDouble(decimal.Parse(textBox1.Text.ToString())));
            //TimeSpan tTimeSpan = TimeSpan.FromHours(Decimal.ToDouble(decimal.Parse(textBox1.Text.ToString())));
            //label1.Text = "HH:" + tTimeSpan.Hours.ToString();
            //label2.Text = "MM:" + tTimeSpan.Minutes.ToString();
            //label3.Text = "SS:" + tTimeSpan.Seconds.ToString();

            // dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, tTimeSpan.Hours, tTimeSpan.Minutes, 0);

            //dateTimePicker1.Value = Convert.ToDateTime((tTimeSpan.).ToString());
            //  dateTimePicker1.Value.
            // decimal.Parse(dateTimePicker1.Value.ToString().Replace("AM","")

        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            //dateTimePicker1.CustomFormat = "HH:mm";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("ebuwa");
        }

    }
}
