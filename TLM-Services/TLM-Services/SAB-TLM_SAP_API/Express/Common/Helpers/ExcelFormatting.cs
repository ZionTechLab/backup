using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.Helpers
{
    public sealed class ExcelFormatting
    {
        private ExcelFormatting()
        {

        }
        /// <summary>
        /// convert xlsx to xls
        /// </summary>
        /// <param name="strFullFilePath">full file path(with file name )</param>
        /// <param name="strFilePath">file directory path</param>
        /// <param name="strFName">file name</param>
        /// <returns>new file path</returns>
        public static string ConvertXlsx(string strFullFilePath,  string strFilePath , string  strFName)
        {
           
            var strFileName = GetFileDetails(strFilePath, strFName);
            DataTable newExcelFormat = ReadExcelData(strFullFilePath);
            var newFile = File.Create(strFileName);
            using (ExcelPackage pck = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Name of Worksheet");
                ws.Cells["A1"].LoadFromDataTable(newExcelFormat, true);
                pck.Save();
                ws.Dispose();
            }
            newFile.Dispose();
            return strFileName;

        }

        /// <summary>
        /// full file path (with file name)
        /// </summary>
        /// <param name="filePath">string</param>
        /// <returns>datatable</returns>
        public  static DataTable ReadExcelData(string filePath)
        {
            DataTable dtexcel = new DataTable();
            bool hasHeaders = false;
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            DataRow schemaRow = schemaTable.Rows[0];
            string sheet = schemaRow["TABLE_NAME"].ToString();
            if (!sheet.EndsWith("_"))
            {
                string query = "SELECT  * FROM [" + sheet + "]";
                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                dtexcel.Locale = CultureInfo.CurrentCulture;
                daexcel.Fill(dtexcel);
            }

            conn.Close();
            return dtexcel;
        }

        private static string GetFileDetails(string strFilePath, string strFileName)
        {
            string[] fname = strFileName.Split('.');
            strFilePath = Path.Combine(strFilePath, fname[0] + ".xlsx");
            if (File.Exists(strFilePath))
            {
                File.Delete(strFilePath);
            }
            return strFilePath;
        }

        

    }
}
