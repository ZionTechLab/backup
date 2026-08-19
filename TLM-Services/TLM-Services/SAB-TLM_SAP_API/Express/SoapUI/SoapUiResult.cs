using Express.View.Domain.SoapUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Express.UI.SoapUI
{
    public class SoapUiResult
    {
        public SoapUiResult()
        {

        }

        //private string LocalCountryCode = "";
        //private string FDate = "";
        //private string TDate = "";
        //private string ConsNo = "";

        //public SoapUiResult(string _LocalCountryCode,string _FDate,string _TDate, string _ConsNo)
        //{
        //    this.LocalCountryCode = _LocalCountryCode;
        //    this.FDate = _FDate;
        //    this.TDate = _TDate;
        //    this.ConsNo = _ConsNo;
        //}

        public List<XmlReadWebManifestDomain> ReadXmlLits(XmlDocument XMlDoc)
        {
            List<XmlReadWebManifestDomain> XmlReadAirwayBillsList = new List<XmlReadWebManifestDomain>();
            XmlReadAirwayBillsList.Clear();



            try
            {
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(XMlDoc.NameTable);
                nsMgr.AddNamespace("v1", "http://fedex.com/ws/getmanifest/v1");

                //XmlNode item_SoapContaint = XMlDoc.SelectSingleNode("SOAP-ENV:Envelope");
                //XmlNode item_SoapEnalopBody = item_SoapContaint.SelectSingleNode("SOAP-ENV:Body");
                //XmlNode item_GetManifestResponce = item_SoapEnalopBody.SelectSingleNode("GetManifestResponse");
                //XmlNode item_GetXmlManifest = item_GetManifestResponce.SelectSingleNode("XmlManifest");

                XmlNodeList AirwayBillsList = XMlDoc.SelectNodes("//v1:AirwayBills", nsMgr);



                //XMlDoc.Descendants().Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
                //xml = doc.ToString();
                int i = 0;
                foreach (XmlNode item_AirwayBills in AirwayBillsList)
                {
                    if(i==142)
                    {

                    }
                    XmlReadWebManifestDomain XmlReadAirwayBills_Item = new XmlReadWebManifestDomain();
                    XmlReadAirwayBills_Item.TransMode = item_AirwayBills["Trans"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.TrackNo = item_AirwayBills["TrackNbr"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    try
                    {
                        XmlReadAirwayBills_Item.MAWBNo = item_AirwayBills["MAWB"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    }
                    catch (Exception)
                    {

                        XmlReadAirwayBills_Item.MAWBNo = "";
                    }

                    try
                    {
                        XmlReadAirwayBills_Item.Child = item_AirwayBills["Child"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    }
                    catch (Exception)
                    {

                        XmlReadAirwayBills_Item.Child = "";
                    }
                    XmlReadAirwayBills_Item.UniqueID = item_AirwayBills["UniqueID"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Orig = item_AirwayBills["Orig"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Dest = item_AirwayBills["Dest"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.ShipDt = item_AirwayBills["ShipDt"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");

                    XmlDocument ShiperDoc = new XmlDocument();
                    ShiperDoc.LoadXml("<root>"+item_AirwayBills.InnerXml+"</root>");
                    XmlNamespaceManager ShipernsMgr = new XmlNamespaceManager(ShiperDoc.NameTable);
                    ShipernsMgr.AddNamespace("v2", "http://fedex.com/ws/getmanifest/v1");

                    XmlNode item_Shipper = ShiperDoc.SelectSingleNode("//v2:Shipper", ShipernsMgr);
                    XmlNode item_Consignee = ShiperDoc.SelectSingleNode("//v2:Consignee", ShipernsMgr);

                    if (item_Shipper != null)
                    {


                        try
                        {
                                XmlReadAirwayBills_Item.SenAccount = item_Shipper["Acct"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {

                            XmlReadAirwayBills_Item.SenAccount = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenName = item_Shipper["Name"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenName = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenCompany = item_Shipper["Company"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenCompany = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenAddr1 = item_Shipper["Add1"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenAddr1 = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenAddr2 = item_Shipper["Add2"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenAddr2 = "";
                        }

                        XmlReadAirwayBills_Item.SenCity = 0;

                        try
                        {
                                XmlReadAirwayBills_Item.SenCityN = item_Shipper["City"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenCityN = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenState = item_Shipper["State"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenState = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenCountry = item_Shipper["Cntry"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenCountry = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenZip = item_Shipper["Postal"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenZip = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.SenPhone = item_Shipper["Phone"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.SenPhone = "";
                        }
                    }

                    if (item_Consignee != null)
                    {
                        try
                        {
                                XmlReadAirwayBills_Item.RecAccount = item_Consignee["Acct"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecAccount = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.RecName = item_Consignee["Name"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecName = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.RecCompany = item_Consignee["Company"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecCompany = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.RecAddr1 = item_Consignee["Add1"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecAddr1 = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.RecAddr2 = item_Consignee["Add2"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecAddr2 = "";
                        }
                        XmlReadAirwayBills_Item.RecCity = 0;
                        try
                        {
                                XmlReadAirwayBills_Item.RecCityN = item_Consignee["City"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecCityN = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.RecState = item_Consignee["State"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecState = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.RecCountry = item_Consignee["Cntry"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecCountry = "";
                        }

                        try
                        {
                                XmlReadAirwayBills_Item.RecZip = item_Consignee["Postal"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecZip = "";
                        }
                        try
                        {
                                XmlReadAirwayBills_Item.RecPhone = item_Consignee["Phone"].InnerText.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                        catch (Exception)
                        {
                            XmlReadAirwayBills_Item.RecPhone = "";
                        }
                    }
                    XmlReadAirwayBills_Item.Service = item_AirwayBills["Service"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Base = item_AirwayBills["Base"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.PackTyp = item_AirwayBills["PackTyp"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Form = item_AirwayBills["Form"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.DangGoods = item_AirwayBills["DangGoods"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");

                    XmlReadAirwayBills_Item.Dutiable = item_AirwayBills["Dutiable"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.OrigCntry = item_AirwayBills["OrigCntry"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.ExportCntry = item_AirwayBills["ExportCntry"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Currrency = item_AirwayBills["Currrency"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Value = item_AirwayBills["Value"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.FreightChg = item_AirwayBills["FreightChg"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Desc = item_AirwayBills["Desc"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.HandlingQty = item_AirwayBills["HandlingQty"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Pieces = item_AirwayBills["Pieces"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.Weight = item_AirwayBills["Weight"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");

                    XmlReadAirwayBills_Item.BillTo = item_AirwayBills["BillTo"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.BillDty = item_AirwayBills["BillDty"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.DelDt = item_AirwayBills["DelDt"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.CommitDt = item_AirwayBills["CommitDt"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.ConsNbr = item_AirwayBills["ConsNbr"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.MPSTyp = item_AirwayBills["MPSTyp"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.CommodityDesc = item_AirwayBills["CommodityDesc"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.HarmonizedCd = item_AirwayBills["HarmonizedCd"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBills_Item.BillToAcct = item_AirwayBills["BillToAcct"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    XmlReadAirwayBillsList.Add(XmlReadAirwayBills_Item);
                    i++;

                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return XmlReadAirwayBillsList;
        }
    }
}
