using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;

namespace KuhlektFTP.SFTP
{
    public static class Uploads
    {
        public static void UploadFiles(string host, string username, string password, List<DownSourceDestin> files)
        {
            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();
                foreach (var file in files)
                {                 
                    using (var uplfileStream = System.IO.File.OpenRead(file.SourceFile??""))
                    {
                        Console.WriteLine("UPLOADING");
                        Console.WriteLine(file.SourceFile);
                        sftp.UploadFile(uplfileStream, file.DestinFile??"", true);
                    }
                }
                sftp.Disconnect();
            }
        }
    }
}
