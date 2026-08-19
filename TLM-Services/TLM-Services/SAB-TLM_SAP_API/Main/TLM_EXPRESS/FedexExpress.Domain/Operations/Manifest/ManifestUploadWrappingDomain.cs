using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class ManifestUploadWrappingDomain
    {
        public List<OpsConsAWBDomainView> AwbList { get; set; }
        public List<ConsMasterDomainView> ConsList { get; set; }
    }
}
