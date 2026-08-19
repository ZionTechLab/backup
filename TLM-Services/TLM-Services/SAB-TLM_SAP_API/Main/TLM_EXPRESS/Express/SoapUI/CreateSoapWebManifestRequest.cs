using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Express.UI.SoapUI
{
    public class CreateSoapWebManifestRequest
    {
        public CreateSoapWebManifestRequest()
        {

        }

        public XmlDocument CreateRequstFomDestinationCountry(string FDate, string TDate, string LocalCountryCode)
        {
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:v1=""http://fedex.com/ws/getmanifest/v1"">
               <soapenv:Header/>
               <soapenv:Body>
                  <v1:GetManifestRequest>
                     <v1:WebAuthenticationDetail>
                           <v1:UserCredential>
                           <v1:Key>2MFx55sjxNDgLhrP</v1:Key>
                           <v1:Password>nX1zN9oaPSx1rSGpY1pZgCsNc</v1:Password>
                        </v1:UserCredential>
                     </v1:WebAuthenticationDetail>
                     <v1:Version>
                        <v1:ServiceId>getmanifestservice</v1:ServiceId>
                        <v1:Major>1</v1:Major>
                        <v1:Intermediate>0</v1:Intermediate>
                        <v1:Minor>0</v1:Minor>
                     </v1:Version>
                     <v1:ClientId>OMIMP00001</v1:ClientId>
                     <v1:OutputFormat>XML</v1:OutputFormat>
                     <v1:ReturnInResponseIfPossible>true</v1:ReturnInResponseIfPossible>
                     <v1:SearchByShipDt>true</v1:SearchByShipDt>
                     <v1:DateRangeBeginInGMT>2018-11-05</v1:DateRangeBeginInGMT>
                     <v1:DateRangeEndInGMT>2018-11-12</v1:DateRangeEndInGMT>
                     <v1:Filters>
                        <v1:DestinationCountryCd>OM</v1:DestinationCountryCd>
                     </v1:Filters>
                 </v1:GetManifestRequest>
               </soapenv:Body>
            </soapenv:Envelope>");

            try
            {
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(soapEnvelopeXml.NameTable);
                nsMgr.AddNamespace("v1", "http://fedex.com/ws/getmanifest/v1");

                XmlNode DateRangeBeginInGMTseverityNode = soapEnvelopeXml.SelectSingleNode("//v1:DateRangeBeginInGMT/text()", nsMgr);
                DateRangeBeginInGMTseverityNode.Value = FDate;

                XmlNode DateRangeEndInGMTseverityNode = soapEnvelopeXml.SelectSingleNode("//v1:DateRangeEndInGMT/text()", nsMgr);
                DateRangeEndInGMTseverityNode.Value = TDate;

                //XmlNode DestinationCountryCdseverityNode = soapEnvelopeXml.SelectSingleNode("//v1:DestinationCountryCd/text()", nsMgr);
                //DestinationCountryCdseverityNode.Value = LocalCountryCode;


            }
            catch (Exception ex)
            {

                throw;
            }

            //try
            //{
            //XmlNodeList XmlNode = soapEnvelopeXml.GetElementsByTagName("v1:GetManifestRequest");
            //foreach (XmlNode aDateNode in XmlNode)
            //{
            //    XmlAttribute DateRangeBeginInGMT = aDateNode.Attributes["v1:DateRangeBeginInGMT"];
            //    aDateNode.InnerText = FDate;

            //    XmlAttribute DateRangeEndInGMT = aDateNode.Attributes["v1:DateRangeEndInGMT"];
            //    aDateNode.InnerText = TDate;

            //    XmlNodeList nodeFilter = soapEnvelopeXml.GetElementsByTagName("v1:GetManifestRequest");
            //    foreach (XmlNode aFilterNode in nodeFilter)
            //    {
            //        XmlAttribute DestinationCountryCd = aDateNode.Attributes["v1:DestinationCountryCd"];
            //        aDateNode.InnerText = LocalCountryCode;
            //    }

            //   }
            //    }
            //catch (Exception ex)
            //{
            //    throw;
            //}

            return soapEnvelopeXml;
        }

        public XmlDocument CreateRequstFomCons(string FDate, string TDate, string LocalCountryCode,string ConsNo)
        {
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" 
                xmlns:v1 =""http://fedex.com/ws/getmanifest/v1"">
                <soapenv:Header/>
                <soapenv:Body>
                  <v1:GetManifestRequest>
                     <v1:WebAuthenticationDetail>
                        <v1:UserCredential>
                           <v1:Key>2MFx55sjxNDgLhrP</v1:Key >
                           <v1:Password>nX1zN9oaPSx1rSGpY1pZgCsNc</v1:Password>
                        </v1:UserCredential>
                     </v1:WebAuthenticationDetail>
                     <v1:Version>
                        <v1:ServiceId>getmanifestservice</v1:ServiceId>
                        <v1:Major>1</v1:Major>
                        <v1:Intermediate>0</v1:Intermediate>
                        <v1:Minor>0</v1:Minor>
                     </v1:Version>
                     <v1:ClientId>LKWSC00005</v1:ClientId>
                     <v1:OutputFormat>XML</v1:OutputFormat>
                     <v1:ReturnInResponseIfPossible>true</v1:ReturnInResponseIfPossible>
                     <v1:SearchByShipDt>true</v1:SearchByShipDt>
                     <v1:DateRangeBeginInGMT>2018-10-17</v1:DateRangeBeginInGMT>
                     <v1:DateRangeEndInGMT>2018-10-19</v1:DateRangeEndInGMT>
                     <v1:Filters>
                        <v1:DestinationCountryCd>LK</v1:DestinationCountryCd>
                        <v1:ConsNumber>808393096748</v1:ConsNumber>
                     </v1:Filters>
                  </v1:GetManifestRequest>
               </soapenv:Body>
            </soapenv:Envelope>");

            XmlNode nodeBody = soapEnvelopeXml.SelectSingleNode("soapenv:Body");
            XmlNode nodeRequest = nodeBody.SelectSingleNode("v1:GetManifestRequest");
            foreach (XmlNode aDateNode in nodeRequest)
            {
                XmlAttribute DateRangeBeginInGMT = aDateNode.Attributes["v1:DateRangeBeginInGMT"];
                aDateNode.InnerText = FDate;

                XmlAttribute DateRangeEndInGMT = aDateNode.Attributes["v1:DateRangeEndInGMT"];
                aDateNode.InnerText = TDate;

                XmlNode nodeFilter = soapEnvelopeXml.SelectSingleNode("v1:Filters");

                foreach (XmlNode aFilterNode in nodeRequest)
                {
                    XmlAttribute DestinationCountryCd = aFilterNode.Attributes["v1:DestinationCountryCd"];
                    aFilterNode.InnerText = LocalCountryCode;

                    XmlAttribute ConsNumber = aFilterNode.Attributes["v1:ConsNumber"];
                    aFilterNode.InnerText = ConsNo;
                }
            }

            return soapEnvelopeXml;
        }
    }
}
   

