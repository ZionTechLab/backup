namespace NotepadLite;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm(args.Length > 0 ? args[0] : null));
    }
}
