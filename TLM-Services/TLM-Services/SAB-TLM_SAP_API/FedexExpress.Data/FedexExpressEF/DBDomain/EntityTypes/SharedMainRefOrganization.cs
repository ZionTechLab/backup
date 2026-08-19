using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{

    [Table("SharedMain.RefOrganization")]
    public class SharedMainRefOrganization
    {
        public bool Deleted { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        public int OrgCode1 { get; set; }

        public int OrgCode2 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrgCode { get; set; }

        public int OrgGroup { get; set; }

        [StringLength(60)]
        public string OrgName { get; set; }

        [StringLength(50)]
        public string OrgRefId { get; set; }

        [StringLength(1)]
        public string OrgIndividual { get; set; }

        public int OrgIndStatues { get; set; }

        [StringLength(30)]
        public string CompRegNo { get; set; }

        [StringLength(15)]
        public string PersonIDNo { get; set; }

        [StringLength(15)]
        public string PersonPPNo { get; set; }

        [StringLength(60)]
        public string OrgAddr1 { get; set; }

        [StringLength(60)]
        public string OrgAddr2 { get; set; }

        public int OrgCityCode { get; set; }

        [StringLength(30)]
        public string OrgCity { get; set; }

        [StringLength(2)]
        public string OrgCountry { get; set; }

        [StringLength(10)]
        public string OrgPostCode { get; set; }

        [StringLength(20)]
        public string OrgState { get; set; }

        [StringLength(40)]
        public string OrgPhone { get; set; }

        [StringLength(30)]
        public string OrgMobile { get; set; }

        [StringLength(40)]
        public string OrgFax { get; set; }

        [StringLength(40)]
        public string OrgEmail { get; set; }

        [StringLength(100)]
        public string OrgURL { get; set; }

        [StringLength(100)]
        public string OrgRemarks { get; set; }

        [StringLength(1)]
        public string OrgActive { get; set; }

        public int USM_ID { get; set; }

        public DateTime USM_DATE { get; set; }
    }
}
