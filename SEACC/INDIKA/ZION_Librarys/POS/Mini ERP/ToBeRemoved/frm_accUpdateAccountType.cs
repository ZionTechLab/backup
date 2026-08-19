using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_accUpdateAccountType : MettroForm
    {
        #region Form Load
        public frm_accUpdateAccountType()
        {
            InitializeComponent();
        }

        private void frm_accUpdateAccountType_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            clsFormatter.setFormatForm(this, "Update Account Types", 2, 0);
        }
        #endregion

        #region Btn Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int iConter = 0;            
            char[] delimiterChars = { '/' };
            string sCode = "";

            List<tbl_zAccGLMaster_AccountType> DetailsAccType = tbl_zAccGLMaster_AccountType.SelectAll().Where(p=> p.GlAccountType_ID != "default").ToList();
            foreach (tbl_zAccGLMaster_AccountType detail in DetailsAccType)
            {
                List<tbl_accGLMaster> DetailGL = tbl_accGLMaster.SelectAllByGlAccountType_ID(detail.GlAccountType_ID).OrderBy(o => o.Line_No).ToList();
                foreach (tbl_accGLMaster detGL in DetailGL)
                {
                    if (detGL.Gl_ID != "<Auto Generate>" && detGL.Gl_ID != "default")
                    {
                        string[] glCodes = detGL.Gl_ID.Split(delimiterChars);
                        if (glCodes.Length == 5)
                            sCode = glCodes[4];
                    }
                }

                int iCode = int.Parse(sCode);

                detail.Counter = iCode + 1;
                detail.Update();

            }

            MessageBox.Show("successfully Updated", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion       
       
    }
}
