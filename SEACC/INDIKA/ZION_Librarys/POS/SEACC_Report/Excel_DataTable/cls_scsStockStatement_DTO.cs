using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_Report.Excel_DataTable
{
    class cls_scsStockStatement_DTO
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string ItemCatID { get; set; }
        public string ItemCatName { get; set; }

        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal UtilizedQty { get; set; }
        
        public decimal GRNQty { get; set; }
        public decimal PRNQty { get; set; }
        public decimal GINQty { get; set; }
        public decimal GTNFromQty { get; set; }
        public decimal GTNToQty { get; set; }
        public decimal AdjQty { get; set; }
        public decimal DGNQty { get; set; }
        public decimal DINQty { get; set; }
        public decimal ISNFromQty { get; set; }
        public decimal IGINQty { get; set; }
        public decimal IGRNQty { get; set; }
        public decimal FGTNQty { get; set; }

        public decimal DOQty { get; set; }
        public decimal SRNQty { get; set; }

        public decimal PGINMin { get; set; }
        public decimal PGINAdd { get; set; }
        public decimal PGRNMin { get; set; }
        public decimal PGRNAdd { get; set; }
        public decimal SubOutMin { get; set; }
        public decimal SubOutAdd { get; set; }
        public decimal SubInReturnedMin { get; set; }
        public decimal SubInReturnedAdd { get; set; }
        public decimal SubInMin { get; set; }
        public decimal SubInAdd { get; set; }
        public decimal WIP { get; set; }
        public decimal WIPSemiFinished { get; set; }
        public decimal PFGTN { get; set; }
        public decimal PFGTNAcceptance { get; set; }
        public decimal PItemSplitAdd { get; set; }
        public decimal PItemSplitMin { get; set; }

        public decimal Other { get; set; }
    }
}
