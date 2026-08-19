using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SEACC_Alert_Engine
{
    public class clsEmailEngine
    {
        public static string getColor(Colors CLr)
        {
            string sColorCode = "#0074b3;";
            switch (CLr)
            {
                case Colors.New:
                    sColorCode = "#0074b3;";
                    break;
                case Colors.Updated:
                    sColorCode = "#b33f00;";
                    break;
                case Colors.Approvd:
                    sColorCode = "#00b33f;";
                    break;
                case Colors.rejected:
                    sColorCode = "#b3001a;";
                    break;
                case Colors.Warning:
                    sColorCode = "#FF8B19;";
                    break;
                default:
                    break;
            }
            return sColorCode;

        }

        #region Create Email Body
        //Developed by Gayan 2016-12-30
        public static string CreateEmailBody_DailyStatus(string Header, Colors CLr, DataTable detail)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div style=\"background-color:" + getColor(CLr) + "  font-family: Arial, Helvetica,sans-serif; padding: 7px; padding-bottom:15px; margin-bottom:10px; font-size: 14px; color: #FFF; \">" + Header.Replace("\n", "<br/><br/>") + "</div>");
            sb.Append("<table style=\"font-family: Arial, Helvetica,sans-serif; font-size: 11px;\">");

            string html = ExportDatatableToHtml(detail);
            sb.Append(html);

            return sb.ToString();
        }

        public static string CreateEmailBody_Common(string Header, string Count, string Footer, Colors CLr, DataTable detail)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div style=\"background-color:" + getColor(CLr) + "  font-family: Arial, Helvetica,sans-serif; padding: 7px; padding-bottom:15px; margin-bottom:10px; font-size: 14px; color: #FFF; \">" + Header.Replace("\n", "<br/><br/>") + "</div>");
            
            string html = ExportDatatableToHtml(detail);
            sb.Append(html);
                        
            sb.Append("<div style=\" font-family: Arial, Helvetica,sans-serif; padding: 3px; padding-bottom:10px; margin-bottom:10px; font-weight:bold; font-size: 11px; color: #000; \"> " + Count.Replace("\n", "<br/><br/>") + "</div>");
            sb.Append("<div style=\" font-family: Arial, Helvetica,sans-serif; padding: 3px; padding-bottom:10px; margin-bottom:10px; font-size: 12px; color: #000; \">" + Footer.Replace("\n", "<br/><br/>") + "</div>");

            return sb.ToString();
        }        

        public static string CreateEmailBody(string Header, Colors CLr, DataTable detail)
        {
            string fontColor_D = "#06F";

            StringBuilder sb = new StringBuilder();

            sb.Append("<div style=\"background-color:" + getColor(CLr) + "  font-family: Arial, Helvetica,sans-serif; padding: 7px; padding-bottom:15px; margin-bottom:10px; font-size: 14px; color: #FFF; \">" + Header.Replace("\n", "<br/><br/>") + "</div>");
            sb.Append("<table style=\"font-family: Arial, Helvetica,sans-serif; font-size: 11px;\">");

            foreach (DataRow row in detail.Rows) // Loop over the rows.
            {
                sb.AppendLine("<tr >");
                sb.Append("<td  style=\"width:100px;");
                sb.Append("color:" + fontColor_D + ";");
                sb.Append("\" >");
                //  sb.Append(row[0] == "" ? "&nbsp;" : row[0]);
                sb.Append(" </td>");

                sb.Append("<td  style=\"");
                sb.Append("color:" + "#FF000000" + ";");
                sb.Append("\" >");
                //  sb.Append((row[0] == "" ? "" : ": ") + row[2]);
                sb.Append(" </td>");
                sb.AppendLine("</tr>");

            }
            sb.Append("</table>");
            return sb.ToString();
        }

        #endregion

        #region Help Methods
        //Developed by Gayan 2016-12-30
        protected static string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            //strHTMLBuilder.Append("<html >");
            //strHTMLBuilder.Append("<head>");
            //strHTMLBuilder.Append("</head>");
            //strHTMLBuilder.Append("<body>");
            //strHTMLBuilder.Append("<table border='1px' cellpadding='5' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; padding:7px; font-size:smaller'>");

            strHTMLBuilder.Append("<table cellpadding='3' cellspacing='0' style='font-family:Garamond; padding:0px; font-size:smaller; border:1px solid silver;'>");

            //strHTMLBuilder.Append("<tr style=\"font-family: Arial, Helvetica,sans-serif; font-size: 14px;\" >");
            strHTMLBuilder.Append("<tr style=\"font-family: Arial, Helvetica,sans-serif; font-size: 12px; \" >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td align=\"center\" style=\"font-weight:bold; border:1px solid silver;\">");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                //strHTMLBuilder.Append("<tr style=\"font-family: Arial, Helvetica,sans-serif; font-size: 13px;\" >");
                strHTMLBuilder.Append("<tr style=\"font-family: Arial, Helvetica,sans-serif; font-size: 11px; border:1px solid silver;\" >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    if (myColumn.DataType != typeof(int))
                        strHTMLBuilder.Append("<td style=\"font-family: Arial, Helvetica,sans-serif; font-size: 11px; border:1px solid silver;\">");
                    else
                        //strHTMLBuilder.Append("<td align=\"right\" >");
                        strHTMLBuilder.Append("<td align=\"right\" style=\" border:1px solid silver;\" >");

                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            strHTMLBuilder.Append("</table>");
            // strHTMLBuilder.Append("</body>");
            // strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;

        } 
        #endregion
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

    public class MaillReceptioner
    {
        public string sEmail = "", sName = "";
        public SendMailTypes iMsgType = SendMailTypes.To;

        public MaillReceptioner()
        { }
        public MaillReceptioner(string _sName, string _sEmail, SendMailTypes _iMsgTrye)
        {
            sName = _sName;
            sEmail = _sEmail;
            iMsgType = _iMsgTrye;
        }
    }


}
