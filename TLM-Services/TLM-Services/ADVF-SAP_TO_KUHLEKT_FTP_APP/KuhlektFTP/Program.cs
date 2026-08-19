using KuhlektFTP;
using KuhlektFTP.SFTP;
using System.Configuration;
using System.Diagnostics;

string LOCALFOLDER = AppDomain.CurrentDomain.BaseDirectory;

try
{
    Console.WriteLine("TEST START");

    Logger.LogToFile(LOCALFOLDER + @"/Log.txt", "FILE UPLOAD STARTED");

    string SAP_IP = ConfigurationManager.AppSettings["SAP_IP"] ?? "";
    string SAP_PORT = ConfigurationManager.AppSettings["SAP_PORT"] ?? "";
    string SAP_UN = Protect.GetKey(ConfigurationManager.AppSettings["SAP_SUN"] ?? "");
    string SAP_PW = "4keDzpP&$W%LQKma4Q";
    //4keDzpP&$W%LQKma4Q
    
    //Protect.GetKey(ConfigurationManager.AppSettings["SAP_SPW"] ?? "");
    string SAP_SOURCE = ConfigurationManager.AppSettings["SAP_SOURCE"] ?? "";
    string SAP_DESTIN = ConfigurationManager.AppSettings["SAP_DESTIN"] ?? "";


    string SOURCE_PROTOCOL = ConfigurationManager.AppSettings["SOURCE_PROTOCOL"] ?? "";
    string SOURCE_IP = ConfigurationManager.AppSettings["SOURCE_IP"] ?? "";
    string SOURCE_PORT = ConfigurationManager.AppSettings["SOURCE_PORT"] ?? "";
    string SOURCE_UN = Protect.GetKey(ConfigurationManager.AppSettings["SOURCE_SUN"] ?? "");
    string SOURCE_PW = "COL%$7ki8&845";// Protect.GetKey(ConfigurationManager.AppSettings["SOURCE_SPW"] ?? "");
    string SOURCE_PATH = ConfigurationManager.AppSettings["SOURCE_PATH"] ?? "";
    string SOURCE_OPTIONS = ConfigurationManager.AppSettings["SOURCE_OPTIONS"] ?? "";

    string ARCHIVE_IP = ConfigurationManager.AppSettings["ARCHIVE_IP"] ?? "";
    string ARCHIVE_PORT = ConfigurationManager.AppSettings["ARCHIVE_PORT"] ?? "";
    string ARCHIVE_UN = Protect.GetKey(ConfigurationManager.AppSettings["ARCHIVE_SUN"] ?? "");
    string ARCHIVE_PW = "COL%$7ki8&845"; //Protect.GetKey(ConfigurationManager.AppSettings["ARCHIVE_SPW"] ?? "");
    string ARCHIVE_PATH = ConfigurationManager.AppSettings["ARCHIVE_PATH"] ?? "";

    string DESTIN_PROTOCOL = ConfigurationManager.AppSettings["DESTIN_PROTOCOL"] ?? "";
    string DESTIN_IP = ConfigurationManager.AppSettings["DESTIN_IP"] ?? "";
    string DESTIN_PORT = ConfigurationManager.AppSettings["DESTIN_PORT"] ?? "";
    string DESTIN_UN = Protect.GetKey(ConfigurationManager.AppSettings["DESTIN_SUN"] ?? "");
    string DESTIN_PW = "KLaq1wEpCG[P"; //Protect.GetKey(ConfigurationManager.AppSettings["DESTIN_SPW"] ?? "");
    string DESTIN_PATH = ConfigurationManager.AppSettings["DESTIN_PATH"] ?? "";
    string DESTIN_OPTIONS = ConfigurationManager.AppSettings["DESTIN_OPTIONS"] ?? "";
    string DESTIN_ARCHIVE_PATH = ConfigurationManager.AppSettings["DESTIN_ARCHIVE_PATH"] ?? "";
    string FILES = ConfigurationManager.AppSettings["FILES"] ?? "";

    List<string> FilesList = FILES.Split(',').ToList();
    List<DownSourceDestin> SAPSList = new List<DownSourceDestin>();
    List<DownSourceDestin> SourceDestinList = new List<DownSourceDestin>();
    List<DownSourceDestin> LocaltoDestinList = new List<DownSourceDestin>();
    List<DownSourceDestin> LocaltoArchiveList = new List<DownSourceDestin>();

    foreach (string file in FilesList)
    {
        var fileloc = new DownSourceDestin
        {
            SourceFile = SAP_SOURCE + file,
            DestinFile = SAP_DESTIN + file
        };
        SAPSList.Add(fileloc);
    }
    foreach (string file in FilesList)
    {
        var fileloc = new DownSourceDestin
        {
            SourceFile = SOURCE_PATH + file,
            DestinFile = LOCALFOLDER + @"/DOWNLOADS/" + file
        };
        SourceDestinList.Add(fileloc);
    }
    foreach (string file in FilesList)
    {
        var fileloc = new DownSourceDestin
        {
            SourceFile = LOCALFOLDER + @"/DOWNLOADS/" + file,
            DestinFile = DESTIN_PATH + file
        };
        LocaltoDestinList.Add(fileloc);
    }

    foreach (string file in FilesList)
    {
        string filename = Path.GetFileNameWithoutExtension(LOCALFOLDER + @"/DOWNLOADS/" + file);
        string ext = Path.GetExtension(LOCALFOLDER + @"/DOWNLOADS/" + file);
        string newfilename = filename.Replace(filename, filename + "-" + DateTime.Now.Ticks + ext);


        var fileloc = new DownSourceDestin
        {
            SourceFile = LOCALFOLDER + @"/DOWNLOADS/" + file,
            DestinFile = ARCHIVE_PATH + newfilename
        };
        LocaltoArchiveList.Add(fileloc);
    }



    //foreach (var x in SAPSList)
    //{
        
        //KuhlektFTP.SFTP.Downloads.DownloadSCP(SAP_IP, SAP_UN, SAP_PW, SAPSList);
       
        
        //Process cmd = new Process();
        //cmd.StartInfo.FileName = @"C:\Program Files\PuTTY\pscp.exe";
        //cmd.StartInfo.UseShellExecute = false;
        //cmd.StartInfo.RedirectStandardInput = true;
        //cmd.StartInfo.RedirectStandardOutput = true;

        //string argument = @"-P " + SAP_PORT + " -pw " + '"' + SAP_PW + '"' + " " + SAP_UN + "@" + SAP_IP + ":" + x.SourceFile + " " + '"' + x.DestinFile + '"';
        //Logger.LogToFile(LOCALFOLDER + @"/Log.txt", "" + argument);

        //cmd.StartInfo.Arguments = argument;

        //cmd.Start();
        //cmd.StandardInput.WriteLine("exit");
        //string output = cmd.StandardOutput.ReadToEnd();
        //Logger.LogToFile(LOCALFOLDER + @"/Log.txt", "" + output);
        //    Process cmd = new Process();
        //string putty = '"' + @"C:\Program Files\PuTTY\pscp.exe" + '"';
        //cmd.StartInfo.FileName = @"cmd.exe";
        //cmd.StartInfo.UseShellExecute = false;
        //cmd.StartInfo.RedirectStandardInput = true;
        //cmd.StartInfo.RedirectStandardOutput = true;
        //cmd.Start();

        //using (StreamWriter sw = cmd.StandardInput)
        //{

        //    string argument = @"-P " + SAP_PORT + " -pw " + '"' + SAP_PW + '"' + " " + SAP_UN + "@" + SAP_IP + ":" + x.SourceFile + " " + '"' + x.DestinFile + '"';
        //    Console.WriteLine(argument);
        //    sw.WriteLine(argument);
        //}
        //  cmd.StartInfo.Arguments = argument;
        //  cmd.Start();       
    //}
    ////cmd.StandardInput.WriteLine("exit");
    //string output = cmd.StandardOutput.ReadToEnd();
    Console.WriteLine("SAP PUTTY");
    //string fingerprint = "ssh-ed25519 255 oLpDNAGF9ot2DV8ETj6fsI35jQfHwKavd+u7GAGShPU=";
    string fingerprint = "ssh-ed25519 255 9S0IyrL/OPH+Al+LHmLE1DUD8xzRoD8OL1IJm4IGtqA=";

    //KuhlektFTP.SFTP.Downloads.SCPDownload(SAP_IP, SAP_PORT, SAP_UN, SAP_PW, fingerprint, SAPSList);
    KuhlektFTP.SFTP.Downloads.DownloadSCP(SAP_IP, SAP_PORT, SAP_UN, SAP_PW, SAPSList);
    Console.WriteLine("SOURCE");
    KuhlektFTP.SFTP.Downloads.DownloadFiles(SOURCE_IP, SOURCE_UN, SOURCE_PW, SourceDestinList);
    Console.WriteLine("DESTIN");
    KuhlektFTP.SFTP.Uploads.UploadFiles(DESTIN_IP, DESTIN_UN, DESTIN_PW, LocaltoDestinList);
    Console.WriteLine("ARCHIVE");
    KuhlektFTP.SFTP.Uploads.UploadFiles(ARCHIVE_IP, ARCHIVE_UN, ARCHIVE_PW, LocaltoArchiveList);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Logger.LogToFile(LOCALFOLDER + @"/Log.txt", "" + ex);
}

