using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinancePR.Debt")]
    public partial class Debt
    {
        public bool Deleted { get; set; }

        public int CMPY { get; set; }

        public int AgncyCode { get; set; }

        [StringLength(5)]
        public string BranchCode { get; set; }

        [StringLength(5)]
        public string DeptCode { get; set; }

        [StringLength(5)]
        public string SlockCode { get; set; }

        [StringLength(10)]
        public string DocId { get; set; }

        [StringLength(7)]
        public string DocType { get; set; }

        public DateTime DocDate { get; set; }

        public DateTime PostDate { get; set; }

        public DateTime TransDate { get; set; }

        public long JobNo { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal InvNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DocNo { get; set; }

        [StringLength(50)]
        public string DocReference { get; set; }

        [StringLength(15)]
        public string ReferenceID1 { get; set; }

        public int OrgCode { get; set; }

        public short SeqNo { get; set; }

        [StringLength(10)]
        public string RevsDocId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RevsDocNo { get; set; }

        public decimal VALFC { get; set; }

        [StringLength(5)]
        public string FC { get; set; }

        public decimal ConvRate { get; set; }

        public decimal VALRS { get; set; }

        public decimal BALANCE { get; set; }

        public decimal PMVALRS { get; set; }

        [StringLength(5)]
        public string LC { get; set; }

        [StringLength(10)]
        public string AccountCode { get; set; }

        [StringLength(5)]
        public string PayMode { get; set; }

        [StringLength(20)]
        public string PayRefNo { get; set; }

        [StringLength(50)]
        public string PayRefBank { get; set; }

        public DateTime PayDate { get; set; }

        [StringLength(50)]
        public string PayTo { get; set; }

        [StringLength(1)]
        public string PayAcPay { get; set; }

        [StringLength(50)]
        public string RefNo1 { get; set; }

        [StringLength(50)]
        public string RefNo2 { get; set; }

        [StringLength(50)]
        public string RefNo3 { get; set; }

        public DateTime TranDate1 { get; set; }

        public DateTime TranDate2 { get; set; }

        [StringLength(60)]
        public string OrgName { get; set; }

        [StringLength(60)]
        public string OrgPerson { get; set; }

        [StringLength(60)]
        public string OrgAddr1 { get; set; }

        [StringLength(60)]
        public string OrgAddr2 { get; set; }

        [StringLength(30)]
        public string OrgCity { get; set; }

        [StringLength(2)]
        public string OrgCountry { get; set; }

        [StringLength(30)]
        public string TaxRegNo { get; set; }

        [StringLength(5)]
        public string TaxCode1 { get; set; }

        [StringLength(5)]
        public string TaxCode2 { get; set; }

        [StringLength(5)]
        public string TaxCode3 { get; set; }

        public decimal TaxCode1Val { get; set; }

        public decimal TaxCode2Val { get; set; }

        public decimal TaxCode3Val { get; set; }

        public decimal TaxCode1Per { get; set; }

        public decimal TaxCode2Per { get; set; }

        public decimal TaxCode3Per { get; set; }

        [StringLength(500)]
        public string Remarks1 { get; set; }

        [StringLength(500)]
        public string Remarks2 { get; set; }

        [StringLength(10)]
        public string CurrentAc { get; set; }

        [StringLength(10)]
        public string ControlAc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ControlPostNo { get; set; }

        public DateTime ControlPostDate { get; set; }

        [StringLength(1)]
        public string DocCancel { get; set; }

        public short USM_ID { get; set; }

        public DateTime? USM_DATE { get; set; }

        [StringLength(25)]
        public string ReferenceID { get; set; }

        [StringLength(5)]
        public string DCLCODE { get; set; }

        [StringLength(100)]
        public string Naration { get; set; }

        [StringLength(1)]
        public string ch { get; set; }

        [StringLength(50)]
        public string ChqRef { get; set; }

        [StringLength(50)]
        public string RefNo { get; set; }

        [StringLength(15)]
        public string VATNO { get; set; }

        [StringLength(15)]
        public string SVATNO { get; set; }

        [StringLength(1)]
        public string Check_After { get; set; }

        [StringLength(20)]
        public string USM_LOGIN { get; set; }

        [StringLength(20)]
        public string ChqNo { get; set; }

        [StringLength(1)]
        public string cata { get; set; }

        public DateTime CANCELDATE { get; set; }
    }
}
