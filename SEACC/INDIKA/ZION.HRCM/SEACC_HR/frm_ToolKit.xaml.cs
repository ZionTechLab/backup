using System;
using System.Collections.Generic;
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
using DataTire;
using Digiteq_Logic;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frm_ToolKit.xaml
    /// </summary>
    public partial class frm_ToolKit : Window
    {
        #region Form Load
        public frm_ToolKit()
        {
            InitializeComponent();
        } 
        #endregion

        private void btn_genarate_Search_Enum_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public enum Search");
            sb.AppendLine("{");
            foreach (tbl_cfgSearch oSearch in tbl_cfgSearch.SelectAll())
            {
                sb.AppendLine(oSearch.SearchName + " = " + oSearch.SearchId + ",");
            }
            sb.AppendLine("}");
            txtbox1.Text = sb.ToString();
        }

        private void btn_genarate_Search_Quary_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from [dbo].[tbl_cfgSearch]");
            sb.AppendLine("go");
            sb.AppendLine("");
            foreach (tbl_cfgSearch oSearch in tbl_cfgSearch.SelectAll())
            {
                sb.AppendLine("INSERT INTO [dbo].[tbl_cfgSearch] ([searchId],[searchName],[displayName],[searchTable],[selection1],[selection2],[width])   VALUES(" + oSearch.SearchId + ",'" + oSearch.SearchName + "','" + oSearch.DisplayName + "','" + oSearch.SearchTable + "','" + oSearch.Selection1.Replace("'", "''") + "','" + oSearch.Selection2.Replace("'", "''") + "'," + oSearch.Width + ")");
            }
            sb.AppendLine("go");
            sb.AppendLine("");

            sb.AppendLine("delete from [dbo].[tbl_cfgSearchDetail]");
            sb.AppendLine("go");
            sb.AppendLine("");
            foreach (tbl_cfgSearchDetail oSearch in tbl_cfgSearchDetail.SelectAll())
            {
                sb.AppendLine("INSERT INTO [dbo].[tbl_cfgSearchDetail] ([searchId],[fieldOrder],[fieldName],[displayName],[datatype],[size],[isFilter],[FilterOrder]) VALUES(" + oSearch.SearchId + "," + oSearch.FieldOrder + ",'" + oSearch.FieldName + "','" + oSearch.DisplayName + "','" + oSearch.Datatype + "'," + oSearch.Size + "," + (oSearch.IsFilter ? 1 : 0) + "," + oSearch.FilterOrder + ")");
            }
            sb.AppendLine("go");
            sb.AppendLine("");
            txtbox1.Text = sb.ToString();
        }

        private void Btn_Device_Syncronization_Click(object sender, RoutedEventArgs e)
        {
            DeviceSyncronization oDs = new DeviceSyncronization();
            oDs.Show();
        }

        #region Quary for "tbl_securityFormMaster"
        private void btn_genarate_Form_Quary_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
           foreach (tbl_securityFunctionMaster form in tbl_securityFunctionMaster.SelectAll())
            {
                sb.AppendLine("IF EXISTS (SELECT * FROM dbo.tbl_securityFunctionMaster WHERE function_ID =" + form.Function_ID + ")");

                sb.AppendLine("UPDATE dbo.tbl_securityFunctionMaster SET");
                sb.AppendLine("[function_Code] = '" + form.Function_Code + "',");
                sb.AppendLine("[functionName] = '" + form.FunctionName + "',");
                sb.AppendLine("[functionCategory_ID] = '" + form.FunctionCategory_ID + "',");
               // sb.AppendLine("[displayName] ='" + form.DisplayName + "',");
                sb.AppendLine("[isEnable] ='" + form.IsEnable + "',");
                sb.AppendLine("[isReport]='" + form.IsReport + "'");
               // sb.AppendLine("[isViewer]='" + form.IsViewer + "'");
                sb.AppendLine("WHERE function_ID = '" + form.Function_ID + "'");
                sb.AppendLine("ELSE");
                sb.AppendLine("INSERT INTO [SEACC_HRCM].[dbo].[tbl_securityFunctionMaster]");
                sb.AppendLine("([function_ID]");
                sb.AppendLine(",[function_Code]");
                sb.AppendLine(",[functionName]");
                sb.AppendLine(",[functionCategory_ID]");
                sb.AppendLine(",[isEnable]");
                sb.AppendLine(",[isReport])");
                sb.AppendLine("VALUES(");
                sb.AppendLine("'" + form.Function_ID + "',");
                sb.AppendLine("'" + form.Function_Code + "',");
                sb.AppendLine("'" + form.FunctionName + "',");
                sb.AppendLine("	'" + form.FunctionCategory_ID + "',");
                sb.AppendLine("'" + form.IsEnable + "',");
                sb.AppendLine("'" + form.IsReport + "');");

                sb.AppendLine("go");
                sb.AppendLine("");
                txtbox1.Text = sb.ToString();
            }
        }
        #endregion

        private void btn_genarate_Form_Enum_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public enum FormName");
            sb.AppendLine("{");
            foreach (tbl_securityFunctionMaster oSearch in tbl_securityFunctionMaster.SelectAll())
            {
                sb.AppendLine(oSearch.FunctionName.Replace(" ","_").Replace("-","_") + " = " + oSearch.Function_ID + ",");
            }
            sb.AppendLine("}");
            txtbox1.Text = sb.ToString();
        }
    }
}