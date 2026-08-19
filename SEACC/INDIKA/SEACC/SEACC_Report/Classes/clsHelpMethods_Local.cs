using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_Report
{
    class clsHelpMethods_Local
    {
        public static decimal getDisplayPrice(decimal dPrice, decimal dExRate)
        {
            decimal dUnitPrice = 0;
            if (dExRate > 0)
                dUnitPrice = dPrice / dExRate;
            return dUnitPrice;
        }

        #region Get Report Path
        public static bool GetReportPath(string ReportID, ref string ReportName, ref string ReportName2, ref string s_Path)
        {
            GetReportPath(ReportID, ref ReportName, ref ReportName2, ref s_Path, false);

            if (s_Path == null || s_Path.Length <= 0)
            {
                MessageBox.Show("Report is not linked.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;

        }
        public static bool GetReportPath(string ReportID, ref string ReportName, ref string ReportName2, ref string s_Path, bool isExcel)
        {
            ReportName = "";
            ReportName2 = "";
            try
            {
                tbl_securityReportMaster detail = tbl_securityReportMaster.Select(ReportID);
                if (detail != null)
                {
                    s_Path = detail.ReportPath.Trim();
                    ReportName = detail.DisplayName.Trim();
                    if (detail.DisplayName2 != null)
                        ReportName2 = detail.DisplayName2.Trim();

                    tbl_securityReportMaster_CompanyBranch oRptBranchWice = tbl_securityReportMaster_CompanyBranch.Select(ReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oRptBranchWice != null)
                    {
                        s_Path = oRptBranchWice.ReportPath.Trim();
                        ReportName = oRptBranchWice.DisplayName.Trim();
                        if (oRptBranchWice.DisplayName2 != null)
                            ReportName2 = oRptBranchWice.DisplayName2.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!isExcel && (s_Path == null || s_Path.Length <= 0))
            {
                MessageBox.Show("Report is not linked.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
        #endregion

        #region Start Progress Bar
        public static void startProgressBar(int minVal, int maxVal, int incrementVal, ProgressBar PB)
        {
            try
            {
                PB.Minimum = minVal;
                PB.Maximum = maxVal;

                PB.Value = PB.Value + incrementVal;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Progress Bar Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Convert List To  DataTable
        public static DataTable ToDataTable<T>(List<T> items)
        {
            //convert list
            //DataTable dt = clsHelpMethods_Local.ToDataTable(lstTemp);
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            
            //put a breakpoint here and check datatable
            return dataTable;
        } 
        #endregion

    }
}
