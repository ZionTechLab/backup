using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Express.UI.Common.Helpers;
using Express.UI.Common.Enum;

namespace Express.UI.Common.CustomControl
{
    public partial class DataManipulate : UserControl , IDataManipulate
    {
        private Dictionary<ButtonTypes, Button> _Buttons;
        public DataManipulate()
        {
            InitializeComponent();
          if(_Buttons ==null )
            {
                _Buttons = new Dictionary<ButtonTypes, Button>();
                _Buttons.Add(ButtonTypes.NEW, this.newBtn);
                _Buttons.Add(ButtonTypes.EDIT , this.editBtn);
                _Buttons.Add(ButtonTypes.SAVE, this.saveBtn);
                _Buttons.Add(ButtonTypes.CANCEL, this.cancelBtn);
                _Buttons.Add(ButtonTypes.DELETE, this.deleteBtn);
                _Buttons.Add(ButtonTypes.CLOSE, this.closeBtn);
                _Buttons.Add(ButtonTypes.PRINT, this.printBtn);
                _Buttons.Add(ButtonTypes.PREVIEW, this.previewBtn);
                _Buttons.Add(ButtonTypes.PROCESS, this.processBtn);
                _Buttons.Add(ButtonTypes.IMPORT, this.importBtn);

            }
        }
        public event EventHandler NewButtonClick;
        public event EventHandler SaveButtonClick;
        public event EventHandler EditButtonClick;
        public event EventHandler CancelButtonClick;
        public event EventHandler DelteButtonClick;
        public event EventHandler PrintButtonClick;
        public event EventHandler PreviewButtonClick;
        public event EventHandler ProcessButtonClick;
        public event EventHandler ImportButtonClick;
        public event EventHandler CloseButtonClick;

        public void ClearMethod(object param, EventArgs e)
        {
            if (this.CancelButtonClick != null)
                this.CancelButtonClick(this, e);
        }

        public void CloseForm(object param, EventArgs e)
        {
            if (this.CloseButtonClick != null)
                this.CloseButtonClick(this, e);
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            if (this.DelteButtonClick != null)
                this.DelteButtonClick(this, e);
        }

        internal void CustomButtonState(object iMPORT, bool v, object hIDEVISIBLE)
        {
            throw new NotImplementedException();
        }

        public void EditMethod(object param, EventArgs e)
        {
            if (this.EditButtonClick != null)
                this.EditButtonClick(this, e);
        }

        public void FilterMethod(object param, EventArgs e)
        {
           
        }

        public void ImportMethod(object param, EventArgs e)
        {
            if (this.ImportButtonClick != null)
                this.ImportButtonClick(this, e);
        }

        public void NewMethod(object param, EventArgs e)
        {
            if (this.NewButtonClick != null)
                this.NewButtonClick(this, e);
        }

        public void previewMethod(object param, EventArgs e)
        {
            if (this.PreviewButtonClick != null)
                this.PreviewButtonClick(this, e);
        }

        public void PrintMethod(object param, EventArgs e)
        {
            if (this.PrintButtonClick != null)
                this.PrintButtonClick(this, e); 
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            if (this.ProcessButtonClick != null)
                this.ProcessButtonClick(this, e);
        }

        public void SaveMethod(object param, EventArgs e)
        {
            if (this.SaveButtonClick != null)
                this.SaveButtonClick(this, e);
        }


        /// <summary>
        /// Can manage button enble/disble and visible/hide states
        /// </summary>
        /// <param name="buttonType">button type (ex newbutton )</param>
        /// <param name="value">true/false</param>
        /// <param name="btnState">enble/disabel or visible/hide</param>
        public void CustomButtonState(ButtonTypes buttonType, bool value , ButtonCustomState btnState)
        {
            SetButtonStatus(_Buttons[buttonType], value, btnState);
        }

        private void SetButtonStatus(Button button , bool value , ButtonCustomState btnState)
        {
            if (btnState == ButtonCustomState.DISABLEENABBLE )
            {
                button.Enabled = value;
            }
            else if( btnState ==ButtonCustomState.HIDEVISIBLE )
            {
                button.Visible = value;
            }
        }

        

       
    }
}
