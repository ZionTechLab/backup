using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.CfgFuelChartTypes")]
    public partial class CfgFuelChartType
    {
        public CfgFuelChartType()
        {
           // RatesSellCountryMasterHeds = new HashSet<RatesSellCountryMasterHed>();
        }

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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuelChart { get; set; }

        [StringLength(50)]
        public string FuelChartN { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<RatesSellCountryMasterHed> RatesSellCountryMasterHeds { get; set; }
    }
}
