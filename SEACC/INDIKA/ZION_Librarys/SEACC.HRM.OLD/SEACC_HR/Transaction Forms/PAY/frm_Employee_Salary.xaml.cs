using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for frm_Employee_Salary.xaml
    /// </summary>
    public partial class frm_Employee_Salary : Window
    {
        DataTable dt_PayslipItems = new DataTable();
        DataTable dt_StatutaryItems_RawData = new DataTable();
        DataTable dt_StatutaryItems = new DataTable();

        public frm_Employee_Salary()
        {
            InitializeComponent();

            dt_PayslipItems.Columns.Add("payItem_ID");
            dt_PayslipItems.Columns.Add("payItem_Code");
            dt_PayslipItems.Columns.Add("payItem_Title");
            dt_PayslipItems.Columns.Add("payItem_Amount", typeof(decimal));

            dt_StatutaryItems_RawData.Columns.Add("payItem_ID");
            dt_StatutaryItems_RawData.Columns.Add("payItem_Code");
            dt_StatutaryItems_RawData.Columns.Add("stat_ID");
            dt_StatutaryItems_RawData.Columns.Add("stat_Code");
            dt_StatutaryItems_RawData.Columns.Add("stat_Title");
            dt_StatutaryItems_RawData.Columns.Add("stat_Pct");
            dt_StatutaryItems_RawData.Columns.Add("stat_Amount");

            dt_StatutaryItems.Columns.Add("stat_ID");
            dt_StatutaryItems.Columns.Add("stat_Code");
            dt_StatutaryItems.Columns.Add("stat_Title");
            dt_StatutaryItems.Columns.Add("stat_Pct");
            dt_StatutaryItems.Columns.Add("stat_Amount");

            dgrPayItem.ItemsSource = dt_PayslipItems.DefaultView;

            dt_StatutaryItems.DefaultView.Sort = "[stat_Title] DESC";
            dgrStatutary.ItemsSource = dt_StatutaryItems.DefaultView;
        }


        public void RefreshGrid(string sEmployeeID)
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtNetSalary, false, true, false);

            foreach (tbl_genMasEmployee_PaySlipItems oItem in tbl_genMasEmployee_PaySlipItems.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID))
            {
                dt_PayslipItems.Rows.Add(oItem.PayItem_ID, clsRef_Name.get_PaySlipItem_Code(oItem.PayItem_ID), clsRef_Name.get_PaySlipItem_Title(oItem.PayItem_ID), cls_Formater.FormatDecimal(oItem.Rate, 2));
                foreach (tbl_genMasEmployee_PaySlipItems_Statutary oStatItem in tbl_genMasEmployee_PaySlipItems_Statutary.SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID_PayItem_ID(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeID, oItem.PayItem_ID))
                    dt_StatutaryItems_RawData.Rows.Add(oStatItem.PayItem_ID, clsRef_Name.get_PaySlipItem_Code(oStatItem.PayItem_ID), oStatItem.StatutaryPayItem_ID, clsRef_Name.get_PaySlipItems_Statutary_Title(oStatItem.StatutaryPayItem_ID), clsRef_Name.get_PaySlipItems_Statutary_Title(oStatItem.StatutaryPayItem_ID), cls_Formater.FormatDecimal(oStatItem.Percentage, 2), cls_Formater.FormatDecimal((oItem.Rate * oStatItem.Percentage / 100), 2));
            }

            //var abc = from tab in dt_StatutaryItems_RawData.AsEnumerable()
            //          group tab by tab["stat_ID"]
            //    into groupDt
            //          select new
            //          {
            //              Group = groupDt.Key,
            //              Sum = groupDt.Sum((r) => decimal.Parse(r["stat_Amount"].ToString()))
            //          };

            var vStatutaryItems = from row in dt_StatutaryItems_RawData.AsEnumerable()
                                  group row by new { stat_ID = row["stat_ID"], stat_Code = row["stat_Code"], stat_Title = row["stat_Title"], stat_Pct = row["stat_Pct"] } into grp
                                  select new
                                  {
                                      stat_ID = grp.Key.stat_ID,
                                      stat_Code = grp.Key.stat_Code,
                                      stat_Title = grp.Key.stat_Title,
                                      stat_Pct = grp.Key.stat_Pct,
                                      Sum = grp.Sum((r) => decimal.Parse(r["stat_Amount"].ToString()))
                                  };

            foreach (var vStatutaryItem in vStatutaryItems)
                dt_StatutaryItems.Rows.Add(vStatutaryItem.stat_ID, vStatutaryItem.stat_Code, vStatutaryItem.stat_Title, vStatutaryItem.stat_Pct, vStatutaryItem.Sum);

            var vPayslipItem_Total = dt_PayslipItems.Compute("Sum(payItem_Amount)", "");
            var vEPF_8 = dt_StatutaryItems.Select("stat_ID = '" + clsConfig.sEPF_Employee + "'");

            decimal dEPF_8 = Convert.ToDecimal(vEPF_8[0]["stat_Amount"]);
            decimal dPayslipItem_Total = Convert.ToDecimal(vPayslipItem_Total);

            txtNetSalary.Text = (dPayslipItem_Total - dEPF_8).ToString();
        }

    }
}
