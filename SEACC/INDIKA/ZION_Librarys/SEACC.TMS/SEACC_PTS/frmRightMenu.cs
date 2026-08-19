using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    public partial class frmRightMenu : Form
    {
        string sFilePath = "";
        int X = 0, Y = 0;
        public frmRightMenu()
        {
            InitializeComponent();
        }
        public frmRightMenu(string FilePath, int x, int y)
        {
            InitializeComponent();
           // this.Location = new Point(x, y);
            X = x;
            Y = y;
            sFilePath = FilePath;
        }

        #region Form Load
        private void frmRightMenu_Load(object sender, EventArgs e)
        {
            FormFormating();
            SetLableWidth(ref lblDownLod, 500);
        }

        #endregion

        #region Download
        private void lblDownLod_Click(object sender, EventArgs e)
        {
            try
            {
                SetLableClolor(ref lblDownLod, false);
                SaveDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frm_Tasks.frmMenu = null;
                SetLableClolor(ref lblDownLod, true);
                this.Close();
            }
        }
        #endregion

        #region View
        private void lblView_Click(object sender, EventArgs e)
        {
            try
            {
                SetLableClolor(ref lblDownLod, false);
                System.Diagnostics.Process.Start(sFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frm_Tasks.frmMenu = null;
                SetLableClolor(ref lblDownLod, true);
                this.Close();
            }
        }
        #endregion

        #region Format Right Click Form
        private void FormFormating()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ForeColor = Color.Black;
          //  this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            this.Location = new Point(MousePosition.X, MousePosition.Y);
        }
        #endregion

        #region File Brouser
        private void SaveDialog()
        {
            FolderBrowserDialog SaveBox = new FolderBrowserDialog();
            if (SaveBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sFinalDestination = SaveBox.SelectedPath;
                sFinalDestination += "\\" + Path.GetFileName(sFilePath);
                System.IO.File.Copy(sFilePath, sFinalDestination);
            }
        }
        #endregion

        private void SetLableClolor(ref Label lbl, bool setDefault)
        {
            if (!setDefault)
                lbl.BackColor = Color.LightSteelBlue;
            else
                lbl.BackColor = Color.Azure;
        }

        private void SetLableWidth(ref Label lbl, int width)
        {
            lbl.Width = width;
        }


    }
}
