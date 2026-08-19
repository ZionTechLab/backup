using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfQRReader
{
    public class FileQRDataDomainView
    {
        public int SeqId { get; set; }
        public int FilesId { get; set; }
        public string StoreFileName { get; set; }
        public string QRData { get; set; }
    }
    public class ResponseMessage
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
