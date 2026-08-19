
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express
{
    public partial class Form1 : Form , IDataManipulate
    {
        public Form1()
        {
            InitializeComponent();
            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);            
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE , false, ButtonCustomState.HIDEVISIBLE);
        }

        public void ClearMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void CloseForm(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void EditMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void FilterMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ImportMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void NewMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void previewMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void PrintMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SaveMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
