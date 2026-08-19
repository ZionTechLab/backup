using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using SEACC_WPFControls.Controls;

namespace SEACC_WPFControls
{
    public class cls_Formater : Window
    {
        static BrushConverter bc = new BrushConverter();

        public static string Format_Date = "yyyy/MM/dd";
        public static string Format_Date2 = "yyyy-MMM-dd";
        public static string Format_Date3 = "MM/dd/yyyy";
        public static string Format_Time = "HH:mm";
        public static string Format_DateTime = "yyyy/MM/dd HH:mm";

        public static string fncsetstring(string sTemp)
        {
            return "'" + sTemp.Replace("'", "''").Trim() + "'";
        }

        #region Format Decimal

        public static string FormatDecimal(decimal dValue, string sDecimalPlaces)
        {
            string value = "0.00";
            try
            {
                value = FormatDecimal(dValue, int.Parse(sDecimalPlaces));
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            return value;
        }

        public static string FormatDecimal(decimal dValue, int DecimalPlaces)
        {
            string value = "0.00";
            string sFormat = "";

            switch (DecimalPlaces)
            {
                case 0:
                    sFormat = "{0:#,0}";
                    break;
                case 1:
                    sFormat = "{0:#,0.0}";
                    break;
                case 2:
                    sFormat = "{0:#,0.00}";
                    break;
                case 3:
                    sFormat = "{0:#,0.000}";
                    break;
                case 4:
                    sFormat = "{0:#,0.0000}";
                    break;
                case 5:
                    sFormat = "{0:#,0.00000}";
                    break;
                default:
                    break;
            }

            value = String.Format(sFormat, dValue);
            return value;
        }// string fmt2 = "#,##0.00;(#,##0.00)"; 
        #endregion

        #region Bit Map
        public static BitmapImage Convert_ByteToBitMap(byte[] ByteImage)
        {
            BitmapImage bitmap = new BitmapImage();
            try
            {
                if (ByteImage.Length > 0)
                {
                    using (var stream = new MemoryStream(ByteImage))
                    {
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                    }
                }
            }
            catch (Exception)
            {
            }
            return bitmap;
        }

        public static byte[] Convert_BitMapToByteArray(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
        #endregion

        #region Set Enable Disable Control
        public static void SetEnableDisable_LableTimePicker(SEACC_LabelTimeSelector myTimeSelector, bool bEnable, bool bClickToExpand)
        {
            myTimeSelector.SetTime(DateTime.Now);

            if (bEnable)
            {
                myTimeSelector.IsEnabled = true;
                myTimeSelector.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myTimeSelector.IsEnabled = false;
                myTimeSelector.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
            myTimeSelector.timePicker.isClickToExpand = bClickToExpand;
        }

        public static void SetEnableDisable_DatePicker(DatePicker myDatePicker, bool bEnable)
        {
            myDatePicker.SelectedDate = DateTime.Now;

            if (bEnable)
            {
                myDatePicker.IsEnabled = true;
                myDatePicker.BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myDatePicker.IsEnabled = false;
                myDatePicker.BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }

        }

        public static void SetEnableDisable_TimeSpan(SEACC_TimeSpan myTimeSpan, bool bEnable)
        {
            myTimeSpan.SetTimeSpan(new TimeSpan(0, 0, 0));

            if (bEnable)
            {
                myTimeSpan.IsEnabled = true;
                myTimeSpan.BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myTimeSpan.IsEnabled = false;
                myTimeSpan.BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_LableTimeSpan(SEACC_LabelTimeSpan myTimeSpan, bool bEnable)
        {
            myTimeSpan.SetTimeSpan(new TimeSpan(0, 0, 0));

            if (bEnable)
            {
                myTimeSpan.IsEnabled = true;
                myTimeSpan.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myTimeSpan.IsEnabled = false;
                myTimeSpan.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_LableTextbox(SEACC_LableTextBox myTextBox, bool bEnable, bool isNumaric, bool isMultiline)
        {
            myTextBox.ISNumaric = isNumaric;
            myTextBox.IsMultiline = isMultiline;
            myTextBox.ErrorText = "";
            if (bEnable)
            {
                myTextBox.IsEnabled = true;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myTextBox.IsEnabled = false;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_LableTextboxWithCheckBox(SEACC_LabelTextBoxWithCheckBox myTextBox, bool bEnable, bool isNumaric, bool isMultiline)
        {
            myTextBox.ISNumaric = isNumaric;
            myTextBox.IsMultiline = isMultiline;
            myTextBox.ErrorText = "";
            if (bEnable)
            {
                myTextBox.IsEnabled = true;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myTextBox.IsEnabled = false;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_PrimaryKeyLabelTextBox(SEACC_LableTextBox myTextBox, bool bEnable, bool isNumeric, bool isMultiline)
        {
            myTextBox.ISNumaric = isNumeric;
            myTextBox.IsMultiline = isMultiline;
            myTextBox.ErrorText = "";
            if (bEnable)
            {
                myTextBox.setReadOnlyStatus(false);
                // myTextBox.IsEnabled = true;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
                myTextBox.TextBox_Background = (Brush)bc.ConvertFrom("#D8D8D8");
            }
            else
            {
                myTextBox.setReadOnlyStatus(true);
                //myTextBox.IsEnabled = false;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_ForigenKeyLabelTextBox(SEACC_LableTextBox myTextBox, bool bEnable, bool isNumeric, bool isMultiline)
        {
            myTextBox.ISNumaric = isNumeric;
            myTextBox.setReadOnlyStatus(true);
            myTextBox.ErrorText = "";
            myTextBox.IsMultiline = isMultiline;
            if (bEnable)
            {
                myTextBox.IsEnabled = true;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
                myTextBox.TextBox_Background = (Brush)bc.ConvertFrom("#D8D8D8");
            }
            else
            {
                myTextBox.IsEnabled = false;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_ForigenKeyLabelTextBoxWithCheckBox(SEACC_LabelTextBoxWithCheckBox myTextBox, bool bEnable, bool isNumeric, bool isMultiline)
        {
            myTextBox.ISNumaric = isNumeric;
            myTextBox.setReadOnlyStatus(true);
            myTextBox.ErrorText = "";
            myTextBox.IsMultiline = isMultiline;
            if (bEnable)
            {
                myTextBox.IsEnabled = true;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
                myTextBox.TextBox_Background = (Brush)bc.ConvertFrom("#D8D8D8");
            }
            else
            {
                myTextBox.IsEnabled = false;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_PasswordBox(PasswordBox myTextBox, bool bEnable, bool isNumaric)
        {

            if (bEnable)
            {
                myTextBox.IsEnabled = true;
                myTextBox.BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myTextBox.IsEnabled = false;
                myTextBox.BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_MultipleSelectBox(SEACC_LablelMultipleSelectBox myBox, bool bEnable)
        {

            if (bEnable)
            {
                myBox.IsEnabled = true;
                myBox.BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
                myBox.Grid_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
                myBox.Header_Background = (Brush)bc.ConvertFrom("#D8D8D8");
            }
            else
            {
                myBox.IsEnabled = false;
                myBox.BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
                myBox.Grid_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        #region SetEnableDisable SEACC TextBox
        public static void SetEnableDisable_SEACCNormalTextbox(SEACC_TextBox myTextBox, bool bEnable, bool isNumaric, bool isMultiline)
        {
            myTextBox.ISNumaric = isNumaric;
            myTextBox.IsMultiline = isMultiline;
            myTextBox.ErrorText = "";
            if (bEnable)
            {
                myTextBox.IsEnabled = true;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myTextBox.IsEnabled = false;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_ForigenKeyTextBox(SEACC_TextBox myTextBox, bool bEnable, bool isNumaric)
        {
            myTextBox.ErrorText = "";
            myTextBox.ISNumaric = isNumaric;
            myTextBox.setReadOnlyStatus(true);

            if (bEnable)
            {
                myTextBox.IsEnabled = true;
                //myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
                //myTextBox.Background = (Brush)bc.ConvertFrom("#D8D8D8");

                //Channge by Gayan on 2017-04-20
                //
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
                myTextBox.TextBox_Background = (Brush)bc.ConvertFrom("#D8D8D8");
            }
            else
            {
                myTextBox.IsEnabled = false;
                myTextBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        public static void SetEnableDisable_PrimaryKeyTextbox(SEACC_TextBox myTextBox, bool bEnable)
        {

            if (bEnable)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#D3ADCA");
                myTextBox.setReadOnlyStatus(true);
                // myTextBox.IsEnabled = true;
                myTextBox.Background = brush;
            }
            else
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#ABABAB");
                myTextBox.setReadOnlyStatus(false);
                // myTextBox.IsEnabled = false;
                myTextBox.Background = brush;
            }
        }
        #endregion

        public static void SetEnableDisable_CheckBox(CheckBox myCheckBox, bool bEnable)
        {
            if (bEnable)
            {
                myCheckBox.BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            }
            else
            {
                myCheckBox.BorderBrush = (Brush)bc.ConvertFrom("Black");
            }
        }

        public static void SetEnableDisable_DataGrid(DataGrid myDataGrid, bool bEnable, string colorCode_HeaderBackGround, string ColorcodeForForeground)
        {
            if (bEnable)
            {

                double myPadding = 6.00;
                double myBorder = 0.00;
                myDataGrid.GridLinesVisibility = DataGridGridLinesVisibility.Horizontal;
                myDataGrid.CanUserSortColumns = true;
                myDataGrid.CanUserAddRows = false;
                myDataGrid.CanUserDeleteRows = false;
                myDataGrid.CanUserResizeColumns = false;
                // myDataGrid.IsReadOnly = true;

                myDataGrid.HorizontalAlignment = HorizontalAlignment.Left;
                myDataGrid.AutoGenerateColumns = false;
                //myDataGrid.AlternatingRowBackground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE0E0E0"));
                myDataGrid.HorizontalGridLinesBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDADADA"));
                // myDataGrid.VerticalGridLinesBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA4A2A2"));
                myDataGrid.CanUserReorderColumns = false;
                myDataGrid.CanUserSortColumns = false;
                myDataGrid.FontSize = 10;
                myDataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;
                myDataGrid.AutoGenerateColumns = false;
                myDataGrid.ColumnHeaderHeight = 29;
                myDataGrid.FontSize = 11;
                myDataGrid.RowHeight = 22;


                var style = new Style(typeof(System.Windows.Controls.Primitives.DataGridColumnHeader));
                if (colorCode_HeaderBackGround != "")
                {
                    style.Setters.Add(new Setter { Property = BackgroundProperty, Value = (Brush)bc.ConvertFrom(colorCode_HeaderBackGround) });
                }

                style.Setters.Add(new Setter { Property = ForegroundProperty, Value = (Brush)bc.ConvertFrom(ColorcodeForForeground) });
                style.Setters.Add(new Setter { Property = PaddingProperty, Value = new Thickness(Math.Round(myPadding / 2, 0)) });
                style.Setters.Add(new Setter { Property = BorderThicknessProperty, Value = new Thickness(Math.Round(myBorder / 2, 0)) });
                // style.Setters.Add(new Setter { Property = DataGridCell, Value = new Thickness(Math.Round(myBorder / 2, 0)) });
                myDataGrid.ColumnHeaderStyle = style;

            }
        }

        public static void SetEnableDisable_RadioButttons(RadioButton myRadioButtons, bool bEnable)
        {

            if (bEnable)
            {
                myRadioButtons.IsEnabled = true;
                myRadioButtons.BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");

            }
            else
            {
                myRadioButtons.IsEnabled = false;
                myRadioButtons.BorderBrush = (Brush)bc.ConvertFrom("#ABABAB");
            }
        }

        #endregion

        #region Marquee
        public void Marquee_Display(bool bStatusn, double Width)
        {
            FRM_Marquee_mini fMN = new FRM_Marquee_mini();
            fMN.Width = Width;
            fMN.Left = this.Width;

            fMN.Top = System.Windows.SystemParameters.WorkArea.Bottom - 100;
            if (bStatusn)
                fMN.Show();
        }
        #endregion
    }
}