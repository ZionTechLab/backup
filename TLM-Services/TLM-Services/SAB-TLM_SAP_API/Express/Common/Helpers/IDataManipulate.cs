using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.Helpers
{
    public interface IDataManipulate
    {
        void NewMethod(object param , EventArgs e);
        void SaveMethod(object param , EventArgs e);
        void EditMethod(object param , EventArgs e);
        void ClearMethod(object param, EventArgs e);
        void DeleteMethod(object param, EventArgs e);
        void CloseForm(object param, EventArgs e);
        void FilterMethod(object param, EventArgs e);
        void PrintMethod(object param, EventArgs e);
        void previewMethod(object param, EventArgs e);
        void ImportMethod(object param, EventArgs e);
        void ProccessMethod(object param, EventArgs e);
    }
}
