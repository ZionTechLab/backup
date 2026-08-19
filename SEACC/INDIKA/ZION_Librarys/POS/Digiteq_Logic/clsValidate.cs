using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using DataTire;
using System.Drawing;
using System.Data;
using System.Globalization;

namespace Digiteq_Logic
{
    public class clsValidate
    {
        #region Write Log  

        #region Error Log
        public static void WriteErrorLog(string sError, int iformID, Exception ex)
        {
            try
            {
                string smsg = DateTime.Now.ToString() + " - " + sError + " - " + iformID + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + "-" + Environment.NewLine + Environment.NewLine;

                string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                File.AppendAllText(logFileName_Local, smsg);

                string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                File.AppendAllText(logFileName, smsg);
            }
            catch { }
        }
        #endregion

        #region SMS Log
        public static void WriteSMSLog(string sMessage)
        {
            string logFileName = Path.Combine(Application.StartupPath, "SMSLog.dat");
            try
            {
                File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sMessage);
            }
            catch { }
        }
        #endregion
        #endregion

        //Email

        #region ValidateEmail
        public static bool ValidateEmail(string emailAddress)
        {
            string pattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|2{1}[0-5]{2})\.([0-1]?[0-9]{1,2}|2{1}[0-5]{2})\."
       + @"([0-1]?[0-9]{1,2}|2{1}[0-5]{2})\.([0-1]?[0-9]{1,2}|2{1}[0-5]{2})){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            Match match = Regex.Match(emailAddress, pattern, RegexOptions.IgnoreCase);
            return match.Success;
        }
        #endregion

        #region ValidateWebAddress
        public static bool ValidateWebAddress(string webAddress)
        {
            if (webAddress.Contains(".."))
                return false;
            else
            {
                if (webAddress.Contains("."))
                {
                    if ((webAddress.EndsWith(".")) || (webAddress.StartsWith(".")))
                        return false;
                    else
                        return true;
                }
                else
                    return false;

            }
        }
        #endregion

        //Numeric Validation - Text Boxes

        #region Allow Integer
        public static bool AllowInteger(KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8))
            {
                //Allow integers
            }
            else
            {
                e.KeyChar = (char)0;
            }
            return e.Handled;
        }
        #endregion

        #region Allow Integer and Plus
        public static bool AllowIntegerAndPlus(KeyPressEventArgs e)
        {
            if ((((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8)) || e.KeyChar == 43)
            {
                //Allow integers
            }
            else
            {
                e.KeyChar = (char)0;
            }
            return e.Handled;
        }
        #endregion

        #region Allow Integer and Comma
        /// <summary>
        /// Allows only integers and commas to be typed in a control (AlowIntegers)
        /// </summary>
        /// <param name="e">KeyPress event of the control</param>
        /// <param name="sender">sent object</param>
        public static bool AllowIntegerAndComma(KeyPressEventArgs e, object sender)
        {
            if (((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8) || (e.KeyChar == 44))
            {
                if ((sender.ToString().Substring(sender.ToString().Length - 1, 1) == ",") && (e.KeyChar == 44))
                    e.KeyChar = (char)0;
            }
            else
                e.KeyChar = (char)0;

            return e.Handled;
        }
        #endregion

        #region Allow Integer and Hypen
        /// <summary>
        /// Allows only integers and commas to be typed in a control (AlowIntegers)
        /// </summary>
        /// <param name="e">KeyPress event of the control</param>
        /// <param name="sender">sent object</param>
        public static bool AllowIntegerAndHypen(KeyPressEventArgs e, object sender)
        {
            if (((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8) || (e.KeyChar == 45))
            {
                if ((sender.ToString().Substring(sender.ToString().Length - 1, 1) == "-") && (e.KeyChar == 45))
                    e.KeyChar = (char)0;
            }
            else
                e.KeyChar = (char)0;

            return e.Handled;
        }
        #endregion

        #region Allow Integer Comma and Hypen
        /// <summary>
        /// Allows only integers and commas to be typed in a control (AlowIntegers)
        /// </summary>
        /// <param name="e">KeyPress event of the control</param>
        /// <param name="sender">sent object</param>
        public static bool AllowIntegerCommaAndHyphen(KeyPressEventArgs e, object sender)
        {
            if (((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8) || (e.KeyChar == 44) || (e.KeyChar == 45))
            {
                if ((sender.ToString().Substring(sender.ToString().Length - 1, 1) == ",") && (e.KeyChar == 44))
                {
                    e.KeyChar = (char)0;
                }

                if ((sender.ToString().Substring(sender.ToString().Length - 1, 1) == "-") &&
                    (e.KeyChar == 45))
                {
                    e.KeyChar = (char)0;
                }

            }
            else
            {
                e.KeyChar = (char)0;
            }
            return e.Handled;
        }
        #endregion

        #region Allow Decimal
        /// <summary>
        /// Allow keypress only for decimal figures (AlowDecimals)
        /// </summary>
        /// <param name="textValue">Text Value</param>
        /// <param name="e">
        /// Parameter e carries the KeyChar of the pressed key in a <see cref="KeyPressEventArgs"/> object.
        /// </param>
        public static void AllowDecimal(string textValue, KeyPressEventArgs e)
        {
            string decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            if (((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8) || (Convert.ToString(e.KeyChar) == decimalSeparator) || (Convert.ToString(e.KeyChar) == "-"))
            {
                if ((Convert.ToString(e.KeyChar) == decimalSeparator))
                {
                    if (textValue.Contains(decimalSeparator))
                    {
                        e.KeyChar = (char)0;
                    }
                }
            }
            else
            {
                e.KeyChar = (char)0;
            }
        }
        #endregion

        #region Allow Decimal with Hypen
        /// <summary>
        /// Allow keypress only for decimal figures (AlowDecimals)
        /// </summary>
        /// <param name="textValue">Text Value</param>
        /// <param name="e">
        /// Parameter e carries the KeyChar of the pressed key in a <see cref="KeyPressEventArgs"/> object.
        /// </param>
        public static void AllowDecimalWithHypen(string textValue, KeyPressEventArgs e)
        {
            string decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            if (((e.KeyChar >= 48) && (e.KeyChar <= 57)) || (e.KeyChar == 8) || (e.KeyChar == 45) || (Convert.ToString(e.KeyChar) == decimalSeparator))
            {
                if ((Convert.ToString(e.KeyChar) == decimalSeparator))
                {
                    if ((textValue.ToString().Substring(textValue.ToString().Length - 1, 1) == "-") && (e.KeyChar == 45))
                    {
                        if (textValue.Contains(decimalSeparator))
                        {
                            e.KeyChar = (char)0;
                        }
                    }
                }
            }
            else
            {
                e.KeyChar = (char)0;
            }
        }
        #endregion

        #region Allow Decimal With Length
        /// <summary>
        /// Allows only decimal values, and the same time it validate the leanth
        /// </summary>
        /// <param name="control"></param>
        /// <param name="e"></param>
        /// <param name="noOfIntegers">number of integers</param>
        /// <param name="noOfPrecisions">Number of Prcisions</param>
        public static void AllowDecimalWithLength(Control control, KeyPressEventArgs e, int noOfIntegers, int noOfPrecisions)
        {
            string decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            if ((47 < e.KeyChar && e.KeyChar < 58) || e.KeyChar == 8 || e.KeyChar.ToString() == decimalSeparator)
            {
                if (e.KeyChar.ToString() == decimalSeparator && control.Text != "")
                {
                    if (control.Text.Contains(decimalSeparator))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        CheckLenthForDecimal(control, e, noOfIntegers, noOfPrecisions);         //when double only ok
                    }
                }
                else
                {
                    CheckLenthForDecimal(control, e, noOfIntegers, noOfPrecisions);           //when double only ok
                }
            }
            else
            {
                e.Handled = true;
            }

        }
        #endregion

        #region Check Length for Decimal
        /// <summary>
        /// This is use by 'AllowDecimal' Method for validate leanth of the input
        /// </summary>
        /// <param name="control"></param>
        /// <param name="e"></param>
        /// <param name="noOfIntegers"></param>
        /// <param name="noOfPrecisions"></param>
        private static void CheckLenthForDecimal(Control control, KeyPressEventArgs e, int noOfIntegers, int noOfPrecisions)
        {
            int cursorPosistion = ((TextBox)control).SelectionStart;
            string decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            if (e.KeyChar.ToString() == decimalSeparator || e.KeyChar == 8 || ((TextBox)control).SelectionLength > 0)
            {
                e.Handled = false;
            }
            else
            {
                if (control.Text.Contains(decimalSeparator))
                {
                    if (cursorPosistion > control.Text.IndexOf(decimalSeparator))
                    {
                        if (control.Text.Substring(control.Text.IndexOf(decimalSeparator) + 1).Length > (noOfPrecisions - 1))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                    else
                    {
                        if (control.Text.Substring(0, (control.Text.IndexOf(decimalSeparator) + 1)).Length > noOfIntegers)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }

                }
                else
                {
                    if (control.Text.Length > (noOfIntegers - 1))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
        }
        #endregion

        #region Validate BagSizes
        public static decimal ValidateBagSize(decimal size)
        {
            decimal value = 1;
            if (size != 0)
                value = size;
            return value;
        }
        #endregion

        //Numeric Validation - Grid
        #region Validate Numbers - Grid

        public static bool ValidateCellValue_Numaric(DataGridView dgvDetail, string sColumnName, DataGridViewCellEventArgs e)
        {
            bool bValue = true;
            decimal dColIndex = e.ColumnIndex;
            decimal dQty = dgvDetail.Columns["Qty"].Index;

            bValue = isCurrency(clsValidate.ValidateGridValue(dgvDetail, sColumnName, e.RowIndex, "A"));
            if (!bValue)
                MessageBox.Show("This Value Must be a number", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return bValue;
        }
        #endregion

        public static bool ValidateSellpriceVsCostPrice(DataGridView dgvDetail)
        {
            bool bStatus = true;
            if (clsConfig.bValidateCostPriceVsSellPrice)
            {
                int iCount = 0;
                string errorItems = "";
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemCode = "";
                    string sItemName = "";
                    decimal dUnitPrice_Sell = 0;
                    decimal dWeightPrice_Sell = 0;
                    decimal dCostPrice = 0;

                    sItemCode = ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                    sItemName = ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
                    dUnitPrice_Sell = ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    dWeightPrice_Sell = ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));

                    tbl_genItemMaster_Pricing oItem = tbl_genItemMaster_Pricing.Select(sItemCode);
                    if (oItem != null)
                    {
                        //clsConfig.sItemCostPriceName_Default = "costPrice"  / "kiloPrice" / "waitedAverageCostPrice" / "highestPurchasCostPrice" / "recentCostPrice"
                        dCostPrice = clsProcessMethods.GetCostPrice(oItem, clsConfig.sItemCostPriceName_Default);
                    }

                    if ((dCostPrice <= dUnitPrice_Sell) || (dCostPrice <= dWeightPrice_Sell))
                        continue;
                    else
                    {
                        errorItems += (sItemCode + " - '" + sItemName) + "'\n";
                        iCount++;
                    }
                }

                if (iCount > 0)
                {
                    MessageBox.Show("Selling Price should be larger than Cost Price in following items : \n" + errorItems, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    bStatus = false;
                }
            }
            return bStatus;
        }

        //Printing

        #region Check Printing Validity
        public static bool CheckPrintingValidity(int iPrintCount)
        {
            bool bOk = true;
            try
            {
                if (iPrintCount > 0)
                {
                    bOk = false;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bOk;
        }
        #endregion

        #region Check Approved Validity
        public static bool CheckAlreadyApproved(bool IsApproved)
        {
            bool bOk = true;
            try
            {
                if (IsApproved)
                {
                    bOk = false;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bOk;
        }
        #endregion

        //Network

        #region Check Validity IP Address
        public static bool CheckValidityIPAddress(string sIPAddress)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //create our Regular Expression object
            Regex check = new Regex(pattern);
            //boolean variable to hold the status
            bool valid = false;
            //check to make sure an ip address was provided
            if (sIPAddress == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(sIPAddress, 0);
            }
            //return the results
            return valid;
        }
        #endregion


        //Supplier

        #region Check Supplier Blacklisted
        public static bool isSupplierBlackListed(string sSupplierID)
        {
            bool rtn = false;
            tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(sSupplierID);
            if (detail != null)
            {
                if (detail.IsBlacklisted)
                {
                    rtn = true;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SupplierIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return rtn;
        }
        #endregion

        #region Check Supplier Suspended
        public static bool isSupplierSuspended(string sSupplierID)
        {
            bool rtn = false;
            tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(sSupplierID);
            if (detail != null)
            {
                if (detail.IsLocked)
                {
                    rtn = true;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SupplierIsSuspended), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return rtn;
        }
        #endregion


        // Production Job

        #region Production JobPre Plan Validation
        public static bool GetProductionJobPrePlanValidation(string ProductionJobID) //not Recomended method
        {
            bool bStatus = false;
            int iDays;
            try
            {
                tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(ProductionJobID);
                if (detail != null)
                {
                    if (detail.IsPrePlaned)
                    {
                        iDays = int.Parse(clsConfig.sProductionJobPrePlanDates);
                        TimeSpan dateDiff = clsSecurity.getServerDateTime() - detail.PlanDate;

                        if (dateDiff.TotalDays >= iDays)
                            bStatus = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bStatus;
        }
        #endregion

        #region Data Grid row get value
        public static string ValidateRowValue(DataRow row, string sColumname, string sDefaultValue)
        {
            try
            {
                if (row[sColumname] != null && row[sColumname].ToString().Length > 0)
                    sDefaultValue = row[sColumname].ToString();
            }
            catch (Exception)
            {
            }
            return sDefaultValue;
        }

        public static decimal ValidateRowValue(DataRow row, string sColumname, decimal dDefaultValue)
        {
            try
            {
                if (row[sColumname] != null && row[sColumname].ToString().Length > 0)
                    dDefaultValue = decimal.Parse(row[sColumname].ToString());
            }
            catch (Exception)
            {
            }
            return dDefaultValue;
        }

        public static bool ValidateRowValue(DataRow row, string sColumname, bool sDefaultValue)
        {
            try
            {
                if (row[sColumname] != null && row[sColumname].ToString().Length > 0)
                    sDefaultValue = bool.Parse(row[sColumname].ToString());
            }
            catch (Exception)
            {
            }
            return sDefaultValue;
        }

        public static DateTime ValidateRowValue(DataRow row, string sColumname, DateTime sDefaultDate)
        {
            try
            {
                if (row[sColumname] != null && row[sColumname].ToString().Length > 0)
                    sDefaultDate = DateTime.Parse(row[sColumname].ToString());
            }
            catch (Exception)
            {
            }
            return sDefaultDate;
        }

        public static int ValidateRowValue(DataRow row, string sColumname, int iDefaultValue)
        {
            try
            {
                if (row[sColumname] != null && row[sColumname].ToString().Length > 0)
                    iDefaultValue = int.Parse(row[sColumname].ToString());
            }
            catch (Exception)
            {
            }
            return iDefaultValue;
        }
        #endregion
        //Grid

        #region Validate Datagrid Tag/Value
        //value string
        public static string ValidateGridTag(DataGridView dgvDataGrid, string sColumname, int iRowIndex, string sDefaultValue)
        {
            string value = sDefaultValue;
            if (dgvDataGrid[sColumname, iRowIndex].Tag != null && dgvDataGrid[sColumname, iRowIndex].Tag.ToString().Length > 0)
                value = dgvDataGrid[sColumname, iRowIndex].Tag.ToString();
            return value;
        }
        public static string ValidateGridValue(DataGridView dgvDataGrid, string sColumname, int iRowIndex, string sDefaultValue)
        {
            string value = sDefaultValue;
            if (dgvDataGrid.Columns.Contains(sColumname))
                if (dgvDataGrid[sColumname, iRowIndex].Value != null && dgvDataGrid[sColumname, iRowIndex].Value.ToString().Length > 0)
                    value = dgvDataGrid[sColumname, iRowIndex].Value.ToString();
            return value;
        }


        public static bool ValidateRowValue(DataGridViewRow row, string sColumname, bool sDefaultValue)
        {
            bool value = sDefaultValue;
            if (row.Cells[sColumname] != null && row.Cells[sColumname].ToString().Length > 0)
            {
                string ds = row.Cells[sColumname].Value.ToString();
                value = bool.Parse(row.Cells[sColumname].Value.ToString());
            }

            return value;
        }



        //value DateTime
        public static DateTime ValidateGridTag(DataGridView dgvDataGrid, string sColumname, int iRowIndex, DateTime sDefaultDate)
        {
            DateTime value = sDefaultDate;
            if (dgvDataGrid[sColumname, iRowIndex].Tag != null && dgvDataGrid[sColumname, iRowIndex].Tag.ToString().Length > 0)
                value = DateTime.Parse(dgvDataGrid[sColumname, iRowIndex].Tag.ToString());
            return value;
        }
        public static DateTime ValidateGridValue(DataGridView dgvDataGrid, string sColumname, int iRowIndex, DateTime sDefaultDate)
        {
            DateTime value = sDefaultDate;
            if (dgvDataGrid[sColumname, iRowIndex].Value != null && dgvDataGrid[sColumname, iRowIndex].Value.ToString().Length > 0)
                value = DateTime.Parse(dgvDataGrid[sColumname, iRowIndex].Value.ToString());
            return value;
        }
        public static DateTime ValidateGridValueTryPhase(DataGridView dgvDataGrid, string sColumname, int iRowIndex, DateTime sDefaultDate)
        {
            DateTime value = sDefaultDate;
            if (dgvDataGrid[sColumname, iRowIndex].Value != null && dgvDataGrid[sColumname, iRowIndex].Value.ToString().Length > 0)
                DateTime.TryParse(dgvDataGrid[sColumname, iRowIndex].Value.ToString(), out value);
            return value;
        }
        public static DateTime ValidateGridValueExactDate(DataGridView dgvDataGrid, string sColumname, int iRowIndex, DateTime sDefaultDate)
        {
            DateTime value = sDefaultDate;
            string format = "dd/MM/yyyy";
            if (dgvDataGrid[sColumname, iRowIndex].Value != null && dgvDataGrid[sColumname, iRowIndex].Value.ToString().Length > 0)
                value = DateTime.ParseExact(dgvDataGrid[sColumname, iRowIndex].Value.ToString(), format, CultureInfo.InvariantCulture);
            return value;
        }


        //value bool
        public static bool ValidateGridTag(DataGridView dgvDataGrid, string sColumname, int iRowIndex, bool sDefaultValue)
        {
            bool value = false;
            if (dgvDataGrid[sColumname, iRowIndex].Tag != null && dgvDataGrid[sColumname, iRowIndex].Tag.ToString().Length > 0)
                value = bool.Parse(dgvDataGrid[sColumname, iRowIndex].Tag.ToString());
            return value;
        }
        public static bool ValidateGridValue(DataGridView dgvDataGrid, string sColumname, int iRowIndex, bool sDefaultValue)
        {
            bool value = false;
            if (dgvDataGrid[sColumname, iRowIndex].Value != null && dgvDataGrid[sColumname, iRowIndex].Value.ToString().Length > 0)
                value = bool.Parse(dgvDataGrid[sColumname, iRowIndex].Value.ToString());
            return value;
        }


        //value int
        public static int ValidateGridTag(DataGridView dgvDataGrid, string sColumname, int iRowIndex, int sDefaultValue)
        {
            int value = sDefaultValue;
            if (dgvDataGrid[sColumname, iRowIndex].Tag != null && isCurrency(dgvDataGrid[sColumname, iRowIndex].Tag.ToString()))
                value = int.Parse(dgvDataGrid[sColumname, iRowIndex].Tag.ToString());
            return value;
        }
        public static int ValidateGridValue(DataGridView dgvDataGrid, string sColumname, int iRowIndex, int sDefaultValue)
        {
            int value = sDefaultValue;
            if (dgvDataGrid[sColumname, iRowIndex].Value != null && isCurrency(dgvDataGrid[sColumname, iRowIndex].Value.ToString()))
                value = int.Parse(dgvDataGrid[sColumname, iRowIndex].Value.ToString());
            return value;
        }

        //decimal
        public static decimal ValidateGridTag(DataGridView dgvDataGrid, string sColumname, int iRowIndex, decimal sDefaultValue)
        {
            decimal value = sDefaultValue;
            if (dgvDataGrid[sColumname, iRowIndex].Tag != null && isCurrency(dgvDataGrid[sColumname, iRowIndex].Tag.ToString()))
                value = decimal.Parse(dgvDataGrid[sColumname, iRowIndex].Tag.ToString());
            return value;
        }
        public static decimal ValidateGridValue(DataGridView dgvDataGrid, string sColumname, int iRowIndex, decimal sDefaultValue)
        {
            decimal value = 0;
            if (dgvDataGrid.Columns.Contains(sColumname))
                if (dgvDataGrid[sColumname, iRowIndex].Value != null && isCurrency(dgvDataGrid[sColumname, iRowIndex].Value.ToString()))
                    value = decimal.Parse(dgvDataGrid[sColumname, iRowIndex].Value.ToString());
            return value;
        }




        #endregion

        //Validate Grid Count
        #region Check Validate Grid Count
        public static bool CheckGridCountValidity(int GridRowCount, int iFormID)
        {
            bool bStatus = false;
            try
            {
                if (GridRowCount > 0)
                    bStatus = true;
                else
                    MessageBox.Show("Please add items before saving the transaction…!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                WriteErrorLog("", iFormID, ex);
            }
            return bStatus;
        }

        #endregion

        //Date  

        #region Validate Process Note Back Date
        public static bool ValidateProcessNoteBackDate(int iProcessNoteID, DateTime dt)
        {
            bool bValue = false;
            tbl_securityDateSettings detail = tbl_securityDateSettings.Select(iProcessNoteID);
            if (detail != null)
            {
                if (detail.IsEnable)
                {
                    if (clsSecurity.getServerDateTime().AddDays(-detail.MaxDaysBackword) > dt)
                    {
                        bValue = true;
                    }
                }
                else
                    bValue = true;
            }
            else
                bValue = true;
            return bValue;
        }
        #endregion

        #region Validate Process Note Forward Date
        public static bool ValidateProcessNoteForwardDate(int iProcessNoteID, DateTime dt)
        {
            bool bValue = false;
            tbl_securityDateSettings detail = tbl_securityDateSettings.Select(iProcessNoteID);
            if (detail != null)
            {
                if (detail.IsEnable)
                {
                    if (clsSecurity.getServerDateTime().AddDays(detail.MaxDaysForward) < dt)
                    {
                        bValue = true;
                    }
                }
                else
                    bValue = true;
            }
            else
                bValue = true;
            return bValue;
        }
        #endregion


        //Text Box

        #region Delimal Validate
        public static decimal DecimalValidate(Control txtBox)
        {
            decimal value = 0;
            if (txtBox != null && txtBox.Text.Length > 0 && isCurrency(txtBox.Text.Trim()))
                value = decimal.Parse(txtBox.Text.Trim());
            return value;
        }
        #endregion

        #region Validate TextBox    

        public static bool ValidateTextBox_EmptyValue(TextBox txtBox, string sMessage)
        {
            bool bValue = true;
            Color colBack = txtBox.BackColor;
            if (txtBox.Text.Trim().Length == 0)
            {
                bValue = false;
                txtBox.Focus();
                txtBox.BackColor = Color.FromArgb(250, 244, 133);
            }

            if (bValue == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, sMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBox.BackColor = colBack;
            }
            return bValue;
        }
        #endregion

        #region Validate TextBox
        public static bool ValidateTextBox_Tag_CannotBeEmptyOrDefault(TextBox txtBox, string sMessage)
        {
            bool bValue = true;
            Color colBack = txtBox.BackColor;
            if (txtBox.Tag == null || txtBox.Tag.ToString().Length == 0 || txtBox.Tag.ToString().Trim() == "default")
            {
                bValue = false;
                txtBox.Focus();
                txtBox.BackColor = Color.FromArgb(250, 244, 133);
            }

            if (bValue == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, sMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBox.BackColor = colBack;
            }
            return bValue;
        }
        #endregion

        public static bool ValidateComboBox_Value(System.Windows.Forms.ComboBox cmbBox, string sMessage)
        {
            bool bValue = true;
            Color colBack = cmbBox.BackColor;
            object s = cmbBox.SelectedItem;
            if (cmbBox.SelectedValue == null || cmbBox.SelectedIndex == -1 || cmbBox.SelectedItem == "default" || cmbBox.SelectedValue == "default")
            {
                bValue = false;
                cmbBox.Focus();
                cmbBox.BackColor = Color.FromArgb(250, 244, 133);
            }

            if (bValue == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, sMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBox.BackColor = colBack;
            }
            return bValue;
        }

        public static bool ValidateComboBox_Value_CannotBeEmptyOrDefault(System.Windows.Forms.ComboBox cmbBox, string sMessage)
        {
            bool bValue = true;
            Color colBack = cmbBox.BackColor;
            object s = cmbBox.SelectedItem;
            if (((ComboBoxItem)s).Value == null || cmbBox.SelectedIndex == -1 || ((ComboBoxItem)s).Value == "default")
            {
                bValue = false;
                cmbBox.Focus();
                cmbBox.BackColor = Color.FromArgb(250, 244, 133);
            }

            if (bValue == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, sMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBox.BackColor = colBack;
            }
            return bValue;
        }

        //Item

        #region Validate Item Code
        public static bool Validate_ItemCode(ref TextBox txtItemCode, ref TextBox txtItemCategory, ref TextBox TxtItemSerialNo)
        {
            bool bValue = false;
            tbl_genItemMaster oItem = tbl_genItemMaster.Select(txtItemCode.Text.Trim());
            if (oItem != null && oItem.Item_ID != "default")
            {
                if (!oItem.IsDeleted)
                {
                    txtItemCode.Tag = oItem.Item_ID;
                    txtItemCode.Text = oItem.ItemName;

                    txtItemCategory.Tag = "default";
                    txtItemCategory.Text = "default";
                    TxtItemSerialNo.Tag = "0";
                    TxtItemSerialNo.Text = "0";
                    bValue = true;
                }
                else
                    MessageBox.Show("Invalid Item Code, Item is Already Deleted from the System", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Invalid Item Code, Please Type a Correct Item Code and Press Enter Again", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            return bValue;
        }
        #endregion

        public static bool Validate_CustomerWise_ItemPricing_Enable(string sCustomerID, string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2)
        {
            bool bCustomerPricingValid = false;
            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
            if (oCustomer != null && oCustomer.Customer_ID != "default")
            {
                if (oCustomer.ItemPriceMode == (int)enum_CustomerPrice_Mode.Customer_Wise_Price)
                {
                    foreach (tbl_genItemMaster_Finance_Customer oFin in tbl_genItemMaster_Finance_Customer.SelectAllByCustomer_ID(oCustomer.Customer_ID))
                    {
                        if (sItemSubCategoryID == oFin.ItemSubCategory_ID && sItemSubCategoryID2 == oFin.ItemSubCategory2_ID && sSerialNo == oFin.ItemSerialNo && sSerialNo2 == oFin.ItemSerialNo2)
                        {
                            bCustomerPricingValid = true;
                            break;
                        }
                    }
                }

                else if (oCustomer.ItemPriceMode == (int)enum_CustomerPrice_Mode.Customer_Wise_PriceCategory)
                {
                    if (oCustomer.ItemPriceCategory.Length > 0 && oCustomer.ItemPriceCategory != "default")

                        bCustomerPricingValid = true;
                }

                else
                    bCustomerPricingValid = true;
            }

            if (!bCustomerPricingValid)
                MessageBox.Show("Item doesn't have a Valid Item Price (This Customer has enabled Customer-Wise Pricing or Pricing Category) \nPlease Add Customer-Wise Price for This Item or assign a price category", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bCustomerPricingValid;
        }

        public static bool isCurrency(string val)
        {
            Double result;
            return Double.TryParse(val, System.Globalization.NumberStyles.Currency,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public static bool IsValiedItemType(string sItemType_ID)
        {
            bool bStatus = false;

            List<string> lstItemTypes = new List<string>();
            lstItemTypes.Add("ITP/001");
            lstItemTypes.Add("ITP/004");
            lstItemTypes.Add("ITP/008");
            lstItemTypes.Add("ITP/009");
            lstItemTypes.Add("ITP/010");
            lstItemTypes.Add("ITP/011");
            lstItemTypes.Add("ITP/012");
            lstItemTypes.Add("ITP/027");
            lstItemTypes.Add("ITP/028");
            lstItemTypes.Add("ITP/029");
            lstItemTypes.Add("ITP/030");
            lstItemTypes.Add("ITP/031");
            lstItemTypes.Add("ITP/032");
            lstItemTypes.Add("ITP/033");
            lstItemTypes.Add("ITP/034");
            lstItemTypes.Add("ITP/035");

            foreach (string item in lstItemTypes.Where(p => p == sItemType_ID))
            {
                bStatus = true;
                break;
            }
            return bStatus;
        }

        public static bool Check_AcceptedFGQty_ProdApparel(string sCO_ID, string sFinishedGood_ID, decimal dDO_Qty)
        {
            bool bResult = true;
            decimal dAcceptedQty_Batches = 0;

            bool bIsProductionLinked_CO = false;
            foreach (tbl_prodTxBatch oApparel_Btach in tbl_prodTxBatch.SelectAllByCustomerOrder_ID(sCO_ID).Where(r => !r.IsCanceled && r.Item_ID == sFinishedGood_ID))
            {
                bIsProductionLinked_CO = true;
                foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oApparel_Acceptance in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByProdBatch_ID(oApparel_Btach.ProdBatch_ID))
                {
                    //add by janith 2018-10-03
                    tbl_prodTxFinishedGoodTransferAcceptance oAcceptance = tbl_prodTxFinishedGoodTransferAcceptance.Select(oApparel_Acceptance.Acceptance_ID);
                    if (oAcceptance != null && oAcceptance.IsApproved && !oAcceptance.IsCanceled)
                        dAcceptedQty_Batches += oApparel_Acceptance.AcceptanceQty;
                }
            }
            if ((dDO_Qty > dAcceptedQty_Batches) && bIsProductionLinked_CO)
            {
                bResult = false;
                MessageBox.Show("Approved FGTN Accepted Quantity for \nItem :\"" + clsGenaralName.getName_Item(sFinishedGood_ID) + "\" is less than DO Qty.\nAvailable Accepted quantity is " + clsFormatter.FormatDecimalPlaces_Quantity(dAcceptedQty_Batches) +
                    " " + clsGenaralName.getName_ItemUOMName(sFinishedGood_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return bResult;
        }

        //Transaction Code Length
        public static bool CheckValidity_TransactionCodeLength(string sTx_ID)
        {
            bool bStatus = false;
            if (sTx_ID.Trim().Length > 0 && !sTx_ID.Contains("<Auto Generate>"))
            {
                int iTxCode_Length = sTx_ID.Trim().Length;

                if (iTxCode_Length >= clsConfig.iTransactionId_MinLength &&
                    iTxCode_Length <= clsConfig.iTransactionId_MaxLength)
                {
                    bStatus = true;
                }
                else
                {
                    MessageBox.Show(
                        "Please make sure length of the transaction Id should be more than " + clsConfig.iTransactionId_MinLength + " characters and less than " + clsConfig.iTransactionId_MaxLength + " characters",
                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("Transaction " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bStatus;
        }

        public static bool CheckValidity_StockQty(string sStore_ID, string sItem_ID, string sItemName, DateTime dtmTxDate, decimal dCurrentQty, decimal dPrvQty)
        {
            bool bReturn = false;
            decimal dTotalAvailableQty = 0;
            try
            {
                DataTable dtResult = DBHandling.ExecQuery("select * from [dbo].[func_StoreStock]('" + dtmTxDate.ToString("yyyy-MM-dd") + "', '" + sItem_ID + "', '0', '" + sStore_ID + "', '0')").Tables[0];
                if (dtResult != null && dtResult.Rows.Count > 0)
                    dTotalAvailableQty = decimal.Parse(dtResult.AsEnumerable().Sum(x => x.Field<decimal>("qty")).ToString());

                if ((dTotalAvailableQty + dPrvQty) >= dCurrentQty)
                {
                    bReturn = true;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(sItemName + " (" + sItem_ID + ") has " + (dTotalAvailableQty + dPrvQty) + " only. \nStock will be going minus... ", "Are you sure to continue...?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        bReturn = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        bReturn = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong...\n" + ex.Message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return bReturn;
        }
    }

    public class ComboBoxItem
    {
        public string Value;
        public string Text;

        public ComboBoxItem(string val, string text)
        {
            Value = val;
            Text = text;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}