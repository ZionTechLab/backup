using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using WinSCP;

namespace KuhlektFTP.SFTP
{
    public static class Downloads
    {
        public static void DownloadFiles(string host, string username, string password, List<DownSourceDestin> files)
        {
            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();
                foreach (var file in files)
                {
                    if (File.Exists(file.DestinFile))
                    {
                        File.Delete(file.DestinFile);
                        Thread.Sleep(2000);
                    }

                    using (Stream fileStream = File.OpenWrite(file.DestinFile ?? ""))
                    {
                        Console.WriteLine("DOWNLOADING");
                        Console.WriteLine(file.SourceFile);
                        sftp.DownloadFile(file.SourceFile ?? "", fileStream);
                        Thread.Sleep(5000);
                    }
                }
                sftp.Disconnect();
            }
        }


        public static void SCPDownload(string host,string port, string username, string password,string fingerprint, List<DownSourceDestin> files)
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Scp,
                HostName = host,
                PortNumber = Convert.ToInt32("0"+port),
                UserName = username,
                Password =password,
                SshHostKeyFingerprint = fingerprint,
            };
            //sessionOptions.AddRawSettings("Compression", "on");
            sessionOptions.AddRawSettings("SendBuf", "off");

            using (WinSCP.Session session = new WinSCP.Session())
            {
                // Connect
                session.Open(sessionOptions);

                // Download files
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Automatic;

                TransferOperationResult transferResult;
                transferResult =
                                session.GetFiles("/sftp/*", @"C:\Debtors_Dashboard\", false, transferOptions);

                // Throw on any error
                transferResult.Check();

                // Print results
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    Console.WriteLine("Download of {0} succeeded", transfer.FileName);
                }
            }
        }
        public static void DownloadSCP(string host,string port, string username, string password, List<DownSourceDestin> files)
        {
            try
            {
                using (ScpClient c = new ScpClient(host, Convert.ToInt32("0" + port), username, password))
                {
                    c.Connect();
                    foreach (var file in files)
                    {
                        Console.WriteLine("Downloading {0} ,from: {1}", file, host);
                        if (File.Exists(file.DestinFile))
                        {
                            File.Delete(file.DestinFile);
                            Thread.Sleep(2000);
                        }                        
                        c.Download(file.SourceFile, new FileInfo(file.DestinFile ?? ""));
                        Thread.Sleep(5000);
                    }

                    c.Disconnect();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }


}
