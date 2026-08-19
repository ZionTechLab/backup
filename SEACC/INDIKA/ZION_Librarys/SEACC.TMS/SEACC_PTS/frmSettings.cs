using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SEACC_PTS
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            pbxProfilePic.BackgroundImage = Image.FromFile(settings.sImagePath);
        }

        private void pbxProfilePic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pbxProfilePic.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sSaveFileName =Application.StartupPath+ @"\image\ProfilePics\PP_" + settings.strLogedUserName + ".jpg";
            if (File.Exists(sSaveFileName))
                File.Delete(sSaveFileName);

            File.Copy(openFileDialog1.FileName, sSaveFileName);
       
            tbl_masUser oUser = tbl_masUser.Select(settings.UserId_Loged);
            if (oUser != null)
            {
                oUser.ProfilePicture=sSaveFileName.Replace(Application.StartupPath+"\\", "");
                oUser.Update();
                MessageBox.Show("Updated Successfully");
            }
        }
    }
}
