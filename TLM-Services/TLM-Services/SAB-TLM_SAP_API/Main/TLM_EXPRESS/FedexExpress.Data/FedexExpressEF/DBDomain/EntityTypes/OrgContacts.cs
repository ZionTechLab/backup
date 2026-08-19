using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Crm.OrgContacts")]
    public partial class OrgContacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactCode { get; set; }

        public int OrgCode { get; set; }

        public int GroupID { get; set; }

        public int CMPY { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int DesignationID { get; set; }

        [StringLength(50)]
        public string SchoolAttended { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(30)]
        public string HomePhone { get; set; }

        [StringLength(30)]
        public string OfficePhoneNo { get; set; }

        [StringLength(30)]
        public string ExtensionNo { get; set; }

        [StringLength(30)]
        public string DirectPhoneNo { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        public int TransportId { get; set; }

        [StringLength(300)]
        public string PersonalAchievements { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(30)]
        public string Race { get; set; }

        [StringLength(30)]
        public string Religion { get; set; }

        [StringLength(300)]
        public string OtherInfro { get; set; }

        [Column(TypeName = "date")]
        public DateTime WeddingAnniversary { get; set; }

        public int FamilyLifeId { get; set; }

        public int MaritalStatusCode { get; set; }

    }
}
