
using Express.View.Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Common.Helpers
{
   public class MessageNotification
    {
        public static void MessageBoxOK(string strMessage, string strCmp, string _messageHeader = "Information")
        {
            ////MessageBox.Show(strMessage, strCmp, MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(strMessage, LoginInfoView.PROJECTNAME, MessageBoxButtons.OK, MessageBoxIcon.Information);

        } 
        public static void MessageBoxError(string strMessage, string strCmp, string _messageHeader = "Information")
        {
            //// MessageBox.Show(strMessage, strCmp, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ///MessageBoxViewModel.MessageBoxInstance.ViewMessageBox(LoginInfoView.PROJECTNAME, strMessage, MsgButtonType.OK, MsgIconType.Error, _messageHeader);
            MessageBox.Show(strMessage, LoginInfoView.PROJECTNAME, MessageBoxButtons.OK , MessageBoxIcon.Error);
        }
        public static bool MessageBoxConfirm(string strMessage, string strCmp, string _messageHeader = "Confirmation")
        {
            //var result = ConfirmBoxViewModel.ConfirmBoxInstance.ConfirmMessageBox(LoginInfoView.PROJECTNAME, strMessage, MsgButtonType.YesNo, MsgIconType.Question);
            //return result;
            var result= MessageBox.Show(strMessage, LoginInfoView.PROJECTNAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes )
            {
                return true;
            }
            else if( result == DialogResult.No)
            {
                return false;
            }  
            else
            {
                return false;
            }
                          
        }
        public static string MessageBoxConfirmYesNoCancel(string strMessage, string strCmp, string _messageHeader = "Confirmation")
        {
            var result = MessageBox.Show(strMessage, LoginInfoView.PROJECTNAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return "YES";
            }
            else if (result == DialogResult.No)
            {
                return "NO";
            }
            else if( result == DialogResult.Cancel)
            {
                return "CANCEL";
            }
            else
            {
                return "NA";
            }
        }

    }
}
