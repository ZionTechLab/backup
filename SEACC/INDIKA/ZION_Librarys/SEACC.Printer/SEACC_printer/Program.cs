using System;
using System.Windows.Forms;

namespace SEACC_printer
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DIGITEQ_RDPrinter());
		}
	}
}
