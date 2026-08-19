using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_LOGIN.Digiteq_Logic
{
  public  class clsCommon
    {
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
    }
}
