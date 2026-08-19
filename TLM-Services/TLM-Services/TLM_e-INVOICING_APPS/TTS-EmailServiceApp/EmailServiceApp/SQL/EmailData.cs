using Dapper;
using EmailServiceApp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.SQL
{
    public class EmailData
    {
        string conString = null;
        public EmailData()
        {
            conString = System.Configuration.ConfigurationManager.ConnectionStrings["EmailConnectionString"].ConnectionString; ;
        }
        public List<EmailListDomain> GetEmailList()
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [AutoID],[InvoiceNo],[Area],[NewEmail],[ReSend],[OrgCode],[DocType],[CMPY],[AgncyCode],[UserId] FROM [Express].[TrEmail] where [NewEmail]='Y' ", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<EmailListDomain> EmailList = new List<EmailListDomain>();
                        while (reader.Read())
                        {
                            EmailListDomain emailItem = new EmailListDomain();
                            emailItem.AutoID = reader.GetInt32(0);
                            emailItem.InvoiceNo = decimal.Parse(reader.GetValue(1).ToString());
                            emailItem.Area = reader.GetValue(2).ToString();
                            emailItem.NewEmail = reader.GetValue(3).ToString();
                            emailItem.ReSend = reader.GetValue(4).ToString();
                            emailItem.OrgCode = int.Parse(reader.GetValue(5).ToString());
                            emailItem.DocType = reader.GetValue(6).ToString();
                            emailItem.CMPY = int.Parse(reader.GetValue(7).ToString() == null ? "0" : reader.GetValue(7).ToString());
                            emailItem.AgncyCode = int.Parse(reader.GetValue(8).ToString() == null ? "0" : reader.GetValue(8).ToString());
                            emailItem.UserId = int.Parse(reader.GetValue(9).ToString() == null ? "0" : reader.GetValue(9).ToString());
                            EmailList.Add(emailItem);
                        }
                        return EmailList;
                    }
                }
            }
        }

        public string GetCustomerEmail(int OrgCode)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                string result = "";
                using (SqlCommand command = new SqlCommand("select [OrgDelEmail] from  [SharedMain].[RefOrganization] where [Deleted]='False' and [OrgActive]='Y' and [OrgCode]=" + OrgCode, connection))
                {
                    var firstColumn = command.ExecuteScalar();
                    if (firstColumn != null)
                    {
                        result =  ""+firstColumn;
                    }
                }
                return result;
            }

        }

        //public List<TaxInvoiceReportDomainView> GetTaxInvoiceResulatData(int CompanyID, int AgencyID, string InvoiceNo, int UserID)
        //{
        //    using (SqlConnection connection = new SqlConnection(conString))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("[Express].[TLM_RepInvoiceDutyClearence]", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add(new SqlParameter("@companyID", CompanyID));
        //            command.Parameters.Add(new SqlParameter("@agencyCode", AgencyID));
        //            command.Parameters.Add(new SqlParameter("@invoiceNo", InvoiceNo));
        //            command.Parameters.Add(new SqlParameter("@userid", UserID));
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                List<TaxInvoiceReportDomainView> TaxInvoiceList = new List<TaxInvoiceReportDomainView>();
        //                while (reader.Read())
        //                {
        //                    TaxInvoiceReportDomainView TaxInvoiceItem = new TaxInvoiceReportDomainView();
        //                    TaxInvoiceItem.GroupID = reader.GetInt32(0);
        //                    TaxInvoiceItem.CompanyID = reader.GetInt32(1);
        //                    TaxInvoiceItem.DocReference = reader.GetValue(2).ToString();
        //                    TaxInvoiceItem.RefNo1 = reader.GetValue(3).ToString();
        //                    TaxInvoiceItem.RefNo2 = reader.GetValue(4).ToString();
        //                    TaxInvoiceItem.RefNo3 = reader.GetValue(5).ToString();
        //                    TaxInvoiceItem.DocDate = reader.GetDateTime(6);

        //                    TaxInvoiceItem.JobNo = decimal.Parse(reader.GetValue(7).ToString());
        //                    TaxInvoiceItem.InvNo = reader.GetValue(8).ToString();
        //                    TaxInvoiceItem.OrgName = reader.GetValue(9).ToString();

        //                    TaxInvoiceItem.OrgContact = reader.GetValue(10).ToString();
        //                    TaxInvoiceItem.OrgCountry = reader.GetValue(11).ToString();
        //                    TaxInvoiceItem.OrgAddr1 = reader.GetValue(12).ToString();
        //                    TaxInvoiceItem.OrgAddr2 = reader.GetValue(13).ToString();
        //                    TaxInvoiceItem.OrgCity = reader.GetValue(14).ToString();
        //                    TaxInvoiceItem.ChargeCode = reader.GetValue(15).ToString();

        //                    TaxInvoiceItem.ChargeDesc = reader.GetValue(16).ToString();

        //                    TaxInvoiceItem.ConvRate = reader.GetDecimal(17);
        //                    TaxInvoiceItem.LC = reader.GetValue(18).ToString();
        //                    TaxInvoiceItem.FC = reader.GetValue(19).ToString();
        //                    TaxInvoiceItem.LineAmount = reader.GetDecimal(20);
        //                    TaxInvoiceItem.LineTaxTotal = reader.GetDecimal(21);

        //                    TaxInvoiceItem.LineTotalAmount = reader.GetDecimal(22);
        //                    TaxInvoiceItem.DocType = reader.GetValue(23).ToString();
        //                    TaxInvoiceItem.Remarks = reader.GetValue(24).ToString();
        //                    TaxInvoiceItem.CustomVal = reader.GetDecimal(25);
        //                    TaxInvoiceItem.TAX1 = reader.GetDecimal(26);
        //                    TaxInvoiceItem.TAX2 = reader.GetDecimal(27);

        //                    TaxInvoiceItem.TAX3 = reader.GetDecimal(28);
        //                    TaxInvoiceItem.SVATNO = reader.GetValue(29).ToString();
        //                    TaxInvoiceItem.VATNO = reader.GetValue(30).ToString();
        //                    TaxInvoiceItem.Detain = reader.GetValue(31).ToString();

        //                    TaxInvoiceItem.GoodDescp = reader.GetValue(32).ToString();
        //                    TaxInvoiceItem.VALFC = reader.GetDecimal(33);
        //                    TaxInvoiceItem.BillOrgCountry = reader.GetValue(34).ToString();
        //                    TaxInvoiceItem.PayMode = reader.GetValue(35).ToString();

        //                    TaxInvoiceItem.SenRefNotes = reader.GetValue(36).ToString();
        //                    TaxInvoiceItem.PrintUser = reader.GetValue(37).ToString();
        //                    TaxInvoiceItem.ManCurrency = reader.GetValue(38).ToString();
        //                    TaxInvoiceItem.CusdecNo = reader.GetValue(40).ToString();

        //                    TaxInvoiceList.Add(TaxInvoiceItem);
        //                }

        //                return TaxInvoiceList;
        //            }

        //        }
        //    }
        //}

        public IList<TaxInvoiceReportDomainView> GetTaxInvoiceResulatData(int CompanyID, int AgencyID, string InvoiceNo, int UserID)
        {
            using (IDbConnection connection = new SqlConnection(conString))
            {
                var output = connection.Query<TaxInvoiceReportDomainView>($"[Express].[TLM_RepInvoiceDutyClearence] @companyID, @agencyCode, @invoiceNo, @userid", new { companyID = CompanyID, agencyCode= AgencyID , invoiceNo = InvoiceNo , userid = UserID }).ToList();
                return output;
            }
        }

        public EmailConfigDomainView GetEmailConfiguration(int configID ,int companyID)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[Project].[TLMV2_GetEmailConfigBullk]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", configID));
                    command.Parameters.Add(new SqlParameter("@companyID", companyID));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        EmailConfigDomainView item = new EmailConfigDomainView();
                        while (reader.Read())
                        {
                            //item = new EmailConfigDomainView();
                            item.SmtpServerN  = reader.GetValue(1).ToString();
                            item.PortCode = reader.GetInt32(2);
                            item.UserName = reader.GetValue(3).ToString();
                            item.Password = reader.GetValue(4).ToString();
                        }

                        return item;
                    }
                }
            }
        }
        public IList<CompanyReportDomainView> GetCompany(int companyID)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [GroupID],[CompID],[CompNameSort],[CompName],[Address1],[Address2],[Logo],[Email],[Fax],[Telephone],[TaxRegNo],[ReportPath] FROM [Project].[CfgCompany] Where [CompID]=" + companyID, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<CompanyReportDomainView> CompanyList = new List<CompanyReportDomainView>();
                        while (reader.Read())
                        {
                            CompanyReportDomainView emailItem = new CompanyReportDomainView();
                            emailItem.GroupID = reader.GetInt32(0);
                            emailItem.CompanyID = reader.GetInt32(1);
                            emailItem.CompanySortName = reader.GetValue(2)==null?"":reader.GetValue(2).ToString();
                            emailItem.CompanyName = reader.GetValue(3) == null?"": reader.GetValue(3).ToString();
                            emailItem.Address1 = reader.GetValue(4) == null ? "" : reader.GetValue(4).ToString();
                            emailItem.Address2 = reader.GetValue(5) == null ? "" : reader.GetValue(5).ToString();
                            emailItem.Email = reader.GetValue(7) == null ? "" : reader.GetValue(7).ToString();
                            emailItem.Fax = reader.GetValue(8) == null ? "" : reader.GetValue(8).ToString();
                            emailItem.Telephone = reader.GetValue(9) == null ? "" : reader.GetValue(9).ToString();
                            emailItem.TaxRegNo = reader.GetValue(10) == null ? "" : reader.GetValue(10).ToString();
                            emailItem.ReportPath = reader.GetValue(11) == null ? "" : reader.GetValue(11).ToString();


                            CompanyList.Add(emailItem);
                        }
                        return CompanyList;
                    }
                }
            }
        }

        public List<FrtInvoiceReportDomainView> GetFrtInvoiceResulatData(int GroupId, int CompanyID, int AgencyID, string InvoiceNo,string InvType)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[Express].[USP_RepInvoiceBulkPrintFrt]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@groupID", GroupId));
                    command.Parameters.Add(new SqlParameter("@companyID", CompanyID));
                    command.Parameters.Add(new SqlParameter("@agencyCode", AgencyID));
                    command.Parameters.Add(new SqlParameter("@InvNumFrom", InvoiceNo));
                    command.Parameters.Add(new SqlParameter("@InvNumTo", InvoiceNo));
                    command.Parameters.Add(new SqlParameter("@InvType", InvType));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<FrtInvoiceReportDomainView> FrtInvoiceList = new List<FrtInvoiceReportDomainView>();
                        while (reader.Read())
                        {
                            FrtInvoiceReportDomainView FrtInvoiceItem = new FrtInvoiceReportDomainView();
                            FrtInvoiceItem.RowID = reader.GetInt32(0);
                            FrtInvoiceItem.GroupID = reader.GetInt32(2);
                            FrtInvoiceItem.CompanyID = reader.GetInt32(3);
                            FrtInvoiceItem.InvDate = reader.GetDateTime(4);
                            FrtInvoiceItem.TransDate = reader.GetDateTime(5);
                            FrtInvoiceItem.ShipDate = reader.GetDateTime(6);
                            FrtInvoiceItem.InvNo = reader.GetValue(7).ToString();
                            FrtInvoiceItem.OrgCode = reader.GetInt32(9);
                            FrtInvoiceItem.OrgName = reader.GetValue(10).ToString();
                            FrtInvoiceItem.OrgCountry = reader.GetValue(11).ToString();
                            FrtInvoiceItem.OrgAddr1 = reader.GetValue(12).ToString();
                            FrtInvoiceItem.OrgAddr2 = reader.GetValue(13).ToString();
                            FrtInvoiceItem.OrgCity = reader.GetValue(14).ToString();
                            FrtInvoiceItem.ChargeCode = reader.GetValue(15).ToString();
                            FrtInvoiceItem.ChargeDesc = reader.GetValue(16).ToString();
                            FrtInvoiceItem.ConvRate = decimal.Parse(reader.GetValue(17).ToString());
                            FrtInvoiceItem.LocalCurrency = reader.GetValue(18).ToString();
                            FrtInvoiceItem.ForiengCurrency = reader.GetValue(19).ToString();
                            FrtInvoiceItem.LineLCAmount = decimal.Parse(reader.GetValue(20).ToString());
                            FrtInvoiceItem.LineFCAmount = decimal.Parse(reader.GetValue(21).ToString());
                            FrtInvoiceItem.DebtorLCCurrency = reader.GetValue(22).ToString();
                            FrtInvoiceItem.DebtorFLCurrency = reader.GetValue(23).ToString();
                            FrtInvoiceItem.DebtorFCTotAmount = decimal.Parse(reader.GetValue(24).ToString());
                            FrtInvoiceItem.DebtorLCTotAmount = decimal.Parse(reader.GetValue(25).ToString());
                            FrtInvoiceItem.Remarks = reader.GetValue(27).ToString();
                            FrtInvoiceItem.AgnAWBNo = reader.GetValue(28).ToString();
                            FrtInvoiceItem.SvcType = reader.GetValue(29).ToString();
                            FrtInvoiceItem.PackType = reader.GetValue(30).ToString();
                            FrtInvoiceItem.TotPkgs = reader.GetInt32(31);
                            FrtInvoiceItem.TotWgt = decimal.Parse(reader.GetValue(32).ToString());
                            FrtInvoiceItem.WgtU = reader.GetValue(33).ToString();
                            FrtInvoiceItem.BillWgt = decimal.Parse(reader.GetValue(34).ToString());
                            FrtInvoiceItem.BillWgtU = reader.GetValue(35).ToString();
                            FrtInvoiceItem.DimVol = decimal.Parse(reader.GetValue(36).ToString());
                            FrtInvoiceItem.RexWgt = decimal.Parse(reader.GetValue(37).ToString());
                            FrtInvoiceItem.DocNdoc = reader.GetValue(38).ToString();
                            FrtInvoiceItem.FuelShgPer = decimal.Parse(reader.GetValue(39).ToString());
                            FrtInvoiceItem.Shipper = reader.GetValue(40).ToString();
                            FrtInvoiceItem.Consingnee = reader.GetValue(41).ToString();
                            FrtInvoiceItem.OrginCounty = reader.GetValue(42).ToString();
                            FrtInvoiceItem.DestCountry = reader.GetValue(43).ToString();
                            FrtInvoiceItem.TaxCode1Val = decimal.Parse(reader.GetValue(44).ToString());
                            FrtInvoiceItem.TaxCode2Val = decimal.Parse(reader.GetValue(45).ToString());
                            FrtInvoiceItem.LineTaxCode2Value = decimal.Parse(reader.GetValue(46).ToString());
                            FrtInvoiceItem.GoodDescription = reader.GetValue(48).ToString();
                            FrtInvoiceItem.RexVol = decimal.Parse(reader.GetValue(49).ToString());
                            FrtInvoiceItem.PackName = reader.GetValue(50).ToString();
                            FrtInvoiceItem.AgncyID = reader.GetValue(51).ToString();
                            FrtInvoiceItem.DocType = reader.GetValue(52).ToString();
                            FrtInvoiceItem.PayMode = reader.GetValue(53).ToString();
                            FrtInvoiceItem.InvGroup = reader.GetValue(54).ToString();
                            FrtInvoiceList.Add(FrtInvoiceItem);
                        }

                        return FrtInvoiceList;
                    }

                }
            }
        }

        public void UpdateEmailLog(string SendEmail,string ReciveEmail,string ErrorStatus,string isResend,string Ststus,int RecodeNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    string result = "";
                    //string quu =;
                    using (SqlCommand command = new SqlCommand("update [Express].[TrEmail] set [SendEmail]= '" + SendEmail + "', [ReceivedEmail]= " + "'" + ReciveEmail + "'" + " ,[Status]= '" + Ststus + "',[ReSend]= '" + Ststus + "',[NewEmail]= '" + isResend + "',[UserDate]= GETDATE() , [ErrorStatus]=' " + ErrorStatus + "' where AutoID =" + RecodeNo + " ", connection))
                    {
                        var firstColumn = command.ExecuteScalar();
                        if (firstColumn != null)
                        {
                            result = firstColumn.ToString();
                        }
                    }
                    // return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
