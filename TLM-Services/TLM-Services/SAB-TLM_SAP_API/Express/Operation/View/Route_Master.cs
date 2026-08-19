using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory;
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
    public partial class Route_Master : Form, IDataManipulate
    {
        private readonly IRouteMaster<RouteMasterView> _routeMaster;
        private readonly RouteMasterView _routeMasterSave = new RouteMasterView();
        private string checkBox = "";
        private string responseMSG = "Already exists";
        
        public FormStateEnum FormState { get; private set; }

        public Route_Master()
        {
            InitializeComponent();

            if (_routeMaster == null)
            {
                _routeMaster = OperationsUIFacotry.GetService<IRouteMaster<RouteMasterView>>();
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

            grdRouteMaster.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtRouteCode.ReadOnly = true;
            txtRouteName.ReadOnly = true;
            txtRemarks.ReadOnly = true;

            txtRouteCode.MaxLength = 10;
            txtRouteName.MaxLength = 50;
            txtRemarks.MaxLength = 100;

            chkActive.Checked = true;
            chkActive.Enabled = false;

            ShowGridView();
            GridFieldsDisable();
            grdRouteMaster.AutoGenerateColumns = false;

        }

        public void ShowGridView()
        {
            var showGrid = _routeMaster.GetRoutMasterGrid();
            grdRouteMaster.DataSource = showGrid.ToList();
            grdRouteMaster.AutoGenerateColumns = false;
        }

        public void ClearFields()
        {
            txtRouteCode.Text = "";
            txtRouteName.Text = "";
            txtRemarks.Text = "";                      
        }

        public void GridFieldsDisable()
        {
            grdRouteMaster.Columns["SvcRootID"].ReadOnly = true;
            grdRouteMaster.Columns["SvcRootName"].ReadOnly = true;
            grdRouteMaster.Columns["Remarks"].ReadOnly = true;
            grdRouteMaster.Columns["Active"].ReadOnly = true;
            
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

            txtRouteCode.ReadOnly = true;
            txtRouteName.ReadOnly = true;
            txtRemarks.ReadOnly = true;
            chkActive.Checked = true;

            grdRouteMaster.ReadOnly = false;
            grdRouteMaster.Enabled = true;
            chkActive.Enabled = false;


            grdRouteMaster.DataSource = null;
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

            grdRouteMaster.ReadOnly = false;
            grdRouteMaster.Enabled = true;
            chkActive.Enabled = true;
            grdRouteMaster.Enabled = false;
            GridFieldsDisable();

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);

            txtRouteCode.ReadOnly = true;
            txtRouteName.ReadOnly = false;
            txtRemarks.ReadOnly = false;

           // ShowGridView();
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

            grdRouteMaster.ReadOnly = true;
            grdRouteMaster.Enabled = false;
            chkActive.Enabled = true;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
           
            ClearFields();

            txtRouteCode.ReadOnly = false;
            txtRouteName.ReadOnly = false;
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
            //bool b1 = String.IsNullOrWhiteSpace(txtRouteCode.Text.Trim());
            //bool b2 = String.IsNullOrWhiteSpace(txtRouteName.Text.Trim());
            GridFieldsDisable();

            if (txtRouteCode.Text != "" && txtRouteName.Text != "")
            {

                FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
                ResponseMessage responce = null;

               // _routeMasterSave.CMPY = cmpy;
                _routeMasterSave.SvcRootID = txtRouteCode.Text;
                _routeMasterSave.SvcRootName = txtRouteName.Text;
                _routeMasterSave.Remarks = txtRemarks.Text;
                _routeMasterSave.Active = checkBox;

                grdRouteMaster.AutoGenerateColumns = false;

                var vResult = CustomValidate.Instance.ValidateModel(_routeMasterSave);


                if (vResult == "")
                {

                    if (FormState == FormStateEnum.Save)
                    {
                        responce = _routeMaster.SaveDetails(_routeMasterSave);
                    }
                    if (FormState == FormStateEnum.Update)
                    {
                        responce = _routeMaster.EditDetails(_routeMasterSave);
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

                        txtRouteCode.ReadOnly = true;
                        txtRouteName.ReadOnly = true;
                        txtRemarks.ReadOnly = true;
                        chkActive.Enabled = false;
                        chkActive.Checked = true;

                        grdRouteMaster.Enabled = true;

                    }
                   
                    string response = responce.StrMessage;
                  

                    if (String.Equals(response, responseMSG))
                    {
                        MessageBox.Show("Route Code already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ClearFields();
                    }              
                    
                }

            }
            else
            {
                MessageBox.Show("Route Code/Name can't be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            }       
            
        }

        //private void grdRouteMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //           // dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                 
        //            DataGridViewRow row = this.grdRouteMaster.Rows[e.RowIndex];

        //            txtRouteCode.Text = row.Cells["SvcRootID"].Value.ToString();
        //            txtRouteName.Text = row.Cells["SvcRootName"].Value.ToString();
        //            txtRemarks.Text = row.Cells["Remarks"].Value.ToString();                   

        //        }
        //    }

        //    catch (Exception)

        //    {
        //    }
        //}

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

        private void grdRouteMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);

                    DataGridViewRow row = this.grdRouteMaster.Rows[e.RowIndex];

                    txtRouteCode.Text = row.Cells["SvcRootID"].Value.ToString();
                    txtRouteName.Text = row.Cells["SvcRootName"].Value.ToString();
                    txtRemarks.Text = row.Cells["Remarks"].Value.ToString();

                }
            }

            catch (Exception)

            {
            }


        }
               
    }
}
