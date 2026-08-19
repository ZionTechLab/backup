using AxFOXITREADERLib;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SEACC_printer
{
	public class printDialog : Form
	{
		public delegate void MyEventHandler(string tryCount, bool bIsPrinted);

		public string sFilename = "";

		private Timer t1 = new Timer();

		private int iTryCount = 0;

		private string sTry = "";

		private IContainer components = null;

		private AxFoxitCtl axFoxitCtl1;

		public event printDialog.MyEventHandler OnTryPrint;

		public printDialog()
		{
			this.InitializeComponent();
			this.t1.Interval = 1000;
			this.t1.Tick += new EventHandler(this.t1_Tick);
		}

		private void t1_Tick(object sender, EventArgs e)
		{
			try
			{
				this.t1.Stop();
				this.axFoxitCtl1.OpenFile(this.sFilename);
				this.axFoxitCtl1.PrintFile();
				base.Close();
			}
			catch (Exception)
			{
				this.sTry += ". ";
				this.iTryCount++;
				if (this.iTryCount > 6)
				{
					this.t1.Interval += 600;
				}
				else if (this.iTryCount > 3)
				{
					this.t1.Interval += 300;
				}
				this.t1.Start();
				this.OnTryPrint(this.sTry, false);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			base.Visible = false;
			this.t1.Start();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.OnTryPrint(this.sTry, true);
			this.axFoxitCtl1.Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(printDialog));
            this.axFoxitCtl1 = new AxFoxitCtl();
            ((ISupportInitialize)this.axFoxitCtl1).BeginInit();
            base.SuspendLayout();
            this.axFoxitCtl1.Enabled = true;
            this.axFoxitCtl1.Location = new Point(12, 12);
            this.axFoxitCtl1.Name = "axFoxitCtl1";
            this.axFoxitCtl1.OcxState = (AxHost.State)resources.GetObject("axFoxitCtl1.OcxState");
            this.axFoxitCtl1.Size = new Size(260, 237);
            this.axFoxitCtl1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(284, 261);
            base.Controls.Add(this.axFoxitCtl1);
            base.Name = "printDialog";
            base.Opacity = 0.0;
            base.ShowInTaskbar = false;
            this.Text = "Form1";
            base.TopMost = true;
            base.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
            base.Load += new EventHandler(this.Form1_Load);
            ((ISupportInitialize)this.axFoxitCtl1).EndInit();
            base.ResumeLayout(false);
		}
	}
}
