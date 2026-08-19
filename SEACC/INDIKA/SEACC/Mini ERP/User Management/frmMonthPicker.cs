using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frmMonthPicker : Form
    {
        public string glb_sJobCode = "", glb_sSectionID = "";
        public DateTime glb_dtmPlanDate = new DateTime();
        public DateTime glb_dtmPlanDate_New = new DateTime();
        public frmMonthPicker()
        {
            InitializeComponent();
        }

        private void frmMonthPicker_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                if (glb_sJobCode.Length > 0 && glb_sSectionID.Length > 0)
                {
                    decimal dQty = 0;
                    string sUom = "", sItemID = "";
                    glb_dtmPlanDate_New = monthCalendar1.SelectionStart;
                    //tbl_pmsSectionPlan_Master oOld = tbl_pmsSectionPlan_Master.Select(glb_sSectionID, glb_dtmPlanDate.Date, glb_sJobCode);
                    //if (oOld != null && oOld.Job_ID != "default")
                    //{                        
                    //    oOld.SectionPlanDate = monthCalendar1.SelectionStart;
                    //    oOld.Update();
                    //}
                    //else
                    //{
                    //    foreach (tbl_pmsPrePlan oPlan in tbl_pmsPrePlan.SelectAllByProductionJob_ID(glb_sJobCode).Where(p => p.PrePlan_ID != "default" && !p.IsDeleted))
                    //    {
                    //        foreach (tbl_pmsPrePlan_SectionPath detail in tbl_pmsPrePlan_SectionPath.SelectAllByPrePlan_ID(oPlan.PrePlan_ID).Where(p => p.Section_ID == glb_sSectionID))
                    //        {
                    //            foreach (tbl_pmsPrePlan_SectionPath_OutputItem output in tbl_pmsPrePlan_SectionPath_OutputItem.SelectAllByLine_No_PrePlan_ID_Section_ID(detail.Line_No, detail.PrePlan_ID, detail.Section_ID))
                    //            {
                    //                dQty = glb_sSectionID == "SEC/001" ? output.Weight : output.Qty;
                    //                sUom = clsAutocode.getUOMID_FromSectionID(glb_sSectionID);
                    //                sItemID = output.Item_ID;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //    tbl_pmsSectionPlan_Master oNew = new tbl_pmsSectionPlan_Master(glb_sSectionID, monthCalendar1.SelectionStart.Date, glb_sJobCode, "", dQty, 1, sUom, sItemID);
                    //    oNew.Insert();
                    //}
                }
            }
            catch (Exception){}

            this.Close();
        }
    }
}
