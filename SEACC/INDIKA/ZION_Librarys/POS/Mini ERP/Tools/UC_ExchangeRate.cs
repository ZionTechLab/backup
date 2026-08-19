using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using DataTire;

namespace Digiteq
{
    public partial class UC_ExchangeRate : UserControl
    {
        public delegate void valueChanged();
        public event valueChanged ExRateChanged;

        public UC_ExchangeRate()
        {
            InitializeComponent();
        }

        #region properties
        public decimal ExchangeRate
        {
            get
            {
                return decimal.Parse(txtCurrencyRate.Text.Trim());
            }
        }

        public string CurrencyCode
        {
            get
            {
                return txtCurCode.Tag.ToString().Trim();
            }
        } 
        #endregion

        public void ClearFields()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurCode, true);
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }

        private void txtCurCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }

        private void txtCurCode_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }

        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurCode);
            if (txtCurCode.Tag != null)
                FillDetailsCurrency(txtCurCode.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            ExRateChanged();
        }

        #region Fill
        public void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurCode.Tag = null;
                txtCurCode.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurCode.Tag = currency.Currency_ID;
                        txtCurCode.Text = currency.CurrencyName;
                        txtCurrencyRate.Text = currency.CurrencyRate.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void FillDetailsCurrency(string sCurrencyID, decimal ExRate)
        {
            try
            {
                txtCurCode.Tag = null;
                txtCurCode.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurCode.Tag = currency.Currency_ID;
                        txtCurCode.Text = currency.CurrencyName;
                        txtCurrencyRate.Text = ExRate.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        } 
        #endregion
    }
}