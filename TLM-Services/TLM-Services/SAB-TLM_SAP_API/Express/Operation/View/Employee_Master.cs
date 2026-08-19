using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Operation.View
{
    public partial class Employee_Master : Form, IDataManipulate
    {

        private readonly IEmployeeMaster<EmployeeMasterView> _empMaster;
        private readonly EmployeeMasterView _empMasterSave = new EmployeeMasterView();
        private string checkBox = "";
        private string responseMSG = "Already exists";

        public FormStateEnum FormState { get; private set; }

        public Employee_Master()
        {
            InitializeComponent();

            if (_empMaster == null)
            {
                _empMaster = OperationsUIFacotry.GetService<IEmployeeMaster<EmployeeMasterView>>();
            }

            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);


            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);

            grdEmpMaster.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtEmpCode.ReadOnly = true;
            txtEmpName.ReadOnly = true;
            txtRemarks.ReadOnly = true;

            txtEmpCode.MaxLength = 15;
            txtEmpName.MaxLength = 50;
            txtRemarks.MaxLength = 100;

            chkActive.Checked = true;
            chkActive.Enabled = false;

            ShowGridView();
            GridFieldsDisable();

        }

        public void ShowGridView()
        {
            var showGrid = _empMaster.GetEmployeeMasterGrid();
            grdEmpMaster.DataSource = showGrid.ToList();
            grdEmpMaster.AutoGenerateColumns = false;
        }

        public void ClearFields()
        {
            txtEmpCode.Text = "";
            txtEmpName.Text = "";
            txtRemarks.Text = "";
        }

        public void GridFieldsDisable()
        {
            grdEmpMaster.Columns["EmployeeID"].ReadOnly = true;
            grdEmpMaster.Columns["EmployeeName"].ReadOnly = true;
            grdEmpMaster.Columns["Remarks"].ReadOnly = true;
            grdEmpMaster.Columns["Active"].ReadOnly = true;

        }


        public void ClearMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Clear;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            ClearFields();

            txtEmpCode.ReadOnly = true;
            txtEmpName.ReadOnly = true;
            txtRemarks.ReadOnly = true;
            chkActive.Enabled = false;
            chkActive.Checked = true;

            grdEmpMaster.ReadOnly = false;
            grdEmpMaster.Enabled = true;

            grdEmpMaster.DataSource = null;
            ShowGridView();
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
            FormState = FormStateEnum.Update;

            grdEmpMaster.ReadOnly = false;
            grdEmpMaster.Enabled = true;
            chkActive.Enabled = true;
            grdEmpMaster.Enabled = false;
            GridFieldsDisable();

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);

            txtEmpCode.ReadOnly = true;
            txtEmpName.ReadOnly = false;
            txtRemarks.ReadOnly = false;

            //ShowGridView();
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
            FormState = FormStateEnum.New;

            grdEmpMaster.ReadOnly = true;
            grdEmpMaster.Enabled = false;
            chkActive.Enabled = true;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            ClearFields();

            txtEmpCode.ReadOnly = false;
            txtEmpName.ReadOnly = false;
            txtRemarks.ReadOnly = false;

            ShowGridView();
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
            GridFieldsDisable();

            if (txtEmpCode.Text != "" && txtEmpName.Text != "")
            {

                FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
                ResponseMessage responce = null;

                _empMasterSave.EmployeeID = txtEmpCode.Text;
                _empMasterSave.EmployeeName = txtEmpName.Text;
                _empMasterSave.Remarks = txtRemarks.Text;
                _empMasterSave.Active = checkBox;

                var vResult = CustomValidate.Instance.ValidateModel(_empMasterSave);


                if (vResult == "")
                {

                    if (FormState == FormStateEnum.Save)
                    {
                        responce = _empMaster.SaveDetails(_empMasterSave);
                    }
                    if (FormState == FormStateEnum.Update)
                    {
                        responce = _empMaster.EditDetails(_empMasterSave);
                    }


                    if (responce.IsSuccess) // after save result
                    {

                        MessageBox.Show("Save Successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);

                        ShowGridView();
                        ClearFields();
                        FormState = FormStateEnum.Clear;

                        dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

                        txtEmpCode.ReadOnly = true;
                        txtEmpName.ReadOnly = true;
                        txtRemarks.ReadOnly = true;
                        chkActive.Enabled = false;
                        chkActive.Checked = true;

                        grdEmpMaster.Enabled = true;
                    }

                    string response = responce.StrMessage;


                    if (String.Equals(response, responseMSG))
                    {
                        MessageBox.Show("Employee Code already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ClearFields();
                    }
                }

            }
            else
            {
                MessageBox.Show("Employee Code/Name can't be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            }
        }

        
        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked == true)
            {
                checkBox = "Y";
            }
            else
            {
                checkBox = "";
            }
        }

        private void grdEmpMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);

                    DataGridViewRow row = this.grdEmpMaster.Rows[e.RowIndex];

                    txtEmpCode.Text = row.Cells["EmployeeID"].Value.ToString();
                    txtEmpName.Text = row.Cells["EmployeeName"].Value.ToString();
                    txtRemarks.Text = row.Cells["Remarks"].Value.ToString();

                }
            }

            catch (Exception)

            {
            }
        }
    }
}
