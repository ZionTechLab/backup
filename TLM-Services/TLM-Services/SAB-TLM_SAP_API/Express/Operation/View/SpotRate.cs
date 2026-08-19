using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory;
using Express.UI.Helpers;
using Express.View.Domain.Login;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Pricing.View
{
    public partial class SpotRate : Form, IDataManipulate
    {
        private readonly ISpotRates<SpotRatesDomainView> _spotCharges;
        private readonly SpotRatesDomainView _spotRateDomain;
        SpotRatesDomainView SelectedGridRow = null;
        int RoStateChengeIndex = 0;
        public FormStateEnum FormState { get; private set; }
        public SpotRate()
        {
            InitializeComponent();

            if (_spotCharges == null)
            {
                _spotCharges = PricingUIFactory.GetService<ISpotRates<SpotRatesDomainView>>();
            }
            _spotRateDomain = new SpotRatesDomainView();
            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);


            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);


            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);

            radioButton2.Checked = true;
            txt_awb.ReadOnly = true;
            txt_express.ReadOnly = true;
            txt_rate.ReadOnly = true;
            txt_remarks.ReadOnly = true;
        }

        public void ClearMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Clear;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);

            groupBox1.Enabled = true;
            txt_awb.ReadOnly = true;
            txt_express.ReadOnly = true;
            txt_rate.ReadOnly = true;
            txt_remarks.ReadOnly = true;
            dataGridView2.DataSource = null;

            txt_awb.Text = "";
            txt_express.Text = "";
            txt_rate.Text = "";
            txt_remarks.Text = "";
            txt_AwbNo.Text = "";
            date_transaction_from.Value = System.DateTime.Now;

        }

        public void CloseForm(object param, EventArgs e)
        {
            this.Dispose();
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Delete ;
            ResponseMessage responce = null;

            if (SelectedGridRow != null)
            {
                if (FormState == FormStateEnum.Delete)
                {
                    responce = _spotCharges.DeleteDetail(SelectedGridRow);

                }

                if (responce.IsSuccess)
                {
                    txt_awb.ReadOnly = true;
                    txt_express.ReadOnly = true;
                    txt_rate.ReadOnly = true;
                    txt_remarks.ReadOnly = true;
                    SelectedGridRow = null;
                  
                    dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);
                    FindMethord();
                    ClearText();
                    MessageNotification.MessageBoxOK("Delete Successful", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                }
                else
                {
                    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            else
            {
                MessageNotification.MessageBoxOK("Please Select the Spot Rate", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
            }
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

            FormState = FormStateEnum.New;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);

           // txt_AwbNo.Text = "";
            dataGridView2.DataSource = null;
            groupBox1.Enabled = false;


            txt_awb.Text = "";
            txt_express.Text = "";
            txt_rate.Text = "";
            txt_remarks.Text = "";

            txt_awb.ReadOnly = false;
            txt_express.ReadOnly = false;
            txt_rate.ReadOnly = false;
            txt_remarks.ReadOnly = false;
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
            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
            ResponseMessage responce = null;

            _spotRateDomain.Deleted = false;
            _spotRateDomain.AutoID = 0;
            _spotRateDomain.AgnAWBNo = txt_awb.Text.Trim();
            _spotRateDomain.ExpressID = txt_express.Text.Trim();
            _spotRateDomain.Remarks = txt_remarks.Text;
            _spotRateDomain.EnterDate = System.DateTime.Now.Date;
            _spotRateDomain.USM_DATE= System.DateTime.Now.Date;
            _spotRateDomain.USM_ID = LoginInfoView.USERID;
            _spotRateDomain.Rate = Decimal.Parse(txt_rate.Text == "" ? "0" : txt_rate.Text);

            if (FormState == FormStateEnum.Update)
            {
                MessageNotification.MessageBoxOK("Update is not allowed ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
            }
            else
            {

                if (txt_express.Text != "")
                {
                    var vResult = CustomValidate.Instance.ValidateModel(_spotRateDomain);

                    if (vResult == "")
                    {
                       
                        if (FormState == FormStateEnum.Save)
                        {
                            responce = _spotCharges.SaveDetails(_spotRateDomain);
                        }


                        if (responce.IsSuccess)
                        {
                            groupBox1.Enabled = true;
                            txt_awb.ReadOnly = true;
                            txt_express.ReadOnly = true;
                            txt_rate.ReadOnly = true;
                            txt_remarks.ReadOnly = true;
                            radioButton2.Checked = true;
                            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);
                            FindMethord();
                            MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                            ClearText();
                        }
                        else
                        {
                            MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                        }

                    }
                    else
                    {
                        MessageNotification.MessageBoxError(vResult, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    }
                }
                else
                {
                    MessageNotification.MessageBoxError("Invalid AWB No", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SpotRate_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txt_AwbNo.ReadOnly = true;
            date_transaction_from.Enabled = true;
            date_transaction_to.Enabled = true;
            dataGridView2.DataSource = null;
            txt_AwbNo.Text = "";
            ClearText();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            date_transaction_from.Enabled = false;
            date_transaction_to.Enabled = false;
            txt_AwbNo.ReadOnly = false;
            dataGridView2.DataSource = null;
            date_transaction_from.Value = System.DateTime.Now;
            date_transaction_to.Value = System.DateTime.Now;
            ClearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindMethord();
            //ClearText();
        }

        private void txt_awb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ValidateAWBDetail();
            }
        }
        public void ValidateAWBDetail()
        {
            if (txt_awb.Text != "")
            {
                SpotRatesAWBDomainView AWBResult = _spotCharges.GetAwbDetails(txt_awb.Text).FirstOrDefault();

                if(AWBResult ==null)
                {
                    MessageNotification.MessageBoxOK("Invalid AWB ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
                }
                else
                {
                    if (AWBResult.BillTransChgY != "Y")
                    {
                        txt_express.Text = AWBResult.ExpressID;
                        txt_awb.ReadOnly = true;
                        _spotRateDomain.TransDate = AWBResult.TransDate;
                    }
                    else
                    {
                        MessageNotification.MessageBoxOK("AWB already invoiced", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
                    }
                }
            }
            else
            {
                MessageNotification.MessageBoxOK("Invalid AWB ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
            }

        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

         

        }

        public void FindMethord()
        {
            if (radioButton2.Checked == true)
            {
                var SpotRateResult = _spotCharges.GetSpotDataFromDateRange(date_transaction_from.Value.Year + "-" + date_transaction_from.Value.Month + "-" + date_transaction_from.Value.Day, date_transaction_to.Value.Year + "-" + date_transaction_to.Value.Month + "-" + date_transaction_to.Value.Day).ToList();
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = SpotRateResult;
                dataGridView2.ClearSelection();
                ClearText();
            }
            else if (radioButton1.Checked == true)
            {
                var SpotRateResult = _spotCharges.GetSpotDataFromAwb(txt_AwbNo.Text.Trim());
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = SpotRateResult;
                dataGridView2.ClearSelection();
                ClearText();
            }
        }

        private void txt_rate_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(txt_rate.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    txt_rate.Text = txt_rate.Text.Remove(txt_rate.Text.Length - 1);
            //}
        }

        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public void ClearText()
        {
            txt_awb.Text = "";
            txt_express.Text = "";
            txt_rate.Text = "";
            txt_remarks.Text = "";
            SelectedGridRow = null;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
          

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var rVal = (SpotRatesDomainView)dataGridView2.SelectedRows[0].DataBoundItem;
            if (rVal != null)
            {
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                txt_awb.Text = rVal.AgnAWBNo;
                txt_express.Text = rVal.ExpressID.ToString();
                txt_remarks.Text = rVal.Remarks;
                txt_rate.Text = rVal.Rate.ToString();
                SelectedGridRow = rVal;
            }

        }

        private void date_transaction_from_ValueChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
        }

        private void date_transaction_to_ValueChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
        }
    }
}
