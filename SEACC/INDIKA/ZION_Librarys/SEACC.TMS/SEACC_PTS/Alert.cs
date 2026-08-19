using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Mail;
using System.Collections;
using System.IO;
using System.Net;
using SEACC_PTS.NmsEnum;
using SEACC_PTS.NmsLogic;
//using System.Text;

namespace SEACC_PTS
{
    public enum fontStyle
    {
        Bold, italic, underline, bold_italic, bold_underline, NA
    }
    public enum LineType
    {
        H1, H2, H3, H4, H5, H6, Footer1, Footer2, Line1, Line2, Space, Detail1, Detail2, DataTable, DIV, TableColomn1, TableColomn2, TableColomn3, TableColomn4, P, P_heading, Grid
    }
    public enum ElementAlign
    {
        Left, Right, Center, Inherit, NA
    }
    class Alert
    {

        public static bool SendMail(ArrayList sMailTo, ArrayList sFilePaths, string Subject, string Body, bool bShowMessage)
        {
            bool bSuccess = false;
            try
            {
                MailAddress From = new MailAddress(settings.AutoAlert_SenderAddress, "Digiteq Time Management System");
                MailMessage message = new MailMessage();
                message.From = From;

                foreach (string ToAdd in sMailTo)
                {
                    MailAddress to = new MailAddress(ToAdd.ToString());
                    message.To.Add(to);
                }

                message.Subject = Subject;
                message.Body = Body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = settings.AutoAlert_Host;
                smtp.Port = settings.AutoAlert_port;
                smtp.EnableSsl = settings.AutoAlert_SSLEnabled;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(From.Address, settings.AutoAlert_PassWord);

                foreach (String sFilpath in sFilePaths)
                {
                    Attachment att = new Attachment(sFilpath);
                    message.Attachments.Add(att);
                }

                smtp.Send(message);
                if (bShowMessage)
                {
                    System.Windows.Forms.MessageBox.Show("Email sent successfully!");

                } bSuccess = true;
            }

            catch (Exception ex)
            {
                bSuccess = false;
                if (bShowMessage)
                    System.Windows.Forms.MessageBox.Show("Failed to send message because " + ex.Message);
            }


            return bSuccess;
        }

        public static bool SendMailHTML(string sUserID, ArrayList sMailTo, ArrayList sFilePaths, string Subject, string Body, bool bShowMessage)
        {
            bool bSuccess = false;
            // tbl_utlEmailConfig mail = tbl_utlEmailConfig.Select(sUserID);
            //  if (mail != null)
            {
                try
                {


                    MailAddress From = new MailAddress(settings.AutoAlert_SenderAddress, "Digiteq Time Management System");
                    MailMessage message = new MailMessage();
                    message.IsBodyHtml = true;
                    message.From = From;

                    foreach (string ToAdd in sMailTo)
                    {
                        if (ToAdd !="")
                        {
                            MailAddress to = new MailAddress(ToAdd.ToString());
                            message.To.Add(to); 
                        }
                    }

                    message.Subject = Subject;
                    message.Body = Body;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = settings.AutoAlert_Host;
                    smtp.Port = settings.AutoAlert_port;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(From.Address, settings.AutoAlert_PassWord);

                    foreach (String sFilpath in sFilePaths)
                    {
                        Attachment att = new Attachment(sFilpath);
                        message.Attachments.Add(att);
                    }

                    smtp.Send(message);
                    if (bShowMessage)
                        System.Windows.Forms.MessageBox.Show("Email sent successfully!");

                    bSuccess = true;

                    try
                    {
                        message.Dispose();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message, "Memory Dispose Problome", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                   
                }
                    

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    bSuccess = false;
                    if (bShowMessage)
                        System.Windows.Forms.MessageBox.Show("Failed to send message because " + ex.Message);
                }
            }
            return bSuccess;
        }

