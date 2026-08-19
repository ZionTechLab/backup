using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Digiteq_Logic
{
    public class emailEngine
    {
        public string genarateEmail_Body(string Heading)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<HTML>");
            sb.AppendLine("<BODY>");
            sb.AppendLine("<div style=\"background-color: #06F; font-family: Arial, Helvetica,sans-serif; padding: 10; font-size: 15px; color: #FFF;\">"+Heading+"</div>");
            sb.AppendLine("</BODY>");
            sb.AppendLine("</HTML>");
            return sb.ToString();
        }
    }

    public enum LineType
    {
        H1, H2, H3, H4, H5, H6,Header_Block, Footer1, Footer2, Line1, Line2, Space, Detail1, Detail2, DataTable, DIV, TableColomn1, TableColomn2, TableColomn3, TableColomn4
    }

    public enum ElementAlign
    {
        Left, Right, Center, Inherit, NA
    }

    public enum fontStyle
    {
        Bold, italic, underline, bold_italic, bold_underline, NA
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
        public Elament H1 = new Elament(ElementAlign.Center, null, 19, "#333333", fontStyle.NA);
        public Elament H2 = new Elament(ElementAlign.Center, null, 13, "#333333", fontStyle.NA);
        public Elament H3 = new Elament(ElementAlign.Center, null, 12, "#333333", fontStyle.NA);
        public Elament H4 = new Elament(ElementAlign.Center, null, 11, "#333333", fontStyle.NA);
        public Elament H5 = new Elament(ElementAlign.Center, null, 10, "#333333", fontStyle.NA);
        public Elament H6 = new Elament(ElementAlign.Center, null, 9, "#333333", fontStyle.NA);

        public Elament Space = new Elament(ElementAlign.Center, null, 8, "#333333", fontStyle.NA);

        public Elament HF = new Elament(ElementAlign.Left, null, 9, "#999999", fontStyle.Bold);

        public Elament Div1 = new Elament(ElementAlign.Left, null, 10, "#666666", fontStyle.NA, ElementAlign.Left, null, 10, "#5C0000", fontStyle.Bold);
    }

    public class clsEmailConfig
    {
        #region Create Email Body
        public static string CreateEmailBody(string Header, DataTable detail)
        {
        //    int fontSize_D = 10;
            string fontColor_D = "#06F";
          //  string BackColor_Request = "#06F";
          //  string BackColor_Approved = "#339933";
          //  string BackColor_Reject = "#e60000";

            StringBuilder sb = new StringBuilder();
            sb.Append("<div style=\"background-color: #06F; font-family: Arial, Helvetica,sans-serif; padding: 7px; padding-bottom:15px; margin-bottom:10px; font-size: 14px; color: #FFF; \">" + Header.Replace("\n", "<br/><br/>") + "</div>");
            sb.Append("<table style=\"font-family: Arial, Helvetica,sans-serif; font-size: 11px;\">");
            foreach (DataRow row in detail.Rows) // Loop over the rows.
            {
                sb.AppendLine("<tr >");
                sb.Append("<td  style=\"width:100px;");
                sb.Append("color:" + fontColor_D + ";");
                sb.Append("\" >");
                sb.Append(row[0] == "" ? "&nbsp;" : row[0]);
                sb.Append(" </td>");

                sb.Append("<td  style=\"");
                sb.Append("color:" + "#FF000000" + ";");
                sb.Append("\" >");
                sb.Append((row[0] == ""?"":": ") + row[2]);
                sb.Append(" </td>");
                sb.AppendLine("</tr>");

            }
            sb.Append("</table>");
            return sb.ToString();
        }

        public static string CreateEmailBody(List<emailLine> list1)
        {
            StringBuilder sb = new StringBuilder();
           
            foreach (emailLine l1 in list1)
            {
                switch (l1.LineType)
                { case LineType.Header_Block:
                        {
                            sb.Append("<div style=\"background-color: #06F; font-family: Arial, Helvetica,sans-serif; padding: 7px; padding-bottom:15px; margin-bottom:10px; font-size: 14px; color: #FFF; \">" + l1.Heading.Replace("\n", "<br/><br/>") + "</div>");
                            break;
                        }
                    case LineType.H1:
                        {
                            sb.Append("<H1 style=\"font-weight: 100; color:#333333; font: 25px Segoe UI, Regular;\">" + l1.Heading + "</H1>");
                            break;
                        }
                    case LineType.H2:
                        {
                            sb.Append("<H1 style=\" color:#333333; font: 15px/10px Arial, serif;\">" + l1.Heading + "</H1>");
                            break;
                        }
                    case LineType.H3:
                        {
                            sb.Append(CreateEmailLine(l1));
                            break;
                        }
                    case LineType.H4:
                        {
                            sb.Append(CreateEmailLine(l1));
                            break;
                        }
                    case LineType.H5:
                        {
                            sb.Append(CreateEmailLine(l1));
                            break;
                        }
                    case LineType.H6:
                        {
                            sb.Append("<H1 style=\" color:#333333; font: 9px Segoe UI, Regular;\">" + l1.Heading + "</H1>");
                            break;
                            //sb.Append(CreateEmailLine(l1, formating.H6));
                            //break;
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
                            sb.Append(CreateEmailLine(l1));
                            break;
                        }
                    case LineType.Footer1:
                        {
                            l1.LineType = LineType.DIV;
                            sb.Append(CreateEmailLine(l1));
                            break;
                        }
                    case LineType.Detail2:
                        {
                            sb.Append(CreateEmailLine(l1));
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
                                    sb.Append("<td style=\"border-top:hidden; border-right:hidden; padding:4px; font-weight:normal; \">" + dr[column].ToString() + "</td>");
                                }
                                sb.Append("</tr>");
                            }
                            sb.Append("</table>");
                            #endregion
                            break;
                        }
                    default:
                        break;
                }
            }
     
            return sb.ToString();
        }

        static string CreateEmailLine(emailLine line)
        {
           // int fontSize_D = 10;
            string fontColor_D = "#666666";

            StringBuilder sb = new StringBuilder();
            if (line.Detail == "" || line.Detail == null)
            {
                sb.Append("<" + line.LineType.ToString());
                sb.Append(" style=\"");
                sb.Append("text-align:" +  line.Heading_Alignment.ToString() + "; ");
                //sb.Append(format.L_FontSize != fontSize_D ? "font-size:" + format.L_FontSize.ToString() + "px; " : "");
                //sb.Append((format.L_FontStyle == fontStyle.Bold) ? "font-weight:bold; " : "");
                //sb.Append(format.L_FontColor != fontColor_D ? "color:" + format.L_FontColor + ";" : "");
                sb.Append("\"");
                sb.Append(">");
                sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading);
                sb.Append("</" + line.LineType.ToString() + ">");
            }
            else
            {
                sb.Append("<table style=\"font-family: Arial, Helvetica,sans-serif; font-size: 11px;\">");
                sb.AppendLine("<tr>");
                sb.Append("<td  style=\"width:100px;");
                sb.Append("color:" + fontColor_D + ";");
                sb.Append("\" >");
                sb.Append(line.Heading == "" ? "&nbsp;" : line.Heading);
                sb.Append(" </td>");

                sb.Append("<td  style=\"");
                sb.Append("color:" + fontColor_D + ";");
                sb.Append("\" >");
                sb.Append(": " + line.Detail);
                sb.Append(" </td>");
                sb.AppendLine("</tr>");
                sb.Append("</table>");
            }
            return sb.ToString();
        }

        public static string CreateEmailBodyWithMultyTable(string EmailId, string Title, string sHeading, DataTable tHeader, DataTable tDetail, DataTable tFooter_Total, DataTable tFooter_PerItem, DataSet ds)
        {
            // string sBodyHTML;
            StringBuilder sb = new StringBuilder();
            sb.Append("<H3 align=\"Center\" ><font size=\"3\" color=\"#515355\">" + Title + "</font> </H3>");
            sb.Append("<H3 align=\"Center\" ><font size=\"2\" color=\"#515355\">" + sHeading + "</font> </H3>");

            sb.Append("<HR>");

            #region Header
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tHeader.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "n")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            #endregion

            if (tDetail != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");
                sb.Append("<tr>");
                foreach (DataTable dtIn in ds.Tables)
                {
                    sb.Append("<td>");
                    sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                    sb.Append("<tr>");
                    foreach (DataColumn dc in dtIn.Columns)
                    {
                        sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow dr in dtIn.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dtIn.Columns)
                        {
                            sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                        } sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }
            else
            {

            }

            #region User Details Per Item
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tFooter_PerItem.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td><font size=\"1\" color=\"#515355\">  </font></td>");
                else
                    sb.Append("<td><font size=\"1\" color=\"#515355\"> : </font></td>");
                sb.Append("<td> <b><font size=\"1\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            #endregion

            sb.Append("<p></p>");

            #region User Details Total
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tFooter_Total.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td><font size=\"1\" color=\"#515355\">  </font></td>");
                else
                    sb.Append("<td><font size=\"1\" color=\"#515355\"> : </font></td>");
                sb.Append("<td> <b><font size=\"1\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            #endregion



            sb.Append("<HR>");
            sb.Append("<p><b><font size=\"1\" color=\"#80878E\">Email Ref No : " + EmailId + "</font></b></p>");
            return sb.ToString();
        }

        public static string CreateDailyStatusEmailBody(string EmailId, string Title, string sHeading, DataTable tTitle, DataTable tDetail1, DataTable tDetail2, DataTable tDetail3, DataTable tDetail4, DataTable tDetail5, DataTable tDetail6, DataTable tDetail7, DataTable tHeader, DataTable tDetail, DataTable tFooter)
        {
            // string sBodyHTML;
            StringBuilder sb = new StringBuilder();

            sb.Append("<H3 align=\"Center\" >" + Title + "</H3>");
            sb.Append("<H3 align=\"Center\" >" + sHeading + "</H3>");
            sb.Append("<HR>");
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tTitle.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "n")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");

                sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[2].ToString() + "</font> </b></td>");

                sb.Append("</tr>");

            }
            //  sb.Append("/table");
            #region Detail1
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append(" <td>");
            sb.Append("<th align=\"center\"><u>FOR THE DAY </u></th>");
            sb.Append(" </td>");
            sb.Append(" <td>");
            sb.Append("<th align=\"center\"><u>FOR THE MONTH</u></th>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail1.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail2
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail2.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else

                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail3
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail3.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else

                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");


                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail4
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail4.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");


                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail5
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail5.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");

                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail6
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            //sb.Append(" <td><font size=\"1.5\" color=\"#515355\"> Main Store Stock </font> </td>");
            //sb.Append("<th align=\"Left\">Main Store Stock </th>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail6.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else

                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");



                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail7
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail7.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Header
            if (tHeader != null)
            {
                sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
                sb.Append(" <tr>");
                sb.Append(" <td>");
                sb.Append(" </td>");
                sb.Append(" <td>");
                sb.Append("<th align=\"center\"><u>FOR THE DAY </u></th>");
                sb.Append(" </td>");
                sb.Append(" <td>");
                sb.Append("<th align=\"center\"><u>FOR THE MONTH</u></th>");
                sb.Append(" </td>");
                sb.Append("</tr>");
                foreach (DataRow dr in tHeader.Rows)
                {
                    sb.Append("<tr  COLSPAN=\"2\">");
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                    if (dr[0].ToString() == "")
                        sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                    else
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                    if (dr[2].ToString() == "")
                        sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                    else
                        sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                    if (dr[3].ToString() == "")
                        sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                    else
                        sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }
            else
            {

            }
            #endregion

            if (tDetail != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"2px\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");
                sb.Append("<tr>");
                foreach (DataRow dr in tDetail.Rows)
                {
                    foreach (DataColumn column in tDetail.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");
                    }
                    //sBodyHTML += "<th>" + dr.ColumnName + "</th>";
                }
                sb.Append("</tr>");
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }
            else
            {

            }


            #region User Details
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tFooter.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td><font size=\"1\" color=\"#515355\">  </font></td>");
                else
                    sb.Append("<td><font size=\"1\" color=\"#515355\"> : </font></td>");
                sb.Append("<td> <b><font size=\"1\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            #endregion

            sb.Append("<HR>");
            sb.Append("<p><b><font size=\"1\" color=\"#80878E\">Email Ref No : " + EmailId + "</font></b></p>");
            return sb.ToString();
        }

        #endregion
    }
}
