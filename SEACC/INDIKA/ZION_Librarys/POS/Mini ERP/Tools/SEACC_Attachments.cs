using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Digiteq
{
    public partial class SEACC_Attachments : UserControl
    {
        frm_Attachments oFrmAttachments = new frm_Attachments();
        public int iFormID;
        public SEACC_Attachments()
        {
            InitializeComponent();
        }

        public void UpdateBackColor()
        {
            if (oFrmAttachments.dtAttachments.Rows.Count > 0)
            {
                btnAttachment.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
                btnAttachment.ForeColor = System.Drawing.Color.White;
            }
        }

        public void Clear()
        {
            oFrmAttachments.Clear();
        }

        public void FillAttachments(string sTx_ID)
        {
            oFrmAttachments.iFormID = iFormID;
            oFrmAttachments.FillDetails(sTx_ID);
            UpdateBackColor();
        }

        public void Close()
        {
            oFrmAttachments.Close();
            UpdateBackColor();
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            oFrmAttachments.ShowDialog();
            UpdateBackColor();
        }

        public void Insert(string sTx_ID)
        {
            oFrmAttachments.iFormID = iFormID;
            oFrmAttachments.Insert(sTx_ID);
            UpdateBackColor();
        }
    }
}