        public static string CreateEmailBody(List<emailLine> list1, EmailLineformating formating, DataTable dtHeader, DataTable dtDetail, clsEnum.Email_Alignment[] Alignment)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div style=\" \">");
            foreach (emailLine l1 in list1)
            {
                switch (l1.LineType)
                {
                    case LineType.H1:
                        {
                            sb.Append("<H1 style=\"font-weight: 100; color:#333333; font: 25px Arial, serif;\">" + l1.Heading + "</H1>");
                            break;
                        }
                    case LineType.H2:
                        {
                            sb.Append("<H1 style=\" color:#333333; font: 15px/10px Arial, serif;\">" + l1.Heading + "</H1>");

                            break;
                        }
                    case LineType.H3:
                        {
                            sb.Append(CreateEmailLine(l1, formating.H3));
                            break;
                        }
                    case LineType.H4:
                        {
                            sb.Append(CreateEmailLine(l1, formating.H4));
                            break;
                        }
                    case LineType.H5:
                        {
                            sb.Append(CreateEmailLine(l1, formating.H5));
                            break;
                        }
                    case LineType.H6:
                        {
                            sb.Append(CreateEmailLine(l1, formating.H6));
                            break;
                        }
                    case LineType.Line1:
                        {
                            sb.Append("<HR>");
                            break;
                        }
                    case LineType.Line2:
                        {
                            sb.Append("<HR>");
                            break;
                        }
                    case LineType.Space:
                        {
                            l1.LineType = LineType.DIV;
                            sb.Append(CreateEmailLine(l1, formating.Space));
                            break;
                        }
                    case LineType.Footer1:
                        {
                            l1.LineType = LineType.DIV;
                            sb.Append(CreateEmailLine(l1, formating.HF));
                            break;
                        }
                    case LineType.Detail2:
                        {
                            sb.Append(CreateEmailLine(l1, formating.Div1));
                            break;
                        }
                    case LineType.DataTable:
                        {
                            #region Details
                            sb.Append(" <table  cellspacing=\"0\" cellpadding=\"0\"  border=\"1px\" style=\"border-bottom:hidden; border-left:hidden; border-color:#333333; font-size:10px; margin-bottom:8px;\" >");
                            sb.Append("<tr>");
                            foreach (DataColumn dc in l1.Table.Columns)
                            {
                                sb.Append("<th style=\"border-top:hidden; border-right:hidden; padding:4px;  color:#5C0000; font-weight:bold;\">" + dc.ColumnName + "</th>");
                            }
                            sb.Append("</tr>");

                            foreach (DataRow dr in l1.Table.Rows)
                            {
                                sb.Append("<tr>");
                                foreach (DataColumn column in l1.Table.Columns)
                                {
                                    if (l1.TableFormating != null)
                                    {
                                        //string sStyle = "";
                                        //foreach (emailLine l2 in l1.TableFormating)
                                        //{
                                        //    if (dr[column].ToString() == l2.Heading)
                                        //    { 

                                        //    }
                                        //}
                                    }
                                    sb.Append("<td style=\"border-top:hidden; border-right:hidden; padding:4px;\">" + dr[column].ToString() + "</td>");
                                }
                                sb.Append("</tr>");
                            }
                            sb.Append("</table>");
                            #endregion
                            break;
                        }
                    case LineType.P:
                        {
                            sb.Append(CreateParagraph(l1, formating.P, LineType.P));
                            break;
                        }
                    case LineType.P_heading:
                        {
                            sb.Append(CreateParagraph(l1, formating.P_heading, LineType.P_heading));
                            break;
                        }
                    case LineType.Grid:
                        {
                            sb.Append(CreateEmailLineWithGrid(l1, formating.Div1, dtHeader, dtDetail, true, Alignment));
                            break;
                        }

                    default:
                        break;
                }
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        static string CreateEmailLine(emailLine line, Elament format)
        {
            int fontSize_D = 10;
            string fontColor_D = "#666666";

            StringBuilder sb = new StringBuilder();
            if (line.Detail == "" || line.Detail == null)
            {
                sb.Append("<" + line.LineType.ToString());
                sb.Append(" style=\"");
                sb.Append("text-align:" + ((line.Heading_Alignment == ElementAlign.Inherit) ? format.L_Alignment.ToString() : line.Heading_Alignment.ToString()) + "; ");
                sb.Append("font: " + ((format.L_FontStyle == fontStyle.Bold) ? "bold " : "") + format.L_FontSize.ToString() + "px ");
                //sb.Append(format.L_FontSize != fontSize_D ? "font-size:" + format.L_FontSize.ToString() + "px; " : "");
                // sb.Append((format.L_FontStyle == fontStyle.Bold) ? "font-weight:bold; " : "");
                sb.Append(format.L_FontColor != fontColor_D ? "color:" + format.L_FontColor + ";" : "");
                sb.Append("\"");
                sb.Append(">");
                sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading);
                sb.Append("</" + line.LineType.ToString() + ">");
            }
            else
            {
                sb.Append("<table>");

                sb.Append("<td width=\"100px\" style=\"");
                sb.Append(format.L_FontSize != fontSize_D ? "font-size:" + format.L_FontSize.ToString() + "px; " : "");
                sb.Append(format.L_FontStyle == fontStyle.Bold ? "font-weight:bold; " : "");
                sb.Append(format.L_FontColor != fontColor_D ? "color:" + format.L_FontColor + ";" : "");
                sb.Append("\" >");
                sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading);
                sb.Append(" </td>");

                sb.Append("<td  style=\"");
                sb.Append(format.R_FontSize != fontSize_D ? "font-size:" + format.R_FontSize.ToString() + "px; " : "");
                sb.Append(format.R_FontStyle == fontStyle.Bold ? "font-weight:bold; " : "");
                sb.Append(format.R_FontColor != fontColor_D ? "color:" + format.R_FontColor + ";" : "");
                sb.Append("\" >");
                sb.Append(": " + line.Detail);
                sb.Append(" </td>");

                sb.Append("</table>");
            }


