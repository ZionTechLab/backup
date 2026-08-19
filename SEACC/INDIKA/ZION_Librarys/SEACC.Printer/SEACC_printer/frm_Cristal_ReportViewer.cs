using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SEACC_printer
{
	public class frm_Cristal_ReportViewer : Form
	{
		public delegate void MyEventHandler(string tryCount, bool bIsPrinted);

		private int iErrorCount = 0;

		public string sRptPath = "";

		private string sTry = "";

		private IContainer components = null;

		public CrystalReportViewer crystalReportViewer1;

		private Timer timer1;

		public event frm_Cristal_ReportViewer.MyEventHandler OnTryPrint;

		public frm_Cristal_ReportViewer()
		{
			this.InitializeComponent();
		}

		public bool PrintReport()
		{
			bool bStatus = false;
			this.timer1.Stop();
			try
			{
				this.Cursor = Cursors.WaitCursor;
				ReportDocument objRpt = new ReportDocument();
				objRpt.Load(this.sRptPath);
				this.crystalReportViewer1.ReportSource = objRpt;
				this.crystalReportViewer1.Refresh();
				this.crystalReportViewer1.DisplayToolbar = true;
				this.crystalReportViewer1.CloseView(false);
				base.WindowState = FormWindowState.Maximized;
				base.ShowDialog();
				this.OnTryPrint("", true);
				objRpt.Close();
				objRpt.Dispose();
				this.DeleteFile(this.sRptPath);
				bStatus = true;
			}
			catch (Exception ex)
			{
				if (ex.Message == "Load report failed.")
				{
					Application.Restart();
				}
				else
				{
					MessageBox.Show(ex.Message);
					if (this.iErrorCount == 9)
					{
						this.timer1.Stop();
						this.OnTryPrint("Error ", false);
						bStatus = true;
					}
					else
					{
						this.iErrorCount++;
						this.OnTryPrint(this.sTry, false);
						this.timer1.Start();
						this.timer1.Interval += 500;
						this.sTry += ".";
					}
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
			return bStatus;
		}

		private bool DeleteFile(string filename)
		{
			bool bRet = false;
			try
			{
				File.Delete(filename);
				bRet = true;
			}
			catch (Exception)
			{
			}
			return bRet;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Cristal_ReportViewer));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(653, 611);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 2500;
            // 
            // frm_Cristal_ReportViewer
            // 
            this.ClientSize = new System.Drawing.Size(653, 611);
            this.Controls.Add(this.crystalReportViewer1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frm_Cristal_ReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEACC – Remote report viewer";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

		}
	}
}
