using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.TrCusdecHed")]
    public partial class TrCusdecHed
    {
        public bool? Deleted { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgncyCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string MAWBNo { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CusdecNo { get; set; }

        [StringLength(50)]
        public string CusdecMAWBNo { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string AgnAWBNo { get; set; }

        public int? OrgCode { get; set; }

        [StringLength(60)]
        public string OrgName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InvNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalLC { get; set; }

        [StringLength(1)]
        public string BillY { get; set; }

        [StringLength(1)]
        public string ManifestNF { get; set; }

        [StringLength(1)]
        public string OrganizationNF { get; set; }

        [StringLength(1)]
        public string ChargeCodeNF { get; set; }

        [StringLength(1)]
        public string BillTo { get; set; }

        [StringLength(10)]
        public string BillAccount { get; set; }

        [StringLength(100)]
        public string BillName { get; set; }

        [StringLength(12)]
        public string ConsID { get; set; }

        [StringLength(1)]
        public string ShipType { get; set; }

        [StringLength(1)]
        public string MissRoute { get; set; }

        [StringLength(15)]
        public string ExpressID { get; set; }

        [StringLength(7)]
        public string Doctype { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransDate { get; set; }

        [StringLength(4000)]
        public string GoodDescrip { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CustomValue { get; set; }

        [StringLength(5)]
        public string CustomValCur { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GlobleTax { get; set; }

        public int? USM_LOGIN { get; set; }

        public DateTime? USM_DATE { get; set; }

        [StringLength(200)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(100)]
        public string Person { get; set; }

        [StringLength(10)]
        public string SalesCode { get; set; }

        [StringLength(50)]
        public string OrgCity { get; set; }

    }
}
