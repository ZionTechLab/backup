using System;
using System.Windows.Input;
using System.Windows;

namespace SEACC_WPFControls
{
    public static class CommonValidations
    {
        public static Key getNumaricKey(Key KeyCode)
        {
            Key status = KeyCode;
            switch (KeyCode)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.OemComma:
                case Key.Decimal:
                case Key.OemPeriod:              
                    status = KeyCode;
                    break;
                case Key.NumPad0:
                    status = Key.D0;
                    break;
                case Key.NumPad1:
                    status = Key.D1;
                    break;
                case Key.NumPad2:
                    status = Key.D2;
                    break;
                case Key.NumPad3:
                    status = Key.D3;
                    break;
                case Key.NumPad4:
                    status = Key.D4;
                    break;
                case Key.NumPad5:
                    status = Key.D5;
                    break;
                case Key.NumPad6:
                    status = Key.D6;
                    break;
                case Key.NumPad7:
                    status = Key.D7;
                    break;
                case Key.NumPad8:
                    status = Key.D8;
                    break;
                case Key.NumPad9:
                    status = Key.D9;
                    break;
            }
            return status;
        }
    }

    public enum MessegeBoxType
    {
        Cancel_Confirmation = 1,
        Checked_Confirmation=2,
        Approval_Confirmation = 3,
        LogOut_Confirmation = 4,
        Delete_Confirmation_CC = 5,
        Locked_Confirmation = 6,

        Successfully_Canceled = 100,
        Successfully_Created = 101,
        Successfully_Updated=102,
        Successfully_Checked = 103,
        Successfully_Approved = 104,
        Successfully_Changed = 105,
        Successfully_Locked = 106,

        RecordAlreadyExist = 7,
        FieldAlreadyExist = 8,

        CannotCancel_AlreadyApproved = 12,
        CannotCancel_AlreadyCanceled=16,
        SuccessfullyProcessed = 13,
        PasswordsNotMatched=14,

        AccessDenied=55,

        RegistryError=1000,
    }

    public static class SEACCMessageBox
    {
        public static bool Show(string Caption, string MessegeBoxText)
        {
            return Show(Caption, MessegeBoxText, MessageBoxButton.YesNo, "#FF4791C3");
        }

        public static bool Show(string Caption, string MessegeBoxText, MessageBoxButton btn)
        {
            return Show(Caption, MessegeBoxText, btn, "#FF4791C3");
        }

        public static bool Show(string Caption, string MessegeBoxText, MessageBoxButton btn, string BackColor)
        {
            SEACC_MessegeBox oError = new SEACC_MessegeBox(Caption, MessegeBoxText, btn);
            oError.SetMessegeboxColor(BackColor);
            oError.ShowDialog();

            return (bool)oError.DialogResult;
        }

        public static bool Show(MessegeBoxType MessegeBoxType)
        {
            return Show(MessegeBoxType, "");
        }

        public static bool Show(MessegeBoxType MessegeBoxType, string FieldName)
        {
            string sMessageTitle = "";
            string sMessageDetail = "";
            string BackColor = "";
            MessageBoxButton ButtonType = MessageBoxButton.YesNo;

            switch (MessegeBoxType)
            {
                #region Confirmation
                case MessegeBoxType.Cancel_Confirmation:
                    sMessageTitle = "Confirmation....!";
                    sMessageDetail = "Are you sure you want to cancel selected item?";
                    BackColor = "#FF5B6B76";
                    break;

                case MessegeBoxType.Checked_Confirmation:
                    sMessageTitle = "Confirmation....!";
                    sMessageDetail = "Are you sure you want to Check this?";
                    BackColor = "#FF5B6B76";
                    break;

                case MessegeBoxType.Locked_Confirmation:
                    sMessageTitle = "Confirmation....!";
                    sMessageDetail = "Are you sure you want to Lock this?";
                    BackColor = "#FF5B6B76";
                    break;

                case MessegeBoxType.Approval_Confirmation:
                    sMessageTitle = "Confirmation....!";
                    sMessageDetail = "Are you sure you want to Approve this?";
                    BackColor = "#FF5B6B76";
                    break;

                case MessegeBoxType.LogOut_Confirmation:
                    sMessageTitle = "Confirmation....!";
                    sMessageDetail = "Are you sure you want to logout ?";
                    BackColor = "#FF5B6B76";
                    break;

                case MessegeBoxType.Delete_Confirmation_CC:
                    sMessageTitle = "Confirmation....!";
                    sMessageDetail = " Are you sure you want to delete already saved data and enter these new data?";
                    BackColor = "#FF5B6B76";
                    break;

                #endregion

                #region Succesfull
                case MessegeBoxType.Successfully_Canceled:
                    sMessageTitle = "Success....!";
                    sMessageDetail = "Successfully Canceled ..";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.Successfully_Created:
                    sMessageTitle = "Success....!";
                    sMessageDetail = "Successfully Created ..";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.Successfully_Updated:
                    sMessageTitle = "Success....!";
                    sMessageDetail = "Successfully Updated ..";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.Successfully_Checked:
                    sMessageTitle = "Success....!";
                    sMessageDetail = "Successfully Checked";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.Successfully_Locked:
                    sMessageTitle = "Success....!";
                    sMessageDetail = "Successfully Locked";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.Successfully_Approved:
                    sMessageTitle = "Success....!";
                    sMessageDetail = "Successfully Approved ..";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.Successfully_Changed:
                    sMessageTitle = "Success....!";
                    sMessageDetail = "Successfully Changed";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.SuccessfullyProcessed:
                    sMessageDetail = "Success....!";
                    sMessageDetail = "Successfully Processed";
                    BackColor = "#FF4791C3";
                    ButtonType = MessageBoxButton.OK;
                    break;
                #endregion

                #region Errors
                case MessegeBoxType.RecordAlreadyExist:
                    sMessageTitle = "Something went wrong....!";
                    sMessageDetail = "Record Already Exist";
                    BackColor = "#FFC34753";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.FieldAlreadyExist:
                    sMessageTitle = "Something went wrong....!";
                    sMessageDetail = FieldName + " Already Exist";
                    BackColor = "#FFC34753";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.CannotCancel_AlreadyApproved:
                    sMessageTitle = "Transaction cannot be cancelled....!";
                    sMessageDetail = "This transaction is already approved.";
                    BackColor = "#FFC34753";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.CannotCancel_AlreadyCanceled:
                    sMessageTitle = "Transaction cannot be cancelled....!";
                    sMessageDetail = "This transaction is already cancelled.";
                    BackColor = "#FFC34753";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.PasswordsNotMatched:
                    sMessageTitle = "Something went wrong....!";
                    sMessageDetail = "Passwords Not Matched";
                    BackColor = "#FFC34753";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.RegistryError:
                    sMessageTitle = "Registry Error....!";
                    sMessageDetail = "Please contact your system Administrator";
                    BackColor = "#FFC34753";
                    ButtonType = MessageBoxButton.OK;
                    break;

                case MessegeBoxType.AccessDenied:
                    sMessageTitle = "Access Denied....!";
                    sMessageDetail = "Sorry, you don’t have permission to perform this Action.\n Please get permission from the system administrator";
                    BackColor = "#FFC34753";
                    ButtonType = MessageBoxButton.OK;
                    break; 
                #endregion
            }
            return Show(sMessageTitle, sMessageDetail, ButtonType, BackColor);
        }
    }

    public static class SEACCExeption
    {
        public static bool Show(Exception ex)
        {
                SEACC_Exeption oError = new SEACC_Exeption(ex);
                oError.ShowDialog();
                return (bool)oError.DialogResult;
        }
    }
}