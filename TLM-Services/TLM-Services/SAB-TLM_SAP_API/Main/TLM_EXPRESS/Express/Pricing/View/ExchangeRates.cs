
using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory;
using Express.UI.Helpers;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Express
{
    public partial class ExchangeRates : Form  , IDataManipulate
    {
        private readonly IExchangeRatesDataProvider<ExchangeRatesView> _extProvider;
        private readonly ExchangeRatesView _model;
        private  List<CurrencyDetailDomainView> _CurrencyList;
        private readonly RefExgRatesDomainView _rateValue;
        private ManifestClearenceDomainView _manifestConfig;
        private ExchangeRateStatus _extStatus;
        public ExchangeRates( ExchangeRateStatus _extStatus)
        {
            InitializeComponent();
            if (_extProvider == null)
            {
                _extProvider =   PricingUIFactory.GetService<IExchangeRatesDataProvider<ExchangeRatesView>>();
            }
            currCode.ReadOnly = false;
            _model = new ExchangeRatesView();
            _CurrencyList = new List<CurrencyDetailDomainView>();
            FormState = FormStateEnum.Initial;
            _manifestConfig =_extProvider.GetManifestClearenceConf(LoginInfoView.COMPANYID);
            this._extStatus = _extStatus;
            InitialConfig();           
        }

        public ExchangeRates(ref RefExgRatesDomainView _rateValue , ManifestClearenceDomainView _manifestConfig , ExchangeRateStatus _extStatus)
        {
            InitializeComponent();
            if (_extProvider == null)
            {
                _extProvider = PricingUIFactory.GetService<IExchangeRatesDataProvider<ExchangeRatesView>>();
            }
            _model = new ExchangeRatesView();
            _CurrencyList = new List<CurrencyDetailDomainView>();
            currCode.ReadOnly = false;
            this._rateValue = _rateValue;
            this._manifestConfig = _manifestConfig;
            this._extStatus = _extStatus;
            InitialConfig();
           
        }

        private void InitialConfig()
        {
            this.Text = "Exchange Rates";
            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);


            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);
            SetEnableDisalbe(false);
            extRateList.AutoGenerateColumns = false;
            InitializeOpenLocation();
        }


        private void InitializeOpenLocation( )
        {
            if (_extStatus == ExchangeRateStatus.NON)
            {
                extRateTypes.DataSource = _extProvider.GetExchangeRateTypes("ALL").ToList();
                extRateTypes.Enabled = true;
            }
            else if (_extStatus == ExchangeRateStatus.CLEARENCE)
            {
                extRateTypes.DataSource = _extProvider.GetExchangeRateTypes("ALL").Where(ex => ex.ExgRatTarif == _manifestConfig.ClearanceExgRatTarif).ToList();
                extRateTypes.Enabled = false;
            }
           
        }
        private void ExchangeRates_Load(object sender, EventArgs e)
        {  
            InitialExchangeRate();
        }
        
        #region DTO

        private FormStateEnum _FormState;
        public FormStateEnum FormState
        {
            get { return _FormState; }
            set { _FormState = value; }
        }


        #endregion

        #region control events
       
        private void InitialExchangeRate()
        {
            var extTypeItem = (ExchaneRateTarifTypeView)extRateTypes.SelectedItem;
            baseCurrCode.Text = extTypeItem.BaseCurrency;
            baseCurrDesc.Text = extTypeItem.CurrencyN;
            _model.ExgRateTarif = extTypeItem.ExgRatTarif;
            _CurrencyList = _extProvider.GetCurrencyDetail("ALL").ToList();
            
            currList.DataSource = _CurrencyList;
            if (_rateValue !=null )
            {
                currCode.Text = _rateValue.Currency;
                effectDate.Value = _rateValue.EffectDate;
                currList.SelectedValue = _rateValue.Currency;
                effectDate.Value = _rateValue.EffectDate;
                extRate.Text = _rateValue.ExgRate.ToString();
                remarks.Text = _rateValue.Remarks;

                if(currList.SelectedValue ==null)
                {
                    currList.Enabled = false;
                    currCode.ReadOnly = true;
                    MessageNotification.MessageBoxError("Currency code is not exists, Please add currency code", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                }
            }
            else
            {
                currCode.Text = extTypeItem.DefCurrency;
                currList.SelectedValue = extTypeItem.DefCurrency;
            }
           
            
        }
        private void currList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currency = (CurrencyDetailDomainView)currList.SelectedItem; 
            if(currency!=null)         
                currCode.Text = currency.Currency;     
                

            if (_model.ExgRateTarif != 0 && currCode.Text!="")
            {
                SetExgrates();
               /// extRateList.DataSource = _extProvider.GetExchangeRate(_model.ExgRateTarif, currCode.Text.Trim());
            }
            else
            {
                ClearGrid();
            }

        }

        
        #endregion

        #region Data Maniflulate

        public void NewMethod(object param , EventArgs e)
        {
            FormState = FormStateEnum.New;            

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false , ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false , ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true , ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true , ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            if(_extStatus ==ExchangeRateStatus.CLEARENCE )
            {

            }
            else
            {
                effectDate.Value = DateTime.Now;
                extRate.Text = "";
                remarks.Text = "";
            }
           
            SetEnableDisalbe(true);
        }

        public void SaveMethod(object param , EventArgs e)
        {
            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
            ResponseMessage responce = null;

            if( !CustomValidate.Instance.TryPassDecimal(extRate.Text))
            {
                MessageNotification.MessageBoxError("Please enter valid value to exchange rate", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }


            //////if(FormState == FormStateEnum.Save && effectDate.Value.Date <DateTime.Now.Date)
            //////{
            //////    MessageNotification.MessageBoxError("Exchange rate can not update past dates", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            //////    return;
            //////}

            _model.Currency = currCode.Text;
            _model.EffectDate = effectDate.Value;
            _model.ExgRate = Convert.ToDecimal(extRate.Text);
            _model.ExgRateTarif = _model.ExgRateTarif;
            _model.Remarks = remarks.Text;
            _model.UserID = 1;

            if(_rateValue!=null)
            {
                if (_rateValue.Currency != _model.Currency)
                {
                    MessageNotification.MessageBoxError("Please select manifest currency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
            }                
          

            var vResult = CustomValidate.Instance.ValidateModel(_model);       

            if (vResult == "")
            {
               var vCurr=  _CurrencyList.Where(curr => curr.Currency.ToUpper() == currCode.Text.ToUpper());
                if(vCurr ==null || vCurr.Count()==0)
                {
                    MessageNotification.MessageBoxError("Please select valid currency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if (FormState == FormStateEnum.Save)
                {
                    responce = _extProvider.SaveDetails(_model);
                }
                if (FormState == FormStateEnum.Update)
                {
                    responce = _extProvider.EditDetails(_model);
                }


                if (responce.IsSuccess)
                {
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);

                    if(_rateValue !=null )
                    {
                        _rateValue.Currency = _model.Currency;
                        _rateValue.ExgRate = _model.ExgRate;
                        _rateValue.Remarks = remarks.Text;
                    }
                    dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

                    ////extRateList.DataSource = _extProvider.GetExchangeRate(_model.ExgRateTarif, currCode.Text.Trim());
                    SetExgrates();
                    SetEnableDisalbe(false);
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

        public void EditMethod(object param , EventArgs e)
        {
            FormState = FormStateEnum.Update;
          
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false , ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false , ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true , ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            SetEnableDisalbe(true);
            effectDate.Enabled = false;
        }

        public void ClearMethod(object param , EventArgs e)
        {
            FormState = FormStateEnum.Clear;       
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);


            effectDate.Value = DateTime.Now;
            extRate.Text = "";
            remarks.Text = "";
            SetEnableDisalbe(false);

        }

        public void DeleteMethod(object param , EventArgs e)
        {
            FormState = FormStateEnum.Delete;
        }

        public void CloseForm(object param , EventArgs e)
        {
            this.Dispose();
        }

        public void FilterMethod(object param , EventArgs e)
        {
           
        }

        public void PrintMethod(object param, EventArgs e)
        {
           
        }

        public void previewMethod(object param , EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ImportMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region methods
        private void SetEnableDisalbe(bool val)
        {
            effectDate.Enabled = val;
            extRate.Enabled = val;
            remarks.Enabled = val;

        }
        #endregion


        ////////private  async Task< IList<ExchaneRateTarifTypeView>> GetExtRate()
        ////////{
        ////////    // Task.FromResult is a placeholder for actual work that returns a string.  
        ////////    var result = await Task.FromResult<IList<ExchaneRateTarifTypeView>>(_extProvider.GetExchangeRateTypes("ALL"));

        ////////    // The method then can process the result in some way.  


        ////////    return result;
        ////////}

        ////////private async Task<IList< CurrencyDetailDomainView>> GetCurrency()
        ////////{
        ////////    // Task.FromResult is a placeholder for actual work that returns a string.  
        ////////    var result = await Task.FromResult< IList< CurrencyDetailDomainView>>(_extProvider.GetCurrencyDetail("ALL"));

        ////////    // The method then can process the result in some way.  


        ////////    return result;
        ////////}

        private void extRateTypes_KeyDown(object sender, KeyEventArgs e)
        {
            //if (extRateTypes.DataSource == null)
            //{
            //    extRateTypes.DataSource = _extProvider.GetExchangeRateTypes("ALL");
            //}
        }

        private void currList_KeyDown(object sender, KeyEventArgs e)
        {
            if (currList.DataSource==null )
            {
                currList.DataSource = _extProvider.GetCurrencyDetail("ALL");
            }           
        }

       

        private void extRateTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearGrid();
            var extType = (ExchaneRateTarifTypeView)extRateTypes.SelectedItem;
            

            if (_model.ExgRateTarif != 0 && currCode.Text!=""  && extType!=null)
            {
                _model.ExgRateTarif = extType.ExgRatTarif;
                ///extRateList.DataSource = _extProvider.GetExchangeRate(_model.ExgRateTarif, currCode.Text.Trim());
                SetExgrates();
            }

        }

        private void currCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClearGrid();
            ////
            ////if (currValues == null || currValues.Count == 0)
            ////{
            ////    currCode.Text = "";
            ////}
            ////else
            ////{
            ////    currList.DataSource = currValues;
            ////}

            if (e.KeyChar == 13)
            {
                ClearGrid();
                // ClearCurrency();
                if (_CurrencyList != null && _CurrencyList.Count > 0)
                {
                    var currValues = _CurrencyList.FindAll(curr => curr.Currency.ToUpper().Contains(currCode.Text.ToUpper()));

                    if (currValues == null || currValues.Count == 0)
                    {
                        currCode.Text = "";
                    }
                    else
                    {
                        currList.DataSource = currValues;
                    }


                }
                else
                {
                    currCode.Text = "";
                }
            }
            else
            {
                //var currValues = _CurrencyList.FindAll(curr => curr.Currency.ToUpper().Contains(currCode.Text.ToUpper()));
                //if (currValues != null && currValues.Count> 0)
                //{                  

                //    currList.DataSource = currValues;
                //}
            }
        }

        private void ClearGrid()
        {
            if (extRateList.DataSource != null)
            {
                extRateList.DataSource = null;
            }
        }

        private void SetExgrates()
        {
            extRateList.DataSource = _extProvider.GetExchangeRate(_model.ExgRateTarif, currCode.Text.Trim());
        }

        private void ClearCurrency()
        {
           if( currList.DataSource !=null)
            {
                currList.DataSource = null;
            }

        }

        private void rateBackworks_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void rateBackworks_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {


        }
        private void extRateList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (FormState == FormStateEnum.Initial && _rateValue != null)
            {
                effectDate.Value = _rateValue.EffectDate;
                extRate.Text = _rateValue.ExgRate.ToString();
                remarks.Text = _rateValue.Remarks;
            }
            else
            {
                var rVal = (ExchangeRatesView)e.Row.DataBoundItem;
                if (rVal != null)
                {
                    effectDate.Value = rVal.EffectDate;
                    extRate.Text = rVal.ExgRate.ToString();
                    remarks.Text = rVal.Remarks;

                }
                else
                {
                    effectDate.Value = DateTime.Now;
                    extRate.Text = "";
                    remarks.Text = "";
                }
            }


        }
       

      
    }
}
