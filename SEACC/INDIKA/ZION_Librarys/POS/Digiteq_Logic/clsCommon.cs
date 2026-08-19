using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using DataTire;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Digiteq_Logic
{
    public class clsCommon
    {
        #region General Values
        public static string SoftwareVersion = "";
      //  public static string CompanyName = "";
        public static string CompanyAddress1 = "";
        public static string CompanyAddress2 = "";

        public static Font defaultFont = new Font("Calibiri", 6, FontStyle.Bold);
        public static bool isTrunk = false;
        public static Color ColourForLockedRecord = Color.DarkRed;
        public static System.Diagnostics.Process oskProcess = null;
        #endregion

        #region General functions
        public static bool isCurrency(string val)
        {
            Double result;
            return Double.TryParse(val, System.Globalization.NumberStyles.Currency,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }
        public static bool isValueZero(string val)
        {
            if (val.Length > 0)
            {
                double dValue = double.Parse(val);
                if (dValue != 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static string RemoveNewLinestring(string sTemp)
        {
            string s = sTemp.Replace("\n", "").Trim();
            return s.Replace("\r", "").Trim();
        }
        public static string fncsetstring(string sTemp)
        {
            return "'" + sTemp.Replace("'", "''").Trim() + "'";
        }

        public static string fncsetdate(DateTime sTemp)
        {
            return "'" + sTemp.Year.ToString() + sTemp.Month.ToString().PadLeft(2, '0') +
                            sTemp.Day.ToString().PadLeft(2, '0') + " " + "00" + ":" +
                            "00" + ":" + "00" + "'";
        }

        public static string fncsetdatewotime(DateTime sTemp)
        {
            return "'" + sTemp.Year.ToString() + sTemp.Month.ToString().PadLeft(2, '0') +
                            sTemp.Day.ToString().PadLeft(2, '0') + "'";
        }

        public static string fncsetdatetime(DateTime sTemp)
        {
            return "'" + sTemp.Year.ToString() + sTemp.Month.ToString().PadLeft(2, '0') +
                            sTemp.Day.ToString().PadLeft(2, '0') + " " + sTemp.Hour.ToString().PadLeft(2, '0') + ":" +
                            sTemp.Minute.ToString().PadLeft(2, '0') + ":" + sTemp.Second.ToString().PadLeft(2, '0') + ":" + sTemp.Millisecond.ToString().PadLeft(3, '0') + "'";

        }

        public static bool IsLastRawEmpty(DataGridView dgv, int iLastRaw)
        {
            bool value = false;
            if (dgv[1, iLastRaw].Value == null || dgv[1, iLastRaw].Value.ToString().Length <= 0)
                value = true;
            return value;
        }
        public static bool IsCustomerizedGrid()
        {
            bool value = false;
            tbl_securtiyConfigActive detail = tbl_securtiyConfigActive.Select(clsAutocode.getConfigActiveID(ConfigActiveValue.DisplayCustormizedGrid));
            if (detail != null)
                value = detail.IsActive;
            return value;
        }
 
        public static int getDaysUptoDate(DateTime FromDate)
        {
            int days = 0;
            TimeSpan tsp = clsSecurity.getServerDateTime().Date - FromDate.Date;
            days = tsp.Days;
            return days;
        }
        public static int getDays(DateTime FromDate, DateTime ToDate)
        {
            int days = 0;
            TimeSpan tsp = ToDate.Date - FromDate.Date;
            days = tsp.Days;
            return days;
        }
        #endregion        

        #region Registry Area
        private static string regDBUserName;
        private static string regDBUserPassword;
        private static string regDatabaseName;
        private static string regServerName;
        private static string regOutlet;
        private static string regTerminal;

        private static string regCompanyName;
        private static string regValied;
        private static string regRegistryName = "Software\\52465123-sys\\456465465461312313111321";// + "1212";
        private static string regDomainName;

        #endregion



        #region Validate Foreign Key Area
        public static void ValidateForeignKey(ref TextBox tbox)
        {
            if (tbox.Tag == null || tbox.Tag.ToString().Length <= 0)
                tbox.Tag = "default";
        }

        public static void ValidateForeignKey(ref string str)
        {
            if (String.IsNullOrEmpty(str) == true)
                str = "default";
        }

        public static void ValidateForeignKey(ref TextBox tbox, string sReturnValue)
        {
            if (tbox.Tag == null || tbox.Tag.ToString().Length <= 0)
                tbox.Tag = sReturnValue;
        }
        public static void ValidateForeignKey(ref TextBox tbox, int sReturnValue)
        {
            if (tbox.Tag == null || tbox.Tag.ToString().Length <= 0)
                tbox.Tag = sReturnValue;
        }

        public static void ValidateForeignKey(ref Label lbl)
        {
            if (lbl.Tag == null || lbl.Tag.ToString().Length <= 0 || lbl.Text.Trim() == "-")
                lbl.Tag = "default";
        }
        public static bool isForeignKeyIsDefault(string sForeignKey)
        {
            bool value = false;
            if (sForeignKey.Trim().ToUpper() == "DEFAULT")
                value = true;
            return value;
        }


        public static string GetForeignKeyValue(string sForeignKey)
        {
            string value = "";
            if (!clsCommon.isForeignKeyIsDefault(sForeignKey))
                value = sForeignKey;
            return value;
        }
        public static string GetForeignKeyValueNone(string sForeignKey)
        {
            string value = "None";
            if (!clsCommon.isForeignKeyIsDefault(sForeignKey))
                value = sForeignKey;
            return value;
        }
        #endregion

        #region Validate Item Subcategories and Serial Nos
        public static void ValidateItemSubCategoryAndSerialNo(ref TextBox txtboxSubCategory, ref TextBox textboxSerialNo, string sSerialReturnValue)
        {
            if (txtboxSubCategory.Tag == null || txtboxSubCategory.Tag.ToString().Length <= 0)
                txtboxSubCategory.Tag = "default";
            if (txtboxSubCategory.Text.Trim().Length <= 0)
                txtboxSubCategory.Text = "default";

            if (textboxSerialNo.Tag == null || textboxSerialNo.Tag.ToString().Length <= 0)
                textboxSerialNo.Tag = sSerialReturnValue;
            if (textboxSerialNo.Text.Trim().Length <= 0)
                textboxSerialNo.Text = sSerialReturnValue;

        }
        #endregion

        #region Set Enable/Disable Area
        public static void SetEnableDisable_NormalTextbox(TextBox myTextBox, bool bEnable)
        {
            if (bEnable)
            {
                myTextBox.Enabled = true;
                myTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else
            {
                myTextBox.Enabled = false;
                myTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        public static void SetEnableDisable_NormalLabel(Label myLabel, bool bEnable)
        {
            if (bEnable)
            {
                //myLabel.ForeColor = Color.FromArgb(99, 50, 50);
                myLabel.ForeColor = Color.Black;
            }
            else
            {
                myLabel.ForeColor = Color.Gray;
            }
        }
        public static void SetEnableDisable_NormalCheckBox(CheckBox myCheckBox, bool bEnable)
        {
            if (bEnable)
                myCheckBox.Enabled = true;
            else
                myCheckBox.Enabled = false;
        }
        public static void SetEnableDisable_NormalPannl(Panel myPanel, bool bEnable)
        {
            if (bEnable)
                myPanel.Enabled = true;
            else
                myPanel.Enabled = false;
        }
        public static void SetEnableDisable_NormalRadioButton(RadioButton myRadioButton, bool bEnable)
        {
            if (bEnable)
            {
                myRadioButton.ForeColor = Color.FromArgb(99, 50, 50);
                myRadioButton.Enabled = true; ;
            }
            else
            {
                myRadioButton.ForeColor = Color.Gray;
                myRadioButton.Enabled = false;
            }
        }
        public static void SetEnableDisable_NormalDateTimePicker(DateTimePicker myDateTimePicker, bool bEnable)
        {
            if (bEnable)
            {
                myDateTimePicker.ForeColor = Color.FromArgb(99, 50, 50);
                myDateTimePicker.Enabled = true;
            }
            else
            {
                myDateTimePicker.ForeColor = Color.Gray;
                myDateTimePicker.Enabled = false;
            }
        }

        public static void SetEnableDisable_PrimaryKeyTextbox(TextBox myTextBox, bool bEnable)
        {
            if (bEnable)
            {
                myTextBox.Enabled = true;
                //myTextBox.BackColor = Color.FromArgb(211, 173, 173);
                myTextBox.BackColor = Color.DarkGray;
            }
            else
            {
                myTextBox.Enabled = false;
                myTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        public static void SetEnableDisable_ForeignKeyTextboxOptional(TextBox myTextBox, bool bEnable)
        {
            myTextBox.ReadOnly = true;
            if (bEnable)
            {
                myTextBox.Enabled = true;
                myTextBox.BackColor = Color.LightGray;
            }
            else
            {
                myTextBox.Enabled = false;
                myTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        public static void SetEnableDisable_ForeignKeyTextboxMust(TextBox myTextBox, bool bEnable)
        {
            if (bEnable)
            {
                myTextBox.Enabled = true;
                //myTextBox.BackColor = Color.FromArgb(211, 200, 200);
                myTextBox.BackColor = Color.LightGray;
            }
            else
            {
                myTextBox.Enabled = false;
                myTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        public static void SetVisible_PermissionTextBox(TextBox myTextBox, bool bVisible)
        {
            if (bVisible)
            {
                myTextBox.Visible = true;
                myTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else
            {
                myTextBox.Visible = false;
                myTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        public static void SetEnableDisable_NormalComboBox(ComboBox myComboBox, bool bEnable)
        {
            if (bEnable)
            {
                myComboBox.Enabled = true;
                myComboBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else
            {
                myComboBox.Enabled = false;
                myComboBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }
        #endregion

        #region Set Visibility Area
        public static void SetVisibility_Panel(Panel myPanel, bool bEnable)
        {
            if (bEnable)
                myPanel.Visible = true;
            else
                myPanel.Visible = false;
        } 
        #endregion

        #region Get Tax Values
        public static decimal getPesentageVAT()
        {
            decimal value = 0;
            tbl_zTax tax = tbl_zTax.Select("TAX/001");
            if (tax != null)
                value = tax.TaxPesentage;
            return value;
        }
        public static decimal getPesentageNBT()
        {
            decimal value = 0;
            tbl_zTax tax = tbl_zTax.Select("TAX/002");
            if (tax != null)
                value = tax.TaxPesentage;
            return value;
        }
        public static decimal getPesentageOtherTax()
        {
            decimal value = 0;
            tbl_zTax tax = tbl_zTax.Select("TAX/003");
            if (tax != null)
                value = tax.TaxPesentage;
            return value;
        }
        #endregion

        #region Get Currency Rate
        public static decimal getCurrencyRate(string sCurrencyID)
        {
            decimal dExRate = 1;
            if (sCurrencyID.Length > 0)
            {
                tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                if (currency != null)
                {
                    dExRate = currency.CurrencyRate;
                }
            }
            return dExRate;
        }
        #endregion

        #region Get Company Details
        public static byte[] getCompanyImage()
        {
            byte[] sCompanyImage = null;
            tbl_genCompanyImage comI = tbl_genCompanyImage.Select(clsSecurity.CompanyID);
            if (comI != null)
                sCompanyImage = comI.MainLogo;

            return sCompanyImage;
        }


        public static string getCompanyVAT()
        {
            string VAT = "";
            tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            if (com != null)
                VAT = com.VatRegisterNo;

            return VAT;
        }
        public static string getCompanyNBT()
        {
            string NBT = "";
            tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            if (com != null)
                NBT = com.CompanyMDName;

            return NBT;
        }

        public static string getCompanySVAT()
        {
            string SVAT = "";
            tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            if (com != null)
                SVAT = com.MdTelephone;

            return SVAT;
        }
        public static string getCompanyEmail()
        {
            string Email = "";
            tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            if (com != null)
                Email = com.Email;

            return Email;
        }
        public static string getCompanyWeb()
        {
            string Web = "";
            tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            if (com != null)
                Web = com.Url;

            return Web;
        }
        public static string getCompanyBusinessRegisterNo()
        {
            string BusinessRegisterNo = "";
            tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
            if (com != null)
                BusinessRegisterNo = com.BusinessRegisterNo;

            return BusinessRegisterNo;
        }
        #endregion

        #region Currency To Word
        /// <summary>
        /// Create For Convert Decimal Value To Words
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// 
        public static string CurrencyToWord(decimal Curr)
        {
            string decimalPlace = "", Value = "";// Value = "Rupees ";
            int des = 0;

            decimalPlace = Convert.ToString(Curr - Math.Floor(Curr));
            if (decimalPlace.Length >= 2)
                des = Convert.ToInt32(decimalPlace.Substring(2));

            Value += NumberToWords(Convert.ToInt32(decimal.Truncate(Curr)));

            if (des > 0)
                Value += " and Cents " + NumberToWords(des);

            return Value + " Only";
        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        #endregion

        #region Validate Values
        public static void ValidateDeciamlValue(ref TextBox tbox)
        {
            if (tbox.Text.Trim().Length <= 0)
                tbox.Text = "0.00";
        }

        public static void ValidateIntegerlValue(ref TextBox tbox)
        {
            if (tbox.Text.Trim().Length <= 0)
                tbox.Text = "0";
        }
        #endregion

        #region Combine Date and Time
        public static DateTime CombineDateAndTime(string sDate, string sTime)
        {
            DateTime rtnVal = clsSecurity.getServerDateTime();
            try
            {
                rtnVal = DateTime.Parse(sDate + " " + sTime);
            }
            catch (Exception)
            {
                return rtnVal;
            }
            return rtnVal;
        }
        #endregion

        #region Get Telephone Fax Customer/Supplier
        public static string getCustomerTelephoneAndFax(string CustomerID)
        {
            string sTelephoneFax = "";
            tbl_genCustomerMaster Cus = tbl_genCustomerMaster.Select(CustomerID);
            if (Cus != null)
            {
                if (Cus.Telephone.Trim().Length > 0 || Cus.Fax.Trim().Length > 0)
                {
                    sTelephoneFax = (Cus.Telephone.Trim().Length > 0) ? Cus.Telephone : "N/A";
                    sTelephoneFax += " / ";
                    sTelephoneFax += (Cus.Telephone.Trim().Length > 0) ? Cus.Telephone : "N/A";
                }
                else
                    sTelephoneFax = "N/A";
            }
            return sTelephoneFax;
        }

        public static string getSupplerTelephoneAndFax(string CustomerID)
        {
            string sTelephoneFax = "";
            tbl_genSupplierMaster Cus = tbl_genSupplierMaster.Select(CustomerID);
            if (Cus != null)
            {
                sTelephoneFax = Cus.Telephone + "  /  " + Cus.Fax;
            }
            return sTelephoneFax;
        }
        #endregion

       

        #region Get Employee Code n Reference No
        public static void getEmployeeCodeAndName_ByRefereceNo(string sRefNo_ID, ref string sEmpCode, ref string sEmpName)
        {
            tbl_zOrderRefNo oOrDetail = tbl_zOrderRefNo.Select(sRefNo_ID);
            if (oOrDetail != null && oOrDetail.OrderRefNo_ID != "default")
            {
                sEmpCode = oOrDetail.Employee_ID;
                sEmpName = clsGenaralName.getName_Employee(oOrDetail.Employee_ID);
            }
        } 
        #endregion

        #region Check Supplier n Customer Types
        public static bool isLocalCustomer(string sCustomerID)
        {
            bool bStatus = false;
            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
            if (oCustomer != null)
            {
                if (oCustomer.CustomerType_ID == "1")
                    bStatus = true;
            }
            return bStatus;
        }

        public static bool isLocalSupplier(string sSupplier)
        {
            bool bStatus = false;
            tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(sSupplier);
            if (oSupplier != null)
            {
                if (oSupplier.SupplierType_ID == "1")
                    bStatus = true;
            }
            return bStatus;
        } 
        #endregion

        #region get Month ID
        public static int getMonthID(DateTime dtmTransactiondate)
        {
            return int.Parse(dtmTransactiondate.Year.ToString() + (dtmTransactiondate.Month < 10 ? "0" : "") + dtmTransactiondate.Month.ToString());
        }
        #endregion


       

        #region Data Tables Using Item Grouped
        public static DataTable DataGridViewToDataTable_ItemGrouped(DataGridView dgvDetail)
        {
            DataTable dt_In = new DataTable();
            dt_In.Columns.Add("ItemCode");
            dt_In.Columns.Add("InquiryCode");
            dt_In.Columns.Add("ItemStatus");
            dt_In.Columns.Add("JobCode");
            dt_In.Columns.Add("Quantity");
            dt_In.Columns.Add("Weight");
            dt_In.Columns.Add("ItemSubCategoryID");
            dt_In.Columns.Add("ItemSubCategoryID2");
            dt_In.Columns.Add("ItemSerialNo");
            dt_In.Columns.Add("ItemSerialNo2");
            dt_In.Columns.Add("CusOrderCode");
            dt_In.Columns.Add("DeliveryOrderCode");

            DataTable dt_Out = new DataTable();
            dt_Out.Columns.Add("ItemCode");
            dt_Out.Columns.Add("InquiryCode");
            dt_Out.Columns.Add("ItemStatus");
            dt_Out.Columns.Add("JobCode");
            dt_Out.Columns.Add("Quantity");
            dt_Out.Columns.Add("Weight");
            dt_Out.Columns.Add("ItemSubCategoryID");
            dt_Out.Columns.Add("ItemSubCategoryID2");
            dt_Out.Columns.Add("ItemSerialNo");
            dt_Out.Columns.Add("ItemSerialNo2");
            dt_Out.Columns.Add("CusOrderCode");
            dt_Out.Columns.Add("DeliveryOrderCode");

            foreach (DataGridViewRow row in dgvDetail.Rows)
                dt_In.Rows.Add(clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, ""),
                    clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, ""),
                    clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00")),
                    clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00")),
                    clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default"),
                    clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0"),
                    clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0"),
                    clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default")
                    );

            var newResults = from row in dt_In.AsEnumerable()
                             group row by new { ItemCode = row.Field<string>("ItemCode"), InquiryCode = row.Field<string>("InquiryCode"), ItemStatus = row.Field<string>("ItemStatus"), JobCode = row.Field<string>("JobCode"), ItemSubCategoryID = row.Field<string>("ItemSubCategoryID"), ItemSubCategoryID2 = row.Field<string>("ItemSubCategoryID2"), ItemSerialNo = row.Field<string>("ItemSerialNo"), ItemSerialNo2 = row.Field<string>("ItemSerialNo2"), CusOrderCode = row.Field<string>("CusOrderCode"), DeliveryOrderCode = row.Field<string>("DeliveryOrderCode") } into grp
                             select new
                             {
                                 ItemCode = grp.Key.ItemCode,
                                 InquiryCode = grp.Key.InquiryCode,
                                 ItemStatus = grp.Key.ItemStatus,
                                 JobCode = grp.Key.JobCode,
                                 Quantity = grp.Sum((r) => decimal.Parse(r["Quantity"].ToString())),
                                 Weight = grp.Sum((r) => decimal.Parse(r["Weight"].ToString())),
                                 ItemSubCategoryID = grp.Key.ItemSubCategoryID,
                                 ItemSubCategoryID2 = grp.Key.ItemSubCategoryID2,
                                 ItemSerialNo = grp.Key.ItemSerialNo,
                                 ItemSerialNo2 = grp.Key.ItemSerialNo2,
                                 CusOrderCode = grp.Key.CusOrderCode,
                                 DeliveryOrderCode = grp.Key.DeliveryOrderCode
                             };


            foreach (var record in newResults)
                dt_Out.Rows.Add(record.ItemCode, record.InquiryCode, record.ItemStatus, record.JobCode, record.Quantity, record.Weight, record.ItemSubCategoryID, record.ItemSubCategoryID2, record.ItemSerialNo, record.ItemSerialNo2, record.CusOrderCode, record.DeliveryOrderCode);

            return dt_Out;
        }

        public static DataTable DataGridViewToDataTable_ItemGrouped_CategoryID1(DataGridView dgvDetail)
        {
            DataTable dt_In = new DataTable();
            dt_In.Columns.Add("ItemCode");
            dt_In.Columns.Add("InquiryCode");
            dt_In.Columns.Add("ItemStatus");
            dt_In.Columns.Add("JobCode");
            dt_In.Columns.Add("Quantity");
            dt_In.Columns.Add("Weight");
            dt_In.Columns.Add("ItemSubCategoryID1");
            dt_In.Columns.Add("ItemSubCategoryID2");
            dt_In.Columns.Add("ItemSerialNo");
            dt_In.Columns.Add("ItemSerialNo2");
            dt_In.Columns.Add("CusOrderCode");
            dt_In.Columns.Add("DeliveryOrderCode");

            DataTable dt_Out = new DataTable();
            dt_Out.Columns.Add("ItemCode");
            dt_Out.Columns.Add("InquiryCode");
            dt_Out.Columns.Add("ItemStatus");
            dt_Out.Columns.Add("JobCode");
            dt_Out.Columns.Add("Quantity");
            dt_Out.Columns.Add("Weight");
            dt_Out.Columns.Add("ItemSubCategoryID1");
            dt_Out.Columns.Add("ItemSubCategoryID2");
            dt_Out.Columns.Add("ItemSerialNo");
            dt_Out.Columns.Add("ItemSerialNo2");
            dt_Out.Columns.Add("CusOrderCode");
            dt_Out.Columns.Add("DeliveryOrderCode");

            foreach (DataGridViewRow row in dgvDetail.Rows)
                dt_In.Rows.Add(clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, ""),
                    clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, ""),
                    clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00")),
                    clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00")),
                    clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default"),
                    clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0"),
                    clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0"),
                    clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode", row.Index, "default"),
                    clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default")
                    );

            var newResults = from row in dt_In.AsEnumerable()
                             group row by new { ItemCode = row.Field<string>("ItemCode"), InquiryCode = row.Field<string>("InquiryCode"), ItemStatus = row.Field<string>("ItemStatus"), JobCode = row.Field<string>("JobCode"), ItemSubCategoryID = row.Field<string>("ItemSubCategoryID1"), ItemSubCategoryID2 = row.Field<string>("ItemSubCategoryID2"), ItemSerialNo = row.Field<string>("ItemSerialNo"), ItemSerialNo2 = row.Field<string>("ItemSerialNo2"), CusOrderCode = row.Field<string>("CusOrderCode"), DeliveryOrderCode = row.Field<string>("DeliveryOrderCode") } into grp
                             select new
                             {
                                 ItemCode = grp.Key.ItemCode,
                                 InquiryCode = grp.Key.InquiryCode,
                                 ItemStatus = grp.Key.ItemStatus,
                                 JobCode = grp.Key.JobCode,
                                 Quantity = grp.Sum((r) => decimal.Parse(r["Quantity"].ToString())),
                                 Weight = grp.Sum((r) => decimal.Parse(r["Weight"].ToString())),
                                 ItemSubCategoryID = grp.Key.ItemSubCategoryID,
                                 ItemSubCategoryID2 = grp.Key.ItemSubCategoryID2,
                                 ItemSerialNo = grp.Key.ItemSerialNo,
                                 ItemSerialNo2 = grp.Key.ItemSerialNo2,
                                 CusOrderCode = grp.Key.CusOrderCode,
                                 DeliveryOrderCode = grp.Key.DeliveryOrderCode
                             };


            foreach (var record in newResults)
                dt_Out.Rows.Add(record.ItemCode, record.InquiryCode, record.ItemStatus, record.JobCode, record.Quantity, record.Weight, record.ItemSubCategoryID, record.ItemSubCategoryID2, record.ItemSerialNo, record.ItemSerialNo2, record.CusOrderCode, record.DeliveryOrderCode);

            return dt_Out;
        } 
        #endregion

       

        #region Digital Storage Convert
        public static double BytesToKilobytes(long bytes)
        {
            double dValue = 0;
            if (bytes != 0)
                dValue = bytes / 1024d;

            return dValue;
        }
        public static double BytesToMegabytes(long bytes)
        {
            double dValue = 0;
            if (bytes != 0)
                dValue = bytes / 1024d / 1024d;

            return dValue;
        }
        public static double BytesToGigabytes(long bytes)
        {
            double dValue = 0;
            if (bytes != 0)
                dValue = bytes / 1024d / 1024d / 1024d;

            return dValue;
        }
        public static double KilobytesToBytes(double kilobytes)
        {
            double dValue = 0;
            if (kilobytes != 0)
                dValue = kilobytes * 1024d;

            return dValue;
        } 
        #endregion 
    }
}
#region Set Values


//internal static string getCompanyName()
//{
//    throw new NotImplementedException();
//}

//#region Get Storage Capacity
//public static double GetFileSizeOnDisk(string file)
//{
//    double dValue = 0;
//    string drive = "";

//    FileInfo info = new FileInfo(file);
//    foreach (DriveInfo drv in DriveInfo.GetDrives())
//    {
//        set drive name to select file relevant drive.
//        if (drv.Name != info.Directory.Root.FullName)
//            continue;

//        get giga bytes values using that method
//        dValue = clsCommon.BytesToGigabytes(drv.TotalFreeSpace);

//        improve this method using commented code 
//        #region To Be Used
//        long lAvailable = drv.AvailableFreeSpace;
//        long lFree = drv.TotalFreeSpace;
//        long lTotal = drv.TotalSize;

//        switch (drive)
//        {
//            case "Bytes":
//                dValue = clsCommon.KilobytesToBytes(drv.TotalFreeSpace);
//                break;
//            case "KiloBytes":
//                dValue = clsCommon.BytesToKilobytes(drv.TotalFreeSpace);
//                break;
//            case "MegaBytes":
//                dValue = clsCommon.BytesToMegabytes(drv.TotalFreeSpace);
//                break;
//            case "GigaBytes":
//                dValue = clsCommon.BytesToGigabytes(drv.TotalFreeSpace);
//                break;                
//        }  
//        #endregion
//    }

//    return dValue;
//}
//#endregion

//public static void setRegName()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    // If the return value is null, the key doesn't exist
//    if (key == null)
//    {
//        // The key doesn't exist; create it / open it
//        key = Registry.LocalMachine.CreateSubKey(RegRegistryName);
//    }

//}
//public static void setRegValues()
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    // screen.
//    key.SetValue("servername", RegServerName.Trim());
//    key.SetValue("database", RegDatabaseName.Trim());
//    key.SetValue("dbuser", RegDBUserName.Trim());
//    key.SetValue("dbpassword", RegDBUserPassword.Trim());
//    key.SetValue("outlet", regOutlet.Trim());
//    key.SetValue("terminal", RegTerminal.Trim());
//    key.SetValue("companyname", RegCompanyName.Trim());
//    key.SetValue("valied", RegValied);
//    key.SetValue("registryName", RegRegistryName);
//    key.SetValue("domainName", RegDomainName);

//}
//public static void setRegValuesServername(string ServerName)
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    RegServerName = ServerName;
//    key.SetValue("servername", RegServerName.Trim());
//}
//public static void setRegValuesDatabasename(string DatabaseName)
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    RegDatabaseName = DatabaseName;
//    key.SetValue("database", RegDatabaseName.Trim());
//}
//public static void setRegValuesUsername(string UserName)
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    RegDBUserName = UserName;
//    key.SetValue("dbuser", RegDBUserName.Trim());
//}
//public static void setRegValuesPassword(string UserPassword)
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    RegDBUserPassword = UserPassword;
//    key.SetValue("dbpassword", RegDBUserPassword.Trim());
//}
//public static void setRegValuesValidKey(string ValidKey)
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    regValied = ValidKey;
//    key.SetValue("valied", regValied.Trim());
//}
//public static void setRegValuesOutlet(string OutletID)
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    RegOutlet = OutletID;
//    key.SetValue("outlet", RegOutlet.Trim());
//}
//public static void setRegValuesTerminal(string TerminalID)
//{
//    // Open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

//    // Set the registry values to correspond to the form's coordinates on the
//    RegTerminal = TerminalID;
//    key.SetValue("terminal", RegTerminal.Trim());
//}
#endregion

#region Get Values
//#region get server name

//public static string getRegServerName()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("servername").ToString();

//    return result;
//}
//#endregion

//#region get database name

//public static string getRegDatabaseName()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("database").ToString();

//    return result;
//}
//#endregion

//#region get user name
//public static string getRegDBUserName()
//{
//    // Attempt to open the key
//    string result = "";
//    try
//    {
//        RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);
//        result = key.GetValue("dbuser").ToString();
//    }
//    catch { }
//    return result;
//}
//#endregion

//#region get password

//public static string getRegDBUserPassword()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("dbpassword").ToString();

//    return result;
//}
//#endregion

//#region get outlet

//public static string getRegDBOutlet()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("outlet").ToString();

//    return result;
//}
//#endregion

//#region get version

//public static string getRegDBTerminal()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("terminal").ToString();

//    return result;
//}
//#endregion

//#region get company name

//public static string getRegDBComapanyName()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);
//    string result = key.GetValue("companyname").ToString();

//    return result;
//}
//#endregion

//#region get valied

//public static string getRegDBValied()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("valied").ToString();

//    return result;
//}
//#endregion

//#region get regirstry name

//public static string getRegDBRegistryName()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("registryName").ToString();

//    return result;
//}
//#endregion

//#region get domain name

//public static string getRegDBDomainName()
//{
//    // Attempt to open the key
//    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

//    string result = key.GetValue("domainName").ToString();

//    return result;
//}
//#endregion
#endregion


//public static void SetEnableDisable_ForeignKeyLabelTextboxOptional(labelt myTextBox, bool bEnable)
//{
//    if (bEnable)
//    {
//        myTextBox.Enabled = true;
//        myTextBox.BackColor = Color.LightGray;
//    }
//    else
//    {
//        myTextBox.Enabled = false;
//        myTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
//    }
//}

//public static string getComName()
//{
//    string sCompanyName = "";
//    tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
//    if (com != null)
//        sCompanyName = com.CompanyName;

//    return sCompanyName;
//}
//public static string getCompanyAddress1()
//{
//    string sAddress1 = "";
//    tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
//    if (com != null)
//        sAddress1 = com.Address;

//    return sAddress1;
//}

//public static byte[] getCompanyImage()
//{
//    byte[] sCompanyImage = null;
//    tbl_genCompanyImage comI = tbl_genCompanyImage.Select(clsSecurity.getRegDBComapanyName());

//    if (comI != null && comI.MainLogo!=null)
//        sCompanyImage = comI.MainLogo;
//    else
//    {

//        System.IO.MemoryStream ms = new System.IO.MemoryStream();
//        Digiteq_Logic.Properties.Resources.no_image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
//      //  byte[] bmpBytes = ms.ToArray();



//        sCompanyImage = ms.ToArray();
//    }
//    return sCompanyImage;
//}


//public static string getCompanyAddress2_DAPL()
//{
//    string sAddress2 = "";
//    tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.getRegDBComapanyName());
//    if (com != null)
//        sAddress2 = "Tel / FAX : " + com.Telephone1;

//    return sAddress2;
//}


//public static List<string> getEnumDescription(Type enumType)
//{
//    List<string> lPeriod = new List<string>();

//    foreach (var record in Enum.GetValues(enumType).Cast<Enum>().Select(value => new
//    {
//        (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
//        value
//    })
//.OrderBy(item => item.value)
//.ToList())
//    {
//        lPeriod.Add(record.Description);
//    }
//    return lPeriod;
//}


//public static DataTable DataGridViewToDataTable(DataGridView dataGridView1)
//{
//    DataTable dt = new DataTable();
//    foreach (DataGridViewColumn col in dataGridView1.Columns)
//    {
//        dt.Columns.Add(col.Name);
//    }
//    foreach (DataGridViewRow gridRow in dataGridView1.Rows)
//    {
//        if (gridRow.IsNewRow)
//            continue;
//        DataRow dtRow = dt.NewRow();
//        for (int i1 = 0; i1 < dataGridView1.Columns.Count; i1++)
//        {

//            dtRow[i1] = (gridRow.Cells[i1].Value == null ? DBNull.Value : gridRow.Cells[i1].Value);
//        }
//        dt.Rows.Add(dtRow);
//    }
//    return dt;
//}