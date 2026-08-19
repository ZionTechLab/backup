using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    public partial class SeaccRichTextBox : UserControl
    {
        public SeaccRichTextBox()
        {
            InitializeComponent();
        }

        public string FormatedText
        {
            get
            {
                return this.txtDesc.Rtf;
            }
            set
            {
                this.txtDesc.Rtf = value;
            }
        }

        private void btn_Bold_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Bold.Checked)
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style | FontStyle.Bold);
            else
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style & ~FontStyle.Bold);
            txtDesc.Focus();
        }

        private void btn_Italic_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Italic.Checked)
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style | FontStyle.Italic);
            else
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style & ~FontStyle.Italic);
            txtDesc.Focus();
        }

        private void btn_Underline_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Underline.Checked)
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style | FontStyle.Underline);
            else
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style & ~FontStyle.Underline);
            txtDesc.Focus();
        }

        private void btn_Strick_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Strick.Checked)
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style | FontStyle.Strikeout);
            else
                txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style & ~FontStyle.Strikeout);
            txtDesc.Focus();
        }

        private void fontComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Font font = new Font(fontComboBox1.Text, txtDesc.SelectionFont.Size, txtDesc.SelectionFont.Style);
                txtDesc.SelectionFont = new Font(font, txtDesc.SelectionFont.Style);
            }
            catch (Exception)
            {

            }
            txtDesc.Focus();
        }

        private void cbxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Font font = new Font(txtDesc.SelectionFont.FontFamily, float.Parse(cbxFontSize.Text), txtDesc.SelectionFont.Style);

                txtDesc.SelectionFont = new Font(font, txtDesc.SelectionFont.Style);
            }
            catch (Exception)
            {

                //  throw;
            }
            txtDesc.Focus();
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.I)
            {
                if (!txtDesc.SelectionFont.Style.ToString().Contains(FontStyle.Italic.ToString()))
                    txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style | FontStyle.Italic);
                else
                    txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style & ~FontStyle.Italic);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.B)
            {
                if (!txtDesc.SelectionFont.Style.ToString().Contains(FontStyle.Bold.ToString()))
                    txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style | FontStyle.Bold);
                else
                    txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style & ~FontStyle.Bold);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.U)
            {
                if (!txtDesc.SelectionFont.Style.ToString().Contains(FontStyle.Underline.ToString()))
                    txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style | FontStyle.Underline);
                else
                    txtDesc.SelectionFont = new Font(txtDesc.SelectionFont, txtDesc.SelectionFont.Style & ~FontStyle.Underline);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btn_addImage_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Image image = Image.FromFile(openFileDialog1.FileName);

                // Put the image on the clipboard
                Clipboard.SetImage(image);

                //// Paste it into the rich tetx box.
                txtDesc.Paste();
            }



        }

        private void btn_FColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDesc.SelectionColor = colorDialog1.Color;

            }
        }

        private void btn_BackColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDesc.SelectionBackColor = colorDialog1.Color;
            }
        }

        private void btn_Bulert_Click(object sender, EventArgs e)
        {
            txtDesc.SelectionBullet = true;
        }

        private void txtDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtDesc.SelectionFont.Style.ToString().Contains(FontStyle.Italic.ToString()))
                    btn_Italic.Checked = false;
                else
                    btn_Italic.Checked = true;

                if (!txtDesc.SelectionFont.Style.ToString().Contains(FontStyle.Bold.ToString()))
                    btn_Bold.Checked = false;
                else
                    btn_Bold.Checked = true;

                if (!txtDesc.SelectionFont.Style.ToString().Contains(FontStyle.Underline.ToString()))
                    btn_Underline.Checked = false;
                else
                    btn_Underline.Checked = true;

                if (!txtDesc.SelectionFont.Style.ToString().Contains(FontStyle.Strikeout.ToString()))
                    btn_Strick.Checked = false;
                else
                    btn_Strick.Checked = true;
                fontComboBox1.Text = txtDesc.SelectionFont.Name;
                cbxFontSize.Text = txtDesc.SelectionFont.Size.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btn_BigViwer_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(txtDesc.Rtf);
            f2.ShowDialog();
        }
    }
}
