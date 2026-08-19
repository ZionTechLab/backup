using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Express.UI.SoapUI
{
    public class GetXmlResult
    {
        public GetXmlResult()
        {

        }

        public XmlDocument GetXmlFormSoap(XmlDocument SoapXmlDocument)
        {
            HttpWebRequest request = CreateWebManifestWebRequest();
            XmlDocument soapEnvelopeXmlresult = new XmlDocument();

            using (Stream stream = request.GetRequestStream())
            {
                SoapXmlDocument.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    //XDocument doc = XDocument.Parse(soapResult, LoadOptions.PreserveWhitespace);
                    //doc.Descendants().Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
                    //soapEnvelopeXmlresult = doc.ToXmlDocument();
                    //xml = doc.ToString();
                    soapEnvelopeXmlresult.LoadXml(soapResult);
                }
            }

            return soapEnvelopeXmlresult;
        }

        public static HttpWebRequest CreateWebManifestWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://ws.fedex.com:443/web-services/getManifest");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}
