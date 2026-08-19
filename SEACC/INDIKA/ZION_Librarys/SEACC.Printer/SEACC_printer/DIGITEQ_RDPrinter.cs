//using iTextSharp.text;
//using iTextSharp.text.pdf;
using PdfSharp.Pdf.Printing;
using Spire.Pdf;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace SEACC_printer
{
	public class DIGITEQ_RDPrinter : Form
	{
        #region Public Variables
        public const int WM_NCLBUTTONDOWN = 161;

        public const int HT_CAPTION = 2;

        private string sFileFullName = "";

        private string sDirName = "";

        private DirectoryInfo sDir;

        private DirectoryInfo sDir_Temp;

        private int i_Xvalue = 50;

        private int i_Yvalue = 0;

        private string sPrintedValue = "";

        private IContainer components = null;

        private Timer timer1;

        private NotifyIcon notifyIcon1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem closeServiceToolStripMenuItem;

        private ToolStripMenuItem restartServiceToolStripMenuItem;

        private ToolStripMenuItem openLogFileToolStripMenuItem;

        private PrintDocument PntDocCheque;

        private Label label1;

        private Button btn_reset;

        private PictureBox pictureBox1;

        private Panel panel1;

        private Label label2;

        private Timer tmrMessege;

        private Button btnClose;

        private Button btnMakeBig; 
        #endregion

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public DIGITEQ_RDPrinter()
		{
			this.InitializeComponent();
		}

		private void ShowMessege(string messege)
		{
			this.label2.Text = messege;
			this.tmrMessege.Start();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			base.Location = new Point(Screen.PrimaryScreen.Bounds.Width - base.Width, Screen.PrimaryScreen.Bounds.Height - base.Height - 10);
			this.ShowMessege("Service Started - V" + Application.ProductVersion);
			try
			{
				this.sDirName = File.ReadAllText("Config.ini");
				if (!Directory.Exists("Temp_RPT"))
				{
					Directory.CreateDirectory("Temp_RPT");
				}
				this.sDir = new DirectoryInfo(this.sDirName);
				this.sDir_Temp = new DirectoryInfo("Temp_RPT");
				if (!this.sDir.Exists)
				{
					this.sDir.Create();
				}
				this.timer1.Start();
				FileInfo[] Files = this.sDir.GetFiles("*.*");
				FileInfo[] Files_Temp = this.sDir_Temp.GetFiles("*.*");
				try
				{
					if (Files.Length > 0)
					{
						FileInfo[] array = Files;
						for (int i = 0; i < array.Length; i++)
						{
							FileInfo file = array[i];
							try
							{
								file.Delete();
							}
							catch
							{
							}
						}
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (Files_Temp.Length > 0)
					{
						FileInfo[] array = Files_Temp;
						for (int i = 0; i < array.Length; i++)
						{
							FileInfo file = array[i];
							try
							{
								file.Delete();
							}
							catch
							{
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
			catch (FileNotFoundException)
			{
				this.ShowMessege("Configaration File Not Found");
			}
			finally
			{
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				FileInfo[] Files = this.sDir.GetFiles("*.pdf");
				FileInfo[] FilesXml = this.sDir.GetFiles("*.xml");
				FileInfo[] FilesRpt = this.sDir.GetFiles("*.rpt");
				FileInfo[] FilesRpt_Temp = this.sDir_Temp.GetFiles("*.rpt");
				if (Files.Length > 0)
				{
					FileInfo[] array = Files;
					for (int i = 0; i < array.Length; i++)
					{
						FileInfo file = array[i];
						try
						{
							this.timer1.Stop();
							this.ShowMessege("New Print Document Found!");
							this.sPrintedValue = file.FullName;
							this.sFileFullName = file.FullName;

                            PrintDialog printDialog1 = new PrintDialog();
                            DialogResult result = printDialog1.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //spire pdf
                                PdfDocument pdfdocument = new PdfDocument();
                                pdfdocument.LoadFromFile(this.sFileFullName);
                                pdfdocument.PrinterName = printDialog1.PrinterSettings.PrinterName;
                                pdfdocument.PrintDocument.Print();
                                pdfdocument.Dispose();
                            }

                            //printDialog frm = new printDialog();
                            //frm.OnTryPrint += new printDialog.MyEventHandler(this.frm1_OnTryPrint);
                            //frm.sFilename = this.sFileFullName;
                            //frm.ShowDialog();

							File.Delete(this.sFileFullName);
							this.timer1.Start();
						}
						catch (Exception)
						{
							this.ShowMessege("Error...  ");
							this.timer1.Start();
						}
						finally
						{
							this.sFileFullName = "";
						}
					}
				}
				if (FilesXml.Length > 0)
				{
					FileInfo[] array = FilesXml;
					for (int i = 0; i < array.Length; i++)
					{
						FileInfo file = array[i];
						try
						{
							this.timer1.Stop();
							this.ShowMessege("New Print Document Found! ");
							this.sFileFullName = file.FullName;
							this.PntDocCheque.DefaultPageSettings.Landscape = true;
							new PageSetupDialog
							{
								Document = this.PntDocCheque
							}.ShowDialog();
							new PrintPreviewDialog
							{
								Document = this.PntDocCheque,
								Width = 800,
								TopMost = true
							}.ShowDialog();
							File.Delete(this.sFileFullName);
							this.timer1.Start();
						}
						catch (Exception)
						{
							this.ShowMessege("Error...  ");
							this.timer1.Start();
						}
						finally
						{
							this.sFileFullName = "";
						}
					}
				}
				if (FilesRpt.Length > 0)
				{
					FileInfo[] array = FilesRpt;
					for (int i = 0; i < array.Length; i++)
					{
						FileInfo file = array[i];
						try
						{
							File.Copy(file.FullName, "Temp_RPT\\" + Path.GetFileName(file.FullName));
							File.Delete(file.FullName);
						}
						catch (Exception)
						{
						}
					}
				}
				if (FilesRpt_Temp.Length > 0)
				{
					FileInfo[] array = FilesRpt_Temp;
					for (int i = 0; i < array.Length; i++)
					{
						FileInfo file = array[i];
						try
						{
							this.timer1.Stop();
							this.ShowMessege("New Print Document Found! ");
							frm_Cristal_ReportViewer oRPT = new frm_Cristal_ReportViewer();
							oRPT.OnTryPrint += new frm_Cristal_ReportViewer.MyEventHandler(this.oRPT_OnTryPrint);
							oRPT.sRptPath = file.FullName;
							oRPT.PrintReport();
							this.timer1.Start();
						}
						catch (Exception)
						{
							this.ShowMessege("Error... ");
							this.timer1.Start();
						}
					}
				}
			}
			catch (Exception)
			{
				this.ShowMessege("Somting wrong call system admin....!");
				MessageBox.Show("Somting wrong....!");
			}
		}

		private void oRPT_OnTryPrint(string tryCount, bool bIsPrinted)
		{
			if (bIsPrinted)
			{
				this.ShowMessege("Printing....");
			}
			else
			{
				this.ShowMessege("Trying to print  " + tryCount.ToString());
			}
		}

		private void frm1_OnTryPrint(string tryCount, bool bIsPrinted)
		{
			if (bIsPrinted)
			{
				this.ShowMessege("Printing....");
			}
			else
			{
				this.ShowMessege("Trying to print  " + tryCount.ToString());
			}
		}

		private void notifyIcon1_Click(object sender, EventArgs e)
		{
			this.contextMenuStrip1.Show();
			this.contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
		}

		private void closeServiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void restartServiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}

		private void PntDocCheque_PrintPage(object sender, PrintPageEventArgs e)
		{
			string Cheque_Date = "";
			string Payee = "";
			string Bank = "";
			string Amount = "";
			string IsPayee = "False";
			string date = "";
			string month = "";
			string year = "";
			string CurrencyToWord = "";
			this.ReadValue(ref Cheque_Date, ref Payee, ref Bank, ref Amount, ref IsPayee, ref date, ref month, ref year, ref CurrencyToWord);
			bool bIsPayee = bool.Parse(IsPayee);
			try
			{
				StringFormat sf = new StringFormat();
                System.Drawing.Font Font_Title = new System.Drawing.Font("Calibri", 9f, FontStyle.Bold);
                System.Drawing.Font Font_Title2 = new System.Drawing.Font("Calibri", 10f, FontStyle.Bold);
                System.Drawing.Font Font_Title3 = new System.Drawing.Font("Calibri", 14f, FontStyle.Bold);
                System.Drawing.Font Font_Title4 = new System.Drawing.Font("Calibri", 14f, FontStyle.Regular);
				if (Bank.Length > 0)
				{
					string sPayee = Payee.ToString();
					string sAmount = "***" + Amount.ToString();
					string sDate = Cheque_Date;
					string d = date.Substring(0, 1);
					string d2 = date.Substring(1, 1);
					string m = month.Substring(0, 1);
					string m2 = month.Substring(1, 1);
					string y = year.Substring(0, 1);
					string y2 = year.Substring(1, 1);
					string y3 = year.Substring(2, 1);
					string y4 = year.Substring(3, 1);
					string sAccountPayee = "** Account Payee Only **";
					string sUndeline = "______________________";
					if (bIsPayee && Bank.Trim() != "COMMERCIAL BANK")
					{
						e.Graphics.DrawString(sUndeline, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 340, this.i_Yvalue + 38), sf);
						e.Graphics.DrawString(sAccountPayee, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 340, this.i_Yvalue + 50), sf);
						e.Graphics.DrawString(sUndeline, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 340, this.i_Yvalue + 51), sf);
					}
					int iLastStr = 16;
					if (sPayee.Length <= 48)
					{
						iLastStr = sPayee.Length - 32;
					}
					string[] sRupee = this.SplitWord(CurrencyToWord);
					string text = Bank.Trim();
					if (text != null)
					{
						if (!(text == "SAMPATH BANK"))
						{
							if (!(text == "HATTON NATIONAL BANK"))
							{
								if (!(text == "PEOPLE’S BANK"))
								{
									if (!(text == "SEYLAN BANK"))
									{
										if (text == "COMMERCIAL BANK")
										{
											if (bIsPayee)
											{
												e.Graphics.DrawString(sUndeline, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 200, this.i_Yvalue + 32), sf);
												e.Graphics.DrawString(sAccountPayee, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 200, this.i_Yvalue + 45), sf);
												e.Graphics.DrawString(sUndeline, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 200, this.i_Yvalue + 45), sf);
											}
											this.i_Yvalue += 5;
											this.i_Xvalue += 3;
											e.Graphics.DrawString(sDate, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 57, this.i_Yvalue + 5), sf);
											if (sPayee.Length < 16)
											{
												e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
											}
											else if (sPayee.Length < 32)
											{
												e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
												e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 84));
											}
											else
											{
												e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
												e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 84));
												e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 108));
											}
											e.Graphics.DrawString(sAmount, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 60, this.i_Yvalue + 205));
											e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 240, this.i_Yvalue + 62));
											e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 245, this.i_Yvalue + 103));
											e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 131));
											e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 161));
											e.Graphics.DrawString(d, Font_Title4, Brushes.Black, new Point(this.i_Xvalue + 653, this.i_Yvalue + 11));
											e.Graphics.DrawString(d2, Font_Title4, Brushes.Black, new Point(this.i_Xvalue + 678, this.i_Yvalue + 11));
											e.Graphics.DrawString(m, Font_Title4, Brushes.Black, new Point(this.i_Xvalue + 702, this.i_Yvalue + 11));
											e.Graphics.DrawString(m2, Font_Title4, Brushes.Black, new Point(this.i_Xvalue + 728, this.i_Yvalue + 11));
											e.Graphics.DrawString(y3, Font_Title4, Brushes.Black, new Point(this.i_Xvalue + 802, this.i_Yvalue + 11));
											e.Graphics.DrawString(y4, Font_Title4, Brushes.Black, new Point(this.i_Xvalue + 826, this.i_Yvalue + 11));
											e.Graphics.DrawString(sAmount, Font_Title3, Brushes.Black, new Point(this.i_Xvalue + 690, this.i_Yvalue + 127));
										}
									}
									else
									{
										e.Graphics.DrawString(sDate, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 57, this.i_Yvalue + 5), sf);
										if (sPayee.Length < 16)
										{
											e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
										}
										else if (sPayee.Length < 32)
										{
											e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
											e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 84));
										}
										else
										{
											e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
											e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 84));
											e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 108));
										}
										e.Graphics.DrawString(sAmount, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 60, this.i_Yvalue + 205));
										e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 240, this.i_Yvalue + 62));
										e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 245, this.i_Yvalue + 103));
										e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 131));
										e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 161));
										e.Graphics.DrawString(d, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 653, this.i_Yvalue + 11));
										e.Graphics.DrawString(d2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 678, this.i_Yvalue + 11));
										e.Graphics.DrawString(m, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 702, this.i_Yvalue + 11));
										e.Graphics.DrawString(m2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 728, this.i_Yvalue + 11));
										e.Graphics.DrawString(y3, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 802, this.i_Yvalue + 11));
										e.Graphics.DrawString(y4, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 826, this.i_Yvalue + 11));
										e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 676, this.i_Yvalue + 127));
									}
								}
								else
								{
									e.Graphics.DrawString(sDate, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 57, this.i_Yvalue + 5), sf);
									if (sPayee.Length < 16)
									{
										e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 53), sf);
									}
									else if (sPayee.Length < 32)
									{
										e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 53), sf);
										e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 78));
									}
									else
									{
										e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 53), sf);
										e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 78));
										e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 103));
									}
									e.Graphics.DrawString(sAmount, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 60, this.i_Yvalue + 205));
									e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 240, this.i_Yvalue + 63));
									e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 245, this.i_Yvalue + 103));
									e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 131));
									e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 161));
									e.Graphics.DrawString(d, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 653, this.i_Yvalue + 15));
									e.Graphics.DrawString(d2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 678, this.i_Yvalue + 15));
									e.Graphics.DrawString(m, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 702, this.i_Yvalue + 15));
									e.Graphics.DrawString(m2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 728, this.i_Yvalue + 15));
									e.Graphics.DrawString(y3, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 802, this.i_Yvalue + 15));
									e.Graphics.DrawString(y4, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 826, this.i_Yvalue + 15));
									e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 676, this.i_Yvalue + 127));
								}
							}
							else
							{
								e.Graphics.DrawString(sDate, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 57, this.i_Yvalue + 5), sf);
								if (sPayee.Length < 16)
								{
									e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
								}
								else if (sPayee.Length < 32)
								{
									e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
									e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 84));
								}
								else
								{
									e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 60), sf);
									e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 84));
									e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 108));
								}
								e.Graphics.DrawString(sAmount, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 60, this.i_Yvalue + 205));
								e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 240, this.i_Yvalue + 62));
								e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 245, this.i_Yvalue + 103));
								e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 131));
								e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 225, this.i_Yvalue + 161));
								e.Graphics.DrawString(d, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 653, this.i_Yvalue + 11));
								e.Graphics.DrawString(d2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 678, this.i_Yvalue + 11));
								e.Graphics.DrawString(m, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 702, this.i_Yvalue + 11));
								e.Graphics.DrawString(m2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 728, this.i_Yvalue + 11));

                                //add this 2017-11-30
                                e.Graphics.DrawString(y, Font_Title, Brushes.Black, new Point(i_Xvalue + 756, i_Yvalue + 11));//year1
                                e.Graphics.DrawString(y2, Font_Title, Brushes.Black, new Point(i_Xvalue + 778, i_Yvalue + 11));//year2
                                //old code
                                e.Graphics.DrawString(y3, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 802, this.i_Yvalue + 11));//year3
                                e.Graphics.DrawString(y4, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 826, this.i_Yvalue + 11));//year4
								e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 676, this.i_Yvalue + 127));
							}
						}
						else
						{
							e.Graphics.DrawString(sDate, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 57, this.i_Yvalue + 2), sf);
							if (sPayee.Length < 16)
							{
								e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 20, this.i_Yvalue + 85), sf);
							}
							else if (sPayee.Length < 32)
							{
								e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 20, this.i_Yvalue + 85), sf);
								e.Graphics.DrawString(sPayee.Substring(16, sPayee.Length - 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 111));
							}
							else
							{
								e.Graphics.DrawString(sPayee.Substring(0, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 20, this.i_Yvalue + 85), sf);
								e.Graphics.DrawString(sPayee.Substring(16, 16), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 111));
								e.Graphics.DrawString(sPayee.Substring(32, iLastStr), Font_Title2, Brushes.Black, new Point(this.i_Xvalue, this.i_Yvalue + 137));
							}
							e.Graphics.DrawString(sAmount, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 60, this.i_Yvalue + 245));
							e.Graphics.DrawString(sPayee, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 240, this.i_Yvalue + 63));
							e.Graphics.DrawString(sRupee[0], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 240, this.i_Yvalue + 103));
							e.Graphics.DrawString(sRupee[1], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 220, this.i_Yvalue + 131));
							e.Graphics.DrawString(sRupee[2], Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 220, this.i_Yvalue + 161));
							e.Graphics.DrawString(d, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 653, this.i_Yvalue + 10));
							e.Graphics.DrawString(d2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 678, this.i_Yvalue + 10));
							e.Graphics.DrawString(m, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 702, this.i_Yvalue + 10));
							e.Graphics.DrawString(m2, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 728, this.i_Yvalue + 10));
							e.Graphics.DrawString(y3, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 802, this.i_Yvalue + 10));
							e.Graphics.DrawString(y4, Font_Title, Brushes.Black, new Point(this.i_Xvalue + 826, this.i_Yvalue + 10));
							e.Graphics.DrawString(sAmount, Font_Title2, Brushes.Black, new Point(this.i_Xvalue + 676, this.i_Yvalue + 127));
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private string[] SplitWord(string sWord)
		{
			int Counter = 0;
			string[] word = sWord.Split(new char[]
			{
				' '
			});
			string[] ArrayStr = new string[]
			{
				"",
				"",
				""
			};
			string[] array = word;
			for (int i = 0; i < array.Length; i++)
			{
				string str = array[i];
				Counter += str.Length + 1;
				if (Counter < 56)
				{
					string[] array2;
					(array2 = ArrayStr)[0] = array2[0] + str + " ";
				}
				else if (Counter < 110)
				{
					string[] array2;
					(array2 = ArrayStr)[1] = array2[1] + str + " ";
				}
				else
				{
					string[] array2;
					(array2 = ArrayStr)[2] = array2[2] + str + " ";
				}
			}
			return ArrayStr;
		}

		private void ReadValue(ref string Cheque_Date, ref string Payee, ref string Bank, ref string Amount, ref string IsPayee, ref string date, ref string month, ref string year, ref string CurrencyToWord)
		{
			XmlTextReader reader = new XmlTextReader(this.sFileFullName);
			string NoteElimentvalue = "";
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					NoteElimentvalue = reader.Name;
				}
				if (reader.NodeType == XmlNodeType.Text)
				{
					string text = NoteElimentvalue;
					switch (text)
					{
					case "Cheque_Date":
						Cheque_Date = reader.Value;
						break;
					case "Payee":
						Payee = reader.Value;
						break;
					case "Bank":
						Bank = reader.Value;
						break;
					case "Amount":
						Amount = reader.Value;
						break;
					case "IsPayee":
						IsPayee = reader.Value;
						break;
					case "date":
						date = reader.Value;
						break;
					case "month":
						month = reader.Value;
						break;
					case "year":
						year = reader.Value;
						break;
					case "CurrencyToWord":
						CurrencyToWord = reader.Value;
						break;
					}
				}
			}
			reader.Close();
		}

		private void DIGITEQ_RDPrinter_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				DIGITEQ_RDPrinter.ReleaseCapture();
				DIGITEQ_RDPrinter.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		private void btn_reset_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}

		private void tmrMessege_Tick(object sender, EventArgs e)
		{
			this.label2.Text = "";
			this.tmrMessege.Stop();
			this.btnMakeBig.Visible = true;
			base.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 10, Screen.PrimaryScreen.Bounds.Height - base.Height - 10);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 10, Screen.PrimaryScreen.Bounds.Height - base.Height - 10);
			this.btnMakeBig.Visible = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Location = new Point(Screen.PrimaryScreen.Bounds.Width - base.Width, Screen.PrimaryScreen.Bounds.Height - base.Height - 10);
			this.btnMakeBig.Visible = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DIGITEQ_RDPrinter));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restartServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PntDocCheque = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrMessege = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMakeBig = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "DIGITEQ RD PRINTER";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Tag = "";
            this.notifyIcon1.Text = "DIGITEQ RD Printer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartServiceToolStripMenuItem,
            this.openLogFileToolStripMenuItem,
            this.closeServiceToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 70);
            // 
            // restartServiceToolStripMenuItem
            // 
            this.restartServiceToolStripMenuItem.Name = "restartServiceToolStripMenuItem";
            this.restartServiceToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.restartServiceToolStripMenuItem.Text = "Restart Service";
            this.restartServiceToolStripMenuItem.Click += new System.EventHandler(this.restartServiceToolStripMenuItem_Click);
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openLogFileToolStripMenuItem.Text = "Open Log File";
            // 
            // closeServiceToolStripMenuItem
            // 
            this.closeServiceToolStripMenuItem.Name = "closeServiceToolStripMenuItem";
            this.closeServiceToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeServiceToolStripMenuItem.Text = "Stop Service";
            this.closeServiceToolStripMenuItem.Click += new System.EventHandler(this.closeServiceToolStripMenuItem_Click);
            // 
            // PntDocCheque
            // 
            this.PntDocCheque.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PntDocCheque_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SEACC printer manager";
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Location = new System.Drawing.Point(72, 30);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 2;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(15, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 59);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DIGITEQ_RDPrinter_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 49);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 49);
            this.label2.TabIndex = 0;
            // 
            // tmrMessege
            // 
            this.tmrMessege.Interval = 6000;
            this.tmrMessege.Tick += new System.EventHandler(this.tmrMessege_Tick);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(187, -7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 24);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMakeBig
            // 
            this.btnMakeBig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMakeBig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMakeBig.BackgroundImage")));
            this.btnMakeBig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMakeBig.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMakeBig.FlatAppearance.BorderSize = 0;
            this.btnMakeBig.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMakeBig.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMakeBig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBig.Location = new System.Drawing.Point(0, 0);
            this.btnMakeBig.Name = "btnMakeBig";
            this.btnMakeBig.Size = new System.Drawing.Size(15, 59);
            this.btnMakeBig.TabIndex = 6;
            this.btnMakeBig.UseVisualStyleBackColor = false;
            this.btnMakeBig.Visible = false;
            this.btnMakeBig.Click += new System.EventHandler(this.button1_Click);
            // 
            // DIGITEQ_RDPrinter
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(203, 108);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnMakeBig);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DIGITEQ_RDPrinter";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ButtonFace;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DIGITEQ_RDPrinter_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
