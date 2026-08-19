// See https://aka.ms/new-console-template for more information

// Get Folders Require QR read
// Filter Files Pending Scan for each 
// Loop QR read set pdf

using pdfQRReader;
using System.Configuration;

FilesData data = new FilesData();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
string filepath = ConfigurationManager.AppSettings["UploadFilePath"].ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
QRRead reader = new QRRead();
List<FileQRDataDomainView>? pending = data.GetPendingList(".pdf", "QR");
if (pending != null && pending.Count > 0)
{
    foreach (FileQRDataDomainView file in pending)
    {
        string qrdata = reader.ScanQR(filepath + @"eDoc\" + file.StoreFileName);
        Console.WriteLine(qrdata);
        file.QRData = qrdata;
    }
    data.SaveQRScanData(pending, "QR");
}
// Add read properties to file
