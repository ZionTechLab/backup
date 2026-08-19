using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Helpers;
using Express.UI.Common.SrvReference;
using Express.UI.Factory.Operations;
using Express.UI.Helpers;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
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
    public partial class Manifest_InboundInvPopUp : Form
    {
        private readonly ManifestInbLVProPramDomainView _paraValue;
        private  ResponseMessage responce;
        private readonly IManifestInboundInvPopup _processProvider;
        public Manifest_InboundInvPopUp(decimal _dutyValue ,ref ResponseMessage responce , ManifestInbLVProPramDomainView _paraValue , string _localCurrency)
        {
            InitializeComponent();
            if(_processProvider ==null )
            {
                _processProvider = OperationsUIFacotry.GetService<IManifestInboundInvPopup>();
            }          
            txtCustomPay.Text = Convert.ToString(_dutyValue);
            this._paraValue = _paraValue;
            this.responce = responce;
            dtePayment.Value = DateTime.Now.Date;
            txtLocCurrency.Text = _localCurrency;
            txtPayVouNum.Text = _paraValue.PayVouNumber;
            GetDutyPayAccounts();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!MessageNotification.MessageBoxConfirm("Are sure want to process this ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                return;
            }

            try
            {
               
               ////if ( !NumberValidator.TryPassInteger(txtPayAccNo.Text ))
               //// {
               ////     MessageNotification.MessageBoxError("Please enter valid number to payment acc", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
               ////     return;
               //// }

               if(cmbPayAccount.SelectedItem ==null )
                {
                    MessageNotification.MessageBoxError("Please select payment acc", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                var payAcc = (InvDutyClrPayAccountDomainView)cmbPayAccount.SelectedItem;

                _paraValue.BayanNo = txtBayanNo.Text;
                _paraValue.PaymentRef = txtPayrefNo.Text;
                //_paraValue.PaymentAcc = Convert.ToInt32(txtPayAccNo.Text);
                _paraValue.PaymentAcc = Convert.ToInt32(payAcc.AccountCode);
                _paraValue.PaymentDate = dtePayment.Value.Date;

                var vResult = CustomValidate.Instance.ValidateModel(_paraValue);               
                if (vResult == "")
                {
                    responce = _processProvider.ProcessCostInvoice(_paraValue);
                    

                    if (responce.IsSuccess)
                    {
                        
                        MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                        if(txtPayVouNum.Text !="")
                        {
                            txtPayVouNum.Text = txtPayVouNum.Text+ " , " + responce.ReturnValue;
                        }
                        else
                        {
                            txtPayVouNum.Text = responce.ReturnValue;
                        }

                        HttpSapReference.SapSend();

                        this.Close();
                    }
                    else
                    {
                        MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    }
                }
                else
                {
                    MessageNotification.MessageBoxError(vResult, LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                }
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Manifest_InboundInvPopUp_Load(object sender, EventArgs e)
        {

        }

        private void GetDutyPayAccounts()
        {
            var payaccdet = _processProvider.GetClrPayAccounts(Convert.ToInt32(_paraValue.CompanyID));
            cmbPayAccount.DataSource = payaccdet;
            if (payaccdet.Where(pay => pay.DefV == "Y").Count() > 0)
            {
                cmbPayAccount.SelectedValue = payaccdet.Where(pay => pay.DefV == "Y").FirstOrDefault().AccountCode;
            }

        }
    }
}
