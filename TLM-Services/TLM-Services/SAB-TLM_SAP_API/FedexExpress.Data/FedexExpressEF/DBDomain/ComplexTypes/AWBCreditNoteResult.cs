using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public class AWBCreditNoteResult
    {
        public bool Deleted { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        public int AgncyCode { get; set; }

        [StringLength(5)]
        public string BranchCode { get; set; }

        [StringLength(5)]
        public string DeptCode { get; set; }

        [StringLength(5)]
        public string SlockCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string DocId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(7)]
        public string DocType { get; set; }

        public DateTime DocDate { get; set; }

        public long JobNo { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal InvNo { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal DocNo { get; set; }

        [StringLength(50)]
        public string DocReference { get; set; }

        [StringLength(15)]
        public string ReferenceID1 { get; set; }

        public int OrgCode { get; set; }

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

        [StringLength(20)]
        public string TaxRegNo1 { get; set; }

        [StringLength(20)]
        public string TaxRegNo2 { get; set; }

        [StringLength(20)]
        public string TaxRegNo3 { get; set; }

        [StringLength(20)]
        public string TaxRegNo4 { get; set; }

        [StringLength(500)]
        public string Remarks1 { get; set; }

        [StringLength(500)]
        public string Remarks2 { get; set; }

        [StringLength(30)]
        public string TaxRegNo { get; set; }

        [StringLength(25)]
        public string ReferenceID { get; set; }

        [StringLength(50)]
        public string RefNo { get; set; }

        [StringLength(15)]
        public string VATNO { get; set; }

        [StringLength(15)]
        public string SVATNO { get; set; }

        [StringLength(50)]
        public string AgncyName { get; set; }

        [StringLength(50)]
        public string CompName { get; set; }

        [StringLength(30)]
        public string BranchName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string SalesAreaName { get; set; }


    }
}