            return sb.ToString();
        }

        static string CreateParagraph(emailLine line, Elament format, LineType LTP)
        {
            int fontSize_D = 10;
            string fontColor_D = "#666666";

            StringBuilder sb = new StringBuilder();

            if (line.Detail != "")
            {
                sb.Append("<table>");

                sb.Append("<td width=\"100px\" style=\"");
                sb.Append(format.L_FontSize != fontSize_D ? "font-size:" + format.L_FontSize.ToString() + "px; " : "");
                sb.Append(format.L_FontStyle == fontStyle.Bold ? "font-weight:bold; " : "");
                sb.Append(format.L_FontColor != fontColor_D ? "color:" + format.L_FontColor + ";" : "");
                sb.Append("\" >");
                sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading);
                sb.Append(" </td>");

                sb.Append("<td  style=\"");
                sb.Append(format.R_FontSize != fontSize_D ? "font-size:" + format.R_FontSize.ToString() + "px; " : "");
                sb.Append(format.R_FontStyle == fontStyle.Bold ? "font-weight:bold; " : "");
                sb.Append(format.R_FontColor != fontColor_D ? "color:" + format.R_FontColor + ";" : "");
                sb.Append("\" >");

                sb.Append("" + line.Detail);

                sb.Append(" </td>");

                sb.Append("</table>");
            }

            else
            {

                if (LineType.P_heading == LTP)
                {
                    sb.Append("<table>");
                    sb.Append("<td width=\"100px\" style=\"");
                    sb.Append(format.L_FontSize != fontSize_D ? "font-size:" + format.L_FontSize.ToString() + "px; " : "");
                    sb.Append(format.L_FontStyle == fontStyle.Bold ? "font-weight:bold; " : "");
                    sb.Append(format.L_FontColor != fontColor_D ? "color:" + format.L_FontColor + ";" : "");
                    sb.Append("\" >");
                    sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading + ":");
                    sb.Append(" </td>");
                    sb.Append("</table>");
                }

            }
            return sb.ToString();
        }

        static string CreateEmailLineWithGrid(emailLine line, Elament format, DataTable dtHeader, DataTable dtDetail, bool isDataset, clsEnum.Email_Alignment[] Alignment)
        {
            int fontSize_D = 10;
            string fontColor_D = "#666666";

            StringBuilder sb = new StringBuilder();
            if (line.Detail == "" || line.Detail == null)
            {
                sb.Append("<" + line.LineType.ToString());
                sb.Append(" style=\"");
                sb.Append("text-align:" + ((line.Heading_Alignment == ElementAlign.Inherit) ? format.L_Alignment.ToString() : line.Heading_Alignment.ToString()) + "; ");
                sb.Append("font: " + ((format.L_FontStyle == fontStyle.Bold) ? "bold " : "") + format.L_FontSize.ToString() + "px ");
                //sb.Append(format.L_FontSize != fontSize_D ? "font-size:" + format.L_FontSize.ToString() + "px; " : "");
                // sb.Append((format.L_FontStyle == fontStyle.Bold) ? "font-weight:bold; " : "");
                sb.Append(format.L_FontColor != fontColor_D ? "color:" + format.L_FontColor + ";" : "");
                sb.Append("\"");
                sb.Append(">");
                sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading);
                sb.Append("</" + line.LineType.ToString() + ">");
            }
            else
            {
                sb.Append("<table>");

                sb.Append("<td width=\"100px\" style=\"");
                sb.Append(format.L_FontSize != fontSize_D ? "font-size:" + format.L_FontSize.ToString() + "px; " : "");
                sb.Append(format.L_FontStyle == fontStyle.Bold ? "font-weight:bold; " : "");
                sb.Append(format.L_FontColor != fontColor_D ? "color:" + format.L_FontColor + ";" : "");
                sb.Append("\" >");
                sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading);
                sb.Append(" </td>");

                sb.Append("<td  style=\"");
                sb.Append(format.R_FontSize != fontSize_D ? "font-size:" + format.R_FontSize.ToString() + "px; " : "");
                sb.Append(format.R_FontStyle == fontStyle.Bold ? "font-weight:bold; " : "");
                sb.Append(format.R_FontColor != fontColor_D ? "color:" + format.R_FontColor + ";" : "");
                sb.Append("\" >");
                sb.Append(": " + line.Detail);
                sb.Append(" </td>");

                sb.Append("</table>");
            }

            if (isDataset)
            {
                if (dtDetail != null)
                {
                    if (dtHeader != null)//For Header
                    {
                        sb.Append("<table  style=\"");//
                        sb.Append("width:100%;border: 0px solid #8A0808;cellspacing:0;cellpadding:0;");//
                        sb.Append("\">");//
                        foreach (DataRow dRow in dtHeader.Rows)
                        {
                            int iCount = dRow.Table.Columns.Count;
                            sb.Append("<tr>");

                            for (int i = 0; i < iCount; i++)
                            {
                                sb.Append("<td style=\"");
                                sb.Append("border: 1px solid #8A0808;");//
                                sb.Append("\">");
                                sb.Append(dRow[i].ToString());
                                sb.Append("</td>");
                                //sb.Append("<td align=center>");
                                //sb.Append(dRow[i].ToString());
                                //sb.Append("</td>");
                            }
                            sb.Append("</tr>");
                        }
                    }

                    sb.Append("<table  style=\"");//
                    sb.Append("width:100%;border: 0px solid #8A0808;border-spacing: 0px;cellspacing:0;cellpadding:0;");//
                    sb.Append("\">");
                    int iRowCount = 0;
                    foreach (DataRow dRow in dtDetail.Rows)
                    {
                         int iCount = dRow.Table.Columns.Count;
                         int iTempiCount = iCount;
                         if (iRowCount == 0)
                         {
                             sb.Append("<tr>");
                             for (int i = 0; i < iCount; i++)
                             {
                                 sb.Append("<th style=\"");
                                 sb.Append("border: 1px solid #8A0808;margin:0;padding:0;border-spacing:0px");//
                                 sb.Append("\">");
                                 sb.Append(dRow[i].ToString());
                                 sb.Append("</th>");
                             }
                             sb.Append("</tr>");
                         }                        
                         else
                         {

                             sb.Append("<tr>");
                             for (int i = 0; i < iCount; i++)
                             {
                                 //For Group option
                                 if (dRow[0].ToString() == "")
                                 {
                                     sb.Append("<td  style=\"");
                                     sb.Append("border: 1px dotted #8A0808;margin:0;padding:0;text-align:" + "Left" + ";" + "colspan=" + dRow[2].ToString());                                   
                                     sb.Append("\">");
                                     sb.Append(dRow[1].ToString());
                                     string s = dRow[1].ToString();
                                     sb.Append("</td>");
                                     break;
                                 }
                                 else if (dRow[0].ToString() == "#")//For Sum
                                 {
                                     
                                     string Colspan= dRow[1].ToString();                                    

                                     if (i == iTempiCount - 1 || i == iTempiCount - 2)
                                     {
                                         sb.Append("<td  style=\"");
                                         sb.Append("border: 0px dotted #8A0808;margin:0;padding:0;text-align:" + "Right" + ";");
                                         sb.Append("\">");
                                         sb.Append(dRow[i].ToString());
                                         iTempiCount = iCount;
                                         sb.Append("</td>");
                                     }
                                     else
                                     {
                                         //For Empty Row
                                         sb.Append("<td  style=\"");
                                         sb.Append("border: 0px dotted #8A0808;margin:0;padding:0;text-align:" + "Right" + ";");
                                         sb.Append("\">");
                                         sb.Append("");
                                         iTempiCount = iCount;
                                         sb.Append("</td>");

                                     }

                                 }
                                 else
                                 {

                                     sb.Append("<td style=\"");
                                     sb.Append("border: 1px dotted #8A0808;margin:0;padding:0;text-align:" + ClsFormatter.GetAlignment(Alignment[i]) + ";");
                                     sb.Append("\">");
                                     sb.Append(dRow[i].ToString());
                                     sb.Append("</td>");
                                 }
                             
                             }
                             sb.Append("</tr>");
                         }

                         iRowCount++;
                    }
                    sb.Append("</table>");
                }

            }

            return sb.ToString();
        }





    }


    public class emailLine
    {
        public LineType LineType = LineType.Line1;
        public ElementAlign Heading_Alignment;
        public string Heading = "";
        public ElementAlign Detail_Alignment;
        public string Detail = "";
        public DataTable Table;
        public List<emailLine> TableFormating;

        public emailLine(LineType _LineType, ElementAlign _Heading_Alignment, string _Heading, ElementAlign _Detail_Alignment, string _Detail)
        {
            LineType = _LineType;
            Heading_Alignment = _Heading_Alignment;
            Heading = _Heading;
            Detail_Alignment = _Detail_Alignment;
            Detail = _Detail;
        }

        public emailLine(LineType _LineType, string _Heading, string _Detail)
        {
            LineType = _LineType;
            Heading_Alignment = ElementAlign.Inherit;
            Heading = _Heading;
            Detail_Alignment = ElementAlign.Inherit;
            Detail = _Detail;
        }

        public emailLine(LineType _LineType, ElementAlign _Heading_Alignment, string _Heading)
        {
            LineType = _LineType;
            Heading_Alignment = _Heading_Alignment;
            Heading = _Heading;
        }

        public emailLine(LineType _LineType, string _Heading)
        {
            LineType = _LineType;
            Heading_Alignment = ElementAlign.Inherit;
            Heading = _Heading;
        }

        public emailLine(LineType _LineType)
        {
            LineType = _LineType;
        }

        public emailLine(LineType _LineType, DataTable _Table)
        {
            LineType = _LineType;
            Table = _Table;
        }
        public emailLine(LineType _LineType, DataTable _Table, List<emailLine> _TableFormating)
        {
            LineType = _LineType;
            Table = _Table;
            TableFormating = _TableFormating;
        }
    }


    public class Elament
    {
        public ElementAlign L_Alignment = ElementAlign.Inherit;
        public string L_Font = null;
        public int L_FontSize = 0;
        public string L_FontColor = "#333333";
        public fontStyle L_FontStyle;

        public ElementAlign R_Alignment = ElementAlign.Inherit;
        public string R_Font = null;
        public int R_FontSize = 0;
        public string R_FontColor = "#333333";
        public fontStyle R_FontStyle;

        public Elament(ElementAlign alignment, string font, int fontSize, string fontColor, fontStyle fontStyle)
        {
            L_Alignment = alignment;
            L_Font = font;
            L_FontSize = fontSize;
            L_FontColor = fontColor;
            L_FontStyle = fontStyle;
        }

        public Elament(ElementAlign L_alignment, string L_font, int L_fontSize, string L_fontColor, fontStyle L_fontStyle, ElementAlign R_alignment, string R_font, int R_fontSize, string R_fontColor, fontStyle R_fontStyle)
        {
            L_Alignment = L_alignment;
            L_Font = L_font;
            L_FontSize = L_fontSize;
            L_FontColor = L_fontColor;
            L_FontStyle = L_fontStyle;

            R_Alignment = R_alignment;
            R_Font = R_font;
            R_FontSize = R_fontSize;
            R_FontColor = R_fontColor;
            R_FontStyle = R_fontStyle;
        }
    }

    public class EmailLineformating
    {
        public Elament H1 = new Elament(ElementAlign.Center, "Segoe UI", 19, "#333333", fontStyle.NA);
        public Elament H2 = new Elament(ElementAlign.Center, "Comic Sans MS", 13, "#333333", fontStyle.NA);
        public Elament H3 = new Elament(ElementAlign.Center, null, 12, "#333333", fontStyle.NA);
        public Elament H4 = new Elament(ElementAlign.Center, null, 11, "#333333", fontStyle.NA);
        public Elament H5 = new Elament(ElementAlign.Center, null, 10, "#333333", fontStyle.NA);
        public Elament H6 = new Elament(ElementAlign.Center, null, 9, "#333333", fontStyle.NA);

        public Elament Space = new Elament(ElementAlign.Center, null, 8, "#333333", fontStyle.NA);

        public Elament HF = new Elament(ElementAlign.Left, null, 9, "#999999", fontStyle.Bold);

        public Elament Div1 = new Elament(ElementAlign.Left, null, 10, "#666666", fontStyle.NA, ElementAlign.Left, null, 10, "#5C0000", fontStyle.Bold);

        public Elament P = new Elament(ElementAlign.Left, null, 10, "#333333", fontStyle.NA, ElementAlign.Left, null, 10, "#5C0000", fontStyle.Bold);
        public Elament P_heading = new Elament(ElementAlign.Left, null, 10, "#333333", fontStyle.NA, ElementAlign.Left, null, 10, "#5C0000", fontStyle.Bold);
    }
}
