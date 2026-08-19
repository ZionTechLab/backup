namespace SEACC_Alert_Engine
{
    public enum SendMailTypes
    {
        To = 0,
        CC = 1,
        BCC = 2
    }

    public enum EmailStatus
    {
        newMail = 0,
        sentMail = 1,
        Error = 2,
        Error_Reception = 3
    }

    public enum LineType
    {
        H1, H2, H3, H4, H5, H6, Header_Block, Footer1, Footer2, Line1, Line2, Space, Detail1, Detail2, DataTable, DIV, TableColomn1, TableColomn2, TableColomn3, TableColomn4
    }

    public enum ElementAlign
    {
        Left, Right, Center, Inherit, NA
    }

    public enum fontStyle
    {
        Bold, italic, underline, bold_italic, bold_underline, NA
    }

    public enum Colors
    {
        New, Updated, Approvd, rejected, Warning
    }
}