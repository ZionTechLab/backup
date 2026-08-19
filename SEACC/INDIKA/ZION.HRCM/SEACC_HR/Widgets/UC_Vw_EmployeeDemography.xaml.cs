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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.IO;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_Vw_EmployeeDemography.xaml
    /// </summary>
    public partial class UC_Vw_EmployeeDemography : UserControl
    {
        public sp_genMasEmployee Employee;

        public UC_Vw_EmployeeDemography()
        {
            InitializeComponent();
            ClearFields();
        }

        public static DependencyProperty ColorTheam_Property = DependencyProperty.Register("ColorTheam", typeof(Brush), typeof(UC_Vw_EmployeeDemography));
        public Brush ColorTheam
        {
            get
            {
                return (Brush)GetValue(ColorTheam_Property);
            }
            set
            {
                SetValue(ColorTheam_Property, value);
            }

        }

        public void setEmployeeDetail(string employeeId)
        {
            try
            {
                Employee = sp_genMasEmployee.Select(employeeId);
                if (Employee != null)
                {
                    lblEmployeeNo.Text = Employee.Employee_ID;
                    lblFullName.Text = Employee.Title + " " + Employee.FullName;
                    lblInitails.Text = Employee.Initails;
                    lblSurname.Text = Employee.SurName;
                    lblaliasName.Text = Employee.AliasName;
                    lblGender.Text = ((Gender)Employee.Gender).ToString();
                    lblNIC.Text = Employee.NicNo;
                    lblPassport.Text = Employee.PassportNo;
                    lblDOB.Text = Employee.DateOfBirth.ToString(clsConfig.Format_Date);
                    lblCivilStatus.Text = ((CivilState)Employee.CivilState).ToString();
                    lblStatus.Text = Employee.Emp_status_Name;
                    lblVisaEndDate.Text = Employee.VisaEndDate.ToString(clsConfig.Format_Date) == clsConfig.defaultDateTime.Date.ToString(clsConfig.Format_Date) ? "-" : Employee.VisaEndDate.ToString(clsConfig.Format_Date);
                    lblDivision.Text = Employee.DivisionName;
                    lblDepartment.Text = Employee.DepartmentName;
                    lblSection.Text = Employee.Section_Name;
                    lblSubSection.Text = Employee.SubSectionName;
                    lblDesignation.Text = Employee.Designation_name;
                    lblEPF.Text = Employee.EpfNo;
                    lblcategory1.Text = Employee.EmpCatagory1_Name;
                    lblcategory2.Text = Employee.EmpCatagory2_Name;
                    lblcategory3.Text = Employee.EmpCatagory3_Name;

                    pbx_Employee.Source = clsCommon.Convert_ByteToBitMap(Employee.Employee_Image);
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        public void ClearFields()
        {
            lblEmployeeNo.Text = "-";
            lblFullName.Text = "-";
            lblInitails.Text = "-";
            lblSurname.Text = "-";
            lblaliasName.Text = "-";
            lblGender.Text = "-";
            lblNIC.Text = "-";
            lblPassport.Text = "-";
            lblDOB.Text = "-";
            lblCivilStatus.Text = "-";
            lblStatus.Text = "-";
            lblVisaEndDate.Text = "-";
            lblDivision.Text = "-";
            lblDepartment.Text = "-";
            lblSection.Text = "-";
            lblSubSection.Text = "-";
            lblDesignation.Text = "-";
            lblEPF.Text = "-";
            lblcategory1.Text = "-";
            lblcategory2.Text = "-";
            lblcategory3.Text = "-";
            pbx_Employee.Source = null;
        }

        private void btnShowHide_Click(object sender, RoutedEventArgs e)
        {
            if (grdDetail.Visibility == Visibility.Visible)
            {
                grdDetail.Visibility = Visibility.Collapsed;
                btnShowHide.Content = "";
            }
            else
            {
                grdDetail.Visibility = Visibility.Visible;
                btnShowHide.Content = "";
            }
        }
    }
}