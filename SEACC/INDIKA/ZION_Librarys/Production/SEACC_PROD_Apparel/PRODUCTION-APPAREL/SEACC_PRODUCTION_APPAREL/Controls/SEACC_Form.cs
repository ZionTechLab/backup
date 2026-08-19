using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace SEACC_PRODUCTION_APPAREL.Controls
{
    class SEACC_Form : Grid
    {
        #region variables
        public Digiteq_Logic.FormName enmFormName = Digiteq_Logic.FormName.accAccount;
        BrushConverter bc = new BrushConverter();

        Grid grdBotom = new Grid();
        Separator Separator1 = new Separator();
        StackPanel StackPanel1 = new StackPanel();

        public SEACC_Button btn_New = new SEACC_Button();
        public SEACC_Button btn_Save = new SEACC_Button();
        public SEACC_Button btn_Checked = new SEACC_Button();
        public SEACC_Button btn_Approved = new SEACC_Button();
        public SEACC_Button btn_Print = new SEACC_Button();
        public SEACC_Button btn_Cancel = new SEACC_Button();

        public string FormName = "";
        public string FormID = "";
        public int Function_ID = 0;

        public bool PermissionTO_Approve = false, PermissionTO_Check = false, PermissionTO_Cancel = false, PermissionTO_Read = false, PermissionTO_Update = false, PermissionTO_Write = false, PermissionTO_Print = false;
        public bool IsUpdateMode = false;
        public bool isAutoGenaratedCode = false;
        #endregion

        public SEACC_Form()
        {
            #region Botom
            grdBotom.VerticalAlignment = VerticalAlignment.Bottom;
            grdBotom.Height = 45;
            //   grdBotom.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
            grdBotom.Margin = new Thickness(15, 0, 15, 0);

            Separator1.VerticalAlignment = VerticalAlignment.Top;

            StackPanel1.Orientation = Orientation.Horizontal;
            StackPanel1.HorizontalAlignment = HorizontalAlignment.Right;
            StackPanel1.Margin = new Thickness(0, 8, 0, 0);

            btn_New.Content = "New";
            btn_New.Width = 73;
            btn_New.Height = 25;
            btn_New.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
            btn_New.BorderBrush = (Brush)bc.ConvertFrom("#FF9B9B9B");
            btn_New.Foreground = (Brush)bc.ConvertFrom("White");
            btn_New.Margin = new Thickness(0, 6, 6, 0);
            btn_New.VerticalAlignment = VerticalAlignment.Top;

            btn_Save.Content = "Save";
            btn_Save.Width = 73;
            btn_Save.Height = 25;
            btn_Save.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
            btn_Save.BorderBrush = (Brush)bc.ConvertFrom("#FF9B9B9B");
            btn_Save.Foreground = (Brush)bc.ConvertFrom("White");
            btn_Save.Margin = new Thickness(0, 6, 6, 0);
            btn_Save.VerticalAlignment = VerticalAlignment.Top;

            btn_Checked.Content = "Checked";
            btn_Checked.Width = 73;
            btn_Checked.Height = 25;
            btn_Checked.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
            btn_Checked.BorderBrush = (Brush)bc.ConvertFrom("#FF9B9B9B");
            btn_Checked.Foreground = (Brush)bc.ConvertFrom("White");
            btn_Checked.Margin = new Thickness(0, 6, 6, 0);
            btn_Checked.VerticalAlignment = VerticalAlignment.Top;

            btn_Approved.Content = "Approved";
            btn_Approved.Width = 73;
            btn_Approved.Height = 25;
            btn_Approved.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
            btn_Approved.BorderBrush = (Brush)bc.ConvertFrom("#FF9B9B9B");
            btn_Approved.Foreground = (Brush)bc.ConvertFrom("White");
            btn_Approved.Margin = new Thickness(0, 6, 6, 0);
            btn_Approved.VerticalAlignment = VerticalAlignment.Top;

            btn_Print.Content = "Print";
            btn_Print.Width = 73;
            btn_Print.Height = 25;
            btn_Print.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
            btn_Print.BorderBrush = (Brush)bc.ConvertFrom("#FF9B9B9B");
            btn_Print.Foreground = (Brush)bc.ConvertFrom("White");
            btn_Print.Margin = new Thickness(0, 6, 6, 0);
            btn_Print.VerticalAlignment = VerticalAlignment.Top;

            btn_Cancel.Content = "Cancel";
            btn_Cancel.Width = 73;
            btn_Cancel.Height = 25;
            btn_Cancel.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
            btn_Cancel.BorderBrush = (Brush)bc.ConvertFrom("#FF9B9B9B");
            btn_Cancel.Foreground = (Brush)bc.ConvertFrom("White");
            btn_Cancel.Margin = new Thickness(0, 6, 6, 0);
            btn_Cancel.VerticalAlignment = VerticalAlignment.Top;
            #endregion

            Children.Add(grdBotom);
            grdBotom.Children.Add(Separator1);
            grdBotom.Children.Add(StackPanel1);
            StackPanel1.Children.Add(btn_New);
            StackPanel1.Children.Add(btn_Save);
            StackPanel1.Children.Add(btn_Approved);
            StackPanel1.Children.Add(btn_Checked);
            StackPanel1.Children.Add(btn_Print);
            StackPanel1.Children.Add(btn_Cancel);
        }

        public void SetVisibility_HorizontalRule(bool HR_Rule)
        {
            if (!HR_Rule)
                Separator1.Visibility = Visibility.Hidden;
        }

        public void SetVisibility_ActionButons(bool button_New, bool button_Print, bool button_Save, bool button_CheckedBy, bool button_ApproveBy, bool button_Cancle)
        {
            if (!button_Print)
            {
                btn_Print.Width = 0;
                btn_Print.Margin = new Thickness(0);
            }
            if (!button_New)
            {
                btn_New.Width = 0;
                btn_New.Margin = new Thickness(0);
            }
            if (!button_Save)
            {
                btn_Save.Width = 0;
                btn_Save.Margin = new Thickness(0);
            }
            if (!button_CheckedBy)
            {
                btn_Checked.Width = 0;
                btn_Checked.Margin = new Thickness(0);
            }
            if (!button_ApproveBy)
            {
                btn_Approved.Width = 0;
                btn_Approved.Margin = new Thickness(0);
            }
            if (!button_Cancle)
            {
                btn_Cancel.Width = 0;
                btn_Cancel.Margin = new Thickness(0);
            }
        }

        public void SaveUserActivity(int ActivityType)
        {
            try
            {
                tbl_audUserActivities oUserActivitys = new tbl_audUserActivities((int)enmFormName, ActivityType, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                oUserActivitys.Insert();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Oops..!", "Something went wrong. \nPlease contact your IT administrator or email to \"helpdesk@digiteq.biz\"", MessageBoxButton.OK);
            }
        }

        public void Initialize()
        {
            this.Unloaded += SEACC_Form_Unloaded;
            tbl_securityFunctionMaster oFunction = tbl_securityFunctionMaster.Select((int)enmFormName);
            if (oFunction != null)
            {
                FormName = oFunction.FunctionName;
                FormID = oFunction.FunctionCategory_ID + "-" + oFunction.Function_ID;
                Function_ID = oFunction.Function_ID;

                tbl_securityFunctionMaster_Form oForm = tbl_securityFunctionMaster_Form.Select(oFunction.Function_ID);
                if (oForm != null)
                    isAutoGenaratedCode = oForm.IsAutoGenerate;

                #region Set Permission
                tbl_securityFunctionMaster_Permission detail = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, (int)enmFormName);
                if (detail != null)
                {
                    PermissionTO_Approve = detail.AllowApprovable;
                    PermissionTO_Check = detail.AllowCheckable;
                    PermissionTO_Cancel = detail.AllowDelete;
                    PermissionTO_Read = detail.AllowRead;
                    PermissionTO_Update = detail.AllowUpdate;
                    PermissionTO_Write = detail.AllowWrite;
                    PermissionTO_Print = detail.AllowPrint;
                }
                #endregion

                if (!PermissionTO_Read)
                {
                    SEACCMessageBox.Show("Sorry, you don’t have permission to access this function….!", "Please contact your IT administrator or email your request to helpdesk@digiteq.biz\nFunction ID - " + ((int)enmFormName).ToString(), MessageBoxButton.OK);
                    SaveUserActivity(2);
                }
                else
                    SaveUserActivity(1);
            }
            else
            {
                SEACCMessageBox.Show("Sorry, Function not found….!", "Please contact your IT administrator or email your request to helpdesk@digiteq.biz\nFunction ID - " + ((int)enmFormName).ToString(), MessageBoxButton.OK);
                SaveUserActivity(2);
            }
        }

        void SEACC_Form_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveUserActivity(3);
        }

        public bool CheckPermission_ToSave(bool bIsUpdatemode)
        {
            bool bStatus = false;

            if (bIsUpdatemode)
                bStatus = PermissionTO_Update;
            else
                bStatus = PermissionTO_Write;

            if (!bStatus)
            {
                SEACCMessageBox.Show(MessegeBoxType.AccessDenied);
                SaveUserActivity(4);
            }
            return bStatus;
        }

        public bool CheckPermission_ToChecked()
        {
            if (!PermissionTO_Check)
            {
                SEACCMessageBox.Show(MessegeBoxType.AccessDenied);
                SaveUserActivity(5);
            }
            return PermissionTO_Check;
        }

        public bool CheckPermission_ToApproved()
        {
            if (!PermissionTO_Approve)
            {
                SEACCMessageBox.Show(MessegeBoxType.AccessDenied);
                SaveUserActivity(6);
            }
            return PermissionTO_Approve;
        }

        public bool CheckPermission_ToCancel()
        {
            if (!PermissionTO_Cancel)
            {
                SEACCMessageBox.Show(MessegeBoxType.AccessDenied);
                SaveUserActivity(4);
            }
            return PermissionTO_Cancel;
        }

        public bool CheckPermission_ToPrint()
        {
            if (!PermissionTO_Print)
            {
                SEACCMessageBox.Show(MessegeBoxType.AccessDenied);
                SaveUserActivity(4);
            }
            return PermissionTO_Print;
        }

        public string getAutoGeneratedCode()
        {
            return clsCommon.getAutoGeneratedCode(enmFormName);
        }

        
    }
    public static class clsCommon
    {
        public static string getAutoGeneratedCode(FormName enmFormName)
        {
            string sCode = "";

            tbl_securityFunctionMaster_Form detail = tbl_securityFunctionMaster_Form.Select((int)enmFormName);
            if (detail != null)
            {
                if (detail.Prefix1 != null && detail.Prefix1.Length > 0)
                    sCode += detail.Prefix1;

                sCode += detail.Counter.ToString(getWidthFormat(detail.Length));
                detail.Counter++;
                detail.Update();
            }
            return sCode;
        }

        public static string getWidthFormat(int Size)
        {
            string Zero = "";
            for (int x = 0; x < Size; x++)
            {
                Zero += "0";
            }
            return Zero;
        }
    }
}
